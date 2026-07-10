# Les 5.1: If-Statements en Switch Gebruiken

## Wat Ga Je Leren?

In deze les leer je hoe je je code slimmer kunt maken door beslissingen te nemen. Je gaat:

- If-statements uitgebreid gebruiken voor complexe logische beslissingen
- Else en else if combinaties maken voor meerdere opties
- Alle vergelijkingsoperatoren gebruiken (==, !=, <, >, >=, <=)
- Logische operatoren toepassen (&&, ||, !) voor complexe voorwaarden
- Switch statements gebruiken als alternatief voor veel if-else statements
- Game logica bouwen die kennis uit alle vorige lessen combineert
- (Extra) Ternary operator en guard clauses gebruiken voor optimalisatie

---

## If-Statements Revisited

In Les 2.2 heb je al kennisgemaakt met if-statements voor input. Nu gaan we ze veel uitgebreider gebruiken!

### Wat Zijn If-Statements?

Een **if-statement** is zoals een **kruispunt** in je code waar je een beslissing neemt:

```csharp
if (voorwaarde)
{
    // Doe dit als de voorwaarde waar is
}
```

### Basis If-Statement Review

```csharp
public class HealthChecker : MonoBehaviour
{
    public int playerHealth = 100;

    void Update()
    {
        // Simpele if-statement (kennis uit Les 2.2)
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
```

---

## Vergelijkingsoperatoren

### Alle Vergelijkingen Die Je Kunt Maken

```csharp
public class ComparisonExamples : MonoBehaviour
{
    public int score = 100;
    public int health = 75;
    public string playerName = "Alex";
    public bool hasKey = true;

    void Start()
    {
        // Gelijk aan
        if (score == 100)
        {
            Debug.Log("Perfect score!");
        }

        // Niet gelijk aan
        if (playerName != "Guest")
        {
            Debug.Log("Welcome back, " + playerName + "!");
        }

        // Groter dan
        if (score > 50)
        {
            Debug.Log("Good score!");
        }

        // Kleiner dan
        if (health < 20)
        {
            Debug.Log("Warning: Low health!");
        }

        // Groter dan of gelijk aan
        if (health >= 75)
        {
            Debug.Log("Health is good!");
        }

        // Kleiner dan of gelijk aan
        if (score <= 100)
        {
            Debug.Log("Score within normal range!");
        }

        // Boolean check (uit Les 2.2)
        if (hasKey)
        {
            Debug.Log("Player has the key!");
        }

        // Boolean check (omgekeerd)
        if (!hasKey) // ! betekent "niet"
        {
            Debug.Log("Player needs to find the key!");
        }

        // AND operator (&&) - Beide moeten waar zijn
        if (health > 50 && hasKey)
        {
            Debug.Log("Player is healthy AND has the key!");
        }

        // OR operator (||) - Eén van beide moet waar zijn
        if (score > 90 || playerName == "Admin")
        {
            Debug.Log("High score OR admin access!");
        }

        // Combinatie van operatoren
        if ((health > 30 && hasKey) || playerName == "Developer")
        {
            Debug.Log("Ready to proceed OR developer override!");
        }
    }
}
```

### Vergelijkingsoperatoren Overzicht

| Operator | Betekenis             | Voorbeeld                 |
| -------- | --------------------- | ------------------------- |
| `==`     | Gelijk aan            | `score == 100`            |
| `!=`     | Niet gelijk aan       | `name != "Guest"`         |
| `>`      | Groter dan            | `health > 50`             |
| `<`      | Kleiner dan           | `health < 20`             |
| `>=`     | Groter dan of gelijk  | `level >= 5`              |
| `<=`     | Kleiner dan of gelijk | `speed <= 10`             |
| `&&`     | EN (AND)              | `health > 50 && hasKey`   |
| `\|\|`   | OF (OR)               | `score > 90 \|\| isAdmin` |
| `!`      | NIET (NOT)            | `!gameOver`               |

---

## Else en Else If

### Else - De Alternatieve Route

![decision](https://media4.giphy.com/media/v1.Y2lkPTc5MGI3NjExbHYyaDNqbHd0bm9jN2UzaHpudjRremZia2tjeDBubGtveDRvdHZzcSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/DLG7XAxSMlJudB7g4r/giphy.gif)

Maar nu hebben we toch wat meer opties.

```csharp
public class PlayerStatus : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health > 50)
        {
            Debug.Log("Player is healthy!");
        }
        else
        {
            Debug.Log("Player needs healing!");
        }
    }
}
```

### Else If - Meerdere Opties

![lots of options](https://media3.giphy.com/media/v1.Y2lkPTc5MGI3NjExM2Y0MmoxNGtwODRrM3M4cHAzNHM3d2QzNDk4aHNyNmJqM3F5c21xZCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/xT0xewLy70uaFY3Vte/giphy.gif)

```csharp
public class HealthSystem : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health > 80)
        {
            Debug.Log("Excellent health!");
        }
        else if (health > 50)
        {
            Debug.Log("Good health!");
        }
        else if (health > 20)
        {
            Debug.Log("Warning: Low health!");
        }
        else
        {
            Debug.Log("Critical: Very low health!");
        }
    }
}
```

### Complexere Logica (ge-neste if's)

```csharp
public class GameLogic : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool hasKey = false;

    void Update()
    {
        // Combineren van kennis uit Les 2.2 (input) en Les 5.1 (logica)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lives > 0)
            {
                if (hasKey)
                {
                    Debug.Log("Door opened! You win!");
                }
                else
                {
                    Debug.Log("You need a key to open the door!");
                }
            }
            else
            {
                Debug.Log("Game Over - No lives left!");
            }
        }
    }
}
```

---

## Logische Operatoren

### AND (&&) - Beide moeten waar zijn

```csharp
public class ANDExamples : MonoBehaviour
{
    public int health = 100;
    public bool hasWeapon = true;
    public int level = 5;

    void Start()
    {
        // Beide voorwaarden moeten waar zijn
        if (health > 50 && hasWeapon)
        {
            Debug.Log("Ready for battle!");
        }

        // Drie voorwaarden
        if (health > 80 && hasWeapon && level >= 5)
        {
            Debug.Log("Ready for boss fight!");
        }
    }
}
```

### OR (||) - Eén van beide moet waar zijn

```csharp
public class ORExamples : MonoBehaviour
{
    public string difficulty = "Easy";
    public bool godMode = false;
    public int attempts = 0;

    void Start()
    {
        // Een van beide voorwaarden moet waar zijn
        if (difficulty == "Easy" || godMode)
        {
            Debug.Log("Player gets extra help!");
        }

        // Complexere OR logica
        if (attempts > 5 || difficulty == "Tutorial")
        {
            Debug.Log("Show hint to player!");
        }
    }
}
```

### NOT (!) - Omdraaien van boolean

```csharp
public class NOTExamples : MonoBehaviour
{
    public bool gameStarted = false;
    public bool isPaused = false;

    void Update()
    {
        // Alleen als game NIET gestart is
        if (!gameStarted)
        {
            Debug.Log("Press any key to start!");
        }

        // Alleen als game NIET gepauzeerd is
        if (!isPaused)
        {
            // Game logic hier
            Debug.Log("Game is running...");
        }
    }
}
```

---

## Praktische Game Voorbeelden

### 1. Level System (Combinatie Les 2.2 + 5.1)

```csharp
public class LevelSystem : MonoBehaviour
{
    public int experience = 0;
    public int level = 1;
    public string playerClass = "Warrior";

    void Update()
    {
        // Input uit Les 2.2 + logica uit Les 5.1
        if (Input.GetKeyDown(KeyCode.E))
        {
            GainExperience(25);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowPlayerInfo();
        }
    }

    // Functie uit Les 3.2 + logica uit Les 5.1
    void GainExperience(int amount)
    {
        experience += amount;
        Debug.Log("Gained " + amount + " experience!");

        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        int requiredExp = level * 100; // Level 1 = 100 exp, Level 2 = 200 exp, etc.

        if (experience >= requiredExp)
        {
            level++;
            experience = 0; // Reset experience
            Debug.Log("LEVEL UP! Now level " + level);

            // Verschillende berichten per class
            if (playerClass == "Warrior")
            {
                Debug.Log("Your strength increases!");
            }
            else if (playerClass == "Mage")
            {
                Debug.Log("Your magic power increases!");
            }
            else if (playerClass == "Rogue")
            {
                Debug.Log("Your agility increases!");
            }
        }
    }

    void ShowPlayerInfo()
    {
        Debug.Log("=== PLAYER INFO ===");
        Debug.Log("Class: " + playerClass);
        Debug.Log("Level: " + level);
        Debug.Log("Experience: " + experience + "/" + (level * 100));

        // Status gebaseerd op level
        if (level >= 10)
        {
            Debug.Log("Status: Expert!");
        }
        else if (level >= 5)
        {
            Debug.Log("Status: Experienced!");
        }
        else
        {
            Debug.Log("Status: Beginner!");
        }
    }
}
```

### 2. Combat System (Physics Les 3.1 + Collision Les 4.2 + Logic Les 5.1)

```csharp
public class CombatSystem : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int damage = 25;
    public bool isBlocking = false;
    public string enemyType = "Goblin";

    void Update()
    {
        // Input handling (Les 2.2)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isBlocking = true;
            Debug.Log("Blocking!");
        }
        else
        {
            isBlocking = false;
        }
    }

    // Collision detection uit Les 4.2
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamageFrom(other.gameObject);
        }

        if (other.CompareTag("HealthPotion"))
        {
            Heal(30);
            Destroy(other.gameObject);
        }
    }

    // Complex logic met if-statements
    void TakeDamageFrom(GameObject enemy)
    {
        int incomingDamage = damage;

        // Verschillende damage per enemy type
        if (enemyType == "Goblin")
        {
            incomingDamage = 15;
        }
        else if (enemyType == "Orc")
        {
            incomingDamage = 30;
        }
        else if (enemyType == "Dragon")
        {
            incomingDamage = 50;
        }

        // Blocking logic
        if (isBlocking)
        {
            incomingDamage = incomingDamage / 2; // Halve damage
            Debug.Log("Blocked! Reduced damage to " + incomingDamage);
        }

        health -= incomingDamage;
        Debug.Log("Took " + incomingDamage + " damage! Health: " + health);

        // Health checks
        if (health <= 0)
        {
            Die();
        }
        else if (health < 20)
        {
            Debug.Log("WARNING: Low health!");
        }
    }

    void Heal(int amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("Healed " + amount + " health! Current: " + health + "/" + maxHealth);
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Game over logic hier
    }
}
```

---

## Switch Statements - Keuze uit Veel Opties

### Wanneer Gebruik je Switch?

Gebruik **switch** wanneer je **veel opties** hebt gebaseerd op **één variabele**:

```csharp
// Veel if-else statements - onoverzichtelijk
if (weapon == "Sword")
{
    damage = 25;
}
else if (weapon == "Bow")
{
    damage = 20;
}
else if (weapon == "Staff")
{
    damage = 30;
}
else if (weapon == "Dagger")
{
    damage = 15;
}

// Switch statement - overzichtelijker!
switch (weapon)
{
    case "Sword":
        damage = 25;
        break;
    case "Bow":
        damage = 20;
        break;
    case "Staff":
        damage = 30;
        break;
    case "Dagger":
        damage = 15;
        break;
    default:
        damage = 10; // Als geen match
        break;
}
```

### Switch Syntax

```csharp
switch (variabele)
{
    case waarde1:
        // Code voor waarde1
        break;
    case waarde2:
        // Code voor waarde2
        break;
    default:
        // Code als geen match
        break;
}
```

**Belangrijk:** Vergeet niet de `break;` statements!

### Praktische Switch Voorbeelden

#### 1. Weapon System

```csharp
public class WeaponSystem : MonoBehaviour
{
    public string currentWeapon = "Sword";
    public int damage;
    public float attackSpeed;

    void Start()
    {
        SetWeaponStats();
    }

    void Update()
    {
        // Weapon switching met input (Les 2.2)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon("Sword");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon("Bow");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon("Staff");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            EquipWeapon("Dagger");
        }
    }

    void EquipWeapon(string weaponName)
    {
        currentWeapon = weaponName;
        SetWeaponStats();
        Debug.Log("Equipped: " + currentWeapon);
    }

    void SetWeaponStats()
    {
        switch (currentWeapon)
        {
            case "Sword":
                damage = 25;
                attackSpeed = 1.0f;
                Debug.Log("Sword: Balanced weapon");
                break;

            case "Bow":
                damage = 20;
                attackSpeed = 1.5f;
                Debug.Log("Bow: Fast ranged weapon");
                break;

            case "Staff":
                damage = 35;
                attackSpeed = 0.7f;
                Debug.Log("Staff: Powerful but slow");
                break;

            case "Dagger":
                damage = 15;
                attackSpeed = 2.0f;
                Debug.Log("Dagger: Very fast, low damage");
                break;

            default:
                damage = 10;
                attackSpeed = 1.0f;
                Debug.Log("Unarmed: Weak but always available");
                break;
        }

        Debug.Log("Damage: " + damage + ", Speed: " + attackSpeed);
    }
}
```

#### 2. NPC Dialogue System

```csharp
public class NPCDialogue : MonoBehaviour
{
    public string npcName = "Village Elder";
    public int conversationStage = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartConversation();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueConversation();
        }
    }

    void StartConversation()
    {
        conversationStage = 1;
        ShowDialogue();
    }

    void ContinueConversation()
    {
        conversationStage++;
        ShowDialogue();
    }

    void ShowDialogue()
    {
        switch (conversationStage)
        {
            case 1:
                Debug.Log(npcName + ": Welcome, traveler!");
                Debug.Log("Press E to continue...");
                break;

            case 2:
                Debug.Log(npcName + ": Our village needs your help!");
                Debug.Log("Press E to continue...");
                break;

            case 3:
                Debug.Log(npcName + ": A dragon has been terrorizing our lands.");
                Debug.Log("Press E to continue...");
                break;

            case 4:
                Debug.Log(npcName + ": Will you help us defeat it?");
                Debug.Log("Press E to accept quest...");
                break;

            case 5:
                Debug.Log(npcName + ": Thank you, brave hero!");
                Debug.Log("Quest accepted: Defeat the Dragon");
                conversationStage = 0; // Reset conversation
                break;

            default:
                Debug.Log(npcName + ": Good luck on your quest!");
                break;
        }
    }
}
```

---

<span style="background-color: #89bdeaff; padding: 10px; border-radius: 5px; display: block;">

## (Extra) If-Statements voor gevorderden - Ternary operator en Inverteren

### Ternary Operator - Korte If-Statement

De **ternary operator** (`?:`) is een verkorte manier om een simpele if-else te schrijven:

```csharp
// Normale if-else
string status;
if (health > 50)
{
    status = "Healthy";
}
else
{
    status = "Injured";
}

// Ternary operator - korter!
string status = health > 50 ? "Healthy" : "Injured";
```

**Syntax:** `voorwaarde ? waarde_als_waar : waarde_als_onwaar`

**Meer voorbeelden:**

```csharp
// Set damage gebaseerd op weapon
int damage = hasWeapon ? 25 : 5;

// Display message
Debug.Log(playerLevel >= 10 ? "Expert Player!" : "Beginner Player");

// Set color
Color healthColor = health > 20 ? Color.green : Color.red;
```

**Tip:** Gebruik ternary voor simpele beslissingen. Voor complexere logica zijn gewone if-statements duidelijker!

### Early Returns - Inverteren

Soms kun je je code leesbaarder maken door if-statements **om te draaien**. Dit heet "early return" of "guard clauses".

**❌ Moeilijk leesbare code:**

```csharp
void ProcessPlayerAction()
{
    if (playerHealth > 0)
    {
        if (hasAmmo)
        {
            if (!isReloading)
            {
                // Lange code hier voor schieten
                Debug.Log("Player shoots!");
                ammo--;
                // Nog meer code...
            }
            else
            {
                Debug.Log("Player is reloading, can't shoot");
            }
        }
        else
        {
            Debug.Log("No ammo left!");
        }
    }
    else
    {
        Debug.Log("Player is dead, can't shoot");
    }
}
```

**✅ Leesbaarder met early returns:**

```csharp
void ProcessPlayerAction()
{
    // Check alle redenen waarom we NIET kunnen schieten eerst
    if (playerHealth <= 0)
    {
        Debug.Log("Player is dead, can't shoot");
        return; // Stop hier, ga niet verder
    }

    if (!hasAmmo)
    {
        Debug.Log("No ammo left!");
        return; // Stop hier
    }

    if (isReloading)
    {
        Debug.Log("Player is reloading, can't shoot");
        return; // Stop hier
    }

    // Als we hier komen, kunnen we schieten!
    Debug.Log("Player shoots!");
    ammo--;
    // Alle shoot logic hier, zonder diepe nesting
}
```

### Guard Clauses in Game Development

**Voorbeeld: Pickup Item:**

```csharp
void OnTriggerEnter(Collider other)
{
    // Guard clauses - check alle redenen waarom pickup NIET werkt
    if (!other.CompareTag("Player"))
        return; // Niet de speler

    if (isAlreadyPickedUp)
        return; // Al opgepakt

    if (player.InventoryFull())
        return; // Inventory vol

    // Als we hier komen, pickup werkt!
    player.AddToInventory(itemName);
    ShowPickupEffect();
    Destroy(gameObject);
}
```

### Voordelen van Inverteren

**1. Minder nesting (geen diepe { } structuren)**
**2. Duidelijker wat er mis kan gaan**
**3. Makkelijker om nieuwe checks toe te voegen**
**4. De "happy path" (wanneer alles goed gaat) staat onderaan**

### Wanneer Gebruiken?

✅ **Gebruik guard clauses voor:**

- Input validation (is de input geldig?)
- Error checking (kan deze actie uitgevoerd worden?)
- Permissions (mag de speler dit doen?)

❌ **Gebruik normale if-else voor:**

- Echte keuzes (links of rechts gaan?)
- Game states (menu vs playing vs paused)
- Verschillende outcomes die allemaal geldig zijn

</span>

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat zijn de verschillende vergelijkingsoperatoren (==, !=, <, >, etc.)?
- Wat is het verschil tussen if, else if en else?
- Hoe werken logische operatoren (&&, ||, !)?
- Wanneer gebruik je switch statements in plaats van if-else?
- Hoe combineer je if-statements met collision detection?
- Hoe gebruik je if-statements met functions uit Les 3.2?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

## Oefeningen uitvoeren

Doe nu minimaal 1 oefening naar keuze voor les 5.1
De oefeningen vind je [hier](../Oefeningen/oefeningen_5_1.md) terug

![exercise](https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3ZXRrc3QwYWV1Ym5oY2FrZnF5YWxnaW9heTRsNnZzdnpnMmRxeXM1ZiZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/x1BVziEYuKBd1aVZRz/giphy.gif)

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je weet hoe je alle vergelijkingsoperatoren gebruikt (==, !=, <, >, >=, <=)
- [ ] Je kunt complexe if-else-statements maken
- [ ] Je begrijpt logische operatoren (&&, ||, !)
- [ ] Je weet wanneer je switch statements gebruikt
- [ ] Je kunt switch statements correct schrijven met break statements
- [ ] Je hebt complexe game logic gemaakt die if-statements combineert met collision detection
- [ ] Je combineert kennis uit alle vorige lessen in je logic systemen
- [ ] Je kunt beslissingen maken gebaseerd op variabelen en game states

### Volgende Stap

In Les 5.2 gaan we logica combineren met botsingen en input om nog complexere game systemen te maken!

---

## Veelgestelde Vragen

### Q: Wat is het verschil tussen = en ==?

**A:**

- `=` is **toewijzen**: `health = 100` (geef health de waarde 100)
- `==` is **vergelijken**: `health == 100` (is health gelijk aan 100?)

### Q: Wanneer gebruik ik switch in plaats van if-else?

**A:** Gebruik switch wanneer je **veel opties** hebt gebaseerd op **één variabele**. Switch is overzichtelijker bij 4+ opties.

### Q: Waarom moet ik break; gebruiken in switch statements?

**A:** Zonder `break;` "valt" de code door naar de volgende case. Dit heet "fall-through" en is meestal niet wat je wilt.

### Q: Kan ik if-statements in if-statements zetten?

**A:** Ja! Dit heet "nesting". Maar probeer het niet te diep te maken (max 2-3 levels) voor leesbaarheid.

### Q: Wat gebeurt er als geen case matcht in een switch?

**A:** Dan wordt de `default` case uitgevoerd (als die er is). Zonder default gebeurt er niets.

### Q: Hoe combineer ik && en || in één statement?

**A:** Gebruik haakjes voor duidelijkheid: `if ((health > 50 && hasWeapon) || godMode)`

---
