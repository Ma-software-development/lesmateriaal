# M2 GDV les 3.2 (CODE) Peggle Game, Combos, Multiplier, Events

Wat we er uiteindelijk mee kunnen bouwen:
![combo gameplay](../src/3_2_combo_multiplier.gif)

Wat we vandaag gaan bouwen:
![combo result](../src/3_2_combo_result.gif)

We gaan een combo systeem maken op basis van tags.

## Bumpers maken

Om te beginnen plaatsen we een aantal bumpers in het level.

Hiervoor maken we eerst prefabs.

Maak prefabs voor minstens 2 soorten bumpers.

Start eerst met een ronde .png van een bumper. Je kunt ook een simpele circel gebruiken.

![create circle](../src/3_2_create_circle.png)

plaats deze eerst in je hierarchy hang er een `Circle Collider 2d` component aan en sleep hem vervolgens in je prefabs map om er een prefab van te maken.

![circle prefab](../src/3_2_circle_prefab.gif)

## Tags toevoegen

Geef je prefab een tag zoals bijvoorbeeld `RedCombo` of `combo_1` iets waaraan je kunt herkennen bij welke combo deze bumper hoort en wat overeenkomt met het uiterlijk.

We gaan meerdere bumpers die bij elkaar horen dezelfde tag geven.

zodat we in de code kunnen zien of er wel of geen combo gemaakt is aan de hand van de tag van de bumper die geraakt is.

![combo tag](../src/3_2_combo_tag.png)

Maak nu een level met minimaal 2 soorten bumpers die hun eigen bijhorende tags hebben. De namen van de tags zijn niet heel belangrijk als de bumpers die bij elkaar horen maar dezelfde tags hebben.

## Nieuwe tags definieren

Standaard zijn er al wat vaste tags maar je kunt deze zelf ook toevoegen.

![new tag](../src/3_2_new_tag.gif)

Geef nu ook de prefab van je bal de tag: `Ball`

## Scripts toevoegen

Maak 2 nieuwe scripts aan: `BumperHit.cs` en `ComboSystem.cs`
Hang `BumperHit.cs` als component aan de prefabs van je verschillende bumpers.

Sleep `ComboSystem.cs` in je hierarchy. Er zal dan vanzelf een nieuwe leeg gameobject gemaakt worden met het script erop.

![combo system](../src/3_2_combo_system_hierarchy.png)

Open beide scripts in Visual Studio

## BumperHit.cs

Laten we hiermee starten. Dit script gaat voor elke bumper bijhouden of hij door de bal geraakt is.

Hiervoor hebben we de unity methode `OnCollisionEnter2D` nodig.

```Csharp
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
```

Nu gaan we dus voor elke bumper bijhouden of hij geraakt wordt door de bal. Hiervoor controleren we de tag van alle objecten die de bumpers raken.

```Csharp
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {

        }
    }
```

### Action Events

Als we geraakt worden door de bal willen we eigenlijk iets doen in een ander script. Er zijn meer manieren om dit voor elkaar te krijgen maar een mooie manier is gebruik maken van `Action Events`. Zie dit als berichtjes die scripts kunnen versturen waar andere scripts naar kunnen luisteren. Een soort radiostation en radio ontvangers dus.

_Technish gezien werkt het iets anders maar zo is het makkelijk te begrijpen en te onthouden._

![radio](https://as1.ftcdn.net/v2/jpg/16/50/63/96/1000_F_1650639638_FVoyRm2ULaOPLodRnw0Z07vGlTp8b5Jp.jpg)

We gaan nu dus een radio bericht maken om te kunnen versturen. Een `Action Event` dus. Deze maken we in de `class` maar voor de functie `OnCollisionEnter2D`

Het bericht zetten we als volgt klaar voor gebruik:
`public static event Action<string> onBumperHit;`

- `public` zorgt dat andere scripts erbij mogen komen
- `static` zorgt dat hij niet bij 1 gameobject hoort en dat alle bumpers hetzelfde bericht kunnen sturen.
- `event` zorgt dat alleen de bumpers dit bericht kunnen sturen
- `Action` zorgt dat andere scripts iets kunnen doen met het bericht als ze het ontvangen
- `<string>` zorgt dat we extra informatie mee kunnen sturen in het bericht
- `onBumperHit` is de naam van het bericht

```Csharp
using System;       //nodig voor Action
public class BumperHit : MonoBehaviour
{
    //dit is het action event , het bericht
    public static event Action<string> onBumperHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            //straks gaan we hier het bericht versturen dat onze bumper geraakt is.
        }
    }
}
```

Om het bericht daadwerkelijk te versturen gebruiken we de `Invoke()` functie.
Dit ziet er dan zo uit `onBumperHit?.Invoke();`

Met het vraagteken checken we of er wel naar het bericht wordt geluisterd. Zo niet hoeven we hem niet te versturen. Met Invoke versturen we het bericht.

We gaan ook informatie met het bericht meesturen. Namenlijk de `tag` van onze bumper, zodat ons combo systeem kan zien welke bumper er geraakt is. Ook sturen we de waarde van de bumper mee zodat het combo systeem kan bepalen hoe veel punten we erbij krijgen.

In de vorige les hebben we al een `ScoreSystem` gemaakt met daarin een methode `AddScore`. Deze kunnen we nu ook gebruiken om onze score te verhogen.

De code ziet er nu als volgt uit:

```Csharp
using System;   //nodig voor Action
public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 100;
    public static event Action<string, int> onBumperHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            onBumperHit?.Invoke(gameObject.tag, scoreValue);//bericht versturen dat er een bumper geraakt is. De tag en waarde sturen we mee

        }
    }
}
```

We hebben nu dus een script dat bijhoud voor alle bumpers of ze geraakt worden. Zodra dat zo is versturen ze een bericht met daarbij ook de tag en punten waarde van de bumper. Elk ander script in mijn project kan nu besluiten om naar dit bericht te gaan luisteren en er iets mee te gaan doen. Dat maakt voor dit script verder niet meer uit. Dit script is nu klaar met zijn werk.

## ComboSystem.cs

We gaan nu het systeem bouwen dat bijhoud welke bumpers er geraakt zijn en in welke volgorde. Zolang de bumpers die geraakt worden bij elkaar horen (zelfde tags) zal de combo oplopen en zo ook een multiplier waarmee de score vermenigvuldigd kan worden.

We gaan beginnen om te zorgen dat dit script gaat luisteren naar berichten van de bumpers. Hang het script op

Die doen we als volgt in de `Start` methode:

```Csharp
private void Start()
{
    BumperHit.onBumperHit += CheckForCombo;
}
```

Het script luistert naar alle berichten met de naam `onBumperHit` die verstuurd worden door alle `BumperHit` scripts die op de bumpers zitten.

zodra dit bericht binnenkomt voert de code de functie `CheckForCombo` uit die we ook gaan maken in dit script.

**Belangrijk** scripts die naar `Action Events` luisteren moeten hier ook mee stoppen als er bijvoorbeeld een nieuwe scene geladen wordt. Anders gaat het script 2x luisteren naar hetzelfde bericht en dan 3x enzovoort. Dit kan resulteren in `bugs` en zogenaamde `memory leaks`. Om dit te voorkomen gebruik je deze code:

```Csharp
private void OnDisable()
{
    BumperHit.onBumperHit -= CheckForCombo;
}
```

We gaan nu ook de `CheckForCombo()` functie maken. Hierin komt te staan wat het `ComboSystem` moet doen als er een bumper geraakt is.

```Csharp
private void CheckForCombo(string tag, int bumperValue){

}
```

De tags die meegestuurd worden in de berichten gaan we verzamelen in een List. We moeten dus ook een `List` maken. Dit doen we bovenin het script binnen de `class` maar voor de `functies`.

`private List<string> bumperTags = new List<string>();`

Onze code ziet er nu zo uit:

```Csharp
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();

    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;
    }
    private void CheckForCombo(string tag, int bumpervalue) {

    }
}

```

Nu gaan we in de `CheckForCombo` functie de binnengekomen tags verzamelen in de lijst.

`bumperTags.Add(tag);`

Zodra we meerdere berichten binnen hebben gehad hebben we dus ook meer tags in de lijst staan. Die kunnen we dan dus gaan vergelijken. We pakken steeds de laatste 2 tags. Zodoende kunnen we een hele chain bijhouden van tags die hetzelfde zijn. Zodra de laatste tag anders is dan de vorige kunnen we de lijst leeg maken en is de combo-chain verbroken.

De lijst kunnen we leeg maken met `bumperTags.Clear();`

```Csharp
    //check of er meer dan 1 tag in de lijst zitten
    if (bumperTags.Count > 1) {
        //check of de op 1 na laatste tag gelijk is aan de laatste
        if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
        {
            //Zo ja? Combo Chain is nog heel
        }
        else
        {
            //Zo nee? Combo Chain is verbroken

        }
    }
```

Als beloning voor een ondoorbroken combo-chain willen we de speler een score multiplier geven die ervoor zorgt dat de score steeds sneller oploopt. We gaan hiervoor weer een variabele maken.
`private int scoreMultiplier = 1` wederom op de daarvoor bestemde plek. In de `class` maar boven alle `functies`.

Elke keer als we een bumper raken en de combo-chain nog heel is verhogen we deze multiplier waarde met 1.

Zodra we een verkeerde bumper raken resetten we de `scoreMultiplier` waarde weer naar `1`

Dit is nu onze code:

```Csharp
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();
    private int scoreMultiplier = 1;
    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;
    }
    private void CheckForCombo(string tag, int bumperValue) {
        if (bumperTags.Count > 1) {

            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;
            }
            else
            {
                scoreMultiplier = 1;
                bumperTags.Clear();
            }
        }
    }
}
```

Tot slot moeten we natuurlijk nog onze score op gaan tellen en bijhouden. Hiervoor maken we gebruik van de `ScoreManager` die jullie in [les 3.1](<https://github.com/djsjollema/lessen-gamedevelopment/blob/main/M2/GDV/Les%203.1%20Score%20%26%20Triggers%20(KV)/Lesmateriaal/ScoreManager.md#les-31-week-3--score-manager>) hebben gemaakt. Als je nog les nog niet hebt uitgewerkt kun je dat nu eerst doen.

bij elke bumper die we raken gaan we de waarde van deze bumper optellen bij de score. Deze punten worden ook vermenigvuldigd met de `scoreMultiplier`.

Dit doen we nadat we gecheckt hebben of onze chain nog heel is of verbroken.
`ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);`

We printen onze score en de multiplier ook gelijk even naar de `console` met behulp van `Debug.Log`.

De code is nu compleet en ziet er als volgt uit:

```Csharp
using System.Collections.Generic;
using UnityEngine;
public class ComboSystem : MonoBehaviour
{
    private List<string> bumperTags = new List<string>();   //lijst met geraakte tags
    private int scoreMultiplier = 1;
    private void Start()
    {
        BumperHit.onBumperHit += CheckForCombo;             //luisteren naar action event onBumperHit als game start
    }
    private void OnDisable()
    {
        BumperHit.onBumperHit -= CheckForCombo;             //stop met luisteren naar action event onBumperHit als scene herstart of game stopt
    }
    private void CheckForCombo(string tag, int bumperValue)
    {
        bumperTags.Add(tag);                                //tag toevoegen aan lijst
        if (bumperTags.Count > 1)                           //check of er meer dan 1 tag is
        {                                                   //check of de laatste 2 tags gelijk zijn
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;                          //verhoog de multiplier
            }
            else                                            //als ze niet gelijk zijn
            {
                scoreMultiplier = 1;                        //reset multiplier
                bumperTags.Clear();                         //leeg de lijst met tags
            }
        }                                                   //voeg score toe aan de ScoreManager
        ScoreManager.Instance.AddScore(bumperValue * scoreMultiplier);

                                                            //print score en multiplier in de console
        Debug.Log($"Score: {ScoreManager.Instance.score} || Multiplier: {scoreMultiplier}X");
    }
}

```

## Testen

Als het goed is werkt je prototype nu ongeveer zo:

![result combos](../src/3_2_result_combos.gif)

## Inleveren op je README

Zet in de titel **3.2 Combo System en Bumpers**
Maak een korte omschrijving en GIF van je prototype en zet deze op je readme. Zet hier ook de links naar de code.
