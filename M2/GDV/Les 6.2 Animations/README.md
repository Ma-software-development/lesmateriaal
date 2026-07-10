# M2 GDV les 6.2 (CODE) 2d Animations

Om een animatie in Unity te maken heb je een zogenaamde **"sprite sheet"** nodig. Dit is een enkele image met daarop de verschillende frames van een animatie.

_voorbeeld van een spritesheet:_
![spritesheet](https://fiverr-res.cloudinary.com/images/t_main1,q_auto,f_auto,q_auto,f_auto/gigs/135301408/original/0adcf7085ee367a5ce5b514be49d24e05c96f6f8/create-quality-sprite-sheet.jpg)

Deze spritesheet kan 1 of meerdere animaties bevatten.

Om deze sprite sheet te kunnen gebruiken in unity is het van belang om deze op de juiste manier te importeren. Als het gaat om een spritesheet met 1 animatie erin is dat heel makkelijk en straight forward.

Sleep je image (.png) in je unity project in een map aan met de naam `/Sprites`, `/Spritesheets` of `/2d` of iets dergelijks.

Selecteer nu de image en kijk in de inspector.

Verander nu de Texture Type naar `Sprite (2d and UI)` en druk op `apply`

![import](../src/6_2_import.png)

Je asset is nu goed geimporteerd en kan in het project window ook uitgeklapt worden. Unity heeft de verschillende frames in je animatie geidentificeerd.

![import](../src/6_2_sprites.png)

Om je 2d animatie af te kunnen spelen heb je een game object nodig met een `Sprite Renderer` en een `Animator` component.

![animator_animation](../src/6_2_animator_animation.png)

Maar uiteraard kan unity het je ook makkelijk maken en kun je gewoon de sprite asset in je scene slepen. Unity maakt dan voor jou een gameobject aan en een animation en animator Asset.


