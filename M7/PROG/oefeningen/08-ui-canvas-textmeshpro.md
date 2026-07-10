# Oefening: UI, Canvas & TextMeshPro

## Leerdoel

Een UI bouwen met Canvas, TextMeshPro en buttons.

---

## Oefening 1: Teller UI

Maak een klik-teller:

1. Maak een Canvas met een TextMeshPro tekst en een Button
2. Maak script `ClickCounter.cs`:

```csharp
using TMPro;

public class ClickCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int count = 0;

    // Koppel deze functie aan de Button via de Inspector
    public void OnButtonClick()
    {
        // TODO: Verhoog count
        // TODO: Update counterText.text met de nieuwe waarde
    }
}
```

**Setup:** Koppel `OnButtonClick` aan de Button via het OnClick event in de Inspector.

**Test:** Elke klik verhoogt het getal op het scherm.

---

## Oefening 2: Health Bar

Maak een health bar met een Slider:

```csharp
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update()
    {
        // TODO: Bij drukken op H, verminder health met 10
        // TODO: Update healthSlider.value
        // TODO: Bij drukken op J, heal 10 (max = maxHealth)
    }
}
```

**Test:** H = damage, J = heal, slider reageert visueel.
