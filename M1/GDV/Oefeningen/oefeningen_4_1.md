# Oefeningen Les 4.1: Trigger vs Collision Quest

## Werkwijze
Begin met **Oefening 4.1A**.  
Heb je die af? Ga door met **Oefening 4.1B** en daarna met **Oefening 4.1C**.  
De oefeningen bouwen op elkaar voort, dus het is het beste om ze in deze volgorde te maken.  


Als je klaar bent, vul dan [dit](https://forms.gle/VqBssDKbTQtTE37n8) formulier in. De kennisvragen helpen je om te ontdekken of je de belangrijkste onderdelen van de les echt begrijpt. Dezelfde onderwerpen komen later terug in de toets.

---

## Oefening 4.1A: Coin Collector

**Doel**  
Leer hoe je een speler laat bewegen, coins oppakt via een trigger en muren gebruikt als collision.  

**Wat ga je doen?**  
Je maakt een speler die coins kan verzamelen. Coins verdwijnen via een **Trigger** en muren blokkeren de speler via een **Collision**. De score wordt zichtbaar gemaakt in de Console.  

**Stappen**  
- Maak een **Player** (bijv. Cube) met Rigidbody en Collider. Zet de tag op **Player**.  
- Maak een **Coin** (bijv. Sphere) met Collider, zet **Is Trigger** aan en de tag op **Coin**.  
- Maak een **Muur** (Cube) met Collider. Laat **Is Trigger** uit staan.  
- Laat de speler links en rechts bewegen via `Input.GetAxis("Horizontal")`.  
- Zorg dat coins verdwijnen met `OnTriggerEnter` en dat er een score in de Console wordt bijgehouden.  
- Zorg dat muren de speler blokkeren met een Collision.  

**Bonus uitdagingen**  
- Laat de coin ronddraaien in de lucht en kies bewust voor **Space.Self** of **Space.World**.  
- Voeg meerdere coins toe en tel ze allemaal mee in de score.  
- Toon in de Console een duidelijke melding bij zowel Trigger als Collision.  

---

## Oefening 4.1B: Goomba Trouble

**Doel**  
Leer hoe je naast triggers ook collisions met vijanden en UI-feedback gebruikt.  

**Wat ga je doen?**  
Je breidt je coin-scène uit met een vijand (Goomba of stilstaand object) die een leven kost bij collision. Coins keren automatisch terug en de score verschijnt in een Canvas-tekst.  

**Stappen**  
- Breid je vorige scène uit.  
- Voeg een **Canvas** toe met een Text (of TextMeshProUGUI) voor de score.  
- Zorg dat coins na een paar seconden respawnen.  
- Voeg een **Enemy** toe (Goomba of stilstaand object) met Collider en tag **Enemy**.  
- Laat bij collision met de Enemy een leven van de speler afgaan (houd dit bij met een int-variabele en toon dit in de Console of UI).  

**Bonus uitdagingen**  
- Laat de coin krimpen bij oppakken en terugploppen bij respawn.  
- Laat de Enemy of Goomba om een **pivot** draaien in plaats van op zichzelf.  
- Voeg een geluidseffect toe bij het oppakken van coins.  

---

## Oefening 4.1C: Boo Challenge

**Doel**  
Leer hoe je complexe collisions en triggers combineert, inclusief respawn-mechanieken.  

**Wat ga je doen?**  
Je voegt een bewegende vijand toe die rond een as draait, een KillZone die levens kost bij vallen, en coins met verschillende waarden en respawntijden.  

**Stappen**  
- Breid je vorige scène uit.  
- Voeg een **Boo** of ander vijand-object toe dat rond een empty parent draait. Zet de tag op **Enemy**.  
- Zorg dat collision met deze vijand levens aftrekt.  
- Maak een **KillZone** onder het level (bijv. een groot vlak met Is Trigger aan en tag KillZone).  
- Laat de speler een leven verliezen en terugkeren naar een RespawnPoint wanneer deze in de KillZone valt.  
- Voeg meerdere coins toe met verschillende scorewaarden en respawntijden.  

**Bonus uitdagingen**  
- Laat de Boo wiebelen tijdens het roteren om hem levendiger te maken.  
- Voeg een **Checkpoint** toe als Trigger die tijdelijk een bericht in de UI toont. Tag dit object **Checkpoint**.  
- Bouw een cooldown zodat de speler niet meerdere levens tegelijk verliest bij aanhoudend contact met een vijand.  
