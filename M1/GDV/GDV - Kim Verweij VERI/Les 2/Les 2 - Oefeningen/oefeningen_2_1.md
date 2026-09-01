# Oefeningen Les 2.1: Scriptmatige beweging in Unity

Vandaag ga je oefenen met beweging in Unity.

Je begint met **Oefening 2.1A**.  
Heb je die af? Dan ga je door met **Oefening 2.1B**.  
Heb je daarna nog tijd, dan mag je **Oefening 2.1C** proberen.

De oefeningen bouwen op elkaar voort, dus maak ze het liefst in deze volgorde.

Het hoeft nog niet perfect te zijn. Het belangrijkste is dat je begrijpt hoe je een GameObject laat bewegen met een script.

---

## Inleveren

Lever je opdracht in via Simulise.

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat
- een korte uitleg van wat je hebt gemaakt
- welke beweging je hebt gemaakt
- wat goed lukte
- wat je lastig vond

---

## Oefening 2.1A: Draaiend muntje (Coin)

### Doel

Je leert hoe je een GameObject rond zijn eigen as laat draaien met een script.

### Wat ga je doen?

Je maakt een muntje dat automatisch ronddraait, zoals een coin in een game.

### Stappen

1. Voeg een `Cube` of `Cylinder` toe.
2. Geef het object een duidelijke naam, bijvoorbeeld `Coin`.
3. Geef het object eventueel een goud materiaal.
4. Maak een script, bijvoorbeeld `RotateCoin`.
5. Zet het script op je coin.
6. Gebruik `transform.Rotate()` om het object te laten draaien.
7. Gebruik `Time.deltaTime` zodat de beweging netjes blijft.
8. Maak de draaisnelheid instelbaar met een `public float rotateSpeed`.

### Bonus

- Laat het muntje om meerdere assen draaien.
- Maak meerdere coins met verschillende snelheden.
- Laat het muntje langzaam omhoog en omlaag bewegen.

---

## Oefening 2.1B: Heen-en-weer beweging (Goomba)

### Doel

Je leert hoe je een GameObject automatisch heen en weer laat bewegen.

### Wat ga je doen?

Je maakt een object dat heen en weer beweegt, zoals een Goomba in Mario.

### Stappen

1. Voeg een `Cube` of `Sphere` toe.
2. Geef het object een duidelijke naam, bijvoorbeeld `Goomba`.
3. Maak een script, bijvoorbeeld `GoombaMovement`.
4. Zet het script op je Goomba.
5. Gebruik `transform.position` of `transform.Translate()` om het object te bewegen.
6. Laat het object bewegen over de X-as of Z-as.
7. Gebruik `Time.deltaTime`.
8. Maak de snelheid instelbaar met een `public float speed`.

### Tip

Je kunt bijvoorbeeld `Mathf.PingPong()` gebruiken om een beweging heen en weer te maken.

### Bonus

- Maak de afstand instelbaar met een `public float distance`.
- Laat meerdere Goomba’s bewegen met verschillende snelheden.
- Laat de Goomba draaien in de richting waarin hij beweegt.

---

## Oefening 2.1C: Cirkelbeweging (Boo)

### Doel

Je leert hoe je een GameObject rond een punt laat bewegen.

### Wat ga je doen?

Je maakt een Boo die rond een middelpunt zweeft.

### Stappen

1. Voeg een `Sphere` toe als Boo.
2. Maak eventueel een leeg GameObject als middelpunt.
3. Maak een script, bijvoorbeeld `BooOrbit`.
4. Zet het script op je Boo.
5. Gebruik `transform.RotateAround()` om rond een punt te draaien.
6. Gebruik `Time.deltaTime`.
7. Maak de snelheid instelbaar met een `public float orbitSpeed`.

### Bonus

- Laat meerdere Boo’s rond hetzelfde punt bewegen.
- Geef elke Boo een andere snelheid.
- Combineer de cirkelbeweging met een op-en-neer beweging.

---

## Klaar?

Controleer je werk:

- [ ] Mijn object beweegt automatisch
- [ ] Mijn script staat op het juiste GameObject
- [ ] Ik gebruik `Time.deltaTime`
- [ ] Ik heb duidelijke namen gebruikt
- [ ] Ik heb mijn scene opgeslagen
- [ ] Ik heb een screenshot of gif gemaakt
- [ ] Ik heb mijn opdracht ingeleverd via  [Simulise](https://ma.simulise.com/school/assignment/d95819ef-7f0e-47b1-a81a-264c0e92103d/view)

---

## Tips

- Sla regelmatig op met **Ctrl+S**.
- Gebruik duidelijke namen zoals `Coin`, `Goomba` en `Boo`.
- Als je object uit beeld verdwijnt, selecteer het in de Hierarchy en druk op **F**.
- Als iets misgaat, gebruik **Ctrl+Z**.
- Kijk in de Console als je script niet werkt.
