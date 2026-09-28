# Oefening 3.1 – Stuiteren en botsingen

In deze oefening maak je een bal die op een ondergrond stuitert. Daarna gebruik je code om een botsing te detecteren en de kleur van een Material te veranderen.

Probeer de opdrachten eerst zelf te maken. Kom je er niet uit? Dan kun je de voorbeeldcode openklappen.

---

## Stap 1 – Maak een ondergrond

1. Maak een nieuwe **Cube**.
2. Gebruik de **Scale Tool** om van de Cube een ondergrond te maken.
3. Maak een **Material**.
4. Kies zelf een kleur en plaats het Material op de Cube.

Je mag zelf bepalen hoe je omgeving eruitziet. Je kunt bijvoorbeeld meerdere Cubes gebruiken om verschillende ondergronden, verhogingen of muren te maken.

---

## Stap 2 – Maak een stuiterende bal

1. Maak een **Sphere**.
2. Plaats de Sphere boven de ondergrond.
3. Voeg een **Rigidbody** toe aan de Sphere mocht er nog geen rigidbody opzitten. Dit kun je zien in de inspector. 
4. Maak een **Physics Material**. Dit kun je doen door rechter muisklik in project.
   <img width="874" height="509" alt="image" src="https://github.com/user-attachments/assets/4f95da84-1716-4ee7-b2a2-b047ed335931" />

6. Geef het Physics Material een hoge **Bounciness**.
7. Plaats het Physics Material op de Collider van de Sphere.

Test je spel.

De bal moet naar beneden vallen en weer omhoog stuiteren wanneer deze de ondergrond raakt.

---

## Uitleg – Een botsing detecteren

Met `OnCollisionEnter` kun je detecteren wanneer een object tegen een ander object botst.

De parameter `collision` bevat informatie over de botsing. Met `collision.gameObject.name` kun je bijvoorbeeld de naam opvragen van het object waartegen de bal botst. 

Met `Debug.Log` kun je deze naam tonen in de **Console**.

---

## Stap 3 – Detecteer een botsing

1. Maak een nieuw script voor de bal.
2. Noem het script bijvoorbeeld `BallCollision`.
3. Plaats het script op de Sphere.
4. Gebruik `OnCollisionEnter` om een botsing te detecteren.
5. Gebruik `Debug.Log` om in de Console te tonen welk object de bal raakt.
6. Test je spel en controleer de Console.

Kun je in de Console zien welk object de bal raakt? Dan heb je de basisopdracht behaald.

<details>
<summary>Bekijk de voorbeeldcode</summary>

```csharp
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("De bal raakt: " + collision.gameObject.name);
    }
}
```

</details>

---

# Uitdaging – Verander kleur bij botsing!

Zorg ervoor dat er zichtbaar iets gebeurt wanneer de bal ergens tegenaan botst.

Probeer ervoor te zorgen dat de ondergrond van kleur verandert wanneer de bal erop stuitert.

Je mag ook zelf iets anders bedenken. Je kunt bijvoorbeeld:

- de ondergrond van kleur laten veranderen;
- de bal van kleur laten veranderen;
- meerdere Cubes maken die allemaal van kleur veranderen;
- bij iedere botsing een willekeurige kleur kiezen;
- een extra boodschap in de Console tonen.

---

## Uitleg – De Renderer

Om de kleur van een object te veranderen, heb je de `Renderer` van dat object nodig.

De Renderer zorgt ervoor dat een object zichtbaar wordt. Via de Renderer kun je ook het Material en de kleur van het object aanpassen.

De Renderer moet je:

1. bovenaan het script declareren;
2. één keer in `Start()` ophalen;
3. bij een botsing gebruiken om de kleur te veranderen.

`GetComponent<Renderer>()` hoort dus in `Start()` en niet in `OnCollisionEnter`.

---

## Stap 4 – Laat de ondergrond van kleur veranderen

1. Maak een nieuw script.
2. Noem het script bijvoorbeeld `ChangeColor`.
3. Declareer bovenaan het script een variabele voor de Renderer.
4. Haal de Renderer op in `Start()`.
5. Gebruik `OnCollisionEnter` om een botsing te detecteren.
6. Verander bij een botsing de kleur van het Material.
7. Plaats het script op de Cube.
8. Test je spel.

<details>
<summary>Bekijk de voorbeeldcode</summary>

```csharp
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        objectRenderer.material.color = Color.red;
    }
}
```

</details>

---

## Extra uitdaging – Gebruik een willekeurige kleur

Zorg ervoor dat de Cube bij iedere botsing een willekeurige kleur krijgt.

Probeer eerst zelf te bedenken wat je hiervoor moet aanpassen.

<details>
<summary>Bekijk de oplossing</summary>

Vervang:

```csharp
objectRenderer.material.color = Color.red;
```

door:

```csharp
objectRenderer.material.color = Random.ColorHSV();
```

</details>

---

## Inleveren

Lever je opdracht in via Simulise.

Zorg dat je inlevering bevat:

- een screenshot of gif van je resultaat;
- een korte uitleg van wat je hebt gemaakt;
- welke physics-instellingen je hebt gebruikt;
- wat goed lukte;
- wat je lastig vond.

---

## Klaar?

Controleer je werk:

- [ ] Mijn bal valt door zwaartekracht.
- [ ] Mijn bal stuitert op de ondergrond.
- [ ] Ik heb een Rigidbody gebruikt.
- [ ] Ik heb een Physics Material gebruikt.
- [ ] In de Console staat welk object de bal raakt.
- [ ] Ik heb de Renderer bovenaan het script gedeclareerd.
- [ ] Ik haal de Renderer op in `Start()`.
- [ ] Mijn Cube verandert van kleur wanneer de bal erop stuitert.
- [ ] Ik heb mijn scène opgeslagen.
- [ ] Ik heb een screenshot of gif gemaakt.
- [ ] Ik heb mijn opdracht ingeleverd via Simulise.

---

## Tips

- Sla regelmatig op met **Ctrl+S**.
- Kijk in de Console als je script niet werkt.
- Valt je bal door de grond? Controleer dan de Colliders.
- Valt je bal niet? Controleer dan de Rigidbody en **Use Gravity**.
- Stuitert je bal niet? Controleer dan het Physics Material en de **Bounciness**.
- Verandert de kleur niet? Controleer dan of het script op de juiste Cube staat.
- Gaat er iets mis? Gebruik dan **Ctrl+Z**.
