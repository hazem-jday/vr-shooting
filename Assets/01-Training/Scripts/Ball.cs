using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public TMPro.TMP_Text score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball"))
        {
            BallGenerator.score++;
            score.text = "" + BallGenerator.score;
            Destroy(gameObject);
        }
    }
}
