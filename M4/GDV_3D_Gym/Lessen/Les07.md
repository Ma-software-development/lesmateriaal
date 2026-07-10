# M4 GDV HNR LES 7: Particle Systems — Visuele effecten

Deze les leren jullie het volgende:

- Je begrijpt hoe een `ParticleSystem` is opgebouwd en welke modules er zijn
- Je kunt de belangrijkste instellingen aanpassen (Emission, Shape, Lifetime, Color, Size)
- Je kunt een Particle System afspelen vanuit een script
- Je kunt een trigger-zone maken zodat een effect afspeelt als de speler een bepaalde plek bereikt

In deze les laat ik zien hoe je een visueel effect maakt en koppelt aan je scene. Je kunt direct meedoen of kijken en aantekeningen maken.

De uitgebreide stap-voor-stap instructie staat hier: [ParticleSystemTriggerExplosion.md](../Uitleg/stepbystep/ParticleSystemTriggerExplosion.md)

---

## Hoe werkt een Particle System?

Een `ParticleSystem` spawnt (genereert) grote hoeveelheden kleine objecten — **deeltjes** — en stuurt elk deeltje aan via modules:

| Module        | Wat het doet                                                    |
| ------------- | --------------------------------------------------------------- |
| **Main**      | Levensduur, startsnelheid, startgrootte, startkleur             |
| **Emission**  | Hoeveel deeltjes per seconde of per burst worden gespawnd       |
| **Shape**     | De vorm van het spawn-gebied (bol, kegel, vlak, mesh...)        |
| **Velocity**  | Extra richtingscontrole per deeltje                             |
| **Color**     | Kleurverloop over de levensduur van het deeltje                 |
| **Size**      | Grootteverloop over de levensduur (bijv. groot → klein)         |
| **Renderer**  | Welk materiaal/sprite op de deeltjes wordt geplaatst            |

Elk effect combineer je door de juiste modules aan/uit te zetten en de waarden af te stemmen.

---

## Oefening 1 — YouTube video kijken (~10 min)

Voordat we beginnen kijk je zelfstandig de onderstaande video. Deze geeft een beknopte maar duidelijke overview van de belangrijkste Particle System instellingen in Unity.

> **Kijk de video volledig en maak aantekeningen van de instellingen die je nog niet kende.**

🎥 [Particle System Overview — Unity (YouTube)](https://www.youtube.com/watch?v=FEA1wTMJAR0)

Beantwoord daarna voor jezelf:
- Welke module regelt de *kleur* van een deeltje over zijn levensduur?
- Wat is het verschil tussen **Rate over Time** en **Burst** in de Emission-module?
- Waarvoor gebruik je de **Shape**-module?

---

## Oefening 2 — Eerste Particle System aanmaken (~10 min)

Ik laat zien hoe je een nieuw Particle System aanmaakt en de basisinstellingen instelt:

1. Rechtermuisknop in de Hierarchy → **Effects > Particle System**.
2. Noem het object `PS_Explosie`.
3. In de Inspector zie je de **Main**-module bovenaan. Stel in:
   - **Start Lifetime:** `1.5`
   - **Start Speed:** `8`
   - **Start Size:** `0.5`
   - **Start Color:** kies een oranje/geel kleur
   - **Gravity Source:** Physics → **Gravity Modifier:** `1`
4. Zet de **Loop**-toggle **uit** (want een explosie speelt maar één keer).
5. Zet **Play On Awake** ook **uit** (we starten het effect vanuit een script).

---

## Oefening 3 — Effect vormgeven (~15 min)

Ik laat zien hoe je het effect er als een echte explosie uit laat zien:

**Emission (burst):**

1. Open de **Emission**-module.
2. Zet **Rate over Time** op `0`.
3. Klik op het **+** onder **Bursts** → voeg een burst toe met:
   - **Time:** `0`
   - **Count:** `50`

**Shape:**

4. Open de **Shape**-module.
5. Stel **Shape** in op `Sphere`, **Radius:** `0.2`.

**Color over Lifetime:**

6. Open de **Color over Lifetime**-module (activeer hem met het vinkje).
7. Klik op de kleurenbalk → maak een verloop van `oranje → rood → transparant`.

**Size over Lifetime:**

8. Open de **Size over Lifetime**-module (activeer hem).
9. Stel een curve in die begint op `1` en eindigt op `0` (deeltjes worden kleiner).

> Klik op **Play** in de Particle System preview (onderkant Inspector) om het effect direct te bekijken zonder de scene te starten.

---

## Oefening 4 — Trigger-zone maken met een script (~20 min)

Nu koppelen we het effect aan de scene: als de speler een bepaalde plek bereikt, speelt het effect af.

**Trigger zone aanmaken:**

1. Maak een leeg GameObject aan: **GameObject > Create Empty** → noem het `TriggerZone`.
2. Voeg toe: **Add Component > Physics > Box Collider**.
3. Activeer **Is Trigger** op de Box Collider.
4. Positioneer de `TriggerZone` ergens in je level waar de speler doorheen moet lopen.

**Particle System als child toevoegen:**

5. Sleep `PS_Explosie` naar `TriggerZone` als child-object (of maak een nieuwe aan als child).
6. Stel de positie van `PS_Explosie` in op `0, 0, 0` (relatief aan de trigger).

**Script schrijven:**

7. Maak een script `EffectTrigger.cs` en koppel dit aan `TriggerZone`:

```csharp
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            effect.Play();
        }
    }
}
```

8. Sleep `PS_Explosie` naar het **Effect**-veld in de Inspector.
9. Zorg dat het karakter de tag **Player** heeft.

> `hasTriggered` zorgt ervoor dat het effect maar één keer afspeelt, ook al loopt de speler er meerdere keren doorheen.

---

## Oefening 5 — Effect optioneel verwijderen na afspelen (~5 min)

Een explosie die blijft bestaan in de Hierarchy is een verspilling. Je kunt het GameObject automatisch verwijderen:

```csharp
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem effect;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
        }
    }
}
```

> `effect.main.duration + effect.main.startLifetime.constantMax` geeft je de totale maximale afspeeltijd van het effect, zodat het GameObject precies op het juiste moment wordt verwijderd.

---

## Opdracht: Maak jouw eigen effect

Maak een eigen visueel effect en voeg dit toe aan je 3D Gym scene.

**Vereisten:**

- Het effect speelt af als de speler een bepaalde plek in het level bereikt (via `OnTriggerEnter`)
- Het effect is zelfbedacht: een explosie, een bliksemflits, vuurwerk, rook, magie — jouw keuze
- Het effect speelt maar **één keer** af
- De trigger-zone is duidelijk zichtbaar gepositioneerd in het level (bijv. aan het einde van een pad, bij een item)

**Inleveren:**

Commit en push je voortgang naar je GitHub-repository, presenteer de opdracht netjes op je readme en lever de link in op Simulise: 
`GD - M4 - GDV - HNR : Particle System Effect`
