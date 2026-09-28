# Bal laten botsen tegen schermranden met matrices in Unity

## 1. Het idee

We hebben in Unity een bal die met een **constante snelheid** beweegt. De snelheid van de bal stellen we voor als een vector:

$
\vec{v} =
\begin{bmatrix}
v_x \\
v_y
\end{bmatrix}
$

Hierbij is:

- \(v_x\) de snelheid in de horizontale richting.
- \(v_y\) de snelheid in de verticale richting.

Wanneer de bal tegen een rand botst, willen we de juiste component van de snelheid omkeren. Dit kunnen we doen met een **reflectiematrix**.

---

## 2. Botsen tegen de linker- of rechterrand

Wanneer de bal tegen de **linker- of rechterrand** botst, moet hij horizontaal terugkaatsen.

Daarom veranderen we:


$v_x \rightarrow -v_x$


terwijl $v_y$ hetzelfde blijft.

Dit kan met de matrix:


$R_x =
\begin{bmatrix}
-1 & 0 \\
0 & 1
\end{bmatrix}$

De nieuwe snelheid wordt:


$\vec{v}_{nieuw} = R_x \vec{v}$


Bijvoorbeeld:


````math
\begin{bmatrix}
-1 & 0 \\
0 & 1
\end{bmatrix}

\begin{bmatrix}
4 \\
2
\end{bmatrix}
=
\begin{bmatrix}
-4 \\
2
\end{bmatrix}
````


De bal ging eerst naar rechts en omhoog `(4, 2)` en gaat daarna naar links en omhoog `(-4, 2)`.

---

## 3. Botsen tegen de boven- of onderrand

Bij een botsing met de **boven- of onderrand** moet juist de verticale snelheid worden omgekeerd:


$v_y \rightarrow -v_y$

De matrix hiervoor is:

````math
R_y =
\begin{bmatrix}
1 & 0 \\
0 & -1
\end{bmatrix}\
````

Dus:


$\vec{v}_{nieuw} = R_y \vec{v}$


Bijvoorbeeld:

````math
\begin{bmatrix}
1 & 0 \\
0 & -1
\end{bmatrix}
\begin{bmatrix}
4 \\
2
\end{bmatrix}
=
\begin{bmatrix}
4 \\
-2
\end{bmatrix}
````

De bal gaat nu naar rechts en **omlaag**.

---

## 4. Implementatie in Unity

In Unity kunnen we hiervoor een `Vector2` gebruiken voor de snelheid.

```csharp
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 velocity = new Vector2(4f, 2f);

    void Update()
    {
        // Beweeg de bal
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }

    void ReflectX()
    {
        // Matrix:
        // [-1  0]
        // [ 0  1]

        float newX = -1 * velocity.x + 0 * velocity.y;
        float newY =  0 * velocity.x + 1 * velocity.y;

        velocity = new Vector2(newX, newY);
    }

    void ReflectY()
    {
        // Matrix:
        // [1   0]
        // [0  -1]

        float newX = 1 * velocity.x +  0 * velocity.y;
        float newY = 0 * velocity.x + -1 * velocity.y;

        velocity = new Vector2(newX, newY);
    }
}
```

---

## 5. De randen controleren

Stel dat het speelveld loopt van:

- links: `x = -8`
- rechts: `x = 8`
- onder: `y = -4`
- boven: `y = 4`

Dan kunnen we in `Update()` controleren of de bal een rand raakt:

```csharp
void Update()
{
    transform.position += (Vector3)(velocity * Time.deltaTime);

    Vector3 position = transform.position;

    // Linker- of rechterrand
    if (position.x <= -8f || position.x >= 8f)
    {
        ReflectX();
    }

    // Boven- of onderrand
    if (position.y <= -4f || position.y >= 4f)
    {
        ReflectY();
    }
}
```

---

## 6. Waarom blijft de snelheid constant?

Een reflectie verandert alleen de **richting** van de snelheidsvector, niet de lengte ervan.

Voor de botsing:


$|\vec{v}| = \sqrt{v_x^2 + v_y^2}$


Na een botsing met bijvoorbeeld de rechterrand:

````math
|\vec{v}_{nieuw}| =
\sqrt{(-v_x)^2 + v_y^2}
````

Omdat:


$(-v_x)^2 = v_x^2$


krijgen we:


$|\vec{v}_{nieuw}| = |\vec{v}|$


De **richting verandert**, maar de **snelheid blijft dus constant**.

---

## Samenvatting

Bij een botsing met de **linker- of rechterrand** gebruiken we:

````math
\boxed{
\begin{bmatrix}
-1 & 0 \\
0 & 1
\end{bmatrix}}
````

Hierdoor wordt de **x-snelheid omgekeerd**.

Bij een botsing met de **boven- of onderrand** gebruiken we:

````math
\boxed{
\begin{bmatrix}
1 & 0 \\
0 & -1
\end{bmatrix}}
````

Hierdoor wordt de **y-snelheid omgekeerd**.

Op deze manier kan een bal in Unity met een constante snelheid tegen alle vier de randen van het speelveld blijven kaatsen.