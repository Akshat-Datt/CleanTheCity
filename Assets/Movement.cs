using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizontalInput;
    public float verticalInput;
    public float steerSpeed;
    public Joystick joystick;

    public Transform smokePosition;
    public ParticleSystem smoke;
    Rigidbody trashRb;
    void Start()
    {
        trashRb = GetComponent<Rigidbody>();
    }

  
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * joystick.Vertical * 10);
        

        
        transform.Rotate(Vector3.up * joystick.Horizontal * steerSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            Destroy(collision.gameObject);
            Instantiate(smoke, smokePosition.position, Quaternion.identity);
        }
        else if(collision.gameObject.tag == "Obstacle"){
            trashRb.velocity = Vector3.zero;
        }
    }
}
