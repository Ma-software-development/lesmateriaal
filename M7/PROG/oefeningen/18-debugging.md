# Oefening 18 — Debugging

**Onderwerp:** Breakpoints, Debug.Log en veelvoorkomende fouten  
**Module:** M5

---

## Oefening 18a — Bug opsporen met Debug.Log

Een script werkt niet zoals verwacht. Gebruik `Debug.Log` om de bug te vinden en op te lossen.

```csharp
using UnityEngine;

public class BuggyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth += amount; // BUG: hier klopt iets niet
        Debug.Log("Health: " + currentHealth);

        if (currentHealth < 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " is dood!");
        Destroy(gameObject);
    }
}
```

**Opdracht:**

1. Maak dit script aan en koppel het aan een GameObject.
2. Roep `TakeDamage(25)` aan vanuit een ander script of via een button.
3. Lees de console-output — klopt de health-waarde?
4. Fix de bug en voeg extra `Debug.Log`-regels toe om de flow te controleren.
5. **Bonus:** Voeg een check toe zodat health niet onder 0 kan zakken (`Mathf.Clamp`).

---

## Oefening 18b — NullReferenceException oplossen

Het volgende script gooit een foutmelding. Zoek de oorzaak en los het op.

```csharp
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text scoreText;
    private int score = 0;

    void Start()
    {
        // scoreText is niet toegewezen!
        UpdateDisplay();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
```

**Opdracht:**

1. Maak een UI Text (TMP) aan in je scene.
2. Voeg het script toe en **druk op Play** — lees de foutmelding in de Console.
3. Begrijp wat `NullReferenceException` betekent.
4. Los het probleem op door:
   - `scoreText` als `[SerializeField]` te markeren en via de Inspector toe te wijzen, **of**
   - `GetComponent<TMP_Text>()` of `FindObjectOfType<TMP_Text>()` te gebruiken in `Start()`.
5. Voeg een null-check toe als vangnet:
   ```csharp
   if (scoreText == null)
   {
       Debug.LogWarning("ScoreText is niet toegewezen!");
       return;
   }
   ```
