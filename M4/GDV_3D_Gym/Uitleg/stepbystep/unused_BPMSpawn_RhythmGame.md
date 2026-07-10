# Step By Step — BPM-gebaseerde Spawn: Rhythm Game

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt hoe BPM (beats per minute) wordt omgezet naar een tijdinterval
- Je kunt objecten synchroon met muziek laten spawnen
- Je kunt een hit-window bouwen: de speler wordt beoordeeld op timingnauwkeurigheid
- Je kunt een combo-teller bijhouden die bij een miss gereset wordt

---

## Concept: BPM naar tijd

BPM staat voor **beats per minute**. Om te weten hoeveel seconden er tussen twee beats zit:

```
seconden per beat = 60 / BPM

Voorbeeld: 120 BPM → 60 / 120 = 0.5 seconden per beat
```

In een rhythm game spawnen noten op de beat. De speler drukt op het juiste moment een knop in. Hoe dichter bij de beat, hoe hoger de beoordeling.

```
Beat:    |    |    |    |    |
Noot:    ↓    ↓    ↓    ↓    ↓    (gespawnd op elke beat)
Speler:       ↑         ↑         (drukt in — timing wordt beoordeeld)
```

---

## Stap 1 — Scene inrichten

1. Maak een nieuw **2D**-project of gebruik een bestaand project.
2. Maak een leeg GameObject → noem het `RhythmManager`.
3. Maak een `Quad` of `Sprite`-GameObject als **noot-prefab**:
   - Geef het een opvallende kleur (bijv. geel).
   - Sleep het naar `Assets/Prefabs/` en verwijder het origineel.
4. Voeg een **AudioSource**-component toe aan `RhythmManager` met een muziekclip als **AudioClip**.

---

## Stap 2 — RhythmManager script

1. Maak **`RhythmManager.cs`** en koppel het aan `RhythmManager`:

```csharp
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    [Header("Muziek")]
    public AudioSource audioSource;
    public float bpm = 120f;

    [Header("Noot-instellingen")]
    public GameObject notePrefab;
    public Transform spawnPoint;     // Waar noten verschijnen
    public Transform targetPoint;    // Waar de speler ze moet raken

    [Header("Hit-window (seconden)")]
    public float perfectWindow = 0.05f;
    public float goodWindow    = 0.12f;

    // Berekend interval op basis van BPM
    private float secondsPerBeat;
    private float nextBeatTime;

    // Score
    public int combo = 0;
    public int score = 0;

    void Start()
    {
        secondsPerBeat = 60f / bpm;
        nextBeatTime   = (float)audioSource.clip.length * 0f; // begin direct
        audioSource.Play();
    }

    void Update()
    {
        // Is het tijd voor een nieuwe beat?
        if (audioSource.time >= nextBeatTime)
        {
            SpawnNote();
            nextBeatTime += secondsPerBeat;
        }
    }

    private void SpawnNote()
    {
        if (notePrefab == null || spawnPoint == null) return;

        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);

        // Geef de noot zijn doellocatie en het verwachte raaktijdstip
        NoteObject noteObj = note.GetComponent<NoteObject>();
        if (noteObj != null)
        {
            noteObj.targetPosition = targetPoint.position;
            noteObj.expectedHitTime = nextBeatTime;
        }
    }

    // Aangeroepen door NoteObject als de speler drukt
    public void RegisterHit(float timingError)
    {
        if (timingError <= perfectWindow)
        {
            Debug.Log("PERFECT!");
            score += 300;
            combo++;
        }
        else if (timingError <= goodWindow)
        {
            Debug.Log("GOOD");
            score += 100;
            combo++;
        }
        else
        {
            Debug.Log("MISS");
            combo = 0;
        }

        Debug.Log($"Score: {score}  Combo: {combo}x");
    }
}
```

---

## Stap 3 — NoteObject script

Elke noot beweegt naar de doelzone. Als de speler op tijd drukt, wordt de hit geregistreerd.

1. Maak **`NoteObject.cs`** en koppel het aan de **noot-prefab**:

```csharp
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public Vector3 targetPosition;
    public float expectedHitTime;
    public float moveSpeed = 5f;
    public float destroyAfter = 2f;     // verdwijnt als de speler te laat is

    private RhythmManager rhythmManager;
    private bool wasHit = false;

    void Start()
    {
        rhythmManager = FindFirstObjectByType<RhythmManager>();
        Destroy(gameObject, destroyAfter);
    }

    void Update()
    {
        // Beweeg naar de doelzone
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        // Speler drukt op de actieknop
        if (Input.GetKeyDown(KeyCode.Space) && !wasHit)
        {
            // Bereken hoe ver de noot nog van het doelpunt is als tijdsfout
            float audioTime   = FindFirstObjectByType<AudioSource>() != null
                                ? FindFirstObjectByType<AudioSource>().time
                                : 0f;
            float timingError = Mathf.Abs(audioTime - expectedHitTime);

            wasHit = true;
            rhythmManager.RegisterHit(timingError);
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Als de noot verdwijnt zonder geraakt te zijn: miss
        if (!wasHit && rhythmManager != null)
        {
            rhythmManager.RegisterHit(999f);   // grote fout = miss
        }
    }
}
```

---

## Stap 4 — Scene afmaken

1. Maak twee lege GameObjects:
   - `SpawnPoint` — rechts buiten beeld, bijv. `(10, 0, 0)`
   - `TargetPoint` — op de positie waar de speler staat, bijv. `(-4, 0, 0)`
2. Sleep ze naar de velden **Spawn Point** en **Target Point** in de Inspector van `RhythmManager`.
3. Sleep een muziekclip naar het **AudioClip**-veld van de AudioSource.
4. Stel **BPM** in op het tempo van jouw muziek (gebruik een BPM-tapper als je het niet weet).

> **BPM meten:** zoek online op "BPM tap tempo" en tik mee op de beat om de BPM te bepalen.

---

## Stap 5 — Testen

1. Klik op **Play**.
2. Controleer dat noten van rechts naar links schuiven in het ritme van de muziek.
3. Druk **Space** als een noot de doelzone bereikt.
4. Controleer de Console: zie je `PERFECT`, `GOOD` of `MISS`?
5. Controleer dat de combo reset bij een miss.

---

## Overzicht van de scripts

| Script           | Verantwoordelijkheid                                          |
|------------------|---------------------------------------------------------------|
| `RhythmManager`  | Houdt BPM bij, spawnt noten, beoordeelt hits                 |
| `NoteObject`     | Beweegt naar doelzone, detecteert spelerinput                |

---

## Uitbreidingsideeën

- **Meerdere banen:** maak 3–4 rijstroken met aparte toetsen (bijv. D, F, J, K) voor een Guitar Hero-stijl layout.
- **Visuele feedback:** toon `PERFECT!` of `MISS` als opduikende tekst op het scherm met een `TMP_Text`.
- **Nootpatroon uit data:** sla de noot-tijdstippen op in een lijst of JSON-bestand zodat je handgemaakte nummers kunt ontwerpen.
