# Oefeningen Les 4.2: Collisions Afvangen met Code

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vindt en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

---

## Oefening 4.2A: Coin Pickup System

### Doel

Oefen met OnTriggerEnter door een muntjes-verzamelsysteem te maken.

### Wat ga je doen?

Je maakt een script dat punten toevoegt als de speler een muntje oppakt.

### Stappen

1. **Maak een nieuwe scene** genaamd "CoinPickup"
2. **Voeg een Capsule toe** als speler en geef deze de tag "Player"
3. **Voeg meerdere Spheres toe** als muntjes en geef ze de tag "Coin"
4. **Zet "Is Trigger" aan** op de Sphere Colliders van de muntjes
5. **Maak een script** `CoinPickup.cs` dat punten toevoegt en het muntje vernietigt bij aanraking
6. **Optimaliseer je code** door code die herhalend is in functies te stoppen.
7. **Test het systeem** door de speler langs de muntjes te bewegen

#### Voorbeeld Console Output

```
Player picked up a coin!
Score: 10
Player picked up a coin!
Score: 20
```

### Bonus Uitdagingen

- Toon het totaal aantal verzamelde muntjes
- Voeg een pickup effect toe (kleur, geluid, particle)
- Laat het systeem alleen werken voor objecten met de tag "Player"

---

## Oefening 4.2B: Damage Zone Trigger

### Doel

Oefen met OnTriggerStay door een damage zone te maken die de speler schade geeft zolang hij in de zone blijft.

### Wat ga je doen?

Je maakt een script dat elke seconde schade toebrengt aan de speler als hij in de zone staat.

### Stappen

1. **Maak een nieuwe scene** genaamd "DamageZone"
2. **Voeg een Cube toe** als damage zone en zet "Is Trigger" aan
3. **Geef de Cube de tag "DamageZone"**
4. **Voeg een Capsule toe** als speler en geef deze de tag "Player"
5. **Maak een script** `DamageZone.cs` dat elke seconde schade toebrengt aan de speler zolang hij in de zone is
6. **Optimaliseer je code** door code die herhalend is in functies te stoppen.
7. **Test het systeem** door de speler in de zone te laten staan

#### Voorbeeld Console Output

```
Player entered damage zone!
Player takes 10 damage!
Player takes 10 damage!
Player left damage zone!
```

### Bonus Uitdagingen

- Toon de huidige health van de speler
- Laat de zone van kleur veranderen als de speler erin staat
- Voeg een genezingszone toe die health teruggeeft

---

## Oefening 4.2C: Bouncing Ball Collision

### Doel

Oefen met OnCollisionEnter door een bal te laten stuiteren op de grond en tegen muren.

### Wat ga je doen?

Je maakt een script dat een bal laat stuiteren als hij de grond of een muur raakt.

### Stappen

1. **Maak een nieuwe scene** genaamd "BouncingBall"
2. **Voeg een Sphere toe** als bal en geef deze een Rigidbody
3. **Voeg een Plane toe** als grond en geef deze de tag "Ground"
4. **Voeg een Cube toe** als muur en geef deze de tag "Wall"
5. **Maak een script** `BouncingBall.cs` dat de bal laat stuiteren bij botsing met grond of muur
6. **Optimaliseer je code** door code die herhalend is in functies te stoppen.
7. **Test het systeem** door de bal te laten vallen en botsen

#### Voorbeeld Console Output

```
Ball bounced on ground!
Ball hit wall!
Ball bounced on ground!
```

### Bonus Uitdagingen

- Voeg een score toe voor elke stuiter
- Laat de bal van kleur veranderen bij elke botsing
- Voeg meerdere muren toe met verschillende effecten

---
