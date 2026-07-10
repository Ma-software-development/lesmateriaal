# Step By Step — Mixamo: Modellen, Animaties & Animator Controller

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt een karakter en animaties downloaden van Mixamo en correct importeren in Unity
- Je begrijpt de belangrijkste import settings (Rig, Avatar, Loop Time)
- Je kunt een Animator Controller opzetten met states, parameters en transitions

---

## Stap 1 — Karakter downloaden van Mixamo

1. Ga naar [mixamo.com](https://www.mixamo.com) en log in (gratis Adobe-account vereist).
2. Klik bovenaan op **Characters** en kies een karakter (bijv. "Xbot" of "Ybot").
3. Klik op **Use this character**.
4. Klik op **Download**.
5. Stel het formaat in:
   - **Format:** FBX for Unity
   - **Skin:** With Skin (voor het model inclusief texturen)
   - **Pose:** T-pose
6. Klik **Download** en sla het bestand op.

---

## Stap 2 — Animaties downloaden van Mixamo

Herhaal dit voor elke animatie die je nodig hebt (Idle, Walk, Run, Jump).

1. Klik bovenaan op **Animations**.
2. Zoek een animatie, bijv. `Idle`.
3. Klik de animatie aan — je karakter toont hem direct.
4. Klik **Download**:
   - **Format:** FBX for Unity
   - **Skin:** Without Skin (want je hebt het model al)
   - **Frames per Second:** 30
   - **Keyframe Reduction:** None
5. Sla elke animatie op met een duidelijke naam: `Worker_Idle.fbx`, `Worker_Walk.fbx`, etc.

Download minimaal:

- `Idle` (rustig staan)
- `Walking` (lopen)
- `Running` (rennen)
- `Jump` (sprong omhoog)
- `Falling Idle` (in de lucht)
- `Hard Landing` (landen)

---

## Stap 3 — FBX-bestanden importeren in Unity

1. Sleep alle gedownloade `.fbx`-bestanden vanuit Windows Verkenner naar de **Project** view in Unity (bijv. naar de map `Assets/3d/`).
2. Unity importeert ze automatisch.

---

## Stap 4 — Rig instellen op Humanoid

Dit is de **belangrijkste stap** — zonder dit werken animaties niet correct op het karakter.

1. Selecteer het **karakter**-FBX in de Project view (het model mét skin, bijv. `Worker_Idle_SKIN.fbx`).
2. Ga in de Inspector naar het tabblad **Rig**.
3. Stel **Animation Type** in op **Humanoid**.
4. Klik **Apply**.
5. Klik daarna op **Configure...** om de Avatar te controleren.
6. In het Avatar-venster: controleer of alle lichaamsdelen groen zijn. Rood betekent dat een bone niet is herkend.
7. Als alles groen is: klik **Done**.

### Animaties instellen op Humanoid

Herhaal stap 4 voor **elke animatie-FBX** (zonder skin):

1. Selecteer de animatie-FBX.
2. Rig → Animation Type → **Humanoid**.
3. Stel **Avatar Definition** in op **Copy From Other Avatar**.
4. Sleep het Avatar van je karakter-FBX naar het **Source** veld.
5. Klik **Apply**.

---

## Stap 5 — Materials en textures uitpakken

FBX-bestanden bevatten materialen en textures ingebakken in het bestand. Unity kan ze niet direct aanpassen zolang ze daarin zitten. Je pakt ze los uit zodat je ze kunt bewerken.

> Doe dit alleen voor het **karakter-FBX** mét skin — animatie-FBXes zonder skin hebben geen materialen.

1. Selecteer het **karakter-FBX** in de Project view.
2. Ga in de Inspector naar het tabblad **Materials**.
3. Klik op **Extract Textures...**
   - Kies of maak een map aan, bijv. `Assets/3d/Textures`.
   - Klik **Choose** (of **Select Folder**).
4. Klik op **Extract Materials...**
   - Kies of maak een map aan, bijv. `Assets/3d/Materials`.
   - Klik **Choose**.
5. Klik **Apply**.

Na het uitpakken zie je de losse materiaal- en textuurbestanden in je Project view staan. Het karakter toont nu zijn kleuren en texturen correct in de scene.

> **Tip:** Als het karakter roze of paars verschijnt, controleer dan of de materials correct zijn uitgepakt en of je een URP-project gebruikt. Converteer eventueel via **Edit → Rendering → Render Pipeline Converter**.

---

## Stap 6 — Animatie-clips instellen (Loop Time, Root Motion)

1. Selecteer een animatie-FBX, bijv. `Worker_Walk.fbx`.
2. Ga naar het tabblad **Animation** in de Inspector.
3. Selecteer de animatie-clip (in de lijst onderaan).
4. Stel in:
   - ✅ **Loop Time** — vink aan voor lopen, rennen, idle (herhalende animaties)
   - ✅ **Loop Pose** — vink aan voor een naadloze loop
   - **Root Transform Rotation** → Bake Into Pose: ✅
   - **Root Transform Position (Y)** → Bake Into Pose: ✅ (voor jump/landing: uitvinken)
   - **Root Transform Position (XZ)** → Bake Into Pose: ✅ (voor in-place animaties)
5. Klik **Apply**.

> **Loop Time aan vs uit:**
>
> - ✅ Loop Time aan: Idle, Walk, Run (herhalen eindeloos)
> - ❌ Loop Time uit: Jump, Landing (eenmalig afspelen)

---

## Stap 7 — Animator Controller aanmaken

1. In de Project view: **rechtermuisknop > Create > Animator Controller**.
2. Noem het `WorkerController`.
3. Dubbelklik om de **Animator** editor te openen.

---

## Stap 8 — States toevoegen aan de Animator Controller

1. In de Animator editor: **rechtermuisknop > Create State > Empty**.
2. Herhaal dit voor elke animatie. Noem de states:
   - `Idle`
   - `Walk`
   - `Run`
   - `Jump`
   - `Fall`
   - `Land`
3. Koppel een animatieclip aan elke state:
   - Selecteer de state.
   - Sleep in de Inspector de bijbehorende `.fbx`-animatieclip naar het veld **Motion**.

> **Entry:** De oranje state is de beginstate. Sleep een pijl van **Entry** naar `Idle` om de game te beginnen in de Idle-staat.

---

## Stap 9 — Parameters aanmaken

Parameters zijn variabelen waarmee scripts de Animator aansturen.

1. Klik links op het tabblad **Parameters** in de Animator editor.
2. Klik op **+** en voeg toe:
   - `Speed` — **Float** (0 = stil, positief = lopen, groter = rennen)
   - `Grounded` — **Bool** (true = op de grond)
   - `JumpTrigger` — **Trigger** (éénmalig schot)

---

## Stap 10 — Transitions aanmaken

Transitions bepalen wanneer de Animator van de ene naar de andere state gaat.

### Idle → Walk

1. Klik met de rechtermuisknop op de `Idle` state → **Make Transition** → klik op `Walk`.
2. Selecteer de transition (de pijl). In de Inspector:
   - ❌ **Has Exit Time** — uitvinken (we willen directe overgang)
   - **Transition Duration:** 0.1
3. Klik **+ (Add Condition)**:
   - `Speed` → **Greater** → `0.1`

### Walk → Idle

1. Rechtermuisknop op `Walk` → **Make Transition** → `Idle`.
2. Condition: `Speed` → **Less** → `0.1`

### Walk → Run

1. `Walk` → `Run`. Condition: `Speed` → **Greater** → `7.0`

### Run → Walk

1. `Run` → `Walk`. Condition: `Speed` → **Less** → `7.0`

### Idle/Walk/Run → Jump (via Any State)

1. Rechtermuisknop op **Any State** → **Make Transition** → `Jump`.
2. Condition: `JumpTrigger`

### Jump → Fall

1. `Jump` → `Fall`. **Has Exit Time**: ✅, Exit Time: `0.8` (na 80% van de sprong-animatie)

### Fall → Land

1. `Fall` → `Land`. Condition: `Grounded` → **true**

### Land → Idle

1. `Land` → `Idle`. **Has Exit Time**: ✅, Exit Time: `1.0`

---

## Stap 11 — Animator Controller koppelen aan karakter

1. Sleep het karakter-FBX (`Worker_Idle_SKIN.fbx`) vanuit de Project view naar de **Hierarchy** om hem in de scene te plaatsen.
2. Selecteer het karakter in de Hierarchy.
3. In de Inspector: zoek het **Animator**-component.
4. Sleep je `WorkerController` naar het veld **Controller**.
5. Zorg dat **Avatar** ingesteld is op het Avatar van je karakter.

---

## Stap 12 — Animator aansturen vanuit script

Voeg de Animator toe aan je bestaande `InputPlayer`-script. Het volledige script ziet er als volgt uit:

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
    [SerializeField] private bool isGrounded = false;

    private Animator animator;

    void Awake()
    {
        InputActionMap map = input.FindActionMap(mapName);
        moveAction   = map.FindAction("Move");
        jumpAction   = map.FindAction("Jump");
        sprintAction = map.FindAction("Sprint");
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()  { input.FindActionMap(mapName).Enable(); }
    void OnDisable() { input.FindActionMap(mapName).Disable(); }

    void Update()
    {
        // Opvragen van de input
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        // Bepalen wat de snelheid is
        float speed = walkSpeed * moveInput.y;

        // Sprinten
        if (sprintAction.IsPressed())
            speed *= 2f;

        // Bewegen van de speler
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Draaien van de speler
        float angle = moveInput.x * turnSpeed * Time.deltaTime;
        transform.Rotate(0f, angle, 0f, Space.World);

        // Springen
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            // Spring animatie triggeren
            animator.SetTrigger("JumpTrigger");
        }

        // Loop en sprint animaties aansturen
        animator.SetFloat("Speed", speed);
        animator.SetBool("Grounded", isGrounded);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
```

> **Let op:** Het karakter-model moet een **child** zijn van het GameObject met dit script, zodat `GetComponentInChildren<Animator>()` de Animator vindt.

---

## Stap 13 — Testen

1. Druk op **Play**.
2. Controleer:
   - Staat het karakter stil in Idle?
   - Speelt Walk af als je beweegt?
   - Schakelt hij over naar Run bij sprinten?
   - Springt de animatie correct en landt hij terug?
3. Open het **Animator**-venster in Play mode om live te zien welke state actief is.

---
