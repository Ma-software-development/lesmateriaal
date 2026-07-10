# 🎓 Unity Les: Vectors, Snelheid en Richting – Een Stuiterende Bal Maken

## 🧑‍🏫 Doel:
Leer hoe je **vectors**, **snelheid** en **richting** gebruikt in Unity door een script te bouwen dat een bal laat stuiteren op het scherm.

---

## 🗂️ Deel 0: Setup

Voordat je begint met coderen:
1. Open Unity en maak een nieuw **2D-project** aan.
2. Klik rechts in de Hierarchy → **2D Object → Sprite → Circle**. Hernoem dit naar **Ball**.
3. Maak een nieuw script aan met de naam `Ball.cs` en koppel het aan de `Ball` GameObject.

---

## ✏️ Deel 1: Variabelen Declareren

**Doel:** Begrijpen wat richting, snelheid en schermgrenzen zijn.

In plaats van met getallen gaan we met Vectoren werken. Een vector is een wiskundig object met zowel grootte als een richting. 

Zo is het bij de vector snelheid (**velocity**) gebruikelijk om deze vector te splitsen in een richting (**direction**) en een grootte (in het geval van snelheid **speed**) 

### 🧠 Opdracht:
Declareer de volgende variabelen bovenaan in je script:

```csharp
Vector3 direction = new Vector3(1, 2, 0);
float speed = 3;

Vector3 velocity;

```

💬 *Wat betekenen deze variabelen? Waarom gebruiken we `Vector3` in plaats van `Vector2`?*

---

## ✏️ Deel 2: Richting en Schermgrenzen Instellen

**Doel:** Converteer schermcoördinaten naar wereldcoördinaten en normaliseer de richting.

### 🧠 Opdracht:
Voeg dit toe aan de `Start()` methode:

```csharp
void Start()
{
    // Normaliseer de richtingsvector
    direction = direction.normalized;
}
```

💬 *Wat gebeurt er als we de richtingsvector niet normaliseren?*

---

## ✏️ Deel 3: Beweeg de Bal

**Doel:** Pas snelheid toe op basis van tijd voor vloeiende beweging.

### 🧠 Opdracht:
In de `Update()` methode, voeg dit toe:

```csharp
void Update()
{
    // Bereken snelheid
    velocity = direction * speed * Time.deltaTime;

    // Verplaats de bal
    transform.position += velocity;
}
```

💡 `Time.deltaTime` zorgt voor vloeiende beweging, ongeacht de framerate.

---


## ✏️ Deel 4: Laat de Bal Stuiteren Tegen de Randen

**Doel:** Detecteer botsingen met schermranden en keer de richting om.

We willen de Ball binnen de grenzen van ons scherm houden. Daarvoor definieren wij bovenaan in het script waar wij de variabelen declareren twee nieuwe Vector2 variabelen, min en max. Deze gaan 

Stel eerst de schermranden vast. Dit is het beste te doen met behulp van twee Vector2 variabelen min en max die boven bij de declaratie van de variabelen worden toegevoegd. 

````csharp
Vector2 min, max;
````
Deze grenzen kunnen pas worden vastgesteld als de applicatie is begonnen. Daarom kunnen deze variabelen pas worden gevuld in de start.

void Start()
{
    // Converteer schermhoeken naar wereldcoördinaten
    min = Camera.main.ScreenToWorldPoint(Vector2.zero);
    max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
}
```


### 🧠 Opdracht:
Voeg deze controles toe **in** de `Update()` methode:

```csharp
if (transform.position.x + transform.localScale.x / 2 > max.x)
{
    direction.x = -direction.x;
}
if (transform.position.x - transform.localScale.x / 2 < min.x)
{
    direction.x = -direction.x;
}
if (transform.position.y + transform.localScale.y / 2 > max.y)
{
    direction.y = -direction.y;
}
if (transform.position.y - transform.localScale.y / 2 < min.y)
{
    direction.y = -direction.y;
}
```

💬 *Waarom gebruiken we `transform.localScale / 2`?*

---

## 🎯 Extra Uitdagingen

- Voeg een `TrailRenderer` toe voor een visueel spoor.
- Speel een geluid af bij botsing.
- Verander richting willekeurig bij elke stuiter.
- Laat de snelheid geleidelijk toenemen.

---

Veel succes met coderen! 🎉
