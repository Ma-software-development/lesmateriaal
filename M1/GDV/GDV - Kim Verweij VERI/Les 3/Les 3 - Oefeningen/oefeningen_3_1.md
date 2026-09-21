# Oefening 3.1 – Stuiteren en botsingen

In deze oefening maak je een kleine scène waarin een bal stuitert. Daarna zorg je ervoor dat er iets gebeurt wanneer de bal ergens tegenaan botst.

---

## Opdracht 1 – Maak een ondergrond

1. Maak een nieuwe **Cube**.
2. Gebruik de **Scale Tool** om van de Cube een ondergrond te maken.
3. Geef de Cube een **Material** en kies zelf een kleur.

Je mag zelf bepalen hoe je omgeving eruitziet. Je kunt bijvoorbeeld meerdere Cubes gebruiken om verschillende ondergronden, verhogingen of muren te maken.

---

## Opdracht 2 – Maak een stuiterende bal

1. Maak een **Sphere** en plaats deze boven je ondergrond.
2. Voeg een **Rigidbody** toe aan de Sphere.
3. Maak een **Physics Material**.
4. Geef het Physics Material een hoge **Bounciness**.
5. Plaats het Physics Material op de Collider van de Sphere.

Test je spel. De bal moet op de ondergrond vallen en weer omhoog stuiteren.

---

## Uitleg – Een botsing detecteren

Met `OnCollisionEnter` kun je detecteren wanneer een object tegen een ander object botst.

De parameter `collision` bevat informatie over de botsing. Met `collision.gameObject` kun je achterhalen welk object is geraakt.

```csharp
void OnCollisionEnter(Collision collision)
{
    Debug.Log("De bal raakt: " + collision.gameObject.name);
}
```

`Debug.Log` laat een bericht zien in de **Console**. In dit geval verschijnt de naam van het object waar de bal tegenaan botst.

---

## Opdracht 3 – Detecteer een botsing

1. Maak een nieuw script voor de bal.
2. Plaats het script op de Sphere.
3. Voeg `OnCollisionEnter` toe aan je script.
4. Gebruik `Debug.Log` om in de Console te tonen welk object de bal raakt.
5. Test je spel en controleer de Console.

Kun je in de Console zien welk object de bal raakt? Dan heb je de basisopdracht behaald.

---

## Uitdaging – Laat de scène reageren

Zorg ervoor dat er zichtbaar iets gebeurt wanneer de bal ergens tegenaan botst.

Bedenk zelf wat er verandert. Je kunt bijvoorbeeld:

- de ondergrond van kleur laten veranderen;
- de bal van kleur laten veranderen;
- iedere Cube een andere kleur geven;
- bij iedere botsing een willekeurige kleur kiezen;
- een extra boodschap in de Console tonen.

---

## Uitleg – De kleur van een object veranderen

Om de kleur van een object te veranderen, heb je de `Renderer` van dat object nodig.

De Renderer zorgt ervoor dat een object zichtbaar wordt. Via de Renderer kun je ook het Material en de kleur van het object aanpassen.

Met `GetComponent<Renderer>()` vraag je de Renderer op van het object waar de bal tegenaan botst.

```csharp
void OnCollisionEnter(Collision collision)
{
    Renderer objectRenderer =
        collision.gameObject.GetComponent<Renderer>();

    if (objectRenderer != null)
    {
        objectRenderer.material.color = Color.red;
    }
}
```

De `if` controleert of het geraakte object een Renderer heeft. Als dat zo is, verandert de kleur van het object in rood.

### Willekeurige kleur

Wil je bij iedere botsing een willekeurige kleur gebruiken? Vervang dan `Color.red` door `Random.ColorHSV()`:

```csharp
objectRenderer.material.color = Random.ColorHSV();
```

---

## Klaar?

Controleer je werk:

- [ ] Mijn bal valt door zwaartekracht.
- [ ] Mijn bal stuitert op de ondergrond.
- [ ] Ik heb een Rigidbody gebruikt.
- [ ] Ik heb een Physics Material gebruikt.
- [ ] In de Console staat welk object de bal raakt.
- [ ] Er gebeurt zichtbaar iets wanneer de bal botst.
- [ ] Ik heb mijn scène opgeslagen.

---

## Inleveren

Lever je opdracht in via Simulise.

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat;
- een korte uitleg van wat je hebt gemaakt;
- wat goed lukte;
- wat je lastig vond.# Oefeningen Les 3.1: Vallen, botsen en stuiteren

Vandaag ga je oefenen met physics in Unity.

Je begint met **Oefening 3.1A**.  
Heb je die af? Dan ga je door met **Oefening 3.1B**.  
Heb je daarna nog tijd, dan mag je **Oefening 3.1C** proberen.

De oefeningen bouwen op elkaar voort. Maak ze dus het liefst in deze volgorde.

---

## Inleveren

Lever je opdracht in via Simulise.

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat
- een korte uitleg van wat je hebt gemaakt
- welke physics-instellingen je hebt gebruikt
- wat goed lukte
- wat je lastig vond

---

## Oefening 3.1A: Vallende bal met stuiter

### Doel

Je leert hoe je een object laat vallen en stuiteren met Unity physics.

### Wat ga je doen?

Je maakt een bal die door zwaartekracht naar beneden valt en stuitert op de vloer.

### Stappen

1. Maak een vloer met een `Plane` of `Cube`.
2. Zorg dat de vloer een `Collider` heeft.
3. Maak een bal met een `Sphere`.
4. Zorg dat de bal een `Sphere Collider` heeft.
5. Voeg een `Rigidbody` toe aan de bal.
6. Laat `Use Gravity` aan staan.
7. Maak een `Physics Material`.
8. Zet `Bounciness` hoger dan `0`.
9. Sleep het Physics Material naar de Collider van de bal.
10. Druk op Play en kijk wat er gebeurt.

### Probeer uit

Verander de waarde van `Bounciness`.

Wat gebeurt er als de waarde laag is?  
Wat gebeurt er als de waarde hoog is?

### Bonus

- Maak een trampolinevloer met hoge `Bounciness`.
- Maak een bal die bijna niet stuitert.
- Maak meerdere ballen met verschillende Physics Materials.

---

## Oefening 3.1B: Foutieve physics verkennen

### Doel

Je leert wat er gebeurt als physics expres raar of extreem zijn ingesteld.

### Wat ga je doen?

Je maakt een scene waarin een object onnatuurlijk reageert.

Dat klinkt misschien gek, maar juist daardoor zie je goed wat instellingen zoals Gravity, Bounciness en Friction doen.

### Stappen

1. Kopieer je scene van oefening 3.1A.
2. Zet bij de bal `Use Gravity` uit.
3. Test wat er gebeurt.
4. Geef de bal een Physics Material met hoge `Bounciness`.
5. Zet `Friction` laag.
6. Druk op Play en kijk wat er gebeurt.

### Probeer uit

Maak bijvoorbeeld:

- een maanlevel waar objecten langzaam vallen
- een ijsvloer waar objecten lang doorglijden
- een bal die overdreven blijft stuiteren
- een object dat blijft zweven

### Bonus

- Maak een object dat langzaam omhoog beweegt alsof het een ballon is.
- Maak een vloer waarop bijna geen wrijving zit.
- Maak een korte gif waarin je rare physics goed zichtbaar is.

---

## Oefening 3.1C: Snelheid, botsing en trigger

### Doel

Je leert hoe je een object snelheid geeft en laat reageren op een botsing of trigger.

### Wat ga je doen?

Je bouwt een scene waarin een bal vooruit schiet.

De bal botst tegen een muur. Als dat gebeurt, verandert de muur van kleur.

Daarna mag je een poortje maken met `Is Trigger`. Als de bal door het poortje gaat, verdwijnt het poortje of verschijnt er een melding in de Console.

### Stappen

1. Maak een bal met een `Rigidbody` en `Sphere Collider`.
2. Maak een muur met een `Box Collider`.
3. Geef de muur een duidelijke kleur.
4. Maak een script, bijvoorbeeld `BallShooter`.
5. Geef de bal in `Start()` een beginsnelheid met `linearVelocity`.

```csharp
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Vector3 initialVelocity = new Vector3(8f, 0f, 0f);

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = initialVelocity;
    }
}
```

6. Zet het script op de bal.
7. Druk op Play en kijk of de bal vooruit schiet.
8. Maak daarna een script op de muur dat bij een botsing de kleur verandert.
9. Gebruik hiervoor `OnCollisionEnter`.

### Extra uitdaging: triggerpoortje

1. Maak een poortje of ring.
2. Geef het poortje een Collider.
3. Zet `Is Trigger` aan.
4. Maak een script dat reageert met `OnTriggerEnter`.
5. Laat het poortje verdwijnen of log een bericht in de Console.

### Bonus

- Laat een deur openzwaaien als de bal ergens tegenaan botst.
- Laat een muntje verdwijnen als de bal erdoorheen gaat.
- Tel +1 op in de Console wanneer de bal door een trigger gaat.
- Bouw een klein parcours met meerdere muren en poortjes.

---

## Klaar?

Controleer je werk:

- [ ] Mijn bal valt door zwaartekracht
- [ ] Mijn bal botst met de vloer
- [ ] Ik heb een `Rigidbody` gebruikt
- [ ] Ik heb een `Collider` gebruikt
- [ ] Ik heb een Physics Material gebruikt
- [ ] Ik heb getest met verschillende instellingen
- [ ] Ik heb mijn scene opgeslagen
- [ ] Ik heb een screenshot of gif gemaakt
- [ ] Ik heb mijn opdracht ingeleverd via [Simulise](PLAATS-HIER-DE-SIMULISE-LINK)

---

## Tips

- Sla regelmatig op met **Ctrl+S**.
- Kijk in de Console als je script niet werkt.
- Als je object door de grond valt, check dan de Colliders.
- Als je object niet valt, check dan de Rigidbody en `Use Gravity`.
- Als je object niet stuitert, check dan het Physics Material.
- Als iets misgaat, gebruik **Ctrl+Z**.
