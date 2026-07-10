# De Sprong Formule Uitgelegd

## De code

```csharp
verticalVelocity = Mathf.Sqrt(2f * Mathf.Abs(gravity) * jumpHeight);
```

Deze regel berekent hoe hard je karakter omhoog moet worden "geschoten" om precies op de gewenste spronghoogte uit te komen. Laten we stap voor stap doorlopen wat hier gebeurt.

---

## Wat is het probleem dat we oplossen?

Stel je voor: je wilt dat je karakter **2 meter** hoog springt. Je kunt niet zomaar zeggen "ga 2 meter omhoog" — dat zou eruitzien alsof je karakter teleporteert. In plaats daarvan willen we een **natuurlijke sprong**: het karakter gaat snel omhoog, vertraagt, en valt dan weer naar beneden.

Daarvoor hebben we een **beginsnelheid** nodig — hoe hard het karakter op het moment van afzet omhoog gaat. De formule berekent precies die beginsnelheid.

---

## De onderdelen van de formule

| Code | Betekenis | Voorbeeld |
|------|-----------|-----------|
| `jumpHeight` | Hoe hoog je wilt springen (in Unity-eenheden/meters) | `2f` |
| `gravity` | Hoe snel je karakter naar beneden wordt getrokken (negatief getal) | `-20f` |
| `Mathf.Abs(gravity)` | Maakt het gravity-getal positief (we hebben alleen de "sterkte" nodig) | `20f` |
| `Mathf.Sqrt(...)` | Berekent de wortel van het getal (het omgekeerde van kwadraat) | `√80 ≈ 8.94` |

---

## Stap voor stap doorrekenen

Laten we het doorrekenen met de standaardwaarden: `jumpHeight = 2` en `gravity = -20`.

### Stap 1 — Maak gravity positief

```
Mathf.Abs(-20) = 20
```

Gravity is in de code een negatief getal (want het trekt je *naar beneden*). Maar voor de berekening hebben we alleen de **sterkte** nodig, niet de richting. `Mathf.Abs()` verwijdert het minteken.

### Stap 2 — Vermenigvuldig alles

```
2 × 20 × 2 = 80
```

Dit tussenresultaat (80) zegt op zich nog niet zoveel — het is een wiskundige tussenstap.

### Stap 3 — Neem de wortel

```
√80 ≈ 8.94
```

Het resultaat is **8.94**. Dit is de beginsnelheid (in meters per seconde) waarmee je karakter omhoog gaat op het moment dat je op de sprongknop drukt.

---

## Waarom werkt dit? De intuïtie

Wanneer je karakter springt, gebeurt er elke frame het volgende:

1. Het karakter gaat omhoog met de huidige `verticalVelocity`
2. De `gravity` trekt die snelheid een beetje naar beneden
3. Op een gegeven moment is de snelheid **0** — dat is het hoogste punt
4. Daarna wordt de snelheid negatief en valt het karakter weer naar beneden

De formule zorgt ervoor dat op het moment dat de snelheid precies 0 bereikt, het karakter op **exact de juiste hoogte** is.

### Vergelijk het met een bal omhoog gooien

- Gooi je een bal **zachtjes** omhoog → hij gaat niet zo hoog
- Gooi je een bal **hard** omhoog → hij gaat heel hoog
- De formule berekent precies hoe **hard** je moet gooien om een bepaalde hoogte te bereiken

---

## Waar komt de formule vandaan?

Dit is een natuurkundige formule die je misschien herkent uit de middelbare school:

$$v = \sqrt{2 \cdot g \cdot h}$$

Waarbij:
- $v$ = beginsnelheid (hoe hard je omhoog gaat)
- $g$ = zwaartekracht (hoe sterk je naar beneden wordt getrokken)
- $h$ = gewenste hoogte

Deze formule komt oorspronkelijk van de energiewet uit de natuurkunde: de bewegingsenergie ($\frac{1}{2}mv^2$) wordt omgezet in zwaartekrachtsenergie ($mgh$). Als je die aan elkaar gelijk stelt en de $m$ (massa) wegstreept, krijg je:

$$\frac{1}{2}v^2 = g \cdot h$$

$$v^2 = 2 \cdot g \cdot h$$

$$v = \sqrt{2 \cdot g \cdot h}$$

**Je hoeft dit niet te onthouden!** Het belangrijkste is dat je begrijpt *wat* de formule doet: de juiste beginsnelheid berekenen voor een gewenste spronghoogte.

---

## Wat gebeurt er als je de waarden verandert?

| Verandering | Effect |
|---|---|
| `jumpHeight` hoger (bv. `5`) | Karakter springt hoger, beginsnelheid wordt groter |
| `jumpHeight` lager (bv. `0.5`) | Karakter springt lager, meer een "hopje" |
| `gravity` sterker (bv. `-30`) | Karakter wordt sneller naar beneden getrokken, maar de formule compenseert: de beginsnelheid wordt ook groter zodat je alsnog dezelfde hoogte haalt. De sprong voelt wel **sneller en strakker** |
| `gravity` zwakker (bv. `-5`) | Karakter zweeft langer in de lucht, de sprong voelt **zweverig en langzaam** |

### Tip voor game feel

- **Zwaardere gravity** (bv. `-30` tot `-40`) → snelle, responsive sprongen (denk aan platformers zoals Celeste)
- **Lichtere gravity** (bv. `-10`) → zweverige sprongen (denk aan een ruimtespel)
- De `jumpHeight` bepaalt *hoe hoog*, de `gravity` bepaalt *hoe het voelt*

---

## Samenvatting

```
verticalVelocity = Mathf.Sqrt(2f * Mathf.Abs(gravity) * jumpHeight);
                   ─────────── ──── ──────────────────── ──────────
                   Neem de      ×2   Maak gravity         Gewenste
                   wortel van        positief              hoogte
```

**In één zin:** de formule berekent hoe hard je karakter omhoog moet worden gelanceerd zodat het — rekening houdend met de zwaartekracht — precies op de gewenste hoogte uitkomt.
