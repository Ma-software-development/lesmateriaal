# Step By Step — Parallax Scrollende Achtergrond: Endless Runner

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt wat parallax-scrolling is en waarom het diepte-illusie geeft
- Je kunt meerdere achtergrondlagen aanmaken met elk een eigen scrollsnelheid
- Je kunt een sprite naadloos herhalen zodat de achtergrond eindeloos lijkt
- Je kunt dit systeem koppelen aan één script dat alle lagen beheert

---

## Concept: wat is parallax?

Bij parallax-scrolling beweegt elke laag met een **andere snelheid**:  
objecten ver weg (lucht, bergen) bewegen langzaam, objecten dichtbij (grond, bomen) bewegen snel. Dit geeft de illusie van diepte.

![parallax](https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExbGtiNDZvMG9xNTB2dHdxcnZ1MGV5dmRta2hnenMwYmc3MDVzempnMSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/U7huVmA3TKuqvznInJ/giphy.gif)

```
Snelheid:   LANGZAAM ◄──────────────────► SNEL
            │                              │
Laag 1      Lucht / Wolken
Laag 2            Bergen / Gebouwen
Laag 3                   Bomen / Struiken
Laag 4                          Grond / Platform
            (ver weg)                  (dichtbij)
```

De truc voor een **eindeloze** achtergrond: zodra een sprite volledig links uit beeld is geschoven, plaatsen we hem direct rechts van zijn kopie. Zo merk je nooit een einde.

---

## Stap 1 — Project inrichten

1. Maak een nieuw **2D**-project aan in Unity Hub (template: **2D (URP)** of **2D**).
2. Zorg dat de **Main Camera** op positie `(0, 0, -10)` staat en de **Projection** op `Orthographic`.

### Sprites importeren

3. Zoek of maak minimaal **4 sprites** voor de lagen (PNG met transparante achtergrond):
   - `bg_sky` — effen lucht of wolken
   - `bg_mountains` — verre bergen of skyline
   - `bg_trees` — middelgrond bomen of struiken
   - `bg_ground` — grondstrook / platform

   > **Tip:** Gebruik een gratis asset zoals **Pixel Adventure** of **Free Game Assets** op de Unity Asset Store, of maak zelf vlakke rechthoeken met een kleurverloop als placeholder.

4. Importeer de sprites in **Assets/Sprites/Background/**.
5. Selecteer elke sprite in de Inspector en stel in:
   - **Texture Type:** Sprite (2D and UI)
   - **Wrap Mode:** Repeat ← dit zorgt straks voor naadloos herhalen

---

## Stap 2 — Lagen opbouwen in de scene

Elke laag wordt één **GameObject** met een `SpriteRenderer`.

1. Rechtermuisknop in Hierarchy → **Create Empty** → noem het `Background`.
2. Maak binnen `Background` vier lege GameObjects:
   - `Layer_Sky`
   - `Layer_Mountains`
   - `Layer_Trees`
   - `Layer_Ground`
3. Voeg aan elk laag-object een **Sprite Renderer** toe:
   - **Add Component > Sprite Renderer**
   - Sleep de bijbehorende sprite naar het **Sprite**-veld.
4. Stel de **Sorting Layer** of **Order in Layer** in zodat de lagen niet door elkaar heen tekenen:

| GameObject        | Order in Layer |
| ----------------- | -------------- |
| `Layer_Sky`       | 0              |
| `Layer_Mountains` | 1              |
| `Layer_Trees`     | 2              |
| `Layer_Ground`    | 3              |

5. Schaal elke sprite zodat hij de volledige breedte van het scherm bedekt  
   (bijv. Scale X = **20**, Scale Y = **5** — pas aan op jouw sprite-afmetingen).

> **Waarom twee kopieën?**  
> Om een naadloze lus te maken, hebben we twee exemplaren van elke sprite naast elkaar nodig. We regelen dit in het script — je hoeft nu nog maar één exemplaar te plaatsen.

---

## Stap 3 — ParallaxLayer script

Dit script zit op **elke afzonderlijke laag** en regelt het scrollen én het herhalen.

1. Maak een nieuw script **`ParallaxLayer.cs`** en koppel het aan elk laag-object:

```csharp
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [Header("Scrollsnelheid (eenheden per seconde)")]
    public float scrollSpeed = 2f;

    private SpriteRenderer spriteRenderer;
    private float spriteWidth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Bereken de breedte van de sprite in world-units
        spriteWidth = spriteRenderer.bounds.size.x;
    }

    void Update()
    {
        // Beweeg de laag naar links
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Zodra de laag ver genoeg naar links is, teleporteer hem naar rechts
        // We gebruiken een drempelwaarde van één sprite-breedte
        if (transform.position.x <= -spriteWidth)
        {
            // Verplaats naar rechts zodat het naadloos aansluit
            float newX = transform.position.x + spriteWidth * 2f;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
```

2. Stel per laag de `scrollSpeed` in de Inspector in:

| Laag              | Aanbevolen scrollSpeed |
| ----------------- | ---------------------- |
| `Layer_Sky`       | 0.5                    |
| `Layer_Mountains` | 1.0                    |
| `Layer_Trees`     | 2.5                    |
| `Layer_Ground`    | 4.0                    |

> **Waarom andere snelheden?**  
> De grond beweegt het snelst (dichtbij de camera). De lucht beweegt nauwelijks (ver weg). Hoe groter het verschil, hoe sterker de diepte-illusie.

---

## Stap 4 — Sprite dupliceren voor naadloze lus

De `teleport`-truc werkt alleen als er altijd een tweede exemplaar rechts in beeld staat.

1. Selecteer `Layer_Sky` in de Hierarchy.
2. Druk **Ctrl+D** om een kopie te maken.
3. Noem de kopie `Layer_Sky_Copy`.
4. Zet de kopie **precies één sprite-breedte naar rechts**  
   (als Scale X = 20 en Pixels Per Unit = 100, dan is de breedte 20 units → stel Position X = 20 in).
5. Voeg ook aan de kopie het script `ParallaxLayer.cs` toe met **dezelfde scrollSpeed**.
6. Herhaal stap 1–5 voor `Layer_Mountains`, `Layer_Trees` en `Layer_Ground`.

> **Snelle controle:** start Play mode en check of je een naad ziet. Als de twee sprites niet precies aansluiten, pas dan de X-positie van de kopie aan totdat er geen zichtbare spleet of overlap is.

---

## Stap 5 — Cameravolger (optioneel)

Bij een endless runner beweegt de **speler** vaak op een vaste X-positie terwijl de wereld naar hem toe scrolt. De camera hoeft dan alleen verticaal mee te bewegen.

1. Maak een **speler**-object (bijv. een `Capsule` sprite).
2. Maak een script **`CameraFollow.cs`** en koppel het aan de **Main Camera**:

```csharp
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // Sleep de speler hierin
    public float verticalOffset = 0f;

    void LateUpdate()
    {
        if (target == null) return;

        // Volg alleen de Y-positie van de speler; X blijft vast
        transform.position = new Vector3(
            transform.position.x,
            target.position.y + verticalOffset,
            transform.position.z
        );
    }
}
```

3. Sleep het speler-object naar het **Target**-veld in de Inspector.

---

## Stap 6 — Testen en verfijnen

1. Klik op **Play**.
2. Controleer dat alle lagen scrollen en dat er geen zichtbare onderbreking is.
3. Pas `scrollSpeed` per laag aan totdat de diepte-illusie er goed uitziet.
4. Voeg eventueel een **vijfde laag** toe voor een voorgrond-element (bijv. gras of rotsen) met een zeer hoge snelheid (6–8).

---

## Overzicht van de scripts

| Script          | Verantwoordelijkheid                        |
| --------------- | ------------------------------------------- |
| `ParallaxLayer` | Scrollt één laag en herplaatst hem naadloos |
| `CameraFollow`  | Laat de camera de speler verticaal volgen   |

---

## Uitbreidingsideeën

- **Snelheid koppelen aan speler:** laat `scrollSpeed` meegroeien met de loopsnelheid van de speler voor een steeds moeilijker wordend spel.
- **Dag/nacht-cyclus:** wissel langzaam de `Color`-eigenschap van de `SpriteRenderer` van `Layer_Sky` om een zonsondergang te simuleren.
- **Parallax op de camera:** in plaats van de lagen zelf te bewegen kun je de `Material.mainTextureOffset` van een achtergrond-quad aanpassen — handig als je de camera wél wilt laten bewegen.
