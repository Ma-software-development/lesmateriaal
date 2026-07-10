# Les 7 : Early Return Patterns

## Wat is Return?

`return` is een keyword dat een functie **onmiddellijk stopt en een waarde kan teruggeven**.

**Basis voorbeelden:**

```csharp
// return in void functie - stopt de functie
public void PrintMessage()
{
    Debug.Log("Start");
    return;  // Functie stopt hier
    Debug.Log("Dit wordt nooit uitgevoerd");
}

// return met waarde - stopt en geeft waarde terug
public int GetNumber()
{
    return 42;  // Functie stopt, retourneert 42
}
```

**Kernidee**: `return` stopt direct - code NA de `return` wordt NIET uitgevoerd.

---

## Wat is Continue?

`continue` is een keyword dat **alleen in loops** werkt. Het slaat de rest van de huidige iteratie over en gaat direct naar de volgende iteratie.

**Basis voorbeelden:**

```csharp
// continue in foreach - skip huidige item
public void ProcessEnemies(List<Enemy> enemies)
{
    foreach (Enemy enemy in enemies)
    {
        if (enemy == null) continue;      // Skip als null
        if (!enemy.IsAlive) continue;     // Skip als dood

        // Nu verwerken we alleen levende enemies
        enemy.TakeDamage(10);
    }
}

// continue in for loop - skip huidige index
public void PrintNumbers()
{
    for (int i = 0; i < 10; i++)
    {
        if (i == 5) continue;  // Sla 5 over, ga naar 6
        Debug.Log(i);          // Print 0,1,2,3,4,6,7,8,9
    }
}
```

**Kernidee**: `continue` slaat DEZE iteratie over, maar gaat verder met de VOLGENDE iteratie. `break` stopt de loop helemaal.

---

## Wat is Break?

`break` is een keyword dat **loops onmiddellijk beëindigt**.

**Voorbeeld:**

```csharp
// break in for loop - stop vroeg
public void SearchNumbers()
{
    for (int i = 0; i < 100; i++)
    {
        if (i == 42)
        {
            Debug.Log("Gevonden!");
            break;                         // Stop loop, ga naar code NA loop
        }
        Debug.Log(i);
    }
    Debug.Log("Loop klaar");               // Dit WORDT nog uitgevoerd
}
```

## De verschillen:

Dus:
`continue` stopt de huidige iteratie en gaat naar de volgende.

`break` stopt de huidige loop en slaat dus alle verdere iteraties over.

`return` stopt de gehele functie en geeft eventueel een waarde terug.

```Csharp
// continue vs break vs return
public void ProcessEnemies(List<Enemy> enemies)
{
    foreach (Enemy enemy in enemies)
    {
        if (enemy == null) continue;       // Skip deze, volgende iteratie
        if (!enemy.IsAlive) break;         // Stop loop, ga naar code NA loop
        if (enemy.IsBoss) return;          // Stop hele functie

        enemy.TakeDamage(10);
    }

    Debug.Log("Take a break!");             //na een break wordt dit direct uitgevoerd
}
```

---

## Het Probleem: Nested Conditions

Wanneer je veel if-statements hebt, ontstaan **"pyramids of doom"** of **"Nesting Hell"**:

<img height=250, src= https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3NHloOGZxdXN2OWE4bmFrYWdpcXUycTA5aWIwMWphN2NraWl0N28yYyZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/l3g00p6L9P1CEVX5C/giphy.gif />

<img height=250, src= https://img.devrant.com/devrant/rant/r_576804_LgG45.jpg />

```csharp

public void ProcessPlayer(Player player)
{
    if (player != null)
    {
        if (player.IsAlive)
        {
            if (player.Health > 0)
            {
                if (player.Inventory.HasWeapon())
                {
                    if (player.CanAttack())
                    {
                        // Eindelijk! We kunnen hier iets doen!
                        player.Attack();
                    }
                }
            }
        }
    }
}
```

**Problemen**:

- Moeilijk te lezen
- Lastig om logica te volgen
- Makkelijk bugs introduceren
- Code rekt zich uit over veel regels en tabs

---

## De Oplossing: Early Return

**Idee**: Controleer eerst wat FOUT is, en return vroeg. Dan is de rest een **"happy path"** waarin je alles wat je wil doen mag doen.

<img width=200, src=https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExaGx2MGxmaWw5dHg5aGYyZnk3ZnRpc3Q4MG92aGowNWs5cHA2a2ZuOSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/2j2cyE6FgE0XSarRmM/giphy.gif />

```csharp
// GOED - Platte structuur
public void ProcessPlayer(Player player)
{
    // Early returns: check alle foute condities eerst
    if (player == null) return;
    if (!player.IsAlive) return;
    if (player.Health <= 0) return;

    Debug.Log("!!") //Makkelijk debuggen

    if (!player.Inventory.HasWeapon()) return;
    if (!player.CanAttack()) return;

    //Hier mag je nu doen wat je wil doen! De happy path!
    player.Attack();
}
```

**Voordelen**:

- Vlak en leesbaar
- Logica is duidelijk
- Minder snel bugs
- Makkelijk uit te breiden en te debuggen

---

## "Early Return Patterns":

Bij programmen zijn er veel voorkomende patronen te herkennen. Bij het gebruiken van "Early returns" zijn er dus ook een aantal herkenbare patronen te vinden.

### Patroon 1: Guard Clauses

**Idee**: Check foute condities aan het begin, return direct.

**Vergelijking:**

```csharp
// I.p.v een Pyraid of doom - "One big if"
public bool CanPlayerJump(Player player)
{
    if (player != null && !player.IsInAir && !player.IsStunned && player.Stamina >= 10)
    {
        return true;
    }
    return false;
}
```

vs

```csharp
// GOED - Guard clauses
public bool CanPlayerJump(Player player)
{
    if (player == null) return false;
    if (player.IsInAir) return false;
    if (player.IsStunned) return false;
    if (player.Stamina < 10) return false;

    return true;
}
```

**Voordeel**: Elk condition staat op zijn eigen regel = veel duidelijker!

---

### Patroon 2: Early Exit in Loops

**Vergelijking**

```csharp
// SLECHT - Nested loop
public Enemy FindNearestEnemy(List<Enemy> enemies)
{
    Enemy nearest = null;

    //Nesting van 4 lagen!
    for (int i = 0; i < enemies.Count; i++)
    {
        //level 1
        if (enemies[i] != null)
        {
            //level 2
            if (enemies[i].IsAlive)
            {
                //level 3

                //lastig leesbare conditie, door de lengte
                if (nearest == null || Vector3.Distance(transform.position, enemies[i].position) <
                    Vector3.Distance(transform.position, nearest.position))
                {
                    //level 4
                    nearest = enemies[i];
                }
            }
        }
    }
    return nearest;
}
```

```csharp
// GOED - Early continue
public Enemy FindNearestEnemy(List<Enemy> enemies)
{
    Enemy nearest = null;

    //Nog maar 2 lagen nesting
    foreach (Enemy enemy in enemies)
    {
        //level 1

        if (enemy == null) continue;           // Skip invalid
        if (!enemy.IsAlive) continue;          // Skip dead


        float distance = Vector3.Distance(transform.position, enemy.position);
        float nearestDistance;

        //Zelfde logica maar dan stap voor stap leesbaar onder elkaar in plaats van in 1 if statement
        if (nearest == null)
        {
            //level 2
            nearestDistance = float.MaxValue;
        }
        else
        {
            nearestDistance = Vector3.Distance(transform.position, nearest.position);
        }
        if (distance < nearestDistance)
        {
            nearest = enemy;
        }
    }

    return nearest;
}
```

**Voordeel**: Geeft een overzichtelijker beeld van wat er gebeurt en in welke volgorde

---

## Verdere tips

### Tip 1: Omdraaien van negatieve Boolean Conditions

```csharp
// Verwarrend - je kijkt snel over het -!- heen
if (!isInvincible) {
    TakeDamage(damageDealt);
 }

// Beter - early return - gelijk duidelijk
if (isInvincible) return;
TakeDamage(damageDealt);
```

### Tip 2: Continue in Loops

```csharp
// Nested
foreach (Enemy enemy in enemies)
{
    //level 1
    if (enemy.IsAlive)
    {
        //level 2
        enemy.Move();
    }
}

// Early continue, maar 1 nesting level
foreach (Enemy enemy in enemies)
{
    //level 1
    if (!enemy.IsAlive) continue;
    enemy.Move();
}
```

### Tip 3: Complexe if statements vermijden

```csharp
// Te complex
if (a > 0 && b < 100 && c == "valid" && d.IsReady() && !e.IsError())
{
    HandleSomething();
}

// Gebruik early returns
if (a <= 0) return;
if (b >= 100) return;
if (c != "valid") return;
if (!d.IsReady()) return;
if (e.IsError()) return;
HandleSomething();

```

---

### Practische Opdracht: Flatten the Pyramid

<img width=350, src=../src/06_flatten.png />

Maak de onderstaande code plat met behulp van early returns. Zet de opdracht in je readme met de titel een korte omschrijving en de uitwerking van je code letterlijk in een codeblock.

Kijk naar de volgende aspecten van de structuur:

| Aspect                | Probleem                       | Doel                             |
| --------------------- | ------------------------------ | -------------------------------- |
| **Nesting diepte**    | 8 lagen                        | 1-2 lagen                        |
| **Leesbaarheid**      | Heel lastig, lang if-statement | Elk check op eigen regel         |
| **&& en \|\| logica** | Verstopt in 1 grote if         | Stap voor stap met early returns |

```csharp
public bool IsPlayerReadyToAttack(Player player)
{
    if (player != null)
    {
        //Level1
        if (player.IsAlive)
        {
            //Level2
            if (player.AttackCooldown <= 0)
            {
                //Level3
                if (player.Target != null)
                {
                    //Level4
                    if (player.Target.IsAlive)
                    {
                        //Level5
                        if (Vector3.Distance(player.transform.position, player.Target.transform.position) < 5f)
                        {
                            //Level6
                            // Nog meer geneste conditions met && en ||
                            if ((player.Mana >= 20 && player.WeaponEquipped) ||
                                (player.Health > 30 && player.HasBuff("Strength")))
                            {
                                //Level7
                                if (!player.IsStunned && !player.IsSlowed)
                                {
                                    //Level8
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    return false;
}

```

---
