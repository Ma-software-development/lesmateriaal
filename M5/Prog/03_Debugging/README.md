# PROG les 3: Debugging

Wat is een Bug?
Wat is het verschil met een Error?

Een bug is een onverwachte fout of ongewenst gedrag in je programma, vaak veroorzaakt door een fout in de logica of implementatie. Een error daarentegen is een specifieke foutmelding die optreedt wanneer het programma niet verder kan uitvoeren, bijvoorbeeld door een ontbrekend bestand of een syntax-fout.

Bugs kunnen makkelijk onopgemerkt blijven, terwijl errors direct zichtbaar zijn en het programma onderbreken.

## Documenteren van bugs

Bij het maken van games is snel, op tijd en effectief debuggen van cruciaal belang.
Ook het vroeg herkennen en goed vastleggen van bugs hoort hierbij.

Bugs die genegeerd worden, kunnen later in het project tot vreemde onverwachte situaties leiden. Het wordt na verloop van tijd steeds lastiger om deze op te lossen omdat ze door je project verweven zitten. Hoe langer je wacht hoe meer schade ze dus op kunnen leveren aan je project.

![bug](../src/03_01_bug.gif)

Wat betreft het snel vastleggen van je Bugs is het belangrijk om dat gelijk te doen als je deze tegenkomt. Probeer de bug te reproduceren maak 1 of meer screenshots en een duidelijke beknopte omschrijving van wat er eigenlijk moet gebeuren en wat er fout gaat. Noteer ook de oorzaak als je dit denkt te weten en eventueel een mogelijke oplossing.

- screenshots bug
- wat zou er moeten gebeuren?
- evt. oorzaak indien bekend / vermoeden
- evt. oplossing indien bekend

Spreek binnen je team af waar de bugs vastgelegd worden en houd je daaraan. Een goede plek is bijvoorbeeld in een trello of op github onder de **Issues** van je project.
![issues](../src/03_02_issues.png)

**Doe dit altijd voor alle bugs die je tegenkomt!** Ook als je denkt dat ze wel even snel op te lossen zijn. Snelle oplossingen zijn namenlijk niet altijd goede of echte oplossingen.

Snelle "Oplossingen" kunnen ook weer leiden tot nieuwe bugs. Het is dus belangrijk om tot de kern van van het probleem te komen.

Zorg met een goede documentatie van je bugs dat je altijd overzicht hebt van wat er allemaal geprobeerd is en wat de problemen zijn. Ook is het fijn om later terug te kunnen zien welke oplossingen gewerkt hebben en welke niet.

## Tools om te debuggen

1 van de simpelste tools om te debuggen is natuurlijk de **console** in Unity. Met het commando **Debug.Log()** hebben jullie al vaker gezocht naar de oorzaak en oplossing van een probleem in je game of code. Je kunt hiermee kijken of de **flow** van je code klopt. Door te checken of een bepaald stuk code wel word uitgevoerd en of de volgorde klopt. Je kunt ook kijken of de waarde van een variabele wel klopt met wat je verwacht.

### Debug Class

Wist je dat er nog veel meer handige tools in de [Debug class](https://docs.unity3d.com/ScriptReference/Debug.html) zitten? Waaronder voor het geven van **warnings** of **errors** en het maken van **assertions** (testen van bepaalde voorwaarden).

Je kunt in Unity zelfs gameobjecten die gelogd worden laten highlighten in het **hierarchy** window.

### Breakpoints

Toch is het zo dat het best omslachtig kan zijn om steeds maar code aan je scripts te moeten toevoegen om te debuggen. Hierom geven alle fatsoenlijke code editors je de mogelijkheid om zogenaamde **breakpoints** toe te voegen.

Met deze **breakpoints** kun je snel alle informatie ophalen over states van je verschillende variabelen en gameobjecten. Dit kun je heel snel doen door een "breakpoint" (pode punt in de linker balk) naast een regel code te plaatsen.

Unity pauzeert de game als je de regel code met de breakpoint hebt bereikt. Je kunt dan regel voor regel door de code uitvoeren en de states (waarden) van alle betrokken variabelen en objecten teruglezen. Ook de flow van je code wordt duidelijk omdat je er stap voor stap doorheen gaat.

Om de waarden van je variabelen en objecten te kunnen uitlezen moet je het autos window open hebben. Dit zou automatisch moeten gaan bij het gebruiken van breakpoints. Anders is deze te vinden onder **Debug > Windows > Autos**

![breakpoint](../src/03_03_breakpoint.png)

### Voorbeelden

In [deze PDF](Debugging.pdf) kun je voorbeelden zien van hoe je de een aantal Debug functies en Breakpoints kunt gebruiken met Unity en Visual Studio.
[![pdf](../src/03_04_pdf.png)](Debugging.pdf)

<a name = "opdracht5"></a>

### Opdracht 3A : Wat veroorzaakt de bugs?

![find bugs](../src/03_05_find_bugs.png)
Noteer de oorzaken van deze 2 bugs in je readme en push deze naar je PROG repo op Github.

### Opdracht 3B : Vastleggen van Mythe bugs

Pak je project Mythe erbij en noteer minimaal 3 verschillende bugs. Zorg voor een duidelijke Omschrijving van:

- wat er eigenlijk zou moeten gebeuren.
- wat er verkeerd gaat. Maak gebruik van screenshots.
- wat je denkt dat de oorzaak kan zijn.
- evt hoe je denkt dat dit opgelost kan worden.
- welke vervolg acties nodig zijn.

Doe dit door 3 nieuwe issues aan te maken op de repo van je Mythe project. Lever van elke gemaakte issue een screenshot in op je PROG repo.

### Opdracht 3C : Breakpoints

Koppel voor je Towerdefense project Unity aan je Editor en plaats een breakpoint. Laat zien dat je de breakpoints kunt gebruiken en dat de states van je variabelen objecten te zien zijn in het Autos window.

Maak een screenshot van je editor terwijl je breakpoint actief is. Lever je screenshot in op je PROG repo.

### Opdracht 5D : Bijhouden bugs voor Towerdefense

Houd voor je Towerdefense game alle bugs bij die je tegenkomt. Dus ook als je ze gelijk op weet te lossen.

doe dit in de Issues van je Towerdefense Repo.

Noteer voor elke bug:

- wat er eigenlijk zou moeten gebeuren.
- wat er verkeerd gaat. Maak gebruik van screenshots.
- wat je denkt dat de oorzaak kan zijn.
- evt hoe je denkt dat dit opgelost kan worden.
- welke vervolg acties nodig zijn.

Als je de bug hebt opgelost moet je de issue ook afsluiten.

Aan het einde van het project mag je game dus geen ongedocumenteerde bugs hebben!

Plaats een link naar je Towerdefense issues op de readme van je PROG repo.
