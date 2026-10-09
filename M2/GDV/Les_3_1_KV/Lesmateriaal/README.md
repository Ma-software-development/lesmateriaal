# Les 3.1 Week 3 – Peggle, hits & score


## Inleiding

In deze les bouw je de complete basis van jouw Peggle-mechanic. Je maakt een Peggle die reageert op de bal, bijhoudt hoeveel hits er nog over zijn, punten doorgeeft aan de ScoreManager en uit het level verdwijnt wanneer de hits op zijn. Dit is de eerste versie van de echte gameplay van jouw spel: raken, punten verdienen en Peggles die verdwijnen. Deze mechanic breid je de komende weken verder uit met extra feedback en spelvariatie.

---

## Theorie
Een Peggle reageert wanneer de bal ertegenaan botst. Deze botsing activeert (of “triggert”) een stukje gameplay: het optellen van punten, het aftellen van de overgebleven hits en uiteindelijk het verwijderen van de Peggle wanneer deze op is. Dit systeem is gebaseerd op collisions in Unity. Een collision ontstaat wanneer twee colliders elkaar raken en één van de objecten een Rigidbody heeft.

Elke Peggle heeft een eigen set waardes die het gedrag bepalen, zoals het aantal hits dat nog over is en het aantal punten dat een hit waard is. Door die waardes aanpasbaar te maken in de Inspector, kun je verschillende soorten Peggles maken. Op die manier bouw je variatie in je spel zonder nieuwe scripts te hoeven schrijven.

De ScoreManager verzamelt alle punten van alle Peggles op één centrale plek. Wanneer een Peggle geraakt wordt, “meldt” deze zich bij de ScoreManager en geeft een aantal punten door. Zo ontstaat er een duidelijk en uitbreidbaar puntensysteem dat later gebruikt kan worden voor leveldoelen, bonusregels of scorevergelijkingen.

De combinatie van collision-detectie, hit-registratie en de ScoreManager vormt de basis van Peggle-achtige gameplay: raken, feedback krijgen, punten verdienen en objecten die verdwijnen na genoeg hits.

---


###  Voeg een GIF en uitleg toe aan je README
Maak een korte GIF waarin jouw mechanic duidelijk te zien is. Zorg dat de GIF laat zien dat de bal de Peggle raakt, dat de score oploopt en dat de Peggle op het juiste moment verdwijnt. Plaats deze GIF onderaan je README en schrijf er een korte uitleg bij waarin je in je eigen woorden beschrijft wat jouw Peggle precies doet: hoeveel hits er nodig zijn, hoeveel punten je krijgt en wat er gebeurt wanneer de Peggle “op” is.







