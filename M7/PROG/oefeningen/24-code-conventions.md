# Oefening 24 — Code Conventions

**Onderwerp:** Naamgeving, stijlregels en leesbare code  
**Module:** M6

---

## Oefening 24a — Slechte code verbeteren

Het volgende script werkt, maar volgt geen enkele conventie. Refactor het.

```csharp
using UnityEngine;

public class thing : MonoBehaviour
{
    public float S = 5f;
    public int hp = 100;
    int D = 10;
    bool dead = false;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, 0, v) * S * Time.deltaTime;
    }

    public void hit(int a)
    {
        hp = hp - a;
        if(hp<=0){ dead=true; Debug.Log("dood"); Destroy(gameObject); }
    }
}
```

**Opdracht:**  
Refactor dit script met de volgende regels:

| Regel               | Conventie                                             |
| ------------------- | ----------------------------------------------------- |
| Klasse-naam         | PascalCase (`PlayerController`)                       |
| Publieke variabelen | camelCase in Inspector, of `[SerializeField] private` |
| Private variabelen  | `_camelCase` of `camelCase`                           |
| Methode-namen       | PascalCase (`TakeDamage`)                             |
| Constanten          | UPPER_CASE of PascalCase                              |
| Variabele-namen     | Beschrijvend, geen afkortingen                        |
| Formatting          | Spaties rond operatoren, accolades op eigen regel     |

Verwacht resultaat (richtlijn):

```csharp
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int maxHealth = 100;

    private int _currentHealth;
    private int _damage = 10;
    private bool _isDead = false;

    void Start()
    {
        _currentHealth = maxHealth;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        Debug.Log($"{gameObject.name} is gestorven.");
        Destroy(gameObject);
    }
}
```

---

## Oefening 24b — Code review

Bekijk het volgende script en geef feedback als een code reviewer.

```csharp
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject e = Instantiate(prefab);
            e.transform.position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            enemies.Add(e);
        }
    }

    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
                i--;
            }
        }
    }
}
```

**Opdracht:**  
Schrijf minstens 5 verbeterpunten op:

1. Naamgeving en access modifiers
2. Magische getallen (magic numbers)
3. Verantwoordelijkheden (SRP)
4. Performance-overwegingen
5. Veiligheid en null-checks

Bonus: Schrijf een verbeterde versie van dit script.
