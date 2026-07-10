# Oefeningen Les 2.1: Scriptmatige Beweging in Unity

## Werkwijze

In deze les begin je met **Oefening 2.1A**.  
Heb je die af? Dan kun je doorgaan met **Oefening 2.1B** en daarna eventueel met **Oefening 2.1C**.  
De oefeningen bouwen op elkaar voort, dus het is het beste om ze in deze volgorde te maken.

De oefeningen lever je in via een README.md bestand op GitHub met:

- Titel van de oefening
- Korte omschrijving van wat je hebt gedaan
- Een gifje met je resultaat
- Link naar je script

Ben je klaar met de oefeningen? Vul dan [dit](https://docs.google.com/forms/d/e/1FAIpQLSc8-3RZsUtxR6Z4annQGl3EQ0uibrmHkpAdSf8VyMZ-uLLdiw/viewform?usp=sharing&ouid=101068750037276710520) formulier in. De kennisvragen helpen je om te ontdekken of je de belangrijkste onderdelen van de les echt begrijpt. Dezelfde onderwerpen komen later terug in de toets.

---

## Oefening 2.1A: Draaiend muntje (Coin)

**Doel**  
Leer hoe je een GameObject rond zijn eigen as laat draaien met een script.

**Wat ga je doen?**  
Je maakt een muntje (of ander object) dat automatisch draait, zoals in Mario.

**Stappen**

- Voeg een `Cube` of `Cylinder` toe en geef deze een goud materiaal.
- Schrijf een script waarin je `transform.Rotate()` gebruikt.
- Gebruik `Time.deltaTime` voor vloeiende beweging.
- Maak de snelheid instelbaar met een `public float rotateSpeed`.

**Bonus uitdagingen**

- Laat het muntje langzaam omhoog zweven terwijl het draait.
- Experimenteer met draaien om meerdere assen tegelijk.

---

## Oefening 2.1B: Heen-en-weer beweging (Goomba)

**Doel**  
Leer een GameObject heen en weer te laten bewegen met behulp van een script.

**Wat ga je doen?**  
Je maakt een object dat heen en weer loopt, zoals Goomba in Mario.

**Stappen**

- Voeg een `Cube` of `Sphere` toe.
- Gebruik `transform.position` in `Update()` om de X- of Z-waarde aan te passen.
- Tip: gebruik `Mathf.PingPong()` of een sinusfunctie voor een herhalend patroon.
- Maak snelheid en afstand instelbaar met `public variabelen`.

**Bonus uitdagingen**

- Laat het object draaien in de richting waarin het loopt.
- Voeg meerdere Goomba’s toe met verschillende snelheden.

---

## Oefening 2.1C: Cirkelbeweging (Boo)

**Doel**  
Leer een GameObject in een cirkel rond een punt te laten bewegen.

**Wat ga je doen?**  
Je maakt een Boo die rond een middelpunt zweeft, zoals in Mario.

**Stappen**

- Voeg een `Sphere` toe als Boo.
- Gebruik `transform.RotateAround()` om rond een punt te draaien.
- Alternatief: gebruik `Mathf.Sin()` en `Mathf.Cos()` om X en Z te berekenen.
- Maak snelheid (`orbitSpeed`) en straal (`radius`) instelbaar met `public variabelen`.

**Bonus uitdagingen**

- Laat meerdere Boo’s rond hetzelfde punt draaien.
- Combineer een cirkelbeweging met een zwevende op-en-neer beweging.

---
