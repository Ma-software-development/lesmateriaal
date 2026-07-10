# Step By Step — Cinemachine 3: Follow Camera met Pan & Tilt

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt Cinemachine installeren en de `CinemachineBrain` instellen op de Main Camera
- Je begrijpt het verschil tussen `CinemachineBrain` en een `CinemachineCamera` (Virtual Camera)
- Je kunt een follow-camera instellen met `Third Person Follow` en `Pan Tilt` voor muis-besturing
- Je kunt de `Look`-actie uit het Input System koppelen aan Cinemachine
- Je kunt wisselen tussen twee Virtual Cameras via een knop

---

## Achtergrond: Hoe werkt Cinemachine?

Cinemachine werkt met twee onderdelen:

| Onderdeel                            | Zit op           | Taak                                                          |
| ------------------------------------ | ---------------- | ------------------------------------------------------------- |
| `CinemachineBrain`                   | Main Camera      | Luistert naar alle Virtual Cameras en beslist welke actief is |
| `CinemachineCamera` (Virtual Camera) | Eigen GameObject | Definieert hoe de camera beweegt en kijkt                     |

Je kunt meerdere Virtual Cameras maken (follow-cam, overview-cam, cutscene-cam) en ze wisselen via **prioriteit** of vanuit **code**. De CinemachineBrain zorgt voor soepele overgangen (blends) tussen de camera's.

**Pan** = horizontale draaiing (links/rechts om de speler draaien)  
**Tilt** = verticale draaiing (omhoog/omlaag kijken)

---

## Stap 1 — Cinemachine installeren

Cinemachine 3 is niet zomaar beschikbaar via de zoekfunctie. Installeer het via de naam:

1. Ga naar **Window > Package Manager**.
2. Klik op het **+**-icoon linksboven → **Install package by name**.
3. Vul in:
   - **Name:** `com.unity.cinemachine`
   - **Version:** `3.1.5`
4. Klik op **Install**.

---

## Stap 2 — CinemachineBrain instellen op de Main Camera

Na installatie:

1. Selecteer de **Main Camera** in de Hierarchy.
2. Controleer of er automatisch een `CinemachineBrain`-component is toegevoegd. Zo niet: **Add Component > Cinemachine > CinemachineBrain**.
3. Laat de standaardinstellingen staan.

---

## Stap 3 — CameraTarget aanmaken op de speler

Cinemachine volgt een specifiek punt op de speler, niet het hele object.

1. Selecteer het karakter in de Hierarchy.
2. Maak een leeg child-object: **rechtermuisknop > Create Empty**. Noem het `CameraTarget`.
3. Zet de positie op Y = `1.5` (borsthoogte).

---

## Stap 4 — Virtual Camera aanmaken (Follow-cam)

1. Ga naar **GameObject > Cinemachine > CinemachineCamera**.
2. Noem hem `VC_Follow`.
3. Sleep je `CameraTarget` object in het **Tracking Target** veld in de Inspector.

---

## Stap 5 — Procedural components instellen

Stel de bewegings- en rotatiebesturing in via de **Procedural Components**:

1. Selecteer `VC_Follow`.
2. Zoek het onderdeel **Procedural Components** in de Inspector.
3. Stel in:
   - **Position Control:** `Third Person Follow`
   - **Rotation Control:** `Pan Tilt`

---

## Stap 6 — Third Person Follow instellen

1. Selecteer `VC_Follow`.
2. Zoek het `CinemachineThirdPersonFollow`-component in de Inspector.
3. Stel in:
   - **Shoulder Offset:** X = `0`, Y = `1`, Z = `0`
   - **Camera Distance:** `5.14`

---

## Stap 7 — Pan Tilt instellen

1. Selecteer `VC_Follow`.
2. Zoek het `CinemachinePanTilt`-component in de Inspector.
3. Stel in:
   - **Reference Frame:** `LookAtTarget`

---

## Stap 8 — Input System koppelen aan Cinemachine

Cinemachine 3 gebruikt de `CinemachineInputAxisController` voor musinput.

### Look-actie toevoegen aan het InputActionAsset

1. Open `InputSystem_Actions.inputactions`.
2. Voeg in de **Player** Action Map een actie toe: `Look`, **Action Type: Value**, **Control Type: Vector2**.
3. Voeg als binding toe: **Mouse/Delta** → **Save Asset**.

### Koppelen in Cinemachine

4. Selecteer `VC_Follow` → **Add Component > Cinemachine > CinemachineInputAxisController**.
5. In de Inspector: koppel **Look X** en **Look Y** aan de `Look`-actie.
6. Stel de **Gain** in:
   - **Look X:** `1`
   - **Look Y:** `-5`

---

## Stap 9 — Damping instellen voor soepele camerabewegingen

1. Selecteer `VC_Follow`.
2. Zoek het `CinemachineThirdPersonFollow`-component.
3. Stel in:
   - **Damping:** X = `0.5`, Y = `0.5`, Z = `0.5`
4. Test in Play mode: de camera volgt nu met een kleine vertraging voor een professioneler gevoel.

---

## Stap 10 — Recentering inschakelen

Als de speler stopt met rondkijken, keert de camera automatisch terug naar achter de speler.

1. Selecteer `VC_Follow`.
2. Zoek het `CinemachinePanTilt`-component.
3. Stel in:
   - **Recenter Target:** `Axis Center`

---

## Stap 11 — Camera-collision instellen (CinemachineDeoccluder)

Voorkomt dat de camera door muren gaat.

1. Selecteer `VC_Follow`.
2. **Add Extension > CinemachineDeoccluder**.
3. Stel in:
   - **Strategy:** `Pull Camera Forward`
   - **Camera Radius:** `0.3`

---

## Stap 12 — Tweede Virtual Camera: Overview

1. **GameObject > Cinemachine > CinemachineCamera** → noem hem `VC_Overview`.
2. Positioneer hem hoog boven de scene: Y = `20`, kijk omlaag (Rotation X = `90`).
3. Stel **Priority** in op `0` (lager dan de follow-cam, die op `10` staat).

### Wisselen via Tab

4. Maak een script `CameraSwitch.cs` en koppel dit aan een leeg GameObject:

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineCamera followCam;
    [SerializeField] private CinemachineCamera overviewCam;
    [SerializeField] private InputActionAsset inputAsset;
    private InputAction switchAction;
    private bool overviewActive = false;

    void Awake()
    {
        switchAction = inputAsset.FindActionMap("Player").FindAction("SwitchCamera");
    }

    void OnEnable()  { inputAsset.FindActionMap("Player").Enable(); }
    void OnDisable() { inputAsset.FindActionMap("Player").Disable(); }

    void Update()
    {
        if (switchAction.WasPressedThisFrame())
        {
            overviewActive = !overviewActive;
            followCam.Priority   = overviewActive ? 0  : 10;
            overviewCam.Priority = overviewActive ? 10 : 0;
        }
    }
}
```

5. Voeg `SwitchCamera` toe aan de InputActionAsset met binding **Keyboard/Tab**.
6. Sleep de twee cameras naar de Inspector-velden van het script.

---

## Stap 13 — Blend instellen

De `CinemachineBrain` bepaalt hoe soepel overgangen zijn.

1. Selecteer de **Main Camera**.
2. In het `CinemachineBrain`-component:
   - **Default Blend:** `EaseInOut`
   - **Default Blend Time:** `0.8` seconden

---

## Stap 14 — Testen

1. Druk op **Play**.
2. Beweeg de muis: draait de camera mee (pan links/rechts, tilt omhoog/omlaag)?
3. Loopt de speler weg: volgt de camera hem met damping?
4. Druk op **Tab**: wisselt de camera naar het bovenaanzicht met een vloeiende blend?
5. Loop naar een muur: wijkt de camera naar voren uit (deoccluder)?

---

## Veelgemaakte fouten & oplossingen

| Probleem               | Oorzaak                                   | Oplossing                                |
| ---------------------- | ----------------------------------------- | ---------------------------------------- |
| Camera beweegt niet    | CinemachineBrain ontbreekt op Main Camera | Add Component > CinemachineBrain         |
| Input werkt niet       | Look-actie niet gekoppeld                 | CinemachineInputAxisController instellen |
| Camera gaat door muren | Deoccluder niet ingesteld                 | Add Extension > CinemachineDeoccluder    |
| Overgang niet soepel   | Blend Time = 0                            | CinemachineBrain → Default Blend Time    |
| Pan werkt, tilt niet   | Vertical axis range te klein              | Stel Min/Max in op -30 / 60              |

---

## Controlelijst voor afronding

- [ ] Cinemachine 3 geïnstalleerd via Package Manager
- [ ] CinemachineBrain op de Main Camera aanwezig
- [ ] `CameraTarget` GameObject op borsthoogte van speler aangemaakt
- [ ] `VC_Follow` Virtual Camera met Follow en LookAt ingesteld
- [ ] OrbitalFollow: Camera Distance en Vertical Range ingesteld
- [ ] Look-actie aangemaakt in InputActionAsset (Mouse/Delta)
- [ ] CinemachineInputAxisController gekoppeld aan Look-actie
- [ ] Damping ingesteld voor soepele beweging
- [ ] Recentering ingeschakeld
- [ ] CinemachineDeoccluder toegevoegd
- [ ] `VC_Overview` aangemaakt en schakelbaar via Tab-toets
- [ ] Blend time ingesteld op 0.8 seconden
