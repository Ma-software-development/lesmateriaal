# Step By Step — Raycasts: Schieten & Kogels Oprapen

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt hoe `Physics.Raycast` werkt met `Ray`, `RaycastHit` en `LayerMask`
- Je kunt een raycast-gebaseerd schiet systeem bouwen waarbij een barrel direct explodeert
- Je kunt kogels oprapen via een raycast en de ammo-teller bijwerken in de UI

---

## Achtergrond: Wat is een Raycast?

Een Raycast is een onzichtbare lijn die vanuit een punt in een richting wordt geschoten. Als de lijn een Collider raakt, geeft Unity informatie terug via een `RaycastHit`.

```
[Camera] ———————————————————→ [Barrel]
              ← max 50 m →
```

| Parameter     | Betekenis                                                   |
| ------------- | ----------------------------------------------------------- |
| `Ray`         | Beginpunt + richting van de lijn                            |
| `RaycastHit`  | Resultaat: welk object, positie van botsing, normaalvector  |
| `maxDistance` | Hoe ver de ray reikt (in meters)                            |
| `LayerMask`   | Filter: welke lagen mag de ray raken?                       |

**Wanneer Raycast vs. Trigger Collider?**

| Raycast                                        | Trigger Collider                   |
| ---------------------------------------------- | ---------------------------------- |
| Actief per frame of op aanvraag                | Altijd actief                      |
| Richting-afhankelijk (je moet ernaar wijzen)   | Detecteert alles in de zone        |
| Goed voor: schieten, interactie, line-of-sight | Goed voor: gebieden, collectibles  |

---

## Stap 1 — Layers instellen

Met Layers kun je bepalen welke objecten een Raycast mag raken. Zo kan de speler zichzelf nooit per ongeluk raken.

1. Ga naar **Edit > Project Settings > Tags and Layers**.
2. Voeg onder **Layers** toe:
   - Layer 6: `Shootable`
   - Layer 7: `Player`
3. Selecteer je barrel/krat-prefab in de Hierarchy → rechtsboven in de Inspector: stel **Layer** in op `Shootable`.
4. Selecteer het spelerkarakter → stel **Layer** in op `Player`.

> **Waarom layers?** De `ShootSystem`-raycast heeft een `LayerMask` die alleen `Shootable` objecten raakt. De speler zit op een andere layer en wordt dus nooit geraakt door zijn eigen schoten.

---

## Stap 2 — Barrel-prefab instellen

De barrel heeft geen eigen script nodig. Hij heeft alleen een Collider en de juiste Layer zodat de raycast hem kan raken.

1. Open de barrel-prefab (dubbelklik in Project view).
2. Controleer of er een **Collider** op zit (bijv. Box Collider). Zo niet: **Add Component > Physics > Box Collider**.
3. Zet **Layer** op `Shootable`.
4. Sla de prefab op.

---

## Stap 3 — Explosie Particle System aanmaken

1. **GameObject > Effects > Particle System**. Noem het `ExplosionEffect`.
2. Pas de instellingen aan:
   - **Duration:** `1`
   - **Looping:** ❌ uitvinken
   - **Start Lifetime:** `0.8`
   - **Start Speed:** `8`
   - **Start Size:** `0.5`
   - **Start Color:** oranje/rood
   - **Max Particles:** `50`
   - **Play On Awake:** ✅
3. Sleep dit object naar de **Project** view om er een prefab van te maken.
4. Verwijder het uit de Hierarchy.
5. Sleep de prefab naar het **Explosion Effect**-veld van `ShootSystem` (koppelen in Stap 9).

---

## Stap 4 — Explosiegeluid toevoegen

1. Download een gratis explosiegeluid van [freesound.org](https://freesound.org) (zoek op "explosion").
2. Sleep het `.wav`- of `.mp3`-bestand naar de **Project** view.
3. Sleep het naar het **Explosion Sound**-veld van `ShootSystem` in de Inspector (koppelen in Stap 9).

> `AudioSource.PlayClipAtPoint` maakt tijdelijk een AudioSource aan op de juiste positie. Je hoeft zelf geen AudioSource-component toe te voegen aan de barrel of de speler.

---

## Stap 5 — ShootOrigin aanmaken

De ray moet vanuit de camera (of het wapen) worden geschoten in de kijkrichting.

1. Selecteer de **Main Camera** in de Hierarchy.
2. Maak een leeg child-object: **rechtermuisknop > Create Empty**. Noem het `ShootOrigin`.
3. Zet de positie op `0, 0, 0` (zodat hij precies op de camera-positie zit).
4. Controleer in de Scene view: de **blauwe pijl** (forward) wijst in de kijkrichting van de camera.

---

## Stap 6 — Shoot-actie toevoegen aan Input System

1. Open `InputSystem_Actions.inputactions` (dubbelklik).
2. Selecteer de `Player` Action Map.
3. Klik **+ (Add Action)**. Noem het `Shoot`.
4. Stel in: **Action Type: Button**.
5. Voeg Binding toe: **Mouse/Left Button**.
6. Klik **Save Asset**.

---

## Stap 7 — ShootSystem.cs aanmaken

1. Maak een nieuw script `ShootSystem` en koppel het aan de **speler** of het **camera-object**.
2. Schrijf de volgende code:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootSystem : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionAsset inputAsset;
    private InputAction shootAction;

    [Header("Raycast")]
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float shootDistance = 50f;
    [SerializeField] private LayerMask shootableLayers;

    [Header("Visueel")]
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float lineDuration = 0.1f;

    void Awake()
    {
        shootAction = inputAsset.FindActionMap("Player").FindAction("Shoot");
    }

    void OnEnable()  { inputAsset.FindActionMap("Player").Enable(); }
    void OnDisable() { inputAsset.FindActionMap("Player").Disable(); }

    void Update()
    {
        // Teken de ray in de Scene view (rood)
        Debug.DrawRay(shootOrigin.position, shootOrigin.forward * shootDistance, Color.red);

        if (shootAction.WasPressedThisFrame())
            Shoot();
    }

    void Shoot()
    {
        Ray ray = new Ray(shootOrigin.position, shootOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, shootDistance, shootableLayers))
        {
            Debug.Log($"Geraakt: {hit.collider.name}");

            // Explosie spawnen op de positie van het geraakt object
            if (explosionEffect != null)
            {
                ParticleSystem effect = Instantiate(explosionEffect, hit.collider.transform.position, Quaternion.identity);
                Destroy(effect.gameObject, effect.main.duration);
            }

            if (explosionSound != null)
                AudioSource.PlayClipAtPoint(explosionSound, hit.collider.transform.position);

            Destroy(hit.collider.gameObject);
            ShowLine(shootOrigin.position, hit.point);
        }
        else
        {
            // Geen treffer: lijn naar maximale afstand
            ShowLine(shootOrigin.position, shootOrigin.position + shootOrigin.forward * shootDistance);
        }
    }

    void ShowLine(Vector3 start, Vector3 end)
    {
        if (lineRenderer == null) return;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;
        StartCoroutine(HideLine());
    }

    System.Collections.IEnumerator HideLine()
    {
        yield return new WaitForSeconds(lineDuration);
        lineRenderer.enabled = false;
    }
}
```

3. Sla op.

---

## Stap 8 — LineRenderer instellen

1. Selecteer het object waarop `ShootSystem` zit.
2. **Add Component > Effects > Line Renderer**.
3. Stel in:
   - **Positions:** Size = `2`
   - **Width:** `0.05`
   - **Color (beide einden):** rood
   - **Use World Space:** ✅
   - **Enabled:** ❌ (het script zet hem aan bij een schot)
4. Sleep de `LineRenderer`-component naar het **Line Renderer**-veld in de Inspector van `ShootSystem`.

---

## Stap 9 — ShootSystem koppelen in de Inspector

1. Selecteer het object met `ShootSystem`.
2. Vul de Inspector-velden in:
   - **Input Asset:** sleep `InputSystem_Actions.inputactions` hierheen
   - **Shoot Origin:** sleep `ShootOrigin` hierheen
   - **Shoot Distance:** `50`
   - **Shootable Layers:** vink alleen `Shootable` aan
   - **Explosion Effect:** sleep het `ExplosionEffect`-prefab hierheen
   - **Explosion Sound:** sleep de audioclip hierheen
   - **Line Duration:** `0.1`

---

## Stap 10 — Schieten testen

1. Zet 3–5 barrels in je scene op de `Shootable` layer.
2. Druk op **Play**.
3. Open ook de **Scene view** naast de Game view.
4. Controleer:
   - Is de rode `Debug.DrawRay`-lijn zichtbaar in de Scene view?
   - Explodeert de barrel direct bij een treffer?
   - Verdwijnt de barrel na de explosie?
   - Is de LineRenderer kort zichtbaar als je schiet?

> **Tip:** als de barrel niet geraakt wordt, controleer dan of de Layer op `Shootable` staat én of `Shootable` is aangevinkt in de LayerMask van het script.

---

## Stap 11 — Kogel-prefab aanmaken

De kogels zijn pickups die de speler kan oprapen.

1. **GameObject > 3D Object > Capsule**. Noem het `Bullet`.
2. Schaal het klein: **Scale** `0.1, 0.3, 0.1`.
3. Geef het een goudkleurig materiaal.
4. Voeg een **Collider** toe als die er nog niet is (de Capsule heeft er standaard een).
5. Tag instellen:
   - Klik bovenaan de Inspector op **Tag > Add Tag...**
   - Klik **+** en voeg `Pickup` toe.
   - Selecteer de Bullet opnieuw en stel **Tag** in op `Pickup`.
6. Sleep de `Bullet` naar de **Project** view om er een prefab van te maken.
7. Verwijder het origineel uit de Hierarchy.

---

## Stap 12 — Interact-actie toevoegen aan Input System

1. Open `InputSystem_Actions.inputactions`.
2. Selecteer de `Player` Action Map.
3. Klik **+ (Add Action)**. Noem het `Interact`.
4. Stel in: **Action Type: Button**.
5. Voeg Binding toe: **Keyboard/E**.
6. Klik **Save Asset**.

---

## Stap 13 — RayOrigin aanmaken

1. Selecteer het spelerkarakter in de Hierarchy.
2. Maak een leeg child-object: **rechtermuisknop > Create Empty**. Noem het `RayOrigin`.
3. Positioneer `RayOrigin` op hoofdhoogte: **Position Y = 1.6**.
4. Zorg dat de **blauwe pijl** (forward) naar voren wijst.

---

## Stap 14 — UI aanmaken

### Ammo-teller

1. **GameObject > UI > Canvas** (als er nog geen Canvas is).
2. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `AmmoCountText`.
3. Stel de tekst in op `Kogels: 0`.
4. Positioneer rechtsonder in het scherm (Anchor: bottom-right).

### Interactie-prompt

5. Rechtermuisknop op Canvas → **UI > Text - TextMeshPro**. Noem het `InteractPrompt`.
6. Stel de tekst in op `[E] Oprapen`.
7. Centreer het onderin het scherm.
8. Zet het **initieel inactief**: vink het vinkje naast de naam in de Inspector uit.

---

## Stap 15 — Pickup Particle System aanmaken

1. **GameObject > Effects > Particle System**. Noem het `PickupEffect`.
2. Pas de instellingen aan:
   - **Duration:** `0.5`
   - **Looping:** ❌
   - **Start Lifetime:** `0.5`
   - **Start Speed:** `3`
   - **Start Size:** `0.15`
   - **Start Color:** goud/geel
   - **Max Particles:** `20`
   - **Play On Awake:** ❌ (script roept `Play()` aan)
3. Sleep naar de **Project** view → prefab maken.

---

## Stap 16 — PickupSystem.cs aanmaken

1. Maak een nieuw script `PickupSystem` en koppel het aan de **speler**.
2. Schrijf de volgende code:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PickupSystem : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float interactDistance = 3f;

    [Header("Input")]
    [SerializeField] private InputActionAsset inputAsset;
    private InputAction interactAction;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI ammoCountText;
    [SerializeField] private GameObject interactPrompt;
    private int ammoCount = 0;

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
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        // Teken de ray in de Scene view (geel)
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * interactDistance, Color.yellow);

        bool hitPickup = Physics.Raycast(ray, out hit, interactDistance)
                         && hit.collider.CompareTag("Pickup");

        // Toon of verberg de interactie-prompt
        if (interactPrompt != null)
            interactPrompt.SetActive(hitPickup);

        // Oprapen bij E-toets
        if (hitPickup && interactAction.WasPressedThisFrame())
            PickupItem(hit.collider.gameObject);
    }

    void PickupItem(GameObject item)
    {
        if (pickupEffect != null)
        {
            pickupEffect.transform.position = item.transform.position;
            pickupEffect.Play();
        }

        if (audioSource != null && pickupSound != null)
            audioSource.PlayOneShot(pickupSound);

        Destroy(item);
        ammoCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (ammoCountText != null)
            ammoCountText.text = $"Kogels: {ammoCount}";
    }
}
```

3. Sla op.

---

## Stap 17 — PickupSystem koppelen in de Inspector

1. Selecteer de speler. Vul de Inspector-velden van `PickupSystem` in:
   - **Ray Origin:** sleep `RayOrigin` hierheen
   - **Interact Distance:** `3`
   - **Input Asset:** sleep `InputSystem_Actions.inputactions` hierheen
   - **Ammo Count Text:** sleep `AmmoCountText` hierheen
   - **Interact Prompt:** sleep `InteractPrompt` hierheen
   - **Pickup Effect:** sleep het `PickupEffect`-prefab hierheen
2. **Add Component > Audio > Audio Source** op de speler (als die er nog niet is):
   - **Play On Awake:** ❌
3. Sleep de `AudioSource`-component naar **Audio Source** in het script.
4. Voeg een pickupgeluid toe aan **Pickup Sound** (bijv. van [freesound.org](https://freesound.org)).

---

## Stap 18 — Kogels in de scene plaatsen

1. Sleep het `Bullet`-prefab 5× vanuit de Project view naar de scene op verschillende posities.
2. Zorg dat ze te bereiken zijn maar niet direct voor de barrel staan (anders schiet je ze weg).

---

## Stap 19 — Alles testen

1. Druk op **Play**.
2. Open de **Scene view** naast de Game view.
3. Controleer het schiet-systeem:
   - Rode `Debug.DrawRay`-lijn zichtbaar in de Scene view?
   - Barrel explodeert direct bij een treffer?
   - Barrel verdwijnt na de explosie?
   - LineRenderer kort zichtbaar?
4. Controleer het pickup-systeem:
   - Gele `Debug.DrawRay`-lijn zichtbaar in de Scene view?
   - Verschijnt `[E] Oprapen` als je naar een kogel kijkt?
   - Verdwijnt de prompt als je wegkijkt?
   - Verdwijnt de kogel en speelt het effect bij E-toets?
   - Wordt de ammo-teller bijgewerkt?

---

## Veelgemaakte fouten & oplossingen

| Probleem                       | Oorzaak                                  | Oplossing                                           |
| ------------------------------ | ---------------------------------------- | --------------------------------------------------- |
| Barrel wordt niet geraakt      | Layer staat niet op `Shootable`          | Controleer de Layer in de Inspector van de barrel   |
| Barrel raakt zichzelf          | `Player`-layer niet ingesteld            | Stel Layer `Player` in op het spelerkarakter        |
| Schiet door alles heen         | `Shootable Layers` niet geconfigureerd   | Vink `Shootable` aan in de LayerMask van het script |
| E-toets werkt niet             | `Interact`-actie niet enabled            | Controleer `OnEnable()` → `inputAsset.Enable()`     |
| Prompt altijd zichtbaar        | Raycast raakt altijd iets                | Controleer de `Pickup`-tag op de kogel              |
| Kogel wordt niet herkend       | Tag `Pickup` ontbreekt                   | Voeg de tag toe via Tags and Layers + stel in       |
| Particle speelt niet           | `Play On Awake` staat aan                | Zet `Play On Awake` ❌ uit                           |
| `NullReferenceException` op UI | UI-object niet gekoppeld in de Inspector | Sleep het object naar het juiste veld               |
| Lijn is altijd zichtbaar       | `LineRenderer` niet op disabled gezet   | Zet `Enabled` ❌ in de Inspector                    |

---

## Controlelijst voor afronding

- [ ] Layer `Shootable` aangemaakt en ingesteld op barrels
- [ ] Layer `Player` aangemaakt en ingesteld op speler
- [ ] Explosie Particle System als prefab aangemaakt
- [ ] Explosiegeluid audioclip gedownload
- [ ] `Shoot`-actie toegevoegd aan InputActionAsset (linkermuisknop)
- [ ] `ShootOrigin` GameObject aangemaakt op de camera
- [ ] `ShootSystem.cs` aangemaakt, gekoppeld en correct ingesteld
- [ ] `Explosion Effect` en `Explosion Sound` gekoppeld aan `ShootSystem`
- [ ] `LineRenderer` component ingesteld en initieel uitgeschakeld
- [ ] Minstens 5 barrels in de scene op layer `Shootable`
- [ ] Tag `Pickup` aangemaakt en ingesteld op kogel-prefab
- [ ] `Interact`-actie toegevoegd aan InputActionAsset (E-toets)
- [ ] `RayOrigin` GameObject aangemaakt op hoofdhoogte
- [ ] `PickupSystem.cs` aangemaakt, gekoppeld en correct ingesteld
- [ ] UI aangemaakt: ammo-teller en interactie-prompt
- [ ] Interactie-prompt initieel inactief
- [ ] Minstens 5 kogel-prefabs in de scene geplaatst
- [ ] `Debug.DrawRay` zichtbaar voor zowel schiet- als pickup-ray
- [ ] Alles getest in Play mode
