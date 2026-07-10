# Oefeningen Les 1.2: C# Scripting Basics

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vind en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een zogenaamde README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst. Een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

## Oefening 1.2A: Personal Gaming Profile Generator

### Doel

Leer Debug.Log() gebruiken door je gaming profiel in de console te tonen.

### Wat ga je doen?

Maak een script dat jouw gaming informatie toont, zoals een Steam profiel.

### Stappen

1. **Maak een nieuwe scene** genaamd "GamerProfile"
2. **Maak een script** genaamd "GamerProfileDisplay"
3. **Schrijf code in de Start() functie:**

```csharp
void Start()
{
    // Gaming profiel informatie
    Debug.Log("=== GAMING PROFILE ===");
    Debug.Log("Gamer Tag: YourNameHere");
    Debug.Log("Favorite Game: Minecraft");
    Debug.Log("Gaming Platform: PC");
    Debug.Log("Hours Played Today: 3");
    Debug.Log("Current Level: 42");
    Debug.Log("Achievement Unlocked: First Script!");
    Debug.Log("==================");
}
```

4. **Personaliseer het:**

   - Verander alle informatie naar jouw eigen gegevens
   - Voeg 3 extra regels toe met je eigen gaming info

5. **Test het:**
   - Sleep script op Main Camera
   - Druk op Play en check de Console

### Bonus Uitdagingen

- Voeg je top 3 favoriete games toe
- Toon je gaming setup (headset, mouse, keyboard merk)
- Voeg [ASCII art toe](https://www.asciiart.eu/) in de console
- Maak een "loading" effect met verschillende berichten

---

## Oefening 1.2B: Discord Bot Simulator

### Doel

Simuleer een Discord bot die verschillende berichten stuurt met comments.

### Wat ga je doen?

Maak een script dat lijkt op een Discord bot die verschillende commando's uitvoert.

### Stappen

1. **Maak een nieuwe scene** genaamd "DiscordBot"
2. **Maak een script** genaamd "DiscordBotSimulator"
3. **Schrijf dit in Start():**

```csharp
void Start()
{
    // Discord Bot Simulator - versie 1.0
    Debug.Log("🤖 GamerBot is online!");

    // Welkomstbericht
    Debug.Log("📢 Welcome to the server!");

    /*
    Simuleer verschillende bot commando's
    Elke regel doet alsof een user een commando heeft gebruikt
    */

    // Weather commando
    Debug.Log("🌤️ Today's weather: Sunny, 22°C - Perfect gaming weather!");

    // Music commando
    Debug.Log("🎵 Now playing: Minecraft OST - Sweden");

    // Meme commando
    Debug.Log("😂 Random meme: Why did the creeper cross the road? To get to the other ssside!");

    // Server stats
    Debug.Log("📊 Server Stats: 1,337 members online");

    // Game night announcement
    Debug.Log("🎮 Game Night Tonight: Among Us at 20:00!");

    Debug.Log("💤 GamerBot going to sleep mode...");
}
```

4. **Voeg je eigen commando's toe:**
   - Maak 3 extra "bot commando's"
   - Gebruik verschillende emoji's
   - Voeg comments toe die uitleggen wat elk commando doet

### Bonus Uitdagingen

- Maak een Update() functie die elke paar seconden een nieuw bericht stuurt
- Simuleer een "chat" tussen meerdere users
- Voeg tijd stamps toe aan berichten
- Maak "error" berichten voor kapotte commando's

---

## Oefening 1.2C: YouTube Video Logger

### Doel

Maak een script dat doet alsof het YouTube video's afspeelt en logged.

### Wat ga je doen?

Simuleer een YouTube playlist die video informatie toont in de console.

### Stappen

1. **Maak een nieuwe scene** genaamd "YouTubePlayer"
2. **Maak een script** genaamd "VideoPlayer"
3. **Schrijf deze code:**

```csharp
void Start()
{
    /*
    YouTube Gaming Playlist Simulator
    Dit script doet alsof het YouTube video's afspeelt
    */

    Debug.Log("YouTube Gaming Playlist Started");
    Debug.Log("Now Loading...");

    // Video 1 info
    Debug.Log("Playing: 'Minecraft But I Can Only Use Dirt'");
    Debug.Log("Channel: Epic Gaming Channel");
    Debug.Log("Views: 2.3M views");
    Debug.Log("Likes: 145K");
    Debug.Log("Duration: 15:32");

    Debug.Log("---"); // Separator tussen video's

    // Video 2 info
    Debug.Log("Playing: 'Why I Quit Fortnite for Minecraft'");
    Debug.Log("Channel: Honest Gamer");
    Debug.Log("Views: 987K views");
    Debug.Log("Likes: 23K");
    Debug.Log("⏱Duration: 8:45");

    Debug.Log("---");

    // Voeg hier jouw favoriete gaming video toe
    Debug.Log("Playing: 'Your Favorite Gaming Video Here'");
    // Voeg de video details toe...
}

void Update()
{
    // Deze functie wordt elke frame aangeroepen
    // We gaan hier later meer mee doen!
}
```

4. **Personaliseer de playlist:**

   - Voeg 2 extra video's toe van jouw favoriete gaming YouTubers
   - Maak realistische view counts en durations
   - Voeg comments toe die uitleggen wat elke sectie doet

5. **Maak het interactiever:**
   - Voeg "advertisement" berichten toe
   - Simuleer "buffering" berichten
   - Voeg "related videos" suggestions toe

### Bonus Uitdagingen

- Maak een "subscription notification" systeem
- Voeg "comment sectie" simulatie toe
- Maak verschillende playlists (Gaming, Music, Tutorials)
- Simuleer video quality settings

---

## Debug & Testing Tips

### Console Tips

- **Clear button** : Wist alle berichten
- **Collapse** : Groepeert identieke berichten
- **Error Pause** : Pauzeer bij fouten
- **Filter buttons**: Toon alleen bepaalde soorten berichten

### Script Tips

- **Sla altijd op** met Ctrl+S voordat je test
- **Check spelling** - C# is case-sensitive
- **Vergeet geen puntkomma's** (;) aan het einde van regels
- **Gebruik aanhalingstekens** ("") rond tekst

### Foutoplossing

#### Rode lijntjes in code?

- Check spelling van `Debug.Log`
- Controleer of je aanhalingstekens klopt
- Zorg dat elke regel eindigt met ;

#### Script werkt niet?

- Zorg dat script op een GameObject staat
- Check of GameObject actief is (vinkje in Inspector)
- Kijk in Console voor error berichten

#### Berichten verdwijnen snel?

- Zet Console venster groter
- Gebruik de scroll bar om terug te kijken
- Zet "Collapse" uit om alles te zien

---
