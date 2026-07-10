# Oefeningen Les 1.1: Unity Interface en GameObjects

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vind en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een zogenaamde README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst. Een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

## Oefening 1.1A: Primitive Building Challenge

### Doel

Leer de Unity interface kennen door een simpel huis met primitieve vormen te bouwen.

### Wat ga je doen?

Bouw een huis met alleen basis GameObjects (cubes, spheres, cylinders).

### Stappen

1. **Maak een nieuwe scene** genaamd "PrimitiveHouse"
2. **Voeg deze GameObjects toe:**

   - 4 Cubes voor de muren
   - 1 Cube voor de vloer (maak deze platter met Scale)
   - 1 Cube voor het dak (draai 45 graden)
   - 2 Cylinders voor schoorstenen
   - 1 Sphere als decoratie (zon of lamp)

3. **Organiseer je Hierarchy:**

   - Hernoem alle objecten logisch ("Muur_Links", "Dak", "Schoorsteen_1", etc.)
   - Sorteer ze netjes in de hierarchy

4. **Experimenteer met Transform:**
   - Gebruik Position om alles op de juiste plek te zetten
   - Gebruik Scale om de juiste verhoudingen te krijgen
   - Gebruik Rotation voor het dak

### Bonus Uitdagingen

- Voeg een "tuin" toe met meerdere cilinders en spheres als bomen
- Maak een pad naar de deur met kleine cubes
- Probeer verschillende camera hoeken uit
- Voeg passende textures toe aan de onderdelen

---

## Oefening 1.1B: Gaming Setup Diorama

### Doel

Maak een 3D versie van je ideale gaming setup met Unity's basis vormen.

### Wat ga je doen?

Bouw een gaming kamer scene met meubels en gaming gear.

### Stappen

1. **Maak een nieuw project** genaamd "GamingSetup"
2. **Bouw deze items:**

   - **Bureau:** 1 grote platte cube
   - **Monitor:** 1 dunne cube (staand)
   - **Toetsenbord:** 1 kleine platte cube
   - **Muis:** 1 hele kleine cube
   - **Stoel:** 2 cubes (zitting + rugleuning)
   - **Gaming headset:** 1 sphere + 2 kleine cylinders
   - **Console:** 1 cube onder het bureau

3. **Scene inrichten:**

   - Plaats alles realistisch ten opzichte van elkaar
   - Gebruik de camera om een goede hoek te vinden
   - Test met Play Mode hoe het eruitziet

4. **Details toevoegen:**
   - Voeg RGB lighting toe met gekleurde spheres
   - Maak een "keyboard" met veel kleine cubes als toetsen
   - Voeg decoratie toe (posters = platte cubes aan de muur)

### Bonus Uitdagingen

- Maak een tweede monitor
- Voeg een mini-fridge toe (cylinder)
- Bouw een headset stand
- Voeg passende textures toe aan de onderdelen

---

## Oefening 1.1C: Retro Arcade Machine Builder

### Doel

Bouw een klassieke arcade machine en leer over object hiërarchie.

### Wat ga je doen?

Construeer een arcade cabinet met alleen Unity's primitieve vormen.

### Stappen

1. **Maak een nieuw project** genaamd "ArcadeMachine"
2. **Bouw de arcade cabinet:**

   - **Main body:** 1 grote cube (de kast)
   - **Screen:** 1 dunne zwarte cube vooraan
   - **Control panel:** 1 schuin geplaatste cube
   - **Joystick:** 1 cylinder + 1 sphere bovenop
   - **Buttons:** 6-8 kleine cylinders
   - **Coin slot:** 1 hele kleine cube
   - **Base:** 1 platte cube onder alles

3. **Organisatie in Hierarchy:**

   ```
   ArcadeMachine
   ├── Cabinet_Main
   ├── Screen
   ├── ControlPanel
   │   ├── Joystick_Base
   │   ├── Joystick_Handle
   │   ├── Button_1
   │   ├── Button_2
   │   └── etc...
   ├── CoinSlot
   └── Base
   ```

4. **Maak het realistisch:**
   - Screen onder een hoek
   - Control panel schuin voor comfort
   - Joystick en buttons op logische plekken

### Bonus Uitdagingen

- Voeg een "marquee" toe bovenaan (voor de game titel)
- Maak side art met extra cubes
- Voeg "neon lighting" toe met gekleurde spheres
- Bouw een tweede arcade machine ernaast
- Voeg passende textures toe aan de onderdelen

---

## Tips voor Alle Oefeningen

### Unity Interface Tips

- **F-toets:** Focus camera op geselecteerd object
- **Right-click + drag:** Roteer scene view
- **Middle-mouse + drag:** Pan scene view
- **Scroll wheel:** Zoom in/out

### Transform Tips

- Gebruik **hele getallen** voor Position waar mogelijk (makkelijker te onthouden)
- **Scale van 1,1,1** is normale grootte
- **Rotation van 0,0,0** is geen rotatie

### Organisatie Tips

- Geef objecten **duidelijke namen**
- Groepeer gerelateerde objecten in de hierarchy
- Sla je scene regelmatig op (Ctrl+S)

### Debugging Tips

- Als een object "verdwenen" is, selecteer het in Hierarchy en druk **F**
- Gebruik **Ctrl+Z** om fouten ongedaan te maken
- Reset Transform via Inspector menu (tandwiel → Reset)

---
