# Oefening: OOP — Inheritance & Encapsulation

## Leerdoel

Overerving en inkapseling toepassen in een game-context.

---

## Oefening 1: Inheritance — Enemy Types

Maak een base class en twee afgeleide enemies:

```csharp
public class EnemyBase : MonoBehaviour
{
    public int health = 50;
    public float speed = 2f;

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " health: " + health);
        if (health <= 0) Die();
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " is verslagen!");
        Destroy(gameObject);
    }

    protected virtual void Move()
    {
        // Standaard: beweeg naar links
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Update()
    {
        Move();
    }
}
```

**Maak nu:**

```csharp
public class FastEnemy : EnemyBase
{
    // TODO: Override Move() — beweeg 2x sneller
    // TODO: Override Die() — print "Fast enemy explodeert!" en roep base.Die() aan
}

public class TankEnemy : EnemyBase
{
    // TODO: Start met 150 health
    // TODO: Override TakeDamage — halveer de damage (armor)
}
```

**Test:** FastEnemy beweegt sneller, TankEnemy kan meer damage hebben.

---

## Oefening 2: Encapsulation — Veilige Properties

Refactor een class zodat velden niet zomaar veranderd kunnen worden:

```csharp
public class PlayerStats : MonoBehaviour
{
    // TODO: Maak health private met een public property
    // Getter: vrij toegankelijk
    // Setter: clamp tussen 0 en maxHealth

    private int _health;
    public int maxHealth = 100;

    public int Health
    {
        get { return _health; }
        private set
        {
            // TODO: Clamp value tussen 0 en maxHealth
            _health = value;
        }
    }

    void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        Debug.Log("Health: " + Health);
    }

    public void Heal(int amount)
    {
        Health += amount;
        Debug.Log("Health: " + Health);
    }
}
```

**Test:** `Health` kan niet boven `maxHealth` of onder 0 komen, ook niet via de Inspector.
