# Oefening: If-statements & Logica

## Leerdoel

Beslissingsstructuren schrijven met if, else, else if en logische operators.

---

## Oefening 1: Gezondheidsstatus

Maak een script dat een status print op basis van health:

```csharp
public class HealthStatus : MonoBehaviour
{
    public int health = 75;

    void Start()
    {
        // TODO: Schrijf if/else if/else die print:
        // health > 75  -> "Gezond"
        // health > 25  -> "Gewond"
        // health > 0   -> "Kritiek"
        // health <= 0  -> "Dood"
    }
}
```

**Test:** Pas `health` aan in de Inspector en controleer of de juiste status verschijnt.

---

## Oefening 2: Toegangscontrole

Maak een script dat checkt of een speler een deur mag openen:

```csharp
public class DoorCheck : MonoBehaviour
{
    public bool hasKey = false;
    public int playerLevel = 3;
    public int requiredLevel = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // TODO: Check of speler key heeft EN level hoog genoeg is
            // Print "Deur gaat open!" of "Je hebt een sleutel nodig!"
            // of "Je level is te laag!" (gebruik && en ||)
        }
    }
}
```

**Test:** Speel met de combinaties van `hasKey` en `playerLevel` om alle paden te testen.
