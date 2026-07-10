# Step By Step — Splines & Timeline: Camera & Cutscenes
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een Spline aanmaken en een object erlangs bewegen met `SplineAnimate`
- Je begrijpt hoe de Timeline window werkt met Tracks en Clips
- Je kunt een Cinemachine Track toevoegen voor een camera-overgang

---

## Achtergrond: Splines vs. Timeline

| Tool | Gebruik |
|---|---|
| **Splines** | Een pad/route — voor constante beweging (patrouille, introductie-dolly) |
| **Timeline** | Een tijdlijn — voor geregisseerde sequenties (cutscene, intro, game-over animatie) |

In een intro-cutscene gebruik je **beiden**: de camera volgt een Spline, de Timeline bepaalt wanneer dat begint en eindigt.

---

## Stap 1 — SplineContainer aanmaken

1. **GameObject > Spline > Draw Splines Tool** (of via **Package Manager: Splines** al geïnstalleerd).
2. Noem het nieuwe GameObject `IntroPath`.
3. In de Scene view verschijnt de Spline-editor. Klik om knots (controlepunten) toe te voegen.
4. Voeg knots toe die de route van de introductie beschrijven:
   - Beginpositie buiten de gym
   - Richting de gymingang
   - Einpositie vóór het karakter
5. Om de Spline te bewerken: selecteer `IntroPath` → in de Inspector klik je op **Edit Spline** (potlood-icoon).
6. Sleep knots naar de gewenste positie in de Scene view. Houd `Alt` ingedrukt om tangent-handles te bewerken (vloeiende bochten).

---

## Stap 2 — SplineAnimate koppelen aan een camera

1. Maak een leeg GameObject: `DollyCamera`.
2. Maak het een child van **niets** (top-level in de Hierarchy).
3. **Add Component > Spline Animate**.
4. Sleep `IntroPath` naar het **Spline Container**-veld.
5. Stel in:
   - **Alignment:** Spline Element (de camera kijkt in de richting van de beweging)
   - **Loop Mode:** Once (play maar één keer voor een intro)
   - **Duration:** 5.0 (seconden voor de volledige rit)
6. Voeg een **Cinemachine Camera** toe aan `DollyCamera` (of maak het een CinemachineCamera).

> **Tip:** Stel de prioriteit van deze CinemachineCamera hoog in (bijv. 20) zodat hij het ovmenet neemt tijdens de cutscene.

---

## Stap 3 — SplineAnimate patrouille instellen voor een NPC

1. Maak een tweede SplineContainer: `PatrouillePad`.
2. Teken een gesloten patrouilleroute (sluit de lus door de laatste knot te verbinden met de eerste).
3. Selecteer je NPC-object.
4. **Add Component > Spline Animate**.
5. Stel in:
   - **Spline Container:** PatrouillePad
   - **Loop Mode:** Loop (continue patrouille)
   - **Duration:** 10.0 (tien seconden voor een ronde)
   - **Alignment:** Spline Element

> **Let op:** `SplineAnimate` vervangt in dit geval `NavMeshAgent` — kies één van de twee voor beweging.

---

## Stap 4 — Timeline window openen

1. **Window > Sequencing > Timeline**.
2. Maak een leeg GameObject: `CutsceneDirector`.
3. Selecteer `CutsceneDirector`. In de Timeline-window klik je op **Create** om een **Timeline Asset** aan te maken. Sla op als `IntroCutscene.playable` in de `Assets/Scenes/`-map.

---

## Stap 5 — Activation Track: NPC laten verschijnen

1. In de Timeline window: klik **+** → **Activation Track**.
2. Sleep je NPC-GameObject (bijv. `WorkerNPC`) naar het track-label.
3. Klik met rechtermuisknop op de track en kies **Add Clip**.
4. Versleep de clip zodat de NPC pas na 3 seconden actief wordt (bijv. van seconde 3 tot het einde).

> **Tip:** Zet de NPC vóór de cutscene op **inactive** (`SetActive(false)`) zodat hij pas verschijnt als de Timeline het aangeeft.

---

## Stap 6 — Cinemachine Track voor camera-overgang

1. Installeer de Cinemachine-Timeline-integratie als dat nog niet is gebeurd:
   - **Window > Package Manager > Cinemachine > Samples**.
   - Of het is automatisch beschikbaar als je Cinemachine ≥ 3 hebt geïnstalleerd.

2. In de Timeline window: klik **+** → **Cinemachine Track**.
3. Koppel de **CinemachineBrain** van de Main Camera aan dit track (sleep de Main Camera naar het track-label).
4. Voeg clips toe:
   - **Clip 1 (0s – 5s):** Sleep `VC_Dolly` (de DollyCamera Cinemachine Camera) in de track.
   - **Clip 2 (5s – einde):** Sleep `VC_Follow` (de volg-camera) in de track.
5. Maak een overgang: sleep de clips zodat ze een paar frames overlappen. Timeline maakt dan automatisch een blend.

---

## Stap 7 — Animation Track: deur openen

1. In Timeline: klik **+** → **Animation Track**.
2. Sleep de **deur** (met een Animator) naar dit track.
3. Klik met rechtermuisknop → **Add Animation Clip**.
4. In de Clip: klik **Edit in Animation Window**.
5. In de Animation window: sla een frame op met de deur dicht (seconde 0) en een frame met de deur open (seconde 4).
6. Sluit de Animation window. De deur opent nu op seconde 4 van de cutscene.

---

## Stap 8 — Cutscene automatisch starten

1. Maak `CutsceneTrigger.cs`:

```csharp
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private bool playedOnce = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playedOnce)
        {
            playedOnce = true;
            director.Play();
        }
    }
}
```

2. Maak een Box Collider in de ingang van de gym als trigger.
3. Koppel `CutsceneTrigger` aan dit object.
4. Sleep `CutsceneDirector` naar het `Director`-veld.
5. Test: loop door de ingang → cutscene start.

---

## Stap 9 — Na de cutscene: input teruggeven aan de speler

Terwijl de cutscene speelt, mag de speler niet bewegen.

```csharp
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private MonoBehaviour playerController; // MoveCharacterController

    void OnEnable()
    {
        director.played += OnCutscenePlayed;
        director.stopped += OnCutsceneStopped;
    }

    void OnDisable()
    {
        director.played -= OnCutscenePlayed;
        director.stopped -= OnCutsceneStopped;
    }

    void OnCutscenePlayed(PlayableDirector d)
    {
        playerController.enabled = false; // speler-input uitschakelen
    }

    void OnCutsceneStopped(PlayableDirector d)
    {
        playerController.enabled = true; // speler-input teruggeven
    }
}
```

---

## Stap 10 — Game-over cutscene (uitbreiding)

1. Maak een tweede Timeline Asset: `GameOverCutscene.playable`.
2. Voeg een Activation Track toe voor een **Game Over**-UI-paneel.
3. Voeg een Animation Track toe voor een fade-to-black (Canvas Group alpha van 0 naar 1).
4. Roep `director.Play()` aan vanuit `HealthSystem` na het sterven.

---

## Spline geavanceerd: tangents aanpassen

| Knot Type | Werking |
|---|---|
| **Auto Smooth** | Unity berekent vloeiende bochten automatisch |
| **Cubic Bezier** | Handmatige tangent-handles voor volledige controle |
| **Linear** | Rechte lijnen tussen knots (hoekige beweging) |

Gebruik **Cubic Bezier** voor camerapadden (vloeiend) en **Linear** voor technische paden (bijv. lifttraject).

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Camera beweegt niet langs Spline | SplineContainer niet gekoppeld | Sleep de SplineContainer naar SplineAnimate |
| Cutscene herstart elke keer | `playedOnce` flag ontbreekt | Voeg de bool-check toe in de trigger |
| Camera keert niet terug na cutscene | Tweede Cinemachine clip ontbreekt | Voeg `VC_Follow` als clip toe na de dolly-clip |
| NPC verschijnt meteen | Object is niet disabled voor de Timeline | Zet NPC op `SetActive(false)` in de scene |
| Animation Track animatie speelt niet | Animator Controller staat ook op het object | Zet Animator Controller op None als Timeline de animatie aanstuurt |

---

## Controlelijst voor afronding

- [ ] `IntroPath` SplineContainer aangemaakt met minimaal 4 knots
- [ ] `DollyCamera` volgt de Spline via SplineAnimate (Duration 5s, Once)
- [ ] `PatrouillePad` voor NPC aangemaakt met Loop Mode
- [ ] Timeline Asset aangemaakt en gekoppeld aan CutsceneDirector
- [ ] Activation Track: NPC verschijnt na 3 seconden
- [ ] Cinemachine Track: overgang van DollyCamera naar VC_Follow
- [ ] Animation Track: deur opent op seconde 4
- [ ] CutsceneTrigger: cutscene start eenmalig bij betreden zone
- [ ] Speler-input uitgeschakeld tijdens cutscene, teruggegeven daarna
- [ ] Cutscene volledig doorgespeeld zonder fouten in de Console
