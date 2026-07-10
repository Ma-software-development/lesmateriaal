# Step By Step — NavMesh & NPC Navigatie
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een NavMesh bakken voor een scene
- Je kunt een NPC laten navigeren met `NavMeshAgent`
- Je kunt een simpele patrol- en follow-AI bouwen

---

## Achtergrond: Hoe werkt NavMesh?

Een **NavMesh** (Navigation Mesh) is een onzichtbare laag die over je scene wordt gelegd. Hij berekent welke gebieden begaanbaar zijn en vindt de kortste route tussen twee punten.

- **NavMeshSurface**: genereert de mesh
- **NavMeshAgent**: component op de NPC die de mesh gebruikt om te navigeren
- **NavMeshObstacle**: dynamisch obstakel (bijv. een barrel die je wegschopt)

---

## Stap 1 — AI Navigation package controleren

1. Ga naar **Window > Package Manager**.
2. Zorg dat **AI Navigation** geïnstalleerd is (staat al in het 3d_Gym project).  
   Zo niet: zoek op `AI Navigation` → Install.

---

## Stap 2 — NavMeshSurface toevoegen

1. Maak een leeg GameObject: **GameObject > Create Empty**. Noem het `NavMeshManager`.
2. Selecteer het. **Add Component > AI > NavMesh Surface**.
3. In de Inspector van `NavMeshSurface`:
   - **Agent Type:** Humanoid (of de default)
   - **Collect Objects:** All Game Objects
   - **Include Layers:** selecteer alle lagen die de vloer/muren bevatten

---

## Stap 3 — Statische objecten markeren

NavMesh bakt alleen **statische** geometrie.

1. Selecteer alle vloeren en muren in de Hierarchy.
2. Klik rechtsboven in de Inspector op **Static** → kies **Navigation Static** (of vink alles aan).

---

## Stap 4 — NavMesh bakken

1. Selecteer `NavMeshManager` met de `NavMeshSurface`.
2. Klik in de Inspector op **Bake**.
3. Wacht tot Unity klaar is. Je ziet een blauw vlak over de begaanbare gebieden in de Scene view.

> **Tip:** Gebruik het **Navigation**-venster (**Window > AI > Navigation (Obsolete)**) of de `NavMeshSurface` voor meer controle over de bake-instellingen.

---

## Stap 5 — NPC aanmaken

1. Gebruik een simpele Capsule als NPC: **GameObject > 3D Object > Capsule**. Noem het `NPC`.
2. Of gebruik het Worker-model uit de Assets.
3. Stel de positie in op de begaanbare NavMesh-zone (blauwe vlek).

---

## Stap 6 — NavMeshAgent toevoegen aan NPC

1. Selecteer `NPC`.
2. **Add Component > AI > NavMesh Agent**.
3. Stel in:
   - **Speed:** 3.5
   - **Angular Speed:** 120
   - **Acceleration:** 8
   - **Stopping Distance:** 0.5
   - **Radius:** 0.4 (moet kleiner zijn dan de vrije ruimte in doorgangen)
   - **Height:** 2.0

---

## Stap 7 — Eenvoudig navigatie-script: NPC naar vaste positie

1. Maak `NPCNavigate.cs`:

```csharp
using UnityEngine;
using UnityEngine.AI;

public class NPCNavigate : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }
}
```

2. Maak een leeg GameObject in de scene als doelpunt. Noem het `Destination`.
3. Sleep `Destination` naar het **Destination**-veld in de Inspector.
4. Druk **Play**: de NPC loopt naar het doelpunt.

---

## Stap 8 — Patrol-systeem bouwen

```csharp
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 1f;

    private NavMeshAgent agent;
    private int currentWaypoint = 0;
    private float waitTimer = 0f;
    private bool waiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextWaypoint();
    }

    void Update()
    {
        if (waiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                waiting = false;
                GoToNextWaypoint();
            }
            return;
        }

        // Controle: heeft de NPC het waypoint bereikt?
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waiting = true;
            waitTimer = waitTime;
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypoint].position);
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }
}
```

### Waypoints aanmaken
1. Maak 3–4 lege GameObjects in de scene: `WP_01`, `WP_02`, `WP_03`, `WP_04`.
2. Positioneer ze op verschillende plekken binnen de gym.
3. Selecteer de NPC. Sleep alle waypoints naar het **Waypoints**-array in de Inspector.

---

## Stap 9 — State machine bouwen: Patrol, Chase, Return

Dit is het volledige NPC-AI script voor de huiswerkopdracht als referentie:

```csharp
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class NPCGuard : MonoBehaviour
{
    public enum State { Patrol, Chase, Return }

    [Header("Referenties")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private TextMeshPro stateLabel; // World-space text boven NPC

    [Header("Instellingen")]
    [SerializeField] private float detectionRange = 8f;
    [SerializeField] private float losRange = 15f;
    [SerializeField] private float losePlayerTime = 3f;

    private NavMeshAgent agent;
    private State currentState = State.Patrol;
    private int waypointIndex = 0;
    private float loseTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToWaypoint();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol: UpdatePatrol(); break;
            case State.Chase:  UpdateChase();  break;
            case State.Return: UpdateReturn(); break;
        }

        if (stateLabel != null)
            stateLabel.text = currentState.ToString();
    }

    void UpdatePatrol()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
            GoToWaypoint();
        }

        if (CanSeePlayer())
            SetState(State.Chase);
    }

    void UpdateChase()
    {
        agent.SetDestination(player.position);

        if (CanSeePlayer())
            loseTimer = losePlayerTime;
        else
        {
            loseTimer -= Time.deltaTime;
            if (loseTimer <= 0f)
                SetState(State.Return);
        }
    }

    void UpdateReturn()
    {
        GoToWaypoint();

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            SetState(State.Patrol);

        if (CanSeePlayer())
            SetState(State.Chase);
    }

    bool CanSeePlayer()
    {
        float dist = Vector3.Distance(transform.position, player.position);
        if (dist > losRange) return false;

        Vector3 direction = (player.position - transform.position).normalized;
        if (Physics.Raycast(transform.position + Vector3.up, direction, out RaycastHit hit, losRange))
        {
            if (hit.collider.CompareTag("Player"))
                return dist <= detectionRange;
        }
        return false;
    }

    void GoToWaypoint()
    {
        if (waypoints.Length > 0)
            agent.SetDestination(waypoints[waypointIndex].position);
    }

    void SetState(State newState)
    {
        currentState = newState;
    }
}
```

---

## Stap 10 — NavMeshObstacle toevoegen aan dynamische objecten

Als een barrel door de speler weggeduwd wordt, moet de NavMesh dit weten.

1. Selecteer een barrel-prefab.
2. **Add Component > AI > NavMesh Obstacle**.
3. Stel in:
   - **Shape:** Box (of Capsule)
   - **Carve:** ✅ (snijdt gat in NavMesh als het obstakel beweegt)
   - **Carve Only Stationary:** ❌ (altijd carven, ook in beweging)

---

## Stap 11 — State-label boven de NPC (World Space UI)

1. Rechtermuisknop op NPC → **UI > Text - TextMeshPro**.
2. In de Canvas die verschijnt: stel **Render Mode** in op **World Space**.
3. Positioneer het boven het hoofd van de NPC: Y = 2.5.
4. Stel Font Size in op 0.3 (World Space werkt met andere schaal).
5. Sleep het naar het **State Label**-veld in `NPCGuard`.

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| NPC staat stil | Buiten NavMesh of niet gebakken | Rebake de NavMesh; controleer positie |
| NPC loopt door muren | Muren niet als Navigation Static gemarkeerd | Markeer muren → rebake |
| NPC verdwijnt in de vloer | Agent Height verkeerd | Pas Height aan in NavMeshAgent |
| Waypoints worden overgeslagen | `stoppingDistance` te groot | Verklein `stoppingDistance` |
| Chase werkt niet | Raycast raakt de NPC zelf | Zet de NPC op een aparte Layer |

---

## Controlelijst voor afronding

- [ ] AI Navigation package aanwezig
- [ ] NavMeshSurface gebakken (blauwe overlay zichtbaar in Scene view)
- [ ] Vloer en muren zijn Navigation Static
- [ ] NavMeshAgent component op NPC aanwezig en correct ingesteld
- [ ] NPC navigeert naar een vaste positie
- [ ] Patrol-systeem werkt met 3+ waypoints in een lus
- [ ] NPC wacht bij elk waypoint
- [ ] Line-of-sight Raycast werkt
- [ ] State machine: Patrol → Chase → Return correct
- [ ] State-label zichtbaar boven de NPC
- [ ] NavMeshObstacle op dynamische objecten (barrel)
