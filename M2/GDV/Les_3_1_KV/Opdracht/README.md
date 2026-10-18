# Les 3.1 Week 3 – Score & Triggers Opdracht 


## De Opdracht

In deze opdracht bouw je de kern van jouw Peggle-spel. Je maakt een Peggle die reageert wanneer de bal het object raakt, bijhoudt hoeveel hits er nog over zijn, punten doorgeeft aan de ScoreManager en verdwijnt zodra de ingestelde hoeveelheid hits is bereikt. Dit vormt de basis van de gameplay die je later verder gaat uitbreiden.

Het minimale resultaat is een Peggle die geraakt kan worden, punten oplevert en automatisch verdwijnt wanneer de hits op zijn. Dit moet zichtbaar zijn in jouw spel: de score moet correct oplopen en de Peggle moet op het juiste moment verdwijnen.

Je werkt in duo’s zodat jullie deze mechanic gezamenlijk kunnen ontwikkelen. Jullie bespreken hoe jullie de oplossing opzetten, welke logica jullie gebruiken en welke stappen nodig zijn om de mechanic goed te laten werken. Jullie kunnen elkaar helpen, verschillende keuzes vergelijken en samen oplossen wat niet meteen lukt.
Iedere student bouwt wel in een eigen Unity-project. De kern van de mechanic is hetzelfde, maar de uitwerking mag per persoon verschillen in stijl of details.

Aan het einde van de opdracht controleren jij en je duo-partner samen of jullie Peggles reageren op hits, punten doorgeven en verdwijnen wanneer de hits op zijn. Daarna maakt elke student een korte GIF van de eigen mechanic en voegt deze toe aan de README, samen met een korte uitleg.


---

## Stappenplan 
- Maak een Peggle-object in je scene. Dit kan een sprite, een vorm of een eigen asset zijn. 
- Geef het object een duidelijke naam, bijvoorbeeld Peggle. 
- Voeg een Collider2D toe zodat je bal de Peggle kan raken. Dit object heeft geen Rigidbody nodig.

Stap 2
- Maak een nieuw script voor de Peggle.
- Voeg daarin twee instellingen toe: het totale aantal hits (int) dat de Peggle aankan en het aantal punten (int) dat één hit waard is.
- Je stelt deze waardes straks in via de Inspector.

Stap 3
- Laat de Peggle bijhouden hoeveel hits er nog over zijn.
- Wanneer de bal de Peggle raakt, gaat dit aantal omlaag.
- Zodra de Peggle geen hits meer heeft, is hij “op” en kan hij uit de scene worden verwijderd

Stap 4
- Geef de score door aan de ScoreManager door vanuit het Peggle-script AddScore aan te roepen. 
- Hierdoor zie je direct resultaat wanneer je de Peggle raakt.

Stap 5
Laat de Peggle verdwijnen wanneer de teller het ingestelde aantal hits heeft bereikt. 
- Gebruik hiervoor Destroy(gameObject).

Stap 6
Maak de mechanic visueel door elke hit zichtbaar te maken. 
- Dit kan bijvoorbeeld door de kleur van de Peggle donkerder te maken of door een sprite-swap te doen.

Stap 7
Test je mechanic samen met je duo-partner. Controleer of de score oploopt, of de hits worden geregistreerd en of de Peggle op het juiste moment verdwijnt.

Stap 8
Maak een GIF waarin drie dingen te zien zijn: 
- het raken van de Peggle,
- het oplopen van de score
- en het verdwijnen van de Peggle.
Voeg deze GIF toe aan je README met een korte uitleg.


---

<details>
<summary>Klik hier om de voorbeeldcode voor de Peggle te openen</summary>

```csharp

using UnityEngine;

public class Peggle : MonoBehaviour
{
    public int hitsToDestroy = 3;     // totaal aantal hits dat deze peg aankan
    public int pointsPerHit = 10;     // aantal punten dat één hit waard is


  private void OnCollisionEnter2D(Collision2D collision)
   {
        // score toekennen
        ScoreManager.Instance.AddScore(pointsPerHit);

        // aftellen
        hitsToDestroy--;

        // check of de peg nu op is
        if (hitsToDestroy <= 0)
        {
            Destroy(gameObject, 0.25f);
        } 
   }
}

```
</details> 







