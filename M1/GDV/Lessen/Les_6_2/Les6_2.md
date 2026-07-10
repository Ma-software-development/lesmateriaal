# Les 6.2: For- en Foreach-Loops Gebruiken

## Wat Ga Je Leren?

In deze les ga je dieper in op loops (herhalingen) en leer je hoe je efficiënt door data kunt itereren. Je gaat:

- For-loops uitgebreid gebruiken voor herhalingen
- Foreach-loops beheersen voor collections
- Nested loops (loops in loops) maken
- While loops begrijpen en gebruiken
- Loop control statements (break, continue) toepassen
- Complexe game systemen bouwen met loops

---

## Loop Herinnering uit Les 6.1

In Les 6.1 heb je al kennisgemaakt met basis loops:

```csharp
// For loop - met index
for (int i = 0; i < lijst.Count; i++)
{
    Debug.Log(lijst[i]);
}

// Foreach loop - zonder index
foreach (string item in lijst)
{
    Debug.Log(item);
}
```

Nu gaan we veel **geavanceerdere technieken** leren!

---

## For-Loops Uitgebreid

### Basis For-Loop Anatomie

```csharp
for (initialisatie; conditie; increment)
{
    // Code die herhaald wordt
}
```

**Uitleg:**

- **Initialisatie**: Wat gebeurt voor de eerste iteratie (meestal `int i = 0`)
- **Conditie**: Wanneer stopt de loop? (meestal `i < aantal`)
- **Increment**: Wat gebeurt na elke iteratie (meestal `i++`)

### Verschillende For-Loop Patronen

```csharp
public class ForLoopPatterns : MonoBehaviour
{
    void Start()
    {
        BasicPatterns();
        CountingPatterns();
        ListPatterns();
    }

    void BasicPatterns()
    {
        Debug.Log("=== BASIC PATTERNS ===");

        // Normale counting (0 tot 5)
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Count: " + i);
        }

        // Achterstevoren (5 tot 0)
        for (int i = 5; i >= 0; i--)
        {
            Debug.Log("Countdown: " + i);
        }

        // Stappen van 2
        for (int i = 0; i <= 10; i += 2)
        {
            Debug.Log("Even numbers: " + i); // 0, 2, 4, 6, 8, 10
        }

        // Oneven getallen
        for (int i = 1; i <= 10; i += 2)
        {
            Debug.Log("Odd numbers: " + i); // 1, 3, 5, 7, 9
        }
    }

    void CountingPatterns()
    {
        Debug.Log("=== COUNTING PATTERNS ===");

        // Exponentieel (machten van 2)
        for (int i = 1; i <= 64; i *= 2)
        {
            Debug.Log("Power of 2: " + i); // 1, 2, 4, 8, 16, 32, 64
        }

        // Fibonacci sequence (eerste 10)
        int a = 0, b = 1;
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Fibonacci: " + a);
            int temp = a + b;
            a = b;
            b = temp;
        }
    }

    void ListPatterns()
    {
        List<string> wapens = new List<string> { "Zwaard", "Boog", "Staf", "Dolk", "Knuppel" };

        Debug.Log("=== LIST PATTERNS ===");

        // Elke 2e item
        for (int i = 0; i < wapens.Count; i += 2)
        {
            Debug.Log("Every 2nd weapon: " + wapens[i]);
        }

        // Laatste 3 items
        for (int i = wapens.Count - 3; i < wapens.Count; i++)
        {
            Debug.Log("Last 3: " + wapens[i]);
        }

        // Vergelijk elk item met het volgende
        for (int i = 0; i < wapens.Count - 1; i++)
        {
            Debug.Log("Compare: " + wapens[i] + " vs " + wapens[i + 1]);
        }
    }
}
```

---

## Foreach-Loops Uitgebreid

### Basis Foreach Herinnering

```csharp
List<GameObject> vijanden = new List<GameObject>();

foreach (GameObject vijand in vijanden)
{
    // Doe iets met elke vijand
    Debug.Log(vijand.name);
}
```

### Foreach met Verschillende Data Types

```csharp
public class ForeachExamples : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public List<int> scores = new List<int> { 100, 250, 175, 300, 125 };
    public string[] spelerNamen = { "Alex", "Emma", "Jan", "Lisa" };

    void Start()
    {
        ProcessGameObjects();
        ProcessNumbers();
        ProcessStrings();
    }

    void ProcessGameObjects()
    {
        Debug.Log("=== GAMEOBJECT PROCESSING ===");

        // Alle waypoints activeren
        foreach (Transform waypoint in waypoints)
        {
            if (waypoint != null)
            {
                waypoint.gameObject.SetActive(true);
                Debug.Log("Activated: " + waypoint.name);
            }
        }

        // Alle children van dit object verwerken
        foreach (Transform child in transform)
        {
            Debug.Log("Child: " + child.name + " at " + child.position);
        }
    }

    void ProcessNumbers()
    {
        Debug.Log("=== NUMBER PROCESSING ===");

        int totaal = 0;
        foreach (int score in scores)
        {
            totaal += score;
            Debug.Log("Processing score: " + score + " (running total: " + totaal + ")");
        }

        Debug.Log("Final total: " + totaal);
        Debug.Log("Average: " + (totaal / scores.Count));
    }

    void ProcessStrings()
    {
        Debug.Log("=== STRING PROCESSING ===");

        foreach (string naam in spelerNamen)
        {
            Debug.Log("Welcome " + naam + " (length: " + naam.Length + ")");
            // Check voor specifieke namen
            if (naam.StartsWith("A"))
            {
                Debug.Log(naam + " starts with A!");
            }
        }
    }
}
```

---

## While Loops

### Wat Zijn While Loops?

**While loops** blijven herhalen **zolang** een conditie waar is:

```csharp
while (conditie)
{
    // Code die herhaalt
    // Vergeet niet de conditie te veranderen!
}
```

### While Loop Voorbeelden

```csharp
public class WhileLoopExamples : MonoBehaviour
{
    public int playerHealth = 100;
    public List<GameObject> enemiesInRange = new List<GameObject>();

    void Start()
    {
        BasicWhileExample();
        GameWhileExamples();
    }

    void BasicWhileExample()
    {
        Debug.Log("=== BASIC WHILE ===");

        int countdown = 5;
        while (countdown > 0)
        {
            Debug.Log("Countdown: " + countdown);
            countdown--; // BELANGRIJK: verander de conditie!
        }
        Debug.Log("Blast off!");
    }

    void GameWhileExamples()
    {
        Debug.Log("=== GAME WHILE EXAMPLES ===");

        // Zoek naar dichtsbijzijnde vijand
        GameObject nearestEnemy = null;
        float shortestDistance = float.MaxValue;
        int index = 0;

        while (index < enemiesInRange.Count)
        {
            GameObject enemy = enemiesInRange[index];
            if (enemy != null)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestEnemy = enemy;
                }
            }
            index++;
        }

        if (nearestEnemy != null)
        {
            Debug.Log("Nearest enemy: " + nearestEnemy.name + " at distance: " + shortestDistance);
        }
    }

    // While vs For vergelijking
    void WhileVsForComparison()
    {
        List<string> items = new List<string> { "a", "b", "c", "d" };

        Debug.Log("=== FOR VERSION ===");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(i + ": " + items[i]);
        }

        Debug.Log("=== WHILE VERSION ===");
        int index = 0;
        while (index < items.Count)
        {
            Debug.Log(index + ": " + items[index]);
            index++;
        }
        // Beide doen hetzelfde!
    }
}
```

### Do-While Loops

```csharp
void DoWhileExample()
{
    int attempts = 0;
    bool success = false;

    do
    {
        attempts++;
        Debug.Log("Attempt " + attempts);

        // Simuleer random success
        success = Random.Range(0f, 1f) > 0.7f; // 30% kans op success

    } while (!success && attempts < 5);

    if (success)
    {
        Debug.Log("Success after " + attempts + " attempts!");
    }
    else
    {
        Debug.Log("Failed after " + attempts + " attempts.");
    }
}
```

---

## Nested Loops (Loops in Loops)

### Wat Zijn Nested Loops?

**Nested loops** zijn loops **binnen andere loops**. Super krachtig voor complexe bewerkingen!

### Grid/Board Systemen

```csharp
public class GridSystem : MonoBehaviour
{
    public int gridWidth = 5;
    public int gridHeight = 5;
    public GameObject tilePrefab;

    void Start()
    {
        CreateGrid();
        ProcessGrid();
    }

    void CreateGrid()
    {
        Debug.Log("=== CREATING GRID ===");

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(x * 2f, 0, y * 2f);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
                tile.name = "Tile_" + x + "_" + y;

                // Checkerboard pattern
                if ((x + y) % 2 == 0)
                {
                    tile.GetComponent<Renderer>().material.color = Color.white;
                }
                else
                {
                    tile.GetComponent<Renderer>().material.color = Color.black;
                }
            }
        }
    }

    void ProcessGrid()
    {
        Debug.Log("=== PROCESSING GRID ===");

        // Verwerk elke positie in het grid
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Debug.Log("Grid position: (" + x + ", " + y + ")");

                // Check buren (neighbors)
                CheckNeighbors(x, y);
            }
        }
    }

    void CheckNeighbors(int centerX, int centerY)
    {
        // Kijk naar alle 8 buren rond een positie
        for (int offsetX = -1; offsetX <= 1; offsetX++)
        {
            for (int offsetY = -1; offsetY <= 1; offsetY++)
            {
                // Skip center position
                if (offsetX == 0 && offsetY == 0) continue;

                int neighborX = centerX + offsetX;
                int neighborY = centerY + offsetY;

                // Check bounds
                if (neighborX >= 0 && neighborX < gridWidth &&
                    neighborY >= 0 && neighborY < gridHeight)
                {
                    Debug.Log("  Neighbor at (" + neighborX + ", " + neighborY + ")");
                }
            }
        }
    }
}
```

### Inventory Grid Systeem

```csharp
public class InventoryGrid : MonoBehaviour
{
    public class InventorySlot
    {
        public string itemName;
        public int quantity;
        public bool isEmpty;

        public InventorySlot()
        {
            itemName = "";
            quantity = 0;
            isEmpty = true;
        }
    }

    public int rows = 6;
    public int columns = 8;
    private InventorySlot[,] grid; // 2D array

    void Start()
    {
        InitializeGrid();
        FillWithTestItems();
        DisplayGrid();
        SearchGrid();
    }

    void InitializeGrid()
    {
        grid = new InventorySlot[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                grid[row, col] = new InventorySlot();
            }
        }

        Debug.Log("Initialized " + rows + "x" + columns + " inventory grid");
    }

    void FillWithTestItems()
    {
        // Voeg random items toe
        string[] items = { "Potion", "Sword", "Shield", "Bow", "Arrow", "Gem" };

        for (int i = 0; i < 10; i++)
        {
            int randomRow = Random.Range(0, rows);
            int randomCol = Random.Range(0, columns);

            if (grid[randomRow, randomCol].isEmpty)
            {
                grid[randomRow, randomCol].itemName = items[Random.Range(0, items.Length)];
                grid[randomRow, randomCol].quantity = Random.Range(1, 10);
                grid[randomRow, randomCol].isEmpty = false;
            }
        }
    }

    void DisplayGrid()
    {
        Debug.Log("=== INVENTORY GRID ===");

        for (int row = 0; row < rows; row++)
        {
            string rowString = "Row " + row + ": ";
            for (int col = 0; col < columns; col++)
            {
                if (grid[row, col].isEmpty)
                {
                    rowString += "[Empty] ";
                }
                else
                {
                    rowString += "[" + grid[row, col].itemName + ":" + grid[row, col].quantity + "] ";
                }
            }
            Debug.Log(rowString);
        }
    }

    void SearchGrid()
    {
        Debug.Log("=== SEARCHING GRID ===");

        // Tel alle items
        Dictionary<string, int> itemCounts = new Dictionary<string, int>();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (!grid[row, col].isEmpty)
                {
                    string itemName = grid[row, col].itemName;
                    if (itemCounts.ContainsKey(itemName))
                    {
                        itemCounts[itemName] += grid[row, col].quantity;
                    }
                    else
                    {
                        itemCounts[itemName] = grid[row, col].quantity;
                    }
                }
            }
        }

        // Toon resultaten
        foreach (var kvp in itemCounts)
        {
            Debug.Log("Total " + kvp.Key + ": " + kvp.Value);
        }
    }
}
```

---

## Loop Control Statements

### Break - Stop de Loop

```csharp
public class BreakExamples : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        FindFirstAliveEnemy();
        FindTreasure();
    }

    void FindFirstAliveEnemy()
    {
        Debug.Log("=== BREAK EXAMPLE ===");

        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) continue; // Skip null objects

            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null && health.currentHealth > 0)
            {
                Debug.Log("Found alive enemy: " + enemy.name);
                break; // Stop zoeken na eerste levende vijand
            }
        }
    }

    void FindTreasure()
    {
        Debug.Log("=== TREASURE HUNT ===");

        // Zoek in 10x10 grid
        bool foundTreasure = false;

        for (int x = 0; x < 10 && !foundTreasure; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // Simuleer treasure check
                if (Random.Range(0f, 1f) < 0.05f) // 5% kans
                {
                    Debug.Log("Treasure found at (" + x + ", " + y + ")!");
                    foundTreasure = true;
                    break; // Break uit inner loop
                }
            }
        }

        if (!foundTreasure)
        {
            Debug.Log("No treasure found!");
        }
    }
}
```

### Continue - Skip naar Volgende Iteratie

```csharp
public class ContinueExamples : MonoBehaviour
{
    public List<GameObject> allObjects = new List<GameObject>();
    public List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

    void Start()
    {
        ProcessOnlyActiveObjects();
        ProcessOnlyEvenNumbers();
    }

    void ProcessOnlyActiveObjects()
    {
        Debug.Log("=== CONTINUE EXAMPLE ===");

        foreach (GameObject obj in allObjects)
        {
            // Skip inactive objects
            if (!obj.activeInHierarchy)
            {
                continue; // Ga naar volgende object
            }

            // Skip objects without specific component
            if (obj.GetComponent<Renderer>() == null)
            {
                continue; // Ga naar volgende object
            }

            // Process object
            Debug.Log("Processing: " + obj.name);
            obj.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void ProcessOnlyEvenNumbers()
    {
        Debug.Log("=== EVEN NUMBERS ONLY ===");

        foreach (int number in numbers)
        {
            // Skip odd numbers
            if (number % 2 != 0)
            {
                continue; // Ga naar volgend getal
            }

            // Process even number
            Debug.Log("Even number: " + number + " squared = " + (number * number));
        }
    }
}
```

---

## Performance en Optimalisatie

### Loop Performance Tips

```csharp
public class LoopPerformance : MonoBehaviour
{
    public List<GameObject> manyObjects = new List<GameObject>();

    void Start()
    {
        // Maak grote lijst voor testing
        for (int i = 0; i < 1000; i++)
        {
            GameObject obj = new GameObject("Object_" + i);
            manyObjects.Add(obj);
        }

        CompareLoopTypes();
        OptimizationTips();
    }

    void CompareLoopTypes()
    {
        Debug.Log("=== PERFORMANCE COMPARISON ===");

        // Test for loop
        float startTime = Time.realtimeSinceStartup;
        for (int i = 0; i < manyObjects.Count; i++)
        {
            // Simuleer werk
            manyObjects[i].name = "Processed_" + i;
        }
        float forTime = Time.realtimeSinceStartup - startTime;

        // Test foreach loop
        startTime = Time.realtimeSinceStartup;
        int index = 0;
        foreach (GameObject obj in manyObjects)
        {
            obj.name = "Processed_" + index;
            index++;
        }
        float foreachTime = Time.realtimeSinceStartup - startTime;

        Debug.Log("For loop time: " + forTime);
        Debug.Log("Foreach loop time: " + foreachTime);
    }

    void OptimizationTips()
    {
        Debug.Log("=== OPTIMIZATION TIPS ===");

        // ❌ Slecht - Count wordt elke iteratie herberekend
        for (int i = 0; i < manyObjects.Count; i++)
        {
            // Doe iets
        }

        // ✅ Beter - Cache de Count
        int count = manyObjects.Count;
        for (int i = 0; i < count; i++)
        {
            // Doe iets
        }

        // ❌ Slecht - GetComponent elke frame
        foreach (GameObject obj in manyObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                // Doe iets
            }
        }

        // ✅ Beter - Cache components
        List<Renderer> cachedRenderers = new List<Renderer>();
        foreach (GameObject obj in manyObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                cachedRenderers.Add(renderer);
            }
        }

        // Nu gebruik cached list
        foreach (Renderer renderer in cachedRenderers)
        {
            // Veel sneller!
        }
    }
}
```

---

## Complexe Game Systemen met Loops

### Tower Defense Enemy Waves

```csharp
public class WaveManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyWave
    {
        public GameObject enemyPrefab;
        public int enemyCount;
        public float spawnDelay;
        public float timeBetweenEnemies;
    }

    public List<EnemyWave> waves = new List<EnemyWave>();
    public List<Transform> spawnPoints = new List<Transform>();
    private int currentWave = 0;
    private bool waveInProgress = false;

    void Start()
    {
        StartCoroutine(ManageWaves());
    }

    System.Collections.IEnumerator ManageWaves()
    {
        // Loop door alle waves
        for (int waveIndex = 0; waveIndex < waves.Count; waveIndex++)
        {
            currentWave = waveIndex;
            Debug.Log("=== STARTING WAVE " + (waveIndex + 1) + " ===");

            yield return new WaitForSeconds(waves[waveIndex].spawnDelay);

            waveInProgress = true;
            yield return StartCoroutine(SpawnWave(waves[waveIndex]));
            waveInProgress = false;

            // Wacht tot alle vijanden verslagen zijn
            yield return StartCoroutine(WaitForWaveComplete());

            Debug.Log("Wave " + (waveIndex + 1) + " completed!");
        }

        Debug.Log("ALL WAVES COMPLETED!");
    }

    System.Collections.IEnumerator SpawnWave(EnemyWave wave)
    {
        // Spawn alle enemies in deze wave
        for (int enemyIndex = 0; enemyIndex < wave.enemyCount; enemyIndex++)
        {
            // Kies random spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            // Spawn enemy
            GameObject enemy = Instantiate(wave.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.name = "Wave" + currentWave + "_Enemy" + enemyIndex;

            Debug.Log("Spawned: " + enemy.name);

            // Wacht voor volgende enemy
            yield return new WaitForSeconds(wave.timeBetweenEnemies);
        }
    }

    System.Collections.IEnumerator WaitForWaveComplete()
    {
        // Wacht tot alle vijanden weg zijn
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        // Debug info
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowWaveStatus();
        }
    }

    void ShowWaveStatus()
    {
        Debug.Log("=== WAVE STATUS ===");
        Debug.Log("Current wave: " + (currentWave + 1) + "/" + waves.Count);
        Debug.Log("Wave in progress: " + waveInProgress);
        Debug.Log("Enemies remaining: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}
```

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat is het verschil tussen for, foreach en while loops?
- Wanneer gebruik je welke loop type?
- Hoe werken nested loops (loops in loops)?
- Wat doen break en continue statements?
- Hoe optimaliseer je loop performance?
- Hoe combineer je loops met kennis uit vorige lessen?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

## Oefeningen uitvoeren

Doe nu minimaal 1 oefening naar keuze voor les 6.2
De oefeningen vind je [hier](../Oefeningen/oefeningen_6_2.md) terug

![exercise](https://media.giphy.com/media/v1.Y2lkPWVjZjA1ZTQ3ZXRrc3QwYWV1Ym5oY2FrZnF5YWxnaW9heTRsNnZzdnpnMmRxeXM1ZiZlcD12MV9naWZzX3JlbGF0ZWQmY3Q9Zw/x1BVziEYuKBd1aVZRz/giphy.gif)

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je beheerst for-loops met verschillende patronen en incrementen
- [ ] Je kunt foreach-loops gebruiken voor verschillende data types
- [ ] Je begrijpt while en do-while loops
- [ ] Je kunt nested loops maken voor complexe systemen
- [ ] Je weet hoe je break en continue gebruikt voor loop control
- [ ] Je hebt performance optimalisaties geleerd voor loops
- [ ] Je kunt complexe game systemen bouwen met loops
- [ ] Je combineert loops effectief met kennis uit alle vorige lessen

### Volgende Stap

In Les 7.1 komt er een summatieve toets om je kennis te testen, plus tijd voor inhaalopdrachten!

---

## Veelgestelde Vragen

### Q: Wanneer gebruik ik for vs foreach vs while?

**A:**

- **For**: Als je index nodig hebt, specifieke range, of achterstevoren wilt
- **Foreach**: Als je alleen alle items wilt doorlopen (eenvoudigst en veiligst)
- **While**: Als je niet weet hoeveel iteraties je nodig hebt

### Q: Hoe voorkom ik oneindige loops?

**A:** Zorg altijd dat je loop conditie **kan veranderen**:

```csharp
// ❌ Oneindige loop
while (true)
{
    Debug.Log("Dit stopt nooit!");
}

// ✅ Goede loop
int counter = 0;
while (counter < 10)
{
    Debug.Log("Safe loop");
    counter++; // Conditie verandert!
}
```

### Q: Mijn nested loops zijn traag, wat nu?

**A:** Optimaliseer door:

- Vermijd onnodige GetComponent() calls
- Cache List.Count waarden
- Gebruik break/continue om vroeg te stoppen
- Overweeg Coroutines voor zeer grote loops

### Q: Hoe break ik uit een nested loop?

**A:** Break breekt alleen uit de **innerste** loop. Voor outer loops gebruik je flags:

```csharp
bool found = false;
for (int x = 0; x < 10 && !found; x++)
{
    for (int y = 0; y < 10; y++)
    {
        if (/* conditie */)
        {
            found = true;
            break; // Uit inner loop
        }
    }
}
```

### Q: Kan ik lijsten modificeren tijdens foreach?

**A:** Nee! Dit geeft errors. Gebruik for loops die achterstevoren lopen:

```csharp
// ❌ Fout
foreach (var item in lijst)
{
    lijst.Remove(item); // Error!
}

// ✅ Goed
for (int i = lijst.Count - 1; i >= 0; i--)
{
    if (/* conditie */) lijst.RemoveAt(i);
}
```

---
