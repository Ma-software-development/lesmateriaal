# Tutorial 5

**Schieten en obstakels kapot maken**

## Leerdoelen:

- De student kan een prefab Instantireen vanuit een script
- De student kan met **Destroy()** iets verwijderen na een bepaalde tijd
- De student kan eigenschappen zoals positie en rotatie van een object overnemen naar een ander object
- De student kan een object, zoals een particle effect, inladen, afspelen en verwijderen
- De student kan met **OnTriggerEnter()** een actie uitvoeren nadat 2 objecten elkaar raken
- De student krijgt een introductie in het hergebruiken van scripts

## Stappenplan:

Voer de onderstaande stappen uit en laat in de volgende les zien hoe ver je bent gekomen.

Als je klaar bent lever je het in en laat je het ook zien aan je docent (BO/FLEX/PROG).

Als je vast zit vraag je om hulp!

### Jullie gaan kogels en vijanden maken:

![Kill On Hit](../tutorial_gfx/KillOnHit.gif)

### 1. Maak een prefab voor je vijand

- Gebruik hiervoor een geanimeerd mixamo character naar keuze **[(zie les 2)](../les2/README.md)**

![Idle](../tutorial_gfx/idle.gif)

- Plaats de enemy prefab in de map prefabs

![Enemy Prefab](../tutorial_gfx/enemyPrefab.png)

- Zorg voor een animator component met een animation controller etc...
- Zorg voor een Rigidbody component en een capsule collider op de juiste plek en van de juiste grootte
- Voeg een audio source component toe met een explosie geluidje
- Geef je enemy de tag "Enemy" [(check les 4)](../les4/README.md#tag)

### 2. Maak een prefab voor je kogel

- Gebruik hiervoor een sphere met een mooie material erop
- Plaats de bullet prefab in de map prefabs

![Bullet Prefab](../tutorial_gfx/bulletPrefab.png)

- Zorg voor een leuk particle system om je bullet wat vuur te geven
  _Als je het lastig vind om met particles te werken hoeft het niet per se en mag je ze standaard laten._

![Bullet Particles Loop](../tutorial_gfx/bulletParticlesLoop.gif)

_Tip: hergebruik je [explosion particle system](https://youtu.be/cvQiQglPI18?si=y-XN8Xs4AjQ9ck_2) als je die hebt gemaakt._

- Zorg voor een Rigidbody component
- Zorg voor een Audio Source component met een explosie geluidje

### 3. Tijd om te scripten: **Shoot.cs**

- Maak een **Shoot.cs** script aan
- Hang het script op je player

![Shoot Script](../tutorial_gfx/shootScript.png)

- Maak een public variabele aan waar je de **bullet prefab** in kunt opslaan

```
public GameObject prefab;
```

![Prefab Var2](../tutorial_gfx/prefabVar2.png)

- Sleep je prefab er gelijk in, in de unity inspector

![Prefab Var](../tutorial_gfx/prefabVar.png)

- Check nu in de **update()** methode of je een bepaalde toets indrukt

```
 if (Input.GetKeyDown(KeyCode.LeftControl)) {

 }
```

_Let op: voor het springen heb je de spatie waarschijnlijk al gebruikt!_

- gebruik de methode [**Instantiate()**](https://docs.unity3d.com/ScriptReference/Object.Instantiate.html) om je prefab als een object in de scene te zetten
- De **Instantiate()** methode geeft je het geplaatste gameobject terug, vang deze op in een variabele

```
    GameObject ob = Instantiate(prefab);
```

- geef het geplaatste gameObject dezelfde rotatie als de speler

```
    ob.transform.rotation = transform.rotation;
```

- geef het geplaatste gameObject (kogel) een positie vlak voor de speler

```
    ob.transform.position = transform.position + transform.forward;
```

- Zorg dat het geplaatste gameObject (bullet) na een tijd vanzelf verdwijnt uit de scene met de [**Destroy()**](https://docs.unity3d.com/ScriptReference/Object.Destroy.html) Methode

```
    Destroy(ob,3f);
```

![Instantiate And Destroy2](../tutorial_gfx/InstantiateAndDestroy2.gif)

### 4. Tijd om verder te scripten: **MoveBullet.cs**

- Maak een **MoveBullet.cs** script en hang deze aan de prefab van je bullet

![Make Move Bullet](../tutorial_gfx/makeMoveBullet.png)

- Zorg voor een public variabele voor de **speed**

```
    public float speed = 500f;
```

- Sla de **rigidboby** op in een variabele als de game **Start**

```
    RigidBody rb;
    void Start(){
        rb = GetComponent<RigidBody>();
    }
```

- Update de velocity van de bullet in de **[FixedUpdate](https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity) Methode**

```
    void FixedUpdate()
    {
        rb.velocity = rb.transform.forward * speed * Time.fixedDeltaTime;
    }
```

![Instantiate And Destroy](../tutorial_gfx/InstantiateAndDestroy.gif)

### 5. Tijd voor een herbruikbaar script: **KillOnHit.cs**

Dit script kunnen we (**her**)gebruiken om de **vijand** te laten exploderen als hij geraakt wordt door een **kogel** en de **speler** te laten exploderen als hij de **vijand** raakt.

![Killonhit2](../tutorial_gfx/killonhit2.gif)

- Maak een nieuw script aan: **"KillOnHit.cs"**
- Hang het aan je **bullet** en **enemy** prefabs

![Bullet Kill On Hit](../tutorial_gfx/bulletKillOnHit.png)

![Enemy Kill On Hit](../tutorial_gfx/enemyKillOnHit.png)

- Maak een **public** **string** waarin je de tag kunt invoeren van het type object dat moet exploderen

```
    public string targetTag;
```

- Maak een **public** **GameObject** waarin je de prefab van het explosie effect kunt toevoegen

- Voer als targetTag "Enemy" in bij de bullet in de inspector.

Maak een nieuwe prefab met de naam **exposion** aan in je project window (rightclick > create > prefab) en hang daar in de inspector een particle system aan.

![prefab effect](../tutorial_gfx/05_particle_effect_prefab.png)

- Maak in je **kill on hit** script ook een referentie naar de prefab van je explosie effect.

```
    public GameObject effect;
```

- Sleep hier een zelfgemaakt explosion prefab in via de inspector.

![Bulletsettings](../tutorial_gfx/bulletsettings.png)

- Voer als targetTag "Player" in bij de enemy
- Sleep ook hier de explosion prefab in de **effect** variabele

![Enemysettings](../tutorial_gfx/enemysettings.png)

- Maak nu een variabele voor je audioSource en sla hierin bij de **Start** van je game de audioSource op

```
 private AudioSource audioSource;

 void Start()
 {
    audioSource = GetComponent<AudioSource>();
 }

```

- Roep beide methoden **OnCollisionEnter()** en **OnTriggerEnter()** aan

```
private void OnCollisionEnter(Collision coll)
{

}
private void OnTriggerEnter(Collider coll)
{

}
```

- In beide methoden kun je dezelfde code schrijven!
- Het maakt hierdoor niet meer uit of een gameobject een collider of een trigger heeft
- Zorg dat je **kogel** een trigger heeft
- zorg dat je **enemy** een collider heeft

_Wat zou er gebeuren als je de enemy een trigger zou geven?_

![Trigger](../tutorial_gfx/trigger.gif)

- Check in beide methoden (**OnCollisionEnter** en **OnTriggerEnter**) of de tag van het object overeenkomt met de meegegeven tag

```
    if (coll.gameObject.tag == targetTag){

    }
```

- Instantieer je explosie en sla het game object op in een variabele

```
        GameObject expl = Instantiate(effect);
```

- Haal je explosie weer weg na 2 seconden

```
        Destroy(expl,2f);
```

- Verwijder het **andere** gameobject waarmee een collision is geweest (**enemy** of **player**)

```
        Destroy(coll.gameObject, 0.1f);
```

- Speel het explosie geluid af!

```
        audioSource.Play();
```

- Test je game!
- Werkt het niet? Check of je tags goed zijn

### Commit en push je werk naar je eigen branch op github. Laat je Unity scene, je code en je repository zien aan de docent en lever een link in op simulise (lesplan : GD1.3 - PROG; Programmeren).

[uitleg over inleveren](../inlever_tutorial/README.md)

### Bonus: Controleer de ingevoerde tag en geef zelf een error

Typ foutjes zijn zo gemaakt en als je in je **targetTag** een verkeerde tag schrijft die niet bestaat werkt je code niet.

![Plaaaayer](../tutorial_gfx/plaaaayer.png)

![Buggger](../tutorial_gfx/buggger.gif)

Je kunt te verwachten foutjes opvangen en jezelf, of andere developers die met je code moeten werken, voorzien van goede feedback. Hiervoor kun je gebruik maken van [Debug.LogError()](https://docs.unity3d.com/ScriptReference/Debug.LogError.html).

![Log Error](../tutorial_gfx/LogError.png)

- Maak in de **Start** methode een boolean die bijhoud of je een bestaande tag hebt gevonden

```
    bool tagFound = false;
```

- Loop door de lijst van unity met gedefinieerde tags heen

```
    foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags) {

    }
```

- Check in de loop of de, via de inspector ingevoerde, tag in de lijst zit en dus bestaat

```
        if (targetTag == tag) {
            tagFound = true;
            break;
        }
```

- Als na de loop de tag niet in de lijst is gevonden Log je een Error Message

```
   if (!tagFound)
   {
        Debug.LogError("TargetTag:" + targetTag + " for `KillOnHit` @ " + gameObject.name + " not found!");
   }
```

[uitleg over inleveren](../inlever_tutorial/README.md)
