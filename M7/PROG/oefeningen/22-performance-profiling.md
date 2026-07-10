# Oefening 22 — Performance & Profiling

**Onderwerp:** Object Pooling, garbage collection en de Unity Profiler  
**Module:** M6

---

## Oefening 22a — Object Pooling

In plaats van steeds `Instantiate` en `Destroy` te gebruiken (wat GC-pressure veroorzaakt), hergebruik je objecten via een pool.

```csharp
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 20;

    private Queue<GameObject> pool = new Queue<GameObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Pool is leeg!");
            return null;
        }

        GameObject bullet = pool.Dequeue();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        pool.Enqueue(bullet);
    }
}
```

**Opdracht:**

1. Maak een simpele bullet-prefab (Sphere met schaal 0.2).
2. Maak het `BulletPool`-script aan.
3. Maak een `Shooter`-script dat bij spatiebalk een bullet uit de pool haalt:
   ```csharp
   void Update()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
           GameObject bullet = pool.GetBullet(transform.position, transform.rotation);
       }
   }
   ```
4. Maak een `Bullet`-script dat na 2 seconden zichzelf teruggeeft aan de pool (ipv `Destroy`).
5. **Bonus:** Open de **Unity Profiler** (Window > Analysis > Profiler) en vergelijk het geheugengebruik met/zonder pooling.

---

## Oefening 22b — Debug.Log en performance

`Debug.Log` is handig maar kost performance, vooral in builds.

**Opdracht:**

1. Maak een script dat elke frame 10x `Debug.Log("test")` aanroept.
2. Open de Profiler en bekijk de CPU-pieken onder **EditorLoop** of **PlayerLoop**.
3. Verwijder of comment de logs uit — bekijk het verschil.
4. Implementeer een simpele wrapper zodat logs alleen in de Editor actief zijn:
   ```csharp
   public static class GameDebug
   {
       [System.Diagnostics.Conditional("UNITY_EDITOR")]
       public static void Log(string message)
       {
           Debug.Log(message);
       }
   }
   ```
5. Vervang `Debug.Log` door `GameDebug.Log` en test dat logs verdwijnen in een build.
