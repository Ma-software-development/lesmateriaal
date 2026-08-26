# Les 4.1: Botsen of detecteren?

Vandaag ga je leren hoe objecten op elkaar kunnen reageren.

Soms wil je dat objecten echt botsen, zoals een speler tegen een muur.  
Soms wil je alleen detecteren dat iets geraakt wordt, zoals een coin die je oppakt.

Daarvoor gebruiken we Colliders, Triggers en Tags.

---

## Na deze les

Na deze les kun je:

- uitleggen wat een Collider doet
- uitleggen wat een Trigger doet
- het verschil uitleggen tussen botsen en detecteren
- een Tag toevoegen aan een GameObject
- controleren waarom een Trigger soms niet werkt

---

## Collider

Een `Collider` bepaalt de vorm waarmee Unity botsingen berekent.

Voorbeelden:

- een muur houdt de speler tegen
- een vloer zorgt dat een bal niet door de grond valt
- een obstakel blokkeert de route

Een Collider is meestal onzichtbaar tijdens het spelen, maar Unity gebruikt hem wel om contact te herkennen.

---

## Trigger

Een `Trigger` is een Collider waarbij `Is Trigger` aanstaat.

Een Trigger houdt objecten niet tegen.  
Objecten kunnen er dus doorheen.

Maar Unity kan wel detecteren dat er iets door de Trigger heen gaat.

Triggers gebruik je bijvoorbeeld voor:

- coins oppakken
- checkpoints
- deuren openen
- killzones
- geheime gebieden

---

## Collision of Trigger?

Gebruik een normale Collider als iets moet blokkeren.

Gebruik een Trigger als iets alleen iets moet detecteren.

Voorbeelden:

- muur = Collision
- coin = Trigger
- vloer = Collision
- checkpoint = Trigger

---

## Tags

Een `Tag` is een label voor een GameObject.

Met Tags kun je herkennen wat iets is.

Voorbeelden:

- `Player`
- `Enemy`
- `Coin`
- `Wall`
- `Checkpoint`

Later kun je in code bijvoorbeeld checken:

```csharp
if (other.CompareTag("Player"))
{
    Debug.Log("De speler is geraakt");
}
```

Zo voorkom je dat elk object zomaar dezelfde reactie geeft.

---

## Wanneer werkt een Trigger?

Check even:

- beide objecten hebben een Collider
- bij één Collider staat `Is Trigger` aan
- minstens één van de objecten heeft een Rigidbody
- beide objecten staan actief in de scene
- je script staat op het juiste GameObject

Als je Trigger niets doet, zit het probleem meestal in één van deze punten.

---

## Kinematic Rigidbody

Soms wil je wel detectie, maar geen zwaartekracht.

Dan kun je een Rigidbody toevoegen en `Is Kinematic` aanzetten.

Handig voor bijvoorbeeld:

- een speler die je zelf bestuurt
- een bewegend platform
- een triggerzone die niet moet vallen

---

## Veelgemaakte fouten

### Mijn speler gaat door de muur

Check of `Is Trigger` uitstaat op de muur.

### Mijn coin verdwijnt niet

Check of de coin een Trigger is en of één van de objecten een Rigidbody heeft.

### Mijn script reageert op het verkeerde object

Gebruik een Tag, bijvoorbeeld `Player` of `Coin`.

### Mijn Trigger werkt niet

Check of je script op het juiste object staat en kijk in de Console.

---

## Oefening

Ga nu naar de oefeningen van les 4.1:

[Oefeningen Les 4.1](../Week%204%20-%20Oefeningen/oefeningen_4_1.md)

---

## Checklist

- [ ] Ik weet wat een Collider doet
- [ ] Ik weet wat een Trigger doet
- [ ] Ik weet het verschil tussen botsen en detecteren
- [ ] Ik heb een Tag toegevoegd
- [ ] Ik weet wanneer een Rigidbody nodig is
- [ ] Ik kan uitleggen waarom een Trigger soms niet werkt
