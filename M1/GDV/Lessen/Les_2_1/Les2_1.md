# Les 2.1: Scenes, GameObjects en Scriptmatige Beweging

## Wat Ga Je Leren?

In deze les ga je dieper in op de bouwstenen van Unity en leer je hoe je GameObjects kunt besturen met code. Je gaat:

- Scenes en GameObjects beter begrijpen
- Componenten gebruiken en manipuleren
- Je eerste GameObject besturen met een script
- Beweging programmeren met Time.deltaTime
- Het Transform component gebruiken in code

---

## Scenes Revisited - Jouw Game Wereld

### Wat is een Scene?

Een **Scene** is zoals een **toneel** in een theater waar jouw verhaal (game) zich afspeelt.

![theater](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExOGJpbGFkZWVyb2JpYjFidWY4cGo2ZG5xbXU2aWN5bmZ2azhkdjl2OCZlcD12MV9naWZzX3NlYXJjaCZjdD1n/l0HlMSVVw9zqmClLq/giphy.gif)

**In Unity:**

- **Scene** = Een level, menu, of scherm in je game
- **GameObjects** = Alle acteurs, rekwisieten en decorstukken
- **Components** = De eigenschappen en gedragingen van elke "acteur"
- **Scripts** = De instructies die vertellen hoe alles beweegt en reageert

### Scene Hiërarchie Begrijpen

In de **Hierarchy** zie je alle GameObjects in je huidige scene:

```
Scene: "MainLevel"
├── Main Camera          (De ogen van de speler)
├── Directional Light    (Verlichting)
├── Global Volume        (Visuele effecten)
├── Player              (De speler)
├── Enemy               (Een vijand)
└── Collectible         (Een verzamelbaar item)
```

**Belangrijk:** Elke GameObject in de Hierarchy bestaat **alleen** in de huidige scene!

---

## GameObjects - De Bouwstenen

### Alles is een GameObject

Zoals je in Les 1.1 hebt geleerd: **alles in Unity is een GameObject**!

Maar nu gaan we ze besturen met code:

```csharp
// Dit script kan op ELKE GameObject worden geplaatst
public class GameObjectController : MonoBehaviour
{
    void Start()
    {
        // "this.gameObject" verwijst naar het GameObject waar dit script op staat
        Debug.Log("Ik ben GameObject: " + this.gameObject.name);
    }
}
```

### GameObject Properties

Elk GameObject heeft altijd deze eigenschappen:

- **name**: De naam die je ziet in de Hierarchy
- **transform**: Positie, rotatie en schaal
- **activeInHierarchy**: Of het object zichtbaar/actief is

```csharp
void Start()
{
    Debug.Log("Mijn naam: " + gameObject.name);
    Debug.Log("Mijn positie: " + gameObject.transform.position);
    Debug.Log("Ben ik actief? " + gameObject.activeInHierarchy);
}
```

---

## Components - Functionaliteit Toevoegen

### Wat Zijn Components?

**Components** zijn zoals **onderdelen** die je aan een GameObject kunt vastmaken om het speciale eigenschappen te geven.

![lego](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExcmRtOWlhY2Z1bGs3a2ZjY3d6anE1cnozZzloZG15aG5oc2R1bjZhZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/ZtwEXtGMG80xWetwUb/giphy.gif)

**Voorbeelden:**

- **Transform**: Positie, rotatie, schaal
- **Renderer**: Maakt het object zichtbaar
- **Collider**: Detecteert botsingen
- **Rigidbody**: Voegt physics toe (zwaartekracht, etc.)
- **Script**: Jouw eigen gedrag!

### Components in Code Gebruiken

Om een component te gebruiken in je script, moet je er eerst een **referentie** naar krijgen:

```csharp
public class ComponentExample : MonoBehaviour
{
    void Start()
    {
        // Krijg het Transform component (heeft elk GameObject altijd)
        Transform myTransform = this.transform;

        // Krijg het Renderer component (als het bestaat)
        Renderer myRenderer = GetComponent<Renderer>();

        if (myRenderer != null)
        {
            Debug.Log("Ik heb een Renderer component!");
        }
    }
}
```

---

## Transform Component - Positie, Rotatie, Schaal

### Het Belangrijkste Component

Het **Transform** component is het allerbelangrijkste - elk GameObject heeft er altijd één!

Het heeft drie hoofdeigenschappen:

1. **Position** (positie): Waar staat het object?
2. **Rotation** (rotatie): Welke kant wijst het op?
3. **Scale** (schaal): Hoe groot is het?

### Transform in Code

```csharp
public class TransformExample : MonoBehaviour
{
    void Start()
    {
        // Huidige waardes lezen
        Debug.Log("Positie: " + transform.position);
        Debug.Log("Rotatie: " + transform.rotation);
        Debug.Log("Schaal: " + transform.localScale);

        // Waardes veranderen
        transform.position = new Vector3(0, 5, 0);    // Zet op positie x=0, y=5, z=0
        transform.localScale = new Vector3(2, 2, 2);  // Maak 2x groter
    }
}
```

### Vector3 - 3D Posities

`Vector3` is Unity's manier om een positie in 3D ruimte op te slaan:

```csharp
Vector3 positie = new Vector3(x, y, z);
// x = links/rechts
// y = omhoog/omlaag
// z = vooruit/achteruit
```

**Handige Vector3 shortcuts:**

```csharp
Vector3.zero       // (0, 0, 0)
Vector3.up         // (0, 1, 0) - omhoog
Vector3.right      // (1, 0, 0) - rechts
Vector3.forward    // (0, 0, 1) - vooruit
```

---

## Je Eerste Bewegende GameObject

### Stap 1: Bewegingsscript Maken

Maak een nieuw script: `SimpleMovement`

```csharp
public class SimpleMovement : MonoBehaviour
{
    void Update()
    {
        // Beweeg het object langzaam naar rechts
        transform.position = transform.position + Vector3.right * 0.01f;
    }
}
```

### Stap 2: Het Testen

1. **Maak een GameObject** (3D Object → Cube)
2. **Sleep het script** op de Cube
3. **Druk op Play** ▶️

Je Cube beweegt nu naar rechts!

### Probleem: Verschillende Snelheden

**Probleem:** Op snellere computers beweegt het object sneller, op langzamere computers langzamer!

**Oplossing:** `Time.deltaTime`

---

## Time.deltaTime - De Sleutel tot Vloeiende Beweging

### Wat is deltaTime?

`Time.deltaTime` is de **tijd in seconden** sinds het vorige frame.

- Op een snelle computer (60 FPS): deltaTime ≈ 0.016 seconden
- Op een langzame computer (30 FPS): deltaTime ≈ 0.033 seconden

### Waarom is dit Belangrijk?

**Zonder deltaTime:**

```csharp
transform.position += Vector3.right * 0.01f; // Beweegt anders snel op verschillende computers
```

**Met deltaTime:**

```csharp
transform.position += Vector3.right * 2.0f * Time.deltaTime; // Beweegt altijd 2 units per seconde
```

![smooth](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExc201NWNvbHJ0b25wOHNyMGY3b2cxNW52cThsbG9yMDF6NmZid28yYiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/iggzinym5qVh4gLlGx/giphy.gif)

### Verbeterd Bewegingsscript

```csharp
public class SmoothMovement : MonoBehaviour
{
    public float snelheid = 3.0f; // 3 units per seconde

    void Update()
    {
        // Beweeg naar rechts met consistente snelheid
        transform.position += Vector3.right * snelheid * Time.deltaTime;
    }
}
```

---

## Verschillende Soorten Beweging

### 1. Lineaire Beweging

```csharp
public class LinearMovement : MonoBehaviour
{
    public float snelheid = 5.0f;

    void Update()
    {
        // Rechte lijn beweging
        transform.position += Vector3.forward * snelheid * Time.deltaTime;
    }
}
```

### 2. Circulaire Beweging (oftewel draaien)

```csharp
public class CircularMovement : MonoBehaviour
{
    public float rotateSpeed = 90.0f; // graden per seconde

    void Update()
    {
        // Draai rond de Y-as
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
```

### 3. Op en Neer Beweging (of heen en weer)

```csharp
public class BobbingMovement : MonoBehaviour
{
    public float amplitude = 2.0f;    // Hoe hoog/laag (afstand tussen heen en weer)
    public float frequency = 1.0f;    // Hoe snel

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Sine wave (Sinus golf) beweging voor op-en-neer effect
        float newY = startPosition.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
```

![Sine Wave](https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExaml2ZTg4Zmp2a3U1YmNoZ2I1dzRmdWRvaTY2aHZ1YTYwZXcwYnIzZiZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/NKLdcqhwo2f8A/giphy.gif)

---

## Transform Manipulatie Technieken

### Positie Veranderen

```csharp
// Directe toewijzing
transform.position = new Vector3(10, 0, 5);

// Relatieve beweging
transform.position += Vector3.up * 2.0f * Time.deltaTime;

// Translate methode (beweegt relatief)
transform.Translate(Vector3.forward * snelheid * Time.deltaTime);
```

### Rotatie Veranderen

```csharp
// Draai rond eigen assen
transform.Rotate(0, 90 * Time.deltaTime, 0); // Y-as rotatie

// Kijk naar een punt
Vector3 doelPunt = new Vector3(0, 0, 0);
transform.LookAt(doelPunt);

// Directe rotatie instellen
transform.rotation = Quaternion.Euler(new Vector3(0,90*Time.deltaTime,0)); // Y-as rotatie van Vector3 naar Quaternion
```

### Schaal Veranderen

```csharp
// Maak groter
transform.localScale += Vector3.one * Time.deltaTime; // Groeit in alle richtingen

// Specifieke schaal
transform.localScale = new Vector3(2, 1, 2); // Breed, normaal hoog, diep
```

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat is het verschil tussen Scene en GameObject?
- Wat doet het Transform component?
- Waarom is Time.deltaTime belangrijk voor beweging?
- Hoe verander je de positie van een GameObject in code?
- Wat is Vector3 en hoe gebruik je het?
- Welke manieren zijn er om objecten te bewegen?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

## Oefeningen uitvoeren

Doe nu minimaal 1 oefening naar keuze voor les 2.1
De oefeningen vind je [hier](../Oefeningen/oefeningen_2_1.md) terug

![exercise](https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3ZXRrc3QwYWV1Ym5oY2FrZnF5YWxnaW9heTRsNnZzdnpnMmRxeXM1ZiZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/x1BVziEYuKBd1aVZRz/giphy.gif)

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je begrijpt wat Scenes zijn en hoe ze werken
- [ ] Je weet wat Components zijn en hoe je ze gebruikt
- [ ] Je kunt het Transform component manipuleren met code
- [ ] Je begrijpt waarom Time.deltaTime belangrijk is
- [ ] Je kunt GameObjects laten bewegen met scripts
- [ ] Je kent Vector3 en kunt het gebruiken voor posities
- [ ] Je hebt verschillende bewegingspatronen gemaakt
- [ ] Je kunt beweging debuggen met Debug.Log

### Volgende Stap

In Les 2.2 gaan we variabelen en input toevoegen! Dan kun je je bewegende objecten besturen met het toetsenbord.

---

## Veelgestelde Vragen

### Q: Mijn object beweegt veel te snel of te langzaam?

**A:** Pas de snelheidswaarde aan en zorg dat je `Time.deltaTime` gebruikt. Probeer waarden tussen 1.0f en 10.0f voor snelheid.

### Q: Waarom gebruik ik transform.position in plaats van alleen position?

**A:** `transform` verwijst naar het Transform component van je GameObject. Je moet altijd via dit component toegang krijgen tot positie informatie.

### Q: Kan ik een object in een rechte lijn laten bewegen?

**A:** Ja! Gebruik `transform.position += Vector3.forward * snelheid * Time.deltaTime;` voor vooruit, of `Vector3.right` voor zijwaarts.

### Q: Hoe stop ik een bewegend object?

**A:** Zet een boolean variabele (zoals `bool isMoving = false;`) en controleer deze in je Update functie voordat je de beweging uitvoert.

### Q: Mijn object verdwijnt uit beeld, hoe krijg ik het terug?

**A:** Reset de positie: `transform.position = Vector3.zero;` of selecteer het object in de Hierarchy en druk **F** om erop in te zoomen.

### Q: Kan ik meerdere bewegingen combineren?

**A:** Absoluut! Voeg gewoon meerdere bewegingen toe in dezelfde Update functie, of maak meerdere scripts op hetzelfde GameObject.

---
