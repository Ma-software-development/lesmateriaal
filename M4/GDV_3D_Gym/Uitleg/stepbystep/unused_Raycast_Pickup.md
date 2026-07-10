# Step By Step — Raycast: Items Oppakken & Interactie
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je begrijpt hoe een `Raycast` werkt (richting, afstand, `RaycastHit`)
- Je kunt een item detecteren met Raycast en oppakken
- Je kunt een UI-element updaten als reactie op een game-event
- Je kunt een `ParticleSystem` en `AudioSource` activeren via script

---

## Achtergrond: Wat is een Raycast?

Een Raycast is een onzichtbare lijn die vanuit een punt in een richting wordt geschoten. Als de lijn een object raakt, geeft Unity informatie terug via een `RaycastHit`:
- Welk object er geraakt is
- Op welke positie de botsing plaatsvond
- De normale van het oppervlak

```
[Speler] ——————————————————→ [Wrench]
          ← max 3 meter →
```

**Wanneer Raycast vs. Trigger Collider?**
| Raycast | Trigger Collider |
|---|---|
| Actief per frame of op aanvraag | Altijd actief |
| Richting-afhankelijk (je moet er naar kijken) | Detecteert alles in de zone |
| Goed voor: schieten, interactie, line-of-sight | Goed voor: gebieden, verzamelzones |

---

## Stap 1 — Wrench instellen als Pickup-object

1. Sleep de `double_open_end_wrench.prefab` uit de Project view naar de scene.
2. Selecteer de wrench in de Hierarchy.
3. Voeg een **Collider** toe als die er nog niet is: **Add Component > Physics > Box Collider**. Pas de grootte aan zodat hij het model netjes omhult (gebruik de **Edit Collider**-knop).
4. Voeg een Tag toe:
   - Klik bovenaan de Inspector op **Tag > Add Tag…**
   - Klik **+** en voeg `Pickup` toe.
   - Selecteer de wrench opnieuw en stel **Tag** in op `Pickup`.

---

## Stap 2 — Interactie-actie toevoegen aan Input

1. Open `PlayerInput.inputactions` (dubbelklik).
2. Selecteer de `Player` Action Map.
3. Klik **+ (Add Action)**. Noem het `Interact`.
4. Stel in: **Action Type: Button**.
5. Voeg Binding toe: **Keyboard/E**.
6. Klik **Save Asset**.

---

## Stap 3 — Pickup-script schrijven: PickupSystem.cs

1. Maak een nieuw script `PickupSystem.cs` en koppel het aan de **speler**.
2. Schrijf de volgende code:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PickupSystem : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Transform rayOrigin; // bijv. de Camera of hoofd-positie

    [Header("Input")]
    [SerializeField] private InputActionAsset inputAsset;
    private InputAction interactAction;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI pickupCountText;
    [SerializeField] private GameObject interactPrompt; // "Druk E om op te pakken"
    private int pickupCount = 0;

    [Header("Effects")]
    [SerializeField] private ParticleSystem pickupEffect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupSound;

    void Awake()
    {
        interactAction = inputAsset.FindActionMap("Player").FindAction("Interact");
    }

    void OnEnable()  { inputAsset.FindActionMap("Player").Enable(); }
    void OnDisable() { inputAsset.FindActionMap("Player").Disable(); }

    void Update()
    {
        CheckForPickup();
    }

    void CheckForPickup()
    {
        // Schiet een ray vanuit de speler naar voren
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        // Teken de ray in de Scene view (zichtbaar via Gizmos)
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * interactDistance, Color.yellow);

        bool hitPickup = Physics.Raycast(ray, out hit, interactDistance)
                         && hit.collider.CompareTag("Pickup");

        // Toon/verberg de interactie-prompt
        if (interactPrompt != null)
            interactPrompt.SetActive(hitPickup);

        // Oppakken als E wordt ingedrukt en we een pickup raken
        if (hitPickup && interactAction.WasPressedThisFrame())
        {
            PickupItem(hit.collider.gameObject);
        }
    }

    void PickupItem(GameObject item)
    {
        // Particle effect op de positie van het item
        if (pickupEffect != null)
        {
            pickupEffect.transform.position = item.transform.position;
            pickupEffect.Play();
        }

        // Geluid afspelen
        if (audioSource != null && pickupSound != null)
            audioSource.PlayOneShot(pickupSound);

        // Item verwijderen uit de scene
        Destroy(item);

        // Teller ophogen
        pickupCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (pickupCountText != null)
            pickupCountText.text = $"Wrenches: {pickupCount}";
    }
}
```

3. Sla op.

---

## Stap 4 — Ray origin instellen

De ray moet vanuit de ogen/hoofd van de speler worden geschoten.

1. Selecteer het karakter in de Hierarchy.
2. Maak een leeg GameObject als kind: **rechtermuisknop > Create Empty**. Noem het `RayOrigin`.
3. Positioneer `RayOrigin` op hoofdhoogte: Position Y = 1.6 (of ter hoogte van de ogen).
4. Sleep `RayOrigin` naar het **Ray Origin**-veld in de Inspector van `PickupSystem`.

---

## Stap 5 — UI aanmaken

### Pickup-teller
1. **GameObject > UI > Canvas** (als er nog geen Canvas is).
2. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `PickupCountText`.
3. Stel de tekst in op `Wrenches: 0`. Zet het in de rechterbovenhoek (Anchor: top-right).
4. Sleep het naar het **Pickup Count Text**-veld in de Inspector van het script.

### Interactie-prompt
5. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `InteractPrompt`.
6. Stel de tekst in op `[E] Oprapen`. Centreer het onderin het scherm.
7. Zet het **initieel inactief**: vink het vinkje naast de naam in de Inspector uit.
8. Sleep het naar **Interact Prompt** in de Inspector van het script.

---

## Stap 6 — Particle System aanmaken

1. **GameObject > Effects > Particle System**. Noem het `PickupEffect`.
2. Selecteer het. In de Inspector, pas de instellingen aan:
   - **Duration:** 0.5
   - **Looping:** ❌ uitvinken
   - **Start Lifetime:** 0.5
   - **Start Speed:** 3
   - **Start Size:** 0.2
   - **Start Color:** geel/goud (passend bij een wrench)
   - **Max Particles:** 30
3. Zet **Play On Awake** uit (het script roept `Play()` aan op het juiste moment).
4. Sleep `PickupEffect` naar het **Pickup Effect**-veld in het script.

---

## Stap 7 — AudioSource instellen

1. Selecteer het karakter. **Add Component > Audio > Audio Source**.
2. Stel in:
   - **Play On Awake:** ❌ uitvinken
   - **Spatial Blend:** 0 (2D geluid, want het is een UI-achtig effect)
3. Voeg een geluidje toe: sleep een `.wav` of `.mp3` audioclip naar het **Pickup Sound**-veld in het script. (Gebruik een gratis geluid van [freesound.org](https://freesound.org))
4. Sleep de `AudioSource` component naar het **Audio Source**-veld.

---

## Stap 8 — Testen

1. Druk op **Play**.
2. Loop richting de wrench.
3. Controleer:
   - Verschijnt de `[E] Oprapen`-prompt als je dichtbij genoeg bent?
   - Verdwijnt hij als je wegloopt?
   - Druk op E: verdwijnt de wrench? Speelt het effect en geluid?
   - Wordt de teller bijgewerkt?

### Debuggen met de Scene view
- Open de **Scene** view naast de **Game** view.
- Controleer de gele debug-ray in de Scene view: schiet hij in de juiste richting?

---

## Stap 9 — Meerdere wrenches plaatsen

1. Selecteer de bestaande wrench in de Hierarchy.
2. Maak hem een prefab: sleep hem naar de **Project** view → klik **Original Prefab** of **Prefab Variant**.
3. Verwijder de wrench uit de Hierarchy.
4. Sleep het prefab 5× vanuit de Project view naar de scene, op verschillende posities.

---

## Stap 10 — Collectibles-systeem uitbreiden (Huiswerk preview)

Voeg toe aan `PickupSystem.cs`:

```csharp
[SerializeField] private int totalPickups = 5;
[SerializeField] private TextMeshProUGUI completedText;

void UpdateUI()
{
    pickupCountText.text = $"Wrenches: {pickupCount}/{totalPickups}";

    if (pickupCount >= totalPickups)
    {
        completedText.gameObject.SetActive(true);
        audioSource.PlayOneShot(pickupSound); // victory sound
    }
}
```

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Ray raakt niets | Origin verkeerd gepositioneerd | Controleer Debug.DrawRay in Scene view |
| E-toets werkt niet | Interact action niet enabled | Controleer OnEnable() → Enable() |
| Prompt altijd zichtbaar | Raycast raakt altijd iets | Controleer de tag op de wrench |
| Particle speelt niet | Play On Awake staat aan, effect al voorbij | Zet Play On Awake ❌ uit |
| NullReference op text | UI-object niet gekoppeld | Sleep het object naar het juiste veld in Inspector |
| Oppakken werkt op afstand | interactDistance te groot | Verklein de waarde (bijv. 2.5) |

---

## Controlelijst voor afronding

- [ ] Wrench heeft tag `Pickup` en een Collider
- [ ] `Interact`-actie aangemaakt in InputActionAsset met E-binding
- [ ] `PickupSystem.cs` script aangemaakt en gekoppeld aan speler
- [ ] `RayOrigin` GameObject op hoofdhoogte aangemaakt
- [ ] Debug.DrawRay zichtbaar in Scene view (gele lijn)
- [ ] Interactie-prompt verschijnt/verdwijnt correct
- [ ] E-toets verwijdert de wrench
- [ ] Pickup-teller wordt bijgewerkt in de UI
- [ ] Particle effect speelt op de positie van het item
- [ ] Audioclip speelt bij oppakken
- [ ] Minimaal 5 wrenches als prefab in de scene geplaatst
