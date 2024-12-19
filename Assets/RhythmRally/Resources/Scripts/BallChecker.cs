using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChecker : MonoBehaviour
{
    private Rigidbody m_Rb;
    private bool isVibrating = false;
    public OVRInput.Controller controller;
    public float vibrationDuration = 1.0f;

    private IEnumerator VibrateController()
    {
        isVibrating = true;
        OVRInput.SetControllerVibration(1.0f, 0.5f, controller);
        yield return new WaitForSeconds(vibrationDuration);
        OVRInput.SetControllerVibration(0, 0, controller);
        isVibrating = false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        OVRInput.SetControllerVibration(1.0f, 0.5f, controller);
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
            StartCoroutine(VibrateController());
            Ball ballComponent = other.gameObject.GetComponent<Ball>();
            ballComponent.ballStatus = Ball.BallStatus.PostHit;
            ballComponent.ChangeDirection(other.gameObject.transform, ballComponent.returnControlPoint, ballComponent.returnPoint);
            //ballComponent.SetMovement();
            //Destroy(other.gameObject);
        }
    }
}
