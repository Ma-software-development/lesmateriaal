# Step By Step — Particle Systems & Audio
**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen
- Je kunt een Particle System aanmaken en instellen
- Je kunt een `AudioSource` gebruiken voor 3D ruimtelijk geluid
- Je kunt particles en audio koppelen aan game-events via script

---

## Stap 1 — Particle System aanmaken: stofwolkje bij landing

### Basis aanmaken
1. **GameObject > Effects > Particle System**. Noem het `DustEffect`.
2. Positioneer het op `Y = 0` (vloerhoogte).

### Instellingen aanpassen
Selecteer `DustEffect`. In de Inspector zie je de module-lijst:

**Main module (bovenaan):**
| Instelling | Waarde |
|---|---|
| Duration | 0.5 |
| Looping | ❌ uitvinken |
| Start Lifetime | 0.4 |
| Start Speed | 1.5 |
| Start Size | 0.3 |
| Start Color | lichtgrijs (#C8C8C8) |
| Gravity Modifier | 0.2 |
| Max Particles | 20 |
| Play On Awake | ❌ uitvinken |

**Emission module:**
| Instelling | Waarde |
|---|---|
| Rate over Time | 0 |
| Bursts: klik **+** | Count = 15, Time = 0 |

**Shape module:**
| Instelling | Waarde |
|---|---|
| Shape | Circle |
| Radius | 0.3 |
| Emit from Edge | ✅ |

**Color over Lifetime module: (vink aan)**
- Stel een gradient in: links = grijs (alpha 255), rechts = grijs (alpha 0)  
  *(fade-out effect)*

**Size over Lifetime module: (vink aan)**
- Stel curve in die van klein begint en groter wordt (laaghangend begin, hoge eindwaarde)

3. Maak er een prefab van: sleep naar Project view.

---

## Stap 2 — DustEffect koppelen aan het bewegingsscript

1. Open `MoveCharacterController.cs`.
2. Voeg toe:

```csharp
[Header("Landing Effect")]
[SerializeField] private ParticleSystem dustEffect;
private bool wasGrounded = false;

void Update()
{
    // ... bestaande code ...

    // Landing detecteren: was in de lucht, nu op de grond
    bool grounded = characterController.isGrounded;
    if (grounded && !wasGrounded)
    {
        // Net geland
        if (dustEffect != null)
        {
            dustEffect.transform.position = transform.position;
            dustEffect.Play();
        }
    }
    wasGrounded = grounded;
}
```

3. Sleep `DustEffect` naar het **Dust Effect**-veld in de Inspector van het karakter.

---

## Stap 3 — Particle System positioneren op voeteniveau

1. Maak `DustEffect` een kind van het karakter: sleep het in de Hierarchy onder het karakter-object.
2. Stel de **Local Position** in op Y = 0 (voeteniveau).
3. Controleer in Play mode: speelt het effect op de juiste positie?

> **Tip: Simulation Space**  
> Als je wilt dat de deeltjes loskomen van de speler (niet mee bewegen), zet **Simulation Space** op **World**. Voor effecten die aan het karakter vastzitten, gebruik **Local**.

---

## Stap 4 — 3D AudioSource instellen op een barrel

### AudioSource toevoegen
1. Selecteer een barrel-prefab.
2. **Add Component > Audio > Audio Source**.
3. Stel in:
   - **Audio Clip:** (leeg laten, wordt via script ingesteld)
   - **Play On Awake:** ❌
   - **Spatial Blend:** **1** (volledig 3D)

### Volume Rolloff instellen
4. Scroll naar beneden in de AudioSource-component.
5. Onder **3D Sound Settings**:
   - **Volume Rolloff:** Logarithmic Rolloff (of Custom)
   - **Min Distance:** 1 (max volume tot op 1 meter)
   - **Max Distance:** 15 (na 15 meter geen geluid meer)

### Script: botsinggeluid
6. Maak `BarrelAudio.cs` en voeg het toe aan de barrel-prefab:

```csharp
using UnityEngine;

public class BarrelAudio : MonoBehaviour
{
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private float minForce = 2f;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Alleen geluid als de kracht groot genoeg is
        float force = collision.relativeVelocity.magnitude;
        if (force >= minForce)
        {
            // Volume is afhankelijk van de kracht (max 1.0)
            float volume = Mathf.Clamp01(force / 10f);
            audioSource.PlayOneShot(collisionSound, volume);
        }
    }
}
```

7. Sleep een passende `AudioClip` (botsinggeluid) naar het **Collision Sound**-veld.

---

## Stap 5 — AudioMixer aanmaken

1. In de Project view: **rechtermuisknop > Create > Audio Mixer**. Noem het `MainMixer`.
2. Dubbelklik om de **Audio Mixer**-editor te openen.
3. Je ziet standaard één groep: `Master`.
4. Klik op de **+** naast `Master` om subgroepen toe te voegen:
   - `Music`
   - `SFX`
5. Sla op: **Ctrl + S**.

### AudioSources koppelen aan de Mixer
6. Selecteer de AudioSource van de achtergrondmuziek.
7. In de Inspector: sleep de `Music`-groep van `MainMixer` naar het **Output**-veld.
8. Doe hetzelfde voor alle SFX AudioSources: sleep de `SFX`-groep ernaartoe.

---

## Stap 6 — Volume-sliders in de UI koppelen aan de AudioMixer

### Mixer parameter blootstellen
1. Open de Audio Mixer-editor.
2. Klik op de `Music`-groep.
3. In de Inspector → klik met rechtermuisknop op het **Volume**-veld → **Expose 'Volume' to script**.
4. Klik rechtsboven op **Exposed Parameters** en hernoem de parameter naar `MusicVolume`.
5. Herhaal dit voor de `SFX`-groep → hernoem naar `SFXVolume`.

### UI Sliders aanmaken
6. **GameObject > UI > Slider**. Dupliceer hem voor een tweede.
7. Noem ze `SliderMusic` en `SliderSFX`.
8. Stel de Slider-waarden in: **Min Value = 0.001**, **Max Value = 1**, **Value = 1**.

### VolumeControl-script
9. Maak `VolumeControl.cs`:

```csharp
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void SetMusicVolume(float value)
    {
        // Lineaire slider waarde → dB omrekenen
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }
}
```

> **Waarom `Mathf.Log10`?** Volume in decibel is logaritmisch. Een lineaire slider voelt daardoor vreemd aan. Met de log-formule klinkt een slider op 50% ook als "half zo hard".

10. Koppel de mixer en sliders aan de Inspector-velden.

---

## Stap 7 — Achtergrondmuziek instellen

1. Maak een leeg GameObject: `BackgroundMusic`.
2. **Add Component > Audio > Audio Source**.
3. Stel in:
   - **Audio Clip:** sleep een muziek-`.mp3` of `.wav` hiernaartoe
   - **Play On Awake:** ✅
   - **Loop:** ✅
   - **Spatial Blend:** 0 (2D – geen afstandseffect voor achtergrondmuziek)
   - **Output:** de `Music`-groep van `MainMixer`

---

## Stap 8 — Testen

1. Druk op **Play**.
2. Loop naar een barrel: verschijnt het stofwolkje bij landing?
3. Duw een barrel om: speelt het botsinggeluid?
4. Loop weg van de barrel: wordt het geluid zachter?
5. Draai aan de volume-sliders: verandert het volume van muziek en SFX apart?

---

## Veelgemaakte fouten & oplossingen

| Probleem | Oorzaak | Oplossing |
|---|---|---|
| Particle speelt altijd | Play On Awake staat aan | Zet Play On Awake ❌ uit |
| Particle op verkeerde positie | Simulation Space = Local, positie verkeerd | Zet Simulation Space op World |
| Geen 3D geluid | Spatial Blend = 0 | Zet Spatial Blend op 1 |
| Volume-slider werkt niet | Parameter naam klopt niet | Controleer Exposed Parameter naam in AudioMixer |
| Geen geluid bij botsing | Kracht te klein | Verlaag `minForce` in BarrelAudio |
| Muziek speelt niet | Audio Clip niet ingesteld | Sleep muziekbestand naar Audio Clip |

---

## Controlelijst voor afronding

- [ ] `DustEffect` Particle System aangemaakt met burst, fade-out, juiste grootte
- [ ] Landing gedetecteerd via `wasGrounded` vergelijking
- [ ] DustEffect speelt op voeteniveau
- [ ] AudioSource op barrel: Spatial Blend = 1 (3D geluid)
- [ ] Botsinggeluid speelt alleen bij voldoende kracht
- [ ] Volume wordt zachter op afstand (Rolloff ingesteld)
- [ ] AudioMixer aangemaakt met Master/Music/SFX groepen
- [ ] Achtergrondmuziek gekoppeld aan Music-groep
- [ ] Volume-parameters blootgesteld aan script
- [ ] Volume-sliders werken correct met log-formule
