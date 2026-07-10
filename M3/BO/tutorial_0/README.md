# Tutorial 0: Opzetten van je Ontwikkelomgeving

**Let op deze tutorial is enkel ter voorbereiding. Het telt niet mee voor de af te tekenen mechanics!**

**Ontwikkelomgeving opzetten en simpele launch mechanic**

## Leerdoelen:

- Jullie weten wat een IDE (integrated development environment) is en kunnen die opzetten voor Unity game projecten
- Jullie kunnen een unity project opzetten voor de arcade mechanics opdrachten
- Jullie kunnen simpele game objecten in de scene creeren
- Jullie kunnen de Rigidbody en Script components aan gameobjecten toevoegen
- Jullie weten waar je de Unity code reference kunt vinden en hoe je deze zelf kunt gebruiken als script ondersteuning
- Jullie kunnen simpele scripts schrijven om gameobjecten te manipuleren

## Stappenplan:

Voer de onderstaande stappen uit en laat in de volgende les zien hoe ver je bent gekomen.

Als je klaar bent lever je het in en laat je het ook zien aan je docent (BO/FLEX/PROG).

Als je vast zit vraag je om hulp!

### 0. Bekijk de eerste 31:35 minuten van deze video

Als je de basics van Unity nog even wil herhalen kun je deze video bekijken. Als het goed is hebben jullie deze kennis al opgedaan in de orienatiefase maar als je twijfelt over je basiskennis van unity kun je deze nog even bekijken.
[![basics](../tutorial_gfx/unity_basics.png)](https://youtu.be/pwZpJzpE2lQ?si=4GncqWjHaXYUy1kV)

### 1. installeer unity HUB

Als je nog geen Unity en Unity Hub hebt geinstalleerd kun je dit nu doen.
![hub](https://user-images.githubusercontent.com/1262745/216940260-3ecdf60a-4cc5-444c-a402-06dd3459728a.png)

### 2. Installeer de laatste LTS versie van Unity

![lts](https://user-images.githubusercontent.com/1262745/216939918-3874ba56-e1c3-49fb-8bac-005241182cae.png)

### 3. Creer een repo met readme en een unity .gitignore

![repo](https://user-images.githubusercontent.com/1262745/216939622-9a9d53aa-0eeb-4323-85d8-9bda551a301a.png)

### 4. Indien van toepassing : Installeer [MS Visual Studio Community 2022](https://visualstudio.microsoft.com/downloads/)

- Selecteer Game Development with Unity
  ![VSunity](https://user-images.githubusercontent.com/1262745/216986819-4bc6afe0-9967-4879-80f7-504565016f69.png)

- Installeer de **_Markdown Editor (64-bit)_** Extension
  ![markdown](https://user-images.githubusercontent.com/1262745/216987147-a79b5572-6b4d-472e-9f77-259bb7d7b8c4.png)

### 5. Clone de repo

Doe dit met github Desktop:
![clone](https://user-images.githubusercontent.com/1262745/216944643-6c447b9f-e305-4dda-a3aa-47179c79d11b.png)

Of via de commandline:

`git clone https://github.com/user/ArcadeMechanics.git`

### 6. Maak een 3d Unity **"URP"** project aan binnen je Repo

![unityhub](../tutorial_gfx/0_URP.png)

Dit staat voor Universal Render Pipeline. Hier kun je later meer mee dan met de **"Built in"** render pipeline

Het kan zijn dat je deze eerst moet importen..

![patience](https://user-images.githubusercontent.com/1262745/216938677-8133a273-0f83-475e-89bb-1fb380543a95.png)

![unity](https://user-images.githubusercontent.com/1262745/216944716-bf1b346e-4f36-4217-8082-4fb551120f8c.png)

### 7. Verplaats de .gitignore file naar root van je unity project

De plek waar je ook de **Assets** folder tegenkomt!

![root](https://user-images.githubusercontent.com/1262745/216955006-0ab2f920-f0fe-4754-afb4-96b3933d2016.png)

Als je dit niet goed doet werkt je .gitignore niet. Dit herken je aan het feit dat git o.a. de **Library** folder gaat tracken als je `git add . ` gebruikt

![gitignore wrong place](../tutorial_gfx/0_library_gitignore.png)

### 8. Maak in Unity een **"Scripts"** folder

![script folder](https://user-images.githubusercontent.com/1262745/216945944-54b722e5-ff2a-4234-bb5c-6bdef8abd164.png)

Die zul ja dan ook in je andere omgevingen terugzien. (Visual studio en windows verkenner)

![folders](https://user-images.githubusercontent.com/1262745/216945988-cc0df84c-1d81-4179-b6c3-c882d5b81026.png)

### 9. Maak een eerste script: **HelloUnity.cs**

Die maak je natuurlijk in je "scripts" folder.

![hellounity](https://user-images.githubusercontent.com/1262745/216946539-011f9dbc-591c-4de8-b5f6-9074445a63b2.png)

![script](https://user-images.githubusercontent.com/1262745/216946844-b529242a-3546-4190-8e63-3b9fc1886567.png)

Dit script heeft het Monobehaviour template

![script2](https://user-images.githubusercontent.com/1262745/216947101-31e0775e-e199-44cf-90ef-c5cfe5c260da.png)

### 10. Schrijf code:

```
  void Start(){
    Debug.Log("Hello Unity");
  }
```

### 11. Voeg het script als component toe aan het Main Camera object.

gewoon even erop slepen!

![component](https://user-images.githubusercontent.com/1262745/216948658-32ab1cfa-e0fd-4cdf-b5ff-bafa1a8deaa9.png)

### 12. Run the game! en check de console.. Zie je een bericht?

![run](https://user-images.githubusercontent.com/1262745/216949259-30d317b7-4d68-410e-ac80-5f6f3b4b8015.png)

### 13. Neem de uitleg over de layout van unity door (Klik op de onderstaande image):

[![image](https://docs.unity3d.com/uploads/Main/using-editor-window.png)](https://docs.unity3d.com/Manual/UsingTheEditor.html)

### 14. Plaats een Plane en een Cube in de Scene.

![3d](https://user-images.githubusercontent.com/1262745/216987879-0503f333-0bb5-4d58-8db9-d2d1be3c6506.png)

### 15. Voeg een Rigidbody component toe aan de Cube via de optie Add Component.

![addObjectsRigid](https://user-images.githubusercontent.com/1262745/216987955-ef5b1fa3-ec39-450a-bbdc-8cfa085fd289.png)

### 16. Maak een nieuw LaunchCube.cs script aan en hang dat aan de Cube als component.

![launch cube](https://user-images.githubusercontent.com/1262745/216988688-58fa601b-c638-4c33-92cc-9e7ef36e3404.png)

### 17. Ga naar de Rigidbody pagina van de Unity scripting manual.

- Bekijk hier de [scripting manual](https://docs.unity3d.com/ScriptReference/Rigidbody.html).
- Zoek naar de **AddForce** methode en bekijk het voorbeeld.
- Gebruik nu de methode **AddForce()** in je eigen script om de **Cube** te lanceren.
- Doe dit op het moment dat je de [spatie ingedrukt hebt](https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html)

Dit is ongeveer het resultaat
![result](../tutorial_gfx/0_result.gif)

### Commit en push je werk naar je eigen branch op github. Laat je Unity scene, je code en je repository zien aan de docent en lever een link in op simulise (lesplan : GD1.3 - PROG; Programmeren).

[uitleg over inleveren](../inlever_tutorial/README.md)
