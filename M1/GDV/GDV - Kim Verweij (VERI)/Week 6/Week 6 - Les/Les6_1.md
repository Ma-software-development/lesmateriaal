# Les 6.1: Alles komt samen

Vandaag ga je alles van de afgelopen lessen combineren in één klein speelbaar level.

Geen grote game dus.  
Gewoon een mini-level waarin je laat zien dat je de basis van Unity snapt.

Je gebruikt dingen die je al eerder hebt geoefend:

- GameObjects
- bewegen met code
- physics
- colliders en triggers
- `if` en `switch`
- simpele gameplay-logica

---

## Na deze les

Na deze les kun je:

- een klein speelbaar level bouwen
- onderdelen uit eerdere lessen combineren
- oude scripts hergebruiken of aanpassen
- een interactie maken met `if` of `switch`
- een collider of trigger gebruiken
- je scene netjes opslaan

---

## Wat is een mini-level?

Een mini-level is een kleine scene met een duidelijk doel.

Bijvoorbeeld:

- verzamel alle coins
- pak een sleutel en open een deur
- ontwijk obstakels en bereik de finish
- raak doelwitten met verschillende aanvallen
- los een kleine puzzel op met triggers

Hou het klein.  
Het hoeft niet perfect te zijn. Het moet vooral werken.

---

## Begin met een simpel idee

Bedenk eerst kort wat de speler moet doen.

Bijvoorbeeld:

```text
De speler moet een sleutel pakken.
Daarna gaat een deur open.
Als de speler de finish raakt, is het level klaar.
```

Dat is al genoeg voor een mini-level.

Maak het niet te groot.  
Je kunt altijd nog iets extra’s toevoegen als je tijd over hebt.

---

## Gebruik wat je al hebt

Je hoeft niet alles opnieuw te maken.

Je mag scripts uit eerdere lessen gebruiken, zoals:

- een object dat draait
- een object dat heen en weer beweegt
- een trigger voor een coin of sleutel
- een `if` om te checken of iets waar is
- een `switch` om keuzes te maken

Pas scripts aan zodat ze bij jouw level passen.

---

## Voorbeeld: sleutel en deur

Je kunt bijvoorbeeld een sleutel verzamelen en daarna een deur openen.

```csharp
using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    public GameObject door;
    public bool hasKey = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Door") && hasKey == true)
        {
            door.SetActive(false);
        }
    }
}
```

Dit is maar een voorbeeld.  
Je mag het simpeler of anders maken.

---

## Denk aan je scene

Zorg dat je level duidelijk is opgebouwd.

Check even:

- waar start de speler?
- wat is het doel?
- wat kan de speler verzamelen of raken?
- wat beweegt er?
- waar gebruik je een trigger of collider?
- wanneer is het level klaar?

---

## Veelgemaakte fouten

### Mijn trigger werkt niet

Check even:

- staat `Is Trigger` aan?
- heeft één van de objecten een `Rigidbody`?
- klopt de tag?
- staat het script op het juiste GameObject?

### Mijn script doet niets

Check even:

- staat het script op een GameObject?
- heb je op Play gedrukt?
- staat er een foutmelding in de Console?
- heet je scriptbestand hetzelfde als je class?

### Mijn level wordt te groot

Maak het kleiner.  
Eerst zorgen dat de basis werkt. Daarna pas extra dingen toevoegen.

---

## Oefening

Ga nu naar de oefeningen van les 6.1:

[Oefeningen Les 6.1](../Week%206%20-%20Oefeningen/oefeningen_6_1.md)

Je gaat een eigen mini-level bouwen waarin je laat zien wat je de afgelopen lessen hebt geleerd.

---

## Checklist

- Ik heb een klein speelbaar level gemaakt
- Ik heb minimaal één bewegend object
- Ik heb minimaal één collider of trigger
- Ik heb minimaal één `if` of `switch` gebruikt
- Ik heb iets uit een eerdere les hergebruikt of aangepast
- Ik heb een eigen extra idee toegevoegd
- Mijn scene is opgeslagen
