# Step By Step — Spawn-systeem: Objecten Laten Verschijnen

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt wat een spawn-systeem is en waarom je prefabs gebruikt
- Je kunt objecten op vaste of willekeurige posities laten spawnen
- Je kunt spawnen op tijd sturen met een interval
- Je kunt een maximumaantal actieve objecten instellen om performance te bewaken

---

## Concept: wat is spawnen?

Spawnen is het aanmaken van een object terwijl het spel loopt — denk aan vijanden die verschijnen, munten die vallen of obstakels die opduiken.

```
Spawner (leeg GameObject)
│
├── Elke X seconden:
│     └── Instantiate(prefab, positie, rotatie)
│
└── Optioneel: maximaal N objecten tegelijk actief
```

De kernfunctie in Unity is `Instantiate()`. Die maakt een kopie van een **prefab** aan op een opgegeven positie.

---

## Stap 1 — Prefab aanmaken

Een prefab is een sjabloon voor een GameObject. Je maakt het één keer aan, en de spawner maakt er kopieën van.

1. Maak een **Cube** aan in de Hierarchy: **rechtermuisknop > 3D Object > Cube**.
2. Geef het een kleur via een nieuw materiaal (bijv. rood).
3. Voeg eventueel een **Rigidbody** toe zodat het valt.
4. Sleep het GameObject vanuit de **Hierarchy naar de Project-view** (map `Assets/Prefabs/`).
   - Unity maakt nu een `.prefab`-bestand aan.
5. Verwijder het originele GameObject uit de Hierarchy.

---

## Stap 2 — Spawn-punten instellen

Spawn-punten zijn lege GameObjects die de locatie markeren waar objecten verschijnen.

1. Maak een leeg GameObject aan: **rechtermuisknop > Create Empty** → noem het `SpawnManager`.
2. Maak daarbinnen drie lege GameObjects:
   - `SpawnPoint_A` op positie `(-4, 5, 0)`
   - `SpawnPoint_B` op positie `(0, 5, 0)`
   - `SpawnPoint_C` op positie `(4, 5, 0)`

> **Tip:** Klik op het kubus-icoontje naast de naam in de Inspector om een Gizmo-kleur te kiezen zodat je de spawn-punten zichtbaar maakt in de editor.

---

## Stap 3 — Spawner script

1. Maak een nieuw script **`Spawner.cs`** en koppel het aan het `SpawnManager`-object:

```csharp
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Wat spawnen")]
    public GameObject prefab;

    [Header("Waar spawnen")]
    public Transform[] spawnPoints;

    [Header("Wanneer spawnen")]
    public float spawnInterval = 2f;
    public int maxObjects = 10;

    private float timer = 0f;
    private int currentCount = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval && currentCount < maxObjects)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        if (spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenPoint = spawnPoints[randomIndex];

        Instantiate(prefab, chosenPoint.position, chosenPoint.rotation);
        currentCount++;
    }

    // Roep dit aan vanuit het gespawnde object als het vernietigd wordt
    public void NotifyDestroyed()
    {
        currentCount--;
    }
}
```

2. Sleep in de Inspector:
   - **Prefab** → jouw cube-prefab
   - **Spawn Points** → `SpawnPoint_A`, `SpawnPoint_B`, `SpawnPoint_C`

---

## Stap 4 — Gespawnd object zichzelf laten verwijderen

1. Maak een script **`SpawnedObject.cs`** en koppel het aan de **prefab**:

```csharp
using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    public float lifetime = 5f;

    private Spawner spawner;

    void Start()
    {
        spawner = FindFirstObjectByType<Spawner>();
        Destroy(gameObject, lifetime);
    }

    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.NotifyDestroyed();
        }
    }
}
```

2. Stel in de Inspector van de prefab de gewenste `lifetime` in (bijv. `5` seconden).

---

## Stap 5 — Testen

1. Klik op **Play**.
2. Controleer in de **Hierarchy** dat er elke `spawnInterval` seconden een object verschijnt.
3. Controleer dat objecten na `lifetime` seconden verdwijnen.
4. Controleer dat er nooit meer dan `maxObjects` actieve objecten zijn.

> **Veelgemaakte fout:** koppel altijd de prefab vanuit de **Project-view**, niet vanuit de Hierarchy. Anders spawnt Unity het originele object.

---

## Overzicht van de scripts

| Script          | Verantwoordelijkheid                                         |
|-----------------|--------------------------------------------------------------|
| `Spawner`       | Beheert timing, locatiekeuze en het maximum aantal objecten |
| `SpawnedObject` | Vernietigt zichzelf na een tijd en meldt dit aan de Spawner |

---

## Uitbreidingsideeën

- **Meerdere prefabs:** gebruik `public GameObject[] prefabs` en kies willekeurig welk type spawnt.
- **Moeilijkheidsgraad:** verlaag `spawnInterval` naarmate de tijd vordert.
- **Spawn-animatie:** laat het object groeien van schaal 0 naar 1 met `Lerp`.
