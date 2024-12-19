using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public Transform[] leftBallControlPoints;
    public Transform[] leftBallReturnPoints;
    public Transform[] rightBallControlPoints;
    public Transform[] rightBallReturnPoints;
    public Transform[] smashBallControlPoints;
    public Transform[] smashBallReturnPoints;

    public GameObject[] ballPrefabs;

    public float spawnRate = 2.0f;
    private float spawnTimer = 0.0f;

    /// <summary>
    /// Ball 오브젝트를 스폰합니다.
    /// <param name="ballType"> 공의 타입 </param>
    /// </summary>
    public void SpawnBall(Ball.BallType ballType)
    {
        if (ballType == Ball.BallType.Left)
        {
            GameObject ball = Instantiate(ballPrefabs[0],spawnPoints[0].position,Quaternion.identity);
            Ball ballComponent = ball.GetComponent<Ball>();
            if (ballComponent != null)
            {
                /*
                ballComponent.startPoint = spawnPoints[0];
                ballComponent.controlPoint = leftBallControlPoints[0];
                ballComponent.endPoint = leftBallControlPoints[1];
                ballComponent.controlPoint2 = leftBallControlPoints[2];
                ballComponent.endPoint2 = leftBallControlPoints[3];
                */
                ballComponent.SetControlPoints(spawnPoints[0], leftBallControlPoints, leftBallReturnPoints);
            }
            spawnTimer = 0.0f;
        }
        else if (ballType == Ball.BallType.Right)
        {
            GameObject ball = Instantiate(ballPrefabs[1],spawnPoints[1].position,Quaternion.identity);
            Ball ballComponent = ball.GetComponent<Ball>();
            if (ballComponent != null)
            {
                /*
                ballComponent.startPoint = spawnPoints[1];
                ballComponent.controlPoint = rightBallControlPoints[0];
                ballComponent.endPoint = rightBallControlPoints[1];
                ballComponent.controlPoint2 = rightBallControlPoints[2];
                ballComponent.endPoint2 = rightBallControlPoints[3];
                */
                ballComponent.SetControlPoints(spawnPoints[1], rightBallControlPoints, rightBallReturnPoints);
            }
            spawnTimer = 0.0f;
        }
        else if (ballType == Ball.BallType.Smash)
        {
            GameObject ball = Instantiate(ballPrefabs[2],spawnPoints[2].position,Quaternion.identity);
            Ball ballComponent = ball.GetComponent<Ball>();
            if (ballComponent != null)
            {
                /*
                ballComponent.startPoint = spawnPoints[2];
                ballComponent.controlPoint = smashBallControlPoints[0];
                ballComponent.endPoint = smashBallControlPoints[1];
                ballComponent.controlPoint2 = smashBallControlPoints[2];
                ballComponent.endPoint2 = smashBallControlPoints[3];
                */
                ballComponent.SetControlPoints(spawnPoints[2], smashBallControlPoints, smashBallReturnPoints);
            }
            spawnTimer = 0.0f;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnTimer >= spawnRate)
        {
            /*
            GameObject ball = Instantiate(ballPrefabs[0],spawnPoints[0].position,Quaternion.identity);
            Ball ballComponent = ball.GetComponent<Ball>();
            if (ballComponent != null)
            {
                ballComponent.startPoint = spawnPoints[0];
                ballComponent.controlPoint = rightBallControlPoints[0];
                ballComponent.endPoint = rightBallControlPoints[1];
                ballComponent.controlPoint2 = rightBallControlPoints[2];
                ballComponent.endPoint2 = rightBallControlPoints[3];
            }
            spawnTimer = 0.0f;
            */
            int temp = Random.Range(0, 3);
            switch (temp)
            {
                case 0:
                    SpawnBall(Ball.BallType.Left);
                    break;
                case 1:
                    SpawnBall(Ball.BallType.Right);
                    break;
                case 2:
                    SpawnBall(Ball.BallType.Smash);
                    break;
                default:
                    break;
            }
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
        
    }
}
