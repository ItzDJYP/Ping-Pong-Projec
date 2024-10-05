using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour 
{
    public float speed = 5.0f;
    public float offset = 0.5f;  // Adjust the offset to control the reaction time of the AI
    public float boundY = 2.25f;  // Adjust as needed
    private Transform ballTransform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ball = GameObject.FindWithTag("Ball");

        if (ball != null)
        {
            ballTransform = ball.transform;
        }
        else
        {
            Debug.LogError("Ball not found. Make sure the Ball GameObject has the 'Ball' tag.");
        }
    }
    void Update()
    {
        if (ballTransform != null)
        {
            float targetY = Mathf.MoveTowards(transform.position.y, ballTransform.position.y, speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, targetY);
        }
    }
}