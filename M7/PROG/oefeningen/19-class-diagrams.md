# Oefening 19 — Class Diagrams

**Onderwerp:** Visuele modellen, klasse-diagrammen lezen en maken  
**Module:** M5 / M6

---

## Oefening 19a — Class diagram lezen

Bekijk het volgende diagram en beantwoord de vragen.

```
┌──────────────────────┐
│       Enemy          │
├──────────────────────┤
│ - health : int       │
│ - speed : float      │
│ # damage : int       │
├──────────────────────┤
│ + TakeDamage(int)    │
│ + Move() : void      │
│ # Die() : void       │
└──────────────────────┘
         ▲
         │ extends
┌──────────────────────┐
│     FlyingEnemy      │
├──────────────────────┤
│ - flyHeight : float  │
├──────────────────────┤
│ + Move() : void      │
│ + Swoop() : void     │
└──────────────────────┘
```

**Opdracht:**

1. Welke variabelen zijn `private`, welke `protected`?
2. Welke methode wordt door `FlyingEnemy` overschreven (override)?
3. Kan `FlyingEnemy` bij `health`? Waarom wel/niet?
4. Kan `FlyingEnemy` bij `damage`? Waarom wel/niet?
5. Schrijf de C#-code voor beide klassen op basis van dit diagram.

---

## Oefening 19b — Zelf een class diagram maken

Je hebt de volgende klassen in een game:

| Klasse                         | Variabelen                                    | Methoden                            |
| ------------------------------ | --------------------------------------------- | ----------------------------------- |
| `Weapon`                       | name (string), damage (int), fireRate (float) | Shoot(), Reload()                   |
| `MeleeWeapon` erft van Weapon  | range (float)                                 | Swing()                             |
| `RangedWeapon` erft van Weapon | ammo (int), maxAmmo (int)                     | Shoot() override, Reload() override |

**Opdracht:**

1. Teken een class diagram (op papier of digitaal) met de juiste:
   - Access modifiers (`+`, `-`, `#`)
   - Overerving-pijlen
   - Variabelen en methoden per klasse
2. Kies zelf welke variabelen `private`, `protected` of `public` moeten zijn — motiveer je keuze.
3. **Bonus:** Implementeer de drie klassen in C# en test ze in Unity.
