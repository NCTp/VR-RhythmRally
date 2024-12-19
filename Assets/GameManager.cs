using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int score = 0;
    public float ballSpawnStartTime = 3.0f;
    private float startTimer = 0.0f;

    public GameObject xrOrigin;

    public Vector3 xrOriginPosOffset;

    public BallSpawner ballSpawner;
    // Start is called before the first frame update
    void Start()
    {
        xrOrigin.transform.position = xrOriginPosOffset;
        SoundManager.Instance.StartMusic();
        
    }

    // Update is called once per frame
    void Update()
    {
        xrOrigin.transform.position = xrOriginPosOffset;
        if (startTimer >= ballSpawnStartTime)
        {
            ballSpawner.StartSpawn();
        }
        else
        {
            startTimer += Time.deltaTime;
        }
    }
}
