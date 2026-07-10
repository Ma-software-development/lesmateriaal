# Les 4 - Delegates

## Wat is een Delegate?

Een **delegate** is een verwijzing naar een functie. Met andere woorden: het is een variabele die een functie opslaat, zodat je die functie later kunt aanroepen via die variabele.

Simpel gezegd: een delegate is een "blueprint" voor functies met dezelfde handtekening (dezelfde parameters en return type).

---

## Waarom Delegates?

- Flexibiliteit: je kunt functies als data doorgeven
- Event-systemen: reageren op dingen die gebeuren (knop klik, speler dood, level compleet)
- Callbacks: iets doen nadat een taak klaar is
- **Decoupling**: verschillende onderdelen van je code kunnen met elkaar communiceren zonder elkaar rechtstreeks te kennen

---

## Basis Voorbeeld

```csharp



public class Player : MonoBehaviour
{
    // Stap 1: Definieer een delegate-type
    public delegate void OnPlayerDied();
    // Stap 2: Maak een instance van die delegate
    public OnPlayerDied playerDied;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Stap 3: Roep de delegate aan (als iemand een functie eraan gekoppeld heeft)
            playerDied?.Invoke();
        }
    }
}

// Stap 4: Koppel een functie aan de delegate
public class Level : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.playerDied += OnDied;  // += koppelt de functie aan
    }
    void OnDisable()
    {
        player.playerDied -= OnDied;
    }
    void OnDied()
    {
        SceneManager.ReloadScene(1);
    }
}
```

Herkennen jullie deze code nog? [In deze les hebben jullie Action Events leren gebruiken](../../../M5/Prog/02_Action_Events/README.md).

**Actions** zijn gebaseerd op **delegates**. Alleen bij Actions kun je een stap overslaan en hoef je niet eerst de delegate te definieren:

```Csharp

//Delegate maken:
public delegate void OnPlayerDied();
public OnPlayerDied playerDied;

//Action maken:
public Action OnPlayerDied playerDied;

```

Het `event` keyword zorgt er hierbij voor dat de delegate of action alleen aangeroepen kan worden vanuit het object of class waarin hij gedefinieerd is.

Een delegate of action zonder event kan overal vandaar worden getriggered.

```Csharp
public class Level : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.playerDied += OnDied;
        player.playerDied?.Invoke();
        //het script dat luistert triggert nu ook het event.
        //Dit zou alleen de verantwoordelijkheid van de Player moeten zijn.
    }
}
```

Door de delegate als `event` te definieren kan dit niet meer en dwing je SRP af.

```Csharp
public delegate void OnPlayerDied();
public event OnPlayerDied playerDied;
```

Een ander voordeel van Actions ten opzichte van delegates is dat je ook argumenten mee kunt geven via de Action:

```Csharp
public class Player : MonoBehaviour
{
    public event Action<int> OnPlayerDied playerDied;
    private int score = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerDied?.Invoke(score);
        }
    }
}
public class Level : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
        player.playerDied += OnDied;
    }
     void OnDied(int score)
    {
        Debug.Log($"Player score:{score}");
    }
}
```

Door je delegate of action `static` te maken hoef je geen referentie te hebben naar het object die deze verstuurt / aanroept en kun je rechtstreeks via de class naar de delegate of action luisteren.

```Csharp
public class Player : MonoBehaviour
{
    public delegate void OnPlayerDied();
    public static event OnPlayerDied playerDied;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Stap 3: Roep de delegate aan (als iemand een functie eraan gekoppeld heeft)
            playerDied?.Invoke();
        }
    }
}

public class Level : MonoBehaviour
{
    //Player player;    niet meer nodig
    void Start()
    {
        //player = FindObjectOfType<Player>();  niet meer nodig
        Player.playerDied += OnDied;  //er kan geluisterd worden naar een event via de class Player ipv het object player
    }
    void OnDisable()
    {
        player.playerDied -= OnDied;
        //unsubscriben is nu extra belangrijk omdat de delegates blijven bestaan op de Player class.

    }
    void OnDied()
    {
        SceneManager.ReloadScene(1);
    }
}
```

**Let op!:** als je vergeet te unsubscriben kan dat leiden tot memmory leaks en events die getriggered blijven worden terwijl de gameobjecten al weg zijn.

---

## Korte Samenvatting

| Concept        | Nut                                                           |
| -------------- | ------------------------------------------------------------- |
| **Delegate**   | Een type dat functies opslaat                                 |
| **Action**     | Een delegate die void teruggeeft (geen waarde)                |
| **static**     | Een delegate kan rechtstreeks vanaf de class worden gekoppeld |
| **+=**         | Een functie koppelen aan een delegate                         |
| **-=**         | Een functie ontkoppelen (belangrijk!)                         |
| **?.Invoke()** | Veilig aanroepen (null-safe)                                  |

---

## Praktisch Voorbeeld: Health System

```csharp
public class HealthSystem : MonoBehaviour
{
    public int health = 100;

    // Delegate declareren
    public Action onHealthChanged;
    public Action onDead;

    public void TakeDamage(int damage)
    {
        health -= damage;
        onHealthChanged?.Invoke();  // Zeg tegen alle luisteraars dat health veranderd is

        if (health <= 0)
        {
            onDead?.Invoke();  // Zeg tegen alle luisteraars dat we dood zijn
        }
    }
}

// UI script luistert naar health veranderingen
public class HealthUI : MonoBehaviour
{
    public Text healthText;

    void Start()
    {
        HealthSystem hs = FindObjectOfType<HealthSystem>();
        hs.onHealthChanged += UpdateHealthDisplay;
        hs.onDead += ShowGameOver;
    }

    void UpdateHealthDisplay()
    {
        HealthSystem hs = FindObjectOfType<HealthSystem>();
        healthText.text = "Health: " + hs.health;
    }

    void ShowGameOver()
    {
        Debug.Log("Game Over!");
    }
}
```

---

## Belangrijk: Unsubscribe!

```csharp
void OnDestroy()
{
    HealthSystem hs = FindObjectOfType<HealthSystem>();
    if (hs != null)
    {
        hs.onHealthChanged -= UpdateHealthDisplay;  // Verwijder listener
        hs.onDead -= ShowGameOver;
    }
}
```

Zonder unsubscribe kunnen geheugenleaks ontstaan!

---

## Voordelen van Delegates/Events

- Loose coupling — scripts hoeven elkaar niet direct te kennen
- One-to-many communicatie — één event kan veel scripts aansturen
- Clean code — makkelijker te lezen en onderhouden
- Reusability — dezelfde events kunnen in meerdere systemen gebruikt worden

---

## Opdracht 4: Score Collection Game

### Doel

Bouw een eenvoudig 3D-spel waarbij de speler rond loopt in een wereld en gele bolletjes (items) verzamelt. Elke verzamelde bol geeft punten. De score wordt real-time in een UI-element weergegeven door middel van **loose coupling via delegates**.
