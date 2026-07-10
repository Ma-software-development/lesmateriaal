# Voorbeeld Enemy Behaviour Gym – Zoekende Peuter

# 1. Gedragsregels

State: Idle
- Vijand staat stil.
- Vijand wacht tot de speler de TriggerZone betreedt.

Trigger
- Speler betreedt TriggerZone - state: Counting.

State: Counting
- Vijand telt van 5 naar 1.
- Na 1: vijand draait om - state: Searching.

State: Searching
Prioriteit van checks:
1. Als speler zichtbaar is - state: Chasing.
2. Als speler niet zichtbaar is en er is geluid - beweeg richting GeluidPositie.
3. Als speler niet zichtbaar is en er is geen geluid - zoekgedrag (simpel patroon).

State: Chasing
- Vijand beweegt richting speler zolang speler zichtbaar is.
- Als speler niet meer zichtbaar is - terug naar Searching.

---

# 2. Detectie

Zicht (Line of Sight)
- Vijand heeft 360 graden zicht.
- Zicht wordt geblokkeerd door obstakels (raycast).
- Als zicht true is - speler is gevonden.

Geluid
- Speler loopt - produceert geluid.
- Speler sluipt - produceert geen geluid.
- Als geluid gedetecteerd wordt:
  - GeluidPositie = laatste positie van de speler.
  - Vijand beweegt naar GeluidPositie.

---

# 3. Zoekgedrag zonder zicht en zonder geluid
- Vijand kiest een zoekpunt binnen een radius (bijv. 5 meter).
- Vijand beweegt naar dat punt.
- Na aankomst: opnieuw zicht en geluid checken.

---

# 4. Flowchart (Mermaid)

```mermaid
flowchart LR

    A["State: Idle"] --> B{"Speler in TriggerZone?"}

    B -- Nee --> A
    B -- Ja --> C["State: Counting (5 → 1)"]

    C --> D["Draai om"]
    D --> E["State: Searching"]

    E --> F{"Kan speler zien?"}

    F -- Ja --> G["State: Chasing"]
    G --> H["Beweeg naar speler"]
    H --> F

    F -- Nee --> I{"Hoort geluid?"}

    I -- Ja --> J["Set Target = GeluidPositie"]
    J --> K["Beweeg naar Target"]
    K --> F

    I -- Nee --> L["Zoekgedrag (zoekpunt binnen radius)"]
    L --> F
