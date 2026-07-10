# Oefening: DRY & SRP

## Leerdoel

Design principes Don't Repeat Yourself (DRY) en Single Responsibility Principle (SRP) herkennen en toepassen.

---

## Oefening 1: DRY — Code Hergebruiken

Onderstaande code is niet DRY. **Refactor** het:

```csharp
// VOOR (niet DRY):
public class EnemyA : MonoBehaviour
{
    public int health = 50;
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }
}

public class EnemyB : MonoBehaviour
{
    public int health = 80;
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) Destroy(gameObject);
    }
}
```

**Opdracht:** Maak één `Damageable` script dat beide enemies kunnen gebruiken. Verwijder de duplicate code.

```csharp
// TODO: Maak een Damageable class met health en TakeDamage
// Zet dit script op beide enemies met verschillende health waardes
```

---

## Oefening 2: SRP — Verantwoordelijkheden Splitsen

Onderstaand script doet te veel. **Splits** het in meerdere scripts:

```csharp
// VOOR (niet SRP):
public class PlayerDoEverything : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;
    public int score = 0;
    public Text scoreText;
    public AudioClip hitSound;

    void Update()
    {
        // Beweging
        float h = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * h * speed * Time.deltaTime;

        // Score UI
        scoreText.text = "Score: " + score;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 10;
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(hitSound);
        }
        if (other.CompareTag("Enemy"))
        {
            health -= 20;
        }
    }
}
```

**Opdracht:** Splits in minimaal 3 scripts:

1. `PlayerMovement` — alleen beweging
2. `PlayerHealth` — alleen health-logica
3. `ScoreManager` — alleen score en UI

Schrijf de 3 scripts en zorg dat ze samenwerken.
