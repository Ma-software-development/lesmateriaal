# Oefeningen Les 5.1: Keuzes maken met code

Vandaag ga je oefenen met `if`, `else if`, `else` en `switch`.

Kies of je start met **Oefening 5.1A** of **Oefening 5.1B**.  
Maak ze allebei af voor volgende week.

Heb je A en B af? Dan kun je verder met **Oefening 5.1C**.

---

## Inleveren

Lever je opdracht in via Simulise:

[Lever hier in op Simulise](https://ma.simulise.com/school/assignment/ff9eee03-5b14-4b1b-bd74-16d84222cc62/view)

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat
- een korte uitleg van wat je hebt gemaakt
- welke keuzes je code maakt
- waar je `if` hebt gebruikt
- waar je `switch` hebt gebruikt
- wat goed lukte
- wat je lastig vond

---

## Oefening 5.1A: Health Status Indicator

### Doel

Je oefent met `if`, `else if` en `else`.

### Wat ga je doen?

Je maakt een health-systeem dat verschillende berichten toont bij verschillende health-waardes.

### Stappen

1. Maak een nieuwe scene met de naam `HealthStatus`.
2. Maak een script met de naam `HealthStatus`.
3. Maak een variabele `int health`.
4. Gebruik `if`, `else if` en `else` voor deze statussen:

| Health | Bericht |
| --- | --- |
| hoger dan 80 | Excellent health |
| hoger dan 50 | Good health |
| hoger dan 20 | Warning: Low health |
| 20 of lager | Critical: Very low health |

5. Laat `health` lager worden met een toets, bijvoorbeeld **H**.
6. Laat `health` hoger worden met een toets, bijvoorbeeld **J**.
7. Test of de juiste berichten in de Console verschijnen.

### Reflectievragen

- Waarom past hier een `if` goed?
- Wanneer zou een `switch` beter werken?

### Bonus

- Toon `Game Over` als health `0` is.
- Verander de kleur van je speler per health-status.
- Voeg een heal item toe dat health teruggeeft.

---

## Oefening 5.1B: Weapon Switch System

### Doel

Je oefent met een `switch`.

### Wat ga je doen?

Je maakt een systeem waarmee je tussen wapens wisselt.

Elk wapen krijgt andere stats.

### Stappen

1. Maak een nieuwe scene met de naam `WeaponSwitch`.
2. Maak een script met de naam `WeaponSwitch`.
3. Maak een variabele `string currentWeapon`.
4. Gebruik een `switch` voor deze wapens:

| Weapon | Damage | Speed |
| --- | --- | --- |
| Sword | 25 | 1.0 |
| Bow | 20 | 1.5 |
| Staff | 35 | 0.7 |
| Dagger | 15 | 2.0 |
| Default | 10 | 1.0 |

5. Wissel van wapen met toetsen **1**, **2**, **3** en **4**.
6. Toon het gekozen wapen en de stats in de Console.

### Reflectievragen

- Waarom past hier een `switch` goed?
- Wat zou er gebeuren als je dit met veel `if`/`else` zou doen?

### Bonus

- Voeg een `Unarmed` optie toe.
- Toon per wapen een korte beschrijving.
- Laat een object van kleur veranderen bij elk wapen.

---

## Oefening 5.1C: Weapon Switch met enum

### Doel

Je leert hoe je vaste keuzes netter kunt opslaan met een `enum`.

### Wat ga je doen?

Je breidt je Weapon Switch uit.  
In plaats van een `string` gebruik je een `enum`.

### Stappen

1. Kopieer je script `WeaponSwitch`.
2. Noem het nieuwe script `WeaponSwitchEnum`.
3. Voeg bovenaan je script een enum toe:

```csharp
public enum WeaponType
{
    Sword,
    Bow,
    Staff,
    Dagger
}
```

4. Maak een variabele:

```csharp
public WeaponType selectedWeapon = WeaponType.Sword;
```

5. Gebruik een `switch` op `selectedWeapon`.
6. Toon per wapen een passend bericht in de Console.
7. Test of je de enum kunt aanpassen in de Inspector.

### Reflectievragen

- Wat is het verschil tussen een `string` en een `enum`?
- Waarom zou een developer een `enum` gebruiken?

### Bonus

- Voeg een nieuw wapen toe, bijvoorbeeld `Axe`.
- Combineer je enum met een `if`.
- Toon extra info als het wapen `Staff` is en health hoger is dan 50.

---

## Klaar?

Controleer je werk:

- [ ] Ik heb oefening A gemaakt
- [ ] Ik heb oefening B gemaakt
- [ ] Ik heb `if`, `else if` en `else` gebruikt
- [ ] Ik heb een `switch` gebruikt
- [ ] Mijn berichten verschijnen in de Console
- [ ] Ik heb mijn scene opgeslagen
- [ ] Ik heb een screenshot of gif gemaakt
- [ ] Ik heb mijn opdracht ingeleverd via [Simulise](https://ma.simulise.com/school/assignment/ff9eee03-5b14-4b1b-bd74-16d84222cc62/view)
