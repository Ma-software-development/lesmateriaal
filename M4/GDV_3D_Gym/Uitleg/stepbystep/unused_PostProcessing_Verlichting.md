# Step By Step — Post Processing & Verlichting
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een URP Volume instellen met post-processing effecten
- Je begrijpt het verschil tussen baked en realtime verlichting
- Je kunt een `Global Volume` en `Local Volume` gebruiken

---

## Achtergrond: Global vs. Local Volume

| Volume | Werking |
|---|---|
| **Global Volume** | Geldt voor de gehele scene — altijd actief |
| **Local Volume** | Alleen actief als de Camera in het Volume-gebied is (Trigger Collider) |

Beide Volume-typen gebruiken een **Volume Profile**: een bestand met alle effect-instellingen.

---

## Stap 1 — Global Volume toevoegen

1. **GameObject > Volume > Global Volume**.
2. In de Inspector: klik op **New** naast **Profile** om een nieuw profiel aan te maken. Sla op als `GymVolumeProfile`.

---

## Stap 2 — Bloom effect toevoegen

1. Selecteer de Global Volume.
2. Klik in de Inspector op **Add Override > Post-processing > Bloom**.
3. Klik op het vinkje naast **Intensity** om het te activeren (Override).
4. Stel in:
   - **Intensity:** 0.3 (subtiel — te hoog ziet er goedkoop uit)
   - **Threshold:** 0.9 (alleen heel lichte gebieden bloomen)
   - **Scatter:** 0.7

> **Tip:** Bloom is zichtbaar bij lichten en reflecterende oppervlakken. Als je het niet ziet, controleer dan of de camera een **HDR**-instelling heeft (**Camera Inspector > Rendering > HDR: ✅**).

---

## Stap 3 — Color Grading (Tone Mapping) toevoegen

1. In de Global Volume: **Add Override > Post-processing > Tonemapping**.
2. Activeer **Mode** en stel in op **ACES** (filmisch).
3. **Add Override > Post-processing > Color Adjustments**:
   - **Post Exposure:** 0.0 (negatief = donkerder, positief = helderder)
   - **Saturation:** -20 (licht desaturated voor industriële sfeer)
   - **Color Filter:** licht blauwgrijs (klik het kleurvak)
4. **Add Override > Post-processing > Lift, Gamma, Gain**:
   - **Shadows (Lift):** blauwachtig (schuif de cirkel licht naar blauw)
   - **Midtones (Gamma):** neutraal
   - **Highlights (Gain):** licht wit/koel

---

## Stap 4 — Vignette toevoegen

1. **Add Override > Post-processing > Vignette**.
2. Activeer alle velden:
   - **Intensity:** 0.25
   - **Smoothness:** 0.5
   - **Color:** zwart

---

## Stap 5 — Local Volume aanmaken (Depth of Field zone)

1. Maak een leeg GameObject: `MisterieuzeHoek`.
2. Positioneer het in een hoek van de gym.
3. **Add Component > Volume**.
4. Stel in:
   - **Is Global:** ❌ (uitvinken — dit is een Local Volume)
   - Klik **New** naast Profile → noem het `MisterieuzeHoekProfile`.
5. **Add Component > Box Collider**:
   - Zet **Is Trigger:** ✅
   - Stel de grootte in zodat het een klein gebied beslaat, bijv. 4 × 3 × 4 meter.
6. In het Volume-component: klik **Add Override > Post-processing > Depth of Field**.
7. Activeer:
   - **Focus Distance:** 3
   - **Aperture:** 5.6
   - **Focal Length:** 50

> De camera blurrt alles buiten de focusafstand als je in de zone loopt. Dit simuleert een mysterieuze, dromerige sfeer.

---

## Stap 6 — Hurt-effect via script (rood Vignette)

### Volume instellen
1. Maak een tweede Global Volume: `HurtVolume`.
2. Maak een nieuw profiel: `HurtProfile`.
3. **Add Override > Post-processing > Vignette**:
   - **Intensity:** 0.6
   - **Color:** rood (#FF0000)
4. Stel de **Weight** van dit Volume in op **0** (initieel uitgeschakeld).

### Script
5. Maak `HurtEffect.cs` en koppel aan het karakter of de GameManager:

```csharp
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class HurtEffect : MonoBehaviour
{
    [SerializeField] private Volume hurtVolume;
    [SerializeField] private float effectDuration = 0.5f;

    public void TriggerHurt()
    {
        StartCoroutine(HurtRoutine());
    }

    IEnumerator HurtRoutine()
    {
        // Verhoog weight naar 1 (volledig rood vignette)
        hurtVolume.weight = 1f;

        float timer = 0f;
        while (timer < effectDuration)
        {
            // Lineair afnemen
            hurtVolume.weight = Mathf.Lerp(1f, 0f, timer / effectDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        hurtVolume.weight = 0f;
    }
}
```

6. Roep `TriggerHurt()` aan vanuit `HealthSystem.TakeDamage()`.

---

## Stap 7 — Baked Verlichting instellen

Baked (gebakken) verlichting berekent schaduwen en indirect licht eenmalig — dit is veel sneller dan realtime berekeningen.

### Objecten markeren als Static
1. Selecteer alle vloer-, muur- en prop-objecten die nooit bewegen.
2. Klik rechtsboven in de Inspector op **Static** → **Everything** (of minimaal **Contribute GI** en **Reflection Probe Static**).
3. Het bewegende karakter (Worker) **niet** als Static markeren.

### Lighting instellen
4. **Window > Rendering > Lighting**.
5. Tabblad **Scene**:
   - **Realtime Global Illumination:** ❌ uitvinken
   - **Baked Global Illumination:** ✅ aanvinken
   - **Lightmapper:** Progressive GPU (sneller) of Progressive CPU
6. Tabblad **Environment**:
   - **Ambient Mode:** Baked
7. Klik **Generate Lighting** (onderaan in het Lighting-venster).

> Wacht tot de baking klaar is — dit kan een paar minuten duren. Je ziet de voortgang rechtsonderin de Unity Editor.

---

## Stap 8 — Light Probes toevoegen voor de Worker

Light Probes geven dynamische objecten (die niet statisch zijn) de juiste belichting.

1. **GameObject > Light > Light Probe Group**.
2. Positioneer de probe-groep in de scene.
3. Selecteer de Light Probe Group. In de Scene view zie je gele bollen.
4. Verplaats en verspreid ze door de gym, met extra probes bij licht-/schaduwovergangen.
5. Klik in de Inspector op **Bake** of gebruik **Generate Lighting** opnieuw.

---

## Stap 9 — Directional Light instellen

1. Selecteer de **Directional Light** in de Hierarchy.
2. In de Inspector:
   - **Mode:** Realtime (voor dynamische schaduwen op bewegende objecten)
   - **Shadow Type:** Soft Shadows
   - **Shadow Resolution:** High
   - **Intensity:** 1.0
3. Roteer het licht: Rotation X = 50, Y = -30 voor een schuine zonnehoek.

---

## Stap 10 — FPS meten voor/na baking

1. **Window > General > Statistics** (rechtsboven in de Game view klikken op **Stats**).
2. Noteer de FPS **voor** het bakken.
3. Genereer de verlichting (Stap 7).
4. Noteer de FPS **na** het bakken.
5. Vergelijk: baked verlichting is significant sneller (minder GPU-belasting).

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Bloom niet zichtbaar | Camera heeft geen HDR | Camera Inspector → Rendering → HDR ✅ |
| Local Volume heeft geen effect | Is Trigger staat uit op Collider | Box Collider → Is Trigger ✅ |
| Hurt-effect werkt niet | Volume weight staat al op 0 | Controleer `hurtVolume.weight = 1f` in script |
| Baking mislukt | Objecten niet als Static gemarkeerd | Selecteer alle statische objecten → Static |
| Worker heeft vreemde belichting | Geen Light Probes | Voeg Light Probe Group toe en rebake |
| Schaduw-artifacts | Shadow Bias te laag | Light Inspector → Shadow Bias verhogen |

---

## Controlelijst voor afronding

- [ ] Global Volume aangemaakt met GymVolumeProfile
- [ ] Bloom: Intensity 0.3, Threshold 0.9
- [ ] Color Grading: ACES Tonemapping + lage saturatie + koele kleur
- [ ] Vignette: Intensity 0.25
- [ ] Local Volume in een hoek met Depth of Field effect
- [ ] Depth of Field overgang werkt als speler de zone in/uit loopt
- [ ] HurtVolume met rood Vignette + Coroutine voor fade-out
- [ ] `TriggerHurt()` wordt aangeroepen bij schade
- [ ] Statische objecten gemarkeerd als Static
- [ ] Baked Global Illumination gegenereerd
- [ ] Light Probes toegevoegd voor de bewegende Worker
- [ ] FPS voor/na baking genoteerd
