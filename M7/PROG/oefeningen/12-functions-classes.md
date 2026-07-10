# Oefening: Functions, Classes & OOP Basics

## Leerdoel

Functies schrijven, eigen classes maken en basisprincipes van OOP toepassen.

---

## Oefening 1: Utility Functions

Maak een class met herbruikbare functies:

```csharp
public class MathHelper
{
    // TODO: Maak een static functie Clamp(float value, float min, float max)
    // die een waarde beperkt tussen min en max

    // TODO: Maak een static functie IsInRange(Vector3 a, Vector3 b, float range)
    // die true returnt als de afstand tussen a en b kleiner is dan range
}
```

Test ze in een ander script:

```csharp
void Start()
{
    float result = MathHelper.Clamp(15f, 0f, 10f);
    Debug.Log(result); // Verwacht: 10

    bool close = MathHelper.IsInRange(Vector3.zero, new Vector3(3, 0, 0), 5f);
    Debug.Log(close); // Verwacht: True
}
```

---

## Oefening 2: Eigen Class — Weapon

Maak een `Weapon` class:

```csharp
[System.Serializable]
public class Weapon
{
    public string name;
    public int damage;
    public float fireRate;

    public Weapon(string name, int damage, float fireRate)
    {
        this.name = name;
        this.damage = damage;
        this.fireRate = fireRate;
    }

    public void PrintInfo()
    {
        // TODO: Print naam, damage en fireRate
    }
}
```

Gebruik het in een MonoBehaviour:

```csharp
public class WeaponTest : MonoBehaviour
{
    void Start()
    {
        Weapon pistol = new Weapon("Pistol", 10, 0.5f);
        Weapon shotgun = new Weapon("Shotgun", 30, 1.2f);

        // TODO: Print info van beide wapens
        // TODO: Vergelijk welke meer damage doet
    }
}
```
