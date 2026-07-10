# Step By Step — Inventory-systeem: Items Oprapen en Gebruiken

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt een `Item`-dataklasse maken die een item beschrijft
- Je kunt een inventory bouwen als lijst van items
- Je kunt items oprapen via een trigger in de scene
- Je kunt een item gebruiken en het effect toepassen op de speler

---

## Concept: hoe werkt het systeem?

```
[Item in de wereld]
      │  speler loopt erdoorheen (trigger)
      ▼
[Inventory]  ←→  lijst van Item-objecten
      │  speler drukt gebruik-knop
      ▼
[Effect]  bijv. health +20, snelheid +2
```

> **Verschil met Les 10:** Les 10 toont een inventory-grid in de UI. Deze les focust op de logica: oprapen, opslaan en gebruiken — de UI is hier minimaal.

---

## Stap 1 — Item dataklasse aanmaken

Een `Item` is een klasse die beschrijft wat een item is en doet. We gebruiken `[System.Serializable]` zodat items in de Inspector verschijnen.

1. Maak een nieuw script **`Item.cs`**. Dit is **geen** MonoBehaviour — het is puur data:

```csharp
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName = "Item";
    public Sprite icon;

    // Effectwaarden — velden die niet gebruikt worden blijven 0
    public int healthBonus   = 0;
    public float speedBonus  = 0f;
}
```

---

## Stap 2 — Inventory script

1. Maak een leeg GameObject → noem het `Player` (of voeg het toe aan jouw bestaande speler).
2. Maak **`Inventory.cs`** en koppel het aan de speler:

```csharp
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems = 5;

    // De lijst met items die de speler bij zich heeft
    private List<Item> items = new List<Item>();

    // Voeg een item toe aan de inventory
    public bool AddItem(Item item)
    {
        if (items.Count >= maxItems)
        {
            Debug.Log("Inventory is vol!");
            return false;
        }

        items.Add(item);
        Debug.Log($"{item.itemName} opgepakt. Inventory: {items.Count}/{maxItems}");
        return true;
    }

    // Gebruik het item op de gegeven index en verwijder het daarna
    public void UseItem(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            Debug.Log("Geen item op die plek.");
            return;
        }

        Item item = items[index];

        // Pas het effect toe op de speler
        PlayerStats stats = GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.health += item.healthBonus;
            stats.speed  += item.speedBonus;
            Debug.Log($"{item.itemName} gebruikt: +{item.healthBonus} health, +{item.speedBonus} snelheid.");
        }

        items.RemoveAt(index);
    }

    // Tijdelijk: druk 1 om het eerste item te gebruiken
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }
    }
}
```

---

## Stap 3 — PlayerStats script

Dit script houdt de statistieken van de speler bij zodat items er effect op kunnen hebben.

1. Maak **`PlayerStats.cs`** en koppel het aan de speler:

```csharp
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health   = 100;
    public float speed  = 5f;

    void Update()
    {
        // Begrens health op 0–100
        health = Mathf.Clamp(health, 0, 100);
    }
}
```

---

## Stap 4 — Item in de wereld plaatsen

Een `WorldItem` is het zichtbare object in de scene. Als de speler erop loopt, wordt het opgepakt.

1. Maak een **Sphere**-GameObject → noem het `HealthPotion`.
2. Maak **`WorldItem.cs`** en koppel het aan de sphere:

```csharp
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    [Header("Item dat opgepakt wordt")]
    public Item item;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null && inventory.AddItem(item))
        {
            // Item succesvol opgepakt — verwijder het uit de wereld
            Destroy(gameObject);
        }
    }
}
```

3. Voeg een **Sphere Collider** toe aan de sphere:
   - Zet **Is Trigger** aan.
4. Vul in de Inspector van `WorldItem` het **Item**-veld in:
   - **Item Name:** `Healthpotion`
   - **Health Bonus:** `20`
5. Zorg dat de speler de tag **Player** heeft.

---

## Stap 5 — Meerdere items maken

Maak twee extra world items:

| GameObject     | Item Name       | Health Bonus | Speed Bonus |
|----------------|-----------------|--------------|-------------|
| `HealthPotion` | Healthpotion    | 20           | 0           |
| `SpeedBoost`   | Snelheidsboost  | 0            | 2           |
| `MegaPotion`   | Megapotion      | 50           | 1           |

Geef elk een ander materiaal zodat ze visueel te onderscheiden zijn.

---

## Stap 6 — Testen

1. Klik op **Play**.
2. Loop over een item — controleer in de Console dat het opgepakt is.
3. Druk **1** om het eerste item te gebruiken.
4. Controleer in de Inspector (via de PlayerStats-component) dat `health` of `speed` is veranderd.
5. Probeer meer dan `maxItems` items op te pakken — het vijfde mag niet lukken.

---

## Overzicht van de scripts

| Script        | Verantwoordelijkheid                                        |
|---------------|-------------------------------------------------------------|
| `Item`        | Dataklasse: naam, icoon en effectwaarden                   |
| `Inventory`   | Lijst van items, oprapen en gebruiken                      |
| `PlayerStats` | Statistieken van de speler (health, snelheid)              |
| `WorldItem`   | Zichtbaar object in de wereld, triggert oprapen            |

---

## Uitbreidingsideeën

- **UI-grid (Les 10):** toon de inventory als icoontjes in een Canvas-grid.
- **Item types:** voeg een `ItemType`-enum toe (`Consumable`, `Weapon`, `KeyItem`) voor andere gebruik-logica per type.
- **Stapelen:** laat items met dezelfde naam stapelen (`stackCount`) i.p.v. aparte slots in te nemen.
