# Les 6.1 — Game State Manager

## Leerdoel

Na deze les kun je verschillende game states beheren en informatie delen tussen scripts.

---

## Theorie

### Game States

Een game heeft verschillende toestanden:

```
[Menu] → [Playing] → [Paused]
              ↓
         [GameOver] → [Menu]
```

| State        | Wat gebeurt er                    |
| ------------ | --------------------------------- |
| **Menu**     | Toon hoofdmenu, wacht op start    |
| **Playing**  | Game is actief, speler kan spelen |
| **Paused**   | Game bevroren, toon pause menu    |
| **GameOver** | Speler verloren, toon score       |
| **Victory**  | Level/game gewonnen               |

### State Manager

Gebruik een **enum** voor states:

```csharp
public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver,
    Victory
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState currentState = GameState.Menu;

    void Awake()
    {
        Instance = this;
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Menu:
                Time.timeScale = 1;
                // Toon menu UI
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                // Verberg menu's
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                // Toon pause menu
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                // Toon game over scherm
                break;
        }
    }
}
```

### Singleton Pattern

Een Singleton zorgt dat er maar één instance is:

```csharp
public static GameManager Instance;

void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
    }
}
```

Aanroepen vanuit andere scripts:

```csharp
GameManager.Instance.SetState(GameState.GameOver);
```

### Events voor State Changes

```csharp
public static event System.Action<GameState> OnStateChanged;

public void SetState(GameState newState)
{
    currentState = newState;
    OnStateChanged?.Invoke(newState);
}

// In ander script:
void OnEnable()
{
    GameManager.OnStateChanged += HandleStateChange;
}

void HandleStateChange(GameState newState)
{
    if (newState == GameState.Paused)
    {
        // Pauzeer dit object
    }
}
```

---

## Oefeningen

### Oefening 1: Simpele State Manager

Maak een basic state manager:

**1. GameManager.cs:**

```csharp
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Menu, Playing, Paused, GameOver }
    public GameState currentState = GameState.Menu;

    public GameObject menuPanel;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetState(GameState.Menu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
                SetState(GameState.Paused);
            else if (currentState == GameState.Paused)
                SetState(GameState.Playing);
        }
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        // TODO: Activeer/deactiveer juiste panels
        // TODO: Zet Time.timeScale (0 = pauze, 1 = normaal)
    }

    // UI Button functies
    public void StartGame() => SetState(GameState.Playing);
    public void PauseGame() => SetState(GameState.Paused);
    public void GameOver() => SetState(GameState.GameOver);
}
```

**2. Test:**

- Start in Menu state
- Klik start → Playing
- ESC → Paused (game freezed)
- ESC → Playing (game resumed)

---

### Oefening 2: Score Persistence

Houd de score bij tussen scene loads:

```csharp
public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public int score = 0;
    public int highScore = 0;
    public int currentLevel = 1;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
```

**Test:**

- Verzamel punten
- Ga game over
- Restart → High score blijft bewaard

---

## Toepassing

Implementeer in je game:

1. **Minimaal:**
   - Menu state met start button
   - Playing state
   - Game Over state

2. **Aanbevolen:**
   - Pause functionaliteit (ESC)
   - Score die bewaard blijft
   - High score systeem

3. **Uitbreidingen:**
   - Victory state bij level completion
   - Level progression
