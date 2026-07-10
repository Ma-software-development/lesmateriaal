
## start

- maak in die `M1Prog_cs1`  een nieuwe directory:
    - `02_var`
- maak in die directory een nieuwe directory:
    - `stringvar`

## terminal openen met visual studio code

- rechter muis click op `stringvar`
    - click op 'open in intergrated terminal'
        - je ziet nu een terminal


- in je terminal in je `stringvar` directory:
    - type `dotnet new console --use-program-main`
        > ![](img/newconsole.PNG)

## String

> de Hello, World! string gaan we nu naar een variable verhuizen (Refactoren)

- maak een nieuwe string variabel aan
    > ![](img/hellovar.PNG)

- pas nu de console writeline aan:
    > ![](img/hellovar2.PNG)

## wat hebben we gedaan?

- lees
    ```
    als we een stuk code hebben zoals Console.WriteLine("hello"); dan zit daar een string waarde in:  
    - "hello" 

    Die waarde wordt als tijdelijke variable opgeslagen.

    1) Wij hebben nu een variable gemaakt en DAAR de waarde "hello world" in bewaart
    2) Later vragen wij de waarde van helloWorldMessage op, en gebruiken de waarde voor console.writeline
    ```


## + string

- laten we nu de code nog een keer aanpassen:
