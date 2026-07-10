## unity

start nu unity op

- maak een nieuw project:
    - ListsCsharp2
- zorg dat je een unity ignore file hebt
    - zet deze op de goede plek!
        > in `dezelfde` directory waar je `Library` directory ook in staat!

## script

- maak een nieuw script
- in de class van dit script maak je een nieuwe List aan
- in deze list moeten GameObject (s) komen
    > noem deze `bullets`



## scene
- maak nu een object in je scene (dit wordt een spawner) 
    > gebruik een basis vorm zoals een kubus, bal etc
- deze spawner moet om de 0.5 seconde:
    -  een nieuw gameobject maken 
         > gebruik gewoon een standaard object zoals een bal of kubus
    - dat gameobject moet weggaan met een *random* richting & een *vaste* snelheid 
- elk gameobject wat je maakt stop je in de List (`bullets`) die je gemaakt hebt

## limieten
- in je update:
    - kijk je hoe groot de lijst (`bullets`) is 
        - als de lijst groter dan 20 is, haal je het eerste object weg 

## split

- voeg het volgende toe aan je update:
    - doe het volgende om de 1 seconde:
        - maak een tijdelijke lijst
            - noem deze even `revengeBullets`
        - loop door je lijst (`bullets`) met bewegende objecten
        - voor elk object:
            - maak een random getal van 0-100
            - als het getal 90 of hoger is:
                - zet je het object in de tijdelijke lijst `revengeBullets`

## revenge bullets maken

- loop nu door de tijdelijke lijst `revengeBullets`:
    - voor elk object:
        - maak 2 nieuwe objecten
            - deze geef je een *random* richting & een *vaste* snelheid 
        - plaats de 2 nieuwe in de lijst (`bullets`) NA het huidige object
        - haal het oude object weg

## commit

`commit` & `push` naar je git!
