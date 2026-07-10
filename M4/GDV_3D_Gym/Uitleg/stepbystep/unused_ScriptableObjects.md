# Step By Step — ScriptableObjects: Data-gedreven Design
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je begrijpt waarom ScriptableObjects handig zijn voor game data
- Je kunt een ScriptableObject aanmaken voor item-definities
- Je kunt een ScriptableObject gebruiken als data-bron in andere scripts

---

## Achtergrond: Waarom ScriptableObjects?

**Zonder ScriptableObject (hardcoded):**
```csharp
// In elke pickup apart:
string itemName = "Wrench";
int pointValue = 10;
AudioClip sound = ...; // Je moet overal dezelfde waarden handmatig instellen
```

**Met ScriptableObject (data-driven):**
```csharp
// In één centraal data-bestand:
ItemData wrenchData; // bevat naam, waarde, geluid — op één plek aanpasbaar
```

**Voordelen:**
- Data aanpassen zonder code te wijzigen
- Eenvoudig nieuwe items toevoegen via de Unity Editor
- Één definitie, overal herbruikbaar
- Designers kunnen werken zonder code te kennen

---

## Stap 1 — ItemData ScriptableObject aanmaken

1. Maak een nieuw script: `ItemData.cs`.
2. Vervang de inhoud volledig:

```csharp
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Game/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Identificatie")]
    public string itemName = "Nieuw Item";
    public Sprite itemIcon;

    [Header("Gameplay")]
    public int pointValue = 10;

    [Header("Effecten")]
    public AudioClip pickupSound;
    public ParticleSystem pickupEffect; // prefab referentie
}
```

3. Sla op.

---

## Stap 2 — ItemData asset aanmaken voor de wrench

1. Ga in de Project view naar een logische map, bijv. `Assets/Data/`.
2. **Rechtermuisknop > Game > Item Data**.
3. Noem het bestand `Wrench_Data`.
4. Selecteer het. In de Inspector stel je in:
   - **Item Name:** `Moersleutel`
   - **Item Icon:** sleep het wrench-icoontje (of een sprite) hierheen
   - **Point Value:** `10`
   - **Pickup Sound:** sleep een `.wav`-geluid hierheen
5. Maak ook `Helmet_Data`, `Gloves_Data` aan voor andere items.

---

## Stap 3 — PickupSystem aanpassen om ItemData te gebruiken

Vervang de hardcoded waarden in `PickupSystem.cs` door verwijzingen naar de SO:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PickupItem : MonoBehaviour
{
    // Koppel dit aan het Pickup-object zelf, niet de speler
    [SerializeField] private ItemData itemData;

    public ItemData GetData() => itemData;
}
```

```csharp
// In PickupSystem.cs, vervang PickupItem() methode:
void PickupItem(GameObject item)
{
    PickupItem pickupComponent = item.GetComponent<PickupItem>();
    if (pickupComponent == null) return;

    ItemData data = pickupComponent.GetData();

    // Geluid uit ScriptableObject
    if (audioSource != null && data.pickupSound != null)
        audioSource.PlayOneShot(data.pickupSound);

    // Particle uit ScriptableObject (instantiate effect prefab)
    if (data.pickupEffect != null)
    {
        var effect = Instantiate(data.pickupEffect, item.transform.position, Quaternion.identity);
        effect.Play();
        Destroy(effect.gameObject, effect.main.duration);
    }

    // Score ophogen met item-specifieke waarde
    score += data.pointValue;

    // UI updaten
    pickupCountText.text = $"{data.itemName}: {score} punten";

    Destroy(item);
}
```

---

## Stap 4 — ItemData koppelen aan pickup-objecten

1. Selecteer de wrench in de Hierarchy (of open de prefab).
2. **Add Component > PickupItem** (het kleine script met de SO-referentie).
3. Sleep `Wrench_Data` naar het **Item Data**-veld.
4. Doe hetzelfde voor eventuele andere pickup-objecten met hun eigen SO.

---

## Stap 5 — PlayerStatsSO aanmaken

1. Maak `PlayerStatsSO.cs`:

```csharp
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Game/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    [Header("Beweging")]
    public float moveSpeed = 5f;
    public float sprintMultiplier = 2f;
    public float rotationSpeed = 100f;

    [Header("Springen")]
    public float jumpHeight = 2f;
    public float gravity = -20f;

    [Header("Gezondheid")]
    public int maxHealth = 100;
}
```

2. Maak een asset aan: **rechtermuisknop > Game > Player Stats**. Noem het `Player_Default_Stats`.
3. Stel de waarden in via de Inspector.

---

## Stap 6 — MoveCharacterController aanpassen voor PlayerStatsSO

1. Open `MoveCharacterController.cs`.
2. Vervang de losse `[SerializeField]`-velden door een verwijzing naar het SO:

```csharp
[SerializeField] private PlayerStatsSO stats;

// Gebruik vervolgens stats.moveSpeed, stats.jumpHeight, etc.
// Voorbeeld:
Vector3 move = transform.forward * movementInput.y * stats.moveSpeed * Time.deltaTime;
verticalVelocity = Mathf.Sqrt(2f * Mathf.Abs(stats.gravity) * stats.jumpHeight);
```

3. Sleep `Player_Default_Stats` naar het **Stats**-veld in de Inspector.

---

## Stap 7 — LootTable ScriptableObject (bonus / huiswerk)

```csharp
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LootTable", menuName = "Game/Loot Table")]
public class LootTable : ScriptableObject
{
    [System.Serializable]
    public class LootEntry
    {
        public ItemData item;
        [Range(0f, 1f)] public float weight = 0.5f;
    }

    public List<LootEntry> entries;

    public ItemData GetRandomItem()
    {
        float totalWeight = 0f;
        foreach (var entry in entries)
            totalWeight += entry.weight;

        float roll = Random.value * totalWeight;
        float cumulative = 0f;

        foreach (var entry in entries)
        {
            cumulative += entry.weight;
            if (roll <= cumulative)
                return entry.item;
        }

        return entries[entries.Count - 1].item;
    }
}
```

1. Maak een `LootTable`-asset aan.
2. Voeg in de Inspector de items toe met hun gewichten:
   - Wrench: weight = 0.6 (60% kans)
   - Helmet: weight = 0.3 (30% kans)
   - Gloves: weight = 0.1 (10% kans)
3. Gebruik in een barrel-script:

```csharp
[SerializeField] private LootTable lootTable;

void Die()
{
    ItemData loot = lootTable.GetRandomItem();
    // Spawn een pickup-object op de positie van de barrel
    Debug.Log($"Loot: {loot.itemName}");
}
```

---

## Stap 8 — Nieuw item toevoegen zonder code

Dit is het bewijs dat ScriptableObjects werken:

1. **Rechtermuisknop > Game > Item Data**. Noem het `Hammer_Data`.
2. Vul naam, icoon, geluid en waarde in.
3. Voeg een nieuw pickup-object toe in de scene.
4. Koppel `Hammer_Data` aan de `PickupItem`-component.
5. Test: het item werkt direct — geen regel code gewijzigd.

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| `[CreateAssetMenu]` verschijnt niet | Script heeft fouten | Fix alle compile-fouten eerst |
| SO-asset is leeg na aanmaken | Velden niet ingevuld | Selecteer het asset en vul de Inspector in |
| `NullReferenceException` op SO | SO niet aan Inspector-veld gekoppeld | Sleep het asset naar het veld |
| Hardcoded waarden nog actief | Script verwijst nog naar losse velden | Vervang alle directe waarden door `stats.veldNaam` |

---

## Controlelijst voor afronding

- [ ] `ItemData.cs` ScriptableObject aangemaakt met `[CreateAssetMenu]`
- [ ] `Wrench_Data`-asset aangemaakt en gevuld
- [ ] Minimaal 2 extra item-SOs aangemaakt (bijv. helm, handschoenen)
- [ ] `PickupItem.cs` koppelt SO aan pickup-object
- [ ] `PickupSystem.cs` leest naam, geluid en waarde uit SO
- [ ] Nieuw item toevoegen werkt zonder code te wijzigen
- [ ] `PlayerStatsSO.cs` aangemaakt met bewegings- en sprongwaarden
- [ ] `MoveCharacterController.cs` gebruikt SO in plaats van losse SerializeFields
- [ ] `LootTable.cs` aangemaakt met weighted random (bonus)
