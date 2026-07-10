# Oefening: OOP — Abstraction & Polymorphism

## Leerdoel

Abstracte classes en interfaces gebruiken voor polymorfisme.

---

## Oefening 1: Abstract Class — Pickups

Maak een abstract pickup systeem:

```csharp
public abstract class PickupBase : MonoBehaviour
{
    public abstract void ApplyEffect(GameObject player);

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
    }
}
```

Maak twee concrete pickups:

```csharp
public class HealthPickup : PickupBase
{
    public int healAmount = 25;

    public override void ApplyEffect(GameObject player)
    {
        // TODO: Heal de speler (via GetComponent of event)
        Debug.Log("Healed " + healAmount);
    }
}

public class SpeedPickup : PickupBase
{
    public float boostDuration = 3f;

    public override void ApplyEffect(GameObject player)
    {
        // TODO: Geef speler een tijdelijke speed boost
        Debug.Log("Speed boost " + boostDuration + " seconden!");
    }
}
```

**Test:** Beide pickups werken via dezelfde trigger-logica maar hebben verschillend effect.

---

## Oefening 2: Interface — IDamageable

Maak een interface die meerdere objecttypen kunnen implementeren:

```csharp
public interface IDamageable
{
    void TakeDamage(int amount);
    bool IsAlive { get; }
}
```

Implementeer het op twee totaal verschillende objecten:

```csharp
public class Enemy : MonoBehaviour, IDamageable
{
    private int health = 50;
    public bool IsAlive => health > 0;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (!IsAlive) Destroy(gameObject);
    }
}

public class Crate : MonoBehaviour, IDamageable
{
    private int durability = 20;
    public bool IsAlive => durability > 0;

    public void TakeDamage(int amount)
    {
        // TODO: Verminder durability
        // TODO: Als kapot, spawn pickup en destroy
    }
}
```

Maak een universeel damage script:

```csharp
public class DamageDealer : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable target = other.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
}
```

**Test:** Dezelfde kogel beschadigt zowel enemies als kisten.
