

## start

- ga naar je deze directory in je terminal van visual studio code:
    - `02_var`
- maak in die directory een nieuwe directory:
    - `variableopdracht1`
        > ![](img/newdir.PNG)
    

## terminal openen met visual studio code

- kijk naar je explore window van visual studio code
    - rechter muis click op `variableopdracht1`
        - click op 'open in intergrated terminal'
            - je ziet nu een terminal, controlleer of je in de goede directory zit


## dotnet new

- in je terminal in je `variableopdracht1` directory:
    - type `dotnet new console --use-program-main`
        > ![](img/newconsole.PNG)
- open Program.cs
 
 ## variablen maken
- kijk waar Hello World staat
- zet tussen hello wolrd en VOOR de `}` wat nieuwe lege regels:
    > ![](img/hier.PNG)

- daar maak je:
    - 4 variabelen voor een vlucht:
        > ![](img/newvars.PNG)
    
    - sluit deze allemaal af met een ; zonder er een waarde aan te geven

- build je project
- run je project
- werkt het? als het goed is wel, alleen je ziet alleen Hello world op het scherm, dat is goed!

## begrijpen

- lees:
```
Zie je dat we variabelen maken door eerst het TYPE en daarna de naam te typen?  

We gebruiken hier 4 verschillende types:
- string, voor waardes die letters, tekens en nummers KUNNEN bevatten
    > bv: "Hello! user7923#$"
- int, dit is voor waardes van HELE getallen, hiermee kunnen we rekenen
    > bv: 999, maar NIET "999" dat wordt een string
- double, ook voor getallen, maar dan met een komma
    > bv: 15.99
- bool: voor het bijhouden of iets waar of niet waar is, of aan of uit staat
    > je kan alleen true OF false als waardes gebruiken
```

## Variabelen op het scherm zetten

- we gaan nu de variabelen ook waardes geven:
    > ![](img/tokyo.PNG)

- zet nu er extra code bij om het op het scherm te zetten:
    > ![](img/consoletokyo.PNG)

- run!
    > ![](img/showtokyo.PNG)

- zet nu de rest ook op het scherm:
    > HINT: je hebt 4 writeline regels nodig!  
    > ![](img/showall.PNG)
    

## mooier

- probeer nu zelf dit te maken:
    > ![](img/concat.PNG)

- kijk naar de code en probeer dit te begrijpen:
    - zie je hoe we waardes, variablen en strings aan elkaar plakken zodat 1 string wordt?

