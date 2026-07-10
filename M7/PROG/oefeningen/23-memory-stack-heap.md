# Oefening 23 — Memory: Stack vs Heap

**Onderwerp:** Value types, reference types en garbage collection awareness  
**Module:** M5 / M6

---

## Oefening 23a — Value type vs Reference type

Begrijp het verschil tussen `struct` (stack/value) en `class` (heap/reference).

```csharp
using UnityEngine;

public struct PositionValue
{
    public float x, y;
}

public class PositionReference
{
    public float x, y;
}

public class MemoryTest : MonoBehaviour
{
    void Start()
    {
        // VALUE TYPE — kopie
        PositionValue a = new PositionValue { x = 1, y = 2 };
        PositionValue b = a;       // b is een KOPIE van a
        b.x = 99;
        Debug.Log($"Value: a.x = {a.x}, b.x = {b.x}");

        // REFERENCE TYPE — referentie
        PositionReference c = new PositionReference { x = 1, y = 2 };
        PositionReference d = c;   // d verwijst naar HETZELFDE object
        d.x = 99;
        Debug.Log($"Reference: c.x = {c.x}, d.x = {d.x}");
    }
}
```

**Opdracht:**

1. Maak het script aan en voer het uit.
2. Noteer de output — wat is het verschil?
3. Leg in eigen woorden uit waarom `a.x` nog `1` is, maar `c.x` veranderd is naar `99`.
4. Beantwoord:
   - Welke van deze types belanden op de **stack**?
   - Welke op de **heap**?
   - Wanneer kies je voor een `struct` in plaats van een `class`?

---

## Oefening 23b — Garbage Collection vermijden

Elke `new` op een reference type (class, string concatenation, List) kan GC-pressure veroorzaken.

```csharp
using UnityEngine;

public class GCPressure : MonoBehaviour
{
    // SLECHT — elke frame een nieuwe string
    void Update()
    {
        string status = "HP: " + GetHealth() + " / " + GetMaxHealth();
        Debug.Log(status);
    }

    int GetHealth() => 80;
    int GetMaxHealth() => 100;
}
```

**Opdracht:**

1. Identificeer waarom bovenstaande code elke frame geheugen alloceert.
2. Refactor met een `StringBuilder` of cache de string zodat deze alleen update wanneer nodig:

   ```csharp
   private int cachedHealth = -1;
   private string cachedStatus;

   void Update()
   {
       int hp = GetHealth();
       if (hp != cachedHealth)
       {
           cachedHealth = hp;
           cachedStatus = $"HP: {hp} / {GetMaxHealth()}";
       }
       // Gebruik cachedStatus
   }
   ```

3. **Bonus:** Open de Profiler, ga naar **Memory** en bekijk GC Alloc — vergelijk voor en na je refactor.
