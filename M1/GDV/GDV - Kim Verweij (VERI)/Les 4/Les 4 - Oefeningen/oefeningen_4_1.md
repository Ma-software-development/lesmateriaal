# Oefeningen Les 4.1: Trigger vs Collision Quest

Vandaag ga je oefenen met triggers, collisions en tags.

Je begint met **Oefening 4.1A**.  
Heb je die af? Dan ga je door met **Oefening 4.1B**.  
Heb je daarna nog tijd, dan mag je **Oefening 4.1C** proberen.

De oefeningen bouwen op elkaar voort, dus maak ze het liefst in deze volgorde.

---

## Inleveren

Lever je opdracht in via Simulise:

[Lever hier in op Simulise](https://ma.simulise.com/school/assignment/257ad4bb-28c2-4372-b962-efcbf246a7fb/view)

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat
- een korte uitleg van wat je hebt gemaakt
- welke objecten een Trigger gebruiken
- welke objecten een Collision gebruiken
- welke Tags je hebt gebruikt
- wat goed lukte
- wat je lastig vond

---

## Oefening 4.1A: Coin Collector

### Doel

Je leert het verschil tussen een Trigger en een Collision.

### Wat ga je doen?

Je maakt een speler die coins kan verzamelen.

Coins verdwijnen via een **Trigger**.  
Muren blokkeren de speler met een **Collision**.  
De score laat je zien in de Console.

### Stappen

1. Maak een **Player** met Rigidbody en Collider.
2. Zet de tag van de Player op **Player**.
3. Maak een **Coin** met Collider.
4. Zet bij de Coin **Is Trigger** aan.
5. Zet de tag van de Coin op **Coin**.
6. Maak een **Muur** met Collider.
7. Laat **Is Trigger** bij de muur uit staan.
8. Laat de Player bewegen met `Input.GetAxis("Horizontal")`.
9. Zorg dat coins verdwijnen met `OnTriggerEnter`.
10. Houd de score bij in de Console.

### Bonus

- Laat de coin ronddraaien.
- Voeg meerdere coins toe.
- Toon in de Console wanneer iets een Trigger of Collision is.

---

## Oefening 4.1B: Goomba Trouble

### Doel

Je leert hoe je een vijand toevoegt met Collision.

### Wat ga je doen?

Je breidt je coin-scene uit met een vijand.

Als de speler de vijand raakt, verliest de speler een leven.  
Coins komen na een paar seconden weer terug.

### Stappen

1. Breid je scene van oefening 4.1A uit.
2. Voeg een **Enemy** toe, bijvoorbeeld een Goomba of blok.
3. Geef de Enemy een Collider.
4. Zet de tag van de Enemy op **Enemy**.
5. Laat de speler een leven verliezen bij Collision met de Enemy.
6. Houd levens bij met een `int` variabele.
7. Laat coins na een paar seconden respawnen.
8. Toon score en levens in de Console of UI.

### Bonus

- Laat de coin krimpen bij oppakken.
- Laat de coin terugploppen bij respawn.
- Laat de Enemy bewegen of draaien.
- Voeg een geluidseffect toe.

---

## Oefening 4.1C: Boo Challenge

### Doel

Je leert meerdere Triggers en Collisions combineren.

### Wat ga je doen?

Je voegt een bewegende vijand, een KillZone en coins met verschillende waardes toe.

Als de speler in de KillZone valt, verliest de speler een leven en komt terug bij een RespawnPoint.

### Stappen

1. Breid je vorige scene uit.
2. Voeg een **Boo** of andere vijand toe.
3. Laat de Boo rond een empty parent draaien.
4. Zet de tag van de Boo op **Enemy**.
5. Zorg dat Collision met Boo levens aftrekt.
6. Maak een **KillZone** onder het level.
7. Zet bij de KillZone **Is Trigger** aan.
8. Zet de tag op **KillZone**.
9. Maak een **RespawnPoint**.
10. Laat de speler terugkeren naar het RespawnPoint.
11. Voeg meerdere coins toe met verschillende scorewaardes.

### Bonus

- Laat Boo wiebelen tijdens het bewegen.
- Voeg een Checkpoint toe als Trigger.
- Toon tijdelijk een bericht in de UI.
- Bouw een cooldown zodat de speler niet meerdere levens tegelijk verliest.

---

## Klaar?

Controleer je werk:

- [ ] Mijn speler kan bewegen
- [ ] Mijn coins werken met een Trigger
- [ ] Mijn muren werken met Collision
- [ ] Ik heb Tags gebruikt
- [ ] Ik gebruik `OnTriggerEnter`
- [ ] Ik gebruik `OnCollisionEnter`
- [ ] Mijn score of levens worden bijgehouden
- [ ] Ik heb mijn scene opgeslagen
- [ ] Ik heb een screenshot of gif gemaakt
- [ ] Ik heb mijn opdracht ingeleverd via [Simulise](https://ma.simulise.com/school/assignment/257ad4bb-28c2-4372-b962-efcbf246a7fb/view)

