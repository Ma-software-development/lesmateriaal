# Oefening: GameObjects & Componenten

## Leerdoel

Werken met Transform, componenten opvragen via code en GameObjects manipuleren.

---

## Oefening 1: Transform Verkennen

Maak een script `TransformInfo.cs` dat in `Start()` de positie, rotatie en schaal van het GameObject print.

```csharp
public class TransformInfo : MonoBehaviour
{
    void Start()
    {
        // TODO: Print transform.position
        // TODO: Print transform.rotation.eulerAngles
        // TODO: Print transform.localScale
    }
}
```

Plaats het script op 3 verschillende GameObjects en vergelijk de output.

---

## Oefening 2: Component Ophalen

Maak een script `ColorChanger.cs` dat:

1. De `SpriteRenderer` ophaalt via `GetComponent<>()`
2. De kleur verandert naar rood bij `Start()`
3. De kleur verandert naar blauw als je op spatie drukt

```csharp
public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;

    void Start()
    {
        // TODO: Haal SpriteRenderer op
        // TODO: Zet kleur naar Color.red
    }

    void Update()
    {
        // TODO: Als spatie ingedrukt, verander naar Color.blue
    }
}
```

**Test:** Plaats op een sprite — rood bij start, blauw bij spatie.
