# Les 4.1 — Waypoint / Navigation System

## Leerdoel

Na deze les kun je tegenstanders laten bewegen via waypoints.

---

## Theorie

### Wat zijn Waypoints?

Waypoints zijn punten in je level waar een AI naartoe beweegt:

```
[A] ───→ [B] ───→ [C]
          ↓
         [D] ←─── [E]
```

De tegenstander beweegt van punt naar punt.

### Waypoint Setup

1. Maak lege GameObjects als waypoints
2. Plaats ze in een logische volgorde
3. Laat de AI naar elk waypoint bewegen

### Waypoint Script

```csharp
public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Huidige waypoint
        Transform target = waypoints[currentWaypointIndex];

        // Beweeg naar target
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Check of we er zijn
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            // Volgende waypoint
            currentWaypointIndex++;

            // Loop terug naar begin
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }
}
```

### Patrol vs Chase

| Type       | Gedrag                          |
| ---------- | ------------------------------- |
| **Patrol** | Volgt vaste route via waypoints |
| **Chase**  | Beweegt naar speler positie     |
| **Flee**   | Beweegt weg van speler          |

### Chase Voorbeeld

```csharp
public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
```

---

## Oefeningen

### Oefening 1: Simpele Patrol

Maak een tegenstander die een vierkant patrol loopt:

1. **Maak 4 waypoints:**
   - Create Empty → noem "Waypoint_A"
   - Plaats op positie (0, 0, 0)
   - Herhaal voor B (5, 0, 0), C (5, -5, 0), D (0, -5, 0)

2. **Maak Enemy:**
   - Maak een Enemy GameObject met sprite
   - Voeg `WaypointFollower` script toe
   - Sleep de 4 waypoints naar de array

3. **Test:**
   - Enemy loopt het vierkant rond
   - Na D gaat hij terug naar A

**Uitbreiding:** Maak de speed instelbaar en test verschillende snelheden.

---

### Oefening 2: Twee Gedragingen

Maak twee enemies met verschillend gedrag:

**Enemy 1: Patroller**

- Volgt een vaste route van 4+ waypoints
- Snelheid: 2

**Enemy 2: Chaser**

- Volgt de speler zodra deze dichtbij is
- Snelheid: 1.5 (iets langzamer dan speler)

Script voor Enemy 2:

```csharp
public class SimpleChaser : MonoBehaviour
{
    public Transform player;
    public float speed = 1.5f;
    public float chaseRange = 5f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseRange)
        {
            // TODO: Beweeg naar speler
        }
    }
}
```

**Test:**

- Patroller negeert je en loopt zijn route
- Chaser volgt je alleen als je dichtbij komt

---

## Toepassing

Implementeer tegenstanders in je game:

1. Bedenk: welke gedragingen passen bij jouw thema?
2. Maak minimaal 2 verschillende enemy types
3. Plaats waypoints in je level

**PAC-MAN referentie:**

- Blinky (rood): Chase - volgt direct
- Pinky (roze): Ambush - gaat naar positie vóór speler
- Inky (blauw): Unpredictable - combinatie
- Clyde (oranje): Random - wisselt tussen chase en scatter
