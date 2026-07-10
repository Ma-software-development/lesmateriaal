using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed = 10;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Quaternion.Lerp

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy") 
        {
            Destroy(gameObject);
            Destroy(other.gameObject); 
        }
    }
}
