# Step By Step — Dialogue-systeem: NPC Gesprekken

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt een reeks dialoogregels opslaan in een datastructuur
- Je kunt een dialoogvenster tonen en regel voor regel doorlopen
- Je kunt een gesprek starten door op een NPC te klikken of er naast te staan
- Je kunt het dialoogvenster automatisch sluiten als alle regels doorlopen zijn

---

## Concept: hoe werkt een dialogue-systeem?

```
DialogueData  (array van strings)
      │  speler drukt E naast NPC
      ▼
DialogueManager  →  toont eerste regel in UI
      │  speler drukt Space / E
      ▼
DialogueManager  →  toont volgende regel
      │  geen regels meer
      ▼
DialogueManager  →  sluit venster
```

---

## Stap 1 — Dialoog data aanmaken

1. Maak een nieuw script **`DialogueData.cs`**. Dit is puur data, geen MonoBehaviour:

```csharp
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public string speakerName = "???";

    [TextArea(2, 5)]   // maakt het veld in de Inspector groter voor lange teksten
    public string[] lines;
}
```

> **`[TextArea]`** geeft het `lines`-veld een groter tekstvak in de Inspector — handig voor langere zinnen.

---

## Stap 2 — DialogueManager script

De manager ontvangt dialogen, toont ze regel voor regel en beheert de UI.

1. Maak een leeg GameObject → noem het `DialogueManager`.
2. Maak **`DialogueManager.cs`** en koppel het eraan:

```csharp
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("UI-referenties")]
    public GameObject dialoguePanel;    // het dialoogvenster (Canvas-kind)
    public TMP_Text speakerNameText;
    public TMP_Text dialogueLineText;

    private DialogueData currentDialogue;
    private int currentLineIndex = 0;
    private bool isActive = false;

    void Update()
    {
        // Ga naar de volgende regel als het venster open is
        if (isActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    // Start een nieuw gesprek
    public void StartDialogue(DialogueData dialogue)
    {
        currentDialogue   = dialogue;
        currentLineIndex  = 0;
        isActive          = true;

        dialoguePanel.SetActive(true);
        speakerNameText.text = dialogue.speakerName;
        dialogueLineText.text = dialogue.lines[0];
    }

    private void ShowNextLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= currentDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueLineText.text = currentDialogue.lines[currentLineIndex];
    }

    private void EndDialogue()
    {
        isActive = false;
        dialoguePanel.SetActive(false);
        currentDialogue = null;
    }

    public bool IsActive()
    {
        return isActive;
    }
}
```

---

## Stap 3 — UI aanmaken

1. Maak een **Canvas** aan.
2. Voeg een **Panel** toe als kind van het Canvas → noem het `DialoguePanel`.
   - Vergroot het naar de onderkant van het scherm (Anchor: onderste strook).
3. Voeg binnen het panel toe:
   - **TextMeshPro** → noem het `SpeakerNameText` (klein, linksboven in het panel)
   - **TextMeshPro** → noem het `DialogueLineText` (groot, midden in het panel)
4. Sleep deze objecten naar de velden **Speaker Name Text** en **Dialogue Line Text** in de Inspector van `DialogueManager`.
5. Sleep **DialoguePanel** naar het veld **Dialogue Panel**.
6. Zet `DialoguePanel` **uit** in de Inspector (vinkje bovenaan uitzetten) — het wordt pas zichtbaar als een gesprek start.

---

## Stap 4 — NPC aanmaken

1. Maak een **Capsule**-GameObject → noem het `NPC`.
2. Voeg een **Sphere Collider** toe (voor de interactieradius):
   - Zet **Is Trigger** aan.
   - Stel **Radius** in op `2`.
3. Maak **`NPCDialogueTrigger.cs`** en koppel het aan de NPC:

```csharp
using UnityEngine;

public class NPCDialogueTrigger : MonoBehaviour
{
    [Header("Dialoog van deze NPC")]
    public DialogueData dialogue;

    private bool playerInRange = false;
    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueManager.IsActive())
            {
                dialogueManager.StartDialogue(dialogue);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Druk E om te praten.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
```

---

## Stap 5 — Dialoog invullen in de Inspector

1. Selecteer de NPC in de Hierarchy.
2. In de Inspector bij `NPCDialogueTrigger`:
   - **Speaker Name:** `Dorpsbewoner`
   - **Lines > Size:** `3`
   - **Element 0:** `Hé, jij daar! Pas op voor het bos.`
   - **Element 1:** `Er wonen gevaarlijke wezens in de nacht.`
   - **Element 2:** `Neem dit — het brengt geluk.`
3. Zorg dat de speler de tag **Player** heeft.

---

## Stap 6 — Testen

1. Klik op **Play**.
2. Loop naar de NPC tot het console-bericht verschijnt.
3. Druk **E** — het dialoogvenster opent met de eerste zin.
4. Druk opnieuw **E** voor elke volgende zin.
5. Na de laatste zin sluit het venster automatisch.

---

## Overzicht van de scripts

| Script                 | Verantwoordelijkheid                                       |
|------------------------|------------------------------------------------------------|
| `DialogueData`         | Dataklasse: sprekersnaam en array van zinnen               |
| `DialogueManager`      | Toont het dialoogvenster, bladert door zinnen              |
| `NPCDialogueTrigger`   | Detecteert de speler, start het gesprek bij E-druk         |

---

## Uitbreidingsideeën

- **Keuze-dialoog:** toon na een zin twee knoppen (`Ja` / `Nee`) en vertak de dialoog op basis van de keuze.
- **Typemachine-effect:** toon letters één voor één met een Coroutine i.p.v. de hele zin in één keer.
- **Condities:** laat een NPC andere tekst tonen als de speler een bepaald item heeft (check de `Inventory` uit Les 22).
