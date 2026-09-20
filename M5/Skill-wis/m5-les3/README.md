# Les: Een rechte in het 2D-vlak definiëren met een steunvector en een richtingsvector

## 1. Leerdoelen

Na deze les kun je:

* Uitleggen wat een steunvector en een richtingsvector zijn.
* Een rechte in het 2D-vlak beschrijven met behulp van vectoren.
* De vectorvergelijking van een rechte opstellen.
* De vectorvergelijking omzetten naar parametervergelijkingen.
* Controleren of een punt op een gegeven rechte ligt.

---

## 2. Wat heb je nodig om een rechte te definiëren?

In een tweedimensionaal vlak (2D-vlak) kun je een rechte volledig vastleggen met twee gegevens:

1. Een **steunvector**: een vector die vanuit de oorsprong naar een vast punt op de rechte wijst.
2. Een **richtingsvector**: een vector die aangeeft in welke richting de rechte loopt.

Stel dat we een rechte \(l\) hebben die door het punt

$$
A(2,3)
$$

loopt en als richtingsvector heeft:

$$
\vec{v}=
\begin{pmatrix}
4\\
1
\end{pmatrix}
$$

De steunvector is dan:

$$
\vec{a}=
\begin{pmatrix}
2\\
3
\end{pmatrix}
$$

Met deze twee vectoren kunnen we alle punten op de rechte bepalen.

---

## 3. De steunvector

Een steunvector is een vector die vanuit de oorsprong \(O(0,0)\) naar een punt op de rechte wijst.

Als een rechte bijvoorbeeld door het punt \(A(2,3)\) loopt, dan is de steunvector:

$$
\vec{a}=\overrightarrow{OA}=
\begin{pmatrix}
2\\
3
\end{pmatrix}
$$

De steunvector vertelt ons dus **waar de rechte zich bevindt in het vlak**.

### Belangrijk

Een rechte heeft niet één unieke steunvector.

Elk punt op de rechte kan gebruikt worden om een steunvector te maken.

---

## 4. De richtingsvector

Een richtingsvector geeft aan in welke richting een rechte loopt.

Bijvoorbeeld:

$$
\vec{v}=
\begin{pmatrix}
4\\
1
\end{pmatrix}
$$

Dit betekent dat we, wanneer we vanaf een punt op de rechte bewegen:

* 4 eenheden naar rechts gaan;
* 1 eenheid omhoog gaan.

We komen dan opnieuw op een punt van dezelfde rechte terecht.

Als we starten bij \(A(2,3)\), krijgen we:

$$
B=(2+4,3+1)
$$

Dus:

$$
B=(6,4)
$$

Beide punten liggen op dezelfde rechte.

We kunnen ook in de tegenovergestelde richting bewegen:

$$
C=(2-4,3-1)
$$

$$
C=(-2,2)
$$

Ook dit punt ligt op de rechte.

### Belangrijk

Een richtingsvector mag nooit de nulvector zijn:

$$
\vec{v}\neq
\begin{pmatrix}
0\\
0
\end{pmatrix}
$$

Een nulvector geeft namelijk geen richting aan.

---

# 5. De vectorvergelijking van een rechte

We kunnen een rechte definiëren met de volgende formule:

$$
\boxed{\vec{r}=\vec{a}+t\vec{v}}
$$

Hierbij is:

| Symbool     | Betekenis                                             |
| ----------- | ----------------------------------------------------- |
| \(\vec{r}\) | De plaatsvector van een willekeurig punt op de rechte |
| \(\vec{a}\) | De steunvector                                        |
| \(\vec{v}\) | De richtingsvector                                    |
| \(t\)       | Een reëel getal, de parameter                         |

De parameter \(t\) bepaalt hoe ver en in welke richting we vanaf het steunpunt bewegen.

Omdat \(t\) elk reëel getal mag zijn, kunnen we elk punt op de rechte bereiken.

---

## 6. Een uitgewerkt voorbeeld

Gegeven zijn het punt:

$$
A(2,3)
$$

en de richtingsvector:

$$
\vec{v}=
\begin{pmatrix}
4\\
1
\end{pmatrix}
$$

We willen de vectorvergelijking van de rechte opstellen.

### Stap 1: Bepaal de steunvector

Omdat de rechte door \(A(2,3)\) loopt:

$$
\vec{a}=
\begin{pmatrix}
2\\
3
\end{pmatrix}
$$

### Stap 2: Noteer de richtingsvector

$$
\vec{v}=
\begin{pmatrix}
4\\
1
\end{pmatrix}
$$

### Stap 3: Vul de vectorvergelijking in

We gebruiken:

$$
\vec{r}=\vec{a}+t\vec{v}
$$

Dit geeft:

$$
\boxed{
\begin{pmatrix}
x\\
y
\end{pmatrix}
=
\begin{pmatrix}
2\\
3
\end{pmatrix}
+
t
\begin{pmatrix}
4\\
1
\end{pmatrix}
}
$$

met:

$$
t\in\mathbb{R}
$$

Dit is de vectorvergelijking van onze rechte.

---

# 7. De parametervergelijkingen van een rechte

We kunnen de vectorvergelijking ook uitschrijven in afzonderlijke vergelijkingen voor \(x\) en \(y\).

We beginnen met:

$$
\begin{pmatrix}
x\\
y
\end{pmatrix}
=
\begin{pmatrix}
2\\
3
\end{pmatrix}
+
t
\begin{pmatrix}
4\\
1
\end{pmatrix}
$$

We vermenigvuldigen de richtingsvector met \(t\):

$$
\begin{pmatrix}
x\\
y
\end{pmatrix}
=
\begin{pmatrix}
2\\
3
\end{pmatrix}
+
\begin{pmatrix}
4t\\
t
\end{pmatrix}
$$

Daaruit volgt:

$$
\boxed{
\begin{cases}
x=2+4t\\
y=3+t
\end{cases}
}
$$

met:

$$
t\in\mathbb{R}
$$

Dit noemen we de **parametervergelijkingen van de rechte**.

---

# 8. Wat doet de parameter \(t\)?

Laten we verschillende waarden van \(t\) invullen in:

$$
\begin{cases}
x=2+4t\\
y=3+t
\end{cases}
$$

| Parameter \(t\) | \(x=2+4t\) | \(y=3+t\) | Punt       |
| --------------- | ---------- | --------- | ---------- |
| \(-2\)          | \(-6\)     | \(1\)     | \((-6,1)\) |
| \(-1\)          | \(-2\)     | \(2\)     | \((-2,2)\) |
| \(0\)           | \(2\)      | \(3\)     | \((2,3)\)  |
| \(1\)           | \(6\)      | \(4\)     | \((6,4)\)  |
| \(2\)           | \(10\)     | \(5\)     | \((10,5)\) |

Al deze punten liggen op dezelfde rechte.

We kunnen hieruit afleiden:

* Bij \(t=0\) bevinden we ons op het steunpunt.
* Bij \(t>0\) bewegen we in de richting van de richtingsvector.
* Bij \(t<0\) bewegen we in de tegenovergestelde richting.

**De parameter bepaalt dus onze positie op de rechte.**

---

# 9. Van twee punten naar een vectorvergelijking

Soms krijgen we geen richtingsvector, maar twee punten op de rechte.

Stel dat een rechte door de volgende punten loopt:

$$
A(1,2)
$$

en

$$
B(5,4)
$$

Hoe stellen we de vectorvergelijking op?

### Stap 1: Kies een steunpunt

We kiezen punt \(A\).

De steunvector is:

$$
\vec{a}=
\begin{pmatrix}
1\\
2
\end{pmatrix}
$$

### Stap 2: Bereken de richtingsvector

De richtingsvector kunnen we berekenen door de coördinaten van \(A\) af te trekken van die van \(B\):

$$
\vec{v}=\overrightarrow{AB}
$$

$$
\vec{v}=
\begin{pmatrix}
5-1\\
4-2
\end{pmatrix}
$$

Dus:

$$
\vec{v}=
\begin{pmatrix}
4\\
2
\end{pmatrix}
$$

### Stap 3: Stel de vectorvergelijking op

$$
\boxed{
\begin{pmatrix}
x\\
y
\end{pmatrix}
=
\begin{pmatrix}
1\\
2
\end{pmatrix}
+
t
\begin{pmatrix}
4\\
2
\end{pmatrix}
}
$$

De parametervergelijkingen zijn:

$$
\boxed{
\begin{cases}
x=1+4t\\
y=2+2t
\end{cases}
}
$$

---

# 10. Controleren of een punt op een rechte ligt

Gegeven is de rechte:

$$
\begin{cases}
x=1+4t\\
y=2+2t
\end{cases}
$$

We willen controleren of het punt:

$$
P(9,6)
$$

op deze rechte ligt.

### Stap 1: Vul de x-coördinaat in

$$
9=1+4t
$$

$$
8=4t
$$

$$
t=2
$$

### Stap 2: Controleer de y-coördinaat

We vullen dezelfde parameterwaarde in:

$$
y=2+2(2)
$$

$$
y=6
$$

Dit komt overeen met de y-coördinaat van \(P\).

Dus:

$$
\boxed{P(9,6)\text{ ligt op de rechte.}}
$$

**Let op:** Beide coördinaten moeten kloppen voor dezelfde waarde van \(t\).

---

# 11. Oefeningen

## Oefening 1: Een vectorvergelijking opstellen

Een rechte loopt door het punt:

$$
A(3,1)
$$

en heeft als richtingsvector:

$$
\vec{v}=
\begin{pmatrix}
2\\
5
\end{pmatrix}
$$

**Opdrachten:**

1. Geef de steunvector.
2. Stel de vectorvergelijking op.
3. Stel de parametervergelijkingen op.
4. Bereken het punt waarvoor \(t=2\).

## Oefening 2: Een richtingsvector berekenen

Een rechte loopt door de punten:

$$
A(2,4)
$$

en

$$
B(6,10)
$$

**Opdrachten:**

1. Bereken de richtingsvector \(\overrightarrow{AB}\).
2. Kies een steunvector.
3. Stel de vectorvergelijking van de rechte op.
4. Stel de parametervergelijkingen op.

## Oefening 3: Ligt het punt op de rechte?

Gegeven is:

$$
\begin{cases}
x=2+3t\\
y=1+2t
\end{cases}
$$

Controleer of de volgende punten op de rechte liggen:

* \(P(5,3)\)
* \(Q(8,5)\)
* \(R(11,6)\)

---

# 12. Samenvatting

Om een rechte in een 2D-vlak te definiëren, hebben we een steunvector en een richtingsvector nodig.

De algemene vectorvergelijking is:

$$
\boxed{\vec{r}=\vec{a}+t\vec{v}}
$$

Als:

$$
\vec{a}=
\begin{pmatrix}
a_x\\
a_y
\end{pmatrix}
$$

en:

$$
\vec{v}=
\begin{pmatrix}
v_x\\
v_y
\end{pmatrix}
$$

dan krijgen we:

$$
\boxed{
\begin{pmatrix}
x\\
y
\end{pmatrix}
=
\begin{pmatrix}
a_x\\
a_y
\end{pmatrix}
+
t
\begin{pmatrix}
v_x\\
v_y
\end{pmatrix}
}
$$

Of als parametervergelijkingen:

$$
\boxed{
\begin{cases}
x=a_x+tv_x\\
y=a_y+tv_y
\end{cases}
}
$$

waarbij:

$$
t\in\mathbb{R}
$$

en:

$$
\vec{v}\neq\vec{0}
$$

**Onthoud: de steunvector bepaalt waar de rechte ligt, de richtingsvector bepaalt hoe de rechte loopt en de parameter bepaalt welk punt op de rechte we bereiken.**
