# Bits and Bytes




Hier is een lesplan om studenten te begeleiden bij het begrijpen en implementeren van de **Bit**-klasse in Unity, die een visuele weergave van een bit simuleert en interactief maakt.


![bit](images/bit.gif)
---

## **Lesplan: Bouw een Interactieve Bit in Unity Stap voor Stap**  
**Doelgroep:** Studenten met basiskennis van Unity en C#  
**Duur:** 60-90 minuten  
**Leerdoelen:**  
✅ Studenten bouwen stap voor stap een interactieve **Bit** in Unity.  
✅ Studenten leren hoe ze kleur en interactie met de muis kunnen implementeren.  
✅ Studenten oefenen met **componenten ophalen, updaten en gebruikersinteractie** in C#.  

---

## **Lesopbouw**

### **1. Introductie (10 min)**
- **Korte uitleg over binaire getallen (0 en 1)**.
- **Concept:** We maken een bit die tussen 0 (rood) en 1 (groen) wisselt bij een muisklik.
- Vraag de studenten: *Hoe zou je dit in Unity kunnen implementeren?*  
  → **Laat ze meedenken over hoe de kleur verandert en hoe de interactie plaatsvindt.**

---

### **2. Opzetten van de Unity Scene (15 min)**
1. **Nieuw Unity 2D-project aanmaken.**
2. **Sprite toevoegen:**
   - Maak een nieuwe **GameObject** (2D Sprite).
   - Gebruik een **vierkante sprite** 
   - Voeg een **BoxCollider2D** component toe (voor muisinteractie).
3. **Nieuw C# script:**  
   - Laat studenten een script aanmaken en **Bit.cs** noemen.
   - Koppel het script aan het **Sprite GameObject**.

---

### **3. Stap voor Stap de Code Opbouwen (20-25 min)**

> **📝 Opdracht:** De studenten schrijven zelf de code op basis van hints.

#### **Stap 1: Startmethode & SpriteRenderer ophalen**
**Vraag:** Hoe krijgen we toegang tot de sprite om de kleur aan te passen?  
👉 **Hint:** Gebruik `GetComponent<SpriteRenderer>()` in de `Start()` methode.

```csharp
public class Bit : MonoBehaviour
{
    SpriteRenderer spriteRenderer; // Variabele om de sprite op te slaan

    void Start()
    {
        // Haal de SpriteRenderer op en sla het op in de variabele
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
```
✅ **Check**: Laat de studenten de code runnen en controleren of er geen fouten zijn.

---

#### **Stap 2: Kleur aanpassen op basis van een bool**
**Vraag:** Hoe kunnen we de kleur van de sprite veranderen?  
👉 **Hint:** Gebruik een **bool** (`state`) en controleer de waarde in `Update()`.

Laat studenten **deze code aanvullen**:

```csharp
public bool state = false; // Houdt de status van de bit bij

void Update()
{
    if (state)
    {
        // Zet de sprite kleur op groen als state true is
        spriteRenderer.color = Color.green;
    }
    else
    {
        // Zet de sprite kleur op rood als state false is
        spriteRenderer.color = Color.red;
    }
}
```
✅ **Check**: Vraag studenten om de code in te vullen en uit te leggen wat er gebeurt.

---

#### **Stap 3: Interactie met de muis (OnMouseUp)**
**Vraag:** Hoe kunnen we de `state` veranderen als de gebruiker klikt?  
👉 **Hint:** Gebruik de **OnMouseUp()** functie.

Laat de studenten **deze code aanvullen**:

```csharp
private void OnMouseUp()
{
    state = !state; // Wissel tussen true en false
}
```
✅ **Check**: Run het project en kijk of klikken de kleur verandert.

---

### **4. Testen en Debuggen (10 min)**
- **Run het spel en klik op de bit.** Werkt de kleurverandering?
- **Mogelijke fouten oplossen:**
  - Kleur verandert niet? → **Check of SpriteRenderer correct wordt opgehaald.**
  - Geen klikinteractie? → **Controleer of er een BoxCollider2D op de sprite zit.**

---

### **5. Afwerking**
- Als de Bit volledig werkt, maak je een nieuwe folder in de map **Prefabs** met als naam **Bit** en daar plaats je zowel het gameobject als het script Bits in, zodat wij dit object bij de komende opdrachten kunnen hergebruiken
- Push de laatste versie naar jouw online respository op github
- lever de link naar deze commit in jouw repo in bij Simulise 

---

### **6. Uitbreiding en Verdieping (15-20 min)**
**Geef studenten uitdagingen om hun kennis te testen en te verdiepen:**
1. **Meer bits toevoegen:**  
   - Maak een **grid van bits** en laat ze onafhankelijk werken.
2. **Status labelen:**  
   - Toon een tekst "0" of "1" boven elke bit.
3. **Geluidseffect toevoegen:**  
   - Speel een geluid af bij elke klik.

**Reflectie:**  
- **Welke nieuwe concepten hebben ze geleerd?**  
- **Hoe kunnen ze dit uitbreiden?**  

---

## **Eindresultaat**
✅ Studenten hebben een **werkende interactieve bit** gebouwd.  
✅ Ze hebben geleerd hoe ze **kleur veranderen, een sprite updaten en interactie toevoegen**.  
✅ Ze kunnen de code uitbreiden met meerdere bits, tekst of geluid.
