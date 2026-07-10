# Step By Step — Scene Management & Coroutines
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt van scene wisselen met `SceneManager.LoadScene()`
- Je kunt een laadscherm bouwen met een `AsyncOperation`
- Je kunt `Coroutines` gebruiken voor tijdgebonden logica

---

## Achtergrond: Wat zijn Coroutines?

Een Coroutine is een functie die je kunt **pauzeren** en later **hervatten**, zonder de rest van het spel te blokkeren.

```csharp
// Normale functie: voert alles meteen uit
void NormalFunction()
{
    DoThingA();
    DoThingB(); // voert direct na A uit
}

// Coroutine: kan wachten tussen stappen
IEnumerator CoroutineExample()
{
    DoThingA();
    yield return new WaitForSeconds(2f); // wacht 2 seconden
    DoThingB(); // voert 2 seconden later uit
}
```

Start een Coroutine altijd met `StartCoroutine(MethodeName())`.

---

## Stap 1 — Scenes aanmaken en registreren

Je hebt minimaal 3 scenes nodig: `MainMenu`, `3d_Gym`, `GameOver`.

### Scenes toevoegen aan de Build Settings
1. **File > Build Settings**.
2. Klik **Add Open Scenes** voor de huidige scene.
3. Open de `MainMenu`-scene en voeg hem ook toe.
4. Open de `GameOver`-scene en voeg hem toe.
5. Controleer dat de volgorde klopt:
   - Index 0: `MainMenu`
   - Index 1: `3d_Gym`
   - Index 2: `GameOver`

> De scene-index gebruik je in `SceneManager.LoadScene(1)`. De naam werkt ook: `SceneManager.LoadScene("3d_Gym")`.

---

## Stap 2 — MainMenu-scene aanmaken

1. **File > New Scene**. Sla op als `MainMenu`.
2. Maak een Canvas: **GameObject > UI > Canvas**.
3. Voeg toe:
   - Een achtergrond-image (of kleurpaneel)
   - Een titel: **UI > Text - TextMeshPro** → "3d Gym Game"
   - Een Start-knop: **UI > Button - TextMeshPro** → tekst "Start"
   - Een Quit-knop: **UI > Button - TextMeshPro** → tekst "Stoppen"

4. Maak een script `MainMenuUI.cs`:

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;

    public void OnStartPressed()
    {
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene("3d_Gym");
    }

    public void OnQuitPressed()
    {
        audioSource.PlayOneShot(buttonSound);
        Application.Quit();

        // In de Editor: stop Play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
```

5. Koppel de knoppen:
   - Selecteer de Start-knop.
   - Scroll in de Inspector naar **On Click ()**.
   - Klik **+** → sleep het Canvas-object (met `MainMenuUI.cs`) hierheen.
   - Kies in het dropdown: **MainMenuUI > OnStartPressed**.
6. Herhaal voor de Quit-knop met `OnQuitPressed`.

---

## Stap 3 — Hover-animatie voor knoppen

1. Selecteer een knop.
2. In de Inspector → **Transition: Animation** (in plaats van Color Tint).
3. Klik **Auto Generate Animation**.
4. Unity maakt een Animator Controller aan. Open het in de Animator view.
5. Selecteer de `Highlighted`-state. Voeg een Scale-animatie toe (bijv. 1.05 × grootte).

---

## Stap 4 — GameManager Singleton aanmaken

Een Singleton is een object dat maar één keer bestaat, ook als je van scene wisselt.

1. Maak `GameManager.cs`:

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Gamedata die between scenes moet blijven
    public int Score { get; private set; } = 0;
    public float TimeElapsed { get; private set; } = 0f;
    public int Lives { get; private set; } = 3;

    void Awake()
    {
        // Zorg dat er maar één GameManager is
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Blijft bestaan tussen scenes
    }

    void Update()
    {
        TimeElapsed += Time.deltaTime;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void LoseLife()
    {
        Lives--;
        if (Lives <= 0)
            GameOver();
    }

    public void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
```

2. Maak een leeg GameObject in de `MainMenu`-scene: `GameManager`.
3. Koppel het script eraan.

---

## Stap 5 — Coroutine: Invincibility Frames

```csharp
using System.Collections;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration = 2f;
    [SerializeField] private float blinkInterval = 0.1f;
    [SerializeField] private Renderer playerRenderer;

    private bool isInvincible = false;

    public bool IsInvincible => isInvincible;

    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        // Schade toepassen...
        GameManager.Instance.LoseLife();

        StartCoroutine(InvincibilityRoutine());
    }

    IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;

        float timer = 0f;
        while (timer < invincibilityDuration)
        {
            // Knipperen: renderer aan/uit
            playerRenderer.enabled = !playerRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        // Zeker zichtbaar aan het einde
        playerRenderer.enabled = true;
        isInvincible = false;
    }
}
```

---

## Stap 6 — Coroutine: GameOver met vertraging

Voeg toe aan `HealthSystem.cs`:

```csharp
using System.Collections;

void Die()
{
    StartCoroutine(GameOverDelay());
}

IEnumerator GameOverDelay()
{
    // Speler-input uitschakelen
    GetComponent<MoveCharacterController>().enabled = false;

    // Wacht 2 seconden
    yield return new WaitForSeconds(2f);

    // Laad de GameOver scene
    GameManager.Instance.GameOver();
}
```

---

## Stap 7 — GameOver-scene aanmaken

1. **File > New Scene**. Sla op als `GameOver`.
2. Maak een Canvas met:
   - Titel: "Game Over"
   - Score-text: `TextMeshProUGUI` — vul in via script
   - Highscore-text: `TextMeshProUGUI`
   - Restart-knop
   - Menu-knop

3. Maak `GameOverUI.cs`:

```csharp
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;

    void Start()
    {
        int score = GameManager.Instance != null ? GameManager.Instance.Score : 0;
        scoreText.text = $"Score: {score}";

        // Highscore via PlayerPrefs
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            PlayerPrefs.Save();
        }
        highscoreText.text = $"Highscore: {highscore}";
    }

    public void OnRestartPressed()
    {
        SceneManager.LoadScene("3d_Gym");
    }

    public void OnMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
```

---

## Stap 8 — Asynchrone scene-loading met laadscherm (bonus)

```csharp
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image loadingBar;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // progress loopt van 0 tot 0.9 (0.9 = klaar, wacht op activatie)
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progress;

            if (operation.progress >= 0.9f)
            {
                // Wacht even zodat de balk vol lijkt
                yield return new WaitForSeconds(0.5f);
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
```

---

## Stap 9 — Afteltimer in 3d_Gym

Voeg toe aan `GameTimer.cs` (Les 10):

```csharp
void Update()
{
    timeLeft -= Time.deltaTime;
    timeLeft = Mathf.Max(0, timeLeft);

    // UI updaten
    int minutes = Mathf.FloorToInt(timeLeft / 60f);
    int seconds = Mathf.FloorToInt(timeLeft % 60f);
    timerText.text = $"{minutes:00}:{seconds:00}";

    // Timer kleurt rood als er minder dan 10 seconden zijn
    timerText.color = timeLeft <= 10f ? Color.red : Color.white;

    if (timeLeft <= 0f && running)
    {
        running = false;
        GameManager.Instance?.GameOver();
    }
}
```

---

## Stap 10 — Volledige game-loop testen

1. Start in `MainMenu`: druk Start → laadt `3d_Gym`.
2. In `3d_Gym`: loop rond, pak wrenches op, laat de timer aflopen of stuur `GameOver()` handmatig.
3. `GameOver`-scene laadt: score en highscore worden getoond.
4. Druk Restart: terug naar `3d_Gym`.
5. Druk Menu: terug naar `MainMenu`.

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Scene niet gevonden | Scene niet in Build Settings | File > Build Settings > Add Open Scenes |
| GameManager null na scene-wissel | Geen DontDestroyOnLoad | Voeg `DontDestroyOnLoad(gameObject)` toe in Awake |
| Twee GameManagers | Singleton-check ontbreekt | Voeg de Instance-check toe in Awake |
| Coroutine stopt niet | `StopCoroutine` niet aangeroepen | Gebruik `StopAllCoroutines()` bij reset |
| Highscore wordt niet opgeslagen | `PlayerPrefs.Save()` vergeten | Voeg `PlayerPrefs.Save()` toe na SetInt |

---

## Controlelijst voor afronding

- [ ] 3 scenes aangemaakt en toegevoegd aan Build Settings (juiste index)
- [ ] MainMenu met Start- en Quit-knop (met geluid)
- [ ] Knop-kliks roepen de juiste `SceneManager.LoadScene()`-methode aan
- [ ] GameManager singleton aangemaakt met `DontDestroyOnLoad`
- [ ] Score, timer en levens worden bijgehouden in GameManager
- [ ] Invincibility frames werken (speler knippert na schade)
- [ ] GameOver-scene laadt na 2 seconden vertraging (Coroutine)
- [ ] GameOver toont score en highscore (via PlayerPrefs)
- [ ] Restart-knop laadt 3d_Gym opnieuw
- [ ] Menu-knop gaat terug naar MainMenu
- [ ] Afteltimer in 3d_Gym triggert GameOver
