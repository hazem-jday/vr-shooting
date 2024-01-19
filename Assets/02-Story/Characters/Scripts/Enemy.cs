using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;

    public float life = 100f;
    public float speed = 2f;
    public float attackRange = 4f;
    public float waitTime = 2f;

    public Transform target;
    public NavMeshAgent navMeshAgent;
    public bool mustAttack = true;
    public bool mustWait = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        target = GameObject.Find("target").transform;

    }

private void Update()
    {
        if (life <= 0)
        {
            Die();
            return;
        }

        if (mustAttack && !mustWait)
        {

            MoveAndAttack();
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    private void MoveAndAttack()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > attackRange)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("Walk", true);
            if(distanceToTarget <= attackRange)
                transform.LookAt(target);

        }
        else
        {

            navMeshAgent.ResetPath();
            animator.SetBool("Walk", false);

            if (!mustWait)
            {
                transform.LookAt(target);
                StartCoroutine(Attack());

            }
        }
    }

    private IEnumerator Attack()
    {
        mustWait = true;
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(waitTime);

        if(!LevelDesign.gameOver)
            LevelDesign.wellhealth-=5;
        if(LevelDesign.wellhealth <= 0)
        {
            LevelDesign.gameOver = true;
        }

        animator.SetBool("Attack", false);
        mustWait = false;
    }

    public void Die()
    {
        animator.SetBool("Death", true);
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", false);
        navMeshAgent.speed = 0f;
        // You may add additional actions for death, like disabling components, playing death sound, etc.
        Destroy(gameObject, 1f); // Destroy the GameObject after 2 seconds (adjust as needed)
    }

    // You may add more functions for taking damage, handling collisions, etc.
}
