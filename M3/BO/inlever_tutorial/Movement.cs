using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 6f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");



        transform.Rotate(new Vector3(0, horizontalInput * rotationSpeed * Time.deltaTime, 0));




        Vector3 newPos = transform.position + verticalInput * transform.forward * moveSpeed * Time.deltaTime;
        transform.position = newPos;

    }
}
