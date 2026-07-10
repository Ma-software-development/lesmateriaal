# Step By Step — Input System (Nieuw): Rigidbody Beweging

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je snapt het verschil tussen het oude en nieuwe Input System
- Je kunt een `InputActionAsset` aanmaken met Action Maps en Bindings
- Je kunt input uitlezen met `ReadValue<Vector2>()`, `WasPressedThisFrame()` en `IsPressed()`
- Je kunt een Rigidbody bewegen en laten springen via scripts
- Je kunt twee spelers aansturen via aparte Action Maps in één InputActionAsset

---

## Achtergrond: oud vs. nieuw Input System

| Oud systeem                   | Nieuw systeem                                   |
| ----------------------------- | ----------------------------------------------- |
| `Input.GetKey(KeyCode.Space)` | `jumpAction.WasPressedThisFrame()`              |
| Hardcoded aan toetsenbord     | Configureerbaar: toetsenbord, controller, touch |
| Geen hergebruik mogelijk      | Action Maps per context (gameplay, UI, menu)    |
| Polling per frame             | Event-driven of polling mogelijk                |

> **Polling vs Events**  
> Als Elk frame wordt door het script wordt gekeken of een bepaalde knop is ingedrukt noem je dat polling. Je kunt ook een gebeurtenis afwachten (Action Events), dan hoeft er niet elke frame een controle plaats te vinden.

Het nieuwe Input System werkt met een **InputActionAsset**: een bestand dat alle inputs definieert, los van de code.

---

## Stap 1 — InputActionAsset openen

1. In de **Project** view in de **Assets** map open je het bestand: **InputSystem_Actions.inputactions**.
2. Dubbelklik op het bestand om de editor te openen.

### Action Map bekijken

3. Klik links op de **Player** map in de kolom `Action Maps`.
4. Klap de Input Action **Move** open door op de pijl ernaast te klikken.

In de Action zitten de **Bindings** opgeslagen: Left Stick, WASD, Stick (Joystick).

Deze bindings triggeren de Input Action die `Move` heet. Die je later in je script gaat gebruiken.

5. Klap de Input Action **Jump** open en check de bindings:
   - Space
   - Button South
   - secondaryButton [XR Controller]

### Eigen Actions aanmaken

6. Klik rechts op de **+** naast "Actions".
7. Maak de volgende actions:
   - `Restart` — Action Type: **Button**
   - `Zoom` — Action Type: **Value**

### Bindings toevoegen aan Restart

8. Klik op de `<No Binding>` onder `Restart`.
9. Klik op **Path** → zoek naar `R` → selecteer **Keyboard/R**.

> **Tip:** klik op de `listen` knop en druk dan de `r` in op je toetsenbord.

### Bindings toevoegen aan Zoom

10. Klik op het **plusje** naast `Zoom`.
11. Klik op **Add Positive/Negative Binding**.
12. Stel de **Composite Type** in op `1D Axis` (2 knoppen).
13. Stel de composite in:
    - Negative: `-` (uitzoomen)
    - Positive: `=` (inzoomen)

> **Tip:** Voor een compositie met 4 knoppen kun je i.p.v `1D Axis` een `2D Vector` gebruiken. Zoals bij `WASD` en de `pijltjes toetsen`.

14. Klik **Save Asset** (rechtsboven in de editor).

---

## Stap 2 — Twee Action Maps aanmaken: Player1 en Player2

Om twee blokjes onafhankelijk van elkaar te kunnen besturen, maak je twee aparte Action Maps: één voor Player 1 (WASD + Spatie) en één voor Player 2 (IJKL + Enter).

1. Open **InputSystem_Actions.inputactions** (dubbelklik).
2. Klik op de **+** naast "Action Maps" (linkerkolom).
3. Noem de nieuwe map `Player1`.
4. Klik opnieuw op de **+** en maak een tweede map: `Player2`.

### Actions aanmaken voor Player1

5. Selecteer de map **Player1** in de linkerkolom.
6. Klik op de **+** naast "Actions" en maak de volgende actions:
   - `Move` — Action Type: **Value**, Control Type: **Vector2**
   - `Jump` — Action Type: **Button**
   - `Sprint` — Action Type: **Button**
7. Klap `Move` open → klik **+ > Add Up/Down/Left/Right Composite**.
8. Stel de composite in:
   - Up: `W`
   - Down: `S`
   - Left: `A`
   - Right: `D`
9. Klik op `<No Binding>` onder `Jump` → **Path**: **Keyboard/Space**.
10. Klik op `<No Binding>` onder `Sprint` → **Path**: **Keyboard/Left Shift**.

### Actions aanmaken voor Player2

11. Selecteer de map **Player2** in de linkerkolom.
12. Klik op de **+** naast "Actions" en maak de volgende actions:
    - `Move` — Action Type: **Value**, Control Type: **Vector2**
    - `Jump` — Action Type: **Button**
    - `Sprint` — Action Type: **Button**
13. Klap `Move` open → klik **+ > Add Up/Down/Left/Right Composite**.
14. Stel de composite in:
    - Up: `Up Arrow`
    - Down: `Down Arrow`
    - Left: `Left Arrow`
    - Right: `Right Arrow`
15. Klik op `<No Binding>` onder `Jump` → **Path**: **Keyboard/Right Ctrl**.
16. Klik op `<No Binding>` onder `Sprint` → **Path**: **Keyboard/Right Shift**.
17. Klik **Save Asset** (rechtsboven).

---

## Stap 3 — Scene opzetten

1. Maak een nieuwe scene of gebruik een bestaande.
2. Voeg een vloer toe: **GameObject > 3D Object > Plane** (schaal: X=5, Z=5).
3. Voeg het eerste blokje toe: **GameObject > 3D Object > Cube**. Hernoem het naar `Player1`.
4. Voeg een tweede blokje toe: **GameObject > 3D Object > Cube**. Hernoem het naar `Player2`.
   Zet `Player2` op een andere startpositie zodat ze niet overlappen, bijv. X=3.
5. Selecteer **Player1**. In de Inspector: klik **Add Component** → **Rigidbody**.
   Vink aan bij Constraints: **Freeze Rotation X**, **Freeze Rotation Z**.
6. Selecteer **Player2**. Doe hetzelfde: **Add Component** → **Rigidbody** + zelfde Constraints.

> **Tip:** Geef de blokjes een ander materiaal of kleur zodat je ze visueel kunt onderscheiden.

---

## Stap 4 — Script schrijven: InputPlayer.cs

1. In de Project view: **rechtermuisknop > Create > C# Script**. Noem het `InputPlayer`.
2. Dubbelklik om het te openen in je code-editor.
3. Schrijf de volgende code:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class InputPlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float turnSpeed = 150f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private string mapName = "Player";

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    private Rigidbody rb;
    private bool isGrounded = false;

    void Awake()
    {
        InputActionMap map = input.FindActionMap(mapName);
        moveAction  = map.FindAction("Move");
        jumpAction  = map.FindAction("Jump");
        sprintAction = map.FindAction("Sprint");
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()  { input.FindActionMap(mapName).Enable(); }
    void OnDisable() { input.FindActionMap(mapName).Disable(); }

    void Update()
    {
         // Opvragen van de input
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        //bepalen wat de snelheid is
        float speed = walkSpeed * moveInput.y;

        //sprinten
        if (sprintAction.IsPressed())
            speed *= 2f;

        //bewegen van de speler
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        //draaien van de speler
        float angle = moveInput.x * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, angle, 0f, Space.World);


        // Springen
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
```

4. Sla op: **Ctrl + S**.

---

## Stap 5 — Scripts koppelen aan beide blokjes

Het script `InputPlayer` werkt voor beide spelers — je stelt per blokje alleen een andere **Map Name** in.

### Player1

1. Selecteer **Player1** in de Hierarchy.
2. Sleep het script `InputPlayer` naar de Inspector, of gebruik **Add Component > InputPlayer**.
3. Sleep het `InputSystem_Actions.inputactions`-bestand naar het veld **Input**.
4. Zet **Map Name** op `Player1`.
5. Stel **Move Speed** in op `5`, **Turn Speed** op `150` en **Jump Force** op `5`.

### Player2

6. Selecteer **Player2** in de Hierarchy.
7. Voeg ook het script `InputPlayer` toe.
8. Sleep hetzelfde `InputSystem_Actions.inputactions`-bestand naar het veld **Input**.
9. Zet **Map Name** op `Player2`.
10. Stel **Move Speed** in op `5`, **Turn Speed** op `150` en **Jump Force** op `5`.

---

## Stap 6 — Ground tag instellen

1. Selecteer de **Plane** (vloer) in de Hierarchy.
2. Klik bovenaan de Inspector op **Tag > Add Tag…**
3. Voeg een nieuwe tag toe: `Ground`.
4. Selecteer de Plane opnieuw en stel de Tag in op `Ground`.

---

## Stap 7 — Testen

1. Druk op **Play** (▶).
2. **Player1**: beweeg met WASD, spring met Left Ctrl, sprint met Left Shift.
3. **Player2**: beweeg met pijltjestoetsen, spring met Right Ctrl, sprint met Right Shift.

> **Werkt de sprong niet?**  
> Controleer of de Plane de tag `Ground` heeft. Controleer ook of `isGrounded` correct wordt ingesteld via `OnCollisionEnter`.

---

## Stap 8 — Gronddetectie via Physics.CheckSphere (robuustere methode)

De `OnCollisionEnter/Exit`-methode kan onbetrouwbaar zijn bij schuin terrein. Een betere methode:

```csharp
[SerializeField] private LayerMask groundLayer;
[SerializeField] private float groundCheckRadius = 0.2f;

private bool IsGrounded()
{
    // Controleer vlak onder het object of er grond is
    return Physics.CheckSphere(
        transform.position + Vector3.down * 0.5f,
        groundCheckRadius,
        groundLayer
    );
}
```

Vervang `isGrounded` in `Update` door de aanroep `IsGrounded()`:

```csharp
if (jumpAction.WasPressedThisFrame() && IsGrounded())
{
    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
}
```

Maak een nieuwe **Layer** aan (`Ground`) en wijs die toe aan de vloer. Stel `groundLayer` in de Inspector in op die layer.
