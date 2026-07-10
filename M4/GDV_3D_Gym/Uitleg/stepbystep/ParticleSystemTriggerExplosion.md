# STEPBYSTEP Particle Systems: Explosie met Trigger
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een Particle System aanmaken en de basismodules instellen
- Je kunt een explosie-effect bouwen met een burst, kleurverloop en size-curve
- Je kunt een trigger-zone aanmaken met een `BoxCollider` (Is Trigger)
- Je kunt een `ParticleSystem` aansturen vanuit een script via `OnTriggerEnter`

---

## Wat ga je bouwen?

Een explosie-effect (`ParticleSystem`) dat eenmalig afspeelt op het moment dat de speler een specifieke zone in je level betreedt. Na afloop vernietigt het effect zichzelf automatisch.

---

## Stap 1 — Particle System aanmaken

1. Rechtermuisknop in de **Hierarchy** → **Effects > Particle System**.
2. Noem het object `PS_Explosie`.
3. Positioneer het op de plek waar je de explosie wilt (bijv. X=0, Y=0.5, Z=5).

---

## Stap 2 — Main module instellen

De **Main**-module is altijd zichtbaar bovenaan het Particle System component.

Stel de volgende waarden in:

| Instelling        | Waarde        |
| ----------------- | ------------- |
| Duration          | `1`           |
| Looping           | ❌ uit        |
| Start Lifetime    | `1.5`         |
| Start Speed       | `8`           |
| Start Size        | `0.4`         |
| Start Color       | Oranje/geel   |
| Gravity Modifier  | `1`           |
| Play On Awake     | ❌ uit        |
| Stop Action       | `Destroy`     |

> **Stop Action: Destroy** zorgt ervoor dat het GameObject zichzelf verwijdert zodra het effect klaar is. Zo blijft je Hierarchy netjes.

---

## Stap 3 — Emission instellen (burst)

Een explosie spawnt alle deeltjes tegelijk in plaats van geleidelijk.

1. Open de **Emission**-module (klik op de naam om hem uit te klappen).
2. Zet **Rate over Time** op `0`.
3. Klik onderaan de module op het **+** achter **Bursts**.
4. Stel de burst in:
   - **Time:** `0`
   - **Count:** `60`
   - **Cycles:** `1`

---

## Stap 4 — Shape instellen

De shape bepaalt vanuit welke vorm de deeltjes worden afgevuurd.

1. Open de **Shape**-module.
2. Stel **Shape** in op **Sphere**.
3. Stel **Radius** in op `0.15`.

Dit zorgt ervoor dat de deeltjes vanuit een klein middelpunt in alle richtingen wegvliegen.

---

## Stap 5 — Color over Lifetime

1. Activeer de module **Color over Lifetime** (vinkje links van de naam).
2. Klik op de kleurenbalk om de Gradient Editor te openen.
3. Maak het volgende verloop:
   - **Begin (0%):** felgeel of oranje, volledig opaque
   - **Midden (~50%):** rood/donkeroranje
   - **Einde (100%):** grijs/zwart, volledig transparant (alpha = 0)

> Klik op de gekleurde marker onderaan de balk voor kleur, op de witte marker bovenaan voor alpha (transparantie).

---

## Stap 6 — Size over Lifetime

1. Activeer de module **Size over Lifetime**.
2. Klik op de curve-balk.
3. Kies de preset **"Curve that starts at 1 and ends at 0"** (of teken hem zelf: lineair van 1 naar 0).

De deeltjes worden nu geleidelijk kleiner en verdwijnen soepel.

---

## Stap 7 — Effect testen

1. Selecteer `PS_Explosie` in de Hierarchy.
2. Onderaan het Particle System component in de Inspector zie je de preview-toolbar.
3. Klik op **Play** (▶) om het effect te bekijken zonder Play mode te starten.
4. Klik op **Restart** om het opnieuw af te spelen.

Ziet het er nog niet goed uit? Pas de waarden aan:
- Te traag → verhoog **Start Speed**
- Te groot → verlaag **Start Size** of **Count**
- Te kort → verhoog **Start Lifetime**

---

## Stap 8 — Prefab maken van het effect

Sla het Particle System op als Prefab zodat je het via een script kunt instantiëren.

1. Maak een map **Assets/Prefabs** aan als die nog niet bestaat.
2. Sleep `PS_Explosie` vanuit de Hierarchy naar de **Prefabs**-map in de Project view.
3. Verwijder het origineel uit de Hierarchy (rechtermuisknop → **Delete**).

---

## Stap 9 — Trigger-zone aanmaken

1. Rechtermuisknop in de Hierarchy → **Create Empty** → noem het `TriggerZone`.
2. Positioneer `TriggerZone` op de plek in je level waar je de explosie wilt triggeren.
3. Klik **Add Component > Physics > Box Collider**.
4. Zet **Is Trigger** op ✅ aan.
5. Pas de **Size** aan zodat de zone groot genoeg is om doorheen te lopen (bijv. X=2, Y=2, Z=2).

> Tip: In de Scene view zie je de groene draadframe-box van de collider. Maak hem ruim genoeg.

---

## Stap 10 — Script schrijven: EffectTrigger.cs

1. Selecteer `TriggerZone` → **Add Component > New Script** → noem het `EffectTrigger`.
2. Open het script en vervang de inhoud door:

```csharp
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject effectPrefab;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
        }
    }
}
```

3. Sla het script op en ga terug naar Unity.
4. Selecteer `TriggerZone` in de Hierarchy.
5. Sleep de **PS_Explosie prefab** vanuit de Project view naar het **Effect Prefab**-veld in de Inspector.

---

## Stap 11 — Player tag instellen

Het script controleert de tag `"Player"` om te herkennen of de speler de zone betreedt.

1. Selecteer het speler-GameObject in de Hierarchy.
2. Klik bovenin de Inspector op het **Tag**-dropdown.
3. Kies **Player** (of klik **Add Tag...** en maak de tag aan als hij er niet is).

---

## Stap 12 — Testen

1. Druk op **Play**.
2. Loop met je karakter naar de `TriggerZone`.
3. Op het moment dat de speler de zone betreedt, spawnt de explosie.
4. Na afloop verdwijnt het effect automatisch (door **Stop Action: Destroy**).
5. Loopt de speler er een tweede keer doorheen? Het effect speelt **niet** opnieuw af (`hasTriggered`).

**Werkt het niet?**

| Probleem                        | Mogelijke oorzaak                                           |
| ------------------------------- | ----------------------------------------------------------- |
| Geen explosie bij betreden zone | Speler heeft tag `Player` niet, of `Is Trigger` staat uit   |
| Effect spawnt maar verdwijnt niet | `Stop Action` staat niet op `Destroy`                     |
| Effect speelt meteen af          | `Play On Awake` staat nog aan in de Main-module             |
| Explosie op verkeerde plek       | Controleer de positie van `TriggerZone` in de scene        |

---

## Klaar? Ga verder met de opdracht

Je hebt nu een werkende explosie als trigger-effect. Voor de opdracht ga je **jouw eigen effect** maken: een bliksemflits, rook, magie, vuurwerk — wat jij wilt. Gebruik dezelfde structuur (trigger-zone + script + ParticleSystem prefab) en pas de modules aan op je eigen idee.

Bekijk voor inspiratie de [Particle System modules in de Unity documentatie](https://docs.unity3d.com/Manual/ParticleSystemModules.html).
