# Les 2.1 — Grid maken met modulo

## Leerdoel

Na deze les kun je een level genereren vanuit een string of array met tekens.

---

## Theorie

### Waarom een Grid?

In PAC-MAN-achtige games bestaat het level uit een raster (grid) van tiles:

- Muren (niet begaanbaar)
- Vloer (begaanbaar)
- Dots (te verzamelen)
- Power-ups

### Level als String

Je kunt een level definiëren als tekst:

```csharp
string[] levelData = {
    "##########",
    "#........#",
    "#.##.##..#",
    "#........#",
    "#.##P.##.#",
    "#........#",
    "##########"
};
```

| Teken | Betekenis    |
| ----- | ------------ |
| `#`   | Muur         |
| `.`   | Dot          |
| `P`   | Player spawn |
| ` `   | Lege vloer   |

### Modulo voor Positie

Met modulo (`%`) bereken je de X-positie in het grid:

```csharp
for (int i = 0; i < levelString.Length; i++)
{
    int x = i % gridWidth;   // Kolom
    int y = i / gridWidth;   // Rij

    char tile = levelString[i];
    SpawnTile(tile, x, y);
}
```

### Grid Generator Script

```csharp
public class GridGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject dotPrefab;
    public GameObject playerPrefab;

    string[] levelData = {
        "##########",
        "#........#",
        "#.##.##..#",
        "#........#",
        "##########"
    };

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int y = 0; y < levelData.Length; y++)
        {
            string row = levelData[y];
            for (int x = 0; x < row.Length; x++)
            {
                char tile = row[x];
                Vector3 position = new Vector3(x, -y, 0);

                switch (tile)
                {
                    case '#':
                        Instantiate(wallPrefab, position, Quaternion.identity);
                        break;
                    case '.':
                        Instantiate(dotPrefab, position, Quaternion.identity);
                        break;
                    case 'P':
                        Instantiate(playerPrefab, position, Quaternion.identity);
                        break;
                }
            }
        }
    }
}
```

---

## Oefeningen

### Oefening 1: Simpel Grid

Maak een 5x5 grid met alleen muren en vloeren:

```csharp
string[] level = {
    "#####",
    "#   #",
    "# # #",
    "#   #",
    "#####"
};
```

1. Maak een `Wall` prefab (cube, schaal 1x1x1)
2. Maak een `GridGenerator` script
3. Genereer het level in `Start()`

**Check:** Je ziet een doolhof-vorm in de Scene view.

---

### Oefening 2: Dots toevoegen

Breid je grid uit met dots:

```csharp
string[] level = {
    "#####",
    "#...#",
    "#.#.#",
    "#...#",
    "#####"
};
```

1. Maak een `Dot` prefab (kleine sphere)
2. Voeg een case toe voor `.` in je switch
3. Tel hoeveel dots er gespawned zijn

**Bonus:** Maak een `dotCount` variabele en print deze in de console.

---

## Toepassing

Ontwerp je eerste level voor je eigen game:

1. Teken het level op ruitjespapier (of in een tekenprogramma)
2. Vertaal dit naar een string-array
3. Bepaal welke tekens je nodig hebt voor jouw game

**Tip:** Begin klein (10x10) en breid later uit.
