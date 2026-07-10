# PROG les 4: Single Responsibility (SRP) en Don't Repeat Yourself (DRY)

[Zie ook de slides over SRP en DRY](SRPenDRY.pdf)

Naast de het voorkomen van Tight Coupling ([behandeld in les 2](../02_Herhaling_Action_Events/README.md))zijn er nog meer best practices binnen het programmeren. 2 belangrijke best practices zijn Single Responcibility Principle en Don't Repeat Yourself.

## Object GeOrienteerd Programmeren / Object Oriented Programming - OOP

Het Single Responsibility Principle is onderdeel van de [SOLID](https://www.digitalocean.com/community/conceptual-articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design) principles. Dit zijn basisprincipes die programmeurs altijd moeten aanhouden om robuuste en makkelijk uitbreidbare en onderhoudbare code te kunnen schrijven. De SOLID principes zijn weer een belangrijk onderdeel van het Object GeOrienteerd Programmeren (OOP).

Daarnaast bestaat OOP in de basis uit een 4 tal basisonderdelen die we in deze lessenreeks deels ook nog zullen behandelen:

- Overerving / Inheritance
- Abstractie / Abstraction
- Inkapseling / Encapsulation
- Polymorfisme / Polymorphism

Ook deze basis elementen zijn ervoor bedoeld om robuuste , uitbreidbare en onderhoudbare code te schrijven.

## Single Responsibility Principle

De naam dekt al erg goed de lading.

Elke class mag volgens het SRP principe maar 1 verantwoordelijkheid hebben oftewel maar 1 ding doen. Door dit aan te houden kun je deze code later heel makkelijk aanpassen zonder dat dit verder effect hoeft te hebben op andere functionaliteit in je systeem.

![SRP](../src/04_01_SRP.png)

Bijvoorbeeld in je towerdefense game kun je een script voor het schieten met je toren apart houden van het script waarmee je de toren kunt upgraden. Hierdoor kun je het schieten aanpassen zonder dat het upgrade systeem hier last van heeft.

Code die SRP niet aanhoudt is herkenbaar aan grote classes en ook komt hier vaak het woord **"manager"** voor in de naam.

De programmeur wist immers niet zo goed meer hoe alle verschillende functies van de class samengevat moesten worden.

Het goed toepassen van SRP zorgt ervoor dat je scripts ook mooi leesbaar zijn. Verder zijn ze makkelijk te hergebruiken op andere objecten.

Bijvoorbeeld een upgrade script dat werkt voor alle torens die dat zouden moeten kunnen. I.p.v voor elk type toren deze functionaliteit weer opnieuw te moeten programmeren. Enkel de verschillen tussen de torens moeten apart worden geprogrammeerd. De overeenkomsten maar 1 keer.
![modular](../src/04_02_modular.png)

Het gebruik van SRP zal leiden tot losse herbruikbare scripts die een duidelijk herkenbare en afgeschermde functionaliteit hebben.

![SRP](../src/04_03_scripts.png)

## Don't Repeat Yourself

Code moet compact en herbruikbaar zijn. Op het moment dat je stukken herhalende code schrijft wordt het later erg lastig om aan te passen. Elke aanpassing zal dan op verschillende plekken moeten worden doorgevoerd.

Ook maakt herhaling je code gewoonweg lastig leesbaar. Herhalende code noemen me ook wel eens spaghetti code omdat de functionaliteit allemaal met elkaar verweven is en een aanpassing op de ene plek ook weer gevolgen heeft voor code op een andere plek. Het wordt dan al snel een soort speurtocht om kleine veranderingen te maken. Herkenbaar?!

Om dit te voorkomen is de vuistregel dus dat je code nooit mag herhalen.

Bijvoorbeeld variabelen van hetzelfde type en met dezelfde functie zoals enemy1 , enemy2 , enemy 3 etc..

Of algoritmes die vaker hetzelfde doen met verschillende objecten.

```
    if(enemy1.lives == 0){
        Destroy(enemy1);
    }
    if(enemy2.lives == 0){
        Destroy(enemy2);
    }
```

Of verschillende classes die gebruik maken van dezelfde functies die allemaal opnieuw zijn geschreven.

Op de volgende manieren kun je je code verbeteren op gebied van SRP:

- Arrays en Lists gebruiken
- Functies en Methoden gebruiken
- Gebruiken van parameters in je functies
- Herbruikbare functies en classes schrijven
- Bibliotheek functies gebruiken
- Inheritance en Abstraction (OOP principes) gebruiken

### Arrays en Lists gebruiken

![arrays and lists](../src/04_04_arr_list.png)

### Functies en Methoden gebruiken

### Gebruiken van parameters in je functies

![arrays and lists](../src/04_05_func_methods.png)

### Herbruikbare functies en classes schrijven

![parameters](../src/04_06_reuse.png)

### Bibliotheek functies gebruiken

![bibliotheek](../src/04_07_library.png)

### Inheritance en Abstraction (OOP principes) gebruiken

![inheritance and abstraction](../src/04_08_inher_abstr.png)

<a name = "opdracht4A"></a>

### Opdracht 4A: SRP

Fork en clone [dit project](https://github.com/erwinhenraat/Space48/tree/main) en probeer het script: ShipBehaviour.cs op te delen in losse scripts volgens het SRP principe.

Zorg dat het prototype precies blijft werken zoals het deed.

![demo](../src/04_09_demo.gif)

- **_Push je code naar github en maak een screen capture van je werkende prototype._**
- **_Zet je werk (gifje , omschrijving en links naar je code) op je PROG readme op github._**

<a name = "opdracht4B"></a>

### Opdracht 4B: DRY

In de code voor de LaserBehaviour staat de volgende code:

```
    void Update(){
        transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }

```

In de code voor de ShipBehaviour staat:

```
    void Move() {
        transform.position = transform.position + transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

    }
```

Beide scripts doen nagenoeg hetzelfde met als klein verschil de Input.GetAxis("Vertical") statement. Pas het script zodanig aan dat beide gameobjecten (het schip en de kogel) gebruik kunnen maken van hetzelfde script. Noem deze **"Movement.cs"**

Zie jij zelf nog iets anders wat herhalend is en erg op elkaar lijkt????

Scroll voor een hint!
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
|\
**Hint:**

```
   IEnumerator Introduction() {
       introductionField.enabled = true;
       introductionField.text = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
       yield return new WaitForSeconds(5f);
       introductionField.enabled = false;
   }
   IEnumerator ShowMessage(string message) {
       messageField.enabled = true;
       messageField.text = message;
       yield return new WaitForSeconds(3f);
       messageField.enabled = false;
   }
```

Je introduction is ook gewoon een message!

Maak de code herbruikbaar! zodat ook de introduction gebruik maakt van de ShowMessage functie.
Zorg dat ook de tijd dat het bericht zichtbaar is voor alle berichten ingesteld kan worden.

- **_Push je code naar github en maak een screen capture van je werkende prototype._**
- **_Lever een link je code en je gifje in via Simulize._**

### Bonus: extra feature

Onderin het ShipBehaviour.cs script staan nog een aantal todo's
werk 1 van de opties uit :

- Optie 1 een HealthSysteem en enemies die op je schieten
- Optie 2 een energy shield systeem

Zorg dat de uitwerking voldoet aan SRP en DRY!

- **_Push je code naar github en maak een screen capture van je werkende prototype._**
- **_Lever een link je code en je gifje in via Simulize._**
