# Oefening: Collections & Loops

## Leerdoel

Arrays, Lists en for/foreach loops gebruiken om data te beheren.

---

## Oefening 1: Inventory Array

Maak een inventory met een array:

```csharp
public class Inventory : MonoBehaviour
{
    string[] items = new string[5];

    void Start()
    {
        items[0] = "Zwaard";
        items[1] = "Schild";
        items[2] = "Drankje";

        // TODO: Loop door de array met een for-loop
        // Print elk item (sla lege slots over met een if-check)
    }
}
```

**Verwacht:** "Zwaard", "Schild", "Drankje" in de console (geen lege regels).

---

## Oefening 2: Vijanden Lijst

Gebruik een `List<>` om vijanden dynamisch te beheren:

```csharp
using System.Collections.Generic;

public class EnemyTracker : MonoBehaviour
{
    List<string> enemies = new List<string>();

    void Start()
    {
        enemies.Add("Goblin");
        enemies.Add("Skeleton");
        enemies.Add("Dragon");

        Debug.Log("Vijanden: " + enemies.Count);

        // TODO: Verwijder "Skeleton" uit de lijst
        // TODO: Voeg "Orc" toe
        // TODO: Loop met foreach en print alle vijanden
        // TODO: Print het nieuwe aantal
    }
}
```

**Verwacht:** Lijst toont "Goblin", "Dragon", "Orc" met count = 3.
