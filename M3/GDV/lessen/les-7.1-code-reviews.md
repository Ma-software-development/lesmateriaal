# Les 7.1 — Code Reviews

## Leerdoel

Na deze les kun je code reviews uitvoeren en geven/ontvangen van constructieve feedback.

---

## Theorie

### Waarom Code Reviews?

| Voordeel         | Uitleg                             |
| ---------------- | ---------------------------------- |
| **Bugs vinden**  | Tweede paar ogen ziet wat jij mist |
| **Kennis delen** | Leer van elkaars oplossingen       |
| **Consistentie** | Code blijft leesbaar en uniform    |
| **Leren**        | Zowel reviewer als auteur leert    |

### Wat Review Je?

**Functionaliteit:**

- Doet de code wat het moet doen?
- Zijn er edge cases gemist?
- Kan het crashen?

**Leesbaarheid:**

- Zijn variabele namen duidelijk?
- Is de code logisch geordend?
- Zijn er comments waar nodig?

**Best Practices:**

- Is de code DRY (Don't Repeat Yourself)?
- Zijn functies niet te lang?
- Is de logica niet te complex?

### Code Review Checklist

```markdown
## Code Review Checklist

### Basics

- [ ] Code compileert zonder errors
- [ ] Geen duidelijke bugs
- [ ] Variabelen hebben duidelijke namen

### Structuur

- [ ] Functies doen één ding
- [ ] Geen duplicate code
- [ ] Logische file/class organisatie

### Unity-specifiek

- [ ] Geen Find() in Update
- [ ] Correct gebruik van Update vs FixedUpdate
- [ ] SerializeField gebruikt ipv public waar gepast

### Comments

- [ ] Complexe code is uitgelegd
- [ ] Geen commented-out code (verwijderen!)
- [ ] TODO's zijn duidelijk
```

### Feedback Geven

**Niet:**

> "Dit is slecht"
> "Waarom doe je dit zo?"

**Wel:**

> "Overweeg om deze functie op te splitsen, dat maakt testen makkelijker"
> "Ik begrijp niet helemaal wat `x` doet, kun je de naam verduidelijken?"

### Feedback Structuur

```
[Wat] - Beschrijf wat je ziet
[Waarom] - Leg uit waarom het een probleem is
[Voorstel] - Geef een alternatief
```

Voorbeeld:

> "De functie `DoStuff()` is 80 regels lang. [Wat]
> Dit maakt het moeilijk te testen en debuggen. [Waarom]
> Overweeg om het op te splitsen in `HandleInput()`, `ProcessMovement()` en `UpdateUI()`. [Voorstel]"

---

## Oefeningen

### Oefening 1: Code Analyseren

Bekijk onderstaande code en noteer 3 verbeterpunten:

```csharp
public class player : MonoBehaviour
{
    public float s = 5;
    public int h = 100;
    public int sc = 0;
    GameObject[] e;

    void Update()
    {
        e = GameObject.FindGameObjectsWithTag("Enemy");

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.position += new Vector3(x, y, 0) * s * Time.deltaTime;

        if (h <= 0)
        {
            Debug.Log("ded");
            // TODO fix this later
            //Destroy(gameObject);
            //SceneManager.LoadScene("GameOver");
            //maybe add explosion?
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Dot")
        {
            sc = sc + 10;
            Destroy(c.gameObject);
        }
        if (c.tag == "Enemy")
        {
            h = h - 10;
        }
        if (c.tag == "PowerUp")
        {
            // powerup
        }
    }
}
```

**Jouw verbeterpunten:**

1. ***
2. ***
3. ***

<details>
<summary>Mogelijke antwoorden</summary>

1. Variabele namen onduidelijk: `s` → `speed`, `h` → `health`, `sc` → `score`
2. `FindGameObjectsWithTag` in Update is inefficiënt
3. Commented-out code en onduidelijke TODO's
4. Class naam begint met kleine letter
5. Empty PowerUp trigger heeft geen implementatie
6. Magic numbers (10 voor score, 10 voor damage)
7. Geen gebruik van CompareTag (veiliger dan ==)

</details>

---

### Oefening 2: Peer Review

Voer een code review uit op elkaars code:

**Stap 1: Voorbereiding (5 min)**

- Open het project van je review-partner
- Kies één script om te reviewen

**Stap 2: Review (10 min)**

Vul in voor het script dat je reviewed:

| Aspect          | Score (1-5) | Opmerking |
| --------------- | ----------- | --------- |
| Leesbaarheid    |             |           |
| Naamgeving      |             |           |
| Structuur       |             |           |
| Functionaliteit |             |           |
| Comments        |             |           |

**Top 3 sterke punten:**

1.
2.
3.

**Top 3 verbeterpunten:**

1.
2.
3.

**Stap 3: Bespreking (10 min)**

- Deel je feedback mondeling
- Vraag om verduidelijking waar nodig
- Schrijf actie-items op

---

## Toepassing

1. Review minimaal 2 scripts van je duo-partner
2. Gebruik de checklist als leidraad
3. Schrijf je feedback op in een bestand of issue
4. Bespreek samen en maak een plan voor verbeteringen

**Tip:** Wees specifiek en constructief. Het doel is verbeteren, niet bekritiseren.
