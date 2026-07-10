# Step By Step — Raycast: Schieten & Obstakels Detecteren

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt een raycast-gebaseerd shoot-systeem bouwen
- Je begrijpt Layer Masks voor gefilterde raycasts
- Je kunt visuele feedback geven via `LineRenderer`

---

## Stap 1 — Shoot-actie toevoegen aan Input

1. Open `PlayerInput.inputactions`.
2. Selecteer de `Player` Action Map.
3. Klik **+ (Add Action)**. Noem het `Shoot`.
4. **Action Type:** Button.
5. Voeg Binding toe: **Mouse/Left Button**.
6. Klik **Save Asset**.

---

## Stap 2 — Layers instellen voor collision filtering

Met Layers kun je bepalen welke objecten een Raycast kan raken.

1. Ga naar **Edit > Project Settings > Tags and Layers**.
2. Voeg onder **Layers** toe:
   - Layer 6: `Shootable`
   - Layer 7: `Player`
3. Selecteer alle barrel-prefabs in de Hierarchy.
4. Zet hun **Layer** (rechtsboven in Inspector) op `Shootable`.
5. Selecteer het spelerpersonage. Zet de **Layer** op `Player`.

> **Waarom layers?** Zodat de speler zichzelf niet kan raken met zijn eigen Raycast.

---

## Stap 3 — IDamageable interface aanmaken

Een interface zorgt dat elk object schade kan ontvangen, ongeacht het type.

1. Maak een nieuw C#-script: `IDamageable.cs`.
2. Vervang de inhoud volledig:

```csharp
public interface IDamageable
{
    void TakeDamage(int amount);
}
```

3. Sla op. (Geen MonoBehaviour nodig — dit is een interface.)

---

## Stap 4 — Barrel-script aanmaken: BreakableBarrel.cs

1. Maak `BreakableBarrel.cs` en koppel het aan de barrel-prefab.

```csharp
using UnityEngine;

public class BreakableBarrel : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioClip explosionSound;

    private int currentHealth;
    private Renderer rend;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponentInChildren<Renderer>();
        originalColor = rend.material.color;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Korte kleur-flash als visuele feedback
        StopAllCoroutines();
        StartCoroutine(DamageFlash());

        if (currentHealth <= 0)
            Die();
    }

    private System.Collections.IEnumerator DamageFlash()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColor;
    }

    private void Die()
    {
        if (explosionEffect != null)
        {
            ParticleSystem effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            effect.Play();
            Destroy(effect.gameObject, effect.main.duration);
        }

        if (explosionSound != null)
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        Destroy(gameObject);
    }
}
```

---

## Stap 5 — Shoot-script aanmaken: ShootSystem.cs

Koppel dit script aan de **speler** of de **camera**:

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
    [SerializeField] private int damage = 1;

    [Header("Visueel")]
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
        // Debug ray in Scene view
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

            // Schade toepassen via interface
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damage);

            // Visuele lijn tonen
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

---

## Stap 6 — LineRenderer instellen

1. Selecteer het speler-GameObject.
2. **Add Component > Effects > Line Renderer**.
3. Stel in:
   - **Positions:** Size = 2 (twee punten: begin en einde)
   - **Width:** 0.05
   - **Color:** rood (beide einden)
   - **Material:** gebruik `Default-Line` of maak een rood Unlit-materiaal
   - **Use World Space:** ✅
4. Zet **Enabled** initieel op ❌ (het script zet het aan bij een schot).
5. Sleep de `LineRenderer` naar het **Line Renderer**-veld in het script.

---

## Stap 7 — ShootOrigin instellen

1. Maak een leeg GameObject als kind van de Camera of het karakter: `ShootOrigin`.
2. Positioneer het op de loop van een denkbeeldig wapen, of gewoon op de camera-positie.
3. Zorg dat de **forward-richting** (blauwe pijl in Scene view) de schietrichting aangeeft.
4. Sleep `ShootOrigin` naar het **Shoot Origin**-veld.

---

## Stap 8 — Shootable Layer Mask instellen

1. Selecteer het `ShootSystem`-component in de Inspector.
2. Klik op het **Shootable Layers**-dropdown.
3. Vink **alleen** `Shootable` aan.

> Dit zorgt dat de Raycast alleen objecten op de `Shootable`-layer raakt, dus nooit de speler zelf.

---

## Stap 9 — Barrel prefab instellen

1. Open de barrel-prefab.
2. Voeg `BreakableBarrel.cs` toe.
3. Zet de Layer op `Shootable`.
4. Koppel een `ParticleSystem` en `AudioClip` voor het explosie-effect.
5. Sla de prefab op.

---

## Stap 10 — Shooting range bouwen

1. Maak een rij van 5 barrels op afstand (bijv. 10–20 meter voor de speler).
2. Druk **Play** en test het schieten:
   - Raken de barrels?
   - Knipperen ze rood?
   - Ontploffen ze na 3 treffers?
   - Is de LineRenderer kort zichtbaar?

---

## Stap 11 — Score UI koppelen (bonus)

Voeg toe aan `ShootSystem.cs`:

```csharp
[Header("UI")]
[SerializeField] private TMPro.TextMeshProUGUI scoreText;
private int score = 0;

// In de Die()-methode van BreakableBarrel, of via een event:
public void AddScore(int points)
{
    score += points;
    if (scoreText != null)
        scoreText.text = $"Score: {score}";
}
```

Of gebruik een simpele `static int` in een `GameManager`-klasse.

---

## Veelgemaakte fouten & oplossingen

| Probleem                      | Oorzaak                          | Oplossing                                                       |
| ----------------------------- | -------------------------------- | --------------------------------------------------------------- |
| Ray raakt niets               | Layer Mask niet ingesteld        | Vink `Shootable` aan bij Layer Mask                             |
| Speler beschiet zichzelf      | Player-layer staat in Layer Mask | Verwijder `Player` uit de Layer Mask                            |
| Barrel gaat niet kapot        | `IDamageable` niet gevonden      | Zorg dat `BreakableBarrel` op hetzelfde object zit als Collider |
| LineRenderer blijft zichtbaar | Coroutine werkt niet             | Controleer `StartCoroutine(HideLine())`                         |
| Flash werkt niet              | Material is Shared Material      | Gebruik `rend.material` (niet `sharedMaterial`)                 |

---

## Controlelijst voor afronding

- [ ] `Shoot`-actie aangemaakt met Mouse Left Button binding
- [ ] `Shootable` en `Player` Layers aangemaakt
- [ ] `IDamageable` interface aangemaakt
- [ ] `BreakableBarrel.cs` koppelt `IDamageable` en heeft HP
- [ ] `ShootSystem.cs` gebruikt Layer Mask en roept `TakeDamage()` aan
- [ ] LineRenderer toont kort de kogelbaan (rood, 0.1 seconde)
- [ ] Barrel knippert rood bij treffer
- [ ] Barrel ontploft bij 0 HP met particle + geluid
- [ ] Speler kan zichzelf niet raken
- [ ] Shooting range: 5 barrels op een rij
