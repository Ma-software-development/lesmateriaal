# Tutorial 2 Bewegen en besturen.

**Beweging en besturing van gameobjecten**

## Leerdoelen:

- Jullie begrijpen wat een [**Vector2** en **Vector3**](https://cgcookie.com/lessons/understanding-vector-3) is
- Jullie begrijpen wat een [**Rigidbody**](https://medium.com/eincode/unity-rigidbody-explained-fb208d0f97f3) is
- Jullie kunnen werken met de [**Velocity**](https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html) van een rigidbody
- Jullie kunnen objecten roteren met:[`transform.Rotate();`](https://docs.unity3d.com/ScriptReference/Transform.Rotate.html)
- Jullie kunnen waarden controleren met:[`Debug.Log();`](https://docs.unity3d.com/ScriptReference/Debug.Log.html)
- Jullie begrijpen waarom snelheden worden vermenigvuldigd met: [`Time.deltaTime`](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html)
- Jullie kunnen met de Unity [**input manager**](https://docs.unity3d.com/Manual/class-InputManager.html) werken
- Jullie kunnen 3d modellen en animaties goed [importeren](https://docs.unity3d.com/Manual/class-FBXImporter.html) zodat deze goed worden afgespeeld

## Stappenplan:

Voer de onderstaande stappen uit en laat in de volgende les zien hoe ver je bent gekomen.

Als je klaar bent lever je het in en laat je het ook zien aan je docent (BO/FLEX/PROG).

Als je vast zit vraag je om hulp!

### 1. Download via Mixamo een character met een "idle" en een "walk" of "run" animatie

![Run](../tutorial_gfx/Run.gif)

Download de **idle met skin** en de rest zonder.

### 2. Sla de .FBX files op in je "Character" folder

![Idle Walk](../tutorial_gfx/idleWalk.png)

### 3. Check de settings van beide FBX objecten

![Settings](../tutorial_gfx/settings.png)

**Exporteer zo nodig de materials en textures van je model**
![Extract](../tutorial_gfx/extract.png)

**Zet "Loop Time" en "Loop Pose" aan voor je animaties**
![Loop](../tutorial_gfx/loop.png)

### 4. Maak een vloer(plane) en een leeg game object voor je player

![Player](../tutorial_gfx/player.png)

### 5. Sleep je "Idle" FBX in je lege Player gameobject

![Player Drag](../tutorial_gfx/playerDrag.png)

### 6. Voeg een animator component toe en een animator controller

![Animator Controller](../tutorial_gfx/animatorController.png)

### 7. Sleep je Idle animatie in de Animator tool

![Idle](../tutorial_gfx/idle.png)

### 8. Sleep de Walk animatie in de Animator tool en maak transitions

![Idleto Walk](../tutorial_gfx/idletoWalk.png)

### 9. Maak 3 triggers "Walk", "Idle" en "WalkR"(R=reverse)

### 10. Voeg de juiste conditions toe aan je transitions

### 11. Zet voor je transitions "Has Exit Time" uit

![Trigger Setup](../tutorial_gfx/triggerSetup.png)

### 12. dupliceer de walk animation in de animator en zet de Speed op -1

Zo gaat dezelfde animatie achterstevoren afspelen

![Duplicate](../tutorial_gfx/duplicate.png)

### 13. Voeg de transitions toe met de juiste triggers in de conditions

![Transitions](../tutorial_gfx/transitions.png)

### 14. Voeg een rigidbody en een capsule collider toe aan de player

![Rigid Capsule](../tutorial_gfx/rigidCapsule.png)

- Zorg dat de capsule collider de juiste maat en positie heeft
- Zet ze op je **Player** gameobject en niet op je model
- Zorg dat de capsule niet kan roteren op de x en z as zodat ie niet om kan vallen
- Vink ook **Is Kinematc** aan! Zodat de player niet wordt gemanipuleerd door het physics systeem. (wat tot onverwachte resultaten kan leiden)

### 15. Roteer je model evt 180 graden op de y as

![Rotate](../tutorial_gfx/rotate.png)
Zodat je player van de camera af kijkt. Als dit al zo is hoeft dat niet.

### 16. Maak een Script met de naam Animate en plaats deze op je model

![Animate Script](../tutorial_gfx/animateScript.png)

```
//Maak een variabele aan voor je animator component
private Animator ani;

void Start()
{
//Pak het animator component en sla die op in de variabele
    ani = GetComponent<Animator>();
}
void Update()
{
//Check voor verticale input
    if (Input.GetAxis("Vertical") > 0)
    {
//is de waarde groter dan 0 dan heb je een knop naar boven ingedrukt
//Roep de juiste trigger aan!
        ani.SetTrigger("Walk");
//SetTrigger is trigger activeren
        ani.ResetTrigger("Idle");
        ani.ResetTrigger("WalkR");
//ResetTrigger is Trigger de-activeren
    }
    else if (Input.GetAxis("Vertical") < 0)
    {
//is de waarde kleiner dan 0 dan heb je een knop naar beneden ingedrukt
//Roep de juiste trigger aan
        ani.SetTrigger("WalkR");
        ani.ResetTrigger("Idle");
        ani.ResetTrigger("Walk");
    }
    else {
//is de waarde 0 dan heb je niets ingedrukt
//Roep de juiste trigger aan
        ani.SetTrigger("Idle");
        ani.ResetTrigger("Walk");
        ani.ResetTrigger("WalkR");
    }
}


```

### 17. Test of je animaties werken

- vooruit == Walk
- achteruit == WalkR
- niets == Idle

![Walktest](../tutorial_gfx/walktest.gif)

### 18. Maak nu een MoveBasic script en zet deze op je player

![Basic Move](../tutorial_gfx/basicMove.png)

### 19. Maak een variabele voor je beweeg snelheid en rotatie snelheid

Door `[SerializeField]` voor de variabelen te zetten worden ze beschikbaar in de inspector.

Omdat het floats zijn zet je een f achter het nummer.

```
public class MoveBasic : MonoBehaviour
{
    [SerializeField]private float speed = 50f;
    [SerializeField]private float rotSpeed = 50f;
```

### 20. Maak een variabele voor je rigidbody

```
//Maak een variabele voor je rigidbody
    private Rigidbody rb;

```

### 21. Sla de rigidbody van je player op in de variabele met behulp van de methode [GetComponent<>()](https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html)

```
void Start()
{
    rb = gameObject.GetComponent<Rigidbody>();
}
```

### 22. Bereken de bewegingssnelheid van je player

```
void Update()
{
    Vector3 positionUpdate = transform.position + Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime;


```

Check in de **Input Manager** (via edit > project settings) welke toetsen van invloed zijn op **Input.GetAxis("Vertical");**

![Input Manager](../tutorial_gfx/inputManager.png)

### 23. Geef de berekende snelheid door als nieuwe positie zodat je player gaat bewegen

```
    transform.position = positionUpdate;

```

### 24. Zorg ook voor de rotatie van je speler op basis van de input

```


    transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0));

    // 0 graden draaien over de x - as
    // 0 graden draaien over de z - as
    // aantal graden over de y - as is opgebouwd uit:
    //  - Input.GetAxis("Horizontal") waarde tussen -1 (links) en 1 (rechts). Als je geen toets indrukt is het 0
    // rotSpeed is je rotatie snelheid die je in de inspector instelt
    // Time.deltaTime is de tijd dat het geduurd heeft om het frame te renderen. Dit zorgt ervoor dat de snelheid op elke framerate hetzelfde is.

}
```

### 25. Probeer de juiste snelheid voor het bewegen en roteren te vinden

![Tweak](../tutorial_gfx/tweak.png)

![Walk Animation](../tutorial_gfx/WalkAnimation.gif)

### 26. Probeer zelf eens een script te schrijven om de een gameobject zonder te roteren over de X- en Z-as te bewegen

![Movearound](../tutorial_gfx/movearound.gif)

### Commit en push je werk naar je eigen branch op github. Laat je Unity scene, je code en je repository zien aan de docent en lever een link in op simulise (lesplan : GD1.3 - PROG; Programmeren).

[uitleg over inleveren](../inlever_tutorial/README.md)
