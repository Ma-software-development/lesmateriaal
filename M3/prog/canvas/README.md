# 🎨 Canvas in Unity - Uitleg

## 🔹 1. Wat is het Canvas?
Het **Canvas** is een component dat UI-elementen bevat en bepaalt hoe ze worden weergegeven in de game.  
Elk UI-element zoals **Text**, **Button**, en **Image** moet in een **Canvas** zitten om zichtbaar te zijn.

---

## 🔹 2. Canvas Componenten
Een **Canvas** heeft een paar belangrijke eigenschappen die bepalen hoe UI wordt weergegeven:

### 🖥️ Render Mode (Weergavemodus)
Dit bepaalt hoe het Canvas wordt gerenderd:
- **Screen Space - Overlay** (default)  
  ➝ UI wordt bovenop alles weergegeven, ongeacht de camera.  
- **Screen Space - Camera**  
  ➝ UI blijft op een vaste positie in de wereld t.o.v. een specifieke camera.  
- **World Space**  
  ➝ UI-elementen gedragen zich als 3D-objecten in de gamewereld.

### 📏 Canvas Scaler
Dit bepaalt hoe de UI schaalt en resolutie aanpast:
- **Constant Pixel Size** – UI blijft altijd even groot in pixels.  
- **Scale With Screen Size** – UI schaalt mee met het schermformaat.  
- **Constant Physical Size** – UI wordt geschaald op basis van fysieke schermgrootte (bijv. centimeters).

---

## 🔹 3. UI Elementen in een Canvas
Binnen een Canvas kun je UI-elementen plaatsen, zoals:
- **Text** – Voor het weergeven van tekst.  
- **Image** – Voor afbeeldingen en iconen.  
- **Button** – Voor interactieve knoppen.  
- **Panel** – Voor het groeperen van UI-elementen.  
- **Slider & ScrollView** – Voor interactie en navigatie.  

---

## 🔹 4. Hoe UI Positionering Werkt (Rect Transform)
**UI-elementen gebruiken een `Rect Transform` in plaats van een gewone `Transform`.**  
Belangrijke eigenschappen:
- **Anchors** – Bepaalt hoe het element zich aanpast aan het scherm of de parent.  
- **Pivot** – Het draaipunt van het UI-element.  
- **Size Delta** – De grootte van het element.  

Bijvoorbeeld, een knop kan **geankerd** worden aan de onderkant van het scherm, zodat het altijd op dezelfde plek blijft, ongeacht de schermgrootte.

---

## 🔹 5. Interactie met UI (Event System)
Het **Event System** zorgt ervoor dat gebruikers met UI-elementen kunnen interageren. Het wordt meestal gebruikt met:
- **Button.onClick()** – Voer een functie uit wanneer er op een knop wordt geklikt.  
- **Event Triggers** – Gebruik verschillende soorten input zoals slepen, hoveren, etc.  

---

## 🔹 6. UI Dynamisch Aanpassen met Scripts
Je kunt UI-elementen aanpassen met C#-scripts:

```csharp
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScore();
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
