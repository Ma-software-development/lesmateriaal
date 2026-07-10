# Les 1 - Code Conventies in Unity

## Leerdoelen

Na deze les kun je:

- Unity's standaard naamgevingsconventies toepassen
- Consistente code structuur maken volgens best practices
- Scripts organiseren volgens Unity's aanbevelingen

![construction](../../../M5/Prog/src/12_01_coding.gif)

## Waarom gebruik je code conventies?

### Leesbaarheid en Begrip

Als je code schrijft volgens vastgestelde conventies, is het gemakkelijker voor anderen (inclusief jezelf!) om later te begrijpen wat de code doet. Je houden aan deze conventies zorgt ervoor dat je meteen ziet waar functies, variabelen en belangrijke blokken zich bevinden en wat ze doen.

![spaghetti](../../../M5/Prog/src/12_02_spaghetti_code.jpg)

### Samenwerking

Bij projecten waarin meerdere programmeurs werken, helpt een consistente stijl om de samenwerking soepeler te laten verlopen. Iedereen schrijft code op een vergelijkbare manier, waardoor het eenvoudiger is om elkaars werk te begrijpen en hierop door te werken.

### Onderhoudbaarheid

Door conventies te volgen, wordt code makkelijker aan te passen of te debuggen. Als je bijvoorbeeld ooit terug moet naar een stuk code van maanden geleden, zorgt een goede stijl ervoor dat je snel kunt begrijpen wat er gebeurt en wijzigingen kunt aanbrengen zonder fouten.

### Vermijden van Fouten

Bepaalde codeconventies zijn gericht op het voorkomen van veelvoorkomende fouten. Bijvoorbeeld, duidelijke naamgeving voor variabelen en functies kan helpen voorkomen dat je per ongeluk iets verkeerd gebruikt of aanroept.

### Professionaliteit

In de professionele wereld wordt verwacht dat je schrijft volgens conventies. Dit laat zien dat je niet alleen technische vaardigheden hebt, maar ook aandacht voor detail en respect voor teamafspraken.

## Belangrijke onderdelen van code conventies

### 1. Naamgeving

#### Classes en Scripts

- PascalCase voor klassenamen
- Script naam moet overeenkomen met klassenaam
- Beschrijvende namen die functionaliteit weergeven

```csharp
// Goed
public class PlayerController : MonoBehaviour
public class HealthSystem : MonoBehaviour

// Fout
public class playercontroller : MonoBehaviour
public class Player_Controller : MonoBehaviour
public class PContr : MonoBehaviour
public class HS : MonoBehaviour
```

#### Variabelen

- camelCase voor variabelen
- Betekenisvolle namen
- Private variabelen beginnen met underscore

```csharp
public float moveSpeed;
private int _healthPoints;
[SerializeField] private float _jumpForce;
```

#### Best Practices

Aanbevelingen om fouten te vermijden en de code efficiënter en leesbaarder te maken, zoals het vermijden van dubbele code of het gebruik van duidelijke en betekenisvolle functie- en variabele namen.

```csharp
    // Wat is duidelijker?

    public int Calculate(){
        int s = (bs * lmod) + (lives * liMod);
        return s;
    }

    //of..

    public int CalcScore(){
        int finalScore = (baseScore * scoreModifier) + (lives * lifeModifier);
        return finalScore;
    }

```

<details><summary>Oefening 1</summary>

#### Oefening 1 (5 min)

Verbeter de naamgeving in de volgende code:

```csharp
public class gamemanager : MonoBehaviour
{
    public Int HP;
    private float Jump_Power;
    public bool Is_Player_Dead;
}
```

</details>

### 2. Code Structuur

#### Groepeer op Access Modifiers

- `public`: Toegankelijk vanuit alle scripts en de Unity Inspector
  - Gebruik voor functies die andere scripts moeten kunnen aanroepen
  - Wees spaarzaam met public variabelen, gebruik liever [SerializeField] met private
  - Gebruik Getters en Setters om variabelen toch vanuit andere scripts beschikbaar te maken.
- `protected`: Toegankelijk binnen de eigen class en alle child classes
  - Gebruik in parent classes voor methodes die child classes moeten kunnen overschrijven
  - Handig voor het maken van herbruikbare basis-classes
- `private`: Alleen toegankelijk binnen de eigen class
  - Standaard keuze voor variabelen en methodes
  - Bevordert encapsulatie en voorkomt onbedoelde wijzigingen

```csharp
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Public properties (PascalCase) define the class interface
    public int CurrentHealth { get; private set; }

    // Private fields (camelCase with underscore prefix) for internal state,
    // made visible in the Inspector via [SerializeField]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _initialHealth = 100;

    // Protected methods (PascalCase) for use by derived classes
    protected virtual void InitializeHealth()
    {
        CurrentHealth = _initialHealth;
    }

    // Public methods (PascalCase) as the public API
    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Private methods (PascalCase) for internal logic
    private void Die()
    {
        // Handle death logic internally
        Debug.Log("Player Died!");
    }

    private void Start()
    {
        InitializeHealth();
    }
}
```

#### Script Opbouw

1. Fields (private, protected variables)
2. Properties (getter/setter)
3. Events / Delegates (unity event)
4. Monobehaviour Methods (Awake, Start, OnEnable, OnDisable, OnDestroy, etc.)
5. Protected Methods
6. Public Methods
7. Private Methods

```csharp
public class BaseCharacter : MonoBehaviour
{
    // 1. Fields (private, protected variables)
    private Rigidbody2D _rb;
    [SerializeField] protected float _moveSpeed;
    // 4. Monobehaviour Methods
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HandleMovement();
    }
    // 5. Protected methodes (voor child classes)
    protected void HandleMovement()
    {
        // Base movement logic
    }
    // 6. Public Methods
    public void SetMoveSpeed(float newSpeed)
    {
        _moveSpeed = newSpeed;
    }
}
public class PlayerMovement : BaseCharacter
{
    // 1. Fields (private, protected variables)
    [SerializeField] private float _sprintMultiplier;
    // 4. Monobehaviour Methods
    void Update()
    {
        HandleMovement();
    }
    // 7. Private Methods
    private void HandleSprint()
    {
        // Sprint logic
    }
}
```

<details><summary>Oefening 2</summary>

#### Oefening 2 (5 min)

Herstructureer deze classes volgens de juiste opbouw en zet overal de best passende acces modifier voor:

```csharp
public class BaseEnemy : Monobehaviour
{
    float speed = 9;
    virtual void TakeDamage(int damage)
    {
        health -= damage;
    }
    virtual float CalculateRange(float modifier){
        return range
    }
    int health = 100;
}

public class Enemy : BaseEnemy
{
    void Attack()
    {
        // Attack logic
    }
    GameObject player;
    void Update()
    {
        if(Distance(gameObject.transform,position, player.transform.position) >  CalculateRange(speed/5)
        {
            Attack();
        }
    }
    void OnTriggerEnter(Collision other)
    {
        if(other.CompareTag("Trap"))
        {
            TakeDamage(50);
        }
    }
    float attackRange = 2f;
}

```

</details>

### 3. Comments

Wanneer zet je wel en geen commentaar in je code? Wanneer moet de naam van je functie voldoende zijn? Wanneer schrijf je bijvoorbeeld een summary.

Eigenlijk wil je dat je naamgeving het overbodig maakt om comments te moeten plaatsen. Dus de naam van je functie moet duidelijk aangeven wat het doet.

Zaken die wat complexer worden die vragen vaak wel weer om extra comments.

```csharp
//single-line comment

/*
multi-line
comment
*/

/// single-line summary

/**
multi-line
summary
/

```

Tip: _Summaries kun je exporteren naar online documentatie met tools zoals [DoxyGen](https://www.doxygen.nl/download.html)_

<details><summary>opdracht 1</summary>

## Opdracht 1

### Inventory System volgens conventions

Maak een inventory systeem met de volgende requirements:

1. Een `InventorySystem` class die items kan beheren
2. Een `InventoryItem` class als baseclass voor alle items
3. Minimaal drie verschillende soorten items (wapens, potions, etc.) die overerven van de baseclass.
4. Functies voor toevoegen en verwijderen van items aan de inventory
5. Je inventory maakt gebruik van een List.

**tip**: Het mag werken met toetsen op je toetsenbord en items en de inventory mag worden weergegeven puur in de Console.

**Voorbeeld:**

```
press/hold 'G' to pickup/drop guns.
press/hold 'M' to pickup/drop medipacks.
press/hold 'K' to pickup/drop keycards.

items in world:

medipacks : 4
guns : 2
keycards : 1

Items in inventory:
medipacks : 0
guns : 1
keycards : 0

picking up a gun!

items in de wereld:

medipacks : 4
guns : 1
keycards : 1

Items in inventory:
medipacks : 0
guns : 2
keycards : 0

```

**Bonus:**
Je maakt een klein leveltje met items waar je met een character doorheen kunt lopen en items kunt oppakken en droppen. Zorg dan ook voor een simpele ui waarin je ziet welke items je hebt.

**Beoordeling:**

- Pas alle geleerde naamgevingsconventies toe
- Structureer je code volgens de besproken indeling
- Voorzie de code van duidelijke, Engelstalige comments
- Gebruik SerializeField waar nodig voor Unity Inspector waardes

**Lever in:**

- Zet de opdracht in je PROG README
- Geef de titel en uitleg over de opdracht
- Screenshots van je Unity Inspector setup
- Gifje van je werkende inventory system
- Link naar je code
</details>
