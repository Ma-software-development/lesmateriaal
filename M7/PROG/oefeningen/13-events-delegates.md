# Oefening: Events & Delegates

## Leerdoel

Events en delegates gebruiken om scripts los te koppelen.

---

## Oefening 1: Game Event

Maak een event-systeem voor "speler is dood":

```csharp
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDied;

    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            // TODO: Invoke OnPlayerDied event
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            TakeDamage(40);
    }
}
```

Luister in een ander script:

```csharp
public class UIManager : MonoBehaviour
{
    void OnEnable()
    {
        // TODO: Abonneer op PlayerHealth.OnPlayerDied
    }

    void OnDisable()
    {
        // TODO: Afmelden van het event
    }

    void HandlePlayerDied()
    {
        Debug.Log("UI: Game Over scherm tonen!");
    }
}
```

**Test:** Druk 3x op D — bij de derde keer verschijnt "UI: Game Over scherm tonen!".

---

## Oefening 2: Event met Data

Maak een event dat score-informatie meestuurt:

```csharp
using System;

public class ScoreSystem : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;

    private int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        // TODO: Invoke OnScoreChanged met de nieuwe score
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            AddPoints(10);
    }
}
```

Luisteraar:

```csharp
public class ScoreDisplay : MonoBehaviour
{
    void OnEnable()
    {
        ScoreSystem.OnScoreChanged += UpdateDisplay;
    }

    void OnDisable()
    {
        ScoreSystem.OnScoreChanged -= UpdateDisplay;
    }

    void UpdateDisplay(int newScore)
    {
        Debug.Log("Score display: " + newScore);
    }
}
```

**Test:** Elke keer P toont de nieuwe score in de console.
