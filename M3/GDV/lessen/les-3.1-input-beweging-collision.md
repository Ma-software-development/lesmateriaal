# Les 3.1 — Input, Beweging & Collision Detection

## Leerdoel

Na deze les kun je player input opvangen en een character laten bewegen met collision detection.

---

## Theorie

### Input System

Unity heeft twee manieren om input te lezen:

**Legacy Input (simpel)**

```csharp
float horizontal = Input.GetAxis("Horizontal"); // -1 tot 1
float vertical = Input.GetAxis("Vertical");     // -1 tot 1

if (Input.GetKeyDown(KeyCode.Space))
{
    // Spatie ingedrukt
}
```

**New Input System (geavanceerd)**
Vereist package installatie, maar geeft meer controle.

### Beweging met Transform

Simpele beweging zonder physics:

```csharp
void Update()
{
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");

    Vector3 direction = new Vector3(h, v, 0);
    transform.position += direction * speed * Time.deltaTime;
}
```

### Beweging met Rigidbody2D

Beweging met physics (aanbevolen):

```csharp
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input lezen
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Beweging toepassen
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
```

### Collision Detection

**Colliders:** Definiëren de vorm voor botsingen

- BoxCollider2D
- CircleCollider2D
- PolygonCollider2D

**Collision Events:**

```csharp
// Bij botsing met solid object
void OnCollisionEnter2D(Collision2D collision)
{
    Debug.Log("Botst met: " + collision.gameObject.name);
}

// Bij trigger (isTrigger = true)
void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Dot"))
    {
        Destroy(other.gameObject);
    }
}
```

### Setup Checklist

| Component   | Instelling                     |
| ----------- | ------------------------------ |
| Rigidbody2D | Gravity Scale = 0              |
| Rigidbody2D | Constraints: Freeze Rotation Z |
| Collider2D  | Passend bij sprite             |
| Muren       | Collider2D (geen trigger)      |
| Dots        | Collider2D + Is Trigger = true |

---

## Oefeningen

### Oefening 1: Basis Beweging

Maak een bestuurbare speler:

1. Maak een `Player` GameObject met:
   - SpriteRenderer (kies een sprite)
   - Rigidbody2D (Gravity = 0)
   - BoxCollider2D of CircleCollider2D

2. Maak script `PlayerMovement.cs`:

```csharp
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        // TODO: Haal Rigidbody2D op
    }

    void Update()
    {
        // TODO: Lees input
    }

    void FixedUpdate()
    {
        // TODO: Beweeg de speler
    }
}
```

**Test:** Je kunt de speler bewegen met WASD of pijltjestoetsen.

---

### Oefening 2: Dots Verzamelen

Voeg dots toe die je kunt verzamelen:

1. Maak een `Dot` prefab met:
   - SpriteRenderer (kleine cirkel)
   - CircleCollider2D met Is Trigger = **true**
   - Tag: "Dot"

2. Voeg aan `PlayerMovement.cs` toe:

```csharp
void OnTriggerEnter2D(Collider2D other)
{
    // TODO: Check of het een Dot is
    // TODO: Destroy de dot
    // TODO: Print "Dot collected!" in console
}
```

3. Plaats 5 dots in de scene

**Test:** Loop over een dot en deze verdwijnt met een console message.

---

## Toepassing

Implementeer beweging in je eigen game:

1. Kies: 4-richtingen (PAC-MAN style) of vrije beweging?
2. Voeg muren toe die de speler blokkeren
3. Voeg je eerste verzamelobjecten toe

**PAC-MAN tip:** Voor grid-gebaseerde beweging kun je de speler alleen laten draaien op kruispunten.
