# Oefening 20 — Data Structures: Struct, Enum & ScriptableObjects

**Onderwerp:** Wanneer gebruik je class, struct, enum of ScriptableObject?  
**Module:** M6

---

## Oefening 20a — Enum en Struct

Maak een inventarissysteem dat `enum` en `struct` gebruikt.

```csharp
using UnityEngine;

// Enum voor item-types
public enum ItemType
{
    Weapon,
    Potion,
    Armor,
    Key
}

// Struct voor item-data (lightweight, value type)
public struct ItemData
{
    public string name;
    public ItemType type;
    public int value;

    public ItemData(string name, ItemType type, int value)
    {
        this.name = name;
        this.type = type;
        this.value = value;
    }

    public override string ToString()
    {
        return $"{name} ({type}) - waarde: {value}";
    }
}
```

**Opdracht:**

1. Maak een script `Inventory` met een `List<ItemData>`.
2. Voeg in `Start()` minstens 4 items toe van verschillende types.
3. Maak een methode `PrintItemsByType(ItemType type)` die alleen items van dat type toont.
4. **Bonus:** Maak een methode `GetMostValuable()` die het item met de hoogste waarde retourneert.

---

## Oefening 20b — ScriptableObject als data-container

Gebruik een `ScriptableObject` om wapen-data los van de code op te slaan.

```csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float fireRate;
    public Sprite icon;
}
```

**Opdracht:**

1. Maak het `WeaponData` ScriptableObject-script aan.
2. Maak via **Create > Game > Weapon Data** in de Project-map minstens 3 wapens aan met verschillende waarden.
3. Maak een `WeaponUser`-script dat een `WeaponData`-referentie heeft:

   ```csharp
   public class WeaponUser : MonoBehaviour
   {
       [SerializeField] private WeaponData equippedWeapon;

       void Start()
       {
           Debug.Log($"Wapen: {equippedWeapon.weaponName}, Damage: {equippedWeapon.damage}");
       }
   }
   ```

4. Wijs verschillende wapens toe via de Inspector en test.
5. **Bonus:** Maak een `List<WeaponData>` (arsenaal) en wissel van wapen met een toets.
