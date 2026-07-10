# Oefening: Beweging & DeltaTime

## Leerdoel

Een object bewegen via scripts en begrijpen waarom `Time.deltaTime` nodig is.

---

## Oefening 1: Constante Beweging

Maak een script `Mover.cs` dat een object constant naar rechts beweegt.

```csharp
public class Mover : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        // TODO: Beweeg naar rechts met speed * Time.deltaTime
        // Hint: transform.position += new Vector3(...)
    }
}
```

**Test:** Het object schuift soepel naar rechts.

**Experiment:** Verwijder `Time.deltaTime` en kijk wat er gebeurt. Waarom is het verschil belangrijk?

---

## Oefening 2: Beweging met Input

Breid het script uit zodat de speler het object bestuurt:

```csharp
public class PlayerMover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // TODO: Maak een Vector3 met h en v
        // TODO: Beweeg het object met speed * Time.deltaTime
    }
}
```

**Test:** Bestuur het object met WASD of pijltjestoetsen.
