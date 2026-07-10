## Lineaire combinaties, span, and basis vectoren

Bekijk eerst deze aflevering van de essence of Lineair Algebra
<a href="https://youtu.be/k7RM-ot2NWY?feature=shared" target="_blank">Linear combinations, span, and basis vectors | Chapter 2, Essence of linear algebra</a>

Om deze aflevering uit te werken, gaan we in Unity onze eigen Ray tekenen met behulp van een vectorvergelijking.

Voor een Ray (halve lijn) heb je twee vectoren nodig: de steunvector en de richtingsvector

# Vergelijking van een lijn met steunvector en richtingsvector

In de vectoriële vorm wordt een lijn in de ruimte of in het vlak vaak beschreven aan de hand van:
- een **steunvector** (ook wel een punt op de lijn),
- een **richtingsvector** (die de richting van de lijn aangeeft).

<img src="images/SteunEnRichting.png" height="50%">

## 1. Algemeen principe

De vergelijking van een lijn `l` door een punt **A** met een richtingsvector **r** is:


$$ l(s): \vec{x} = \vec{a} + s \vec{r} $$

Waarbij:
- **x** een willekeurig punt op de lijn is,
- **a** de steunvector is (bijvoorbeeld **a** = (x₀, y₀, z₀)),
- **r** de richting(vector) is (bijvoorbeeld **r** = (r₁, r₂, r₃)),
- s ∈ ℝ is een parameter (de lijnparameter) die alle punten op de lijn doorloopt.

## voorbeeld van een punt op de lijn vinden

Neem een steunvector en en richtingsvector en een waarde voor t, bijvoorbeeld

$$ \vec{a} = \begin{bmatrix}
1 \\
2
\end{bmatrix} $$
$$ 
\vec{r} = \begin{bmatrix}
    3 \\
    1
\end{bmatrix}$$

$$s = 3$$


dan 

$$ \vec{x} = \vec{a} + s \vec{r} $$

$$
\vec{x} = \begin{bmatrix}
    1\\
    2 
\end{bmatrix} + 3 \begin{bmatrix}
    3 \\ 
    1
\end{bmatrix} = \begin{bmatrix}
    10 \\ 
    5
\end{bmatrix}
$$


## Class MyRay

Nu ga je zelf een myRay-class maken. Om de class MyRay te testen maak je ook een class TestMyRay

Om de te testen gebruiken wij twee dragable objects: eentje die  de support- of steunvector aangeeft en een punt die aangeeft waar de direction- of richtingsvector is
<img src="images/RayClass.gif">

In de Ray op het scherm te renderen onderzoek je de afmetingen van het scherm en bepaal je het meest nabije punt op de lijn, bepaal je de lijn-parameter en teken je met een LineRenderer de lijn. 



## tips

Probeer deze class zelf te ontwikkelen. Als dit niet lukt kun je dit voorbeeld gebruiken

````csharp
using UnityEngine;

public class VectorRay
{
    public Vector3 supportVector;
    public Vector3 directionVector;
    public float lineParameter;

    public VectorRay(Vector3 supportVector, Vector3 directionVector)
    {
        this.supportVector = supportVector;
        this.directionVector = directionVector.normalized;
    }

    public Vector3 getPoint(float t)
    {
        return supportVector + directionVector * t;
    }

    public Vector3 getBorderPoint(Vector2 min, Vector2 max)
    {
        float tx = float.MaxValue;
        float ty = float.MaxValue;

        if (Mathf.Abs(directionVector.x) > 0.0001f)
        {
            tx = directionVector.x > 0 ?
                 (max.x - supportVector.x) / directionVector.x :
                 (min.x - supportVector.x) / directionVector.x;
        }

        if (Mathf.Abs(directionVector.y) > 0.0001f)
        {
            ty = directionVector.y > 0 ?
                 (max.y - supportVector.y) / directionVector.y :
                 (min.y - supportVector.y) / directionVector.y;
        }

        return getPoint(Mathf.Min(tx, ty));
    }
}

````