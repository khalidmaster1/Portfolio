using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float viewDist;
    private Animator anim;
    private GameObject player;
    public float moveSpeed;
    private Rigidbody rb;
    public int hits = 5;
    public GameObject hitBox;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = new Vector3(transform.position.x, GetComponent<BoxCollider>().bounds.max.y, transform.position.z);

         int layerMask = 1 << 7;

        RaycastHit hit;

        if (Physics.Raycast(startPos, transform.TransformDirection(Vector3.forward), out hit, viewDist, layerMask))
        {
            if(!anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
            anim.Play("run");
            player = GameObject.Find("soldier");
            }
        }
        else
        {
           
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            ChasePlayer();
        }

         if(anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
         {
            hitBox.SetActive(true);
         }
         else
         {
             hitBox.SetActive(false);
         }

        if (hits <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    void ChasePlayer()
    {
        if(player.transform.position.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -1);
        }
        rb.velocity = new Vector3(moveSpeed*transform.localScale.z, rb.velocity.y, 0);

        if(Vector2.Distance(transform.position, player.transform.position) < 2)
        {
             anim.Play("attack");
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "bullet")
        {
            hits--;
            Destroy(other.gameObject);
        }
        
    }
}
