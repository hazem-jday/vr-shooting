using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunchTower : MonoBehaviour
{
    bool targetFound = false;
    public GameObject bullet;
    public Transform firePoint;
    public float explosionRadius = 6f;
    GameObject target;
    public float fireRate =3f;
    Rigidbody rb;
    Vector3 realScale;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",0f,fireRate);
        rb = GetComponent<Rigidbody>();
        realScale = Vector3.one;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude <= 0.01f)
            transform.eulerAngles = Vector3.zero;
        if (!targetFound){ 
            Rotate();
        }else if (target != null)
        {
            Vector3 relativePos = target.transform.position - transform.position; 
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            this.gameObject.transform.GetChild(1).rotation = rotation;
        }
    }
    void Shoot(){
        // Rigidbody instance = Instantiate(projectile);
        // instance.velocity = Random.insideUnitSphere * 5.0f;
        if (target != null && targetFound){

            
            //this.gameObject.transform.GetChild(1).rotation =  Quaternion.Slerp(this.gameObject.transform.GetChild(1).rotation ,rotation, 0.9f);;
            Vector3 relativePos = target.transform.position - transform.position;
            var projectile = Instantiate(bullet,firePoint.position,firePoint.rotation);
            projectile.transform.localScale= new Vector3(0.3f,0.3f,0.8f);
            projectile.gameObject.GetComponent<Projectile>().SetMode("rocket");
            projectile.gameObject.GetComponent<Projectile>().SetRadius(explosionRadius);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(9f * relativePos, ForceMode.Impulse);
            Destroy(projectile,1.5f);
            }
    }
    void Rotate(){
        this.gameObject.transform.GetChild(1).Rotate(0f,1f,0);
    }
    private void OnTriggerStay(Collider collision) {
        if(collision.tag =="enemy"){
            targetFound = true;
            target = collision.gameObject;
        }
    }
   private void OnTriggerExit(Collider other) {
        if(other.tag =="enemy"){
            targetFound = false;
            target = null;
        }
   }

    /*

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            transform.localScale = realScale;
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.name == "Terrain")
        {
            transform.localScale = Vector3.one * 0.2f;
        }
    }
    */

}
