# Triangle of Interception in Game Development

De **Triangle of Interception** (onderscheppingsdriehoek) is een manier om te begrijpen hoe een bewegende game-entiteit een ander bewegend doel kan **onderscheppen**. In plaats van naar de *huidige* positie van het doel te bewegen, berekent de achtervolger waar het doel in de toekomst zal zijn en beweegt hij naar dat punt.

> **Terminologie:** *Triangle of Interception* is hier een beschrijvende naam voor het geometrische principe achter **predictive pursuit** of **interception steering**. Het is niet per se een gestandaardiseerde term binnen alle game-engines.

## 1. De drie punten van de driehoek

- **A — Interceptor:** de huidige positie van bijvoorbeeld een vijand, raket of NPC.
- **B — Target:** de huidige positie van de speler of een ander bewegend object.
- **C — Interception point:** de toekomstige positie waar interceptor en target elkaar kunnen ontmoeten.

```text
                    C ●  Voorspeld onderscheppingspunt
                     /|
                    / |
     route A → C   /  |  route B → C
                  /   |
                 /    |
 Interceptor A ●──────● B Target (nu)
              huidige onderlinge afstand
```

De drie zijden geven de geometrie weer: **A → B** is de huidige afstand tussen beide objecten, **B → C** is de verplaatsing van het doel en **A → C** is de benodigde route van de interceptor. Het diagram is schematisch, niet op schaal.

## 2. Chasing versus interception

### Gewoon achtervolgen (chasing)

Een vijand beweegt steeds naar de **huidige positie** van de speler. Als de speler opzij beweegt, moet de vijand voortdurend bijsturen en kan hij achter de speler blijven hangen.

### Voorspellend onderscheppen (interception)

De vijand schat waar de speler na een bepaalde tijd zal staan en beweegt direct naar die **toekomstige positie**. Zo kan de vijand de speler de pas afsnijden.

Voorbeelden in games zijn een raket die een bewegend ruimteschip probeert te raken, een bewaker die een rennende speler onderschept of een NPC die naar een passerend voertuig loopt.

## 3. Hoe bereken je het onderscheppingspunt?

We gaan eerst uit van een vereenvoudigde situatie:

- Beide objecten bewegen in een open 2D- of 3D-ruimte.
- Het doel heeft een **constante snelheid en richting**.
- De interceptor kan **meteen de juiste richting kiezen** en beweegt met een **constante snelheid**.
- Obstakels, acceleratie en draaisnelheid negeren we voorlopig.

Gebruik de volgende variabelen:

| Variabele | Betekenis |
| --- | --- |
| `A` | Positie van de interceptor |
| `B` | Positie van het doel |
| `v` | Snelheidsvector van het doel (richting × snelheid) |
| `s` | Bewegingssnelheid van de interceptor (positief getal) |
| `t` | Tijd tot onderschepping |
| `C` | Onderscheppingspunt |

Na `t` seconden bevindt het doel zich op:

```text
C = B + v * t
```

Om tegelijk bij `C` te komen, moet de interceptor de afstand naar `C` kunnen afleggen:

```text
length(C - A) = s * t
```

Stel `r = B - A`. Door beide formules te combineren en te kwadrateren, krijg je:

```text
(v · v - s²)t² + 2(r · v)t + (r · r) = 0
```

Hier betekent `·` het **dotproduct** van twee vectoren. Dit is een kwadratische vergelijking `a*t² + b*t + c = 0`, waarbij:

```text
a = dot(v, v) - s * s
b = 2 * dot(r, v)
c = dot(r, r)
```

Bereken de mogelijke oplossingen voor `t` en kies de **kleinste niet-negatieve tijd**. Als er geen reële, niet-negatieve oplossing bestaat, is onderscheppen onder deze aannames niet mogelijk. De onderscheppingspositie is vervolgens `C = B + v * t`.

## 4. Rekenvoorbeeld

Stel:

- De vijand staat op `A = (0, 0)`.
- De speler staat op `B = (10, 0)`.
- De speler beweegt omhoog met `v = (0, 2)` eenheden per seconde.
- De vijand kan bewegen met `s = 5` eenheden per seconde.

Dan is `r = (10, 0)` en geldt:

```text
a = 4 - 25 = -21
b = 0
c = 100

-21t² + 100 = 0
t = sqrt(100 / 21) ≈ 2,18 seconden

C = (10, 0) + (0, 2) * 2,18
C ≈ (10, 4,36)
```

De vijand moet dus ongeveer naar **(10, 4,36)** bewegen om de speler na **2,18 seconden** te ontmoeten — zolang de speler zijn huidige snelheid en richting behoudt.

## 5. Voorbeeldimplementatie in JavaScript

Deze functie werkt met 2D-vectoren `{ x, y }` en retourneert een voorspeld onderscheppingspunt, of `null` wanneer er geen geldige onderschepping is.

```js
function findInterceptionPoint(interceptor, target, targetVelocity, interceptorSpeed) {
  if (interceptorSpeed <= 0) return null;

  const rx = target.x - interceptor.x;
  const ry = target.y - interceptor.y;
  const vx = targetVelocity.x;
  const vy = targetVelocity.y;

  const a = vx * vx + vy * vy - interceptorSpeed * interceptorSpeed;
  const b = 2 * (rx * vx + ry * vy);
  const c = rx * rx + ry * ry;
  const EPSILON = 1e-8;

  // De interceptor staat al bij het doel.
  if (c < EPSILON) return { ...target };

  let t;

  if (Math.abs(a) < EPSILON) {
    // Bijna lineaire vergelijking: b*t + c = 0.
    if (Math.abs(b) < EPSILON) return null;
    t = -c / b;
    if (t < 0) return null;
  } else {
    const discriminant = b * b - 4 * a * c;
    if (discriminant < 0) return null;

    const root = Math.sqrt(discriminant);
    const t1 = (-b - root) / (2 * a);
    const t2 = (-b + root) / (2 * a);
    const times = [t1, t2].filter((time) => time >= 0);
    if (times.length === 0) return null;
    t = Math.min(...times);
  }

  return {
    x: target.x + vx * t,
    y: target.y + vy * t,
  };
}

// Voorbeeld:
const interceptPoint = findInterceptionPoint(
  { x: 0, y: 0 },   // Vijand
  { x: 10, y: 0 },  // Speler
  { x: 0, y: 2 },   // Snelheidsvector speler
  5                 // Snelheid vijand
);

console.log(interceptPoint); // Ongeveer { x: 10, y: 4.364 }
```

### Toepassing in je game-loop

1. Lees de huidige positie en **velocity** van het doel.
2. Bereken het voorspelde onderscheppingspunt.
3. Bepaal de richting vanaf de interceptor naar dat punt.
4. Laat je bewegingssysteem in die richting sturen.
5. Bereken opnieuw wanneer het doel van richting of snelheid verandert.

Voor een eenvoudige AI kun je, als de functie `null` teruggeeft, terugvallen op normale achtervolging of een andere AI-strategie kiezen.

## 6. Belangrijke aandachtspunten

- **Obstakels:** een wiskundig onderscheppingspunt kan achter een muur liggen. Combineer deze techniek zo nodig met pathfinding, zoals A* of een navmesh.
- **Acceleratie en draaibeperkingen:** de berekening veronderstelt dat de interceptor direct in de gewenste richting kan bewegen. Een voertuig of raket met beperkte wendbaarheid kan extra besturing nodig hebben.
- **Veranderende doelbeweging:** als de speler plots van richting verandert, is de voorspelling niet meer exact. Bereken regelmatig een nieuw punt.
- **Game feel:** perfecte onderschepping kan te moeilijk of onnatuurlijk aanvoelen. Voeg indien gewenst reactietijd, onzekerheid of een maximale voorspeltijd toe.
- **Aankomst en botsing:** dicht genoeg bij het voorspelde punt komen is in de praktijk vaak voldoende; gebruik een hitbox of afstandsdrempel in plaats van perfecte coördinaatgelijkheid.

## 7. Samenvatting

De **Triangle of Interception** maakt het verschil zichtbaar tussen het volgen van waar een target **nu is** en bewegen naar waar het target **straks zal zijn**. Met de posities, de snelheidsvector van het doel en de snelheid van de interceptor kun je het onderscheppingspunt berekenen. Dat vormt een bruikbare basis voor slimmere enemy AI, homing-projectielen en andere voorspellende bewegingssystemen.

**Kort gezegd:** *Niet achter de speler aan rennen, maar de speler de pas afsnijden.*
