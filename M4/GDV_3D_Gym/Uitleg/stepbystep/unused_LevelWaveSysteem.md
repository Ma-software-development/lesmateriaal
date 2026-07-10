# Step By Step — Level- en Wave-systeem: Gestructureerde Moeilijkheidsopbouw

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt het verschil tussen een level-systeem en een wave-systeem
- Je kunt een `WaveManager` bouwen die golven van vijanden definieert en afvuurt
- Je kunt automatisch naar de volgende wave gaan als alle vijanden verslagen zijn
- Je kunt wave-data opslaan in een overzichtelijke datastructuur

---

## Concept: level vs. wave

| | Level-systeem | Wave-systeem |
|---|---|---|
| **Structuur** | Aparte scenes of zones | Golven binnen één scene |
| **Overgang** | Scene laden | Wachten tot alle vijanden weg zijn |
| **Gebruik** | Platformer, adventure | Shooter, tower defense, endless |

```
WaveManager
│
├── Wave 1: 3× BasicEnemy
├── Wave 2: 5× BasicEnemy + 1× FastEnemy
└── Wave 3: 8× BasicEnemy + 2× FastEnemy
     └── Wacht tot alle vijanden dood zijn → volgende wave
```

---

## Stap 1 — Vijand-prefabs aanmaken

1. Maak twee **Capsule**-GameObjects in de Hierarchy.
   - Noem de eerste `BasicEnemy` — geef het een **oranje** materiaal.
   - Noem de tweede `FastEnemy` — geef het een **rood** materiaal.
2. Voeg aan beide een **Rigidbody** toe (Freeze Rotation X, Y, Z aan).
3. Sleep beide naar `Assets/Prefabs/` en verwijder de originelen.

---

## Stap 2 — Enemy script

1. Maak een script **`Enemy.cs`** en koppel het aan **beide prefabs**:

```csharp
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    private WaveManager waveManager;

    void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (waveManager != null)
        {
            waveManager.OnEnemyDefeated();
        }

        Destroy(gameObject);
    }

    // Tijdelijk: klik op een vijand om schade te testen
    void OnMouseDown()
    {
        TakeDamage(1);
    }
}
```

---

## Stap 3 — Wave-data definiëren

1. Maak **`WaveManager.cs`** — bovenaan definieren we de dataklasse voor één wave:

```csharp
using System.Collections;
using UnityEngine;

// [System.Serializable] maakt de klasse zichtbaar in de Inspector
[System.Serializable]
public class Wave
{
    public string waveName = "Wave";
    public GameObject[] enemyPrefabs;   // welke vijanden mogen spawnen
    public int enemyCount;              // hoeveel vijanden in totaal
    public float timeBetweenSpawns;     // seconden tussen elk spawn
}
```

---

## Stap 4 — WaveManager script

Voeg direct onder de `Wave`-klasse toe in **hetzelfde bestand**:

```csharp
public class WaveManager : MonoBehaviour
{
    [Header("Wave-instellingen")]
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 3f;

    public int currentWaveIndex = 0;
    public int enemiesAlive = 0;

    void Start()
    {
        StartCoroutine(RunWaves());
    }

    private IEnumerator RunWaves()
    {
        foreach (Wave wave in waves)
        {
            Debug.Log($"=== {wave.waveName} begint! ===");

            yield return StartCoroutine(SpawnWave(wave));

            // Wacht tot alle vijanden verslagen zijn
            yield return new WaitUntil(() => enemiesAlive == 0);

            Debug.Log($"{wave.waveName} voltooid!");

            yield return new WaitForSeconds(timeBetweenWaves);

            currentWaveIndex++;
        }

        Debug.Log("Alle waves voltooid — speler wint!");
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.enemyCount; i++)
        {
            int prefabIndex = Random.Range(0, wave.enemyPrefabs.Length);
            int pointIndex  = Random.Range(0, spawnPoints.Length);

            Instantiate(
                wave.enemyPrefabs[prefabIndex],
                spawnPoints[pointIndex].position,
                spawnPoints[pointIndex].rotation
            );

            enemiesAlive++;

            yield return new WaitForSeconds(wave.timeBetweenSpawns);
        }
    }

    public void OnEnemyDefeated()
    {
        enemiesAlive--;
    }
}
```

---

## Stap 5 — Scene inrichten

1. Maak een leeg GameObject → noem het `WaveManager` → koppel `WaveManager.cs`.
2. Maak twee lege GameObjects als spawn-punten:
   - `SpawnPoint_Left` op `(-5, 0, 5)`
   - `SpawnPoint_Right` op `(5, 0, 5)`
3. Sleep ze naar **Spawn Points** in de Inspector.
4. Stel **Waves > Size** op `3` en vul in:

| | Wave Name | Enemy Prefabs | Enemy Count | Time Between Spawns |
|---|---|---|---|---|
| 0 | Wave 1 | BasicEnemy | 3 | 1.5 |
| 1 | Wave 2 | BasicEnemy, FastEnemy | 5 | 1.0 |
| 2 | Wave 3 | BasicEnemy, FastEnemy | 8 | 0.7 |

---

## Stap 6 — UI toevoegen

1. Maak een **Canvas** met twee **TextMeshPro**-teksten: `WaveText` en `EnemyText`.
2. Maak **`WaveUI.cs`** en koppel het aan het Canvas:

```csharp
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    public TMP_Text waveText;
    public TMP_Text enemyText;

    private WaveManager waveManager;

    void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();
    }

    void Update()
    {
        if (waveManager == null) return;

        waveText.text  = $"Wave: {waveManager.currentWaveIndex + 1}";
        enemyText.text = $"Vijanden: {waveManager.enemiesAlive}";
    }
}
```

---

## Stap 7 — Testen

1. Klik op **Play** en controleer in de Console dat Wave 1 start.
2. Klik op vijanden om ze te verslaan.
3. Controleer dat Wave 2 begint zodra alle vijanden van Wave 1 weg zijn.
4. Controleer dat de UI het juiste wave-nummer en vijandencount toont.

---

## Overzicht van de scripts

| Script        | Verantwoordelijkheid                                          |
|---------------|---------------------------------------------------------------|
| `Wave`        | Dataklasse: beschrijft de inhoud van één wave                |
| `WaveManager` | Spawnt waves op volgorde, telt vijanden, wacht op voltooiing |
| `Enemy`       | Houdt health bij, meldt eigen dood aan WaveManager           |
| `WaveUI`      | Toont wave-nummer en resterend aantal vijanden               |

---

## Uitbreidingsideeën

- **Koppelen aan Les 18:** gebruik de `Spawner` als onderliggende spawn-engine, aangestuurd door de `WaveManager`.
- **Boss wave:** een speciale wave met één vijand met veel health.
- **Wave-bonus:** geef bonuspunten voor het snel afmaken van een wave.
- **Procedurele waves:** genereer waves op basis van een moeilijkheidsschaal i.p.v. vaste lijsten.
