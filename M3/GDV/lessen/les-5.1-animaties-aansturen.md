# Les 5.1 — Controleren van Animaties

## Leerdoel

Na deze les kun je animaties aansturen via code met Animator Controllers en parameters.

---

## Theorie

### Animator Parameters

Parameters besturen welke animatie speelt:

| Type        | Gebruik             | Voorbeeld          |
| ----------- | ------------------- | ------------------ |
| **Float**   | Geleidelijke waarde | Speed, Health      |
| **Int**     | Discrete waarde     | Direction (0-3)    |
| **Bool**    | Aan/uit             | IsGrounded, IsDead |
| **Trigger** | Eenmalige actie     | Attack, Jump       |

### Parameters Instellen via Code

```csharp
private Animator animator;

void Start()
{
    animator = GetComponent<Animator>();
}

void Update()
{
    // Float
    animator.SetFloat("Speed", movement.magnitude);

    // Bool
    animator.SetBool("IsAlive", health > 0);

    // Int
    animator.SetInteger("Direction", currentDirection);

    // Trigger (eenmalig)
    if (Input.GetKeyDown(KeyCode.Space))
    {
        animator.SetTrigger("Attack");
    }
}
```

### Transitions Instellen

In de Animator window:

1. Rechterclick op state → Make Transition
2. Click op destination state
3. Selecteer de pijl (transition)
4. Voeg Condition toe

**Transition settings:**

| Setting             | Waarde      | Uitleg            |
| ------------------- | ----------- | ----------------- |
| Has Exit Time       | Uit         | Direct overgaan   |
| Transition Duration | 0           | Geen blend        |
| Conditions          | Speed > 0.1 | Wanneer triggeren |

### Blend Trees

Voor vloeiende overgangen tussen animaties:

```
        [Blend Tree: Movement]
              /    |    \
           Left  Idle  Right
            -1    0     1
               ←Speed→
```

---

## Oefeningen

### Oefening 1: Richting Animaties

Maak animaties voor 4 richtingen:

**1. Animator Setup:**

- Parameters:
  - Float "Horizontal"
  - Float "Vertical"

**2. States maken:**

- Walk_Up
- Walk_Down
- Walk_Left
- Walk_Right

**3. Transitions:**

- Any State → Walk_Up: Vertical > 0.5
- Any State → Walk_Down: Vertical < -0.5
- Any State → Walk_Left: Horizontal < -0.5
- Any State → Walk_Right: Horizontal > 0.5

**4. Script:**

```csharp
void Update()
{
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");

    animator.SetFloat("Horizontal", h);
    animator.SetFloat("Vertical", v);
}
```

**Test:** De juiste animatie speelt per richting.

---

### Oefening 2: Power-Up Animatie

Voeg een tijdelijke power-up animatie toe:

**1. Maak "Powered" animatie:**

- Andere kleur of glow effect
- Of snellere animatie

**2. Animator setup:**

- Parameter: Bool "IsPowered"
- State: Powered (loop)
- Transition: Any State → Powered (IsPowered = true)
- Transition: Powered → Idle (IsPowered = false)

**3. Script:**

```csharp
public class PowerUpController : MonoBehaviour
{
    private Animator animator;
    private bool isPowered = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivatePowerUp(float duration)
    {
        StartCoroutine(PowerUpRoutine(duration));
    }

    IEnumerator PowerUpRoutine(float duration)
    {
        isPowered = true;
        animator.SetBool("IsPowered", true);

        yield return new WaitForSeconds(duration);

        isPowered = false;
        animator.SetBool("IsPowered", false);
    }
}
```

**Test:** Activeer power-up en zie de animatie veranderen voor X seconden.

---

## Toepassing

Implementeer in je game:

1. **Movement animaties** voor alle richtingen
2. **State animaties:**
   - Normal → Powered (bij power-up)
   - Normal → Hurt (bij damage)
   - Any → Dead (bij game over)

**Bonus:** Maak een Blend Tree voor vloeiendere overgangen tussen richtingen.
