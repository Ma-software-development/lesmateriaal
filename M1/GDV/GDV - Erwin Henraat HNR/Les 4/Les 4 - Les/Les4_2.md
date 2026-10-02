# Les 4.2: Functies Herhalen, If-Else en Switch

## Wat Ga Je Leren?

In deze les herhaal je eerst wat je in Les 3.2 over functies hebt geleerd. Daarna breid je je kennis van het `if` statement (Les 2.2) uit. Je gaat:

- De belangrijkste kennis over functies (Les 3.2) herhalen en toepassen
- `else` gebruiken om een alternatief uit te voeren als een voorwaarde niet klopt
- `else if` gebruiken om tussen meerdere keuzes te kiezen
- De `switch` statement leren gebruiken als alternatief voor lange `else if` ketens
- Zelf bepalen wanneer je `if-else` of `switch` het beste kunt gebruiken

---

## Aantekeningen maken

Maak aantekeningen over de behandelde stof in de les. Schrijf het nu zo op zodat je het later makkelijk begrijpt als je het terugleest.

**Belangrijke punten om te noteren:**

- Wat is het verschil tussen een functie met `void` en een functie met een return type?
- Wat is het verschil tussen `if`, `else if` en `else`?
- In welke volgorde worden `else if` voorwaarden gecontroleerd?
- Hoe werkt een `switch` statement en waarvoor dient het keyword `break`?
- Wanneer kies je voor `if-else` en wanneer voor `switch`?

Schrijf ook op wat je niet hebt begrepen uit deze les. Dan kun je hier later nog vragen over stellen aan de docent.

Bewaar al je aantekeningen goed! Deze moet je aan het einde van de periode inleveren.

![notes](https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExeHhzdzZzbHQzYWgyNG1mZDRhdW05dWIwMDI2b2xoNWtkMWN0ODl2dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/3o7GUB9ExWUxjiSrKw/giphy.gif)

---

## Herhaling: Functies uit Les 3.2

Voordat we verder gaan, even kort terug naar Les 3.2. Weet je nog wat een functie is?

Een functie is een **machine**: je stopt er eventueel iets in (argumenten), de machine doet zijn werk, en je krijgt er eventueel iets uit (return value).

```csharp
public class Herhaling : MonoBehaviour
{
    void Start()
    {
        // Aanroep met een argument
        ShowWelcomeMessage("Erwin");

        // Aanroep die iets teruggeeft (return)
        int leeftijd = GetPlayerAge(26, 11, 1979);
        Debug.Log("Leeftijd: " + leeftijd);
    }

    // void functie: doet iets, geeft niets terug
    void ShowWelcomeMessage(string name)
    {
        Debug.Log("Welkom " + name + "!");
    }

    // int functie: geeft een int terug met "return"
    int GetPlayerAge(int day, int month, int year)
    {
        System.DateTime today = System.DateTime.Today;
        int age = today.Year - year;
        return age;
    }
}
```

<details>

<summary>Zelftest: herken de onderdelen</summary>

Bekijk de code hierboven en beantwoord voor jezelf:

- Welke regel is de **functie-definitie** en welke is de **aanroep**?
- Welke woorden zijn de **parameters** en welke waarden zijn de **argumenten**?
- Welke functie heeft een **return type** en welke is `void`?
- Waarom kan `leeftijd` de waarde van `GetPlayerAge()` opslaan, maar zou dat niet werken bij `ShowWelcomeMessage()`?

Niet zeker van je antwoord? Vraag het na bij de docent of een klasgenoot!

</details>

---

## Van Eén If naar If-Else

### Het Probleem met Alleen If

In Les 2.2 heb je het `if` statement geleerd:

```csharp
int leven = 0;

if (leven > 0)
{
    Debug.Log("Speler leeft nog!");
}
```

Maar wat als je ook iets wilt doen wanneer de voorwaarde **niet** klopt? Je zou een tweede, losse `if` kunnen schrijven:

```csharp
if (leven > 0)
{
    Debug.Log("Speler leeft nog!");
}
if (leven <= 0)
{
    Debug.Log("Game Over!");
}
```

Dit werkt, maar Unity moet nu **twee** voorwaarden controleren, terwijl er maar één antwoord mogelijk is. Dat kan korter en duidelijker met `else`.

### De Else - "Anders"

```csharp
if (voorwaarde)
{
    // Doe dit als de voorwaarde waar is
}
else
{
    // Doe dit als de voorwaarde NIET waar is
}
```

**Vergelijking:** "Als het regent, neem een paraplu mee. **Anders** neem je een zonnebril mee."

```csharp
int leven = 0;

if (leven > 0)
{
    Debug.Log("Speler leeft nog!");
}
else
{
    Debug.Log("Game Over!");
}
```

**Belangrijk:** Er wordt altijd precies **één** van de twee blokken uitgevoerd, nooit allebei en nooit geen enkele.

---

## Else If - Kiezen Uit Meerdere Opties

Soms zijn er meer dan twee mogelijke uitkomsten. Dan gebruik je `else if` om extra voorwaarden toe te voegen.

```csharp
if (voorwaarde1)
{
    // Doe dit als voorwaarde1 waar is
}
else if (voorwaarde2)
{
    // Doe dit als voorwaarde1 niet waar was, maar voorwaarde2 wel
}
else if (voorwaarde3)
{
    // Doe dit als voorwaarde1 en voorwaarde2 niet waar waren, maar voorwaarde3 wel
}
else
{
    // Doe dit als geen van bovenstaande voorwaarden waar was
}
```

### Voorbeeld: Speler Status

```csharp
public class PlayerStatus : MonoBehaviour
{
    public int playerHealth = 60;

    void Start()
    {
        string status = GetPlayerStatus(playerHealth); // Herhaling Les 3.2: argument + return
        Debug.Log("Status: " + status);
    }

    string GetPlayerStatus(int health)
    {
        if (health > 75)
        {
            return "Excellent";
        }
        else if (health > 50)
        {
            return "Good";
        }
        else if (health > 25)
        {
            return "Warning";
        }
        else
        {
            return "Critical";
        }
    }
}
```

**Let op de volgorde!** Unity controleert de voorwaarden **van boven naar beneden** en stopt zodra er één klopt. Bij `health = 60` wordt `health > 75` gecontroleerd (niet waar), dan `health > 50` (wel waar!) → `"Good"` wordt teruggegeven. De rest wordt overgeslagen.

<details>

<summary>Denkvraag: wat gaat er mis?</summary>

```csharp
if (health > 25)
{
    return "Warning";
}
else if (health > 75)
{
    return "Excellent";
}
```

Wat gebeurt hier bij `health = 90`? Waarom komt deze code nooit bij `"Excellent"` uit?

De voorwaarde `health > 25` is bij `90` ook al waar, dus stopt de keten daar meteen. De volgorde van je voorwaarden is dus heel belangrijk: begin met de meest specifieke/strengste voorwaarde!

</details>

---

## De Switch Statement

### Waarom een Switch?

Wanneer je heel veel `else if`'s achter elkaar krijgt die allemaal **dezelfde variabele** vergelijken met een **vaste waarde**, wordt de code al snel onoverzichtelijk:

```csharp
if (wapen == "Zwaard")
{
    Debug.Log("Slaan met het zwaard!");
}
else if (wapen == "Boog")
{
    Debug.Log("Schieten met de boog!");
}
else if (wapen == "Staf")
{
    Debug.Log("Toveren met de staf!");
}
else
{
    Debug.Log("Onbekend wapen!");
}
```

Dit kan overzichtelijker met een `switch` statement:

```csharp
switch (wapen)
{
    case "Zwaard":
        Debug.Log("Slaan met het zwaard!");
        break;
    case "Boog":
        Debug.Log("Schieten met de boog!");
        break;
    case "Staf":
        Debug.Log("Toveren met de staf!");
        break;
    default:
        Debug.Log("Onbekend wapen!");
        break;
}
```

### Syntax Uitgelegd

- `switch (wapen)` → de variabele die je wilt vergelijken
- `case "Zwaard":` → als `wapen` gelijk is aan `"Zwaard"`, voer dan deze code uit
- `break;` → **verplicht!** stopt de switch, zodat de volgende `case` niet ook nog wordt uitgevoerd
- `default:` → wordt uitgevoerd als geen enkele `case` matcht (vergelijkbaar met `else`)

**Let op:** vergeet je `break;`, dan geeft Unity een compile error. Elke `case` moet eindigen met `break` (of `return`).

### Switch met Meerdere Datatypes

```csharp
public class SwitchExamples : MonoBehaviour
{
    void Start()
    {
        ShowEnemyBehaviour(2);
    }

    void ShowEnemyBehaviour(int enemyType)
    {
        switch (enemyType)
        {
            case 0:
                Debug.Log("Enemy type: Goblin - aanvallen!");
                break;
            case 1:
                Debug.Log("Enemy type: Skeleton - vluchten!");
                break;
            case 2:
                Debug.Log("Enemy type: Dragon - verstoppen!");
                break;
            default:
                Debug.Log("Onbekend enemy type!");
                break;
        }
    }
}
```

### Wanneer If-Else, Wanneer Switch?

**Gebruik If-Else voor:**

- Vergelijkingen met `>`, `<`, `>=`, `<=` (bereiken/ranges)
- Voorwaarden met `bool` waarden
- Combinaties van meerdere verschillende voorwaarden

**Gebruik Switch voor:**

- Eén variabele vergelijken met veel **vaste** waarden (`int`, `string`, `enum`)
- Als je merkt dat je een lange `else if` keten schrijft die steeds dezelfde variabele checkt op gelijkheid (`==`)

---

## Energizer: "Menselijke Switch" (10 min)

Eén student is de **switch** en gaat vooraan staan. De rest van de klas krijgt om de beurt een briefje met een waarde (bijv. `"Zwaard"`, `"Boog"`, `"Staf"`, of iets onbekends zoals `"Vork"`).

- De student met het briefje loopt naar voren en roept zijn/haar waarde
- De **switch**-student doorloopt hardop zijn "cases": _"Is het Zwaard? Nee. Is het Boog? Nee. Is het Staf? Ja! → doe de bijbehorende actie (bijv. een tover-gebaar maken)"_
- Bij een onbekende waarde voert de switch-student de `default` actie uit (bijv. schouders ophalen)
- Wissel na elke ronde van switch-student

> 💡 Vraag de klas: had dit ook met `if-else` gekund? Wat is er anders?

---

## Praktisch Voorbeeld: Alles Samen

```csharp
public class ShopSystem : MonoBehaviour
{
    public int playerGold = 120;

    void Start()
    {
        TryBuyItem("Potion", 30);
        TryBuyItem("Sword", 200);

        string rank = GetShopRank(playerGold); // Les 3.2: functie met return
        Debug.Log("Winkel rang: " + rank);
    }

    // Functie (Les 3.2) met if-else
    void TryBuyItem(string itemName, int price)
    {
        if (playerGold >= price)
        {
            playerGold -= price;
            Debug.Log(itemName + " gekocht! Resterend goud: " + playerGold);
        }
        else
        {
            Debug.Log("Niet genoeg goud voor " + itemName + "!");
        }
    }

    // Functie (Les 3.2) met else if keten
    string GetShopRank(int gold)
    {
        if (gold >= 500)
        {
            return "VIP";
        }
        else if (gold >= 100)
        {
            return "Trouwe klant";
        }
        else
        {
            return "Nieuwe klant";
        }
    }

    // Functie (Les 3.2) met switch
    void ShowItemDescription(string itemName)
    {
        switch (itemName)
        {
            case "Potion":
                Debug.Log("Geneest 20 HP.");
                break;
            case "Sword":
                Debug.Log("Een scherp zwaard, +10 aanval.");
                break;
            default:
                Debug.Log("Geen beschrijving beschikbaar.");
                break;
        }
    }
}
```

---

## Veelgestelde Vragen

### Q: Moet ik altijd een `else` toevoegen bij een `if`?

**A:** Nee, `else` is optioneel. Gebruik het alleen als je ook echt iets wilt doen wanneer de voorwaarde niet klopt.

### Q: Kan ik oneindig veel `else if` toevoegen?

**A:** Technisch wel, maar bij veel keuzes uit dezelfde variabele is een `switch` vaak overzichtelijker.

### Q: Wat gebeurt er als ik `break` vergeet in een switch case?

**A:** Unity (C#) geeft een compile error. In tegenstelling tot sommige andere talen "vallen" cases in C# niet automatisch door naar de volgende.

### Q: Kan een switch ook op basis van een `bool` werken?

**A:** Technisch kan het, maar met maar 2 mogelijke waarden (`true`/`false`) is een gewone `if-else` duidelijker.

### Q: Wat is het verschil tussen `default` in switch en `else` bij if?

**A:** Ze doen hetzelfde: beide worden uitgevoerd als geen van de andere gevallen matcht.

---

## Wat Heb Je Geleerd?

### Checklist

- [ ] Je kunt uitleggen wat een functie, parameter, argument en return type is (Les 3.2)
- [ ] Je begrijpt wanneer je `else` gebruikt
- [ ] Je kunt een `else if` keten schrijven en weet dat de volgorde belangrijk is
- [ ] Je kunt een `switch` statement schrijven met `case`, `break` en `default`
- [ ] Je weet wanneer je `if-else` of `switch` het beste kunt gebruiken
- [ ] Je kunt functies combineren met `if-else` en `switch`

### Volgende Stap

In de volgende les ga je deze kennis over `if-else` en `switch` combineren met colliders, triggers en input om slimmere game-logica te bouwen.

---
