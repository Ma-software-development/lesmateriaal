# Les 6.2 — Polishen

## Leerdoel

Na deze les kun je "juice" toevoegen aan je game: particles, sound effects en screen shake.

---

## Theorie

### Wat is Polish/Juice?

Polish maakt het verschil tussen "werkt" en "voelt goed":

| Zonder polish    | Met polish                      |
| ---------------- | ------------------------------- |
| Object verdwijnt | Object explodeert met particles |
| Score +10        | Score +10 met pop-up en geluid  |
| Damage           | Screen shake + flash            |

### Feedback Loop

Goede feedback bevestigt elke actie:

```
Speler actie → Visueel + Audio → Speler voelt bevestiging
```

### Particle Systems

Unity's Particle System voor effecten:

1. GameObject → Effects → Particle System
2. Belangrijke instellingen:
   - Duration: hoe lang het systeem speelt
   - Start Lifetime: levensduur per particle
   - Start Size: grootte
   - Start Color: kleur
   - Emission Rate: hoeveel per seconde

### Particle Effect Spawnen

```csharp
public class EffectSpawner : MonoBehaviour
{
    public ParticleSystem collectEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dot"))
        {
            // Spawn particle op positie
            Instantiate(collectEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
```

### Audio

```csharp
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource audioSource;

    public AudioClip collectSound;
    public AudioClip damageSound;
    public AudioClip powerUpSound;

    void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

// Aanroepen:
SoundManager.Instance.PlaySound(SoundManager.Instance.collectSound);
```

### Screen Shake

```csharp
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    private Vector3 originalPosition;

    void Awake()
    {
        Instance = this;
        originalPosition = transform.position;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeRoutine(duration, magnitude));
    }

    IEnumerator ShakeRoutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = originalPosition + new Vector3(x, y, 0);
            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
```

---

## Oefeningen

### Oefening 1: Collect Effect

Maak een particle effect voor het verzamelen van dots:

**1. Particle System aanmaken:**

- GameObject → Effects → Particle System
- Naam: "CollectParticle"
- Settings:
  - Duration: 0.5
  - Looping: **Off**
  - Start Lifetime: 0.3
  - Start Speed: 3
  - Start Size: 0.2
  - Start Color: Geel/Goud
  - Emission → Bursts: 1 burst van 10 particles
  - Shape: Sphere
  - Renderer → Material: Default-Particle

**2. Prefab maken:**

- Sleep naar Project folder
- Voeg script toe voor auto-destroy:

```csharp
public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 1f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
```

**3. Spawnen bij collect:**
In je Player of Dot script:

```csharp
public ParticleSystem collectEffect;

void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Dot"))
    {
        Instantiate(collectEffect, other.transform.position, Quaternion.identity);
        // ... rest van code
    }
}
```

---

### Oefening 2: Sound Effects

Voeg geluidseffecten toe:

**1. AudioSource toevoegen:**

- Maak leeg GameObject "SoundManager"
- Add Component → Audio Source

**2. Geluiden vinden:**

- [freesound.org](https://freesound.org)
- [opengameart.org](https://opengameart.org)
- Zoek: "collect", "pickup", "coin"

**3. SoundManager script:**

```csharp
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Source")]
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip collectClip;
    public AudioClip damageClip;
    public AudioClip powerUpClip;

    void Awake()
    {
        Instance = this;
    }

    public void PlayCollect()
    {
        sfxSource.PlayOneShot(collectClip);
    }

    public void PlayDamage()
    {
        sfxSource.PlayOneShot(damageClip);
    }
}
```

**4. Aanroepen:**

```csharp
SoundManager.Instance.PlayCollect();
```

**Test:** Je hoort geluid bij het verzamelen van dots.

---

## Toepassing

Voeg polish toe aan je game:

**Checklist:**

| Actie           | Particle | Sound | Screen Effect |
| --------------- | -------- | ----- | ------------- |
| Dot verzamelen  | ✓        | ✓     | -             |
| Power-up pakken | ✓        | ✓     | Flash?        |
| Damage nemen    | ✓        | ✓     | Shake         |
| Enemy verslaan  | ✓        | ✓     | -             |
| Game Over       | ✓        | ✓     | Shake         |

**Bonus ideeën:**

- Score pop-up tekst
- Sprite flash bij damage
- Slow motion bij bijna-dood
- Achtergrondmuziek
