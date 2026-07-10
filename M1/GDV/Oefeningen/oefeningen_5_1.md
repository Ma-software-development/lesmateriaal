# Oefeningen Les 5.1: If-Statements en Switch Gebruiken

Kies of je start met oefening A of B. Maak beide af voor volgende week.  
Het is verstandig om daarna ook oefening C te doen — die kun je pas maken als A en B klaar zijn.  

Reflectievragen horen bij elke opdracht en moeten in je README worden beantwoord.  
Succes!

## Inleveren werk

De oefeningen moeten jullie inleveren via een README.md file op Github.

Voor alle oefeningen geldt dat je een titel met de opdracht plaatst, een korte omschrijving van wat je hebt gedaan, een gifje met daarin je werk goed in beeld gebracht en een link naar de code die bij de opdracht hoort.

[gebruik dit als template](../README.md#voorbeeld-readme-opdracht-format)

---

## Oefening 5.1A: Health Status Indicator

### Doel

Oefen met if, else if en else door een health status systeem te maken.

### Wat ga je doen?

Je maakt een script dat de gezondheid van een speler controleert en verschillende berichten toont afhankelijk van de waarde.

### Stappen

1. **Maak een nieuwe scene** genaamd "HealthStatus"
2. **Maak een script** `HealthStatus.cs` met een variabele `int health`
3. **Gebruik if, else if en else** om verschillende statusberichten te tonen in de console:
   - health > 80: "Excellent health!"
   - health > 50: "Good health!"
   - health > 20: "Warning: Low health!"
   - anders: "Critical: Very low health!"
4. **Laat health afnemen** met een toets (bijvoorbeeld H) en verhogen met een andere toets (bijvoorbeeld J)
5. **Test het systeem** door health te veranderen en de juiste berichten te tonen

#### Voorbeeld Console Output

```
Excellent health!
Warning: Low health!
Critical: Very low health!
```

### Reflectievragen

- Waarom past hier een if-structuur goed?  
- Wanneer zou een switch beter werken?

### Bonus Uitdagingen

- Voeg een visueel effect toe bij elke status (kleur veranderen)
- Toon een "Game Over" bericht als health 0 is
- Voeg een heal item toe dat health herstelt

---

## Oefening 5.1B: Weapon Switch System

### Doel

Oefen met switch-statements door een wapenwissel systeem te maken.

### Wat ga je doen?

Je maakt een script waarin je tussen verschillende wapens kunt wisselen en bij elk wapen andere stats toont.

### Stappen

1. **Maak een nieuwe scene** genaamd "WeaponSwitch"
2. **Maak een script** `WeaponSwitch.cs` met een variabele `string currentWeapon`
3. **Gebruik een switch-statement** om damage en attack speed te bepalen:
   - "Sword": damage 25, speed 1.0
   - "Bow": damage 20, speed 1.5
   - "Staff": damage 35, speed 0.7
   - "Dagger": damage 15, speed 2.0
   - default: damage 10, speed 1.0
4. **Wissel van wapen** met toetsen (1-4) en toon de stats in de console
5. **Test het systeem** door te wisselen en te zien dat de stats veranderen

#### Voorbeeld Console Output

```
Equipped: Sword
Damage: 25, Speed: 1
Equipped: Bow
Damage: 20, Speed: 1.5
```

### Reflectievragen

- Waarom past hier een switch-statement beter dan een if-structuur?  
- Wat zou er gebeuren als je dit met if/else zou doen?

- 
### Bonus Uitdagingen

- Voeg een "Unarmed" optie toe als default
- Toon een korte beschrijving bij elk wapen
- Voeg een visueel model wissel toe bij wapen switch

---

## Oefening 5.1C: Verdieping – Weapon Switch met Enum

### Doel

Leer hoe je vaste keuzes typeveilig en overzichtelijk maakt met een enum.

### Wat ga je doen?

Je breidt de vorige opdracht uit en vervangt de string door een enum voor de wapentypes.

### Stappen

1. **Kopieer** je bestaande script `WeaponSwitch.cs` en noem het `WeaponSwitchEnum.cs`.  
2. **Verwijder** de stringvariabele en **voeg een enum toe** bovenaan in je script:  
   ```csharp
   public enum WeaponType { Sword, Bow, Staff, Dagger }
   ```
Maak een variabele aan:
  ```csharp
   public WeaponType selectedWeapon = WeaponType.Sword;
```
Gebruik toetsen R, T, Y, U om te wisselen tussen wapens.

Gebruik een switch om feedback te tonen via Debug.Log() of TextMeshPro.

Roep SelectWeapon(selectedWeapon) alleen aan binnen de juiste toetsblokken.

Voorbeeld Console Output
  ```csharp
   You selected the sword: strong and close range.
   You selected the bow: long range and fast.
   You selected the magic staff: powerful but uses mana.
   You selected the hammer: heavy, slow, but deals massive damage.
```
### Reflectievragen
- Wat is het verschil tussen het gebruik van een string en een enum?
- Waarom zou een professionele developer een enum gebruiken?
  
Bonus Uitdagingen
- Laat de enum zichtbaar zijn in de Unity Inspector (dropdown)
- Voeg een nieuw wapen toe aan de enum, bijvoorbeeld Axe
- Combineer enum met een if: toon extra info als het wapen Staff is én health > 50


