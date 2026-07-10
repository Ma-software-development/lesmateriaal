

## nieuw project


- ga naar je deze directory in je terminal van visual studio code::
    - `02_var`
- maak in die directory een nieuwe directory:
    - `fouten`
- open een terminal in die directory
- maak een nieuwe console project
    > `dotnet new console --use-program-main`


## aanpassen & herhaling

- voeg een nieuwe file toe: 
    - Fouten.cs
- zet deze code erin:
    ```csharp
    namespace fouten;

    class Fouten
    {
        void CodeMetFouten()
        {
            //hier komt de oefen code
        }
    }

    ```

## speuren

- plak deze code in in de function CodeMetFouten:
```csharp
    string leeftijd = 21;

```
- run je code
- herstel de fout (lees de fout codes!)
- test je code (run!)

## meer fouten

- plak deze code in in de function CodeMetFouten:
```csharp
    bool naam = "Lena";
    double heeftRijbewijs = true;

```
- run je code
- herstel de fout (lees de fout codes!)

## Oefening 2: Ongeldige variabelennamen

- plak deze code in in de function CodeMetFouten:
```csharp
int 3autoWielen = 4;
double lengte-in-cm = 175.5;
bool heeft rijbewijs = false;
```
- run je code
- herstel de fout (lees de fout codes!)

# Oefening 3: Dubbele declaratie / foute waarden

- plak deze code in in de function CodeMetFouten:
```csharp
int mijnleeftijd = 20;
string mijnleeftijd = "twintig";
```
- run je code
- herstel de fout (lees de fout codes!)
