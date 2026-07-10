# Oefeningen Les 2.2: Datatypes, Variabelen en Input

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vind en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een zogenaamde README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst. Een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

---

## Oefening 2.2A: Gaming Stats Dashboard

### Doel

Leer variabelen en datatypes gebruiken door een gaming statistieken systeem te maken.

### Wat ga je doen?

Maak een script dat speler statistieken bijhoudt en toont, zoals een RPG character sheet.

### Stappen

1. **Maak een nieuwe scene** genaamd "StatsSystem"
2. **Maak een script** `PlayerStats.cs`:

```csharp
public class PlayerStats : MonoBehaviour
{
//Tip: Met een header kun je titels plaatsen in de inspector
    [Header("Character Info")]
    public string playerName = "DragonSlayer";
    public int level = 1;
    public string characterClass = "Warrior";
    //add your own stats here

    [Header("Combat Stats")]
    public int health = 100;
    public int maxHealth = 100;
    public int mana = 50;
    public int attack = 25;
    public int defense = 15;
    //add your own stats here

    [Header("Game Progress")]
    public int experience = 0;
    public int gold = 150;
    public float playtimeHours = 2.5f;
    public bool hasCompletedTutorial = true;
    //add your own stats here

    [Header("Inventory")]
    public int healthPotions = 3;
    public int keys = 1;
    public string currentWeapon = "Iron Sword";
    //add your own stats here

    void Start()
    {
        DisplayCharacterSheet();
    }

    void Update()
    {
        // Input om stats te updaten
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Level UP!
            level++;
            maxHealth += 20;
            health = maxHealth; // Full heal bij level up
            attack += 5;
            defense += 3;
            mana += 10;

            Debug.Log("LEVEL UP! Now level " + level);
            Debug.Log("Stats increased!");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Use Health Potion
            if (healthPotions > 0 && health < maxHealth)
            {
                healthPotions--;
                health += 30;
                if (health > maxHealth) health = maxHealth;

                Debug.Log("Used health potion! Health: " + health + "/" + maxHealth);
                Debug.Log("Potions remaining: " + healthPotions);
            }
            else if (healthPotions <= 0)
            {
                Debug.Log("No health potions left!");
            }
            else
            {
                Debug.Log("Health is already full!");
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            DisplayCharacterSheet();
        }
        //Reset Stats here when R is pressed!

    }

    private void DisplayCharacterSheet(){
        //Display Character Sheet
        Debug.Log("=== CHARACTER SHEET ===");
        Debug.Log("Name: " + playerName + " the " + characterClass);
        Debug.Log("Level: " + level);
        Debug.Log("Health: " + health + "/" + maxHealth);
        Debug.Log("Mana: " + mana);
        Debug.Log("Attack: " + attack + " | Defense: " + defense);
        Debug.Log("Experience: " + experience + " XP");
        Debug.Log("Gold: " + gold + " coins");
        Debug.Log("Playtime: " + playtimeHours + " hours");
        Debug.Log("Current Weapon: " + currentWeapon);
        Debug.Log("Items: " + healthPotions + " health potions, " + keys + " keys");
        Debug.Log("Tutorial Complete: " + hasCompletedTutorial);
        Debug.Log("========================");
    }
}
```

3. **Test het systeem:**

   - Hang het script aan de camera en druk op play
   - **L** = Level Up
   - **H** = Use Health Potion
   - **I** = Show Character Sheet

4. **Voeg eigen stats toe:**

   - Voeg bij elke **Header** onderdeel 2 eigen stats toe
   - zorg dat je de volgende datatypes allemaal gebruikt:
     - bool
     - int
     - float
     - string
   - Zorg dat al deze nieuwe stats getoond worden via de I-toets

5. **Maak een stats reset (R) -knop**
   - zorg dat je alle stats op `0` of `""` zet als je op de **R** -toets drukt.
   - Verander de naam van de speler na het drukken in "Noob"

---

## Oefening 2.2B: Streaming Setup Manager

### Doel

Leer variabelen en datatypes gebruiken door een streaming setup te beheren.

### Wat ga je doen?

Maak een script dat je streaming setup bijhoudt zoals een echte streamer dashboard.

### Stappen

1. **Maak een nieuwe scene** genaamd "StreamingSetup"
2. **Maak een script** `StreamingManager.cs`:

```csharp
public class StreamingManager : MonoBehaviour
{
    [Header("Stream Info")]
    public string streamerName = "EpicGamer";
    public string currentGame = "Minecraft";
    public bool isLive = false;

    [Header("Stream Stats")]
    public int viewers = 0;
    public int followers = 1250;
    public float streamTimeHours = 0.0f;
    public int chatMessages = 0;

    [Header("Equipment Status")]
    public bool cameraOn = true;
    public bool microphoneOn = true;
    public int audioLevel = 75;
    public string streamQuality = "1080p";

    [Header("Interaction")]
    public int donations = 0;
    public int subscriberCount = 150;
    public bool moderationMode = false;

    void Start()
    {
        Debug.Log("=== STREAMING SETUP MANAGER ===");
        Debug.Log("Streamer: " + streamerName);
        Debug.Log("Ready to stream: " + currentGame);
        Debug.Log("Controls:");
        Debug.Log("L = Go Live | O = Go Offline | V = Add Viewers");
        Debug.Log("M = Toggle Mic | C = Toggle Camera | I = Show Info");
        Debug.Log("===============================");
    }

    void Update()
    {
        // Update stream time als live
        if (isLive)
        {
            streamTimeHours += Time.deltaTime / 3600f; // Seconden naar uren
        }

        // Input handling
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Go Live
            if (!isLive)
            {
                isLive = true;
                viewers = 5; // Start met wat viewers
                Debug.Log("GOING LIVE! Stream started!");
                Debug.Log("Current viewers: " + viewers);
            }
            else
            {
                Debug.Log("Already live!");
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            // Go Offline
            if (isLive)
            {
                isLive = false;
                Debug.Log("STREAM ENDED! Thanks for watching!");
                Debug.Log("Total stream time: " + streamTimeHours.ToString("F2") + " hours");
                viewers = 0;
            }
            else
            {
                Debug.Log("Not currently streaming!");
            }
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            // Add viewers (simuleer groei)
            if (isLive)
            {
                viewers += 10;
                chatMessages += 5;
                Debug.Log("Viewer boost! Current viewers: " + viewers);
                Debug.Log("Chat is getting active! Messages: " + chatMessages);
            }
            else
            {
                Debug.Log("Need to be live first!");
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            // Toggle microphone
            microphoneOn = !microphoneOn;
            Debug.Log("Microphone: " + (microphoneOn ? "ON" : "MUTED"));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle camera
            cameraOn = !cameraOn;
            Debug.Log("Camera: " + (cameraOn ? "ON" : "OFF"));
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            // Show complete info
            Debug.Log("=== STREAM DASHBOARD ===");
            Debug.Log("Streamer: " + streamerName);
            Debug.Log("Game: " + currentGame);
            Debug.Log("Status: " + (isLive ? "LIVE" : "OFFLINE"));
            Debug.Log("Viewers: " + viewers);
            Debug.Log("Followers: " + followers);
            Debug.Log("Stream Time: " + streamTimeHours.ToString("F2") + " hours");
            Debug.Log("Chat Messages: " + chatMessages);
            Debug.Log("Camera: " + (cameraOn ? "ON" : "OFF"));
            Debug.Log("Mic: " + (microphoneOn ? "ON" : "MUTED"));
            Debug.Log("Audio Level: " + audioLevel + "%");
            Debug.Log("Quality: " + streamQuality);
            Debug.Log("Donations: $" + donations);
            Debug.Log("Subscribers: " + subscriberCount);
            Debug.Log("Moderation: " + (moderationMode ? "ENABLED" : "DISABLED"));
            Debug.Log("=======================");
        }

        // Voeg hier je eigen functionaliteit toe!
    }
}
```

3. **Test het systeem:**

   - Hang het script aan de camera en druk op play
   - **L** = Go Live
   - **O** = Go Offline
   - **V** = Add Viewers
   - **M** = Toggle Microphone
   - **C** = Toggle Camera
   - **I** = Show Dashboard

4. **Voeg eigen functionaliteit toe:**
   Voeg bij elke **Header** onderdeel 2 eigen stats toe

   - zorg dat je de volgende datatypes allemaal gebruikt:
     - bool
     - int
     - float
     - string
   - Zorg dat je nieuwe stats getoond worden in de dashboard (I-toets)

   **Ga Viral! met -V-**
   Zorg dat je Viral gaat met de V-toets. Miljoenen views en volgers met 1 druk op de knop! :)

### Bonus Uitdagingen

- Voeg follower groei toe
- Maak een donation systeem
- Simuleer chat spam protection

---

## Oefening 2.2C: Virtual Pet Basics

### Doel

Maak een eenvoudig virtueel huisdier systeem met basis variabelen.

### Wat ga je doen?

Bouw een simpel Tamagotchi-achtig huisdier dat je kunt verzorgen.

### Stappen

1. **Maak een nieuwe scene** genaamd "VirtualPet"
2. **Maak een Pet GameObject** (Sphere)
3. **Maak script** `SimplePet.cs`:

```csharp
public class SimplePet : MonoBehaviour
{
    [Header("Pet Info")]
    public string petName = "Buddy";
    public string petType = "Dog";
    public int petAge = 1;

    [Header("Pet Needs")]
    public int hunger = 50;      // 0-100
    public int happiness = 70;   // 0-100
    public int energy = 80;      // 0-100

    [Header("Pet Status")]
    public bool isSleeping = false;
    public bool isHungry = false;
    public string mood = "Happy";

    void Start()
    {
        Debug.Log("Meet your new pet: " + petName + " the " + petType);
        Debug.Log("Age: " + petAge + " years old");
        Debug.Log("Controls: F = Feed | P = Play | S = Sleep | I = Info");
        ShowPetInfo();
    }

    void Update()
    {
        // Check pet status
        if (hunger < 30)
        {
            isHungry = true;
            mood = "Hungry";
        }
        else if (energy < 20)
        {
            mood = "Tired";
        }
        else if (happiness > 80)
        {
            mood = "Very Happy";
        }
        else
        {
            mood = "Happy";
            isHungry = false;
        }

        // Input controls
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Feed pet
            if (hunger < 100)
            {
                hunger += 25;
                happiness += 10;
                Debug.Log("Fed " + petName + "! Hunger is now: " + hunger);

                if (hunger > 100) hunger = 100;
                if (happiness > 100) happiness = 100;
            }
            else
            {
                Debug.Log(petName + " is already full!");
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Play with pet
            if (!isSleeping && energy > 10)
            {
                happiness += 20;
                energy -= 15;
                hunger -= 10;
                Debug.Log("Played with " + petName + "! Happiness: " + happiness);

                if (happiness > 100) happiness = 100;
                if (energy < 0) energy = 0;
                if (hunger < 0) hunger = 0;
            }
            else if (isSleeping)
            {
                Debug.Log(petName + " is sleeping!");
            }
            else
            {
                Debug.Log(petName + " is too tired to play!");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Toggle sleep
            isSleeping = !isSleeping;

            if (isSleeping)
            {
                Debug.Log(petName + " is now sleeping...");
                energy += 30;
                if (energy > 100) energy = 100;
            }
            else
            {
                Debug.Log(petName + " woke up!");
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            // Show pet info
            ShowPetInfo();
        }

        // Voeg hier je eigen toets toe!
    }

    void ShowPetInfo()
    {
        Debug.Log("=== PET STATUS ===");
        Debug.Log("Name: " + petName);
        Debug.Log("Type: " + petType);
        Debug.Log("Age: " + petAge + " years");
        Debug.Log("Mood: " + mood);
        Debug.Log("Hunger: " + hunger + "/100");
        Debug.Log("Happiness: " + happiness + "/100");
        Debug.Log("Energy: " + energy + "/100");
        Debug.Log("Sleeping: " + isSleeping);
        Debug.Log("==================");
    }
}
```

4. **Test je pet:**

   - Hang het script aan de camera en druk op play
   - **F** = Feed (verhoogt hunger & happiness)
   - **P** = Play (verhoogt happiness, verlaagt energy & hunger)
   - **S** = Sleep (verhoogt energy)
   - **I** = Show Info

5. **Voeg eigen functionaliteit toe:**
   - Voeg 2 extra variabelen toe (bijvoorbeeld: `petWeight`, `isSick`)
   - Maak een eigen toets (bijvoorbeeld T) die iets doet met je nieuwe variabelen
   - Laat je nieuwe stats zien in `ShowPetInfo()`

### Bonus Uitdagingen

- Laat stats langzaam afnemen over tijd
- Voeg een "health" systeem toe
- Maak verschillende pet types met andere start waardes

---

## Tips voor Alle Oefeningen

### Variable Management

- Gebruik **[Header]** attributes om Inspector variabelen te organiseren
- Maak **public** variabelen voor waarden die je wilt tweaken
- Gebruik **meaningful names** voor je variabelen

### Input Best Practices

- Test **alle input combinations** om bugs te vinden
- Gebruik **GetKeyDown()** voor één-keer acties
- Gebruik **GetKey()** voor continue acties
- Voeg **input feedback** toe via Debug.Log

---
