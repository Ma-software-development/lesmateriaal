## Overzicht Oefeningen

Kies **minimaal 1 oefening** die past bij jouw niveau en interesse.

### Niveaus:

- ⭐ **Beginner** - Je eerste keer met variabelen

  - [Les2.2 Oefening 1B: Level Counter](#les22-oefening-1b-level-counter-)
  - [Les2.2 Oefening 2B: Simple Mover](#les22-oefening-2b-simple-mover-)
  - [Les2.2 Oefening 3B: Size Controller](#les22-oefening-3b-size-controller-)

- ⭐⭐ **Starter** - Je begrijpt variabelen en wilt input

  - [Les2.2 Oefening 4S: Spinner](#les22-oefening-4s-spinner-)
  - [Les2.2 Oefening 5S: Color Changer](#les22-oefening-5s-color-changer-)
  - [Les2.2 Oefening 6S: Power Collector](#les22-oefening-6s-power-collector-)

- ⭐⭐⭐ **Gevorderd** - Je wilt uitdaging met complexe variabelen
  - [Les2.2 Oefening 7G: Multi Control Object](#les22-oefening-7g-multi-control-object-)

---

## Algemene Inlever Instructies

### Voor Elke Oefening:

1. **Script file** - Upload je .cs bestand naar GitHub
2. **README documentatie** - Verwerk je opdracht in je README met titel, beschrijving, gif en code link
3. **GitHub repository** - Zorg dat je project beschikbaar is op GitHub en dat je de link naar je readme hebt ingeleverd op simulise.

### Success Tips:

- Begin met een oefening die past bij jouw niveau en interesse
- Experimenteer gerust met verschillende datatypes
- Test je variabelen door ze te wijzigen in de Inspector
- Vraag hulp als je vastloopt - dat is normaal!

---

## Les2.2 Oefening 1B: Level Counter ⭐

**Thema:** Level System

### Wat Ga Je Maken?

Een simpel level systeem waar je met toetsen je level kunt verhogen/verlagen en het GameObject omhoog/omlaag beweegt!

### Opdracht:

1. Maak een nieuw script: `LevelCounter`
2. Sleep het script op een Cube GameObject
3. Gebruik variabelen en input:

```csharp
public class LevelCounter : MonoBehaviour
{
    // Level variabelen
    public int level = 1;
    public string spelerNaam = "Player";

    // Positie variabelen
    private Vector3 startPositie;

    void Start()
    {
        startPositie = transform.position;

        Debug.Log("=== LEVEL COUNTER ===");
        Debug.Log("Speler: " + spelerNaam);
        Debug.Log("Start Level: " + level);
        Debug.Log("=== CONTROLS ===");
        Debug.Log("Druk op L = Level omhoog");
        Debug.Log("Druk op K = Level omlaag");
        Debug.Log("Druk op Space = Experience");
        Debug.Log("Druk op I = Info tonen");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            level = level + 1;
            Debug.Log("Level omhoog! Nieuw level: " + level);

            // Beweeg GameObject omhoog
            transform.position = startPositie + Vector3.up * level;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            level = level - 1;
            if (level < 1) level = 1; // Niet lager dan level 1

            Debug.Log("Level omlaag! Nieuw level: " + level);

            // Beweeg GameObject omlaag
            transform.position = startPositie + Vector3.up * level;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== INFO ===");
            Debug.Log("Speler: " + spelerNaam);
            Debug.Log("Huidig level: " + level);
            Debug.Log("Positie: " + transform.position);
        }
    }
}
```

### Toevoegingen aan de code:

- Voeg een maximum level toe (bijvoorbeeld 10)
- Maak het GameObject ook groter per level
- Voeg experience points toe die je moet verzamelen door spatie te drukken
- Zorg dat je kubus harder draait naarmate je meer experience hebt
- Zorg dat je meer experience krijgt naar mate je in een hoger level komt
- Laat je experience zien als je op info drukt

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 2B: Simple Mover ⭐

**Thema:** Movement Control

### Wat Ga Je Maken?

Een bewegings controller waar je een GameObject kunt bewegen met WASD toetsen!

### Opdracht:

1. Maak een nieuw script: `SimpleMover`
2. Sleep het script op een GameObject naar keuze
3. Gebruik variabelen en input:

```csharp
public class SimpleMover : MonoBehaviour
{
    // Movement variabelen
    public string objectNaam = "Mover";

    // Positie tracking
    private Vector3 startPositie;
    private float totalAfstand = 0.0f;

    void Start()
    {
        startPositie = transform.position;
        Debug.Log("=== SIMPLE MOVER ===");
        Debug.Log("Object: " + objectNaam);

        Debug.Log("=== CONTROLS ===");
        Debug.Log("WASD = Bewegen");
        Debug.Log("Druk op I = Info");
        Debug.Log("Druk op H = Naar start positie");
    }

    void Update()
    {
        Vector3 oudePositie = transform.position;

        // WASD movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.position + Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.position + Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.position + Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.position + Vector3.right;
        }

        // Bereken afgelegde afstand
        float beweging = Vector3.Distance(oudePositie, transform.position);
        totalAfstand = totalAfstand + beweging;

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== INFO ===");
            Debug.Log("Huidige positie: " + transform.position);
            Debug.Log("Totale afstand: " + totalAfstand);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            transform.position = startPositie;
            totalAfstand = 0.0f;
            Debug.Log("Terug naar start!");
        }
    }
}
```

### Toevoegingen aan de code:

- Voeg Q/E toe voor omhoog/omlaag bewegen
- Maak een variabele voor de snelheid die je in kunt stellen in de inspector
- Maak het object 2x sneller met wanneer je Shift inhoud

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 3B: Size Controller ⭐

**Thema:** Scale Control

### Wat Ga Je Maken?

Een grootte controller waar je een GameObject groter en kleiner kunt maken met toetsen!

### Opdracht:

1. Maak een nieuw script: `SizeController`
2. Sleep het script op een Cube
3. Gebruik variabelen en input:

```csharp
public class SizeController : MonoBehaviour
{
    // Size variabelen
    public float grootte = 1.0f;
    public float verandering = 0.1f;
    public string objectNaam = "Scaler";

    // Schaal tracking
    private Vector3 startSchaal;

    void Start()
    {
        startSchaal = transform.localScale;

        Debug.Log("=== SIZE CONTROLLER ===");
        Debug.Log("Object: " + objectNaam);
        Debug.Log("Start grootte: " + grootte);
        Debug.Log("=== CONTROLS ===");
        Debug.Log("Druk op + = Groter");
        Debug.Log("Druk op - = Kleiner");
        Debug.Log("Druk op R = Reset grootte");
        Debug.Log("Druk op I = Info");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
        {
            grootte = grootte + verandering;
            Debug.Log("Groter! Nieuwe grootte: " + grootte);

            // Pas schaal aan
            transform.localScale = startSchaal * grootte;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            grootte = grootte - verandering;
            if (grootte < 0.1f) grootte = 0.1f; // Niet te klein

            Debug.Log("Kleiner! Nieuwe grootte: " + grootte);

            // Pas schaal aan
            transform.localScale = startSchaal * grootte;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            grootte = 1.0f;
            transform.localScale = startSchaal;
            Debug.Log("Grootte gereset!");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== INFO ===");
            Debug.Log("Huidige grootte: " + grootte);
            Debug.Log("Huidige schaal: " + transform.localScale);
        }


    }
}
```

### Toevoegingen aan de code:

- Voeg maximum en minimum grootte toe
- Roteer het object met de pijltjes (links en rechts)
- Verplaats het object omhoog en omlaag met de pijltjes (omhoog en omlaag)

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 4S: Spinner ⭐⭐

**Thema:** Rotation Control

### Wat Ga Je Maken?

Een draai controller waar je een GameObject kunt laten draaien met toetsen!

### Opdracht:

1. Maak een nieuw script: `Spinner`
2. Sleep het script op een GameObject naar keuze
3. Gebruik variabelen en input:

```csharp
public class Spinner : MonoBehaviour
{
    // Rotatie variabelen
    public float draaiSnelheid = 45.0f; // graden per seconde
    public bool isDraaiend = false;
    public string spinnerNaam = "Spinner";

    // Rotatie tracking
    private float totalRotatie = 0.0f;

    void Start()
    {
        Debug.Log("=== SPINNER ===");
        Debug.Log("Spinner: " + spinnerNaam);
        Debug.Log("Draai snelheid: " + draaiSnelheid + " graden/sec");
        Debug.Log("=== CONTROLS ===");
        Debug.Log("Spatie = Start/Stop draaien");
        Debug.Log("Druk op L = Draai links");
        Debug.Log("Druk op R = Draai rechts");
        Debug.Log("Druk op I = Info");
    }

    void Update()
    {
        // Automatisch draaien als isDraaiend true is
        if (isDraaiend)
        {
            float rotatie = draaiSnelheid * Time.deltaTime;
            transform.Rotate(0, rotatie, 0);
            totalRotatie = totalRotatie + rotatie;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDraaiend = !isDraaiend; // Wissel tussen true en false

            if (isDraaiend)
            {
                Debug.Log("Start met draaien!");
            }
            else
            {
                Debug.Log("Stop met draaien!");
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.Rotate(0, -45, 0); // 45 graden naar links
            totalRotatie = totalRotatie + 45;
            Debug.Log("Draai naar links!");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0, 45, 0); // 45 graden naar rechts
            totalRotatie = totalRotatie + 45;
            Debug.Log("Draai naar rechts!");
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== INFO ===");
            Debug.Log("Is draaiend: " + isDraaiend);
            Debug.Log("Totale rotatie: " + totalRotatie + " graden");
            Debug.Log("Huidige rotatie: " + transform.rotation.eulerAngles);
        }
    }
}
```

### Toevoegingen aan de code:

- Voeg sneller/langzamer draaien toe met toetsen (UP en Down)
- Zorg voor een minimum en maximum draaisnelheid
- Wissel de as waarover het object draait als je op de ENTER drukt
- Zorg dat je bij de info ook ziet op welke as je draait
- Tel hoeveel volledige rondes (360 graden) het object heeft gemaakt
- Laat bij info zien hoeveel rondjes je hebt gedraaid

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 5S: Color Changer ⭐⭐

**Thema:** Visual Effects

### Wat Ga Je Maken?

Een kleuren veranderaar waar je met toetsen de kleur van het GameObject kunt veranderen en het object reageert op de kleurwisselingen!

### Opdracht:

1. Maak een nieuw script: `ColorChanger`
2. Sleep het script op een GameObject
3. Gebruik variabelen en input:

```csharp
public class ColorChanger : MonoBehaviour
{
    // Kleur variabelen
    public string huidigeKleur = "Wit";
    public int aantalKleurWisselingen = 0;

    // Visuele effecten
    private Vector3 startPositie;
    private Vector3 startSchaal;

    void Start()
    {
        startPositie = transform.position;
        startSchaal = transform.localScale;

        Debug.Log("=== COLOR CHANGER ===");
        Debug.Log("Start kleur: " + huidigeKleur);
        Debug.Log("=== CONTROLS ===");
        Debug.Log("Druk op R = Rood");
        Debug.Log("Druk op G = Groen");
        Debug.Log("Druk op B = Blauw");
        Debug.Log("Druk op Y = Geel");
        Debug.Log("Druk op W = Wit");
        Debug.Log("Druk op I = Info");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer>().material.color = Color.red;
            huidigeKleur = "Rood";
            aantalKleurWisselingen = aantalKleurWisselingen + 1;
            Debug.Log("Kleur veranderd naar: " + huidigeKleur);

            // Beweeg naar links bij rood
            transform.position = startPositie + Vector3.left * 2;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
            huidigeKleur = "Groen";
            aantalKleurWisselingen = aantalKleurWisselingen + 1;
            Debug.Log("Kleur veranderd naar: " + huidigeKleur);

            // Beweeg omhoog bij groen
            transform.position = startPositie + Vector3.up * 2;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
            huidigeKleur = "Blauw";
            aantalKleurWisselingen = aantalKleurWisselingen + 1;
            Debug.Log("Kleur veranderd naar: " + huidigeKleur);

            // Beweeg naar rechts bij blauw
            transform.position = startPositie + Vector3.right * 2;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            huidigeKleur = "Geel";
            aantalKleurWisselingen = aantalKleurWisselingen + 1;
            Debug.Log("Kleur veranderd naar: " + huidigeKleur);

            // Word groter bij geel
            transform.localScale = startSchaal * 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Renderer>().material.color = Color.white;
            huidigeKleur = "Wit";
            Debug.Log("Kleur veranderd naar: " + huidigeKleur);

            // Reset positie en schaal bij wit
            transform.position = startPositie;
            transform.localScale = startSchaal;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== INFO ===");
            Debug.Log("Huidige kleur: " + huidigeKleur);
            Debug.Log("Aantal kleurwisselingen: " + aantalKleurWisselingen);
            Debug.Log("Positie: " + transform.position);
            Debug.Log("Schaal: " + transform.localScale);
        }
    }
}
```

### Toevoegingen aan de code:

- Voeg meer kleuren toe (paars, oranje, zwart)
- Maak het object groter elke keer als je van kleur wisselt
- Voeg een "regenboog" modus toe die alle kleuren doorloopt
- Zorg dat het blokje blijft roteren in regenboog modus
- Zorg dat je na 10x kleuren wisselen in de regenboog modus gaat

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 6S: Power Collector ⭐⭐

**Thema:** Collection System

### Wat Ga Je Maken?

Een power collector waar je energie kunt verzamelen en uitgeven, en het GameObject reageert op je energie level!

### Opdracht:

1. Maak een nieuw script: `PowerCollector`
2. Sleep het script op een GameObject naar keuze
3. Gebruik variabelen en input:

```csharp
public class PowerCollector : MonoBehaviour
{
    // Power variabelen
    public int energie = 50;
    public int maxEnergie = 100;
    public string collectorNaam = "Power Collector";

    // Visual feedback variabelen
    private Vector3 startPositie;
    private Vector3 startSchaal;

    void Start()
    {
        startPositie = transform.position;
        startSchaal = transform.localScale;

        UpdateVisuals();

        Debug.Log("=== POWER COLLECTOR ===");
        Debug.Log("Collector: " + collectorNaam);
        Debug.Log("Start energie: " + energie + "/" + maxEnergie);
        Debug.Log("=== CONTROLS ===");
        Debug.Log("Druk op E = Verzamel energie (+10)");
        Debug.Log("Druk op Q = Gebruik energie (-5)");
        Debug.Log("Druk op F = Fire power! (-20)");
        Debug.Log("Druk op R = Reset energie");
        Debug.Log("Druk op I = Info");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            energie = energie + 10;
            if (energie > maxEnergie) energie = maxEnergie; // Niet hoger dan maximum

            Debug.Log("Energie verzameld! Huidige energie: " + energie);
            UpdateVisuals();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (energie >= 5)
            {
                energie = energie - 5;
                Debug.Log("Energie gebruikt! Huidige energie: " + energie);
                UpdateVisuals();
            }
            else
            {
                Debug.Log("Onvoldoende energie!");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (energie >= 20)
            {
                energie = energie - 20;
                Debug.Log("FIRE POWER! Energie: " + energie);

                // Special fire effect - spring omhoog en draai
                transform.position = startPositie + Vector3.up * 3;
                transform.Rotate(0, 180, 0);

                UpdateVisuals();
            }
            else
            {
                Debug.Log("Onvoldoende energie voor Fire Power! (20 nodig)");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            energie = 50; // Reset naar start waarde
            Debug.Log("Energie gereset naar: " + energie);

            // Reset positie en rotatie
            transform.position = startPositie;
            transform.rotation = Quaternion.identity;

            UpdateVisuals();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== POWER INFO ===");
            Debug.Log("Collector: " + collectorNaam);
            Debug.Log("Energie: " + energie + "/" + maxEnergie);

            // Bereken percentage
            float percentage = (energie * 100.0f) / maxEnergie;
            Debug.Log("Energie percentage: " + percentage + "%");

            // Status bepalen
            if (energie > 80)
            {
                Debug.Log("Status: HOGE ENERGIE!");
            }
            else if (energie > 40)
            {
                Debug.Log("Status: Gemiddelde energie");
            }
            else
            {
                Debug.Log("Status: Lage energie - verzamel meer!");
            }
        }

        // Langzaam terugkeren naar start positie
        transform.position = Vector3.Lerp(transform.position, startPositie, Time.deltaTime * 2.0f);
    }

    void UpdateVisuals()
    {
        // Verander grootte gebaseerd op energie level
        float schaalFactor = 0.5f + (energie / 100.0f); // Tussen 0.5 en 1.5
        transform.localScale = startSchaal * schaalFactor;

        // Verander kleur gebaseerd op energie level
        Renderer objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            if (energie > 80)
            {
                objectRenderer.material.color = Color.green; // Hoge energie = groen
            }
            else if (energie > 40)
            {
                objectRenderer.material.color = Color.yellow; // Gemiddeld = geel
            }
            else if (energie > 20)
            {
                objectRenderer.material.color = Color.red; // Laag = rood
            }
            else
            {
                objectRenderer.material.color = Color.black; // Zeer laag = zwart
            }
        }
    }
}
```

### Toevoegingen aan de code:

- Voeg een "super power" toe die 50 energie kost
- Zorg dat de energie automatisch langzaam afneemt over tijd
- Laat het object automatisch draaien als de energie vol is
- krimp het object naar een scale van 0.01f als de energy op is

#### Bonus:

- Door de "super power" moet het object rood knipperen en pulseren (groot klein)

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)

---

## Les2.2 Oefening 7G: Multi Control Object ⭐⭐⭐

**Thema:** Combined Controls

### Wat Ga Je Maken?

Een object dat je volledig kunt besturen: bewegen, grootte veranderen, draaien en kleur veranderen!

### Opdracht:

1. Maak een nieuw script: `MultiController`
2. Sleep het script op een GameObject naar keuze
3. Gebruik alle technieken samen:

```csharp
public class MultiController : MonoBehaviour
{
    // Object info
    public string objectNaam = "Multi Controller";

    // Movement
    public float bewegingsSnelheid = 3.0f;
    private Vector3 startPositie;

    // Scale
    public float grootte = 1.0f;
    private Vector3 startSchaal;

    // Rotation
    public float draaiSnelheid = 90.0f;
    public bool isDraaiend = false;

    // Color
    public string huidigeKleur = "Wit";

    // Stats
    private float totalAfstand = 0.0f;
    private float totalRotatie = 0.0f;

    void Start()
    {
        startPositie = transform.position;
        startSchaal = transform.localScale;

        Debug.Log("=== MULTI CONTROLLER ===");
        Debug.Log("Object: " + objectNaam);
        Debug.Log("=== CONTROLS ===");
        Debug.Log("WASD = Bewegen");
        Debug.Log("+/- = Grootte");
        Debug.Log("Spatie = Draaien aan/uit");
        Debug.Log("1-5 = Kleuren");
        Debug.Log("R = Reset alles");
        Debug.Log("I = Info");
    }

    void Update()
    {
        // MOVEMENT
        Vector3 oudePositie = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + Vector3.forward * bewegingsSnelheid * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + Vector3.back * bewegingsSnelheid * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * bewegingsSnelheid * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * bewegingsSnelheid * Time.deltaTime;
        }

        // Track afstand
        totalAfstand = totalAfstand + Vector3.Distance(oudePositie, transform.position);

        // SIZE
        if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.Equals))
        {
            grootte = grootte + 0.2f;
            transform.localScale = startSchaal * grootte;
            Debug.Log("Groter! Grootte: " + grootte);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            grootte = grootte - 0.2f;
            if (grootte < 0.2f) grootte = 0.2f;
            transform.localScale = startSchaal * grootte;
            Debug.Log("Kleiner! Grootte: " + grootte);
        }

        // ROTATION
        if (isDraaiend)
        {
            float rotatie = draaiSnelheid * Time.deltaTime;
            transform.Rotate(0, rotatie, 0);
            totalRotatie = totalRotatie + rotatie;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDraaiend = !isDraaiend;
            Debug.Log("Draaien: " + isDraaiend);
        }

        // COLORS
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponent<Renderer>().material.color = Color.red;
            huidigeKleur = "Rood";
            Debug.Log("Kleur: " + huidigeKleur);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<Renderer>().material.color = Color.green;
            huidigeKleur = "Groen";
            Debug.Log("Kleur: " + huidigeKleur);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<Renderer>().material.color = Color.blue;
            huidigeKleur = "Blauw";
            Debug.Log("Kleur: " + huidigeKleur);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            huidigeKleur = "Geel";
            Debug.Log("Kleur: " + huidigeKleur);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GetComponent<Renderer>().material.color = Color.white;
            huidigeKleur = "Wit";
            Debug.Log("Kleur: " + huidigeKleur);
        }

        // RESET
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPositie;
            transform.localScale = startSchaal;
            transform.rotation = Quaternion.identity;
            grootte = 1.0f;
            isDraaiend = false;
            totalAfstand = 0.0f;
            totalRotatie = 0.0f;
            GetComponent<Renderer>().material.color = Color.white;
            huidigeKleur = "Wit";
            Debug.Log("Alles gereset!");
        }

        // INFO
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== OBJECT INFO ===");
            Debug.Log("Positie: " + transform.position);
            Debug.Log("Grootte: " + grootte);
            Debug.Log("Kleur: " + huidigeKleur);
            Debug.Log("Draaiend: " + isDraaiend);
            Debug.Log("Totale afstand: " + totalAfstand);
            Debug.Log("Totale rotatie: " + totalRotatie + " graden");
        }
    }
}
```

### Toevoegingen aan de code:

- Pas de code aan zodat deze werkt met Input.GetAxis()
- Maak presets (T-toets zet alles op een vooraf ingestelde configuratie)
- Voeg een "random" modus toe die alles willekeurig verandert

### Inlever Vereisten:

Verwerk je opdracht in je README. Deze bevat de titel van de opdracht, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[Zie voorbeeld format](../README.md#Voorbeeld-README-Opdracht-Format)
