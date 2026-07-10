# Oefeningen Les 5.2: Logica Combineren met Botsingen en Input

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vindt en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

---

## Oefening 5.2A: Slimme Pickup Systeem

### Doel

Combineer input, if-statements en collision detection door een pickup systeem te maken dat alleen werkt onder bepaalde voorwaarden.

### Wat ga je doen?

Je maakt een script waarin een speler alleen een health potion kan oppakken als zijn health niet vol is.

### Stappen

1. **Maak een nieuwe scene** genaamd "HealthPickup"
2. **Maak een Capsule als speler** met een variabele `int health` en `int maxHealth`
3. **Maak een Sphere als health potion** met een Collider (Is Trigger aan)
4. **Maak een script** `HealthPickup.cs` dat in `OnTriggerEnter` checkt:
   - Alleen oppakken als `health < maxHealth`
   - Verhoog health en vernietig het potion object
   - Toon een bericht in de console
5. **Test het systeem** door health te veranderen en te proberen op te pakken

#### Voorbeeld Console Output

```
Health restored!
Health already full!
```

### Bonus Uitdagingen

- Voeg een key pickup toe die alleen werkt als je nog geen key hebt
- Toon een visueel effect bij het oppakken
- Voeg een score systeem toe voor elke pickup

---

## Oefening 5.2B: Interactieve Deur met Sleutel

### Doel

Combineer input, if-statements en collision detection door een deur te maken die alleen opent als je een sleutel hebt.

### Wat ga je doen?

Je maakt een script waarin een speler een deur kan openen met de E-toets, maar alleen als hij een sleutel heeft.

### Stappen

1. **Maak een nieuwe scene** genaamd "DoorWithKey"
2. **Maak een Capsule als speler** met een bool `hasKey`
3. **Maak een Cube als deur** met een Collider (Is Trigger aan)
4. **Maak een sphere als key** met een Collider (Is Trigger aan)
5. **Maak een script** `OpenDoorWithKey.cs` dat in `OnTriggerEnter` een hint toont ("Press E to open").
6. **Laat de deur alleen openen** als de speler op E drukt en `hasKey == true`
7. **Laat de speler de key pakken** als de speler deze raakt en zet dan de bool `hasKey = true`
8. **Test het systeem** door een sleutel op te pakken en de deur te openen

#### Voorbeeld Console Output

```
Press E to open (needs key)
Need a key!
Picked up key!
Door opened!
```

### Bonus Uitdagingen

- Laat de deur omhoog bewegen als hij opent
- Toon een ander bericht als je geen sleutel hebt
- Voeg een animatie toe aan de deur

---

## Oefening 5.2C: Kleurwisselende Platform

### Doel

Maak een platform dat van kleur verandert wanneer de speler erop staat en een toets indrukt.

### Wat ga je doen?

Je maakt een script waarin een platform van kleur verandert als de speler erop staat en op verschillende toetsen drukt (R = rood, G = groen, B = blauw).

### Stappen

1. **Maak een nieuwe scene** genaamd "ColorPlatforms"
2. **Maak meerdere Cubes als platforms** met een Collider (Is Trigger aan)
3. **Maak een script** `ColorChanger.cs` dat:
   - Checkt of de speler op het platform staat
   - Bij R/G/B toetsen de kleur verandert
   - Een bericht toont welke kleur actief is
4. **Test het systeem** door op het platform te staan en toetsen in te drukken

#### Voorbeeld Console Output

```
Player on platform - Press R/G/B to change color
Changed to Red!
Changed to Green!
Changed to Blue!
```

### Bonus Uitdagingen

- Voeg meer kleuren toe met andere toetsen
- Laat het platform langzaam van kleur veranderen
- Tel hoe vaak elke kleur is gebruikt

---
