# Markdown

## Lesoverzicht

- Wat is Markdown?
- Markdown-extensies installeren in Visual Studio Code.
- Opmaakregels gebruiken.
- Hyperlinks en afbeeldingen toevoegen.
- Lijsten en checklists maken.
- Codefragmenten invoegen.
- Een README maken voor je GitHub-repository.

## Wat is Markdown?

Markdown is een opmaaktaal voor documenten. Je voegt eenvoudige tekens toe aan tekst om bijvoorbeeld koppen, vetgedrukte woorden, lijsten en links te maken. Markdown is geen programmeertaal.

Een Markdown-bestand heeft de extensie `.md`. In een editor zie je de tekst met de opmaaktekens. Een Markdown-weergave, zoals op GitHub, toont het opgemaakte document.

## Software en extensies

Gebruik Visual Studio Code en installeer de volgende extensies:

- **markdownlint**: controleert de Markdown-syntax.
- **Markdown All in One**: biedt ondersteuning bij het schrijven van Markdown.

Open het extensiepaneel in Visual Studio Code, zoek de extensies en installeer ze.

[Documentatie over Markdown in Visual Studio Code](https://code.visualstudio.com/docs/languages/markdown)

## Markdown-syntax

De voorbeelden hieronder werken als naslag bij de les. Codeblokken tonen de tekens die je in je Markdown-bestand schrijft.

### Kopteksten

Gebruik een of meer hekjes, gevolgd door een spatie. Het aantal hekjes bepaalt het niveau van de kop.

```markdown
# Kop op niveau 1
## Kop op niveau 2
### Kop op niveau 3
```

### Paragrafen en regeleinden

Laat een lege regel tussen paragrafen:

```markdown
Dit is de eerste paragraaf.

Dit is de tweede paragraaf.
```

Voor een geforceerd regeleinde zet je twee spaties aan het einde van een regel. In dit voorbeeld staan twee spaties na `regel.`:

```markdown
Dit is de eerste regel.  
Dit staat op de volgende regel.
```

### Vet en schuingedrukt

```markdown
*Schuingedrukte tekst*
_Schuingedrukte tekst_

**Vetgedrukte tekst**
__Vetgedrukte tekst__
```

### Citaten

```markdown
> Dit is een citaat.
```

### Hyperlinks en e-mailadressen

```markdown
[Naam van de website](https://voorbeeld.nl)

<naam@voorbeeld.nl>
```

### Afbeeldingen

Zet de beschrijving tussen vierkante haken en het pad naar de afbeelding tussen ronde haken. Begin met een uitroepteken.

```markdown
![Beschrijving van de afbeelding](afbeelding.jpg)
```

Als de afbeelding in dezelfde map staat als je README, gebruik je de bestandsnaam. Staat de afbeelding in een submap, neem die map dan op in het pad:

```markdown
![Beschrijving van het recept](afbeeldingen/recept.jpg)
```

### Ongenummerde lijsten

Gebruik `-`, `*` of `+` voor de lijstitems.

```markdown
- Eerste item
- Tweede item
- Derde item
```

### Genummerde lijsten

```markdown
1. Eerste stap
2. Tweede stap
3. Derde stap
```

### Sublijsten

Spring in om een sublijst te maken:

```markdown
1. Eerste item
   1. Eerste subitem
   2. Tweede subitem
2. Tweede item
```

### Checklists

```markdown
- [ ] Nog te doen
- [x] Afgerond
```

### Codefragmenten

Gebruik enkele backticks voor code binnen een zin:

```markdown
Het bestand heet `README.md`.
```

Gebruik drie backticks op aparte regels voor een codeblok. Je kunt achter de eerste drie backticks de taal zetten:

````markdown
```python
print("Hallo wereld!")
```
````

### Horizontale lijnen

```markdown
---
```

Je kunt ook drie sterretjes (`***`) gebruiken.

## Zelfstandig oefenen

Doe zelfstandig de [Nederlandstalige Markdown-tutorial](https://www.markdowntutorial.com/nl/).

Welke syntaxregels ken je daarna?

- [ ] Kopteksten.
- [ ] Paragrafen en een geforceerd regeleinde.
- [ ] Vet en schuingedrukt.
- [ ] Hyperlinks.
- [ ] Lijsten.
- [ ] Afbeeldingen.

## Markdown en GitHub

Maak altijd een `README.md` aan in je Git-repository. GitHub toont dit bestand standaard als opgemaakt document op de repositorypagina.

Schrijf hierin nuttige documentatie over je project en code.

## Opdracht: een recept in je README

Je schrijft een Markdown-document en zet dit in een nieuwe GitHub-repository. Bij het openen van de repository zie je vervolgens jouw opgemaakte pagina.

### Deel 1: repository aanmaken

1. Maak een nieuwe GitHub-repository met de naam `skil_les05`.
2. Vink bij het aanmaken de optie aan om een `README.md` toe te voegen.
3. Clone deze repository naar je laptop.

### Deel 2: het recept schrijven

1. Open het bestand `README.md` uit de repository `skil_les05` op je laptop in Visual Studio Code.
2. Zoek via Google een lekker recept en een bijbehorende afbeelding, of gebruik een eigen recept.
3. Zet de afbeelding in de map van je repository.
4. Schrijf het recept met de volgende Markdown-opmaak:

   - Een kop op **niveau 1** met de titel van het recept.
   - De afbeelding van het recept.
   - Een kop op **niveau 2** met de tekst **BENODIGDHEDEN**.
   - Een **ongenummerde lijst** met de ingrediënten en de hoeveelheden.
   - Een kop op **niveau 3** met de tekst **BEREIDING**.
   - Een **genummerde lijst** met alle bereidingsstappen.
   - Een **link** naar de website waar je het recept hebt gevonden.

Dit sjabloon helpt je op weg. Vervang de voorbeeldtekst, afbeeldingsnaam en link door de gegevens van jouw recept:

```markdown
# Titel van het recept

![Beschrijving van het recept](recept.jpg)

## BENODIGDHEDEN

- Hoeveelheid en ingrediënt
- Hoeveelheid en ingrediënt

### BEREIDING

1. Eerste bereidingsstap.
2. Tweede bereidingsstap.

[Bron van het recept](https://voorbeeld.nl/recept)
```

### Deel 3: publiceren op GitHub

1. Voeg de veranderingen in `README.md` en de afbeelding toe aan Git.
2. Maak een commit met een duidelijke commitmessage.
3. Gebruik `git push` om de wijzigingen van je computer naar je GitHub-repository te sturen.
4. Open je repositorypagina op GitHub en bekijk het opgemaakte document.

Voorbeeldcommando's vanuit de map van je repository:

```bash
git add README.md recept.jpg
git commit -m "Voeg recept toe aan README"
git push
```

Pas `recept.jpg` aan als jouw afbeelding een andere naam of een ander pad heeft.

## Samenvatting

- Markdown is een opmaaktaal voor documenten en geen programmeertaal.
- De syntax bestaat uit eenvoudige opmaakregels die makkelijk te leren zijn.
- Er zijn speciale extensies beschikbaar voor je code-editor (IDE).
- GitHub toont `README.md` standaard als opgemaakt document.
- Maak altijd een README in je repository met nuttige informatie.
