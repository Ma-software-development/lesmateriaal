# Step By Step — CharacterController: Bewegen & Springen

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt het verschil tussen `CharacterController` en `Rigidbody` beweging
- Je kunt `CharacterController.Move()` correct gebruiken
- Je kunt de sprong-formule gebruiken in je game

---

## Achtergrond: CharacterController vs. Rigidbody

| Eigenschap         | CharacterController             | Rigidbody                            |
| ------------------ | ------------------------------- | ------------------------------------ |
| Bewegingscontrole  | Direct, volledig in jouw code   | Indirect via krachten                |
| Botsingen          | Ingebouwd (schuift langs muren) | Via PhysX engine                     |
| Zwaartekracht      | Zelf implementeren              | Automatisch                          |
| Gebruik            | Speler-characters               | Physische objecten (barrels, ballen) |
| Animator-koppeling | Eenvoudig                       | Soms complex                         |

**Kies CharacterController als:** je volledige controle wilt over hoe de speler beweegt.  
**Kies Rigidbody als:** een object realistisch moet reageren op botsingen en krachten.

---

## Stap 1 — CharacterController toevoegen aan het karakter

1. Download een nieuw karakter van Mixamo met daarbij ook weer `idle`, `walk`, `run` en `jump` animaties
2. Plaats je Karakter in de hierarcy
3. In de Inspector: **Add Component > Physics > Character Controller**.
4. Stel de CharacterController in:
   - **Center:** Y = 1.0 (middelpunt op borsthoogte, afhankelijk van karakterhoogte)
   - **Radius:** 0.4 (breedte van de capsule)
   - **Height:** 2.0 (hoogte van het karakter)
5. Controleer in de Scene view: de groene capsule moet het karakter netjes omhullen.

> **Tip:** Klik op het **Gizmos**-dropdown in de Scene view en zorg dat Physics is aangevinkt om de capsule te zien.

---

## Stap 2 — Script aanmaken: MoveCharacterController.cs

1. Maak een nieuw C#-script: `MoveCharacterController`.
2. Schrijf de volgende code:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCharacterController : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAsset;
    [SerializeField] private string mapName = "Player";
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sprintMultiplier = 2f;
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -20f;


    private InputAction moveAction;
    private InputAction sprintAction;
    private InputAction jumpAction;

    private CharacterController characterController;
    private Animator animator;
    private float verticalVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        InputActionMap map  = inputAsset.FindActionMap(mapName);
        moveAction          = map.FindAction("Move");
        sprintAction        = map.FindAction("Sprint");
        jumpAction          = map.FindAction("Jump");
    }

    void OnEnable()  { map.Enable(); }
    void OnDisable() { map.Disable(); }

    void Update()
    {
        Vector2 movementInput = moveAction.ReadValue<Vector2>();

        float speed = movementInput.y * moveSpeed;
        // Sprint
        if (sprintAction.IsPressed())
            speed *= 2;

        // Voorwaartse beweging wordt later verwerkt in de Move methode
        Vector3 move = transform.forward * speed * Time.deltaTime;

        // Rotatie (links/rechts draaien)
        transform.Rotate(Vector3.up * movementInput.x * rotationSpeed * Time.deltaTime);

        // Zwaartekracht en springen
        if (characterController.isGrounded)
        {
            verticalVelocity = -1f; // kleine downward force om grounded te blijven

            if (jumpAction.WasPressedThisFrame())
            {
                // Sprong-formule: v = sqrt(2 * |g| * h)
                verticalVelocity = Mathf.Sqrt(2f * Mathf.Abs(gravity) * jumpHeight);
                animator.SetTrigger("JumpTrigger");
            }
        }
        else
        {
            // Niet op de grond: zwaartekracht toepassen
            verticalVelocity += gravity * Time.deltaTime;
        }


        //verticale snelheid meegeven via de move vector
        move.y = verticalVelocity * Time.deltaTime;

        characterController.Move(move);

        // Animator aansturen voor rennen en landen
        animator.SetFloat("Speed", movementInput.y);
        animator.SetBool("Grounded", characterController.isGrounded);
    }
}
```

3. Sla het script op.

---

## Stap 3 — De sprong-formule proberen te begrijpen

De formule `verticalVelocity = Mathf.Sqrt(2f * Mathf.Abs(gravity) * jumpHeight)` komt uit de natuurkunde.

**Kinematische vergelijking:**  
$$v^2 = u^2 + 2as$$

Waarbij:

- $v$ = eindsnelheid (0, op het hoogste punt)
- $u$ = beginsnelheid (wat we zoeken)
- $a$ = versnelling (zwaartekracht, negatief)
- $s$ = afstand (jumpHeight)

Oplossen naar $u$:
$$u = \sqrt{2 \times |g| \times h}$$

**Voorbeeld met waarden uit het script:**

- gravity = -20, jumpHeight = 2
- $u = \sqrt{2 \times 20 \times 2} = \sqrt{80} \approx 8.94$

Dit is de beginsnelheid die het karakter omhoog geeft om precies 2 meter hoog te springen.

---

## Stap 4 — Script koppelen aan het karakter

1. Selecteer het karakter in de Hierarchy.
2. Sleep het script `MoveCharacterController` naar de Inspector.
3. Vul de velden in:
   - **Input Asset:** sleep `PlayerInput.inputactions` hierheen
   - **Map Name:** `Player`
   - **Move Speed:** `5`
   - **Sprint Multiplier:** `2`
   - **Rotation Speed:** `100`
   - **Jump Height:** `2`
   - **Gravity:** `-20`

---

## Stap 5 — Testen: sprong aanpassen

1. Druk op **Play**.
2. Test het springen met Spatie.
3. Stop Play mode.
4. Verander **Jump Height** naar `5` en **Gravity** naar `-10` → langzame maansprong.
5. Verander **Jump Height** naar `1` en **Gravity** naar `-30` → snelle aardse sprong.
6. Noteer welke waarden het beste voelen voor je game.
