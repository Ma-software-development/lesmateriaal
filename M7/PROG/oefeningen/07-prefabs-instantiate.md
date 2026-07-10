# Oefening: Prefabs & Instantiate

## Leerdoel

Prefabs maken en objecten spawnen via code met `Instantiate()`.

---

## Oefening 1: Bullet Spawner

Maak een script dat kogels spawnt:

1. Maak een `Bullet` prefab (kleine cirkel met Rigidbody2D)
2. Maak een Spawner script:

```csharp
public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: Instantiate bulletPrefab op transform.position
            // TODO: Geef de bullet een snelheid via Rigidbody2D.linearVelocity
        }
    }
}
```

**Test:** Bij elke spatie verschijnt een kogel die omhoog vliegt.

---

## Oefening 2: Random Spawner

Spawn vijanden op willekeurige posities:

```csharp
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            // TODO: Bereken een random positie
            // x: Random.Range(-8f, 8f)
            // y: 6f (boven het scherm)
            // TODO: Instantiate enemyPrefab op die positie
        }
    }
}
```

**Test:** Elke 2 seconden verschijnt een vijand op een willekeurige x-positie.
