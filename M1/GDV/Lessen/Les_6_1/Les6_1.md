# Les 6.1: Introductie Lijsten in C#

## Wat Ga Je Leren?

In deze les leer je hoe je collecties van data kunt beheren met lijsten. Je gaat:

- Begrijpen wat lijsten zijn en waarom ze handig zijn in games
- Je eerste List<> maken en vullen
- Items toevoegen en verwijderen uit lijsten
- Door lijsten heen lopen met indexen
- Lijsten combineren met kennis uit vorige lessen
- Praktische game systemen bouwen met lijsten

---

## Wat Zijn Lijsten?

Tot nu toe heb je **individuele variabelen** gebruikt:

```csharp
string speler1 = "Alex";
string speler2 = "Emma";
string speler3 = "Jan";
```

![squid](https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExM2NvMWFseGdpZzA4Y3U0aGJ5MTJ5OWhuMW82ejBzdWwxOW9oZWV5MSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/f4K47WTBIDEsvvWOuX/giphy.gif)

Maar wat als je **100 spelers** hebt? Of als het aantal spelers **verandert** tijdens het spel?

**Lijsten** zijn zoals **dynamische dozen** die **meerdere items** van hetzelfde type kunnen bevatten:

![train](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExdDdncGliMjMxMzZ0ZG1pbmJjbThzY3FiNG9lOTNyZXk3ZW9uam9meCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/TlK63EDww4g4tXUd0gE/giphy.gif)

**Vergelijking:**
Een lijst is zoals een **trein met wagons** - je kunt wagons toevoegen, verwijderen, en door alle wagons heen lopen.

### Waarom Lijsten in Games?

**Praktische voorbeelden:**

- **Inventory systeem**: Lijst van items die de speler heeft
- **Enemy spawning**: Lijst van vijanden in het level
- **High scores**: Lijst van beste scores
- **Collectibles**: Lijst van opgevangen items
- **Waypoints**: Lijst van punten waar AI naartoe moet lopen

---

## Je Eerste Lijst Maken

### Basis List Syntax

```csharp
List<datatype> lijstNaam = new List<datatype>();
```

**Uitleg:**

- `List<int>` = Lijst van integers
- `List<string>` = Lijst van strings
- `List<GameObject>` = Lijst van GameObjects
- `new List<datatype>()` = Maak een nieuwe, lege lijst

### Lijsten Declareren

```csharp
using System.Collections.Generic;
using UnityEngine;

public class ListExamples : MonoBehaviour
{
    // Verschillende soorten lijsten
    public List<string> spelerNamen = new List<string>();
    public List<int> scores = new List<int>();
    public List<GameObject> vijanden = new List<GameObject>();
    public List<bool> levelCompleted = new List<bool>();

    void Start()
    {
        Debug.Log("Lijsten aangemaakt!");
        Debug.Log("Spelers: " + spelerNamen.Count); // Count = aantal items
        Debug.Log("Scores: " + scores.Count);
    }
}
```

**Belangrijk:** Lijsten kun je alleen gebruiken als je ze importeert via `using System.Collections.Generic;` bovenin je script!

### Lijsten Vullen bij Aanmaken

```csharp
public class ListExamples : MonoBehaviour
{
    // Lijst declareren
    public List<string> spelerNamen;

    void Start()
    {
        spelerNamen = new List<string>(){"Kang", "Seong", "Cho", "Han", "Jang", "Kim", "Lee"};//Lijst vullen met namen
    }
}
```

### Lijsten Vullen via Unity Inspector

Je kunt **public lijsten** ook vullen via Unity's Inspector!

**Hoe werkt dit:**

1. **Maak het script** en sleep het op een GameObject
2. **Selecteer het GameObject** in de Hierarchy
3. **Kijk naar de Inspector** - je ziet je lijsten!
4. **Klik op het pijltje** naast de lijst om hem uit te klappen
5. **Verander "Size"** om items toe te voegen
6. **Vul de items** in de vakjes

![List inspector](../gfx/6_1_lists_inspector.png)

**Voordelen van Inspector lijsten:**

- Makkelijk aanpassen zonder code
- Visueel overzicht van alle items
- Snel testen met verschillende waarden
- Perfect voor GameObjects en Prefabs

**Tip:** Je kunt ook GameObjecten uit de Scene naar de lijst slepen!

---

## Items Toevoegen en Verwijderen

### Add() - Items Toevoegen

```csharp
public class ItemManager : MonoBehaviour
{
    public List<string> inventory = new List<string>();

    void Start()
    {
        // Items toevoegen
        inventory.Add("Zwaard");
        inventory.Add("Health Potion");
        inventory.Add("Sleutel");

        Debug.Log("Inventory bevat " + inventory.Count + " items");
        ShowInventory();
    }

    void ShowInventory()
    {
        Debug.Log("=== INVENTORY ===");
        for (int i = 0; i < inventory.Count; i++)
        {
            Debug.Log(i + ": " + inventory[i]);
        }
    }
}
```

### Index Nummering - Hoe Lijsten Items Organiseren

Voordat we items gaan verwijderen, is het belangrijk om te begrijpen hoe lijsten hun items **nummeren**:

```csharp
List<string> weapons = new List<string> { "Zwaard", "Boog", "Staf", "Dolk" };

// Index:  0        1      2      3
// Item:   "Zwaard" "Boog" "Staf" "Dolk"
```

**Belangrijke punten:**

- **Lijsten beginnen altijd bij 0** (niet bij 1!)
- **Index 0** = eerste item
- **Index 1** = tweede item
- **Index 2** = derde item
- **Laatste index** = `Count - 1`

```csharp
Debug.Log(weapons[0]);  // Output: "Zwaard" (eerste item)
Debug.Log(weapons[3]);  // Output: "Dolk" (vierde item)
Debug.Log(weapons.Count); // Output: 4 (totaal aantal items)
```

### Remove() - Items Verwijderen

```csharp
public class InventorySystem : MonoBehaviour
{
    public List<string> items = new List<string>();

    void Start()
    {
        // Items toevoegen
        items.Add("Zwaard");
        items.Add("Schild");
        items.Add("Potion");

        Debug.Log("Voor verwijderen: " + items.Count + " items");

        // Item verwijderen (door waarde)
        items.Remove("Schild");
        Debug.Log("Na Remove: " + items.Count + " items");

        // Item verwijderen (door index)
        items.RemoveAt(0); // Verwijder eerste item
        Debug.Log("Na RemoveAt: " + items.Count + " items");
    }
}
```

### Insert() en Clear()

```csharp
void Start()
{
    List<string> namen = new List<string> { "Alex", "Jan" };

    // Insert op specifieke positie
    namen.Insert(1, "Emma"); // Voeg Emma toe tussen Alex en Jan
    // Lijst is nu: Alex, Emma, Jan

    // Alle items verwijderen
    namen.Clear();
    Debug.Log("Na Clear: " + namen.Count + " items"); // Output: 0
}
```

---

## Door Lijsten Heen Lopen

### Met Index (For Loop)

```csharp
public class ListIterator : MonoBehaviour
{
    public List<int> scores = new List<int> { 100, 250, 175, 300, 125 };

    void Start()
    {
        // Met for loop en index
        Debug.Log("=== ALLE SCORES ===");
        for (int i = 0; i < scores.Count; i++)
        {
            Debug.Log("Score " + i + ": " + scores[i]);
        }

        // Zoek hoogste score
        int hoogsteScore = 0;
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] > hoogsteScore)
            {
                hoogsteScore = scores[i];
            }
        }
        Debug.Log("Hoogste score: " + hoogsteScore);
    }
}
```

### Met Foreach

```csharp
void Start()
{
    List<string> wapens = new List<string> { "Zwaard", "Boog", "Staf", "Dolk" };

    // Foreach - simpeler maar geen index
    Debug.Log("=== ALLE WAPENS ===");
    foreach (string wapen in wapens)
    {
        Debug.Log("Wapen: " + wapen);
    }

    // Check of specifiek wapen bestaat
    foreach (string wapen in wapens)
    {
        if (wapen == "Boog")
        {
            Debug.Log("Speler heeft een boog!");
            break; // Stop met zoeken
        }
    }
}
```

---

## Lijsten met GameObjects

### Enemy List Systeem

```csharp
public class EnemyManager : MonoBehaviour
{
    public List<GameObject> vijanden = new List<GameObject>();
    public GameObject enemyPrefab; // Sleep hier een prefab naartoe in Inspector

    void Start()
    {
        SpawnEnemies();
        ShowEnemyInfo();
    }

    void Update()
    {
        // Verwijder vijanden die "dood" zijn
        if (Input.GetKeyDown(KeyCode.K))
        {
            KillRandomEnemy();
        }

        // Toon hoeveel vijanden er nog zijn
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowEnemyInfo();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            // Maak nieuwe vijand op random positie
            Vector3 randomPos = new Vector3(
                Random.Range(-5f, 5f),
                0,
                Random.Range(-5f, 5f)
            );

            GameObject nieuweVijand = Instantiate(enemyPrefab, randomPos, Quaternion.identity);
            nieuweVijand.name = "Enemy_" + i;

            // Voeg toe aan lijst
            vijanden.Add(nieuweVijand);
        }

        Debug.Log("Gespawnd: " + vijanden.Count + " vijanden");
    }

    void KillRandomEnemy()
    {
        if (vijanden.Count > 0)
        {
            // Kies random vijand
            int randomIndex = Random.Range(0, vijanden.Count);
            GameObject teVerwijderen = vijanden[randomIndex];

            Debug.Log("Killing: " + teVerwijderen.name);

            // Verwijder uit lijst EN uit scene
            vijanden.RemoveAt(randomIndex);
            Destroy(teVerwijderen);
        }
        else
        {
            Debug.Log("Geen vijanden meer over!");
        }
    }

    void ShowEnemyInfo()
    {
        Debug.Log("=== ENEMY STATUS ===");
        Debug.Log("Aantal vijanden: " + vijanden.Count);

        for (int i = 0; i < vijanden.Count; i++)
        {
            if (vijanden[i] != null)
            {
                Debug.Log(i + ": " + vijanden[i].name + " op " + vijanden[i].transform.position);
            }
        }
    }
}
```

---

## Arrays vs Lists - Het Verschil Begrijpen

Het is belangrijk om ook te weten wat eem **Array** is en het verschil tussen **Arrays** en **Lists** te begrijpen.

### Wat Zijn Arrays?

**Arrays** zijn ook collecties van items, maar ze werken anders dan Lists:

```csharp
// Array - vaste grootte
string[] spelerNamen = new string[3]; // Precies 3 plekken
spelerNamen[0] = "Alex";
spelerNamen[1] = "Emma";
spelerNamen[2] = "Jan";
// spelerNamen[3] = "Lisa"; // FOUT! Array heeft maar 3 plekken

// Array met startwaarden
int[] scores = { 100, 250, 175 }; // 3 items, kan niet groeien
```

### Arrays vs Lists Vergelijking

| Eigenschap            | Array                             | List                                       |
| --------------------- | --------------------------------- | ------------------------------------------ |
| **Grootte**           | Vast (kan niet veranderen)        | Dynamisch (kan groeien/krimpen)            |
| **Syntax**            | `string[] namen = new string[5];` | `List<string> namen = new List<string>();` |
| **Items toevoegen**   | Niet mogelijk na aanmaken         | `lijst.Add("nieuw item")`                  |
| **Items verwijderen** | Niet mogelijk                     | `lijst.Remove("item")`                     |
| **Snelheid**          | Iets sneller                      | Iets langzamer                             |
| **Geheugen**          | Minder geheugen                   | Meer geheugen                              |
| **Flexibiliteit**     | Beperkt                           | Heel flexibel                              |

### Wanneer Gebruik Je Wat?

**Gebruik Arrays voor:**

- Data waarvan je **precies weet** hoeveel je nodig hebt
- **Performance-kritieke** code
- Simpele, **niet-veranderende** lijsten

```csharp
// Voorbeeld: Dagen van de week (altijd 7)
string[] dagenVanDeWeek = { "Ma", "Di", "Wo", "Do", "Vr", "Za", "Zo" };
```

**Gebruik Lists voor:**

- Data die **kan veranderen** tijdens het spel
- **Game development** (meestal flexibeler)
- **Beginners** (makkelijker te gebruiken)

```csharp
// Voorbeeld: Inventory dat kan groeien
List<string> inventory = new List<string>();
inventory.Add("Zwaard");
inventory.Add("Potion");
// Kan later meer items krijgen!
```

### Voor Beginners: Kies Lists

Als beginner **gebruik je meestal Lists** omdat:

- Je hoeft niet van tevoren te weten hoeveel items je nodig hebt
- Je kunt makkelijk items toevoegen en verwijderen
- Ze zijn flexibeler voor experimenten en prototypes

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat zijn lijsten en waarom zijn ze handig?
- Hoe maak je een List<> aan?
- Welke methods kun je gebruiken om items toe te voegen en te verwijderen?
- Hoe loop je door een lijst heen met for en foreach?
- Wanneer gebruik je lijsten in plaats van gewone variabelen?
- Hoe combineer je lijsten met collision detection en GameObjects?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

## Oefeningen uitvoeren

Doe nu minimaal 1 oefening naar keuze voor les 6.1
De oefeningen vind je [hier](../Oefeningen/oefeningen_6_1.md) terug

![exercise](https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3ZXRrc3QwYWV1Ym5oY2FrZnF5YWxnaW9heTRsNnZzdnpnMmRxeXM1ZiZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/x1BVziEYuKBd1aVZRz/giphy.gif)

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je begrijpt wat lijsten zijn en waarom ze handig zijn
- [ ] Je kunt List<> variabelen maken en vullen
- [ ] Je weet hoe je items toevoegt met Add() en verwijdert met Remove()
- [ ] Je kunt door lijsten heen lopen met for loops en foreach
- [ ] Je hebt lijsten gecombineerd met GameObjects en collision detection
- [ ] Je begrijpt het verschil tussen indexen en foreach iteratie
- [ ] Je begrijpt het verschil tussen een Array en een List

### Volgende Stap

In Les 6.2 gaan we for- en foreach-loops nog uitgebreider gebruiken en leren hoe we complexere herhalingen kunnen maken!

---

## Veelgestelde Vragen

### Q: Wat is het verschil tussen een Array en een List?

**A:**

- **Array**: Vaste grootte, sneller, `string[] namen = new string[5];`
- **List**: Dynamische grootte, flexibeler, `List<string> namen = new List<string>();`

Voor beginners is List meestal handiger omdat je items kunt toevoegen en verwijderen.

### Q: Waarom krijg ik een IndexOutOfRangeException?

**A:** Je probeert een index te gebruiken die niet bestaat. Een lijst met 3 items heeft indexen 0, 1, 2. Index 3 bestaat niet!

```csharp
//Fout als lijst maar 3 items heeft
Debug.Log(lijst[3]);

//Goed - check eerst de grootte
if (lijst.Count > 3) Debug.Log(lijst[3]);
```

### Q: Hoe verwijder ik items tijdens een foreach loop?

**A:** Dat kan niet! Gebruik een for loop die achterstevoren loopt:

```csharp
// Fout - Dit geeft een fout
foreach (string item in lijst)
{
    if (item == "verwijder") lijst.Remove(item);
}

// Goed - Dit werkt wel
for (int i = lijst.Count - 1; i >= 0; i--)
{
    if (lijst[i] == "verwijder") lijst.RemoveAt(i);
}
```

### Q: Wanneer gebruik ik for vs foreach?

**A:**

- **For**: Als je de index nodig hebt of items wilt wijzigen/verwijderen
- **Foreach**: Als je alleen alle items wilt bekijken (eenvoudiger en veiliger)

### Q: Hoe sorteer ik een lijst van GameObjects?

**A:** Gebruik een custom Sort met een vergelijkingsfunctie:

```csharp
// Sorteer op afstand tot speler
vijanden.Sort((a, b) =>
    Vector3.Distance(a.transform.position, player.position)
    .CompareTo(Vector3.Distance(b.transform.position, player.position))
);
```
