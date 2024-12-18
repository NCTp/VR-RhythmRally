using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChecker : MonoBehaviour
{
    private Rigidbody m_Rb;
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball Checked");
            Ball ballComponent = other.gameObject.GetComponent<Ball>();
            ballComponent.ballStatus = Ball.BallStatus.PostHit;
            ballComponent.SetMovement();
        }
    }
}
