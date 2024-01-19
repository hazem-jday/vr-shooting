using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    string mode = "bullet";
    float explRadius;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMode(string m){
        mode = m;
    }
    public void SetRadius(float radius){
        explRadius = radius;
    }
    private void OnCollisionEnter(Collision collision) {
        
        GameObject GM = GameObject.Find("gameManager");
        if(collision.gameObject.tag =="enemy" && mode =="bullet"){
            //Destroy(collision.gameObject);
            collision.gameObject.GetComponent<EnemyController>().Die();
            GM.GetComponent<LevelDesign>().KillEnemy();
            Destroy(this.gameObject);
           }
        if ( mode =="rocket"){
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explRadius);
            var e = Instantiate(effect,transform.position,transform.rotation);
            Destroy(e,1f);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.gameObject.tag =="enemy"){
                    Destroy(hitCollider.gameObject);
                    collision.gameObject.GetComponent<EnemyController>().Die();
                    GM.GetComponent<LevelDesign>().KillEnemy();
                }
            }
            Destroy(this.gameObject);
           }
       
    }
}
