# Een bewegend doel raken met een turret

## Onderschepping berekenen met de cosinusregel en het inproduct

Om een bewegende vijand te raken met een projectiel dat een **constante snelheid** heeft, bereken je eerst de **vluchttijd** `t`. Daarmee kun je voorspellen waar de vijand zich bevindt wanneer het projectiel aankomt, en in welke richting de turret moet schieten.

Deze uitleg gebruikt de **cosinusregel**, het **inproduct (dot product)** en een **kwadratische vergelijking**. De methode gaat uit van een vijand met constante snelheid en een projectiel dat in een rechte lijn beweegt, zonder zwaartekracht of versnelling.

## 1. De onderscheppingsdriehoek

Stel je een driehoek voor met drie hoekpunten:

1. **A**: de huidige positie van de turret.
2. **B**: de huidige positie van de vijand.
3. **C**: het ontmoetingspunt waar het projectiel de vijand raakt.

De zijden zijn de afstanden die tijdens de vluchttijd `t` worden afgelegd:

- **Zijde c**: de beginafstand tussen turret en vijand. De vector is $\mathbf{D} = \mathbf{B} - \mathbf{A}$, met lengte $d = \|\mathbf{D}\|$.
- **Zijde a**: de afstand die de vijand aflegt: $a = v_e t$.
- **Zijde b**: de afstand die het projectiel aflegt: $b = v_b t$.

Hierbij zijn $v_e$ en $v_b$ de groottes van respectievelijk de vijandelijke snelheid en de projectielsnelheid.

## 2. De cosinusregel toepassen

Voor de zijde die het projectiel aflegt geldt:

$$
b^2 = a^2 + c^2 - 2ac\cos(\theta)
$$

Na het invullen van de snelheden en afstanden:

$$
(v_b t)^2 = (v_e t)^2 + d^2 - 2(v_e t)d\cos(\theta)
$$

De hoek $\theta$ is de hoek tussen de **bewegingsrichting van de vijand** en de **richting van de vijand naar de turret**.

Met het inproduct van vectoren kun je de cosinus berekenen:

$$
\cos(\theta) = \frac{-\mathbf{D}\cdot\mathbf{v}_e}{\|\mathbf{D}\|\,\|\mathbf{v}_e\|}
$$

Hier is $\mathbf{v}_e$ de snelheidsvector van de vijand. Bij een stilstaand doel is deze hoek niet nodig.

## 3. De vluchttijd berekenen

Schrijf de cosinusregel om naar een kwadratische vergelijking in `t`:

$$
(v_b^2-v_e^2)t^2 + 2dv_e\cos(\theta)t - d^2 = 0
$$

In de standaardvorm $At^2+Bt+C=0$ zijn de coëfficiënten:

$$
\begin{aligned}
A &= v_b^2-v_e^2 \\
B &= 2dv_e\cos(\theta) = -2\mathbf{D}\cdot\mathbf{v}_e \\
C &= -d^2
\end{aligned}
$$

De discriminant en de mogelijke tijden zijn:

$$
\Delta = B^2-4AC
$$

$$
t_{1,2}=\frac{-B\pm\sqrt{\Delta}}{2A}
$$

Kies de **kleinste strikt positieve tijd**. Als de discriminant negatief is of er geen positieve oplossing bestaat, kan de turret het doel onder deze aannames niet onderscheppen.

> **Correctie ten opzichte van de PDF:** de bron vermeldt ook $B=+2\mathbf{D}\cdot\mathbf{v}_e$ en gebruikt dat positieve teken in het codevoorbeeld. Dat is niet consistent met de eerder gegeven definitie $\mathbf{D}=\mathbf{B}-\mathbf{A}$ en de cosinusformule. Hier wordt het bijbehorende **minteken** gebruikt. Ook behandelt de code hieronder het geval $A\approx 0$ afzonderlijk om deling door nul te voorkomen.

## 4. Implementatie (C#-achtige pseudocode)

Bereken eerst de onderscheppingstijd, voorspel daarna de toekomstige vijandpositie en richt de turret op dat punt.

```csharp
Vector3 turretPos = turret.position;
Vector3 enemyPos = enemy.position;
Vector3 enemyVel = enemy.velocity; // Snelheidsvector van de vijand
float bulletSpeed = 50.0f;       // Constante projectielsnelheid

// Vector van de turret naar de vijand
Vector3 toEnemy = enemyPos - turretPos;
float dSq = toEnemy.LengthSquared();

// Coëfficiënten van A*t^2 + B*t + C = 0
float a = bulletSpeed * bulletSpeed - enemyVel.LengthSquared();
float b = -2.0f * Vector3.Dot(toEnemy, enemyVel);
float c = -dSq;

float t = -1.0f; // Geen geldige oplossing gevonden
const float epsilon = 0.00001f;

if (Mathf.Abs(a) < epsilon)
{
    // Lineair geval: B*t + C = 0
    if (Mathf.Abs(b) > epsilon)
    {
        float candidate = -c / b;
        if (candidate > 0.0f) t = candidate;
    }
}
else
{
    float discriminant = b * b - 4.0f * a * c;

    if (discriminant >= 0.0f)
    {
        float sqrtDiscriminant = Mathf.Sqrt(discriminant);
        float t1 = (-b - sqrtDiscriminant) / (2.0f * a);
        float t2 = (-b + sqrtDiscriminant) / (2.0f * a);

        if (t1 > 0.0f) t = t1;
        if (t2 > 0.0f && (t < 0.0f || t2 < t)) t = t2;
    }
}

if (t > 0.0f)
{
    // Waar bevindt de vijand zich over t seconden?
    Vector3 interceptPoint = enemyPos + enemyVel * t;

    // Richting waarin de turret moet schieten
    Vector3 fireDirection = (interceptPoint - turretPos).Normalized();

    // Horizontale draaihoek (yaw) in radialen
    float turretYawAngle = Mathf.Atan2(fireDirection.x, fireDirection.z);

    // Stuur de turret aan met turretYawAngle.
}
```

> **Let op:** dit is C#-achtige pseudocode. Methoden als `LengthSquared()`, `Normalized()` en `Mathf.Atan2()` verschillen per engine of wiskundebibliotheek. Voor Unity, Unreal Engine of Godot moet je de bijbehorende API gebruiken.

## 5. Samenvatting

1. Bereken de vector van de turret naar het doel: $\mathbf{D}=\mathbf{B}-\mathbf{A}$.
2. Bepaal de coëfficiënten van de kwadratische vergelijking met de projectielsnelheid en vijandsnelheid.
3. Los de vergelijking op en kies de kleinste positieve vluchttijd $t$.
4. Voorspel het ontmoetingspunt: $\mathbf{C}=\mathbf{B}+\mathbf{v}_e t$.
5. Richt de turret langs de vector $\mathbf{C}-\mathbf{A}$.

## Bronnen en achtergrond

De aangeleverde PDF is een Google-zoekresultatenpagina met een AI-overzicht en verwijzingen naar onder andere:

- **Stack Overflow** — *Calculating Intercepting Vector*.
- **Game Developer** — *Predictive Aim Mathematics for AI Targeting*.
- **ForrestTheWoods** — *Solving Ballistic Trajectories*.

De wiskundige toelichting komt uit het AI-overzicht op **pagina 1–3** van de PDF. De overige pagina's bevatten voornamelijk gerelateerde zoekresultaten en video's.
