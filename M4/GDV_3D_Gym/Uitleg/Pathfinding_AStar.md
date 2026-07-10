# Pathfinding Uitgelegd: het A\*-algoritme

## Het probleem

Stel je hebt een NPC in je spel die van punt **A** naar punt **B** moet lopen. Maar er staan muren en obstakels in de weg. Hoe vindt de NPC de kortste route zonder door muren heen te lopen?

Dat is het pathfinding-probleem.

> Check ook deze [video](https://youtu.be/i0x5fj4PqP4?si=jWCZiVVzyh8e1Z91)

```
Start                           Doel
  . . . . . . . . . . . . . . . E
  . # # # # # # . . . . . . . .
  . # . . . . # . # # # # # # .
  . # . . . . # . # . . . . # .
  S . . . . . . . # . . . . . .
```

_(`S` = start, `E` = einde, `#` = muur, `.` = begaanbaar)_

Je kunt de NPC niet gewoon laten lopen in de richting van het doel — dan loopt hij op een muur. Je hebt een **slimmer algoritme** nodig.

---

## Drie manieren om een route te vinden

Voordat we A\* uitleggen, is het handig om te zien waarom simpelere methodes tekortschieten.

### Methode 1 — Rechtstreeks naar het doel (werkt niet)

De NPC loopt elke stap in de richting van het doel. Probleem: hij botst op een muur en komt er niet meer omheen.

### Methode 2 — Brute force: alle paden proberen (werkt, maar traag)

De NPC probeert letterlijk elk mogelijk pad. Dit werkt, maar in een grote wereld zijn er miljoenen mogelijke paden. Veel te langzaam.

### Methode 3 — A\* (slim en snel)

A\* combineert twee dingen:

- **Hoe ver ben ik al gelopen?** (niet onnodig ver omrijden)
- **Hoe ver ben ik nog van het doel?** (niet de verkeerde kant op gaan)

Door deze twee te combineren vindt A\* de kortste weg zonder alle paden te hoeven proberen.

---

## De kerngedachte: kostenberekening

A\* kent aan elk vakje (ook wel **node** of **knoop** genoemd) drie waarden toe:

| Waarde | Naam                | Betekenis                                                                      |
| ------ | ------------------- | ------------------------------------------------------------------------------ |
| **G**  | G-cost              | Afstand van het **startpunt** tot dit vakje — hoe ver ben ik al gelopen?       |
| **H**  | H-cost (heuristiek) | Schatting van de afstand van dit vakje tot het **doel** — hoe ver moet ik nog? |
| **F**  | F-cost              | G + H — de totale "kosten" van dit vakje                                       |

**A\* kiest altijd het vakje met de laagste F-cost om als volgende te bekijken.**

### Vergelijk het met een navigatie-app

Stel je rijdt van Amsterdam naar Parijs en je hebt twee routeopties:

- **Route A:** 50 km gereden, nog 450 km te gaan → F = 500 km
- **Route B:** 80 km gereden, maar snelweg, nog 380 km te gaan → F = 460 km

De navigatie-app kiest Route B, ook al heb je meer gereden — want de totale schatting is lager. Dat is precies wat A\* doet.

---

## De heuristiek (H-cost): de schatting

A\* kan het exacte resterende afstand niet weten (want hij kent de route nog niet). Daarom **schat** hij het.

De meest gebruikte schatting heet de **Manhattan distance**: tel het aantal stappen horizontaal + verticaal van het huidige vakje naar het doel.

```
Huidig vakje: (2, 1)
Doelvakje:    (5, 4)

H = |5 - 2| + |4 - 1|
H =    3    +    3
H =    6
```

Waarom "Manhattan"? In Manhattan (New York) kun je ook alleen horizontaal en verticaal rijden door het blokkengrid. Het is de kortst mogelijke afstand als er geen muren zijn.

> **Vuistregel:** de heuristiek mag de echte afstand nooit _overschatten_. Als hij dat wel doet, vindt A\* misschien niet de kortste route. Manhattan distance is altijd gelijk aan of lager dan de echte afstand — dat maakt het een goede heuristiek.

---

## Stap voor stap: A\* op een klein grid

Laten we A\* doorlopen op een 5×5 grid. `S` = start (0,0), `E` = doel (4,4), `#` = muur.

```
     0    1    2    3    4
0  [ S ] [   ] [   ] [   ] [   ]
1  [   ] [ # ] [   ] [   ] [   ]
2  [   ] [ # ] [   ] [ # ] [   ]
3  [   ] [   ] [   ] [ # ] [   ]
4  [   ] [   ] [   ] [   ] [ E ]
```

### De twee lijsten

A\* houdt twee lijsten bij:

- **Open lijst:** vakjes die nog bekeken moeten worden (kandidaten)
- **Gesloten lijst:** vakjes die al volledig afgehandeld zijn

---

### Ronde 1 — Begin bij het startpunt

We plaatsen **S (0,0)** op de open lijst.

- G = 0 (we zijn hier, nog niks gelopen)
- H = |4−0| + |4−0| = 8 (Manhattan distance naar het doel)
- F = 0 + 8 = **8**

We halen S van de open lijst en zetten hem op de **gesloten lijst**.  
Nu bekijken we alle **buren** van S: (1,0) en (0,1).

```
Buur (1,0):   G = 1,  H = |4−1|+|4−0| = 7,  F = 8
Buur (0,1):   G = 1,  H = |4−0|+|4−1| = 7,  F = 8
```

Beide buren gaan op de open lijst. We onthouden ook wie hun **ouder** is (S), zodat we later de route kunnen reconstrueren.

---

### Ronde 2 — Kies het vakje met de laagste F

Open lijst: (1,0) met F=8 en (0,1) met F=8. Gelijke F → kies willekeurig, bijv. **(1,0)**.

Buren van (1,0) die nog niet op de gesloten lijst staan en geen muur zijn: (2,0) en (0,0) is al gesloten.

```
Buur (2,0):   G = 2,  H = |4−2|+|4−0| = 6,  F = 8
```

Open lijst is nu: (0,1) F=8, (2,0) F=8.

---

### Ronde 3 — Verder verkennen

Dit proces herhaalt zich: pak steeds het vakje met de **laagste F**, voeg zijn buren toe, ga door totdat het doelvakje **E** de open lijst bereikt.

Wanneer **E** als beste kandidaat uit de open lijst komt, zijn we klaar. We volgen dan de ouder-verwijzingen terug van E naar S om de route te reconstrueren.

```
Gevonden route (voorbeeld):
(0,0) → (0,1) → (0,2) → (0,3) → (0,4) → (1,4) → (2,4) → (3,4) → (4,4)
```

---

## Het algoritme in pseudocode

Pseudocode is nep-code die de logica toont zonder aan één programmeertaal gebonden te zijn:

```
openLijst   = [ startVakje ]
geslotenLijst = []

zolang openLijst niet leeg is:

    huidig = vakje in openLijst met laagste F-cost

    als huidig == doelVakje:
        reconstrueer route via ouder-verwijzingen
        klaar!

    verplaats huidig van openLijst naar geslotenLijst

    voor elke buur van huidig:

        als buur een muur is of al in geslotenLijst: sla over

        nieuweG = huidig.G + afstand(huidig, buur)

        als buur niet in openLijst:
            voeg toe aan openLijst
        anders als nieuweG >= buur.G:
            sla over   (we hebben al een betere route naar deze buur)

        buur.ouder = huidig
        buur.G = nieuweG
        buur.H = manhattan(buur, doel)
        buur.F = buur.G + buur.H
```

---

## Route reconstrueren

Als A\* het doel bereikt, volg je de **ouder**-verwijzingen terug naar het startpunt. Elke node onthoudt wie hem heeft "ontdekt".

```
E  →  ouder: (3,4)
(3,4) →  ouder: (2,4)
(2,4) →  ouder: (1,4)
(1,4) →  ouder: (0,4)
...
(0,1) →  ouder: (0,0) = START

Draai de lijst om:
Route: (0,0) → (0,1) → ... → (4,4)
```

---

## A\* in Unity: NavMesh vs. zelf bouwen

In Unity hoef je A\* in de meeste gevallen **niet zelf te schrijven**. Unity's **NavMesh**-systeem (zie Les 8) doet al het pathfinding-werk voor je.

|                       | NavMesh (Unity ingebouwd)        | Eigen A\*-implementatie                     |
| --------------------- | -------------------------------- | ------------------------------------------- |
| **Wanneer gebruiken** | 3D-spellen, NPC's op een terrein | 2D grid-spellen, turn-based, puzzels        |
| **Hoe complex**       | Minimale code nodig              | Meer code, maar volledige controle          |
| **Flexibiliteit**     | Beperkt tot de NavMesh           | Aanpasbaar: diagonaal, gewogen tegels, etc. |

Begrijpen hoe A\* werkt helpt je om slimmere keuzes te maken, ook als je NavMesh gebruikt.

---

## Wat als vakjes verschillende kosten hebben?

Tot nu toe kostte elke stap **1**. Maar stel: moeras kost 3, weg kost 1, snelweg kost 0.5.

A\* werkt hier automatisch mee: vervang de vaste stapkosten door de **tilekosten** in de G-berekening.

```
nieuweG = huidig.G + buur.tileKosten
```

A\* zal dan liever over snelwegen rijden dan door het moeras — precies zoals een echte navigatie-app.

---

## Samenvatting

```
F = G + H
    │   └── Schatting: hoe ver nog naar het doel? (Manhattan distance)
    └────── Zekerheid: hoe ver al gelopen vanaf het start?
```

**A\* in vier stappen:**

1. Begin bij het startpunt, zet het op de **open lijst**
2. Pak het vakje met de **laagste F** van de open lijst
3. Voeg zijn **buren** toe aan de open lijst (als ze nog niet bezocht zijn)
4. Herhaal totdat het **doel** gepakt wordt — reconstrueer dan de route via ouder-verwijzingen

**In één zin:** A\* vindt de kortste route door slim te combineren hoeveel je al gelopen hebt en hoe ver je nog moet, zodat het nooit onnodig ver om hoeft te zoeken.
