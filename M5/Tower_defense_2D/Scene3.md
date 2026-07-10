# Tower defense 2D

## Scene1: Making our tower "smarter".

### Step 1: TowerPlacement
#### POI
- GetMouseButtonDown
- Camera.main
- ScreenToWorldPoint
- Input.mousePosition
- RaycastHit2D
- Array.IndexOf

#### Text tutorial
- Create a new Empty gameobject and rename it to "TowerPlacement".
- Create a new C# script called "TowerPlacement" and add it to the TowerPlacement gameobject.
- Create a prefab out of the tower gameobject.
- Add a new variable to the TowerPlacement script and store the tower prefab into it: `[SerializeField] private GameObject towerPrefab;`.
- Create a new variable `towerSlots`: `[SerializeField] private GameObject[] towerSlots;`.
- Create 2 new "2D Object" -> "Sprites" -> "Hexagon Flat-Top" and rename them to "TowerSlot (0..1)", add them as children to the TowerPlacement gameobject.
- Put the 2 newly created tower slots gameobjects into the `towerSlots` variable via the Unity Inspector.
- Add a PolygonCollider2D to the 2 tower slots.
- In the TowerPlacement script add the Unity `Update` function.
- In the `Update` function we are gonna check if we clicked on one of the `towerSlots` gameobjects and place an Tower on it.
- First check if we clicked the left mouse button: `if (Input.GetMouseButtonDown(0)) { }`.
- Then we shoot a raycast from the mousePosition to the world.
`
Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
`
- Then we check if the raycast hit something in the scene: `if(hit.collider != null) { }`.
- We will create a new function called `PlaceTower` with the parameter `int towerSlotIndex`.
- In this function `Instantiate` the `towerPrefab` and set the instantiated tower to the position of the given `towerSlots[towerSlotIndex]` its position.
- Now we need to know if what the raycast hit is actually a towerSlot and whats its index is.
- We can get the index of the clicked towerSlot by using `Array.IndexOf`.
- We check if the `hit.collider.gameObject` is present in the `towerSlots` array: `int towerSlotIndex = Array.IndexOf(towerSlots, hit.collider.gameObject);`.
- This function will return `-1` if what we clicked is not present in the `towerSlots` array.
- So check if the towerSlotIndex is not `-1` and call the `PlaceTower` with the `towerSlotIndex`: `if (towerSlotIndex != -1) { PlaceTower(towerSlotIndex); }`.

By now we can place 2 towers on the towerSlots in the scene by clicking these slots. The towers however will both start targeting the first enemy. We can fix this by making the tower shoot at the closest enemy to the tower.

### Step 2: Tower
#### POI

#### Text tutorial
- Go into the Tower script, to the place where we set the `target` variable to the `targets[0]` gameobject.
- Here we wanna change the `targets[0]` to the enemy closest to the tower its position.
- We can do this by looping over all the `targets`, check the distance from the tower to that target and check if its the closest of all the targets.
- First we want to store the closest distance in a variable so create the `float nearestDistance` variable and set it to a big number like 100.
- Then we want to loop over all the targets with a for loop: `for (int i = 0; i < targets.Length; i++) { }`.
- In the for loop we want to check what the distance is from the tower its position to the target its position (HINT: we already did this in the WaypointFollower script), store this in a variable called `distance`.
- Then we want to check if the distance is smaller than the created `nearestDistance` variable.
- And if so set the target to this instance in the for loop and set the `nearestDistance` to the current distance variable.

Maybe you have noticed we can click the towerslots multiple times to place more towers on the towerslots, lets fix this.

### Step 3: Towerslots
#### POI

#### Text tutorial
- We can start by creating a new C# script called "TowerSlot" and place it on our towerslots.
- In the TowerPlacement script change the `towerSlots` type from `GameObject` to our newly created `TowerSlot` script.
- If you can remember in our first step we checked if we clicked one of the towerSlots, this code will not work anymore because we changed the type to TowerSlot, we can fix this by changing the `Array.IndexOf` second parameter from the gameobject to the `hit.collider.GetComponent<TowerSlot>()`.
- In our TowerSlot script add a new variable: `[SerializeField] public Tower tower;`.
- We can also change the type of the `private GameObject towerPrefab;` to be the `Tower` class so we can only place gameobjects that have the Tower class.
- And we can change the return type of the `Instantiate` function to be the Tower class by casting it to the Tower class (Please look up "C# Type Casting").
- Now when we instantiate the towerPrefab we instantly store it in a `Tower tower` variable and can set the tower variable in the TowerSlot class to this Tower instance: `towerSlots[towerSlotIndex].tower = tower;`.
- Lastly we need to check when trying to place the tower if there is already a tower on the clicked slot.
