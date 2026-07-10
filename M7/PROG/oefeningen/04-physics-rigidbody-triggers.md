# Oefening: Physics — Rigidbody, Colliders & Triggers

## Leerdoel

Rigidbody2D en Collider2D gebruiken voor physics-gebaseerde beweging en botsingsdetectie.

---

## Oefening 1: Rigidbody Bounce

Maak een bal die stuitert:

1. Maak een cirkel-sprite met `Rigidbody2D` en `CircleCollider2D`
2. Maak een vloer met `BoxCollider2D` (geen Rigidbody)
3. Maak een `Physics Material 2D` met Bounciness = 0.8

**Setup:**

- Bal: Rigidbody2D (Gravity Scale = 1), CircleCollider2D + material
- Vloer: BoxCollider2D, positie onder de bal

**Test:** De bal valt en stuitert meerdere keren.

---

## Oefening 2: Trigger Detectie

Maak een pickup-zone die detecteert wanneer de speler erin loopt:

```csharp
public class PickupZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Speler is in de zone!");
            // TODO: Verander de kleur van dit object
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Speler verliet de zone");
            // TODO: Zet de kleur terug
        }
    }
}
```

**Setup:**

- Pickup zone: BoxCollider2D met Is Trigger = **true**
- Player: Rigidbody2D + Collider + Tag "Player"

**Test:** Console messages verschijnen bij binnen- en buitengaan.
