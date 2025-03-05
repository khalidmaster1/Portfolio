using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 4)
        {
            Debug.Log(Time.time);
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
