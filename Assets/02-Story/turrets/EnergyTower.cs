using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTower : MonoBehaviour
{
    float oldSpeed;
    public float slowSpeed = 2f;
    Rigidbody rb;
    Vector3 realScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        realScale = Vector3.one;
        
    }

    private void Update()
    {
        if(rb.velocity.magnitude == 0)
         transform.eulerAngles = Vector3.zero;

    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider collision) {
        if(collision.tag =="enemy"){
           oldSpeed = collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
           collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = slowSpeed;
            //collision.gameObject.GetComponent<Animator>().speed=;
        }
    }

    private void OnTriggerExit(Collider collision) {
        if(collision.tag =="enemy"){        
           collision.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = oldSpeed;
        }
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Terrain")
        {
            transform.localScale = realScale;
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Terrain")
        {
            transform.localScale = Vector3.one*0.2f;
        }
    }*/
}
