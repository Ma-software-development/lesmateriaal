# Oefening: Vector3 Verdieping

## Leerdoel

Vector3-methodes zoals `Distance`, `Lerp`, `Magnitude` en `Normalize` toepassen.

---

## Oefening 1: Afstandscheck

Maak een script dat de afstand tot een doel meet en reageert:

```csharp
public class DistanceChecker : MonoBehaviour
{
    public Transform target;
    public float alertRange = 5f;

    void Update()
    {
        // TODO: Bereken afstand met Vector3.Distance
        // TODO: Als afstand < alertRange, print "Doel is dichtbij!"
        // TODO: Print de afstand elk frame (optioneel: alleen als die verandert)
    }
}
```

**Test:** Sleep een ander object naar `target`. Beweeg het — zodra het dichtbij komt verschijnt het bericht.

---

## Oefening 2: Smooth Follow (Lerp)

Maak een camera/object dat soepel een doel volgt:

```csharp
public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.05f;

    void LateUpdate()
    {
        if (target == null) return;

        // TODO: Bereken nieuwe positie met Vector3.Lerp
        // Van: transform.position
        // Naar: target.position
        // t: smoothSpeed
        // TODO: Pas transform.position aan
    }
}
```

**Test:** Beweeg het target met WASD — het object volgt soepel in plaats van direct.

**Experiment:** Pas `smoothSpeed` aan (0.01 vs 0.5) en merk het verschil.
