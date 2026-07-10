using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Fire"))
        {
            GameObject bullet = Instantiate(projectilePrefab);
            Destroy(bullet, 6f);
        }
    }
}
