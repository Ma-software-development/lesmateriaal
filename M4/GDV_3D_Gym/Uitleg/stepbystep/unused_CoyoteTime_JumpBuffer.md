# Step By Step — Coyote Time & Jump Buffer: Betere Sprong in een Platformer

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt wat coyote time is en waarom het het spelen aangenamer maakt
- Je kunt coyote time implementeren zodat de speler nog kort na een rand kan springen
- Je begrijpt wat een jump buffer is en hoe het vroeg indrukken van de sprong-knop afvangt
- Je kunt beide technieken combineren in één sprongsysteem

---

## Concept: het probleem zonder coyote time

In een platformer zonder coyote time voelt het springen soms oneerlijk:

```
Grond: ████████████████████
Rand:                      │
Speler loopt over rand ────►│
Speler drukt Space          │   ← te laat, al in de lucht
Sprong mislukt!
```

Met **coyote time** krijgt de speler een korte tijdspanne (bijv. 0.15 sec) na het verlaten van de grond om toch nog te springen. Dit is een bewust ontwerp-compromis: het voelt eerlijk aan zonder het spel makkelijker te maken.

**Jump buffer** lost het omgekeerde probleem op: de speler drukt Space *net voor* hij de grond raakt, maar de sprong wordt genegeerd omdat hij al ingedrukt is vóór de landing. Met een jump buffer onthoudt het spel die indruk en voert de sprong alsnog uit zodra de speler landt.

```
Coyote time:   speler verlaat grond → nog X seconden mogen springen
Jump buffer:   speler drukt Space → als hij binnen Y seconden landt, spring dan
```

---

## Stap 1 — Basisopzet

Deze les bouwt voort op een 2D-platformer met een Rigidbody2D. Je hebt nodig:

- Een **speler**-GameObject met `Rigidbody2D` en `CapsuleCollider2D`.
- Een **grond**-object (bijv. een Tilemap of een platform-sprite) met een `CompositeCollider2D` of `BoxCollider2D` op layer **Ground**.
- Een aparte **Physics Layer** genaamd `Ground`.

Als je nog geen speler hebt:

1. Maak een **Capsule**-sprite → voeg `Rigidbody2D` en `CapsuleCollider2D` toe.
2. Maak een `Tilemap` of een platte `Sprite` als grond → stel Layer in op **Ground**.

---

## Stap 2 — PlayerJump script

1. Maak **`PlayerJump.cs`** en koppel het aan de speler:

```csharp
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Sprong")]
    public float jumpForce = 12f;

    [Header("Gronddetectie")]
    public Transform groundCheck;       // leeg child-object onder de speler
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Coyote time")]
    public float coyoteTime = 0.15f;    // seconden na verlaten grond

    [Header("Jump buffer")]
    public float jumpBufferTime = 0.15f; // seconden dat een vroege sprong onthouden wordt

    private Rigidbody2D rb;

    private bool isGrounded;
    private float coyoteTimer  = 0f;
    private float jumpBufferTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- Gronddetectie ---
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        // --- Coyote timer ---
        if (isGrounded)
        {
            coyoteTimer = coyoteTime;   // reset zolang de speler op de grond staat
        }
        else
        {
            coyoteTimer -= Time.deltaTime;  // telt af zodra speler de grond verlaat
        }

        // --- Jump buffer timer ---
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimer = jumpBufferTime;   // speler heeft gedrukt: onthoud dit
        }
        else
        {
            jumpBufferTimer -= Time.deltaTime;
        }

        // --- Sprong uitvoeren ---
        // Voorwaarden: er is een gebufferde sprong EN coyote time is nog niet verlopen
        if (jumpBufferTimer > 0f && coyoteTimer > 0f)
        {
            PerformJump();
        }
    }

    private void PerformJump()
    {
        // Zet de verticale snelheid op de sprongkracht
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // Verbruik beide timers zodat we niet dubbel springen
        jumpBufferTimer = 0f;
        coyoteTimer     = 0f;
    }

    // Teken de grondcheck-cirkel zichtbaar in de editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
```

---

## Stap 3 — GroundCheck instellen

1. Selecteer de speler in de Hierarchy.
2. Voeg een **leeg child-GameObject** toe: **rechtermuisknop op speler > Create Empty** → noem het `GroundCheck`.
3. Zet `GroundCheck` **onder** de voeten van de speler (Position Y = −0.5 of lager, afhankelijk van de hoogte van de Capsule).
4. Sleep `GroundCheck` naar het veld **Ground Check** in de Inspector.
5. Stel **Ground Layer** in op de layer `Ground`.

---

## Stap 4 — Beweging toevoegen (optioneel)

Als je nog geen horizontale beweging hebt, voeg dan een eenvoudig bewegingsscript toe:

```csharp
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }
}
```

---

## Stap 5 — Testen

1. Klik op **Play**.
2. **Test coyote time:** loop van een platform af en druk Space net nadat je de rand hebt verlaten. De speler moet nog kunnen springen.
3. **Test jump buffer:** druk Space net vóór je landt na een sprong. Na de landing moet de speler direct opnieuw springen.
4. Stel `coyoteTime` en `jumpBufferTime` bij: grotere waarden zijn vergevingsgezinder, kleinere waarden zijn strakker.

> **Tip voor debuggen:** voeg tijdelijk `Debug.Log($"Coyote: {coyoteTimer:F2}  Buffer: {jumpBufferTimer:F2}");` toe aan `Update()` om de timers live te volgen in de Console.

---

## Samenvatting van de twee technieken

| Techniek | Probleem dat het oplost | Typische waarde |
|---|---|---|
| **Coyote time** | Speler verlaat rand net vóór hij springt | 0.1–0.2 sec |
| **Jump buffer** | Speler drukt Space net te vroeg voor landing | 0.1–0.2 sec |

---

## Overzicht van de scripts

| Script       | Verantwoordelijkheid                                     |
|--------------|----------------------------------------------------------|
| `PlayerJump` | Gronddetectie, coyote time, jump buffer, sprong-uitvoer |
| `PlayerMove` | Horizontale beweging (optioneel, los script)            |

---

## Uitbreidingsideeën

- **Variable jump height:** laat de sprong lager worden als de speler de knop loslaat voor de piek (`rb.velocity.y *= 0.5f`).
- **Double jump:** geef de speler één extra sprong in de lucht door een `extraJumpsLeft`-teller bij te houden.
- **Landing animatie:** speel een squash-animatie af als `isGrounded` net `true` wordt.
