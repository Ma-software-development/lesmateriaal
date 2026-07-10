# Oefening 21 — Design Patterns

**Onderwerp:** Factory Method, Singleton en Observer pattern  
**Module:** M5

---

## Oefening 21a — Factory Method

Gebruik het Factory-patroon om verschillende vijanden aan te maken zonder overal `if`/`switch`-logica.

```csharp
using UnityEngine;

public enum EnemyType { Slime, Bat, Skeleton }

public static class EnemyFactory
{
    public static GameObject Create(EnemyType type, Vector3 position)
    {
        GameObject enemy = null;

        switch (type)
        {
            case EnemyType.Slime:
                enemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                enemy.transform.localScale = Vector3.one * 0.5f;
                break;
            case EnemyType.Bat:
                enemy = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                enemy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                break;
            case EnemyType.Skeleton:
                enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
        }

        if (enemy != null)
        {
            enemy.name = type.ToString();
            enemy.transform.position = position;
        }

        return enemy;
    }
}
```

**Opdracht:**

1. Maak het `EnemyFactory`-script aan.
2. Maak een `WaveSpawner` die bij Start een golf van 5 willekeurige vijanden spawnt:
   ```csharp
   void Start()
   {
       for (int i = 0; i < 5; i++)
       {
           EnemyType randomType = (EnemyType)Random.Range(0, 3);
           Vector3 pos = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
           EnemyFactory.Create(randomType, pos);
       }
   }
   ```
3. Test en controleer dat er diverse vijanden verschijnen.
4. **Bonus:** Voeg een nieuw enemy-type toe aan de `enum` en de factory.

---

## Oefening 21b — Singleton & Observer

Maak een `GameManager` Singleton die events gebruikt (Observer pattern) om andere scripts op de hoogte te houden.

```csharp
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action OnGameOver;
    public event Action<int> OnScoreChanged;

    private int score;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        OnScoreChanged?.Invoke(score);
    }

    public void TriggerGameOver()
    {
        Debug.Log("GAME OVER");
        OnGameOver?.Invoke();
    }
}
```

**Opdracht:**

1. Maak de `GameManager` aan en voeg het toe aan een leeg GameObject.
2. Maak een `ScoreUI`-script dat luistert naar `OnScoreChanged`:
   ```csharp
   void OnEnable()
   {
       GameManager.Instance.OnScoreChanged += UpdateScore;
   }
   void OnDisable()
   {
       GameManager.Instance.OnScoreChanged -= UpdateScore;
   }
   void UpdateScore(int newScore)
   {
       Debug.Log("Score: " + newScore);
   }
   ```
3. Maak een script dat bij een klik `GameManager.Instance.AddScore(10)` aanroept.
4. Test of de ScoreUI reageert op score-veranderingen.
5. **Bonus:** Voeg een `GameOverScreen`-script toe dat luistert naar `OnGameOver`.
