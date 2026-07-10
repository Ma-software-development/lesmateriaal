# PROG CPP — Module 8

Deze map bevat lesmateriaal voor **Programmeren in C++** binnen **M8 Game Development**.

De lessen werken toe naar een vervolgproject waarin studenten een **RPG Inventory & Shop**-systeem bouwen. Daarbij oefenen studenten met classes, objecten, vectors, functies, menu-structuren en basis CRUD-functionaliteit.

---

## Inhoud van deze map

| Bestand                                               | Beschrijving                                          |
| ----------------------------------------------------- | ----------------------------------------------------- |
| `CPP_Vervolgproject_RPG_Inventory_Shop_10_weken.docx` | Projectdocument voor het RPG Inventory & Shop-project |
| `CSharp_Vervolgproject_Presentatie.pptx`              | Algemene vervolgproject-presentatie                   |
| `Les_2_Item_Class_Maken_Cpp.pptx`                     | Les 2: een `Item` class maken in C++                  |
| `Les_3_Meerdere_Items_Vectoren_Cpp.pptx`              | Les 3: meerdere items opslaan met `vector`            |
| `Les_4_Menu_en_Functies_Structureren_Cpp.pptx`        | Les 4: menu maken en code structureren met functies   |
| `Les_5_Zoeken_Aanpassen_Verwijderen_Cpp.pptx`         | Les 5: zoeken, aanpassen en verwijderen van items     |

---

## Project: RPG Inventory & Shop

In dit project bouwen studenten stap voor stap een C++ consoleprogramma waarin items kunnen worden beheerd.

Het programma groeit uit tot een klein inventory- en shopsysteem, vergelijkbaar met systemen uit RPG’s.

Denk bijvoorbeeld aan items zoals:

* zwaarden
* potions
* armor
* mana crystals
* keys
* crafting materials

---

## Leerdoelen

Na deze lessen kun je:

| Onderwerp     | Je kunt...                                  |
| ------------- | ------------------------------------------- |
| Classes       | een eigen class maken in C++                |
| Objecten      | objecten aanmaken en gebruiken              |
| Constructors  | objecten initialiseren met beginwaarden     |
| Header/source | code verdelen over `.h` en `.cpp` bestanden |
| Vectors       | meerdere objecten opslaan in een `vector`   |
| Functies      | code opdelen in herbruikbare functies       |
| Menu’s        | een consolemenu maken met meerdere keuzes   |
| Zoeken        | items vinden op basis van naam of index     |
| Aanpassen     | bestaande gegevens wijzigen                 |
| Verwijderen   | items uit een lijst verwijderen             |
| Structuur     | grotere programma’s overzichtelijk houden   |

---

## Benodigdheden

Voor deze lessen heb je nodig:

* Visual Studio of Visual Studio Code
* een C++ compiler
* basiskennis van programmeren
* kennis van variabelen, functies, `if` statements en loops
* toegang tot deze repository

Controleer of je compiler werkt door een simpel C++ programma te maken:

```cpp
#include <iostream>

int main()
{
    std::cout << "Hello C++!" << std::endl;
    return 0;
}
```

---

## Aanbevolen projectstructuur

Gebruik een duidelijke structuur met aparte bestanden voor classes.

```text
RPGInventory/
├── main.cpp
├── Item.h
├── Item.cpp
├── Inventory.h
├── Inventory.cpp
└── RPGInventory.vcxproj
```

---

## Voorbeeld: Item class

`Item.h`

```cpp
#pragma once
#include <string>

class Item
{
private:
    std::string name;
    int value;
    int amount;

public:
    Item(std::string name, int value, int amount);

    std::string GetName();
    int GetValue();
    int GetAmount();

    void SetName(std::string newName);
    void SetValue(int newValue);
    void SetAmount(int newAmount);

    void PrintInfo();
};
```

`Item.cpp`

```cpp
#include "Item.h"
#include <iostream>

Item::Item(std::string name, int value, int amount)
{
    this->name = name;
    this->value = value;
    this->amount = amount;
}

std::string Item::GetName()
{
    return name;
}

int Item::GetValue()
{
    return value;
}

int Item::GetAmount()
{
    return amount;
}

void Item::SetName(std::string newName)
{
    name = newName;
}

void Item::SetValue(int newValue)
{
    value = newValue;
}

void Item::SetAmount(int newAmount)
{
    amount = newAmount;
}

void Item::PrintInfo()
{
    std::cout << name << " | Value: " << value << " | Amount: " << amount << std::endl;
}
```

`main.cpp`

```cpp
#include <iostream>
#include "Item.h"

int main()
{
    Item sword("Iron Sword", 100, 1);
    sword.PrintInfo();

    return 0;
}
```

---

## Opbouw van de lessen

| Les     | Onderwerp                          | Resultaat                                            |
| ------- | ---------------------------------- | ---------------------------------------------------- |
| Les 1   | Introductie vervolgproject         | Studenten begrijpen het einddoel                     |
| Les 2   | `Item` class maken                 | Studenten hebben een werkende class                  |
| Les 3   | Meerdere items met `vector`        | Studenten kunnen items opslaan in een lijst          |
| Les 4   | Menu en functies                   | Studenten kunnen het programma bedienen via een menu |
| Les 5   | Zoeken, aanpassen en verwijderen   | Studenten bouwen CRUD-functionaliteit                |
| Vervolg | Uitbreiden richting shop/inventory | Studenten werken richting een compleet project       |

---

## Mogelijke menu-opties

Het programma kan bijvoorbeeld deze opties bevatten:

```text
1. Item toevoegen
2. Items bekijken
3. Item zoeken
4. Item aanpassen
5. Item verwijderen
6. Totale waarde berekenen
7. Afsluiten
```

---

## Code-afspraken

Houd je aan de volgende afspraken:

| Afspraak                   | Uitleg                                |
| -------------------------- | ------------------------------------- |
| Gebruik duidelijke namen   | `itemName` is beter dan `x`           |
| Eén class per bestandspaar | Bijvoorbeeld `Item.h` en `Item.cpp`   |
| Vermijd dubbele code       | Gebruik functies                      |
| Test regelmatig            | Run je programma na elke kleine stap  |
| Gebruik `std::`            | Gebruik geen `using namespace std;`   |
| Houd functies kort         | Eén functie heeft één duidelijke taak |
| Werk stap voor stap        | Maak eerst de basis werkend           |

---

## Veelvoorkomende fouten

| Fout                          | Mogelijke oplossing                                      |
| ----------------------------- | -------------------------------------------------------- |
| `#include` vergeten           | Controleer of je headerbestand is toegevoegd             |
| Constructor komt niet overeen | Controleer parameters in `.h`, `.cpp` en `main.cpp`      |
| Vergeten `;` na class         | Een class eindigt met `};`                               |
| Vector niet herkend           | Voeg `#include <vector>` toe                             |
| String niet herkend           | Voeg `#include <string>` toe                             |
| Functie bestaat niet          | Controleer spelling en hoofdletters                      |
| Linker error                  | Controleer of `.cpp` bestanden echt in het project staan |

---

## Beoordeling

Er kan worden gekeken naar:

| Criterium       | Beschrijving                                                 |
| --------------- | ------------------------------------------------------------ |
| Functionaliteit | Het programma doet wat gevraagd wordt                        |
| Classes         | Classes zijn logisch opgebouwd                               |
| Header/source   | `.h` en `.cpp` bestanden worden correct gebruikt             |
| Menu            | Het menu werkt duidelijk en foutarm                          |
| CRUD            | Toevoegen, bekijken, zoeken, aanpassen en verwijderen werken |
| Codekwaliteit   | Code is leesbaar en netjes gestructureerd                    |
| Zelfstandigheid | De student kan gemaakte keuzes uitleggen                     |

---

## Tips voor studenten

* Begin met één werkend item.
* Maak daarna pas een lijst met meerdere items.
* Test elke functie apart.
* Lees foutmeldingen rustig.
* Controleer goed of je `.h` en `.cpp` bestanden allebei zijn toegevoegd.
* Maak eerst de basisopdracht af voordat je extra features toevoegt.

---

## Mogelijke uitbreidingen

Wanneer de basis werkt, kun je het project uitbreiden met:

* gold / money systeem
* shop waarin je items kunt kopen
* items verkopen
* item rarity
* item types zoals `Weapon`, `Armor` en `Potion`
* save/load naar bestand
* simpele battle waarin items gebruikt worden
* inventory limiet
* sorteren op waarde of naam

---

## Handige links

* [C++ reference](https://en.cppreference.com/)
* [Microsoft C++ documentation](https://learn.microsoft.com/en-us/cpp/)
* [Visual Studio C++ documentation](https://learn.microsoft.com/en-us/cpp/build/vscpp-step-0-installation)

---

## Licentie / gebruik

Dit materiaal is bedoeld voor onderwijsdoeleinden binnen de opleiding Game Development.

Controleer bij hergebruik of aanpassen altijd de afspraken van de opleiding of docent.

