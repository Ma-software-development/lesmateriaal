# Polymorfisme

## Wat is Polymorfisme?

**Polymorfisme** (letterlijk: "veel vormen") stelt je in staat om objecten van verschillende klassen op dezelfde manier te behandelen, zolang ze van dezelfde basisklasse erven. Dit maakt je code flexibel, herhaalbaar en makkelijk uit te breiden.

### Het Kernidee

- **Eén interface, veel implementaties**: Definieer wat moet gebeuren in een basisklasse, maar laat subklassen bepalen _hoe_ het gebeurt
- **Flexibiliteit**: Je hoeft niet van tevoren alle typen te kennen
- **Uitbreidbaarheid**: Voeg nieuwe klassen toe zonder bestaande code aan te passen

---

## Praktisch Voorbeeld: Enemy Systeem in Unity

Stel je voor: je game heeft verschillende soorten vijanden (zombie, goblin, dragon). Ze gedragen zich anders, maar we willen ze allemaal op dezelfde manier aansturen.

### Stap 1: Basisklasse (Parent)

```csharp
using UnityEngine;
public class Enemy : MonoBehaviour
{
    protected float health = 100f;
    protected float speed = 2f;

    // Virtuele methoden - subklassen kunnen deze overschrijven
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} krijgt {damage} damage! HP: {health}");

        if (health <= 0)
            Die();
    }

    public virtual void Attack(GameObject target)
    {
        Debug.Log($"{gameObject.name} valt aan!");
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} is dood!");
        Destroy(gameObject);
    }
}
```

### Stap 2: Subklassen (Children) - Verschillende Enemy Types

```csharp
using UnityEngine;

public class Zombie : Enemy
{
    private void Start()
    {
        gameObject.name = "Zombie";
    }
    public override void TakeDamage(float damage)
    {
        health -= damage * 0.8f; // Zombies zijn sterker, nemen minder damage
        Debug.Log($"Zombie krijgt {damage * 0.8f} damage! HP: {health}");

        if (health <= 0)
            Die();
    }

    public override void Attack(GameObject target)
    {
        base.Attack(target);
        Debug.Log($"Zombie bijt {target.name} !");
    }
}
```

---

```csharp
using UnityEngine;

public class Goblin : Enemy
{
    private float evasionChance = 0.2f; // 20% kans om aan te vallen te ontwijken

    private void Start()
    {
        gameObject.name = "Goblin";
    }
    public override void TakeDamage(float damage)
    {
        if (Random.value < evasionChance)
        {
            Debug.Log("Goblin ontwijkt de aanval!");
            return;
        }

        base.TakeDamage(damage); // Gewone damage berekening
    }

    public override void Attack(GameObject target)
    {
        base.Attack(target);
        Debug.Log($"Goblin schiet pijlen af op {target.name}!");
    }
}
```

---

```csharp
using UnityEngine;

public class Dragon : Enemy
{
    private void Start()
    {
        gameObject.name = "Dragon";
        health = 1000;
    }
    public override void Attack(GameObject target)
    {
        base.Attack(target);
        Debug.Log($"Dragon spuwt vuur en verkoolt {target.name}!");
    }
}
```

### Stap 3: Polymorfisme in Actie!

```csharp

using System.Collections.Generic;
using UnityEngine;
public class BattleManager : MonoBehaviour
{
    [SerializeField]private List<Enemy> enemies;

    void Start()
    {
        // Maak verschillende enemy types
        enemies = new List <Enemy>
        {
            new GameObject().AddComponent<Zombie>(),
            new GameObject().AddComponent<Goblin>(),
            new GameObject().AddComponent<Dragon>()
        };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("PRESSED - SPACE");
            // POLYMORFISME! We behandelen alle enemies hetzelfde,
            // maar elke enemy voert zijn eigen Attack() uit
            foreach (Enemy enemy in enemies)
            {
                enemy.Attack(gameObject); // Verschillende implementaties!
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("PRESSED - D");
            // Alle enemies nemen damage, maar elk op zijn eigen manier
            foreach (Enemy enemy in enemies)
            {
                if (enemy == null) {
                    enemies.Remove(enemy);
                    break;
                }
                enemy.TakeDamage(25f); // Zombies nemen minder, Goblins ontwijken misschien
            }
        }
    }
}
```

---

## Output in Console

```
PRESSED - SPACE
Zombie valt aan!
Zombie bijt BattleManager!
Goblin valt aan!
Goblin schiet pijlen af op BattleManager!
Dragon valt aan!
Dragon spuwt vuur en verkoolt BattleManager!

PRESSED - D
Zombie krijgt 20 damage! HP: 80
Goblin ontwijkt de aanval!
Dragon krijgt 25 damage! HP: 975
```

---

## Voordelen van Polymorfisme

**DRY Principe**: Geen repetitieve code  
**Makkelijk uitbreiden**: Voeg `Skeleton` of `Troll` toe zonder `BattleManager` aan te passen  
**Onderhoudbaar**: Wijzig enemy-gedrag op één plaats  
**Flexibel**: Behandel alle enemies uniform, ondanks verschillen

---

## Verschil: Overerving vs. Abstractie vs. Polymorfisme

Deze drie concepten werken samen, maar doen totaal verschillende dingen:

### 1. **Overerving** - "Ga erven"

**Wat**: Subklassen krijgen eigenschappen en methoden van een basisklasse.  
**Doel**: Code hergebruiken en een hiërarchie opbouwen.  
**Voorbeeld**:

```csharp
public class Enemy : MonoBehaviour { }        // Basisklasse
public class Zombie : Enemy { }               // Erft van Enemy
```

→ Zombie ERFT alles van Enemy (health, speed, TakeDamage, etc.)

---

### 2. **Abstractie** - "Verbergen van complexiteit"

**Wat**: Bepaalde details verbergen en alleen het essentiële tonen.  
**Doel**: Eenvoudiger interface, onbelangrijke details wegmoffelen.  
**Voorbeeld**:

```csharp
public abstract class Enemy : MonoBehaviour
{
    // Abstract methode - MOET geïmplementeerd worden door subklassen
    public abstract void Attack();

    // Concrete methode - dezelfde voor iedereen
    public void Move(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
```

→ Subklassen MOETEN `Attack()` implementeren, maar `Move()` is al gedaan.

**Voordeel**: Je forceert subklassen om bepaalde methoden uit te voeren.

---

### 3. **Polymorfisme** - "Veel vormen"

**Wat**: Dezelfde methode, maar verschillende implementaties per subklasse.  
**Doel**: Objecten op dezelfde manier behandelen, ondanks verschillen.  
**Voorbeeld**:

```csharp
Enemy[] enemies = new Enemy[] { new Zombie(), new Goblin() };
foreach (Enemy e in enemies)
{
    e.Attack(); // Zombies bijten, Goblins schieten - ZELFDE CODE!
}
```

→ Dezelfde regel code doet IETS ANDERS per subklasse.

---

## Visuele Vergelijking

| Concept          | Vraag                   | Antwoord                               | Code Element                            |
| ---------------- | ----------------------- | -------------------------------------- | --------------------------------------- |
| **Overerving**   | Wat delen ze?           | "Zombie EN Goblin hebben beide health" | `class Zombie : Enemy`                  |
| **Abstractie**   | Wat verbergen we?       | "Details van health berekening"        | `private float health;`                 |
| **Polymorfisme** | Hoe doen ze het anders? | "Zombie bijt, Goblin schiet"           | `public virtual/override void Attack()` |

---

## Het Hele Plaatje: Samen in Code

```csharp
// ABSTRACTIE: Definieer wat een Enemy moet doen
public abstract class Enemy : MonoBehaviour
{
    protected float health; // Verborgen detail

    // ABSTRACTIE: Verplichting voor subklassen
    public abstract void Attack();
}

// OVERERVING: Zombie ERFT van Enemy
public class Zombie : Enemy
{
    // POLYMORFISME: Zombie geeft Attack() zijn eigen implementatie
    public override void Attack()
    {
        Debug.Log("Zombie bijt!");
    }
}

// OVERERVING: Goblin ERFT van Enemy
public class Goblin : Enemy
{
    // POLYMORFISME: Goblin geeft Attack() zijn eigen implementatie
    public override void Attack()
    {
        Debug.Log("Goblin schiet pijlen!");
    }
}

// POLYMORFISME in actie!
public class Game
{
    void Start()
    {
        Enemy[] enemies = new Enemy[] { new Zombie(), new Goblin() };

        // Zelfde code, verschillende resultaten
        foreach (Enemy e in enemies)
        {
            e.Attack(); // "Zombie bijt!" / "Goblin schiet pijlen!"
        }
    }
}
```

---

## Samengevat

- **Overerving**: Hoe staan de classes in relatie tot elkaar? (hiërarchie)
- **Abstractie**: Welke eigenschappen en functies willen we verbergen? (complexiteit)
- **Polymorfisme**: Hoe variëren de implementaties? (flexibiliteit)

**Ze werken samen**: Je ERFT een ABSTRACTE klasse, die POLYMORFISME toestaat.

---

# Praktische Opdracht: Battle Arena

## Stap 1: Scripts Kopieren (Basis)

1. Kopieer al deze scripts in je Unity project:

   - `Enemy.cs` (basisklasse)
   - `Zombie.cs`
   - `Goblin.cs`
   - `Dragon.cs`
   - `BattleManager.cs`

2. Maak een **leeg GameObject** in de scene en noem het `BattleManager`

3. Sleep het `BattleManager.cs` script op dit GameObject

4. **Test het systeem**: Open de Console en druk op:
   - **SPATIE**: Alle enemies vallen aan
   - **D**: Alle enemies krijgen 25 damage

**Verwacht resultaat**: Je ziet in de Console dat Zombie bijt, Goblin schiet, en Dragon spuwt vuur! Je ziet ook dat de enemies levens verliezen en dood gaan als je op D blijft drukken.

![resultaat](/M6/PROG/src/6_polymorphisme_assignment.gif)

---

## Stap 2: Nieuw Enemy Type Toevoegen

Maak je eigen fantasy/mythische enemy-type! Voorbeelden:

- **Phoenix** - Kan zichzelf healen
- **Vampire** - Zuigt health van speler af
- **Minotaur** - Extra sterke aanval elke 2e keer
- **Banshee** - Vlucht weg bij laag health
- **Troll** - Regenereert health
- **Werewolf** - Wordt sterker naarmate health lager is

**Wat je moet doen**:

1. Maak een nieuwe klasse die erft van `Enemy`:

```csharp
public class [JeEigeneNaam] : Enemy
{
    private void Start()
    {
        gameObject.name = "[JeEigeneNaam]";
        // Stel health/speed in als nodig
    }

    public override void Attack(GameObject target)
    {
        base.Attack(target);
        Debug.Log("[JOUW CUSTOM ATTACK HIER]");
    }

    public override void TakeDamage(float damage)
    {
        // [JOUW CUSTOM DAMAGE LOGICA HIER]
        base.TakeDamage(damage);
    }
}
```

2. Voeg je nieuwe enemy toe in `BattleManager.cs` in de `Start()` methode:

```csharp
enemies = new List<Enemy>
{
    new GameObject().AddComponent<Zombie>(),
    new GameObject().AddComponent<Goblin>(),
    new GameObject().AddComponent<Dragon>(),
    new GameObject().AddComponent<[JeEigeneNaam]>()  // ← VOEG HIER TOE
};
```

3. Test of je nieuwe enemy correct aanvalt en damage neemt!

---

## Stap 3: Extra Challenge - BattleManager VS Monsters

Pas de code aan zodat nu ook de battle manager dood kan gaan. Als hij aangevallen wordt door de monsters en zijn levens op zijn.

Zorg er tevens voor dat als alle monsters dood zijn dat de BattleManager wint!

### Test

1. Druk **SPATIE** om enemies aan te vallen
2. Druk **D** zodat enemies jou aanvallen en je schade krijgt
3. Als je alle enemies verslagen hebt → **VICTORY!**
4. Als je health op 0 gaat → **GAME OVER**

---
