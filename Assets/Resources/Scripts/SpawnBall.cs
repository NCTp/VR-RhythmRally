using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [Header("Ball Prefabs")]
    public GameObject leftBallPrefab;
    public GameObject rightBallPrefab;
    public GameObject smashBallPrefab;
    [Header("Ball Spawn Settings")]
    public float speed = 1.0f;
    public float smashSpeed = 3.0f;
    public float gravityAmount = 0.1f;
    public float smashGravityAmount = 0.01f;
    public bool isRight = false;

    //private Vector3 

    public void Spawn(BallType ballType)
    {
        if(ballType == BallType.Left)
        {
            GameObject ball = Instantiate(leftBallPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = (Vector3.forward + Vector3.down * gravityAmount) * -speed;
        }
        else if(ballType == BallType.Right)
        {
            GameObject ball = Instantiate(rightBallPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = (Vector3.forward + Vector3.down * gravityAmount) * -speed; 
        }
        else if(ballType == BallType.Smash)
        {
            GameObject ball = Instantiate(smashBallPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody>().velocity = (Vector3.forward + Vector3.down * smashGravityAmount) * -smashSpeed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Spawn(BallType.Left);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            Spawn(BallType.Right);
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            Spawn(BallType.Smash);
        }
    }
}
