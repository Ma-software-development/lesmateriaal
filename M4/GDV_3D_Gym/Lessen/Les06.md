# M4 GDV HNR LES 6: Raycasts — Schieten & Exploderen

Deze les leren jullie het volgende:

- Je begrijpt hoe `Physics.Raycast` werkt met `Ray`, `RaycastHit` en `LayerMask`
- Je kunt een raycast-gebaseerd schiet systeem bouwen waarbij een barrel direct explodeert
- Je kunt een debugging lijn tekenen in de scene met `Debug.DrawRay`
- Je kunt een mooi vormgegeven lijn tekenen met de `LineRenderer`

In deze les laat ik zien hoe je Raycasts gebruikt voor schieten. Je kunt direct meedoen of kijken en aantekeningen maken.

De uitgebreide stap-voor-stap instructie staat hier: [Les06_StepByStep.md](../Uitleg/stepbystep/Raycast_Schieten_Pickup.md)

---

## Hoe werkt een Raycast?

Een Raycast is een onzichtbare lijn die vanuit een punt in een richting wordt geschoten. Unity controleert of die lijn een Collider raakt en geeft informatie terug via een `RaycastHit`.

```
[Camera] ———————————————————→ [Barrel]
              ← max 50 m →
```

```csharp
Ray ray = new Ray(origin.position, origin.forward);
RaycastHit hit;

if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
{
    Debug.Log("Geraakt: " + hit.collider.name);
}
```

| Parameter     | Betekenis                                                  |
| ------------- | ---------------------------------------------------------- |
| `Ray`         | Beginpunt + richting van de lijn                           |
| `RaycastHit`  | Resultaat: welk object, positie van botsing, normaalvector |
| `maxDistance` | Hoe ver de ray reikt (in meters)                           |
| `LayerMask`   | Filter: welke lagen mag de ray raken?                      |

**Wanneer Raycast vs. Trigger Collider?**

| Raycast                                        | Trigger Collider                  |
| ---------------------------------------------- | --------------------------------- |
| Actief per frame of op aanvraag                | Altijd actief                     |
| Richting-afhankelijk (je moet ernaar wijzen)   | Detecteert alles in de zone       |
| Goed voor: schieten, interactie, line-of-sight | Goed voor: gebieden, collectibles |

---

## Oefening 1 — Layers instellen (~5 min)

Met een Layer filter je welke objecten de raycast mag raken — zo kan de speler zichzelf nooit raken.

1. Ga naar **Edit > Project Settings > Tags and Layers**.
2. Voeg toe:
   - Layer 6: `Shootable`
   - Layer 7: `Player`
3. Selecteer je barrel/krat-prefab in de Hierarchy → zet **Layer** op `Shootable`.
4. Selecteer het spelerkarakter → zet **Layer** op `Player`.

> De barrel heeft verder **geen eigen script nodig** — het schiet-script regelt de explosie en verwijdering.

---

## Oefening 2 — Schieten: ShootSystem.cs (~25 min)

Ik schrijf het shoot-script met een `LineRenderer` als visuele kogelbaan.

**Koppel `ShootSystem.cs` aan de speler (of de camera):**

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
        // Teken de ray in de Scene view voor debugging
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

            Destroy(hit.collider.gameObject);
            ShowLine(shootOrigin.position, hit.point);
        }
        else
        {
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

**Shoot-actie toevoegen aan het Input System:**

1. Open `InputSystem_Actions.inputactions`.
2. Voeg toe aan de **Player** Action Map: `Shoot`, **Action Type: Button**.
3. Binding: **Mouse/Left Button** → **Save Asset**.

**LineRenderer instellen:**

- **Add Component > Effects > Line Renderer** op de speler.
- **Width:** `0.05`, **Color:** rood, **Use World Space:** AAN, **Enabled:** UIT (script zet hem aan).

> Gebruik `Debug.DrawRay` in de Scene view om te controleren of de ray in de juiste richting schiet.

---

## Huiswerk: Raycasts in je 3D Gym

Voeg een werkend schiet-systeem toe aan je 3D Gym.

Zorg dat:

- Er minstens **5 barrels/kratten** in je scene staan die direct exploderen als ze geraakt worden
- De `Debug.DrawRay` correct de schietrichting aangeeft in de Scene view

Optioneel (voor snelle werkers):

Kun je ook een **pickup-systeem** bouwen? De volledige stap-voor-stap instructie staat in de [stepbystep tutorial](../Uitleg/stepbystep/Raycast_Schieten_Pickup.md). Zorg dan ook dat:

- Er minstens **5 kogel-pickups** verspreid in de scene liggen
- De interactie-prompt `[E] Oprapen` verschijnt als je naar een kogel kijkt
- De ammo-teller zichtbaar is in de UI

Commit en push je voortgang naar je GitHub-repository, presenteer de opdracht netjes op je readme en lever de link in op Simulise: `GD - M4 - GDV - HNR : Raycasts`
