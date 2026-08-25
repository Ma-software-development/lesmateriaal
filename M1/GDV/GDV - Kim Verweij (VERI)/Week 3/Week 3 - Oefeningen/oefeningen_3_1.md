# Oefeningen Les 3.1: Vallen, botsen en stuiteren

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
