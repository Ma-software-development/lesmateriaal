# Game Design - Design your Enemy (Gym)

## Lescontext

In deze les bouwen we geen volledig level.  
We ontwerpen en testen alleen het gedrag van een vijand.

We gebruiken hiervoor een Gym-scene.

Een Gym is een testomgeving waarin je één mechanic los van de rest van de game bouwt en test.

Geen leveldesign.  
Geen UI.  
Geen polish.  
Alleen gedrag en logica.

---

# Leerdoelen

Aan het einde van deze opdracht kun je:

- Vijandgedrag vertalen naar concrete regels
- Gedrag uitschrijven in een flowchart
- Gedrag testen zonder volledig level
- Het gedrag omzetten naar programmeerbare logica in Unity

---

# Opdracht

## Stap 1 – Ontwerp het gedrag

Schrijf het gedrag van jouw vijand uit in duidelijke, concrete regels.

Beantwoord minimaal:

- Wanneer start het gedrag?
- Wat zijn de triggers?
- Wanneer verandert het gedrag?
- Hoe beweegt de vijand?
- Wat gebeurt er als de speler zichtbaar is?
- Wat gebeurt er als de speler niet zichtbaar is?
- Wanneer stopt het gedrag?

Je mag het woord "gewoon" niet gebruiken.

Alles moet te vertalen zijn naar code.

---

## Stap 2 – Flowchart

Maak een eenvoudige flowchart van het gedrag bijvoorbeeld via https://mermaid.js.org/.

Gebruik beslissingen zoals:

- Is speler zichtbaar?
- Is er geluid?
- Is trigger actief?

Denk in if/else-structuur.

Als je het niet in een flowchart kunt zetten, kun je het niet programmeren.

---

## Stap 3 – Klassikale test

Tijdens de les testen we een aantal ontwerpen samen.

De "vijand" mag alleen doen wat letterlijk in de regels staat.

Als iets niet beschreven is, mag het niet gebeuren.

Na de test:

- Maak je regels concreter
- Pas je flowchart aan
- Verwijder vaag taalgebruik

---

## Stap 4 – Implementatie in Unity

Bouw een Gym-scene waarin je alleen het gedrag van je vijand test.

Minimale vereisten:

- De vijand kan bewegen
- Er is een detectiesysteem (zicht of geluid)
- Gedrag verandert op basis van condities
- Het gedrag is logisch en consistent

Focus op logica, niet op afwerking.

---

# Opdracht - Enemy Behaviour Gym

Je levert het volgende in via GitHub:

## 1. README (verplicht)

In je README staat:

- De uitgeschreven gedragsregels
- De flowchart (als afbeelding of duidelijke schematische weergave)
- Een korte uitleg van hoe jouw detectiesysteem werkt
- Een korte reflectie (minimaal 5 zinnen):
  - Wat werkte direct?
  - Wat werkte niet?
  - Wat moest je aanpassen na het testmoment?

## 2. Unity Project (verplicht)

In je project:

- Een aparte Gym-scene
- Werkend vijandgedrag
- Duidelijke scriptstructuur
- Logische naamgeving van scripts

Zorg dat het project compileert zonder errors.

---

# Beoordeling

Je wordt beoordeeld op:

- Duidelijkheid en concreetheid van je regels
- Logische opbouw van gedrag
- Werkende implementatie
- Programmeerbaarheid van je ontwerp
- Reflectie op je eigen proces
