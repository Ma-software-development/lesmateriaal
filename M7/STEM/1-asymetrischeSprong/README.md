# Asymetrische sprong

# Quadratic function

Een **quadratic function** zit er in het algemeen zo uit:

$$ f(t) = at^2 + bt +c $$

Met deze functie kunnen de nulpunten worden gevonden met een **quadratic equation**

$$ at^2 + bt + c = 0$$


Nu kunnen wij bepalen op welke tijdstippen de sprong de t-as snijdt en de functie f(t) dus nul wordt. Deze nulpunten kan je vinden met de **quadratic formula**

$$ t_{1,2} = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a} $$

Bij een sprong kunnen wij de duur van de sprong vinden door de zwaartekracht (g) , beginsnelheid($`v_0`$) en hoogte waarop de sprong begint ($`h_0`$) in te vullen. De eindhoogte moet wel nul worden, dus de sprong moet eindigen op f(t) = 0

| parameter | waarde  | betekenis |
|-----------|--------|--------|
| a         | $` - \frac{1}{2}g `$ |zwaartekracht
| b         | $`v_0`$    | beginsnelheid
| c         | $`h_0 `$    | beginhoogte


Zo luidt de formule om de duur van de sprong te bepalen:

$$ f(t) = -\frac{1}{2} g t^2 + v_0 t + h_0 $$

## de quadratic-class in C#
Wij kunnen van deze formule in C# een class maken die deze berekening uitvoert

``` CS
public class QuadraticFunction 
{
    public float a;
    public float b;
    public float c;

    public QuadraticFunction(float a, float b, float c)
    {
        this.a = a; this.b = b; this.c = c;
    }

    public float evaluteValue(float t)
    {
        return (a * t * t) + (b * t) + c;
    }

    public Vector2 findZero()
    {
        Vector2 isZero = new Vector2();
        float D = (this.b * this.b ) - (4 * this.a * this.c);
        if(D<0)
        {
            throw new InvalidOperationException("Geen reële oplossingen voor deze vergelijking.");
        }

        else
        {
            isZero.x = (-this.b + Mathf.Sqrt(D))/(2 * this.a);
            isZero.y = (-this.b - Mathf.Sqrt(D)) / (2 * this.a);
        }

        return isZero;
    }

}
```
## de opdracht
Gebruik een spritesheet om een sprong in unity uit te voeren. Je mag zelf de zwaartekracht, beginsnelnheid en beginhoogte instellen.

## voorbeeld
Een sprong in Unity met als parameter

| Parameter  | Waarde |
|------------|----------------|
| $` g `$    | $` -10 \frac{m}{s^2} `$ |
| $` v_0 `$  | $` 9 \frac{m}{s} `$ |
| $` h_0 `$  | $` -3 m `$ |

Deze in de formule voor de sprong invullen:

$$ f(t) = -\frac{10}{2} t^2 + 9 t - 3 $$

Deze functie ziet er alsvolgt uit:
![parabool](images/parabool.png)

De nulpunten zijn t = 0.44 seconden en t = 1.36 seconden. 

Dit zijn dus de snijpunten van de sprong met de lijn y=0. Bij de hoogste waarde van t is de sprong afgelopen. De sprong duurt dus 1.36 seconden

## de animatie

![Jump Anim](images/jumpAnim.png)


de animatie van de sprong duurt 12 frames = 0.750 seconden

![jumpTime](images/JumpTime.png)



## de animation speed

$$ animation.speed = \frac{animationTime}{jumpTime}$$

Dus:

$$ animation.speed =  \frac{0.75}{1.36} = 0.551 $$

![voorbeeld](images/asym_jump.gif)

## het script

```mermaid

classDiagram
    class AsymJump {
        - float vb
        - float g
        - float deltaH
        - States myState
        - Animator animator
        - Vector3 velocity
        - Vector3 acceleration
        - float t
        - float tmax
        - QuadraticFunction f
        - Vector3 startPos
        + void Start()
        + void Update()
    }
    
    class States {
        <<enumeration>>
        wait
        jump
        finished
    }

    class Animator {
        + float speed
    }

    class Vector3 {
        + float x
        + float y
        + float z
    }

    class QuadraticFunction {
        + float a
        + float b
        + float c
        + Vector2 findZero()
    }

    AsymJump --> States
    AsymJump --> Animator
    AsymJump --> Vector3
    AsymJump --> QuadraticFunction

```