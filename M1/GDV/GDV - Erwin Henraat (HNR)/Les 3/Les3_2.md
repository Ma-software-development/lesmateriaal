# Les 3.2: Functies, Argumenten en Return Types

## Wat Ga Je Leren?

In deze les leer je hoe je je code kunt organiseren en herbruiken met functies. Je gaat:

- Begrijpen wat functies zijn en waarom ze handig zijn
- Je eerste eigen functies maken
- Argumenten (parameters) gebruiken om data door te geven
- Return types gebruiken om data terug te krijgen
- Code beter organiseren en minder herhalen

---

## Wat Zijn Functies?

Tot nu toe heb je al functies gebruikt zonder het te beseffen! `Start()`, `Update()`, en `Debug.Log()` zijn allemaal **functies**.

Een **functie** is zoals een **machine** die een specifieke taak uitvoert:

![vending machine](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExYW8xOGJpbzZ4cjZ6YmJsMGNuMmE5bGlxOWpiemp0MHlmd2I2NzhmeCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3orieNJ0AwwqqyQh44/giphy.gif)

**Vergelijking met een Snack Automaat:**

![insert](https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExbHF5M2JmcDVndzYxbWVxemZjZDUwNng3cXN6NTI1a24xNXlkcGR3NyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/l2Jeh5xaLwEJ3QWd2/giphy.gif)

- Je **stopt geld erin** (input/argumenten)
- De machine **doet zijn werk** (functie code)
- Je **krijgt een snack** (output/return value)

![output](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExbjQxeHB6bnNveXB4Mzd3ZGsxOHV5OTd5aGI4cm91bGRiZmhucHJlcSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/TY34ucEkhDtOo/giphy.gif)

### Waarom Functies Gebruiken?

**Probleem zonder functies:**

```csharp
void Update()
{
    // Spring code
    if (Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector3.up * 500);
        Debug.Log("Player jumped!");
    }

    // Later in de code: ook springen bij een andere actie
    if (enemyNearby)
    {
        rb.AddForce(Vector3.up * 500);  // Dezelfde code!
        Debug.Log("Player jumped!");   // Weer hetzelfde!
    }
}
```

**Oplossing met functies:**

```csharp
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        DoJump(); // Roep de functie aan
    }

    if (enemyNearby)
    {
        DoJump(); // Hergebruik dezelfde functie!
    }
}

void DoJump()
{
    rb.AddForce(Vector3.up * 500);
    Debug.Log("Player jumped!");
}
```

![don't repeat](../gfx/3_2_repeat.gif)

**Voordelen:**

- **Minder code herhaling** → schrijf het één keer, gebruik het overal
- **Makkelijker te veranderen** → wijzig op één plek, werkt overal
- **Beter georganiseerd** → elke functie heeft één duidelijke taak

---

### Functies vs Methods

**Functies** die beschikbaar worden gemaakt voor andere scripts (met het keyword `public`) noem je **Methods**.

```csharp
// Dit is een functie (alleen voor dit script)
private void MijnPrivateFunctie()
{
    Debug.Log("Alleen in dit script mag ik deze gebruiken");
}

// Dit is een method (andere scripts kunnen deze ook gebruiken)
public void MijnPubliekeMethod()
{
    Debug.Log("Andere scripts kunnen mij aanroepen!");
}
```

---

## Je Eerste Eigen Functie

### Basis Functie Syntax

```csharp
private void FunctieNaam()
{
    // Code die wordt uitgevoerd
}
```

**Uitleg:**

- `private` = mag ook `public` zijn
- `void` = Deze functie geeft niets terug (geen output)
- `FunctieNaam` = Kies een duidelijke naam (zoals `DoJump` of `PlaySound`)
- `()` = Hier tussen komen later argumenten (de input)
- `{}` = De code die wordt uitgevoerd (wat de machine doet)

### Voorbeeld: Welkomstbericht

```csharp
public class FunctionExample : MonoBehaviour
{
    void Start()
    {
        ShowWelcomeMessage(); // Roep onze functie aan
    }

    void ShowWelcomeMessage()
    {
        Debug.Log("=================");
        Debug.Log("Welkom bij mijn game!");
        Debug.Log("Veel plezier!");
        Debug.Log("=================");
    }
}
```

---

## Argumenten - Data Doorgeven aan Functies

### Wat Zijn Argumenten?

**Argumenten** zijn waarden die je aan **Parameters** meegeeft. De parameters geven deze waarden door aan de functie in een variabele.

```csharp
public class FunctionExample : MonoBehaviour
{
    void Start()
    {
        ShowWelcomeMessage("Kim");
        ShowWelcomeMessage("Jelle");
        ShowWelcomeMessage("Erwin"); // Roep onze functie aan
    }

    void ShowWelcomeMessage(string name)
    {
        Debug.Log("=================");
        Debug.Log("Hee! "+ name +"!");
        Debug.Log("Welkom bij mijn game!");
        Debug.Log("Veel plezier!");
        Debug.Log("=================");
    }
}
```

Hierboven is de variabele `naam` dus de **Parameter** en de waarden `"Kim", "Jelle" & "Erwin" ` zijn de **Argumenten**.

Met het `+`(plus)-symbool kun je de waarde van de variabele aan een string vastplakken.

### Verschillende Typen Parameters

```csharp
public class ArgumentExamples : MonoBehaviour
{
    void Start()
    {
        // String argument
        ShowMessage("Level Complete!");

        // Int argument
        AddScore(100);

        // Float argument
        MoveObject(5.5f);

        // Bool argument
        SetPlayerAlive(true);

        // Meerdere argumenten
        CreateEnemy("Goblin", 50, 2.0f);
    }

    void ShowMessage(string bericht)
    {
        Debug.Log("Bericht: " + bericht);
    }

    void AddScore(int punten)
    {
        Debug.Log("Score verhoogd met: " + punten);
    }

    void MoveObject(float snelheid)
    {
        transform.position += Vector3.right * snelheid * Time.deltaTime;
    }

    void SetPlayerAlive(bool isAlive)
    {
        Debug.Log("Player alive: " + isAlive);
    }

    void CreateEnemy(string type, int health, float speed)
    {
        Debug.Log("Created " + type + " with " + health + " HP and speed " + speed);
    }
}
```

### Physics Voorbeeld

```csharp
public class PhysicsFunctions : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(300.0f); // Normale sprong
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Jump(600.0f); // Super sprong!
        }

        // WASD beweging
        if (Input.GetKey(KeyCode.W)) PushObject(Vector3.forward, 10.0f);
        if (Input.GetKey(KeyCode.S)) PushObject(Vector3.back, 10.0f);
        if (Input.GetKey(KeyCode.A)) PushObject(Vector3.left, 10.0f);
        if (Input.GetKey(KeyCode.D)) PushObject(Vector3.right, 10.0f);
    }

    void Jump(float kracht)
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.up * kracht);
            Debug.Log("Jumped with force: " + kracht);
        }
    }

    void PushObject(Vector3 richting, float kracht)
    {
        if (rb != null)
        {
            rb.AddForce(richting * kracht);
        }
    }
}
```

---

## Return Types - Data Terugkrijgen

### Wat Zijn Return Types?

Tot nu toe hebben alle functies `void` gebruikt - ze geven niets terug. Maar functies kunnen ook **data terugsturen** naar de code die ze aanroept.

```csharp
int TellenTotTien()
{
    return 10; // Geef het getal 10 terug
}
```

**Hoe gebruik je het:**

```csharp
void Start()
{
    int getal = TellenTotTien(); // getal is nu 10
    Debug.Log("Het getal is: " + getal); // Output: "Het getal is: 10"
}
```

### Verschillende Return Types

```csharp
public class ReturnExamples : MonoBehaviour
{
    void Start()
    {
        // Return een int
        int leeftijd = GetPlayerAge();
        Debug.Log("Speler leeftijd: " + leeftijd);

        // Return een float
        float afstand = CalculateDistance();
        Debug.Log("Afstand: " + afstand);

        // Return een string
        string spelerNaam = GetPlayerName();
        Debug.Log("Speler naam: " + spelerNaam);

        // Return een bool
        bool kanSpringen = CanPlayerJump();
        if (kanSpringen)
        {
            Debug.Log("Speler kan springen!");
        }
    }

    int GetPlayerAge()
    {
        return 16; // Return een int
    }

    float CalculateDistance()
    {
        return Vector3.Distance(transform.position, Vector3.zero); // Return een float
    }

    string GetPlayerName()
    {
        return "SuperGamer"; // Return een string
    }

    bool CanPlayerJump()
    {
        return transform.position.y <= 1.0f; // Return een bool (true/false)
    }
}
```

### Argumenten EN Return - Het Beste van Beide

```csharp
public class MathFunctions : MonoBehaviour
{
    void Start()
    {
      // Return een int of basis van een geboortejaar, maand en dag.
        int leeftijd = GetPlayerAge(26, 11, 1979);
        Debug.Log("Speler leeftijd: " + leeftijd);

        // Return een float of basis van 2 posities(Vector3)
        float afstand = CalculateDistance( new Vector3(0f,1f,5f), new Vector3(11f,9f,6f) );
        Debug.Log("Afstand: " + afstand);

    }

    int GetPlayerAge(int dayOfB, int monthOfB, int yearOfB)
    {
        // Bereken leeftijd op basis van geboortedatum
        System.DateTime today = System.DateTime.Today;
        int age = today.Year - yearOfB;

        // Check of verjaardag dit jaar al is geweest
        if (today.Month < monthOfB || (today.Month == monthOfB && today.Day < dayOfB))
        {
            age--;
        }
        return age;//geef de leeftijd terug
    }

    float CalculateDistance(Vector3 pointA, Vector3 pointB)
    {
        return Vector3.Distance(pointA, pointB); // Return een float
    }
}
```

### Praktisch Game Voorbeeld

```csharp
public class GameLogic : MonoBehaviour
{
    public int playerHealth = 100;
    public int playerScore = 0;

    void Start()
    {
        // Test onze game functies
        TakeDamage(25);
        AddPoints(50);

        bool gameOver = IsGameOver();
        Debug.Log("Game Over: " + gameOver);

        string status = GetPlayerStatus();
        Debug.Log("Player status: " + status);
    }

    void TakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        Debug.Log("Player took " + damage + " damage. Health: " + playerHealth);

        if (IsGameOver())
        {
            Debug.Log("GAME OVER!");
        }
    }

    void AddPoints(int points)
    {
        playerScore = playerScore + points;
        Debug.Log("Added " + points + " points. Score: " + playerScore);
    }

    bool IsGameOver()
    {
        return playerHealth <= 0; // Return true als health 0 of minder is
    }

    string GetPlayerStatus()
    {
        if (playerHealth > 75)
        {
            return "Excellent";
        }
        else if (playerHealth > 50)
        {
            return "Good";
        }
        else if (playerHealth > 25)
        {
            return "Warning";
        }
        else
        {
            return "Critical";
        }
    }

    int CalculateLevel()
    {
        return playerScore / 100; // Elke 100 punten = nieuw level
    }
}
```

---

## Function Naming Best Practices

### Goede Function Namen - Goed

```csharp
// Verbs (werkwoorden) voor acties
void Jump()
void Attack()
void MoveLeft()
void PlaySound()

// Is/Can/Has voor boolean returns
bool IsPlayerAlive()
bool CanPlayerMove()
bool HasPlayerKey()

// Calculate voor berekeningen
float CalculateDistance()
int CalculateScore()
```

### Slechte Function Namen - Slecht

```csharp
void DoStuff()        // Te vaag
void Thing()          // Zegt niets
void X()              // Te kort
void HandleInputAndMovePlayerAndCheckCollisions() // Te lang
```

---

## Variabele Scope en Functions

### Wat is Variable Scope?

**Variable Scope** bepaalt waar in je code een variabele gebruikt kan worden.

```csharp
public class ScopeExample : MonoBehaviour
{
    // GLOBAL variabele - bruikbaar in alle functies
    public int globalScore = 0;

    void Start()
    {
        // LOCAL variabele - werkt alleen in Start()
        int localHealth = 50;

        globalScore = 100;     // ✅ Werkt - global variabele
        ShowScore();           // ✅ Werkt - functie aanroepen

        // localHealth kan NIET in ShowScore() gebruikt worden!
    }
    void AddScore(int amount){
        globalScore += amount;  // Werkt - globalScore = global & amount = local
    }
    void ShowScore()
    {
        Debug.Log("Score: " + globalScore);     //  Werkt - global variabele
        Debug.Log(localHealth);                 //  FOUT! localHealth bestaat hier niet
        Debug.Log(amount);                      //  FOUT! amount bestaat hier niet
    }


}
```

**Simpele regel:**

- **Global** (gemaakt buiten functies) - Overal bruikbaar `globalScore`
- **Local** (gemaakt binnen functies) - Alleen in die functie `localHealth`
- **Parameters** (gemaakt binnen functies) - Alleen in die functie `amount`

---

## Debug Tips voor Functies

### Function Flow Debuggen

```csharp
public class DebugFunctions : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start() called");
        TestFunction();
        Debug.Log("Start() finished");
    }

    void TestFunction()
    {
        Debug.Log("TestFunction() started");

        int result = Calculate(5, 3);
        Debug.Log("Calculate returned: " + result);

        Debug.Log("TestFunction() finished");
    }

    int Calculate(int a, int b)
    {
        Debug.Log("Calculate called with: " + a + ", " + b);
        int sum = a + b;
        Debug.Log("Calculate returning: " + sum);
        return sum;
    }
}
```

**Output in Console:**

```
Start() called
TestFunction() started
Calculate called with: 5, 3
Calculate returning: 8
Calculate returned: 8
TestFunction() finished
Start() finished
```

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat zijn functies en waarom gebruik je ze?
- Hoe maak je een functie met argumenten?
- Wat is het verschil tussen void en return functies?
- Hoe roep je een functie aan?
- Wanneer gebruik je functies in plaats van gewone code?
- Wat is het verschil tussen een **Local** en een **Global** variabele?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

## Oefeningen uitvoeren

Doe nu minimaal 1 oefening naar keuze voor les 3.2
De oefeningen vind je [hier](../Oefeningen/oefeningen_3_2.md) terug

![exercise](https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3ZXRrc3QwYWV1Ym5oY2FrZnF5YWxnaW9heTRsNnZzdnpnMmRxeXM1ZiZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/x1BVziEYuKBd1aVZRz/giphy.gif)

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je begrijpt wat functies zijn en waarom ze handig zijn
- [ ] Je kunt je eigen functies maken met void
- [ ] Je weet hoe je argumenten gebruikt om data door te geven
- [ ] Je kunt return types gebruiken om data terug te krijgen
- [ ] Je begrijpt het verschil tussen void en return functies
- [ ] Je kunt functies combineren met argumenten EN return values
- [ ] Je weet hoe je goede functie namen kiest
- [ ] Je hebt je code beter georganiseerd met functies

### Volgende Stap

In Les 4.1 gaan we leren over Colliders, Triggers en Tags. Dan kunnen we objecten laten reageren op elkaar!

---

## Veelgestelde Vragen

### Q: Wanneer maak ik een functie en wanneer niet?

**A:** Maak een functie als:

- Je dezelfde code meer dan 1 keer gebruikt
- Een stuk code een duidelijke taak heeft
- Je code leesbaarder wilt maken

### Q: Wat gebeurt er als ik een return statement vergeet?

**A:** Bij `void` functies is dat geen probleem. Bij andere return types krijg je een foutmelding van Unity.

### Q: Kan ik een functie vanuit een andere functie aanroepen?

**A:** Ja! Functies kunnen andere functies aanroepen. Dat heet "function composition".

### Q: Hoeveel argumenten kan een functie hebben?

**A:** Technisch onbeperkt, maar probeer onder de 5 argumenten te blijven voor leesbaarheid.

### Q: Moet ik altijd return gebruiken in return functies?

**A:** Ja! Elke functie met een return type (niet void) moet altijd een waarde terugsturen.

### Q: Kan ik variabelen uit andere functies gebruiken?

**A:** Nee, variabelen binnen functies zijn "local" - alleen bruikbaar binnen die functie. Gebruik argumenten en return values om data te delen.

---
