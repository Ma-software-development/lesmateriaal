# PROG les 7: Class Diagrams

In deze les gaan we het hebben over class diagrams. [neem deze presentatie door](ClassDiagrams.pdf).

## UML

Een class diagram is onderdeel van de **UML** oftewel de **Unified Modelling Language**. Dit is een verzameling van modellen waarmee je technische ontwerpen kunt maken van sotware en code. [Meer over UML vind je hier.](https://www.uml.org/)

## Nut

Een class diagram kun je op 3 manieren goed inzetten:

1. Het in kaart brengen van een reeds bestaande codebase om zo weer een beetje overzicht te creeeren.

2. Het ontwerpen van je codebase voordat je begint met programmeren zodat je een beginstructuur hebt waar je binnen kunt blijven.

3. Het uitleggen van je structuur aan andere developers.

## Onderdelen van een class

In een class diagram kun je al je classes weergeven uit een project. Je kunt daarbij de **inhoud** van die classes zichtbaar maken. Dit zijn de **Attributes** en **Operations** van een class. Oftewel de **variabelen** en **methoden** van een class.

```mermaid
classDiagram

class Class{
    + attribute, variabele
    + Operation(), method()
}

```

## Relaties, Inheritance & Generalization

In een class diagram kun je ook de relaties die verschillende classes met elkaar hebben aangeven. Dit kunnen bijvoorbeeld relaties van overerving zijn (ook wel generalization).

Deze geef je aan in dit format:

```mermaid
---
title: Inheritance / Genralization
---
classDiagram

Parent <|-- Child
```

In het bovenstaande voorbeeld erft de Child over van de Parent.

## Relaties, Dependancies

Vaak wordt er tussen classes informatie uitgewisseld. bijvoorbeeld via getters, setters en public methods. Je kunt dan spreken van een dependancy. Deze kun je in een class diagram ook weergeven met behulp van het volgende format:

```mermaid
---
title: Dependancy
---
    classDiagram

    UI ..> Player
    class UI{
        + ShowLife()
    }

    class Player{
        + int life
    }
```

In het bovenstaande voorbeeld is de UI afhankelijk van de Player class. Zonder de Player kan de UI geen **life** waarde krijgen en breekt de code.

## Mermaid

Om class diagrammen te maken heb je heel erg veel verschillende tools. Je zou het in photoshop kunnen doen of zelfs in paint(niet aan te raden). Echter is het lastigste niet de inhoud goed krijgen maar de ordening van de blokjes. Met de **Mermaid** tool gaat dat ordenen vanzelf en hoef je alleen de inhoud en de relaties van je classes aan te geven.

Mermaid werkt standaard in je markdown bestanden. Je kunt dit dus in je readme verwerken.

Hier vind je de [Mermaid syntax](https://mermaid.js.org/syntax/classDiagram.html) voor het maken van je eigen class diagrammen in je eigen markdown files (.md) zoals je README.md

Je kunt ook de bron van deze readme bekijken om te zien hoe ik de bovenstaande schema's in mermaid heb gemaakt.

VSCode heeft ook een handige Markdown Preview Mermaid Support extension. Het is ook zeker handig om die te installeren.

![mermaid preview](../../../M5/Prog/src/08_01_mermaid_preview.png)

Hiermee kun je terwijl je bezig bent goed zien wat er gebeurt in je diagrammen.

![mermaid preview](../../../M5/Prog/src/08_02_mermaid_preview_2.png)

## Opdracht 10: Class Diagram van je TD project

Maak een class diagram van alle code in je TD project.

Installeer de Markdown Preview Mermaid Support extension voor VSCode.

Maak een markdown bestand genaamd ClassDiagramTD.md

Gebruik mermaid om al je classes met inhoud en relaties in kaart te brengen.

Hiervoor kun je de volgende syntax gebruiken:

````
```mermaid

//titel is optioneel
---
Title: Class Diagram Tower Defense
---

//geef aan dat je een class diagram wil maken
classDiagram

//definieer je classes en bijhorende attributen en operaties
class MyClass{
    + Attribute     //public
    - attribute     //private
    + Operation()   //public
    - Operation()   //private
}


//geef alle relaties aan
//Overerving Relatie
ChildClass --|> ParentClass

//Dependancy relatie
DependentClass ..> MyClass

//2 richting relatie
MyClass <..> AnotherClass

```
````

Verwerk alle classes in je TD project in het class diagram.

**Beoordeling:**

- Je hebt Mermaid goed gebruikt
- Alle classes uit je TD project zijn verwerkt
- Alle variabelen en functies zijn weergegeven
- Alle inheritance relaties zijn juist weergegeven
- Alle dependancies zijn juist weergegeven

**Lever in:**

- Zet de opdracht in je PROG README
- Geef de titel en uitleg over de opdracht
- zet in de readme een link naar de code van je TD game
