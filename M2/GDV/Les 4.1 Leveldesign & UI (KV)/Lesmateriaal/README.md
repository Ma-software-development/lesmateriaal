# Les 4.1 Week 4 – Level Design & UI


## Theorie – Canvas en UI

### Canvas
Een Canvas is de ruimte waarin alle UI van het spel staat.  
Alle knoppen, panelen en teksten bestaan binnen dit Canvas.  
UI gebruikt RectTransforms in plaats van gewone Transforms.

### RectTransform
De UI-versie van Transform.  
Bepaalt positie, grootte en schaal van UI.  
Werkt met pixels en schermruimte voor precieze besturing.

### Anchors
Anchors bepalen hoe UI meebeweegt wanneer de schermresolutie verandert.  
Door anchors goed te plaatsen blijft UI op de juiste plek, zonder verschuiven of vervormen.

### Canvas Scaler
Regelt hoe UI schaalt op verschillende schermformaten.  
Bij Scale with Screen Size blijft layout consistent en leesbaar, ongeacht resolutie.

---

## Theorie – 9-slice

### Wat is 9-slice
Een 9-slice verdeelt een sprite in negen delen.  
Hoeken blijven scherp en onvervormd.  
Randen schalen in één richting.  
Het midden schaalt volledig mee.

### Waarom 9-slice
UI blijft strak en professioneel.  
Geen uitgerekte randen of vervormde pixels.  
Eén sprite werkt voor verschillende groottes panelen en knoppen.

### 9-slice in Unity
Open de sprite in de Sprite Editor.  
Stel de borders in.  
Unity past daarna automatisch 9-slice toe bij het schalen van UI-elementen.







