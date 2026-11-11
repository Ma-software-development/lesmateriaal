Ik kan geen daadwerkelijk README.md-bestand genereren of opslaan, maar ik kan wel de inhoud leveren.

Omdat een volledige README met alle 25 lessen, uitgebreide theorie, alle afbeeldingen, LaTeX-afleidingen, Unity-voorbeelden, opdrachten en uitwerkingen vele tientallen pagina's Markdown omvat, past dat niet in één antwoord.

Wel kan ik direct een volledige README v1-structuur leveren die als basis dient voor het lesboek.

README.md
# Lineaire Algebra voor Game Developers

## Over deze module

Lineaire algebra vormt de wiskundige basis van moderne game development. Vectoren, lijnen, projecties, matrices, normaalvectoren en reflecties worden gebruikt om objecten te positioneren, bewegen, laten botsen en transformeren. 

---

# Leerroute

## Module 1 - Vectoren

1. Draggable Point
2. GVector
3. Vectoroptelling
4. Vectoraftrekking
5. Scalaire vermenigvuldiging
6. Toepassingen in driehoeken

## Module 2 - Magnitude en Normaliseren

7. Magnitude
8. Normaliseren
9. Vector Resolution

## Module 3 - Lijnen

10. Geparametriseerde lijn
11. Intersections
12. Bissectrice
13. Polar Coordinates

## Module 4 - Driehoeksmeetkunde

14. Perpendicular
15. Hoogtelijnen
16. Circumcenter
17. Incenter

## Module 5 - Projecties

18. Dot Product
19. Orthonormale Basis
20. Gravity in Space

## Module 6 - Matrices

21. Matrixtransformaties
22. Rotaties
23. Reflecties

## Module 7 - Collision Detection

24. Orient2D
25. Normaalvectoren
26. Velocity Resolution
27. Reflectiematrix

---

# Les 1 - Draggable Point

## Leerdoelen

- Werken met coördinaten
- Punten positioneren
- Posities visualiseren

## Theorie

Een punt beschrijft een positie in een vlak.

$$
P=(x,y)
$$

Voorbeeld:

$$
P=(3,5)
$$

Dit betekent:

- 3 naar rechts
- 5 omhoog

### Illustratie



### Opdracht

Maak een punt dat met de muis versleept kan worden.

---

# Les 2 - GVector

## Leerdoelen

- Begrijpen wat een vector is
- Richting en grootte herkennen

## Theorie

Een vector bestaat uit een richting en een grootte.

$$
\vec{v}=
\begin{bmatrix}
x\\
y
\end{bmatrix}
$$

Voorbeeld:

$$
\vec{v}=
\begin{bmatrix}
3\\
4
\end{bmatrix}
$$

### Illustratie



---

# Les 3 - Vectoroptelling

## Theorie

Twee vectoren worden componentgewijs opgeteld.

$$
\vec{a}+\vec{b}
=
\begin{bmatrix}
a_x+b_x\\
a_y+b_y
\end{bmatrix}
$$

Voorbeeld:

$$
\begin{bmatrix}
3\\
2
\end{bmatrix}
+
\begin{bmatrix}
1\\
4
\end{bmatrix}
=
\begin{bmatrix}
4\\
6
\end{bmatrix}
$$

### Illustratie



---

# Les 4 - Vectoraftrekking

## Theorie

$$
\vec{a}-\vec{b}
=
\begin{bmatrix}
a_x-b_x\\
a_y-b_y
\end{bmatrix}
$$

Voorbeeld:

$$
\begin{bmatrix}
5\\
3
\end{bmatrix}
-
\begin{bmatrix}
2\\
1
\end{bmatrix}
=
\begin{bmatrix}
3\\
2
\end{bmatrix}
$$

### Illustratie



---

# Les 5 - Magnitude

## Theorie

De lengte van een vector noemen we de magnitude. 【1-fce6ad\|8】

$$
|\vec{v}|=
\sqrt{x^2+y^2}
$$

Voorbeeld:

$$
\vec{v}
=
\begin{bmatrix}
3\\
4
\end{bmatrix}
$$

$$
|\vec{v}|=
\sqrt{3^2+4^2}
=
5
$$

### Illustratie



---

# Les 6 - Normaliseren

## Theorie

Een genormaliseerde vector heeft lengte 1. 【1-fce6ad\|8】

$$
\hat{v}
=
\frac{\vec{v}}
{|\vec{v}|}
$$

Voorbeeld:

$$
\hat{v}
=
\begin{bmatrix}
3/5\\
4/5
\end{bmatrix}
$$

### Illustratie



---

# Les 10 - Geparametriseerde Lijn

## Theorie

Een parametrische lijn wordt beschreven met:

$$
L(t)=\vec{s}+t\vec{d}
$$

waarbij:

- $\vec{s}$ = steunvector
- $\vec{d}$ = richtingsvector
- $t$ = parameter

【1-fce6ad\|10】

### Illustratie



---

# Les 11 - Intersections

### Illustratie



---

# Les 12 - Bissectrice

### Illustratie



---

# Les 14 - Circumcenter

### Illustratie



---

# Les 15 - Incenter

### Illustratie



---

# Les 18 - Dot Product

## Theorie

Het dot-product wordt gebruikt voor projecties. 【2-e9288a\|9】

$$
\vec{a}\cdot\vec{b}
=
a_x b_x + a_y b_y
$$

Voor genormaliseerde vectoren:

$$
\vec{a}\cdot\vec{b}
=
|\vec{a}|\cos(\theta)
$$

### Illustratie



---

# Les 21 - Matrixtransformaties

## Theorie

Een matrix verandert een vector. 【2-e9288a\|13】

$$
A
=
\begin{bmatrix}
a & b\\
c & d
\end{bmatrix}
$$

$$
A\vec{v}
=
\begin{bmatrix}
a & b\\
c & d
\end{bmatrix}
\begin{bmatrix}
x\\
y
\end{bmatrix}
$$

### Illustratie



---

# Les 22 - Normaalvectoren

## Theorie

Een normaalvector staat loodrecht op een lijn. 【2-e9288a\|16】

Voor

$$
\vec{v}
=
\begin{bmatrix}
x\\
y
\end{bmatrix}
$$

is een mogelijke normaal:

$$
\vec{n}
=
\begin{bmatrix}
-y\\
x
\end{bmatrix}
$$

### Illustratie



---

# Les 24 - Orient2D

### Illustratie



---

# Les 27 - Reflectiematrix

## Theorie

Reflecties kunnen worden uitgevoerd met matrices en normaalvectoren. 【2-e9288a\|20】

### Illustratie



---

# Eindproject

Bouw een complete 2D physics sandbox met:

- vectorvisualisatie
- zwaartekracht
- botsingen
- reflecties
- projecties
- matrixtransformaties

Hiermee komen alle onderdelen van de cursus samen in één game-engineproject. 


Bronnen: gd-m5-wis1.pptx, gd-m5-wis2.pptx> en Summary.page.