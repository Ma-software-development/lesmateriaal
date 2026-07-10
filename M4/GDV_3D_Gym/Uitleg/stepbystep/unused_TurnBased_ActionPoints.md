# Step By Step — Beurt-gebaseerd Spel: Action Points System

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je begrijpt hoe een `TurnManager` de volgorde van spelers beheert
- Je kunt een eenvoudig **action points**-systeem bouwen waarbij elke beurt een budget aan punten heeft
- Je kunt acties (bewegen, aanvallen) koppelen aan action point-kosten
- Je kunt een beurt automatisch beëindigen als een speler geen punten meer heeft
- Je kunt de spelstatus tonen in een eenvoudige UI

---

## Concept: hoe werkt het systeem?

```
TurnManager
│
├── Speler 1  →  krijgt X action points aan het begin van zijn beurt
│               doet acties (elke actie kost punten)
│               beurt eindigt: handmatig (knop) of automatisch (geen punten meer)
│
└── Speler 2  →  zelfde principe
```

| Term                   | Betekenis                                                 |
| ---------------------- | --------------------------------------------------------- |
| **Beurt (turn)**       | De periode dat één speler acties mag uitvoeren            |
| **Action Points (AP)** | Budget per beurt, verbruikt per actie                     |
| **TurnManager**        | Script dat bijhoudt wie er aan de beurt is                |
| **PlayerUnit**         | Script op elke speler met AP-teller en beschikbare acties |

---

## Stap 1 — Scene klaarzetten

1. Maak twee **Cube**-GameObjects aan in de Hierarchy:
   - Noem ze `Player1` en `Player2`.
   - Geef `Player1` een **blauw** materiaal, `Player2` een **rood** materiaal.
2. Zet ze een stuk uit elkaar in de scene (bijv. X = −3 en X = 3).
3. Maak een leeg GameObject aan: **rechtermuisknop in Hierarchy > Create Empty**.
   - Noem het `GameManager`.

---

## Stap 2 — PlayerUnit script

Dit script houdt de action points van één speler bij en voert acties uit.

1. Maak een nieuw script **`PlayerUnit.cs`** via **Assets > Create > C# Script**.
2. Vervang de inhoud door:

```csharp
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    [Header("Instellingen")]
    public string playerName = "Speler";
    public int maxActionPoints = 3;

    [HideInInspector]
    public int currentActionPoints;

    // Herstel punten aan het begin van een nieuwe beurt
    public void StartTurn()
    {
        currentActionPoints = maxActionPoints;
        Debug.Log($"{playerName} begint zijn beurt met {currentActionPoints} AP.");
    }

    // Geeft true terug als de actie gelukt is, false als er onvoldoende AP zijn
    public bool SpendPoints(int cost)
    {
        if (currentActionPoints < cost)
        {
            Debug.Log($"{playerName} heeft onvoldoende AP ({currentActionPoints} / {cost} nodig).");
            return false;
        }

        currentActionPoints -= cost;
        Debug.Log($"{playerName} gebruikt {cost} AP. Resterend: {currentActionPoints}");
        return true;
    }

    public bool HasPointsLeft()
    {
        return currentActionPoints > 0;
    }
}
```

3. Koppel het script aan **Player1** en **Player2**.
4. Stel in de **Inspector** per speler de naam in:
   - `Player1`: playerName = `Speler 1`
   - `Player2`: playerName = `Speler 2`

---

## Stap 3 — TurnManager script

De `TurnManager` regelt welke speler aan de beurt is en schakelt tussen spelers.

1. Maak een nieuw script **`TurnManager.cs`**.
2. Vervang de inhoud door:

```csharp
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [Header("Spelers (volgorde = beurtvolgorde)")]
    public PlayerUnit[] players;

    private int currentPlayerIndex = 0;

    public PlayerUnit CurrentPlayer => players[currentPlayerIndex];

    void Start()
    {
        StartTurnFor(currentPlayerIndex);
    }

    // Roep dit aan via UI-knop of automatisch vanuit een actie
    public void EndTurn()
    {
        Debug.Log($"Beurt van {CurrentPlayer.playerName} eindigt.");

        // Ga naar de volgende speler (loopt rond)
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;

        StartTurnFor(currentPlayerIndex);
    }

    private void StartTurnFor(int index)
    {
        players[index].StartTurn();
        Debug.Log($"=== Beurt van {players[index].playerName} ===");
    }
}
```

3. Koppel `TurnManager.cs` aan het `GameManager`-object.
4. Zet in de Inspector de **Players**-lijst:
   - Size = **2**
   - Element 0 = `Player1`
   - Element 1 = `Player2`

---

## Stap 4 — Acties koppelen aan action points

Elke actie kost een aantal AP. Maak een script **`PlayerActions.cs`** dat concrete acties bevat.

1. Maak `PlayerActions.cs` en koppel het aan **Player1** en **Player2**:

```csharp
using UnityEngine;

[RequireComponent(typeof(PlayerUnit))]
public class PlayerActions : MonoBehaviour
{
    [Header("Kosten per actie")]
    public int moveCost = 1;
    public int attackCost = 2;
    public float moveDistance = 2f;

    private PlayerUnit unit;
    private TurnManager turnManager;

    void Start()
    {
        unit = GetComponent<PlayerUnit>();
        turnManager = FindFirstObjectByType<TurnManager>();
    }

    public void MoveForward()
    {
        // Controleer of dit de actieve speler is
        if (turnManager.CurrentPlayer != unit)
        {
            Debug.Log("Niet jouw beurt!");
            return;
        }

        if (unit.SpendPoints(moveCost))
        {
            transform.Translate(Vector3.forward * moveDistance);
            AutoEndTurnIfNeeded();
        }
    }

    public void Attack()
    {
        if (turnManager.CurrentPlayer != unit)
        {
            Debug.Log("Niet jouw beurt!");
            return;
        }

        if (unit.SpendPoints(attackCost))
        {
            Debug.Log($"{unit.playerName} valt aan!");
            AutoEndTurnIfNeeded();
        }
    }

    // Eindigt de beurt automatisch als er geen AP meer zijn
    private void AutoEndTurnIfNeeded()
    {
        if (!unit.HasPointsLeft())
        {
            Debug.Log("Geen AP meer — beurt eindigt automatisch.");
            turnManager.EndTurn();
        }
    }
}
```

2. Stel per speler in de Inspector de kosten in zoals gewenst.

---

## Stap 5 — UI aanmaken

Een simpele UI toont welke speler aan de beurt is en hoeveel AP er nog zijn.

### Canvas en tekst aanmaken

1. Rechtermuisknop in Hierarchy → **UI > Canvas**.
2. Klik op het Canvas → **UI > Text - TextMeshPro** (voeg het TMP-pakket toe als gevraagd).
   - Noem het `TurnText`.
   - Zet het linksboven in het Canvas (Anchor: Top Left).
   - Stel de tekst in op: `Beurt: —`
3. Voeg een tweede **TextMeshPro**-tekst toe:
   - Noem het `APText`.
   - Zet het eronder.
   - Stel in: `AP: —`
4. Voeg een **UI > Button - TextMeshPro** toe:
   - Noem het `EndTurnButton`.
   - Stel de knoptekst in op `Beurt beëindigen`.

### UI-script aanmaken

5. Maak een script **`GameUI.cs`** en koppel het aan het **Canvas**-object:

```csharp
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Referenties")]
    public TMP_Text turnText;
    public TMP_Text apText;
    public Button endTurnButton;

    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindFirstObjectByType<TurnManager>();
        endTurnButton.onClick.AddListener(OnEndTurnClicked);
        UpdateUI();
    }

    void Update()
    {
        // Ververs elke frame zodat AP-wijzigingen direct zichtbaar zijn
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (turnManager == null) return;

        PlayerUnit current = turnManager.CurrentPlayer;
        turnText.text = $"Beurt: {current.playerName}";
        apText.text   = $"AP: {current.currentActionPoints} / {current.maxActionPoints}";
    }

    private void OnEndTurnClicked()
    {
        turnManager.EndTurn();
    }
}
```

6. Sleep de **TurnText**, **APText** en **EndTurnButton** naar de juiste velden in de Inspector.

---

## Stap 6 — Acties koppelen aan toetsen (optioneel)

Wil je spelers via het toetsenbord aansturen? Voeg dit toe aan `PlayerActions.cs`:

```csharp
void Update()
{
    // Alleen invoer verwerken als dit de actieve speler is
    if (turnManager.CurrentPlayer != unit) return;

    if (Input.GetKeyDown(KeyCode.W)) MoveForward();
    if (Input.GetKeyDown(KeyCode.Space)) Attack();
}
```

> **Tip voor twee spelers op één toetsenbord:**  
> Geef `Player1` de toetsen **W / Space** en `Player2` de toetsen **UpArrow / RightControl**.  
> Controleer in `Update()` per speler of de juiste toetsen zijn ingedrukt.

---

## Stap 7 — Testen

1. Klik op **Play**.
2. Controleer in de **Console** dat Speler 1 begint met `maxActionPoints` AP.
3. Voer acties uit (knop of toets). Controleer dat het AP-getal daalt.
4. Als AP op 0 staat, eindigt de beurt automatisch **of** klik op **Beurt beëindigen**.
5. Controleer dat Speler 2 nu aan de beurt is (console + UI).

---

## Overzicht van de scripts

| Script          | Verantwoordelijkheid                                  |
| --------------- | ----------------------------------------------------- |
| `TurnManager`   | Bijhouden wie er aan de beurt is, wisselen van speler |
| `PlayerUnit`    | Action points bijhouden, punten aftrekken             |
| `PlayerActions` | Concrete acties die AP verbruiken                     |
| `GameUI`        | Spelstatus tonen, knop voor beurt beëindigen          |

---

## Uitbreidingsideeën

- Voeg een **Health**-variabele toe aan `PlayerUnit` en verminder die bij een aanval.
- Maak een `ActionButton`-prefab: een UI-knop die automatisch de AP-kosten toont en grijst als de speler onvoldoende AP heeft.
- Laat de beurt na een vaste tijd automatisch eindigen met een **Coroutine** en een afteltimer in de UI.
- Voeg meer dan twee spelers toe: de `TurnManager` ondersteunt dit al — vergroot simpelweg de `players`-lijst.
