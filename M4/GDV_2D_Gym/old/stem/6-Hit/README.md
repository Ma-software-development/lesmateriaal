# 1.4.skill.stem.6 Hit

Voor deze opdracht moet je beschikken over 
1. een bestuurbare tank: <a href="https://github.com/djsjollema/lessen-gamedevelopment/tree/main/M4/stem/4-TankSheet">Les 1.4 Tanksheet</a>
2. Een Bullet-factory pattern: <a href="https://github.com/djsjollema/lessen-gamedevelopment/tree/main/M4/stem/5-Shoot">Les 1.5 Shoot</a>

ALs je deze opdrachten (nog) niet gemaakt hebt, kun je deze Repository gebruiken
<a href="https://github.com/djsjollema/1.4skill-a.git" target="_blank">Tank- en shootrepository</a>

# Opdracht

Om een Enemy te maken, moet je alle lessen die je hiervoor hebt gehad nog een keer herhalen. Er zijn wel een paar nieuwe onderdelen, zoals bewegen naar een Random plaats en een hit-variabele

1. Gebruik de spritesheet om een animatie van een EnemyTank te maken. 
   - Zorg dat de voorkant van de EnemyTank naar rechts wijst
   - Maak en Enemy van vergelijkbare grootte als de Tank
<img src="images/Enemy.png" width="30%">
2.  Koppel de Enemy aan een script dat de beweging van de EnemyTank regelt.
- De EnemyTank Spawnt op (0,0,0)
- De EnemyTank kiest een willekeurig punt binnen het speelveld
- De EnemyTank bepaalt de afstand naar dit punt en de tijd dat dit kost 
- De EnemyTank beweegt naar dit punt en houdt de tijd bij dat dit kost
- Als de EnemyTank bij de target is aangekomen, kiest het een nieuw willekeurig punt en beweegt weer daarheen
- ALs de Tank de EnemyTank met een Bullet raakt, verdwijnen zowel de EnemyTank als de Bullet
- Maak van de EnemyTank een PreFab

1. De hit
   - Voeg de BoxCollider2D toe aan de EnemyTank-prefab
   - Voeg bij de Bullet een nieuwe variabele toe 
   - 
  ````
  C#     RaycastHit2D hit;
  `````

## Eigenschappen van `RaycastHit2D`

| Eigenschap | Type       | Beschrijving |
|------------|-----------|--------------|
| `point`    | `Vector2` | Wereld­positie waar de ray het object raakte. |
| `normal`   | `Vector2` | Opp­ervlakte-normaal op het raakpunt. |
| `distance` | `float`   | Afstand van oorsprong van de ray tot het raakpunt. |
| `fraction` | `float`   | Fractie van de totale raylengte (0–1) waarop de hit plaatsvond. |
| `collider` | `Collider2D` | De collider die geraakt werd (of `null` als geen hit). |
| `rigidbody`| `Rigidbody2D` | De gekoppelde rigidbody (kan `null` zijn). |
| `transform`| `Transform`  | Transform van het getroffen object (verkregen via `collider.transform`). |

In de Update() van de Bullet gaan we van de variabele **hit** eigenschap collider gebruiken.

## Eigenschappen van `RaycastHit2D.collider`  
*(het object is van het type **`Collider2D`**)*

| Eigenschap | Type | Korte beschrijving |
|------------|------|--------------------|
| `attachedRigidbody` | `Rigidbody2D` | De rigidbody die aan deze collider gekoppeld is. |
| `bounceCombine` | `PhysicsMaterialCombine` | Methode waarmee de uiteindelijke bounciness wordt berekend als twee colliders elkaar raken. |
| `bounciness` | `float` | Hoeveel de collider stuitert bij een botsing. |
| `bounds` | `Bounds` | Axis-aligned omvattende doos in wereldruimte. |
| `callbackLayers` | `LayerMask` | Lagen waarvan deze collider callbacks (collision/trigger) rapporteert. |
| `composite` | `CompositeCollider2D` | Verwijzing naar de composiet-collider (indien aanwezig). |
| `compositeCapable` | `bool` | *True* als de collider samengestelde colliders kan gebruiken. |
| `compositeOperation` | `int / enum` | Welk samenvoeg-algoritme (additive, subtractive …) de composiet gebruikt. |
| `compositeOrder` | `int` | Volgorde waarin de collider verwerkt wordt door een composiet. |
| `contactCaptureLayers` | `LayerMask` | Lagen waarvan contactpunten worden vastgelegd. |
| `density` | `float` | Dichtheid voor massaberekening (bij “Auto Mass”). |
| `errorState` | `ColliderErrorState2D` | Read-only statuscode als de collidergeometrie niet correct kon worden aangemaakt. |
| `excludeLayers` | `LayerMask` | Extra lagen die botsingen met deze collider uitsluiten. |
| `forceReceiveLayers` | `LayerMask` | Lagen waarvan deze collider krachten *kan ontvangen*. |
| `forceSendLayers` | `LayerMask` | Lagen waaraan deze collider krachten *mag sturen*. |
| `friction` | `float` | Wrijvingscoëfficiënt (Physics Material). |
| `frictionCombine` | `PhysicsMaterialCombine` | Methode om uiteindelijke wrijving te berekenen bij contact. |
| `includeLayers` | `LayerMask` | Extra lagen die botsingen met deze collider forceren. |
| `isTrigger` | `bool` | Gedraagt de collider zich als *trigger* i.p.v. een vaste botsing? |
| `layerOverridePriority` | `int` | Prioriteit als layer-beslissingen conflicteren. |
| `localToWorldMatrix` | `Matrix4x4` | Matrix die de collider-vorm naar wereldruimte transformeert. |
| `offset` | `Vector2` | Lokale verschuiving van de collidergeometrie. |
| `shapeCount` | `int` | Aantal actieve physics-shapes waaruit de collider bestaat. |
| `sharedMaterial` | `PhysicsMaterial2D` | Het toegepaste physics-materiaal (friction / bounciness). |
| `usedByEffector` | `bool` | *True* als de collider door een 2D-effector (bv. Buoyancy) gebruikt wordt. |

> *Erfgenaam-eigenschappen* zoals `enabled`, `gameObject`, `transform`, `tag`, enz. komen mee vanuit `Behaviour`/`Component`, maar staan niet in deze tabel omdat ze niet specifiek zijn voor colliders.:contentReference[oaicite:0]{index=0}

Daarmee verwijderen wij het geraakte gameObject en de instantie van de Bullet

`````
if(hit.collider != null)
{
   Destroy(hit.collider.gameObject);
   Destroy(gameObject);
}

`````

# eindproduct
<img src="images/EindProduct.gif">
