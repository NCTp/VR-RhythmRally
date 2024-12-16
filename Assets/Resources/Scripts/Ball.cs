using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType
    {
        Left,
        Right,
        Smash
    }
    [Header("Ball Properties")]
    public BallType ballType;

    public float speed = 1.0f;
    private float m_speed;
    
    
    ////////////// Components //////////////
    private Rigidbody m_BallRb;
    

    /// <summary>
    /// InitBall()
    /// Ball 오브젝트의 멤버 변수들을 초기화합니다.
    /// Ball 타입에 따라 다른 값들을 지정합니다.
    /// </summary>
    public void InitBall()
    {
        switch (ballType)
        {
            case BallType.Left:
                m_speed = 1.0f;
                break;
            case BallType.Right:
                m_speed = 1.0f;
                break;
            case BallType.Smash:
                m_speed = 2.0f;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Movement()
    /// Ball 오브젝트의 기본 움직임을 정의합니다.
    /// </summary>
    public void Movement()
    {
        m_BallRb.velocity = Vector3.forward * m_speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_BallRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
