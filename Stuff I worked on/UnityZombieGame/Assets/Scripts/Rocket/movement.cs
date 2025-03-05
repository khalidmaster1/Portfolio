using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource sf;
    public float thrust = 1.2f;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        sf = this.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
         {
              sf.Play();
         }
         if (Input.GetKeyUp(KeyCode.Space))
         {
              sf.Stop();
         }
       if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate (Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate (Vector3.left * Time.deltaTime * speed);
        }
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        { 
            rb.freezeRotation = false;
        }
    }
}
