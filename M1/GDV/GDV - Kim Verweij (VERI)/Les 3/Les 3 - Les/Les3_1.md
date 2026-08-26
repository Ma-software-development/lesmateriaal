# Les 3.1: Vallen, botsen en stuiteren

Vandaag gaan we kijken wat Unity zelf voor ons kan uitrekenen.

Tot nu toe heb je objecten met de hand geplaatst of met code laten bewegen. In deze les gebruiken we physics. Daardoor kunnen objecten vallen, botsen, rollen en stuiteren.

## Na deze les

Na deze les kun je:

- uitleggen wat physics in Unity doet
- een `Rigidbody` toevoegen
- uitleggen wat een `Collider` doet
- een object laten vallen door zwaartekracht
- een object laten stuiteren met een Physics Material
- een object een duw geven met code

---

## Physics in Unity

Physics betekent dat Unity bewegingen uitrekent alsof er natuurkunde in je game zit.

Bijvoorbeeld:

- een bal valt naar beneden
- een blok botst tegen de grond
- een object stuitert
- een bal rolt van een helling

Je hoeft dan niet elke beweging zelf met `transform.position` te maken. Unity helpt mee.

---

## Rigidbody

Een `Rigidbody` zorgt ervoor dat een GameObject reageert op physics.

Met Rigidbody kan een object bijvoorbeeld:

- vallen door zwaartekracht
- reageren op botsingen
- rollen
- kracht ontvangen

### Rigidbody toevoegen

1. Maak een `Cube` of `Sphere`.
2. Selecteer het object.
3. Klik op **Add Component**.
4. Zoek naar **Rigidbody**.
5. Voeg de Rigidbody toe.
6. Druk op Play.

Als `Use Gravity` aanstaat, valt je object naar beneden.

---

## Collider

Een `Collider` bepaalt de vorm waarmee Unity botsingen berekent.

Zonder Collider weet Unity niet goed waar een object tegenaan botst.

Voorbeelden:

- een Cube heeft meestal een `Box Collider`
- een Sphere heeft meestal een `Sphere Collider`
- een speler gebruikt vaak een `Capsule Collider`

Voor physics heb je vaak allebei nodig:

- `Rigidbody`: zorgt dat het object reageert op physics
- `Collider`: zorgt dat het object kan botsen

---

## Physics Material

Met een Physics Material bepaal je hoe een object reageert tijdens botsingen.

Bijvoorbeeld:

- hoe glad iets is
- hoeveel wrijving iets heeft
- hoe hard iets stuitert

Belangrijke instellingen:

- `Bounciness`: hoe stuiterig het object is
- `Friction`: hoeveel wrijving het object heeft

---

## Kracht geven met code

Je kunt een Rigidbody een duw geven met code.

Daarvoor gebruik je `AddForce()`.

```csharp
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 500f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force);
        }
    }
}
```

Zet dit script op een object met een Rigidbody.

Druk op Play en daarna op **Space**.

---

## Let op met Transform

Als een object een Rigidbody heeft, laat Unity physics het object bewegen.

Probeer dan niet steeds zelf de positie te forceren met:

```csharp
transform.position = ...
```

Dat kan physics in de war brengen.

Gebruik bij physics-objecten liever:

```csharp
rb.AddForce(...)
```

---

## Snelheid direct instellen

Soms wil je een Rigidbody meteen een bepaalde snelheid geven.

In Unity 6 gebruik je daarvoor `linearVelocity`.

```csharp
rb.linearVelocity = new Vector3(5f, 0f, 0f);
```

Dit geeft het object direct snelheid naar rechts.

Gebruik dit niet elke frame opnieuw. Voor gewone physics-beweging is `AddForce()` meestal beter.

---

## Veelgemaakte fouten

### Mijn object valt door de grond

Check even:

- heeft het vallende object een Collider?
- heeft de grond een Collider?
- staat `Is Trigger` uit?
- is de grond groot genoeg?

### Mijn object valt niet

Check even:

- heeft het object een Rigidbody?
- staat `Use Gravity` aan?
- staat `Is Kinematic` uit?

### Mijn object stuitert niet

Check even:

- heeft het object een Physics Material?
- staat `Bounciness` hoger dan `0`?
- zit het Physics Material op de Collider?

---

## Oefening

Ga nu naar de oefeningen van les 3.1:

[Oefeningen Les 3.1](../Week%203%20-%20Oefeningen/oefeningen_3_1.md)

---

## Checklist

- [ ] Ik weet wat een Rigidbody doet
- [ ] Ik weet wat een Collider doet
- [ ] Ik heb een object laten vallen
- [ ] Ik heb een object laten botsen met de grond
- [ ] Ik heb een Physics Material gebruikt
- [ ] Ik heb gezien wat Bounciness doet
- [ ] Ik heb een object kracht gegeven met code
