# Step By Step — Project Setup: URP, Package Manager & Skybox

**Zelfstandige stap-voor-stap instructie**

---

## Leerdoelen

- Je kunt een nieuw Unity URP-project aanmaken en een asset pack importeren via de Assetstore
- Je kunt de Render Pipeline Converter gebruiken om materialen te converteren
- Je kunt een HDRI of 6-sided Skybox instellen via Lighting instellingen

---

## Stap 1 — Nieuw project aanmaken met URP

1. Open **Unity Hub**.
2. Klik op **New project** (rechtsboven).
3. Selecteer bovenaan de template **3D (URP)**.
4. Geef het project een naam, bijv. `3d_Gym`.
5. Kies een opslaglocatie en klik op **Create project**.
6. Wacht tot Unity het project heeft aangemaakt en geopend.

> **Waarom URP?**  
> De Universal Render Pipeline is geoptimaliseerd voor meerdere platforms en ondersteunt moderne effecten zoals post-processing, bloom en volume-gebaseerde belichting. De "standaard" 3D-template gebruikt de Built-in Render Pipeline, die deze features minder goed ondersteunt.

---

## Stap 2 — Asset pack importeren via Package Manager

### Via de Unity Asset Store

1. Ga naar **Window > Package Manager**.
2. Klik linksboven op het dropdown-menu en selecteer **My Assets**.
3. Log in als dat gevraagd wordt.
4. Zoek de gewenste asset en klik **Download**, dan **Import**.

> **Let op roze materialen!**  
> Roze materialen betekenen dat een materiaal de verkeerde Render Pipeline gebruikt. Dit los je op met de Render Pipeline Converter (zie Stap 3).

---

> ### Exporteren en importeren via een `.unitypackage`-bestand
>
> Gebruik dit als je assets wilt overdragen tussen projecten zonder de Asset Store — handig als je bijv. iets van een ander project wilt hergebruiken.
>
> #### Stap A — Assets exporteren vanuit een bestaand project
>
> 1. Open het Unity-project dat de assets bevat die je wilt exporteren.
> 2. Selecteer in de **Project** view de bestanden of mappen die je wilt exporteren  
>    (meerdere items: **Ctrl + klik**).
> 3. Rechtermuisknop op de selectie → **Export Package…**
> 4. In het exportvenster zie je de geselecteerde assets en eventuele afhankelijkheden.  
>    Vink items aan of uit naar behoefte.
> 5. Klik op **Export…**, kies een opslaglocatie en geef het bestand een naam  
>    (bijv. `MijnAssets.unitypackage`).
>
> #### Stap B — Assets importeren in het huidige project
>
> 1. Ga naar **Assets > Import Package > Custom Package…**
> 2. Navigeer naar het opgeslagen `.unitypackage`-bestand en klik **Open**.
> 3. In het importvenster zie je alle bestanden in het pakket.  
>    Klik **Import** om alles te importeren.
> 4. Wacht tot Unity klaar is. Check de **Console** op eventuele fouten.

---

## Stap 3 — Render Pipeline Converter: Built-in naar URP

Als de geïmporteerde assets roze materialen hebben, zijn ze gemaakt voor de Built-in pipeline en moeten ze worden omgezet.

1. Ga naar **Window > Rendering > Render Pipeline Converter**.
2. In het venster dat verschijnt, zorg dat de volgende opties aangevinkt zijn:
   - **Built-in to URP**
   - Material and Material References
   - Animation Clips (als je animaties importeert)
3. Klik op **Initialize Converters** (onderaan).
4. Wacht totdat de lijst is ingeladen.
5. Klik op **Convert Assets**.
6. Controleer daarna in de scene of alle materialen correct zijn (niet meer roze).

> **Tip:** Als sommige materialen nog roze zijn, selecteer het materiaal in de Project view en klik in de Inspector op **Edit > Rendering > Materials > Convert Selected Built-in Materials to URP**.

---

## Stap 4 — Eerste scene opzetten

1. Ga naar **File > New Scene** of open de bestaande `SampleScene`.
2. Sla de scene op: **File > Save As** → geef hem een naam zoals `3d_Gym`.
3. Voeg een vloer toe: **GameObject > 3D Object > Plane**. Schaal hem op: X=10, Y=1, Z=10.
4. Voeg een **tilende texture** toe aan de vloer:
   - Importeer een vloertextuur (bijv. een steen- of houtpatroon) sla een tilende texture op in een map `Textures`. Google bijvoorbeeld op `free tiling grass texture`
   - Maak een nieuw materiaal aan: **rechtermuisknop in Project > Create > Material**, geef het een naam zoals `Floor_Mat`.
   - Selecteer het materiaal en stel de **Shader** in op `Universal Render Pipeline/Lit`.
   - Sleep de geïmporteerde texture naar het **Base Map** veld van het materiaal.
   - Sleep het materiaal vanuit de **Project** view op het **Plane** object in de **Scene** of **Hierarchy**.
   - Pas de **Tiling** aan zodat de texture herhaald wordt over de vloer:
     - Selecteer het materiaal in de **Project** view.
     - Scroll in de **Inspector** naar **Surface Inputs**.
     - Stel bij **Base Map** de **Tiling** in op `X = 10, Y = 10` (pas aan op basis van de schaal van de Plane en de gewenste detailgrootte).
   - Controleer het resultaat in de **Scene** view: de texture moet netjes herhaald en proportioneel weergegeven worden zonder uitrekking.

---

## Stap 5 — HDRI Skybox instellen

Een HDRI Skybox geeft realistische omgevingsbelichting en een mooie achtergrond.

### Een Skybox Material aanmaken

Er zijn twee veelgebruikte methoden: via een **panoramische HDRI-texture** (één afbeelding, 360°) of via een **Cubemap** (6 losse vlakken).

#### Methode 1 — Panoramic (HDRI)

1. In de **Project** view: **rechtermuisknop > Create > Material**.
2. Noem het materiaal `MySkybox`.
3. Selecteer het materiaal. In de **Inspector**: klik op het Shader-dropdown en kies **Skybox > Panoramic**.
4. Zoek in de Project view naar een HDRI-texture of download er eentje (`.hdr` of `.exr` bestand, bijv. via [polyhaven.com](https://polyhaven.com/)).
5. Sleep de texture naar het veld **Spherical (HDR)** in de Inspector van het Skybox-materiaal.

> **Naadlijn zichtbaar?** Selecteer de HDRI-texture → zet **Texture Type** op `Sprite (2D and UI)` → klik **Apply**.

#### Methode 2 — Cubemap (6 vlakken)

Een cubemap bestaat uit 6 afbeeldingen die de zes zijden van een kubus vormen (voor, achter, links, rechts, boven, onder).

1. In de **Project** view: **rechtermuisknop > Create > Material**.
2. Noem het materiaal `MySkybox_Cube`.
3. Selecteer het materiaal. In de **Inspector**: kies bij Shader **Skybox > 6 Sided**.
4. Je ziet nu zes texture-slots: **Front [+z]**, **Back [-z]**, **Left [+x]**, **Right [-x]**, **Up [+y]**, **Down [-y]**.
5. Sleep de bijbehorende afbeeldingen naar elk slot.  
   Bestandsnamen eindigen vaak op `_ft`, `_bk`, `_lf`, `_rt`, `_up`, `_dn` of `_negx`, `_posx`, `_negy`, `_posy`, `_negz`, `_posz` — dat geeft aan welk vlak het is.

### Skybox koppelen aan de scene

1. Ga naar **Window > Rendering > Lighting**.
2. Klik op het tabblad **Environment**.
3. Naast **Skybox Material**: sleep je `MySkybox`-materiaal hiernaartoe, of klik het ronde icoontje en selecteer het.
4. Stel **Sun Source** in op de `Directional Light` in je scene.

### Skybox zichtbaar maken in de Game view

1. Zorg dat de **Main Camera** in de scene aanwezig is.
2. Selecteer de Camera. In de Inspector: stel **Environment > Background Type** in op **Skybox**.
3. Druk op **Play** om het resultaat te zien.

### Exposure en Rotation van de skybox aanpassen

1. Selecteer het `MySkybox`-materiaal in de Project view.
2. In de Inspector zie je de eigenschappen:
   - **Exposure**: hogere waarde = helderder (probeer 0.8 – 1.5)
   - **Rotation**: draait de skybox horizontaal (0–360 graden)
3. Pas de waarden aan terwijl de **Scene**- of **Game**-view open is om live het resultaat te zien.
