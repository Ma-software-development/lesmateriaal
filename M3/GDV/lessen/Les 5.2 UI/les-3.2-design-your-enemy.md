# Les 3.2 — Animatie maken in Unity

## Leerdoel

Na deze les kun je sprite-animaties maken in Unity met de Animator.

---

## Theorie

### Animatie Componenten

| Component               | Functie                       |
| ----------------------- | ----------------------------- |
| **Sprite**              | Enkele afbeelding             |
| **Animation Clip**      | Reeks sprites over tijd       |
| **Animator Controller** | Beheert welke animatie speelt |
| **Animator**            | Component op GameObject       |

### Sprite Sheet

Een sprite sheet bevat meerdere frames in één afbeelding:

```
+---+---+---+---+
| 1 | 2 | 3 | 4 |  <- Walk animation
+---+---+---+---+
| 5 | 6 | 7 | 8 |  <- Idle animation
+---+---+---+---+
```

### Sprite Sheet Importeren

1. Sleep sprite sheet naar Assets
2. Selecteer het bestand
3. In Inspector:
   - Sprite Mode: **Multiple**
   - Pixels Per Unit: 16 (of passend)
4. Klik **Sprite Editor**
5. Slice: Grid by Cell Size
6. Apply

### Animatie Maken

1. Selecteer je GameObject
2. Window → Animation → Animation
3. Klik **Create**
4. Sleep sprites naar timeline
5. Pas **Samples** aan (frames per seconde)

### Animator Controller

De Animator Controller bepaalt welke animatie speelt:

```
[Idle] ──── speed > 0 ───→ [Walk]
   ↑                          │
   └───── speed == 0 ─────────┘
```

---

## Oefeningen

### Oefening 1: Idle Animatie

Maak een simpele idle animatie:

1. **Maak sprites** (of download):
   - Idle_1.png
   - Idle_2.png (iets anders, bijv. knipperen)

2. **Maak animatie:**
   - Selecteer je Player
   - Open Animation window
   - Create → `Player_Idle.anim`
   - Sleep beide sprites naar timeline
   - Zet Samples op 2 (langzaam)

3. **Test:**
   - Play de game
   - Je character moet subtiel bewegen/knipperen

**Geen sprites?** Gebruik gekleurde vierkanten die van kleur wisselen.

---

### Oefening 2: Walk Animatie

Maak een walk animatie met 4 frames:

1. **Maak/vind 4 walk sprites**

2. **Maak animatie:**
   - Create → `Player_Walk.anim`
   - Sleep 4 sprites naar timeline
   - Samples: 8-12

3. **Animator instellen:**
   - Open Animator window
   - Je ziet Idle en Walk states
   - Maak transition: Idle → Walk
   - Maak transition: Walk → Idle

4. **Parameter toevoegen:**
   - Parameters tab → + → Float → "Speed"
   - Idle→Walk: Condition = Speed > 0.1
   - Walk→Idle: Condition = Speed < 0.1

5. **Script aanpassen:**

```csharp
private Animator animator;

void Start()
{
    animator = GetComponent<Animator>();
}

void Update()
{
    float speed = movement.magnitude;
    animator.SetFloat("Speed", speed);
}
```

**Test:** Je character loopt als je beweegt, staat stil als je stopt.

---

## Toepassing

Maak animaties voor je eigen game:

1. **Minimaal nodig:**
   - Idle animatie (2+ frames)
   - Movement animatie (4+ frames)

2. **Optioneel:**
   - Verschillende richtingen (left/right/up/down)
   - Special action (power-up, damage)

**Tip:** Gebruik [OpenGameArt.org](https://opengameart.org) of [itch.io](https://itch.io/game-assets/free) voor gratis sprites.
