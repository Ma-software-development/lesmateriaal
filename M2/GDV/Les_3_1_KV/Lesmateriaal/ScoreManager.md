# Les 3.1 Week 3 – Score Manager

## Wat is een Singleton Pattern?

De ScoreManager gebruikt een zogenoemd singleton pattern. Dat betekent dat er van de ScoreManager maar één exemplaar bestaat in je hele spel. Alle scripts die punten willen toevoegen, verwijzen naar hetzelfde centrale punt.

Je maakt dus niet meerdere ScoreManagers, maar één vaste plek waar de totale score wordt bijgehouden. Hierdoor blijft het systeem overzichtelijk en voorkom je fouten, omdat alle peggles altijd naar dezelfde ScoreManager verwijzen.

Een singleton is handig voor dingen die maar één keer hoeven te bestaan, zoals een score, game manager, audio manager of level manager. Het zorgt ervoor dat andere scripts de ScoreManager makkelijk kunnen bereiken via bijvoorbeeld ScoreManager.Instance.

Bijvoorbeeld:
ScoreManager.Instance.AddScore(10);

Daarmee weet Unity altijd: “Gebruik dé ScoreManager van dit spel.”

---

## Stappenplan

Stap 1

- Voeg een leeg object toe aan je scene en noem deze GameManager.
- Voeg een nieuw script toe aan dit gameobject benaamd ScoreManager.

Stap 2

Voeg deze code toe aan het script:

```Csharp

using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager Instance;

    // Totale score
    public int score = 0;


    private void Awake()
    {
        // controleren of er al een ScoreManager bestaat
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // dit is nu de enige ScoreManager in de scene
        Instance = this;
    }

    // functie om punten toe te voegen
    public void AddScore(int amount)
    {
        score = score + amount;
        // debug voor testen
        Debug.Log("Score: " + score);
    }
}
```

---

Vanuit elk ander script kun je punten toevoegen via:

```Csharp
ScoreManager.Instance.AddScore(2);
```
