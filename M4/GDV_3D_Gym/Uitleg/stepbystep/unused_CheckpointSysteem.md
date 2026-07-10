# Step By Step — Checkpoint-systeem: Voortgang Opslaan

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt wat een checkpoint-systeem doet en wanneer je het gebruikt
- Je kunt checkpoints aanmaken als triggers in de scene
- Je kunt de laatste checkpoint-positie opslaan en de speler daar laten respawnen
- Je kunt checkpoints valideren zodat ze alleen in de juiste volgorde geactiveerd kunnen worden (anti-skip)

---

## Concept: hoe werkt een checkpoint?

Een checkpoint is een onzichtbare zone. Zodra de speler erdoorheen loopt, wordt zijn **respawn-positie** bijgewerkt. Bij dood of reset teleporteert de speler terug naar dat punt.

```
[START] ──► [Checkpoint 1] ──► [Checkpoint 2] ──► [FINISH]
                 ↑                    ↑
           respawn positie    overschrijft vorige
```

Bij een **racegame** geldt bovendien: checkpoints moeten in de juiste volgorde worden aangedaan — anders kan een speler de baan afsnijden.

---

## Stap 1 — Checkpoint-prefab aanmaken

1. Maak een leeg GameObject aan → noem het `Checkpoint`.
2. Voeg een **Box Collider** toe:
   - **Add Component > Box Collider**
   - Zet **Is Trigger** aan (vinkje).
   - Stel **Size** in op `(3, 4, 1)` — breed genoeg om de speler te raken.
3. Voeg optioneel een `Quad`-object toe als kind om de zone zichtbaar te maken in de editor (geef het een semi-transparant materiaal).
4. Sleep het GameObject naar `Assets/Prefabs/` en verwijder het origineel.

---

## Stap 2 — Checkpoint script

1. Maak **`Checkpoint.cs`** en koppel het aan de prefab:

```csharp
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Index bepaalt de vereiste volgorde (0 = eerste, 1 = tweede, etc.)
    public int checkpointIndex = 0;

    private bool isActivated = false;

    // Wordt aangeroepen door de CheckpointManager
    public void Activate()
    {
        if (isActivated) return;

        isActivated = true;

        // Visuele feedback: kleur de zone groen
        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.green;
        }

        Debug.Log($"Checkpoint {checkpointIndex} geactiveerd!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Vertel de manager dat de speler hier doorheen is
            FindFirstObjectByType<CheckpointManager>().ReachCheckpoint(this);
        }
    }
}
```

---

## Stap 3 — CheckpointManager script

De manager houdt bij welk checkpoint het laatste actieve is en beheert de respawn.

1. Maak een leeg GameObject → noem het `CheckpointManager`.
2. Maak **`CheckpointManager.cs`** en koppel het eraan:

```csharp
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [Header("Alle checkpoints in volgorde")]
    public Checkpoint[] checkpoints;

    // Index van het volgende checkpoint dat de speler moet raken
    private int nextExpectedIndex = 0;

    // Positie waar de speler naartoe gaat bij een respawn
    private Vector3 respawnPosition;

    void Start()
    {
        // Beginpositie is het eerste checkpoint (of een vaste startpositie)
        if (checkpoints.Length > 0)
        {
            respawnPosition = checkpoints[0].transform.position;
            checkpoints[0].Activate();
            nextExpectedIndex = 1;
        }
    }

    public void ReachCheckpoint(Checkpoint reached)
    {
        // Controleer of dit het verwachte checkpoint is
        if (reached.checkpointIndex != nextExpectedIndex) return;

        reached.Activate();
        respawnPosition = reached.transform.position;
        nextExpectedIndex++;

        // Alle checkpoints gehaald?
        if (nextExpectedIndex >= checkpoints.Length)
        {
            Debug.Log("Finish! Alle checkpoints gepasseerd.");
        }
    }

    // Roep dit aan vanuit een 'dood'-systeem of reset-knop
    public void RespawnPlayer(Transform player)
    {
        player.position = respawnPosition;
        Debug.Log($"Speler respawnt op {respawnPosition}");
    }
}
```

---

## Stap 4 — Checkpoints in de scene plaatsen

1. Sleep de **Checkpoint-prefab** drie keer de scene in.
2. Stel per instantie in de Inspector de `checkpointIndex` in: `0`, `1`, `2`.
3. Positioneer ze als een route door de scene.
4. Sleep alle drie naar het **Checkpoints**-veld van de `CheckpointManager` (in volgorde van index).
5. Zorg dat de speler de **tag `Player`** heeft (**Inspector > Tag > Player**).

---

## Stap 5 — Respawn koppelen aan de speler

1. Maak een script **`PlayerHealth.cs`** en koppel het aan de speler:

```csharp
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    void Start()
    {
        checkpointManager = FindFirstObjectByType<CheckpointManager>();
    }

    // Roep dit aan vanuit een val-detectie, vijandaanval, etc.
    public void Die()
    {
        Debug.Log("Speler is gestorven — respawn...");
        checkpointManager.RespawnPlayer(transform);
    }

    // Tijdelijk: druk R om te sterven en te testen
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
    }
}
```

---

## Stap 6 — Testen

1. Klik op **Play**.
2. Loop door Checkpoint 0 (startpositie), dan 1, dan 2.
3. Controleer in de Console dat elk checkpoint geactiveerd wordt.
4. Druk **R** om te sterven en controleer dat de speler terug springt naar het laatste checkpoint.
5. Probeer checkpoint 2 over te slaan door er direct naartoe te lopen — de manager mag dit negeren.

---

## Overzicht van de scripts

| Script               | Verantwoordelijkheid                                         |
|----------------------|--------------------------------------------------------------|
| `Checkpoint`         | Detecteert de speler via trigger, meldt aan de manager      |
| `CheckpointManager`  | Houdt volgorde bij, slaat respawn-positie op                |
| `PlayerHealth`       | Roept respawn aan bij dood                                  |

---

## Uitbreidingsideeën

- **Rondeteller (racegame):** tel het aantal keer dat de speler de volledige reeks checkpoints doorloopt.
- **Checkpoint-timer:** sla de tijd op bij elk checkpoint om sectortijden te tonen.
- **Visuele markering:** gebruik een deeltjeseffect of animatie bij activatie in plaats van een kleurwissel.
