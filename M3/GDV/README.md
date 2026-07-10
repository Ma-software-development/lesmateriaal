# Lessen Gamedevelopment (GDV)

---

## Inhoudsopgave

- [Inleiding](#inleiding)
- [Aanpak & Leermethode](#aanpak--leermethode)
- [Tijd & Ondersteuning](#tijd--ondersteuning)
- [Rooster](#rooster)
- [Lesprogramma](#lesprogramma)
- [De Game](#de-game)
- [Beoordeling](#beoordeling)

---

## Inleiding

Welkom bij de module Gamedevelopment! In deze module bouw je een arcade-style game geïnspireerd op de klassieker **PAC-MAN**. Hierbij leer je fundamentele programmeerconcepten die je voor veel verschillende soorten games nodig hebt.

### Wat je leert

**Techniek:** Programmeer basics, grids genereren, input & beweging, collision detection, waypoint navigation, animaties aansturen, game state management, code reviews

**Design:** Game concept ontwikkelen, Game Design Document, animaties maken, usertesten, UI bouwen, polishen (particles, sound, screen shake)

---

## Aanpak & Leermethode

### Hoe we werken

Deze module behandelt **basisconcepten (technieken)** die je moet begrijpen én toepassen. Per les behandelen we meerdere technieken (zoals Rigidbody2D, Collisions of Input). We laten niet zien hoe je een complete game bouwt, maar wel hoe elke techniek werkt. Jij maakt vervolgens zelf de vertaling naar je eigen game.

### Lesstructuur

Elke les volgt hetzelfde patroon:

| Stap | Onderdeel      | Beschrijving                    |
| :--: | -------------- | ------------------------------- |
|  1   | **Theorie**    | Uitleg van het concept          |
|  2   | **Voorbeeld**  | Hoe het in een game werkt       |
|  3   | **Oefening**   | Praktijkoefening tijdens de les |
|  4   | **Toepassing** | Toepassen in je eigen game      |

> **Tip:** De oefeningen kun je snel in één les maken. Dit helpt je de techniek te begrijpen voordat je het in je game toepast.

### Leerdoelen

Aan het eind van deze module kun je:

- [ ] Alle oefeningen maken en inleveren (via GitHub README)
- [ ] Je eigen game afronden en inleveren (release build op github)
- [ ] Alle basisconcepten begrijpen en toepassen
- [ ] Alle basisconcepten uitleggen in een code review
- [ ] Je werk op een goede manier presenteren

---

## Tijd & Ondersteuning

### Tijdsinvestering

Wij verwachten van jou een investering in tijd:

| Type                | Uren per week |
| ------------------- | :-----------: |
| Les (totaal)        |     4 uur     |
| ↳ Theorie & uitleg  |  max. 2 uur   |
| ↳ Oefeningen & game |     2 uur     |
| Huiswerk            |     2 uur     |

### Ondersteuning

Dan krijg jij van ons ondersteuning:

- **Tijdens lessen:** Docenten beschikbaar voor vragen
- **Buiten lestijd:** Hulp via Teams
- **Belangrijkste tip:** Vraag snel hulp als je ergens niet uitkomt!

> **Let op:** Probeer oefeningen tijdens de les af te ronden. Dan kun je direct vragen stellen bij problemen.

---

## Rooster

### SD1A

| Dag     | Tijd          | Les      | Docent |
| ------- | ------------- | -------- | ------ |
| Dinsdag | 09:00 - 11:00 | Les \*.1 | WISJ   |
| Dinsdag | 11:15 - 13:15 | Les \*.2 | VERI   |

### SD1B

| Dag     | Tijd          | Les      | Docent |
| ------- | ------------- | -------- | ------ |
| Maandag | 11:15 - 13:15 | Les \*.1 | WISJ   |
| Dinsdag | 09:00 - 11:00 | Les \*.2 | VERI   |

> **Let op:** In Magister staan deze mogelijk niet als GDV maar als BO ingeroosterd!

---

## Lesprogramma

### Overzicht

| Week | Les \*.1 (Techniek)                                                       | Les \*.2 (Design/Toepassing)                                   |
| :--: | ------------------------------------------------------------------------- | -------------------------------------------------------------- |
|  1   | [Programmeer Basics Herhaling](lessen/les-1.1-programmeer-basics.md)      | [Game Concept](lessen/les-1.2-game-concept.md)                 |
|  2   | [Grid maken met modulo](lessen/les-2.1-grid-met-modulo.md)                | [Game Design Document](lessen/les-2.2-game-design-document.md) |
|  3   | [Input, Beweging & Collision](lessen/les-3.1-input-beweging-collision.md) | [Animatie maken](lessen/les-3.2-animatie-maken.md)             |
|  4   | [Waypoint / Navigation](lessen/les-4.1-waypoint-navigation.md)            | [Usertesten](lessen/les-4.2-usertesten.md)                     |
|  5   | [Controleren van Animaties](lessen/les-5.1-animaties-aansturen.md)        | [UI](lessen/les-5.2-ui.md)                                     |
|  6   | [Game State Manager](lessen/les-6.1-game-state-manager.md)                | [Polishen](lessen/les-6.2-polishen.md)                         |
|  7   | [Code Reviews](lessen/les-7.1-code-reviews.md)                            | [Reflectie & Voorbereiding](lessen/les-7.2-reflectie.md)       |
|  8   | Eindpresentatie                                                           | Toets                                                          |
|  9   | Inhalen                                                                   | Inhalen                                                        |

---

### Week 1

#### Les 1.1 — Introductie & Programmeer Basics (WISJ)

Herhaling van de volgende onderwerpen:

| Onderwerp              | Voorbeelden                               |
| ---------------------- | ----------------------------------------- |
| Variabelen & datatypes | `int`, `float`, `string`, `bool`          |
| Functions              | arguments, return types                   |
| Conditionals           | `if`, `while`, `for`, `foreach`, `switch` |
| Access modifiers       | `public` vs `private`                     |
| Operators              | `+`, `+=`, `=`, `==`, `!`, `&&`, `\|\|`   |

#### Les 1.2 — Game Concept (VERI)

Analyseer een bestaande game en brainstorm over een eigen gameconcept.

---

### Week 2

#### Les 2.1 — Grid maken met modulo (WISJ)

Leer hoe je een grid genereert vanuit een array met tekens of getallen. Elk teken/getal genereert een ander type tile. Hiermee kun je snel levels ontwerpen.

#### Les 2.2 — Game Design Document (VERI)

Maak een Game Design Document waarin je het design van je game duidelijk, concreet en volledig omschrijft.

---

### Week 3

#### Les 3.1 — Input, Beweging & Collision Detection (WISJ)

Leer verschillende manieren om input van toetsenbord of controller op te vangen en om te zetten in beweging van een bestuurbaar gameobject.

#### Les 3.2 — Animatie maken in Unity (VERI)

Maak animaties voor je game characters en objecten.

---

### Week 4

#### Les 4.1 — Waypoint / Navigation System (WISJ)

Implementeer een systeem waarmee tegenstanders of NPC's zich door je level kunnen bewegen.

#### Les 4.2 — Usertesten (VERI)

Laat anderen je game testen en verzamel feedback.

---

### Week 5

#### Les 5.1 — Controleren van Animaties (WISJ)

Leer animaties aan te sturen via code met Animator Controllers.

#### Les 5.2 — UI (VERI)

Bouw de User Interface van je game (score, levens, menu's).

---

### Week 6

#### Les 6.1 — Game State Manager (WISJ)

Beheer verschillende game states en deel informatie tussen scripts.

#### Les 6.2 — Polishen (VERI)

Voeg juice toe: particles, sound effects, screen shake.

---

### Week 7

#### Les 7.1 — Code Reviews (WISJ)

Review elkaars code en leer van feedback.

#### Les 7.2 — Reflectie & Voorbereiding (VERI)

Bereid je eindpresentatie voor.

---

### Week 8

#### Les 8.1 — Eindpresentatie (WISJ)

Presenteer je game.

#### Les 8.2 — Toets (VERI)

Schriftelijke toets over de behandelde stof.

---

### Week 9

#### Les 9.1 & 9.2 — Inhalen

Inhaalmoment voor toets en/of presentatie.

---

## De Game

Je bouwt een game gebaseerd op de onderstaande user stories, geïnspireerd door PAC-MAN. De invulling hoeft niet exact zoals PAC-MAN te zijn — je mag je eigen creatieve draai geven, zolang het past bij de omschreven user stories.

### User Stories

#### 1. Beweging & Navigatie

| Als speler wil ik...                                  | Zodat...                              |
| ----------------------------------------------------- | ------------------------------------- |
| Een entiteit in vaste richtingen kunnen besturen      | Ik door een speelruimte kan navigeren |
| Dat mijn entiteit blijft bewegen zolang ik input geef | De besturing consistent aanvoelt      |
| Beperkt worden door obstakels                         | De speelruimte structuur heeft        |

#### 2. Verzamelobjecten

| Als speler wil ik...                                                     | Zodat...                   |
| ------------------------------------------------------------------------ | -------------------------- |
| Objecten kunnen verzamelen door ermee te interacteren                    | Ik voortgang boek          |
| Feedback krijgen bij het verzamelen van een object                       | Mijn actie bevestigd wordt |
| Dat een doel wordt bereikt wanneer alle vereiste objecten zijn verzameld | Een level kan eindigen     |

#### 3. Tegenstanders

| Als speler wil ik...                                         | Zodat...                |
| ------------------------------------------------------------ | ----------------------- |
| Tegenstanders hebben die mij actief bedreigen                | Er spanning ontstaat    |
| Dat verschillende tegenstanders verschillend gedrag vertonen | Ik patronen kan leren   |
| Gestraft worden bij contact met een tegenstander             | Fouten betekenis hebben |

#### 4. Tijdelijke Macht / Statusverandering

| Als speler wil ik...                                                     | Zodat...                        |
| ------------------------------------------------------------------------ | ------------------------------- |
| Tijdelijk een voordeel kunnen krijgen                                    | De machtsverhouding kan omslaan |
| Dat tegenstanders in die periode kwetsbaar worden                        | Ik strategisch kan handelen     |
| Duidelijke visuele en auditieve signalen krijgen bij statusveranderingen | Ik de speltoestand begrijp      |
| Dat tijdelijke effecten automatisch verlopen                             | Timing belangrijk is            |

#### 5. Risico & Beloning

| Als speler wil ik...                                          | Zodat...                        |
| ------------------------------------------------------------- | ------------------------------- |
| Extra beloningen krijgen bij opeenvolgende succesvolle acties | Risico nemen wordt aangemoedigd |
| Zelf kunnen beslissen of ik risico neem voor meer beloning    | Ik agency ervaar                |

#### 6. Levens, Straf & Herstel

| Als speler wil ik...                            | Zodat...                 |
| ----------------------------------------------- | ------------------------ |
| Meerdere kansen hebben voordat het spel eindigt | Leren wordt gestimuleerd |
| Na falen terugkeren naar een veilige toestand   | Het spel verder kan      |
| Een duidelijke eindtoestand bij volledig falen  | Afsluiting helder is     |

#### 7. Score & Feedback

| Als speler wil ik...                                | Zodat...                     |
| --------------------------------------------------- | ---------------------------- |
| Kwantitatieve feedback krijgen over mijn prestaties | Ik mezelf kan vergelijken    |
| Directe feedback op acties                          | Het spel responsief aanvoelt |
| Optionele uitdagingen voor extra beloning           | Meesterschap wordt beloond   |

#### 8. Progressie & Schaling

| Als speler wil ik...                            | Zodat...                           |
| ----------------------------------------------- | ---------------------------------- |
| Dat uitdagingen geleidelijk toenemen            | Het spel interessant blijft        |
| Herkenbare structuren met variërende parameters | Leren mogelijk is zonder verveling |

#### 9. Systeem & Speltoestanden

| Als systeem wil ik...                                                    | Zodat...                           |
| ------------------------------------------------------------------------ | ---------------------------------- |
| Duidelijke speltoestanden hanteren (actief, gepauzeerd, falen, voltooid) | Logica beheersbaar blijft          |
| Tijdgedreven regels toepassen                                            | Gedrag voorspelbaar en testbaar is |

---

## Beoordeling

### Beoordelingsrubric

| Feature                               | O — Onvoldoende                       | V — Voldoende                                 | G — Goed                                        |
| ------------------------------------- | ------------------------------------- | --------------------------------------------- | ----------------------------------------------- |
| **Entiteit kan bestuurd worden**      | Besturing werkt niet of onbetrouwbaar | Speler kan entiteit besturen met input        | Besturing reageert consistent en voorspelbaar   |
| **Entiteit blijft bewegen bij input** | Beweging stopt onlogisch of hapert    | Beweging blijft actief zolang input actief is | Overgangen tussen inputrichtingen zijn vloeiend |
| **Obstakels blokkeren beweging**      | Entiteit kan door obstakels heen      | Obstakels blokkeren beweging correct          | Botsing werkt in alle richtingen foutloos       |
| **Objecten kunnen verzameld worden**  | Verzamelen werkt niet of soms         | Objecten verdwijnen en tellen mee             | Verzamelen werkt altijd en foutloos             |
| **Feedback bij verzamelen**           | Geen zichtbare feedback               | Speler ziet of hoort feedback                 | Feedback is duidelijk en niet te missen         |
| **Level eindigt bij doel**            | Level eindigt niet of fout            | Level eindigt bij juiste voorwaarde           | Eindconditie werkt zonder bugs                  |
| **Tegenstanders vormen gevaar**       | Geen effect bij contact               | Contact leidt tot straf                       | Straf is consistent en duidelijk                |
| **Verschillende gedragingen**         | Alle tegenstanders doen hetzelfde     | Minstens twee verschillende gedragingen       | Gedragingen zijn herkenbaar en consistent       |
| **Tijdelijke statusverandering**      | Status is permanent of onduidelijk    | Status is tijdelijk en werkt                  | Begin en einde zijn duidelijk herkenbaar        |
| **Tegenstanders tijdelijk kwetsbaar** | Geen verschil merkbaar                | Tegenstanders zijn tijdelijk kwetsbaar        | Kwetsbaarheid werkt in alle situaties           |
| **Feedback bij statusverandering**    | Geen feedback zichtbaar               | Feedback is zichtbaar of hoorbaar             | Feedback is direct en onmiskenbaar              |
| **Meerdere kansen (levens)**          | Game stopt direct                     | Speler heeft meerdere pogingen                | Herstart is logisch en foutloos                 |
| **Eindtoestand (game over)**          | Geen duidelijke eindtoestand          | Game over is herkenbaar                       | Game over is technisch en visueel duidelijk     |

### Toets

Aan het eind van de periode wordt de behandelde stof schriftelijk getoetst. Dit is een toets met **open vragen** over alle behandelde onderwerpen.

### Eindpresentatie

Na afronding van je game presenteer je deze samen met je teamgenoot.

**Wat moet er in je presentatie?**

| Onderdeel           | Beschrijving                                                                                     |
| ------------------- | ------------------------------------------------------------------------------------------------ |
| **Inspiratie**      | Laat zien waar je inspiratie vandaan kwam (bijv. bestaande game)                                 |
| **Ontwerp**         | Toon je ontwerp — is het gelukt om dit na te bouwen?                                             |
| **Demo**            | Korte GIF van je eindresultaat (max 10 sec, gebruik [ScreenToGif](https://www.screentogif.com/)) |
| **Wat ging goed?**  | Minimaal 2 punten + wat je hiervan hebt geleerd                                                  |
| **Wat was lastig?** | Minimaal 2 punten + wat je hiervan hebt geleerd                                                  |
| **Trots**           | Waar ben je het meest trots op?                                                                  |

### Weging

| Onderdeel       |  Weging   |
| --------------- | :-------: |
| Game            | 3/5 (60%) |
| Toets           | 1/5 (20%) |
| Eindpresentatie | 1/5 (20%) |

> Met een voldoende kun je een **Bronzen badge** verdienen op Simulise.
