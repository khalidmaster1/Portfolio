using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10;
    public float facing = 1;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
        StartCoroutine(yieldDestroy(1));
        if (GameObject.Find("soldier").GetComponent<playerController>().facingRight)
        {
            facing = 1;
        }
        else
        {
            facing = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * facing,0,0),Space.World);
    }

    public IEnumerator yieldDestroy(float timeStop)
    {
        yield return new WaitForSeconds(timeStop);
        Destroy(this.gameObject);
    }

     private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(this.gameObject);
        }
        
    }
}
