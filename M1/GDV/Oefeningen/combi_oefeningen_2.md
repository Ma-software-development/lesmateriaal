# Combi Oefeningen Les 2: Movement & Input

Kies 1 van de volgende oefeningen en voer die uit. Je mag er ook meer maken als je dat leuk vind en daar ook tijd voor over hebt.

## Inleveren werk

De oefeningen moeten jullie inleveren via een zogenaamde README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst. Een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

## Oefening 2.3A: Simple Racing Car

### Doel

Combineer beweging, input en variabelen door een eenvoudig racing spel te maken.

### Wat ga je doen?

Bouw een auto die je kunt besturen met basis statistieken tracking.

### Stappen

1. **Maak een nieuwe scene** genaamd "RacingGame"
2. **Bouw een auto:**

   - **Body:** Cube (geschaald naar auto vorm)
   - **Wheels:** 4 Cylinders als wielen
   - Organiseer in hierarchy als "Car" parent object

3. **Maak script** `SimpleCar.cs`:

```csharp
public class SimpleCar : MonoBehaviour
{
    [Header("Car Settings")]
    public string driverName = "Speed Racer";
    public float maxSpeed = 10.0f;
    public float acceleration = 5.0f;
    public float turnSpeed = 100.0f;

    [Header("Current Status")]
    public float currentSpeed = 0.0f;
    public bool isAccelerating = false;
    public bool isBraking = false;

    [Header("Game Stats")]
    public float totalDistance = 0.0f;
    public float raceTime = 0.0f;
    public float topSpeed = 0.0f;

    void Start()
    {
        Debug.Log("Racing Game Started!");
        Debug.Log("Driver: " + driverName);
        Debug.Log("Controls: Arrow Keys = Drive, Space = Brake");
        Debug.Log("Press I for info");
    }

    void Update()
    {
        // Update race time
        raceTime += Time.deltaTime;

        // Reset status
        isAccelerating = false;
        isBraking = false;

        // Handle input using GetAxis (REQUIRED)
        float vertical = Input.GetAxis("Vertical");   // Up/Down arrows
        float horizontal = Input.GetAxis("Horizontal"); // Left/Right arrows

        if (vertical > 0)
        {
            isAccelerating = true;
            currentSpeed += acceleration * Time.deltaTime;
        }

        if (vertical < 0)
        {
            isBraking = true;
            currentSpeed -= acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed -= acceleration * 2.0f * Time.deltaTime;
        }

        // Natural slowdown
        if (vertical == 0 && !Input.GetKey(KeyCode.Space))
        {
            currentSpeed -= 2.0f * Time.deltaTime;
        }

        // Clamp speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Update top speed
        if (currentSpeed > topSpeed)
        {
            topSpeed = currentSpeed;
        }

        // Movement
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // Update distance
        totalDistance += currentSpeed * Time.deltaTime;

        // Turning using GetAxis
        if (currentSpeed > 0.1f)
        {
            transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
        }

        // Debug input
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== CAR INFO ===");
            Debug.Log("Driver: " + driverName);
            Debug.Log("Current Speed: " + currentSpeed.ToString("F1"));
            Debug.Log("Top Speed: " + topSpeed.ToString("F1"));
            Debug.Log("Distance: " + totalDistance.ToString("F1"));
            Debug.Log("Race Time: " + raceTime.ToString("F1") + " seconds");

            // Simple if statements instead of ternary
            if (isAccelerating)
            {
                Debug.Log("Status: Accelerating");
            }
            else if (isBraking)
            {
                Debug.Log("Status: Braking");
            }
            else
            {
                Debug.Log("Status: Cruising");
            }
        }

        // STUDENT TOEVOEGINGEN HIER - zie onderaan
    }
}
```

4. **Test je auto:**
   - **Pijltjestoetsen** = Rijden
   - **Space** = Remmen
   - **I** = Info tonen

### Eigen toevoegingen

**Voeg de volgende 3 eenvoudige features toe aan je racing game:**

#### Toevoeging 1: Reset System

- Voeg `Vector3 startPosition` variabele toe
- In Start(): startPosition = transform.position
- Voeg "R" toets toe: als Input.GetKeyDown(KeyCode.R)
- Bij R toets: transform.position = startPosition
- Bij R toets: transform.rotation = Quaternion.identity
- Bij R toets: reset alle stats (currentSpeed = 0, totalDistance = 0, raceTime = 0, topSpeed = 0)
- Voeg Debug.Log("Car reset!") toe bij reset

#### Toevoeging 2: Fuel System

- Voeg een `float fuel` variabele toe (start waarde 100)
- Voeg een `bool outOfFuel` variabele toe
- In Update(): als fuel > 0, dan fuel -= 10 \* Time.deltaTime
- Als fuel <= 0, zet outOfFuel = true
- Als outOfFuel == true, dan maxSpeed = 2 (langzaam rijden)
- Voeg een "F" toets toe: als Input.GetKeyDown(KeyCode.F), dan fuel = 100 en outOfFuel = false
- Toon fuel level in je info display

#### Toevoeging 4: Engine Gear System (Integer Variabelen)

- Voeg `int currentGear` variabele toe (start waarde 1)
- Voeg "Q" toets toe: verhoog currentGear met 1 (max 3)
- Voeg "E" toets toe: verlaag currentGear met 1 (min 1)
- Gear 1: maxSpeed = 5, Gear 2: maxSpeed = 10, Gear 3: maxSpeed = 15
- Toon current gear in je info display

### Bonus Uitdagingen (Optioneel)

- Voeg **horn sound** toe met H toets (Debug.Log message)
- Maak **different car colors** per gear
- Voeg **engine sound** simulator toe (Debug.Log bij acceleratie)

---

## Oefening 2.3B: Guard Patrol System

### Doel

Maak een eenvoudige NPC die patrouilleert en reageert op input.

### Wat ga je doen?

Bouw een bewaker die automatisch beweegt met basis status tracking.

### Stappen

1. **Maak nieuwe scene** "GuardPatrol"
2. **Maak GameObjects:**

   - **Guard:** Capsule (rood materiaal)
   - **Player:** Capsule (blauw materiaal)

3. **Maak script** `SimpleGuard.cs`:

```csharp
public class SimpleGuard : MonoBehaviour
{
    [Header("Guard Info")]
    public string guardName = "Security Bot";
    public float walkSpeed = 2.0f;
    public float alertSpeed = 4.0f;

    [Header("Movement")]
    public bool movingForward = true;
    public float changeDirectionTime = 3.0f;

    [Header("Status")]
    public bool isAlert = false;
    public float alertTime = 0.0f;

    [Header("Stats")]
    public float totalWalkDistance = 0.0f;
    public int directionChanges = 0;
    public float timeOnDuty = 0.0f;

    private float directionTimer = 0.0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;

        Debug.Log("Guard " + guardName + " starting patrol");
        Debug.Log("Press G for guard info, A to alert guard");
    }

    void Update()
    {
        // Update stats
        timeOnDuty += Time.deltaTime;
        directionTimer += Time.deltaTime;
        float walkDistance = Vector3.Distance(transform.position, lastPosition);
        totalWalkDistance += walkDistance;
        lastPosition = transform.position;

        // Handle alert status
        if (isAlert)
        {
            alertTime += Time.deltaTime;
        }

        // Movement
        float currentSpeed;
        if (isAlert)
        {
            currentSpeed = alertSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        Vector3 moveDirection;
        if (movingForward)
        {
            moveDirection = Vector3.forward;
        }
        else
        {
            moveDirection = Vector3.back;
        }

        transform.position += moveDirection * currentSpeed * Time.deltaTime;

        // Auto direction change
        if (directionTimer >= changeDirectionTime)
        {
            movingForward = !movingForward;
            directionChanges++;
            directionTimer = 0.0f;
            Debug.Log(guardName + " changed direction (Total: " + directionChanges + ")");
        }

        // Input handling
        if (Input.GetKeyDown(KeyCode.A))
        {
            isAlert = !isAlert;
            alertTime = 0;
            Debug.Log(guardName + " alert status: " + isAlert);
        }

        // Debug input
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("=== GUARD STATUS ===");
            Debug.Log("Name: " + guardName);

            //Guard status
            if (isAlert)
            {
                Debug.Log("State: ALERT");
            }
            else
            {
                Debug.Log("State: Patrolling");
            }

            Debug.Log("Time on Duty: " + timeOnDuty.ToString("F1") + " seconds");
            Debug.Log("Distance Walked: " + totalWalkDistance.ToString("F1"));
            Debug.Log("Direction Changes: " + directionChanges);
            Debug.Log("Alert Time: " + alertTime.ToString("F1") + " seconds");
            Debug.Log("===================");
        }

        // STUDENT TOEVOEGINGEN HIER - zie onderaan
    }
}
```

4. **Maak Player script** `SimplePlayer.cs`:

```csharp
public class SimplePlayer : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.back;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
```

### Eigen toevoegingen

**Voeg de volgende 3 eenvoudige features toe aan je patrol system:**

#### Toevoeging 1: Guard Energy System (Variabelen + Timer)

- Voeg `float energy` variabele toe (start 100)
- Voeg `bool tired` variabele toe
- In Update(): energy -= 5 \* Time.deltaTime
- Als energy <= 20, dan tired = true en walkSpeed = 1
- Als energy > 20, dan tired = false en walkSpeed = 2
- Voeg "R" toets toe: energy = 100 (guard rust uit)
- Toon energy en tired status in guard info

#### Toevoeging 2: Patrol Mode Switcher (Input + Booleans)

- Voeg `bool fastPatrol` variabele toe
- Voeg "F" toets toe: fastPatrol = !fastPatrol (wissel mode)
- Als fastPatrol == true: walkSpeed = 4 en changeDirectionTime = 1
- Als fastPatrol == false: walkSpeed = 2 en changeDirectionTime = 3
- Toon patrol mode in guard info display

#### Toevoeging 3: Guard Shift Counter (Integer + Input)

- Voeg `int shiftNumber` variabele toe (start 1)
- Voeg `float shiftTime` variabele toe
- In Update(): shiftTime += Time.deltaTime
- Als shiftTime >= 10 seconden: shiftNumber += 1 en shiftTime = 0
- Voeg "S" toets toe: forceer nieuwe shift (verhoog shiftNumber)
- Toon shift number en shift time in guard info

### Bonus Uitdagingen (Optioneel)

- Voeg **guard radio calls** toe (Debug.Log messages)
- Maak **different patrol speeds** per shift
- Voeg **guard name changer** toe met input

---

## Oefening 2.3C: Obstacle Dodge Game

### Doel

Maak een simpel spel waar je bewegende objecten hebt met score tracking.

### Wat ga je doen?

Bouw een speler die kan bewegen met automatisch bewegende obstakels.

### Stappen

1. **Maak scene** "ObstacleDodge"
2. **Maak GameObjects:**

   - **Player:** Cube (groen)
   - **Obstacles:** 3-5 Cubes (rood) op verschillende posities

3. **Maak Player script** `DodgePlayer.cs`:

```csharp
public class DodgePlayer : MonoBehaviour
{
    [Header("Player Settings")]
    public string playerName = "Dodger";
    public float moveSpeed = 5.0f;

    [Header("Game Stats")]
    public int score = 0;
    public float survivalTime = 0.0f;
    public bool gameActive = true;

    void Start()
    {
        Debug.Log("Obstacle Dodge Game Started!");
        Debug.Log("Player: " + playerName);
        Debug.Log("Controls: WASD to move, P to pause, R to restart");
    }

    void Update()
    {
        if (gameActive)
        {
            survivalTime += Time.deltaTime;

            // Score increases over time
            score = (int)(survivalTime * 10);

            // Movement using GetAxis
            float horizontal = Input.GetAxis("Horizontal"); // A/D keys
            float vertical = Input.GetAxis("Vertical");     // W/S keys

            Vector3 movement = new Vector3(horizontal, 0, vertical);
            transform.position += movement * moveSpeed * Time.deltaTime;
        }

        // Game controls
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameActive = !gameActive;

            // Simple if statement instead of ternary
            if (gameActive)
            {
                Debug.Log("Game resumed");
            }
            else
            {
                Debug.Log("Game paused");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector3.zero;
            score = 0;
            survivalTime = 0;
            gameActive = true;
            Debug.Log("Game restarted!");
        }

        // Info
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("=== GAME STATS ===");
            Debug.Log("Player: " + playerName);
            Debug.Log("Score: " + score);
            Debug.Log("Survival Time: " + survivalTime.ToString("F1") + "s");
            Debug.Log("Game Active: " + gameActive);
            Debug.Log("==================");
        }

        // STUDENT TOEVOEGINGEN HIER - zie onderaan
    }
}
```

4. **Maak Obstacle script** `MovingObstacle.cs`:

```csharp
public class MovingObstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public string obstacleName = "Red Block";
    public float moveSpeed = 3.0f;
    public bool movingRight = true;

    [Header("Stats")]
    public float timeActive = 0.0f;
    public int directionChanges = 0;

    private float changeTimer = 0.0f;

    void Start()
    {
        Debug.Log(obstacleName + " started moving");
    }

    void Update()
    {
        timeActive += Time.deltaTime;
        changeTimer += Time.deltaTime;

        // Move - simple if statement instead of ternary
        Vector3 direction;
        if (movingRight)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        transform.position += direction * moveSpeed * Time.deltaTime;

        // Rotate for visual effect
        transform.Rotate(0, 45 * Time.deltaTime, 0);

        // Change direction every 2 seconds
        if (changeTimer >= 2.0f)
        {
            movingRight = !movingRight;
            directionChanges++;
            changeTimer = 0;
        }

        // Simple boundary check
        if (transform.position.x > 10)
        {
            movingRight = false;
        }
        if (transform.position.x < -10)
        {
            movingRight = true;
        }
    }
}
```

### Eigen toevoegingen

**Voeg de volgende 3 eenvoudige features toe aan je dodge game:**

#### Toevoeging 1: Player Lives System (Integer + Boolean)

- Voeg `int lives` variabele toe (start 3)
- Voeg `bool gameOver` variabele toe
- Voeg "L" toets toe: lives -= 1 (simuleer hit)
- Als lives <= 0, dan gameOver = true en gameActive = false
- Als gameOver == true, toon "GAME OVER" in console
- Toon lives en gameOver status in info display

#### Toevoeging 2: Speed Boost System (Input + Float)

- Voeg `float boostTimer` variabele toe
- Voeg `bool speedBoosted` variabele toe
- Als Input.GetKey(KeyCode.LeftShift): speedBoosted = true en boostTimer += Time.deltaTime
- Anders: speedBoosted = false en boostTimer = 0
- Als speedBoosted == true: moveSpeed = 10, anders moveSpeed = 5
- Toon boost status en boost time in info display

#### Toevoeging 3: Multiplier System (Input + Variables)

- Voeg `int scoreMultiplier` variabele toe (start 1)
- Voeg "M" toets toe: verhoog scoreMultiplier met 1 (max 5)
- Voeg "N" toets toe: verlaag scoreMultiplier met 1 (min 1)
- Score berekening: score = (int)(survivalTime _ 10 _ scoreMultiplier)
- Toon multiplier in info display

### Bonus Uitdagingen (Optioneel)

- Maak **obstacle speed** afhankelijk van survival time
- Voeg **combo counter** toe met successive key presses
- Kijk of je de player daadwerkelijk een obstakel kan laten raken met `OnCollisionEnter`

---

## Tips voor de Oefeningen

- **Test elke toevoeging apart** - voeg 1 variabele toe, test, dan logica
- **Gebruik Debug.Log()** om te controleren of je variabelen kloppen
- **Start met de variabele** - declareer eerst, dan gebruik in Update()
- **Vergeet niet** je nieuwe info in de info displays te tonen
- **Save regelmatig** - Unity kan crashen tijdens development
- **Gebruik Inspector** - wijzig public variabelen tijdens runtime om te testen
