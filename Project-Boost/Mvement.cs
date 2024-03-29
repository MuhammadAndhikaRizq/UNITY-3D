using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    // Awal frame dijalankan
    void Start()
    {
      rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    // Update setiap frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation();

    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the physics system can take over
    }
}
