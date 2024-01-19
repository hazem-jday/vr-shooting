using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    public int numberOfBalls = 30;
    public float minY = 2f;
    public float maxY = 8f;
    public float minX = -15f;
    public float maxX = 15f;
    public float minZ = -15f;
    public float maxZ = 15f;
    public float maxInitialSpeed = 2f;
    public static int score = 0;

    void Start()
    {
        score = 0;
        GenerateBalls();
    }

    void GenerateBalls()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY),
                Random.Range(minZ, maxZ)
            );

            GameObject ball = Instantiate(ballPrefab, position, Quaternion.identity);
            ball.SetActive(true);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Give each ball a random initial velocity
                Vector3 initialVelocity = new Vector3(
                    Random.Range(-maxInitialSpeed, maxInitialSpeed),
                    Random.Range(-maxInitialSpeed, maxInitialSpeed),
                    Random.Range(-maxInitialSpeed, maxInitialSpeed)
                );

                rb.velocity = initialVelocity;
            }
        }
    }

    void FixedUpdate()
    {
        CheckOutOfBounds();
    }

    void CheckOutOfBounds()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject ball in balls)
        {
            if (ball.active)
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                Vector3 position = ball.transform.position;

                // Check if the ball is out of bounds and invert velocity if needed
                if (position.x < minX || position.x > maxX)
                {
                    rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
                }

                if (position.y < minY || position.y > maxY)
                {
                    rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
                }

                if (position.z < minZ || position.z > maxZ)
                {
                    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
                }
            }
            
        }
    }
}
