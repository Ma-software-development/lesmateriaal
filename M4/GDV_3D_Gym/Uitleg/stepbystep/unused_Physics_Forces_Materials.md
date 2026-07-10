# Step By Step — Physics Verdieping: Rigidbody, Forces & Materials
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je begrijpt `AddForce`, `AddTorque` en de verschillende ForceMode-opties
- Je kunt een `PhysicsMaterial` instellen voor stuiteren en wrijving
- Je kunt Rigidbody constraints gebruiken voor gecontroleerde beweging

---

## Achtergrond: ForceMode opties

| ForceMode | Werking | Gebruik |
|---|---|---|
| `Force` | Kracht over tijd (rekening houdend met massa) | Raketmotor, continue duw |
| `Impulse` | Directe krachtstoot (rekening houdend met massa) | Sprong, explosie |
| `VelocityChange` | Directe snelheidsverandering (massa negeert) | Directe beweging, geen massa-effect |
| `Acceleration` | Continue versnelling (massa negeert) | Zwaartekracht-simulatie |

**Richtlijn:** Gebruik `Impulse` voor eenmalige krachten (springen, schieten). Gebruik `Force` voor continue krachten (voortstuwing).

---

## Stap 1 — Twee barrels vergelijken: licht vs. zwaar

1. Maak twee barrel-GameObjects:
   - `BarrelLight`: **Add Component > Rigidbody** → Mass = **1**
   - `BarrelHeavy`: **Add Component > Rigidbody** → Mass = **20**
2. Zorg dat beide barrels een **Box Collider** hebben.
3. Maak een script `PushOnCollision.cs`:

```csharp
using UnityEngine;

public class PushOnCollision : MonoBehaviour
{
    [SerializeField] private float pushForce = 500f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic) return;

        // Duwrichting: weg van de speler
        Vector3 pushDirection = hit.moveDirection;
        pushDirection.y = 0.1f; // klein upward component

        rb.AddForce(pushDirection * pushForce);
    }
}
```

4. Koppel dit script aan het **speler**-object (naast `MoveCharacterController`).
5. Test in Play mode: duw beide barrels. De lichte vliegt weg, de zware nauwelijks.

---

## Stap 2 — Drag en AngularDrag instellen

1. Selecteer `BarrelLight` in de Inspector.
2. In het Rigidbody-component:
   - **Drag:** 0.5 (luchtweerstand voor lineaire beweging)
   - **Angular Drag:** 0.5 (weerstand voor rotatie)
3. Selecteer `BarrelHeavy`:
   - **Drag:** 2.0
   - **Angular Drag:** 5.0 (draait nauwelijks)
4. Test: de zware barrel rolt minder na een duw.

---

## Stap 3 — PhysicsMaterial aanmaken: stuiterend object

1. In de Project view: **rechtermuisknop > Create > Physic Material**.
2. Noem het `Bouncy`.
3. Stel in:
   - **Dynamic Friction:** 0.1
   - **Static Friction:** 0.1
   - **Bounciness:** 0.8
   - **Friction Combine:** Minimum
   - **Bounce Combine:** Maximum

4. Maak een bal: **GameObject > 3D Object > Sphere**.
5. Selecteer de bal → selecteer de **Sphere Collider**.
6. Sleep het `Bouncy`-materiaal naar het **Material**-veld van de Sphere Collider.
7. Voeg een Rigidbody toe aan de bal: Mass = 1, Drag = 0.1.

### Testscript: bal omhoog gooien
8. Maak `ThrowBall.cs`:

```csharp
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private float throwForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            rb.velocity = Vector3.zero; // reset velocity voor herhaald gooien
            rb.AddForce(Vector3.up * throwForce, ForceMode.Impulse);
        }
    }
}
```

9. Koppel het script aan de bal. Test met T-toets: stuitert de bal?

---

## Stap 4 — PhysicsMaterial voor de vloer

Maak ook een materiaal voor de vloer zodat objecten er correct op reageren:

1. **rechtermuisknop > Create > Physic Material**. Noem het `FloorMaterial`.
2. Stel in:
   - **Dynamic Friction:** 0.6
   - **Static Friction:** 0.6
   - **Bounciness:** 0.0
3. Selecteer de Plane (vloer) → voeg het materiaal toe aan zijn Collider.

---

## Stap 5 — Rigidbody Constraints

Constraints voorkomen ongewenste beweging of rotatie.

### Voorbeeld: barrel die niet mag omvallen
1. Selecteer een barrel.
2. In Rigidbody → **Constraints**:
   - **Freeze Rotation X:** ✅
   - **Freeze Rotation Z:** ✅
   - Laat Y vrij (de barrel mag wel draaien om zijn eigen as)
3. Test: de barrel schuift weg maar valt niet om.

### Voorbeeld: speler die niet roteert bij botsing
Op de speler (als je Rigidbody gebruikt in plaats van CharacterController):
- **Freeze Rotation X:** ✅
- **Freeze Rotation Y:** ✅ (optioneel — anders draait hij mee)
- **Freeze Rotation Z:** ✅

---

## Stap 6 — AddTorque: roterende objecten

```csharp
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    [SerializeField] private float torqueForce = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            // Roteer om de Y-as
            rb.AddTorque(Vector3.up * torqueForce);
        }
    }
}
```

Koppel dit aan een barrel. Druk R: de barrel begint te draaien.

---

## Stap 7 — Kanon bouwen: AddForce met VelocityChange

```csharp
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Instellingen")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed = 20f;
    [SerializeField] private float launchAngle = 30f; // graden omhoog

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Fire();
    }

    void Fire()
    {
        // Richting berekenen met launch angle
        Vector3 direction = Quaternion.AngleAxis(-launchAngle, transform.right) * transform.forward;

        // Bal instantiëren
        GameObject ball = Instantiate(ballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // VelocityChange negeert massa — direct snelheid toewijzen
        rb.AddForce(direction * fireSpeed, ForceMode.VelocityChange);

        // Ruim de bal na 5 seconden op
        Destroy(ball, 5f);
    }
}
```

### Setup
1. Maak een leeg GameObject: `Cannon`. Roteer het richting het doel.
2. Maak een child leeg GameObject: `FirePoint` (voor de loop-positie).
3. Maak een ball-prefab (Sphere + Rigidbody + Bouncy PhysicsMaterial).
4. Koppel alles in de Inspector.
5. Test met F-toets.

---

## Stap 8 — Physics Puzzle Kamer

Ontwerp een ruimte met 3 puzzel-objecten:

### Puzzel 1: Zware kist op een drukplaat
- Maak een `PressurePlate.cs` met `OnTriggerStay`:

```csharp
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private float minMass = 10f;

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null && rb.mass >= minMass)
            door.SetActive(false); // deur verdwijnt / gaat open
    }

    void OnTriggerExit(Collider other)
    {
        door.SetActive(true); // deur gaat dicht
    }
}
```

### Puzzel 2: Stuiterball als schakelaar
- Een bal moet een `OnTriggerEnter`-zone raken om een deur te openen.

### Puzzel 3: Barrel wegduwen om een pad vrij te maken
- Gebruik de `PushOnCollision.cs` uit Stap 1.

---

## Stap 9 — Technische notitie bijhouden

Maak tijdens het bouwen een eenvoudige tabel van je keuzes:

| Object | Massa | Drag | PhysicsMaterial | Reden |
|---|---|---|---|---|
| Barrel licht | 1 | 0.5 | Geen | Gemakkelijk te duwen |
| Barrel zwaar | 20 | 2.0 | FloorMaterial | Obstakel, niet te bewegen |
| Stuiterende bal | 1 | 0.1 | Bouncy | Puzzel-mechaniek |
| Kist | 15 | 1.0 | FloorMaterial | Zwaar genoeg voor drukplaat |

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Barrel vliegt door de lucht | ForceMode.Impulse te groot | Verlaag pushForce |
| Bal stuitert niet | PhysicsMaterial niet op Collider | Sleep materiaal naar Sphere Collider |
| Speler duwt barrel niet | Script op verkeerd object | `PushOnCollision` hoort op de speler |
| Barrel slingert wild | AngularDrag te laag | Verhoog AngularDrag |
| Constraints werken niet | Kinematic staat aan | Zet `Is Kinematic` op ❌ |

---

## Controlelijst voor afronding

- [ ] Lichte barrel (mass=1) en zware barrel (mass=20) aangemaakt
- [ ] `PushOnCollision.cs` op de speler: barrels reageren op botsing
- [ ] Verschil in massa duidelijk voelbaar
- [ ] `Bouncy` PhysicsMaterial aangemaakt en toegepast op bal
- [ ] Bal stuitert correct en komt uiteindelijk tot stilstand
- [ ] Vloer heeft `FloorMaterial` met friction
- [ ] `Freeze Rotation X/Z` op barrels zodat ze niet omvallen
- [ ] Kanon schiet bal met launch angle via `ForceMode.VelocityChange`
- [ ] Physics puzzle kamer met minimaal 3 objecten gebouwd
- [ ] Technische notitie met massa/drag/materiaal-keuzes ingevuld
