# Les: Vectoren optellen, aftrekken en scalair vermenigvuldigen

## Leerdoelen
Na deze les kun je:
- twee vectoren bij elkaar optellen;
- twee vectoren van elkaar aftrekken;
- een vector met een scalair (een getal) vermenigvuldigen;
- deze bewerkingen grafisch interpreteren;
- combinaties van vectorbewerkingen uitrekenen.

---

## 1. Wat is een vector?

Een vector heeft een **grootte** en een **richting**. We schrijven een vector bijvoorbeeld als:

$$
\vec{a}=\langle 2,3\rangle
$$

Dit betekent:
- 2 eenheden in de positieve $x$-richting;
- 3 eenheden in de positieve $y$-richting.

In een assenstelsel kun je $\vec{a}$ tekenen als een pijl van $(0,0)$ naar $(2,3)$.

> **Belangrijk:** bij berekeningen met vectoren behandel je de $x$- en $y$-component afzonderlijk.

---

## 2. Vectoren optellen

Gegeven:

$$
\vec{a}=\langle 2,3\rangle
\qquad
\vec{b}=\langle 4,1\rangle
$$

Om de vectoren op te tellen, tel je de overeenkomstige componenten op:

$$
\vec{a}+\vec{b}
=\langle 2+4,\;3+1\rangle
=\langle 6,4\rangle
$$

### Regel

Als

$$
\vec{a}=\langle a_x,a_y\rangle
\quad\text{en}\quad
\vec{b}=\langle b_x,b_y\rangle,
$$

dan geldt:

$$
\boxed{\vec{a}+\vec{b}=\langle a_x+b_x,\;a_y+b_y\rangle}
$$

### Grafisch

Je kunt vectoren grafisch optellen met de **kop-staartmethode**:
1. teken $\vec{a}$;
2. verplaats $\vec{b}$ zonder de lengte of richting te veranderen, zodat het begin van $\vec{b}$ bij de punt van $\vec{a}$ ligt;
3. de vector van het beginpunt van $\vec{a}$ naar het eindpunt van $\vec{b}$ is $\vec{a}+\vec{b}$.

---

## 3. Vectoren aftrekken

Gegeven:

$$
\vec{a}=\langle 4,-2\rangle
\qquad
\vec{b}=\langle 1,5\rangle
$$

Trek opnieuw de overeenkomstige componenten van elkaar af:

$$
\vec{a}-\vec{b}
=\langle 4-1,\;-2-5\rangle
=\langle 3,-7\rangle
$$

### Regel

$$
\boxed{\vec{a}-\vec{b}=\langle a_x-b_x,\;a_y-b_y\rangle}
$$

Aftrekken kun je ook zien als het optellen van de tegengestelde vector:

$$
\vec{a}-\vec{b}=\vec{a}+(-\vec{b})
$$

De vector $-\vec{b}$ heeft dezelfde lengte als $\vec{b}$, maar wijst precies de andere kant op.

---

## 4. Een vector scalair vermenigvuldigen

Een **scalair** is een gewoon getal. Bij scalaire vermenigvuldiging vermenigvuldig je **iedere component** van de vector met dat getal.

Gegeven:

$$
\vec{a}=\langle 3,2\rangle
$$

Bereken $2\vec{a}$:

$$
2\vec{a}
=2\langle 3,2\rangle
=\langle 6,4\rangle
$$

### Regel

Voor een scalair $k$ geldt:

$$
\boxed{k\vec{a}=\langle ka_x,\;ka_y\rangle}
$$

### Wat gebeurt er grafisch?

- $k>1$: de vector wordt langer.
- $0<k<1$: de vector wordt korter.
- $k<0$: de richting draait om en de lengte verandert met factor $|k|$.
- $k=0$: je krijgt de nulvector $\langle 0,0\rangle$.

### Voorbeeld met een negatief getal

Als

$$
\vec{b}=\langle -2,3\rangle,
$$

dan is

$$
-3\vec{b}
=\langle (-3)(-2),\;(-3)(3)\rangle
=\langle 6,-9\rangle.
$$

---

## 5. Combinaties van bewerkingen

Gegeven:

$$
\vec{a}=\langle 1,4\rangle
\qquad
\vec{b}=\langle 3,-2\rangle
$$

Bereken:

$$
2\vec{a}+\vec{b}
$$

Eerst vermenigvuldig je $\vec{a}$ met 2:

$$
2\vec{a}=\langle 2,8\rangle
$$

Daarna tel je $\vec{b}$ erbij op:

$$
2\vec{a}+\vec{b}
=\langle 2,8\rangle+\langle 3,-2\rangle
=\langle 5,6\rangle
$$

> **Aanpak:** voer eerst de scalaire vermenigvuldiging uit en tel of trek daarna de vectoren component voor component op of af.

---

## 6. Samenvatting

| Bewerking | Regel |
|---|---|
| Optellen | $\vec{a}+\vec{b}=\langle a_x+b_x,\;a_y+b_y\rangle$ |
| Aftrekken | $\vec{a}-\vec{b}=\langle a_x-b_x,\;a_y-b_y\rangle$ |
| Scalair vermenigvuldigen | $k\vec{a}=\langle ka_x,\;ka_y\rangle$ |

### Onthoud

**Werk altijd component voor component:** $x$ bij $x$ en $y$ bij $y$.

---

## 7. Oefenen

Bereken de volgende vectoren.

1. $\vec{a}=\langle 2,3\rangle$ en $\vec{b}=\langle 4,-1\rangle$. Bereken $\vec{a}+\vec{b}$.
2. $\vec{a}=\langle 5,2\rangle$ en $\vec{b}=\langle 1,6\rangle$. Bereken $\vec{a}-\vec{b}$.
3. $\vec{a}=\langle -2,4\rangle$. Bereken $3\vec{a}$.
4. $\vec{b}=\langle 3,-1\rangle$. Bereken $-2\vec{b}$.
5. $\vec{a}=\langle 1,2\rangle$ en $\vec{b}=\langle 4,3\rangle$. Bereken $2\vec{a}+\vec{b}$.
6. $\vec{a}=\langle -1,3\rangle$ en $\vec{b}=\langle 2,-2\rangle$. Bereken $3\vec{a}-2\vec{b}$.

---

## 8. Antwoorden

1. $\langle 6,2\rangle$
2. $\langle 4,-4\rangle$
3. $\langle -6,12\rangle$
4. $\langle -6,2\rangle$
5. $\langle 6,7\rangle$
6. $\langle -7,13\rangle$
