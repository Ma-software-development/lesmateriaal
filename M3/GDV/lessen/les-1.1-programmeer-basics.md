# Les 1.1 — Programmeer Basics Herhaling

## Leerdoel

Na deze les kun je de basis programmeerconcepten in C# toepassen in Unity.

---

## Theorie

### Variabelen & Datatypes

```csharp
int score = 0;           // Gehele getallen
float speed = 5.5f;      // Decimale getallen
string playerName = "";  // Tekst
bool isAlive = true;     // Waar/niet waar
```

### Functions

```csharp
// Functie zonder return
void TakeDamage(int amount)
{
    health -= amount;
}

// Functie met return
int GetScore()
{
    return score;
}
```

### Conditionals

```csharp
// If-statement
if (health <= 0)
{
    isAlive = false;
}

// For-loop
for (int i = 0; i < 10; i++)
{
    Debug.Log("Nummer: " + i);
}

// Foreach
foreach (GameObject enemy in enemies)
{
    enemy.SetActive(false);
}
```

### Access Modifiers

```csharp
public int score;    // Zichtbaar in Inspector en andere scripts
private int lives;   // Alleen binnen dit script
```

### Operators

| Operator | Voorbeeld  | Betekenis             |
| -------- | ---------- | --------------------- |
| `=`      | `x = 5`    | Toewijzing            |
| `==`     | `x == 5`   | Vergelijking          |
| `+=`     | `x += 1`   | Optellen en toewijzen |
| `!`      | `!isAlive` | Niet (negatie)        |
| `&&`     | `a && b`   | EN                    |
| `\|\|`   | `a \|\| b` | OF                    |

---

## Oefeningen

### Oefening 1: Score Counter

Maak een script dat:

1. Een `score` variabele bijhoudt (start op 0)
2. Een publieke functie `AddPoints(int points)` heeft
3. Bij aanroep de score verhoogt en in de console print

```csharp
public class ScoreCounter : MonoBehaviour
{
    // TODO: Maak een private int score variabele

    // TODO: Maak een publieke functie AddPoints(int points)
    // die de score verhoogt en print met Debug.Log
}
```

**Test:** Roep `AddPoints(10)` aan in `Start()` en check of "Score: 10" in de console verschijnt.

---

### Oefening 2: Health Check

Maak een script dat:

1. Een `health` variabele heeft (start op 100)
2. Een functie `TakeDamage(int amount)` die health verlaagt
3. Checkt of health <= 0 en dan "Game Over" print

```csharp
public class HealthSystem : MonoBehaviour
{
    // TODO: Maak health variabele

    // TODO: Maak TakeDamage functie met if-check

    void Start()
    {
        // Test: neem 3x 40 damage
        TakeDamage(40);
        TakeDamage(40);
        TakeDamage(40);
    }
}
```

**Verwacht resultaat:** Na de derde `TakeDamage` moet "Game Over" verschijnen.

---

## Toepassing

Denk na over welke variabelen je nodig hebt voor je PAC-MAN game:

- Hoeveel levens heeft de speler?
- Wat is de score?
- Hoeveel dots zijn er verzameld?

Maak alvast een basis `GameManager` script met deze variabelen.
