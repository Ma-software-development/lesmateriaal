## Return

- nu gaan we een vraag anders maken
    - maak een vraag7 function
        - verander `void` in `string`
        - haal de regel hieronder weg
        >![](img/weg.PNG)

        - voeg nu het volgende toe:
        >![](img/returnant.PNG)

## gebruiken

- probeer eerst zelf de function te gebruiken en het antwoord op het scherm te zetten
    <details> 
    <summary>Lukt het niet? </summary>
    <img src="./img/vraag7.PNG">
    </details>
        
## Lijstje maken

- nu gaan we Program.cs die we hebben een lijst met vragen toevoegen
    - voeg het stuk met vragen toe bovenin je program.cs:
    >![](img/vragen.PNG)

- we maken nu een nieuwe function die 1 vraag teruggeeft:
    >![](img/getvraag.PNG)

    - probeer de function uit in Run
    >![](img/getvraagrun.PNG)

- stop nog meer vragen uit `gamequestions.txt` in de lijst


## Random

- we maken weer een function met een return:
    >![](img/getrandom.PNG)
    - vul de function zelf in zodat deze 1 vraag uit de vragen array pakt
        - gebruik de Random class uit c# om een random index te pakken
            > https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-8.0    
            >
            > Hint: uit array pakken `arrayVariableNaam[welkeIndex]`
    
- gebruik de nieuwe function ook in Run

## function gebruikt function

- Maar we hadden al een getvraag function toch?
    - om te laten zien dat we een function in een function kunnen gebruiken passen we de laatste regel aan
        >Dus deze regel:  
        > ![](img/verander.PNG)
    - maak daar het volgende van:
        > ![](img/getvraagrandom.PNG)
        
    

## commit

`commit` & `push` naar je git!