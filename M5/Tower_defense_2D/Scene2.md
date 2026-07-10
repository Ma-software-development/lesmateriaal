# Tower defense 2D

## Scene2: Creating a tower that shoots at the enemies.

### Step 1: Tower
#### POI
- FindGameObjectsWithTag
- Quaternion.FromToRotation

#### Text tutorial
- Create a new "2D Object" -> "Sprites" -> "Circle" to the scene and rename it to "Tower".
- Add a new "2D Object" -> "Sprites" -> "Triangle" to the Tower gameobject as a child.
- Create a new C# Script called "Tower" and add it to the Tower gameobject.
- Create a new Tag called "Enemy" and add it to the Enemy prefab.
- In the Tower script add the `void Update()` function.
- In the `Update` function get all gameobjects from the scene with the tag "Enemy": `GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");`.
- If there are no targets there is no way for the tower to shoot at a target so return to stop the `Update` function: `if (targets.Length == 0) { return; }`.
- Store the first target in the targets array in a temporary new variable: `Transform target = targets[0].transform;`.
- Create a new function called `LookAtTarget` with a `Transform target` as parameter.
- Call the `LookAtTarget` function with the temporary created variable.
- In the `LookAtTarget` function we are gonna rotate the tower towards the target Transform.
- First get the direction vector by substracting the `target.position` by the tower `transform.position` store this in a new variable called `direction`: `Vector2 direction = target.position - transform.position;`.
- Set the rotation of the tower using the `direction` variable and the `Quaternion.FromToRotation`: `transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);` (NOTE: in Unity3D there is the Transform.LookAt function but because we use 2d this does not work).

By now you should have a tower in the scene rotating towards the first enemy spawned. 

### Step 2: Tower + Projectile
#### POI
- GetComponent

#### Text tutorial
- Create a new "2D Object" -> "Sprites" -> "Circle" to the scene and rename it to "Projectile".
- Make the scale (0,5 0,5 0,5).
- Make a Prefab of the Projectile
- Delete the original Projectile gameobject from the scene.
- Create new script "Projectile" and put it on the Projectile prefab.
- Add a reference to the Projectile Prefab in the Tower script: `[SerializeField] private GameObject projectilePrefab;` and set it using the Unity inspector.
- Add a new variable to the Tower class: `[SerializeField] private Transform target;` and remove the local "target" variable (we need the target variable in the upcoming Shoot function).
- Create new function `IEnumerator Shoot() {` and add `void Start()` in which you start the Coroutine: `StartCoroutine(Shoot());`.
- Create new variable: `[SerializeField] private float shootInterval = 1;`
- Add a `while(true)` loop with a `yield return new WaitForSeconds(shootInterval)`: `while (true) { yield return new WaitForSeconds(shootInterval); }`.
- In te Shoot function instantiate a new Projectile each interval: `GameObject projectileGameObject = Instantiate(projectilePrefab);`.
- In the Projectile class also add a target variable: `[SerializeField] public Transform target;` but make it public.
- Add a speed variable to the Projectile class: `[SerializeField] private float speed = 10;`
- Add a `void Update()` to the Projectile script and use `MoveTowards` to move it to the target: `transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);`.
- Back in the Tower class get the Projectile component of the instantiated Projectile gameobject: `Projectile projectile = projectileGameObject.GetComponent<Projectile>();`;
- Set the target of the Projectile to the target of the Tower: `projectile.target = target;`.

### Step 3: Enemy
#### POI
- OnTriggerEnter2D
- Destroy

#### Text tutorial
- Create new Tag "Projectile" and place it on the Projectile prefab.
- Add a Rigidbody component onto the Enemy prefab and set the gravity scale to 0.
- Add a CircleCollider2D onto the Enemy prefab.
- Add a CircleCollider2D onto the Projectile prefab.
- Check the isTrigger boolean on the Enemy prefab CircleCollider2D to true.
- Add `void OnTriggerEnter2D(Collider2D other)` to the Projectile class and check if other.tag is "Enemy" if so Destroy the Enemy and the Projectile itself: `if (other.tag == "Enemy") { Destroy(gameObject); Destroy(other.gameObject); }`.
- You should notice a lot of errors because Projectile is still trying to move the its target.
- Add a `target == null` check to the Update function of the Projectile and destroy the Projectiles Gameobject (also return; because the code after still executes): `if (target == null) { Destroy(gameObject); return; }`.

Now we should have a tower that shoots at the spawning enemys and destroys the enemys on projectile hit.