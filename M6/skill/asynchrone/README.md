# Asynchrone sprong

## de abc-formule

De **ABC-formule** is een methode om de oplossingen van een **kwadratische vergelijking** te vinden. Een kwadratische vergelijking heeft de vorm:

$$
ax^2 + bx + c = 0
$$

waarbij:
- \(a\), \(b\) en \(c\) constanten zijn, met \(a \neq 0\).
- \(x\) de onbekende is die je wilt oplossen.

### **Stap-voor-stap uitleg van de ABC-formule**

De **ABC-formule** luidt:

$$
x = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a}
$$

#### **Stap 1: Identificeer de waarden van \(a\), \(b\) en \(c\)**
Kijk naar de vergelijking en bepaal de waarden van \(a\), \(b\) en \(c\).

#### **Stap 2: Bereken de discriminant (\(\Delta\))**
De **discriminant** is het deel onder de wortel in de ABC-formule:

$$
\Delta = b^2 - 4ac
$$

- **Als $\Delta > 0$** → Twee verschillende oplossingen.
- **Als $\Delta = 0$** → Eén oplossing (een dubbele wortel).
- **Als $\Delta < 0$** → Geen echte oplossingen (alleen complexe oplossingen).

#### **Stap 3: Vul de ABC-formule in**
Gebruik de eerder gevonden waarden om \(x\) te berekenen:

$$
x = \frac{-b \pm \sqrt{\Delta}}{2a}
$$

Gebruik de **plus (\(+\))** en **min (\(-\))** om de twee mogelijke waarden voor \(x\) te berekenen.

---

### **Voorbeeld**
Los de vergelijking op:

$$
2x^2 - 3x - 5 = 0
$$

1. **Bepaal \(a\), \(b\) en \(c\):**
   - \(a = 2\),
   - \(b = -3\),
   - \(c = -5\).

2. **Bereken de discriminant \(\Delta\):**
   $$
   \Delta = (-3)^2 - 4(2)(-5)
   $$
   $$
   = 9 + 40 = 49
   $$

3. **Bereken \(x\) met de ABC-formule:**
   $$
   x = \frac{-(-3) \pm \sqrt{49}}{2(2)}
   $$
   $$
   x = \frac{3 \pm 7}{4}
   $$

   Nu berekenen we de twee mogelijke waarden voor \(x\):

   - **Eerste oplossing**: 
       - $$  x = \frac{3 + 7}{4} = \frac{10}{4} = 2.5 $$
   - **Tweede oplossing**: 
     - $$  x = \frac{3 - 7}{4} = \frac{-4}{4} = -1 $$

4. **Conclusie**: De oplossingen van \(2x^2 - 3x - 5 = 0\) zijn:

   $$
   x = 2.5 \quad \text{of} \quad x = -1
   $$

De **ABC-formule** kan worden toegepast in situaties waarin een **kwadratische vergelijking** moet worden opgelost. In dit geval gaan we kijken hoe je de formule kunt gebruiken als:

- \( a = -0.5g \) (bijvoorbeeld in bewegingsvergelijkingen in de natuurkunde)
- \( b = V_{\text{begin}} \) (de beginsnelheid)

---

## **Stap 1: De algemene vorm van de vergelijking**
De kwadratische bewegingsvergelijking in de natuurkunde wordt vaak gebruikt in **vrije val of verticale beweging**, en heeft de vorm:

$$
s = V_{\text{begin}} t + \frac{1}{2} a t^2
$$

waarbij:
- \( s \) de verplaatsing is,
- \( t \) de tijd is,
- \( V_{\text{begin}} \) de beginsnelheid is,
- \( a = -g \) de zwaartekrachtsversnelling (\( g \approx 9.81 \) m/s² op aarde).

Om dit in de standaardvorm van een kwadratische vergelijking te zetten:

$$
-0.5 g t^2 + V_{\text{begin}} t - s = 0
$$

Hieruit volgt:

$$
a = -0.5 g, \quad b = V_{\text{begin}}, \quad c = -s
$$

---

## **Stap 2: Toepassen van de ABC-formule**
De **ABC-formule** luidt:

$$
t = \frac{-b \pm \sqrt{b^2 - 4ac}}{2a}
$$

Nu vullen we \( a = -0.5 g \), \( b = V_{\text{begin}} \) en \( c = -s \) in:

$$
t = \frac{-V_{\text{begin}} \pm \sqrt{V_{\text{begin}}^2 - 4(-0.5 g)(-s)}}{2(-0.5 g)}
$$

Dit vereenvoudigt tot:

$$
t = \frac{-V_{\text{begin}} \pm \sqrt{V_{\text{begin}}^2 - 2gs}}{-g}
$$

Omdat er een **negatieve deling** is in de noemer, kunnen we alles omdraaien:

$$
t = \frac{V_{\text{begin}} \pm \sqrt{V_{\text{begin}}^2 - 2gs}}{g}
$$

---

## **Stap 3: Interpreteren van de oplossing**
- Er zijn **twee mogelijke oplossingen** voor \( t \) door de \( \pm \) in de formule.
- In een fysieke context betekent dit vaak:
  - De **eerste tijd** is wanneer het object de hoogte \( s \) bereikt op de **opgaande** beweging.
  - De **tweede tijd** is wanneer het object opnieuw bij \( s \) komt tijdens de **terugval**.
- Als de discriminant (\( V_{\text{begin}}^2 - 2gs \)) **negatief** is, betekent dit dat het object **de hoogte \( s \) nooit bereikt**.

---

## **Voorbeeldberekening**
Stel dat:
- \( g = 9.81 \) m/s²,
- \( V_{\text{begin}} = 20 \) m/s,
- \( s = 15 \) m.

Dan wordt:

$$
t = \frac{20 \pm \sqrt{20^2 - 2(9.81)(15)}}{9.81}
$$

$$
t = \frac{20 \pm \sqrt{400 - 294.3}}{9.81}
$$

$$
t = \frac{20 \pm \sqrt{105.7}}{9.81}
$$

$$
t = \frac{20 \pm 10.28}{9.81}
$$

Nu berekenen we de twee tijden:

$$
t_1 = \frac{20 + 10.28}{9.81} = \frac{30.28}{9.81} \approx 3.09 \text{ s}
$$

$$
t_2 = \frac{20 - 10.28}{9.81} = \frac{9.72}{9.81} \approx 0.99 \text{ s}
$$

Dus het object is op \( s = 15 \) meter zowel bij **0.99 s** (opgaande beweging) als bij **3.09 s** (terugkomend).

---

## **Conclusie**
- De **ABC-formule** helpt bij het oplossen van **bewegingsvergelijkingen** waarbij de tijd moet worden bepaald.
- Als \( a = -0.5 g \), \( b = V_{\text{begin}} \) en \( c = -s \), kunnen we een **tijd \( t \) berekenen** waarop een object een bepaalde hoogte bereikt.
- **Beide oplossingen voor \( t \)** zijn fysiek relevant: de ene is voor het omhoog bewegen, de andere voor het neerkomen.
