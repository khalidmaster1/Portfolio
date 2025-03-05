using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

public float xValue = 1.6f;
public float zValue = 0.4f;
public float moveSpeed = 1.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
            
        } 
    }

