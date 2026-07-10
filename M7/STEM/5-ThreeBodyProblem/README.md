# 🌌 Wat is het Three-Body Problem?

## 📖 Definitie

Het **Three-Body Problem** (drie-lichamenprobleem) is een klassiek vraagstuk uit de **hemelmechanica**. Het beschrijft de beweging van drie objecten die elkaar onderling aantrekken door zwaartekracht, volgens de wetten van Newton.

Het probleem is eenvoudig te formuleren, maar extreem moeilijk (en soms onmogelijk) exact op te lossen.

## 🔍 Probleemstelling

> Gegeven de beginposities en snelheden van drie lichamen in de ruimte, wat zijn hun toekomstige posities en bewegingen?

De lichamen beïnvloeden elkaar onderling door zwaartekracht, en de krachten veranderen voortdurend afhankelijk van hun posities.

## 🧮 Waarom is het zo moeilijk?

- Voor twee lichamen (zoals zon en aarde) bestaat er een **exacte wiskundige oplossing**: ellips-, cirkel-, parabool- of hyperboolbanen.
- Voor **drie lichamen** bestaan in het algemeen **geen exacte oplossingen**. Het systeem is **chaotisch**, wat betekent:
  - Kleine verschillen in beginwaarden leiden tot grote verschillen op lange termijn.
  - De bewegingen kunnen **complex, onvoorspelbaar** en zelfs **periodiek of quasi-periodiek** zijn.

## 🌠 Belang en toepassingen

Het Three-Body Problem speelt een rol in onder andere:
- Ruimtevaart en satellietbanen
- Planeetvorming en sterrensystemen
- Dynamische systemen en chaos-theorie

## 📈 Oplossingen en benaderingen

Omdat er geen algemene analytische oplossing bestaat, worden meestal **numerieke methoden** gebruikt:
- Stap-voor-stap berekeningen (integratie)
- Visualisaties met simulaties (zoals in Unity)
- Benaderingen met computers om gedrag over tijd te voorspellen

## 🎬 Voorbeeldsituatie

Stel je voor: drie sterren bewegen rond elkaar in de ruimte. Elk van hen trekt aan de andere twee. Op een bepaald moment kan één ster plots worden weggeslingerd, terwijl de andere twee in een dans achterblijven — of alle drie kunnen in een instabiele spiraal terechtkomen.


# 🧠 Opdracht: Visualiseer het Three-Body-Problem in Unity (zonder massa)

## 🎯 Doel
Maak een visuele simulatie van het Three-Body-Problem in Unity, waarbij je de massa van de lichamen buiten beschouwing laat. De focus ligt op de baanbeweging en interactie tussen drie objecten die elkaar onderling beïnvloeden door een versimpelde zwaartekrachtformule.

## 📌 Specificaties

- Gebruik Unity (versie 2020.3 of hoger aanbevolen).
- Simuleer drie hemellichamen (sferen) die op elkaar reageren volgens een aangepaste zwaartekrachtformule.
- **Laat massa buiten beschouwing:** alle lichamen worden als even zwaar beschouwd, of de massa wordt volledig genegeerd.
- Maak gebruik van Newton's gravitatiewet in vereenvoudigde vorm, bijvoorbeeld:

  ```csharp
  Vector3 force = G * (pos2 - pos1).normalized
  ```

- Visualiseer de banen van de drie lichamen met behulp van `LineRenderer` of een trail-effect.

## 📦 Benodigdheden

- 3D-objecten (sferen) als hemellichamen
- Script voor de zwaartekrachtinteractie
- Script voor het updaten van de posities over tijd
- LineRenderers of Trails om de banen te tonen

## 🚀 Bonus Uitdagingen

- Voeg een UI toe om de beginposities en snelheden aan te passen.
- Voeg een pauze/reset-functionaliteit toe.
- Sla het pad op als een afbeelding of data-export (JSON/CSV).
- Laat de simulatie versnellen of vertragen via een slider.

## ✅ Oplevercriteria

- De drie lichamen bewegen in een zichtbaar dynamisch systeem.
- De simulatie blijft stabiel gedurende langere tijd.
- Er is een visueel onderscheid tussen de drie objecten en hun banen.

## Voorbeeld

<img src="images/threebodyproblem.gif">