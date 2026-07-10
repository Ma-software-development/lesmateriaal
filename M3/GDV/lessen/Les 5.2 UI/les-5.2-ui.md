# Les 5.2 — UI (User Interface)

## Leerdoel

Na deze les kun je een User Interface bouwen met score, levens en menu's.

---

## Theorie

### UI Canvas

Unity UI werkt met een Canvas:

```
Canvas (Screen Space - Overlay)
├── Panel (achtergrond)
├── Text - Score
├── Image - Lives
└── Button - Pause
```

### Canvas Setup

1. GameObject → UI → Canvas
2. Canvas Scaler:
   - UI Scale Mode: **Scale With Screen Size**
   - Reference Resolution: 1920 x 1080
   - Match: 0.5

### UI Componenten

| Component      | Gebruik                 |
| -------------- | ----------------------- |
| **Text (TMP)** | Score, labels           |
| **Image**      | Icons, achtergronden    |
| **Button**     | Klikbare acties         |
| **Panel**      | Groeperen van elementen |

### TextMeshPro

Gebruik TextMeshPro voor mooiere tekst:

1. GameObject → UI → Text - TextMeshPro
2. Bij eerste keer: Import TMP Essentials

```csharp
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
```

### UI Anchors

Anchors bepalen waar UI-elementen blijven bij resize:

| Positie              | Anchor preset |
| -------------------- | ------------- |
| Linksboven           | top-left      |
| Rechtsboven          | top-right     |
| Midden               | center        |
| Onderaan gecentreerd | bottom-center |

---

## Oefeningen

### Oefening 1: Score Display

Maak een score display:

**1. Setup:**

- Canvas toevoegen (als je die nog niet hebt)
- UI → Text - TextMeshPro
- Naam: "ScoreText"
- Anchor: Top-left
- Positie: (100, -50)
- Tekst: "Score: 0"

**2. Script (ScoreManager.cs):**

```csharp
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
```

**3. Koppelen:**

- Maak leeg GameObject "ScoreManager"
- Voeg script toe
- Sleep ScoreText naar het veld

**4. Aanroepen vanuit andere scripts:**

```csharp
// In je Dot script bij OnTriggerEnter2D:
ScoreManager.Instance.AddScore(10);
```

**Test:** Score verhoogt bij het verzamelen van dots.

---

### Oefening 2: Lives Display

Maak een lives display met hartjes:

**1. Maak heart sprite** (of download)

**2. Setup:**

- UI → Image (3x)
- Naam: Heart1, Heart2, Heart3
- Anchor: Top-right
- Layout: naast elkaar

**3. Script (LivesUI.cs):**

```csharp
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Image[] hearts;
    private int currentLives;

    void Start()
    {
        currentLives = hearts.Length;
    }

    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;
            hearts[currentLives].enabled = false;
        }

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
        }
    }

    public void ResetLives()
    {
        currentLives = hearts.Length;
        foreach (Image heart in hearts)
        {
            heart.enabled = true;
        }
    }
}
```

**Test:** Bij aanroepen van `LoseLife()` verdwijnt een hartje.

---

## Toepassing

Bouw de UI voor je game:

**Minimaal:**

- [ ] Score display
- [ ] Lives/health indicator
- [ ] Game Over scherm

**Optioneel:**

- [ ] Pause menu
- [ ] Level indicator
- [ ] Power-up timer
- [ ] High score

**Tip:** Maak een aparte scene voor je UI-prefabs, of gebruik UI prefabs die je in meerdere scenes kunt hergebruiken.
