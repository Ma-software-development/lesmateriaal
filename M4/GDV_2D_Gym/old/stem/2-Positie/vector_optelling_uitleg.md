

# Overzicht: Waar gebruikt Unity vectoren voor?

Unity gebruikt vectoren op veel plekken in een game of interactieve applicatie. Hieronder een handig overzicht.

---

## 📍 1. Positie
Vectoren geven de **positie** van een object aan in de wereld.
```csharp
transform.position = new Vector3(0, 5, 10);
```
Dit plaatst een object op x = 0, y = 5, z = 10.

---

## 📍 2. Richting en beweging
Vectoren beschrijven **richting en snelheid**.
- `transform.forward` → richting waarin een object kijkt.
- `rigidbody.velocity` → snelheid en bewegingsrichting.

```csharp
Vector3 move = transform.forward * speed * Time.deltaTime;
transform.position += move;
```

---

## 📍 3. Schaal
Vectoren bepalen de **schaal** van een object.
```csharp
transform.localScale = new Vector3(2, 2, 2);
```
Vergroot het object 2x in alle richtingen.

---

## 📍 4. Rotaties en oriëntaties
Hoewel rotaties meestal met quaternions werken, worden vectoren gebruikt voor rotatie-assen en richtingen.
```csharp
transform.Rotate(Vector3.up, 90);
```

---

## 📍 5. Fysica en krachten
Vectoren zijn essentieel voor physics:
- krachten (`AddForce`)
- impulsen
- versnelling

```csharp
rigidbody.AddForce(new Vector3(0, 10, 0));
```

---

## 📍 6. Afstanden en botsingen
Vectoren helpen bij:
- afstanden meten (`Vector3.Distance`)
- raycasts uitvoeren
- botsingen berekenen

```csharp
float afstand = Vector3.Distance(obj1.position, obj2.position);
```

---

## 📍 7. Animaties en paden
Bij animaties of bewegen over een pad gebruik je vector-interpolatie.
```csharp
Vector3 tussenpunt = Vector3.Lerp(start, end, 0.5f);
```

---

## ➥ Samengevat
Unity gebruikt vectoren voor bijna alles dat met positie, richting, schaal, fysica en beweging te maken heeft. Het is een kernconcept dat je zeker wilt beheersen als Unity-ontwikkelaar! 🚀


# Uitleg: Een GameObject positioneren met het Transform-component in Unity

In Unity kun je de positie van een GameObject aanpassen door het **Transform-component** te gebruiken. Dit doe je met behulp van een **Vector3**, die de x-, y- en z-coördinaten bevat.

---

## 📍 Stap 1: Toegang krijgen tot het Transform-component

Elk GameObject in Unity heeft standaard een `Transform`-component.  
Je kunt hier in C# bij met:
```csharp
transform
```

Bijvoorbeeld in een script:
```csharp
public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        // Code komt hier
    }
}
```

---

## 📍 Stap 2: Maak een Vector3 aan met de gewenste positie

Een **Vector3** wordt aangemaakt met:
```csharp
Vector3 positie = new Vector3(x, y, z);
```

Voorbeeld:
```csharp
Vector3 positie = new Vector3(0, 5, 10);
```

---

## 📍 Stap 3: Wijs de positie toe aan het Transform-component

Gebruik:
```csharp
transform.position = positie;
```



Volledig voorbeeld:
```csharp
public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        Vector3 nieuwePositie = new Vector3(0, 5, 10);
        transform.position = nieuwePositie;
    }
}
```

---

## 📦 Samengevat

- Gebruik **Vector3** om de gewenste positie te definiëren.
- Wijs die positie toe aan `transform.position`.
- Pas eventueel alleen specifieke assen aan als dat nodig is.

Dit is een basisvaardigheid die je vaak zult gebruiken in Unity! 🚀




# Uitleg: Twee 3D-vectoren optellen

## Stap 1: Schrijf de vectoren op

Stel je hebt twee 3D-vectoren:

$$\mathbf{v_1} = \begin{bmatrix}
 x_1\\
 y_1\\
z_1
\end{bmatrix} $$

$$\mathbf{v_2} = \begin{bmatrix}
 x_2\\
 y_2\\
z_2
\end{bmatrix}$$

Dan is de som van beide vectoren

$$\mathbf{v_1} + \mathbf{v_2} = \begin{bmatrix}
 x_1 +x_2\\
 y_1 + y_2\\
z_1 +z_2
\end{bmatrix}$$
---

## Stap 2: Tel de overeenkomstige componenten op

Tel de **x-, y-, en z-componenten** apart bij elkaar op:

$$\mathbf{v_1} = \begin{bmatrix}
2\\
3\\
5
\end{bmatrix} $$

$$\mathbf{v_2} = \begin{bmatrix}
1\\
-1\\
-2
\end{bmatrix} $$

$$
\mathbf{v_1} + \mathbf{v_2} =\begin{bmatrix}
2\\
3\\
5
\end{bmatrix} + \begin{bmatrix}
1\\
-1\\
-2
\end{bmatrix} = \begin{bmatrix}
3\\
2\\
3
\end{bmatrix}
$$



---

## Stap 3: Schrijf het resultaat op als de nieuwe vector

De somvector is:
\[
\mathbf{v_1} + \mathbf{v_2} = (6, 2, 7)
\]

---

## Samengevat

**Formule:**

\[
(x_1, y_1, z_1) + (x_2, y_2, z_2) = (x_1 + x_2, \; y_1 + y_2, \; z_1 + z_2)
\]

**Voorbeeld:**

\[
(2, 3, 5) + (4, -1, 2) = (6, 2, 7)
\]

---

## Afbeelding

![Vector optelling](path/to/your/image.png)

---

Als je wilt, kan ik de afbeelding voor je meeleveren als bestand!
