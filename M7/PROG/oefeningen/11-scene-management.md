# Oefening: Scene Management

## Leerdoel

Scenes laden, wisselen en data meenemen tussen scenes.

---

## Oefening 1: Scene Wisselen

Maak een menu dat naar een game scene schakelt:

```csharp
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadGame()
    {
        // TODO: Laad de scene "Game"
        // SceneManager.LoadScene("Game");
    }

    public void LoadMenu()
    {
        // TODO: Laad de scene "Menu"
    }

    public void QuitGame()
    {
        Debug.Log("Game afgesloten");
        Application.Quit();
    }
}
```

**Setup:**

1. Maak 2 scenes: "Menu" en "Game"
2. Voeg beide toe aan Build Settings (File → Build Settings → Add)
3. In Menu: button die `LoadGame()` aanroept
4. In Game: button die `LoadMenu()` aanroept

**Test:** Je kunt heen en weer wisselen.

---

## Oefening 2: Data Tussen Scenes

Gebruik een DontDestroyOnLoad object om een score mee te nemen:

```csharp
public class GameData : MonoBehaviour
{
    public static GameData Instance;
    public int score = 0;

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

    public void AddScore(int points)
    {
        score += points;
    }
}
```

**Test:**

- Verzamel punten in de Game scene
- Ga terug naar Menu
- Ga weer naar Game — score is bewaard
