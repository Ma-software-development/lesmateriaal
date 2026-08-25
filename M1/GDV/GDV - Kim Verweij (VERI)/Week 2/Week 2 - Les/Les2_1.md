# Les 2.1: Bewegen met code

Vandaag gaan we voor het eerst iets laten bewegen met code.

Geen paniek: je hoeft nog niet alles van C# te snappen. We beginnen klein. Je zet een script op een GameObject en laat dat object draaien of bewegen.

Vorige les heb je GameObjects gemaakt en aangepast in Unity. Nu gaan we dat niet meer alleen met de hand doen, maar met een script.

---

## Wat leer je in deze les?

Na deze les kun je:

- een script maken
- een script op een GameObject zetten
- uitleggen wat `Start()` en `Update()` ongeveer doen
- een object laten draaien of bewegen
- `Time.deltaTime` gebruiken
- een snelheid aanpassen in de Inspector

---

## Wat is een script?

Een script is een stukje code dat gedrag geeft aan een GameObject.

Bijvoorbeeld:

- een muntje dat draait
- een vijand die heen en weer beweegt
- een platform dat op en neer beweegt

Een script zet je op een GameObject als component.

---

## Start en Update

In Unity gebruik je vaak `Start()` en `Update()`.

```csharp
void Start()
{
    // Gebeurt 1 keer aan het begin
}

void Update()
{
    // Gebeurt elk frame opnieuw
}
```

Gebruik `Start()` voor dingen die 1 keer gebeuren.

Gebruik `Update()` voor dingen die blijven gebeuren, zoals bewegen of draaien.

---

## Transform

Elk GameObject heeft een `Transform`.

Met de Transform bepaal je:

- `position`: waar het object staat
- `rotation`: hoe het object gedraaid is
- `scale`: hoe groot of klein het object is

In code kun je de Transform aanpassen met bijvoorbeeld:

```csharp
transform.position
transform.Rotate()
transform.Translate()
```

---

## Object laten draaien

Met `transform.Rotate()` kun je een object laten draaien.

```csharp
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 90f;

    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
```

Zet dit script op een GameObject en druk op Play.

Als alles goed staat, draait je object vanzelf.

`rotateSpeed` kun je aanpassen in de Inspector. Probeer eens een lage en een hoge waarde.

---

## Object laten bewegen

Met `transform.position` kun je de positie van een object aanpassen.

```csharp
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
```

Dit object beweegt naar rechts.

Andere richtingen zijn bijvoorbeeld:

```csharp
Vector3.left
Vector3.up
Vector3.down
Vector3.forward
Vector3.back
```

Je hoeft ze nog niet allemaal uit je hoofd te kennen. Het is vooral handig om te weten dat Unity vaste richtingen heeft die je kunt gebruiken.

---

## Waarom gebruik je Time.deltaTime?

`Update()` draait heel vaak per seconde.

Op een snelle computer gebeurt dat vaker dan op een langzame computer. Zonder `Time.deltaTime` kan je object dus op elke computer anders bewegen.

Daarom gebruiken we:

```csharp
speed * Time.deltaTime
```

Dan beweegt je object per seconde in plaats van per frame.

Kort gezegd: gebruik `Time.deltaTime` bij beweging in `Update()`.

---

## Public variabele

Als je een variabele `public` maakt, kun je deze aanpassen in de Inspector.

```csharp
public float speed = 3f;
```

Dat is handig, want dan hoef je niet steeds je code te veranderen.

Je past de waarde gewoon aan in Unity en drukt opnieuw op Play.

---

## Veelgemaakte fouten

### Mijn script doet niets

Check even:

- staat het script op het juiste GameObject?
- heb je op Play gedrukt?
- staat er een foutmelding in de Console?
- heeft je script dezelfde naam als je class?

Bijvoorbeeld:

```csharp
public class RotateObject : MonoBehaviour
```

Dan moet je bestand ook `RotateObject.cs` heten.

Mijn object verdwijnt uit beeld
Selecteer het object in de Hierarchy en druk op **F**.

Ik zie mijn public variabele niet in de Inspector
Sla je script op en ga terug naar Unity.
Check ook of je variabele echt `public` is.

---

## Oefening

Ga nu naar de oefeningen van les 2.1:

[Oefeningen Les 2.1](../Week%202%20-%20Oefeningen/oefeningen_2_1.md)

Je gaat eerst een draaiend object maken. Daarna kun je een object heen en weer laten bewegen of in een cirkel laten bewegen.

---

## Checklist

- [ ] Ik heb een script gemaakt
- [ ] Ik heb een script op een GameObject gezet
- [ ] Ik weet ongeveer wat `Start()` doet
- [ ] Ik weet ongeveer wat `Update()` doet
- [ ] Ik heb een object laten bewegen of draaien
- [ ] Ik heb `Time.deltaTime` gebruikt
- [ ] Ik heb een snelheid aangepast in de Inspector
