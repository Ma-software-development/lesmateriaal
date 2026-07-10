# Oefeningen Les 3.1: Unity Physics en Colliders  

## Werkwijze  
In deze les begin je met **Oefening 3.1A**.  
Heb je die af? Dan ga je door met **Oefening 3.1B** en daarna met **Oefening 3.1C**.  
De oefeningen bouwen op elkaar voort, dus het is het beste om ze in deze volgorde te maken.  

De oefeningen lever je in via een **README.md** bestand op GitHub met:  
- Titel van de oefening  
- Korte omschrijving van wat je hebt gedaan  
- Een gifje met je resultaat  
- Link naar je script

Ben je klaar met de oefeningen? Vul dan [dit](https://forms.gle/FZf25qqManYV2cFQ6) formulier in. De kennisvragen helpen je om te ontdekken of je de belangrijkste onderdelen van de les echt begrijpt. Dezelfde onderwerpen komen later terug in de toets.

---

## Oefening 3.1A: Vallende bal met stuiter  

**Doel**  
Leer hoe je in 3D een object laat vallen en realistisch laat stuiteren met behulp van physics.  

**Wat ga je doen?**  
Je maakt een bal die door zwaartekracht naar beneden valt en stuitert op de vloer, vergelijkbaar met een stuiterbal in *Angry Birds*.  

**Stappen**  
- Voeg een Plane of Cube toe als vloer en geef deze een **BoxCollider**.  
- Voeg een **Sphere** toe als bal en geef deze een **SphereCollider**.  
- Voeg aan de bal een **Rigidbody** toe. Laat **Use Gravity** aan staan.  
- Maak in de Project window een **Physic Material** aan en zet **Bounciness** boven 0.  
- Sleep dit Physic Material naar de **Collider** van de bal.  
- Speel de scène af en observeer het verschil in stuiteren bij andere bounciness-waarden.  

**Bonus uitdagingen**  
- Maak een “trampolinevloer” door de vloer een Physic Material met hoge bounciness te geven.  
- Laat een blok verdwijnen zodra de bal erop landt, alsof je een breekbaar platform hebt.  

---

## Oefening 3.1B: Foutieve physics verkennen  

**Doel**  
Begrijp wat er gebeurt als physics expres fout of extreem zijn ingesteld.  

**Wat ga je doen?**  
Je maakt een scène waarin een object onnatuurlijk reageert, bijvoorbeeld zweeft of overdreven stuitert, alsof je een “maanlevel” of glitch nabootst.  

**Stappen**  
- Kopieer je scène van 3.1A.  
- Zet bij de bal **Use Gravity** uit of zet de globale **Gravity** tijdelijk richting 0 in Project Settings.  
- Geef de bal een Physic Material met **Bounciness** rond 1 en **Friction** laag.  
- Speel af en noteer in je README wat er gebeurt en waarom dit niet realistisch is.  

**Bonus uitdagingen**  
- Laat een object zweven alsof het een ballon is en langzaam omhoog gaat.  
- Maak een ijsvloer waar een blok eindeloos door blijft glijden.  
- Laat een vijand heel overdreven stuiteren door extreem hoge bounciness.  

---

## Oefening 3.1C: Velocity, botsing en trigger-event  

**Doel**  
Leer een object met snelheid vooruit te schieten en bij botsing of trigger een event af te handelen.  

**Wat ga je doen?**  
Je bouwt een scène waarin een bal met **velocity** tegen een muur botst en de muurkleur verandert. Daarna vliegt de bal door een poortje met **Is Trigger** aan, waarna het poortje verdwijnt of een melding geeft.  

**Stappen**  
- Voeg een **muur** toe met **BoxCollider** en geef de Renderer een duidelijke kleur.  
- Voeg een **poortje** of ring toe met een **Collider** en zet **Is Trigger** aan.  
- Zorg dat je **bal** een **Rigidbody** en **SphereCollider** heeft.  
- Maak een script (bijvoorbeeld `BallShooter.cs`) en geef de bal in `Start()` een beginsnelheid:  

  ```csharp
  using UnityEngine;
  public class BallShooter : MonoBehaviour
  {
      [SerializeField] private Vector3 initialVelocity = new Vector3(8f, 0f, 0f);
      private Rigidbody rb;
      void Awake() { rb = GetComponent<Rigidbody>(); }
      void Start() { rb.velocity = initialVelocity; }
  }
Maak een script op de muur dat bij botsing de kleur verandert met OnCollisionEnter(Collision collision).

Maak een script op het poortje dat bij OnTriggerEnter(Collider other) een melding logt of het poortje verwijdert.

Bonus uitdagingen
- Laat een deur openzwaaien als de bal er tegenaan botst.
- Laat een muntje verdwijnen als de bal erdoorheen gaat.
- Voeg een scoreteller toe die +1 optelt in de Console wanneer de bal de trigger passeert.
- Bouw een klein parcours met meerdere muren en poortjes.
