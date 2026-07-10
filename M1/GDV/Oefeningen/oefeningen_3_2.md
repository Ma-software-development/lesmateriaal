# Oefeningen Les 3.2: Functies, Argumenten en Return Types

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vindt en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

---

## Oefening 3.2A: Muziek Speler Functies

### Doel

Oefen met functies, argumenten en return types door een simpele muziekspeler te maken.

### Wat ga je doen?

Je maakt een script dat verschillende muziekfuncties bevat, zoals play, stop en volume aanpassen.

### Stappen

1. **Maak een nieuwe scene** genaamd "MusicPlayer"
2. **Maak een script** `MusicPlayer.cs` met minimaal deze functies:
   - `void PlaySong(string songName)`
   - `void StopSong()`
   - `void SetVolume(float volume)`
   - `string GetCurrentSong()`
   - `bool IsPlaying()`
3. **Roep de functies aan** in `Start()` en/of via toetsen (bijvoorbeeld P = Play, S = Stop, V = Volume).
4. **Gebruik Debug.Log** om te laten zien wat er gebeurt. **Er hoeft dus niet echt muziek af te spelen!**
5. **Test het systeem** door verschillende functies aan te roepen en te combineren.

#### Voorbeeld Console Output

```
Playing song: Minecraft OST - Sweden
Current song: Minecraft OST - Sweden
Volume set to: 0.8
Is playing: True
Song stopped.
Is playing: False
```

### Bonus Uitdagingen

- Voeg een functie toe die een random song kiest.
- Maak een functie die het aantal afgespeelde nummers bijhoudt.
- Voeg een "mute/unmute" functie toe.

---

## Oefening 3.2B: Sport Score Calculator

### Doel

Oefen met return types en argumenten door een score calculator voor een sportwedstrijd te maken.

### Wat ga je doen?

Je maakt een script dat punten toevoegt, de winnaar bepaalt en statistieken toont via functies.

### Stappen

1. **Maak een nieuwe scene** genaamd "ScoreCalculator"
2. **Maak een script** `ScoreCalculator.cs` met minimaal deze functies:
   - `void AddPoints(string team, int points)`
   - `int GetScore(string team)`
   - `string GetWinner()`
   - `void ResetScores()`
3. **Roep de functies aan** in `Start()` en/of via toetsen (bijvoorbeeld A = Add Points Team A, B = Add Points Team B, W = Winner).
4. **Gebruik Debug.Log** om de scores en winnaar te tonen.
5. **Test het systeem** door punten toe te voegen en de winnaar te bepalen.

#### Voorbeeld Console Output

```
Added 3 points to Team A
Team A score: 3
Added 2 points to Team B
Team B score: 2
Current winner: Team A
Scores reset!
Team A score: 0
Team B score: 0
Current winner: Draw
```

### Bonus Uitdagingen

- Voeg een functie toe die de scoregeschiedenis toont.
- Maak een functie die een gelijkspel detecteert.
- Voeg een "highscore" functie toe.

---

## Oefening 3.2C: Fantasy Spellbook

### Doel

Oefen met functies en return types door een magisch spellbook te maken.

### Wat ga je doen?

Je maakt een script waarin je verschillende spreuken kunt oproepen, met argumenten en return values.

### Stappen

1. **Maak een nieuwe scene** genaamd "Spellbook"
2. **Maak een script** `Spellbook.cs` met minimaal deze functies:
   - `void CastSpell(string spellName)`
   - `int GetManaCost(string spellName)`
   - `bool CanCast(string spellName, int currentMana)`
   - `string GetSpellEffect(string spellName)`
3. **Roep de functies aan** in `Start()` en/of via toetsen (bijvoorbeeld F = Fireball, H = Heal, I = Info).
4. **Gebruik Debug.Log** om te laten zien welke spreuk wordt gecast en wat het effect is.
5. **Test het systeem** door verschillende spreuken te casten en mana te checken.

#### Voorbeeld Console Output

```
Casting spell: Fireball
Mana cost: 30
Effect: Shoots a ball of fire!
Can cast: True
Casting spell: Heal
Mana cost: 20
Effect: Restores health!
Can cast: False (not enough mana)
```

### Bonus Uitdagingen

- Voeg een functie toe die alle beschikbare spreuken toont.
- Maak een functie die een cooldown timer bijhoudt.
- Voeg een "random spell" functie toe.

---
