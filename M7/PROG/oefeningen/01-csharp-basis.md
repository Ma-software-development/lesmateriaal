# Oefening: C# Basis & Scripting

## Leerdoel

Variabelen, datatypes, Debug.Log en de basisstructuur van een Unity-script begrijpen.

---

## Oefening 1: Variabelen & Debug.Log

Maak een script `IntroScript.cs` dat:

1. Een `string` variabele `playerName` aanmaakt met je naam
2. Een `int` variabele `score` op 0 zet
3. Een `float` variabele `speed` op 3.5f zet
4. Een `bool` variabele `isAlive` op true zet
5. Alles print in de console bij `Start()`

```csharp
public class IntroScript : MonoBehaviour
{
    // TODO: Declareer de 4 variabelen hierboven

    void Start()
    {
        // TODO: Print elke variabele met Debug.Log
        // Voorbeeld: Debug.Log("Naam: " + playerName);
    }
}
```

**Verwacht resultaat:** 4 regels in de console met de waarden.

---

## Oefening 2: Rekenen met variabelen

Maak een script `Calculator.cs` dat:

1. Twee `int` variabelen `a` en `b` aanmaakt
2. In `Start()` de som, het verschil, het product en het quotiënt print

```csharp
public class Calculator : MonoBehaviour
{
    public int a = 12;
    public int b = 4;

    void Start()
    {
        // TODO: Bereken en print:
        // a + b
        // a - b
        // a * b
        // a / b
    }
}
```

**Bonus:** Maak `a` en `b` public zodat je ze in de Inspector kunt aanpassen en opnieuw kunt testen.
