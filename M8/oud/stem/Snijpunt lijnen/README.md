

# De regel van Cramer in ℝ²

De regel van Cramer is een methode om een stelsel van lineaire vergelijkingen op te lossen met behulp van determinanten. Het werkt goed bij kleine stelsels, vooral in ℝ² en ℝ³.

---

## Algemeen stelsel in ℝ²

Beschouw het volgende stelsel:

$$
\begin{cases}
a_1 x + b_1 y = c_1 \\
a_2 x + b_2 y = c_2
\end{cases}
$$

In matrixvorm:

$$
\begin{bmatrix}
a_1 & b_1 \\
a_2 & b_2
\end{bmatrix}
\begin{bmatrix}
x \\
y
\end{bmatrix}
=
\begin{bmatrix}
c_1 \\
c_2
\end{bmatrix}
$$

---
# Wat is een determinant van een matrix en waar gebruik je het voor?

De determinant is een getal dat je kunt berekenen uit een vierkante matrix. Het vertelt je belangrijke eigenschappen over die matrix, zoals of hij inverteerbaar is, of een stelsel lineaire vergelijkingen een unieke oplossing heeft, en hoeveel de matrix de ruimte “opschaalt” of “vervormt”.

---

## Definitie

Voor een $2 \times 2$ matrix:

$$
A = \begin{bmatrix}
a & b \\
c & d
\end{bmatrix}
$$

is de determinant:

$$
\det(A) = ad - bc
$$

Voor een $3 \times 3$ matrix:

$$
A = \begin{bmatrix}
a & b & c \\
d & e & f \\
g & h & i
\end{bmatrix}
$$

is de determinant:

$$
\det(A) = a(ei - fh) - b(di - fg) + c(dh - eg)
$$

Bij grotere matrices gebruik je cofactor-expansie of andere methoden.

---

## Geometrische betekenis

- Bij $2 \times 2$ matrices: de determinant geeft de schaalfactor voor oppervlakte.
- Bij $3 \times 3$ matrices: de determinant geeft de schaalfactor voor volume.
- Als de determinant negatief is, betekent dat een spiegeling in de ruimte.
- Als de determinant nul is, is de afbeelding niet-inverteerbaar en “platgedrukt” op een lagere dimensie.

---

## Waar gebruik je de determinant voor?

✅ **Bepalen of een matrix inverteerbaar is**

- Als $\det(A) \neq 0$, dan bestaat de inverse $A^{-1}$.
- Als $\det(A) = 0$, dan bestaat de inverse niet.

✅ **Oplossen van stelsels (regel van Cramer)**

- Je gebruikt de determinant om met de regel van Cramer $2 \times 2$ of $3 \times 3$ stelsels van vergelijkingen op te lossen.

✅ **Berekenen van eigenwaarden**

- Bij het vinden van eigenwaarden gebruik je de determinant van $A - \lambda I$.

✅ **Geometrische toepassingen**

- De determinant vertelt hoe een transformatie de ruimte vervormt.
- Het bepaalt ook oriëntatie (positief of negatief) na een transformatie.

---

## Samengevat

- De determinant is een enkel getal dat je uit een vierkante matrix kunt berekenen.
- Het vertelt je belangrijke dingen over de matrix:
    - Inverteerbaarheid
    - Schaalfactor
    - Spiegeling of oriëntatie
- Het is een krachtig hulpmiddel bij het oplossen van lineaire algebra-problemen.

---



## Stap 1: Bereken de hoofddeterminant

De hoofddeterminant $D$ is:

$$
D = 
\begin{vmatrix}
a_1 & b_1 \\
a_2 & b_2
\end{vmatrix}
= a_1 b_2 - a_2 b_1
$$

Als $D \neq 0$, heeft het stelsel precies één oplossing.

---

## Stap 2: Bereken de determinant voor $x$

Vervang de eerste kolom (de $x$-kolom) door de rechterkant:

$$
D_x =
\begin{vmatrix}
c_1 & b_1 \\
c_2 & b_2
\end{vmatrix}
= c_1 b_2 - c_2 b_1
$$

---

## Stap 3: Bereken de determinant voor $y$

Vervang de tweede kolom (de $y$-kolom) door de rechterkant:

$$
D_y =
\begin{vmatrix}
a_1 & c_1 \\
a_2 & c_2
\end{vmatrix}
= a_1 c_2 - a_2 c_1
$$

---

## Stap 4: Bereken de oplossingen

De oplossingen zijn:

$$
x = \frac{D_x}{D}, \quad y = \frac{D_y}{D}
$$

---

## Voorbeeld

Los op:

$$
\begin{cases}
2x + 3y = 5 \\
4x - y = 6
\end{cases}
$$

**Stap 1:**

$$
D = (2)(-1) - (4)(3) = -2 -12 = -14
$$

**Stap 2:**

$$
D_x = (5)(-1) - (6)(3) = -5 -18 = -23
$$

**Stap 3:**

$$
D_y = (2)(6) - (4)(5) = 12 -20 = -8
$$

**Stap 4:**

$$
x = \frac{-23}{-14} = \frac{23}{14}, \quad y = \frac{-8}{-14} = \frac{4}{7}
$$

✅ Oplossing:

$$
x = \frac{23}{14}, \quad y = \frac{4}{7}
$$

---

## Belangrijke opmerkingen

- Als $D = 0$ en $D_x$ of $D_y \neq 0$, dan is het stelsel **sprakeloos** (geen oplossing).
- Als $D = 0$ en $D_x = D_y = 0$, dan is het stelsel **onbepaald** (oneindig veel oplossingen).

---


# Snijpunt van twee lijnen in ℝ² met matrixmethode

We zoeken het snijpunt van de volgende lijnen:

$$
L_1: (1, 2) + t (3, 4)
$$
$$
L_2: (2, 0) + s (-1, 2)
$$

---

## Stap 1: Opstellen van de vergelijkingen

Schrijf de parametervoorstellingen uit als stelsel:

$$
\begin{cases}
1 + 3t = 2 - s \\
2 + 4t = 0 + 2s
\end{cases}
$$

Herschrijf:

$$
\begin{cases}
3t + s = 1 \\
4t - 2s = -2
\end{cases}
$$

---

## Stap 2: Matrixvorm

$$
\begin{bmatrix}
3 & 1 \\
4 & -2
\end{bmatrix}
\begin{bmatrix}
t \\
s
\end{bmatrix}
=
\begin{bmatrix}
1 \\
-2
\end{bmatrix}
$$

Noem:

$$
A = \begin{bmatrix} 3 & 1 \\ 4 & -2 \end{bmatrix}, \quad 
\mathbf{x} = \begin{bmatrix} t \\ s \end{bmatrix}, \quad
\mathbf{b} = \begin{bmatrix} 1 \\ -2 \end{bmatrix}
$$

---

## Stap 3: Los op

**Determinant:**

$$
\det(A) = 3 \times (-2) - 4 \times 1 = -6 -4 = -10 \neq 0
$$

**Inverse van A:**

$$
A^{-1} = \frac{1}{\det(A)} \begin{bmatrix} -2 & -1 \\ -4 & 3 \end{bmatrix} 
= \frac{1}{-10} \begin{bmatrix} -2 & -1 \\ -4 & 3 \end{bmatrix}
= \begin{bmatrix} 0.2 & 0.1 \\ 0.4 & -0.3 \end{bmatrix}
$$

**Bereken $\mathbf{x}$:**

$$
\mathbf{x} = A^{-1} \mathbf{b}
= \begin{bmatrix} 0.2 & 0.1 \\ 0.4 & -0.3 \end{bmatrix}
\begin{bmatrix} 1 \\ -2 \end{bmatrix}
$$

Reken uit:

$$
t = 0.2 \times 1 + 0.1 \times (-2) = 0.2 - 0.2 = 0
$$
$$
s = 0.4 \times 1 + (-0.3) \times (-2) = 0.4 + 0.6 = 1
$$

**Oplossing:**

$$
t = 0, \quad s = 1
$$

---

## Stap 4: Bereken het snijpunt

Gebruik $L_1$ (of $L_2$):

$$
\mathbf{P} = (1,2) + 0 \times (3,4) = (1,2)
$$
$$
\mathbf{P} = (2,0) +1 \times (-1,2) = (2 -1,0 +2) = (1,2)
$$

✅ Controle klopt.

---

## Eindantwoord

**Het snijpunt is:**

$$
\boxed{(1,2)}
$$

---
