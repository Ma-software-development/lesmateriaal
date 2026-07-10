# Oefening: Score, Timers & Coroutines

## Leerdoel

Score systemen opzetten, timers gebruiken en coroutines toepassen.

---

## Oefening 1: Countdown Timer

Maak een countdown die bij 0 "Game Over" print:

```csharp
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLeft = 30f;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            // TODO: Trek Time.deltaTime af van timeLeft
            // TODO: Update timerText met Mathf.Ceil(timeLeft)
            // TODO: Als timeLeft <= 0, print "Game Over!" en stop timer
        }
    }
}
```

**Test:** Timer telt af van 30 en stopt bij 0.

---

## Oefening 2: Power-Up met Coroutine

Maak een tijdelijke speed boost:

```csharp
public class PowerUp : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostSpeed = 12f;
    public float boostDuration = 3f;

    private float currentSpeed;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Beweging
        float h = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * h * currentSpeed * Time.deltaTime;

        // TODO: Bij drukken op B, start coroutine SpeedBoost
    }

    IEnumerator SpeedBoost()
    {
        // TODO: Zet currentSpeed naar boostSpeed
        // TODO: Print "Boost actief!"
        // TODO: yield return new WaitForSeconds(boostDuration)
        // TODO: Zet currentSpeed terug naar normalSpeed
        // TODO: Print "Boost voorbij"
        yield return null; // Vervang deze regel
    }
}
```

**Test:** Druk op B, speler beweegt 3 seconden sneller en keert terug naar normaal.
