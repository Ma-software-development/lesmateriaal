# Step By Step — UI Systeem: Canvas, Health Bar & Inventory
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een Canvas opzetten met de juiste Render Mode
- Je kunt een `TextMeshProUGUI` aanpassen via script
- Je kunt een health bar bouwen met `Image.fillAmount`
- Je kunt een inventory-grid bouwen met een simpele lijst

---

## Achtergrond: Canvas Render Modes

| Render Mode | Gebruik |
|---|---|
| **Screen Space — Overlay** | HUD die altijd bovenop alles staat (health bar, score) |
| **Screen Space — Camera** | HUD gekoppeld aan een camera (voor depth effects) |
| **World Space** | 3D UI in de wereld (tekst boven NPC, interactie-prompts) |

Voor een standaard HUD gebruik je altijd **Screen Space — Overlay**.

---

## Stap 1 — Canvas aanmaken

1. **GameObject > UI > Canvas**. Unity maakt automatisch ook een `EventSystem` aan — dit is nodig voor knoppen en input.
2. Selecteer het Canvas-object.
3. In de Inspector:
   - **Render Mode:** Screen Space – Overlay
4. Voeg een **Canvas Scaler** toe (staat er al standaard op):
   - **UI Scale Mode:** Scale With Screen Size
   - **Reference Resolution:** 1920 × 1080
   - **Screen Match Mode:** Match Width or Height (op 0.5)

> Met `Scale With Screen Size` past de UI zich automatisch aan op elk schermformaat.

---

## Stap 2 — Health Bar bouwen

### Achtergrond-image
1. Rechtermuisknop op Canvas → **UI > Image**. Noem het `HealthBarBG`.
2. In de Inspector (RectTransform):
   - **Anchor:** linksboven (klik het anchor-preset icoontje → linksoven)
   - **Pos X:** 20, **Pos Y:** -20
   - **Width:** 300, **Height:** 30
3. Stel de kleur in op donkergrijs.

### Voorgrond-image (de balk zelf)
4. Rechtermuisknop op `HealthBarBG` → **UI > Image**. Noem het `HealthBarFill`.
5. Maak het even groot als de achtergrond: Width = 300, Height = 30, Pos = 0, 0.
6. Stel de kleur in op groen.
7. Zet **Image Type** op **Filled** en **Fill Method** op **Horizontal**.
8. **Fill Amount** is nu een waarde van 0.0 tot 1.0 — dit ga je via script aanpassen.

---

## Stap 3 — HealthSystem-script schrijven

1. Maak `HealthSystem.cs` en koppel dit aan het karakter:

```csharp
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Image healthBarFill;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // Test: druk op H om 10 schade te nemen
        if (Input.GetKeyDown(KeyCode.H))
            TakeDamage(10);
    }

    public void TakeDamage(int amount)
    {
        currentHealth = Mathf.Max(0, currentHealth - amount);
        UpdateHealthBar();

        if (currentHealth == 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthBarFill == null) return;

        float ratio = (float)currentHealth / maxHealth;
        healthBarFill.fillAmount = ratio;

        // Kleur: groen → geel → rood
        if (ratio > 0.6f)
            healthBarFill.color = Color.green;
        else if (ratio > 0.3f)
            healthBarFill.color = Color.yellow;
        else
            healthBarFill.color = Color.red;
    }

    void Die()
    {
        Debug.Log("Speler is dood!");
        // Hier later: game-over scherm laden
    }
}
```

2. Sleep `HealthBarFill` naar het **Health Bar Fill**-veld in de Inspector.

---

## Stap 4 — Stamina Bar bouwen

Herhaal dezelfde stappen als de health bar, maar dan voor stamina:

1. Maak `StaminaBarBG` en `StaminaBarFill` onder het Canvas.
2. Positioneer ze onder de health bar (Pos Y = -60).
3. Kleur: blauw.
4. Voeg `fillAmount`-logica toe aan `StaminaUI.cs` (uit Les 4):

```csharp
[SerializeField] private Image staminaBarFill;

void Update()
{
    // ... bestaande sprint-logica ...
    staminaBarFill.fillAmount = currentStamina / maxStamina;
}
```

---

## Stap 5 — Item-teller: TextMeshPro

1. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**.
2. Noem het `WrenchCountText`.
3. Stel de **Anchor** in op rechtsbovenhoek.
4. Tekst: `Wrenches: 0`, Font Size: 24.
5. In `PickupSystem.cs` (Les 5):

```csharp
using TMPro;
[SerializeField] private TextMeshProUGUI wrenchCountText;

void UpdateUI()
{
    wrenchCountText.text = $"Wrenches: {pickupCount}";
}
```

---

## Stap 6 — "Press E to pick up" prompt

1. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `InteractPrompt`.
2. Tekst: `[E] Oprapen`. Centreer onderin het scherm (Anchor: bottom center).
3. Font Size: 22. Kleur: wit met zwarte outline (Font Asset → Material).
4. Zet het object initieel **inactief** (vink het vinkje weg naast de naam in Inspector).
5. In `PickupSystem.cs`: activeer het object als de Raycast een Pickup raakt:

```csharp
interactPrompt.SetActive(hitPickup);
```

---

## Stap 7 — Timer in de UI

1. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `TimerText`.
2. Positioneer bovenaan midden: Anchor = top center.
3. Maak `GameTimer.cs`:

```csharp
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float totalTime = 60f;
    private float timeLeft;
    private bool running = true;

    void Start()
    {
        timeLeft = totalTime;
    }

    void Update()
    {
        if (!running) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0, timeLeft);

        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (timeLeft <= 0f)
        {
            running = false;
            Debug.Log("Tijd is op!");
        }
    }
}
```

---

## Stap 8 — Inventory Grid bouwen

### Grid Layout Group aanmaken
1. Rechtermuisknop op Canvas → **UI > Panel**. Noem het `InventoryPanel`.
2. Positioneer rechtsonder in het scherm.
3. **Add Component > Layout > Grid Layout Group**:
   - **Cell Size:** 60 × 60
   - **Spacing:** 5 × 5
   - **Constraint:** Fixed Column Count = 4

### Slot-image als prefab
4. Rechtermuisknop op `InventoryPanel` → **UI > Image**. Noem het `InventorySlot`.
5. Geef het een donkere achtergrondkleur.
6. Voeg een **child Image** toe: noem het `ItemIcon`. Stel Alpha in op 0 (initieel leeg).
7. Maak `InventorySlot` een prefab: sleep naar Project view.
8. Verwijder de slot in de scene (het script maakt ze aan).

### Inventory-script
9. Maak `InventoryUI.cs` en koppel aan het Canvas:

```csharp
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform inventoryPanel;
    [SerializeField] private int maxSlots = 4;

    private List<Image> slots = new List<Image>();

    void Start()
    {
        // Maak alle slots aan
        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slot = Instantiate(slotPrefab, inventoryPanel);
            Image icon = slot.GetComponentInChildren<Image>();
            icon.enabled = false;
            slots.Add(icon);
        }
    }

    public void AddItem(Sprite icon)
    {
        foreach (Image slot in slots)
        {
            if (!slot.enabled)
            {
                slot.sprite = icon;
                slot.enabled = true;
                return;
            }
        }
        Debug.Log("Inventory is vol!");
    }
}
```

10. Koppel het slot-prefab en het panel aan de Inspector-velden.
11. Vanuit `PickupSystem.cs`: roep `AddItem(icon)` aan bij oppakken.

---

## Stap 9 — Canvas Scaler controleren

1. Selecteer het Canvas.
2. Controleer de **Canvas Scaler**-instellingen:
   - **UI Scale Mode:** Scale With Screen Size
   - **Reference Resolution:** 1920 × 1080
3. Test door de Game view-resolutie te wisselen (dropdown linksboven in de Game view).
4. Controleer of de UI mee schaalt.

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Health bar verandert niet | `fillAmount` niet aangesproken | Controleer `UpdateHealthBar()` wordt aangeroepen |
| UI schaalt niet op andere resoluties | Canvas Scaler niet ingesteld | Scale With Screen Size instellen |
| TextMeshPro package mist | Niet geïnstalleerd | Window > Package Manager > TextMeshPro |
| Inventory-slots niet zichtbaar | GridLayoutGroup zonder slots | Zorg dat Instantiate de juiste parent gebruikt |
| Timer telt niet af | `running = false` bij start | Controleer `running = true` in `Start()` |

---

## Controlelijst voor afronding

- [ ] Canvas aangemaakt met Screen Space – Overlay en Canvas Scaler
- [ ] Health bar met `fillAmount` en kleurverloop (groen → geel → rood)
- [ ] H-toets geeft schade (testfunctie)
- [ ] Stamina bar aanwezig en gekoppeld aan sprint-logica
- [ ] Wrench-teller bijgewerkt bij elke pickup
- [ ] `[E] Oprapen`-prompt verschijnt alleen bij Raycast-treffer
- [ ] Timer telt af van 60 seconden
- [ ] Inventory-grid met 4 slots
- [ ] Item-icoon verschijnt in slot bij oppakken
- [ ] UI schaalt correct op 1920×1080 én 1280×720
