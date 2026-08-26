# Les 5.1: Keuzes maken met code

Vandaag ga je leren hoe je code keuzes laat maken.

Bijvoorbeeld:

- als je health laag is, toon je een waarschuwing
- als je geen levens meer hebt, is het game over
- als je wapen `Sword` is, krijgt het andere stats dan een `Bow`

Geen paniek: we beginnen klein.

---

## Na deze les

Na deze les kun je:

- een `if` gebruiken
- `else if` en `else` gebruiken
- waardes vergelijken
- `&&`, `||` en `!` herkennen
- een `switch` gebruiken

---

## If

Met een `if` check je of iets waar is.

```csharp
if (health <= 0)
{
    Debug.Log("Game Over");
}
```

Dit betekent:

Als `health` kleiner of gelijk is aan `0`, toon dan `Game Over`.

---

## Else en else if

Met `else` geef je aan wat er gebeurt als de voorwaarde niet klopt.

Met `else if` kun je meerdere opties checken.

```csharp
if (health > 80)
{
    Debug.Log("Excellent health");
}
else if (health > 50)
{
    Debug.Log("Good health");
}
else if (health > 20)
{
    Debug.Log("Low health");
}
else
{
    Debug.Log("Critical health");
}
```

Unity kijkt van boven naar beneden.  
De eerste voorwaarde die klopt, wordt uitgevoerd.

---

## Waardes vergelijken

Deze tekens gebruik je vaak bij `if`:

| Operator | Betekenis |
| --- | --- |
| `==` | is gelijk aan |
| `!=` | is niet gelijk aan |
| `>` | groter dan |
| `<` | kleiner dan |
| `>=` | groter dan of gelijk aan |
| `<=` | kleiner dan of gelijk aan |

Let goed op:

```csharp
health = 100;  // waarde geven
health == 100; // vergelijken
```

---

## AND, OR en NOT

Soms wil je meer dan één ding checken.

```csharp
if (health > 50 && hasKey)
{
    Debug.Log("Je mag door");
}
```

`&&` betekent: allebei moeten waar zijn.

```csharp
if (score > 100 || hasBonus)
{
    Debug.Log("Extra beloning");
}
```

`||` betekent: één van de twee moet waar zijn.

```csharp
if (!gameOver)
{
    Debug.Log("Game loopt nog");
}
```

`!` betekent: niet.

---

## Switch

Een `switch` is handig als je veel keuzes hebt op basis van één variabele.

Bijvoorbeeld bij wapens:

```csharp
switch (currentWeapon)
{
    case "Sword":
        damage = 25;
        break;

    case "Bow":
        damage = 20;
        break;

    case "Staff":
        damage = 35;
        break;

    default:
        damage = 10;
        break;
}
```

Gebruik `switch` als je één ding checkt met meerdere vaste opties.

Gebruik `if` als je voorwaarden wilt combineren.

---

## Veelgemaakte fouten

### `=` en `==` door elkaar halen

```csharp
health = 100;  // waarde geven
health == 100; // vergelijken
```

### `break;` vergeten bij switch

Zet na elke `case` een `break;`.

### Code gebeurt te vaak

Code in `Update()` gebeurt elke frame.

Gebruik `Input.GetKeyDown()` als iets maar één keer moet gebeuren bij een toets.

---

## Oefening

Ga daarna naar de oefeningen van les 5.1:

[Oefeningen Les 5.1](../Week%205%20-%20Oefeningen/oefeningen_5_1.md)

---

## Checklist

- [ ] Ik kan een `if` gebruiken
- [ ] Ik kan `else if` en `else` gebruiken
- [ ] Ik weet het verschil tussen `=` en `==`
- [ ] Ik kan waardes vergelijken
- [ ] Ik herken `&&`, `||` en `!`
- [ ] Ik kan een `switch` gebruiken
