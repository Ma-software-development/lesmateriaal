# PROG C# — Module 4

Deze map bevat lesmateriaal, opdrachten en voorbeelden voor het vak **Programmeren in C#** binnen **M4 Game Development**.

De focus ligt op het verder structureren van code, het werken met objectgeoriënteerd programmeren en het toepassen van C# binnen kleine programmeeropdrachten of game development-contexten.

---

## Inhoud

In deze map vind je materiaal zoals:

* lespresentaties
* programmeervoorbeelden
* opdrachten
* oefenbestanden
* ondersteunende documenten

De bestanden zijn bedoeld voor studenten die al de basis van programmeren kennen en verder oefenen met C#.

---

## Leerdoelen

Na het werken met dit materiaal kun je onder andere:

| Onderwerp      | Je kunt...                                                 |
| -------------- | ---------------------------------------------------------- |
| Variabelen     | gegevens opslaan en gebruiken in C#                        |
| Datatypes      | geschikte datatypes kiezen voor verschillende soorten data |
| Functies       | code opdelen in herbruikbare onderdelen                    |
| Parameters     | waarden meegeven aan functies                              |
| Return values  | functies waarden laten teruggeven                          |
| Conditionals   | keuzes maken met `if`, `else if` en `else`                 |
| Loops          | herhalingen maken met bijvoorbeeld `for` en `foreach`      |
| Arrays / Lists | meerdere waarden opslaan en verwerken                      |
| Classes        | eigen objecttypes maken                                    |
| Objecten       | instanties van classes gebruiken                           |
| Constructors   | objecten op een nette manier initialiseren                 |
| Encapsulation  | gegevens afschermen met private fields en properties       |
| Structuur      | code overzichtelijk verdelen over meerdere bestanden       |

---

## Benodigdheden

Voor deze lessen heb je nodig:

* Visual Studio of Visual Studio Code
* .NET SDK
* basiskennis van programmeren
* toegang tot deze repository
* eventueel Unity, wanneer de opdracht daaraan gekoppeld is

Controleer of .NET goed geïnstalleerd is met:

```bash
dotnet --version
```

---

## Werkwijze

Gebruik de bestanden in deze map als volgt:

1. Bekijk eerst de lespresentatie of uitleg.
2. Open daarna de bijbehorende opdracht.
3. Maak de opdracht zelfstandig of in tweetallen.
4. Test je code regelmatig.
5. Lever je werk in volgens de afspraken van de docent.

---

## Voorbeeld projectstructuur

Een C# consoleproject kan er bijvoorbeeld zo uitzien:

```text
MijnProject/
├── Program.cs
├── Student.cs
├── SchoolClass.cs
└── MijnProject.csproj
```

Voorbeeld:

```csharp
public class Student
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name} is {Age} jaar oud.");
    }
}
```

Gebruik in `Program.cs`:

```csharp
Student student = new Student("Alex", 17);
student.PrintInfo();
```

---

## Afspraken voor code

Houd je code leesbaar en consistent.

| Afspraak                         | Voorbeeld                                  |
| -------------------------------- | ------------------------------------------ |
| Gebruik duidelijke namen         | `studentName` in plaats van `x`            |
| Eén class per bestand            | `Student.cs`, `Teacher.cs`, `Classroom.cs` |
| Schrijf functies kort en gericht | één functie heeft één duidelijke taak      |
| Test regelmatig                  | run je programma na kleine wijzigingen     |
| Gebruik comments waar nodig      | leg lastige code kort uit                  |
| Vermijd dubbele code             | gebruik functies of classes                |

---

## Inleveren

Lever je werk in volgens de instructies van de docent.

Meestal betekent dit:

* projectmap netjes gestructureerd
* code compileert zonder errors
* opdracht is volledig uitgewerkt
* namen van bestanden en classes zijn duidelijk
* code is leesbaar en getest

---

## Beoordeling

Er wordt onder andere gekeken naar:

| Criterium       | Beschrijving                                       |
| --------------- | -------------------------------------------------- |
| Functionaliteit | Doet het programma wat gevraagd wordt?             |
| Codekwaliteit   | Is de code netjes, duidelijk en logisch opgebouwd? |
| Structuur       | Zijn classes, functies en bestanden goed verdeeld? |
| OOP             | Worden classes en objecten correct gebruikt?       |
| Testen          | Is zichtbaar dat het programma getest is?          |
| Zelfstandigheid | Zijn gemaakte keuzes logisch en te verklaren?      |

---

## Tips

* Begin klein.
* Test na elke stap.
* Lees foutmeldingen rustig.
* Gebruik duidelijke namen.
* Maak eerst de basis werkend voordat je uitbreidingen toevoegt.
* Vraag hulp met een concrete vraag en laat zien wat je al geprobeerd hebt.

---

## Veelvoorkomende fouten

| Fout                                 | Oplossing                                         |
| ------------------------------------ | ------------------------------------------------- |
| Vergeten `;`                         | Controleer het einde van je statements            |
| Verkeerde hoofdletters               | C# is hoofdlettergevoelig                         |
| Functie wordt niet aangeroepen       | Controleer of je functie in `Main` wordt gebruikt |
| Variabele bestaat niet in deze scope | Controleer waar je variabele is aangemaakt        |
| Class-bestand niet opgeslagen        | Controleer of het bestand in het project staat    |
| Constructor klopt niet               | Controleer parameters en object-aanmaak           |

---

## Handige links

* [Microsoft C# documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [Microsoft .NET documentation](https://learn.microsoft.com/en-us/dotnet/)
* [Unity C# scripting](https://docs.unity3d.com/Manual/scripting.html)

---

## Licentie / gebruik

Dit lesmateriaal is bedoeld voor onderwijsdoeleinden binnen de opleiding Game Development.

Controleer bij hergebruik of aanpassen altijd de afspraken van de opleiding of docent.
