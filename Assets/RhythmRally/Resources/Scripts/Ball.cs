using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public enum BallType
    {
        Left,
        Right,
        Smash
    }
    public enum BallStatus
    {
        PreHit, // Hit 되지 않은 상태, 플레이어에게 다가오는 상태, 라켓에 부딪히지 않은 상태
        PostHit // Hit 된 상태, 라켓에 부딪힌 상태
    }
    [Header("Ball Properties")]
    public BallType ballType;
    public BallStatus ballStatus = BallStatus.PreHit;
    public float destroyTime = 10.0f;
    
    [Header("Movement Setup")]
    public float speed = 1.0f;
    private float m_speed;
    public bool isHitTable = false;
    public Vector3 preHitDirection;
    public Vector3 postHitDirection;
    public Transform postHitTarget;

    [Header("Movement Points")] 
    public Transform startPoint; // 출발
    public Transform controlPoint; // 중간 지점
    public Transform endPoint; // 도착
    public Transform controlPoint2; // 중간 지점 2
    public Transform endPoint2; // 도착
    public Transform returnPoint; // 반대방향 테이블 지점
    public Transform returnControlPoint; // 중간지점 3
    public Transform returnPoint2; // 반대 테이블 부딪힌 후 이동하는 방향
    public Transform returnControlPoint2; // 중간지점 4

    private Transform m_startPoint;
    private Transform m_controlPoint;
    private Transform m_endPoint;
    
    
    private float t = 0f; // 베지에 곡선의 진행 정도 0~1
    private Vector3 movePos; // 움직일 위치 결정
    
    ////////////// Components //////////////
    private Rigidbody m_BallRb;

    /// <summary>
    /// InitBall()
    /// Ball 오브젝트의 멤버 변수들을 초기화합니다.
    /// Ball 타입에 따라 다른 값들을 지정합니다.
    /// </summary>
    public void SetControlPoints(Transform startPointInput, Transform[] ControlPoints, Transform[] ReturnPoints)
    {
        startPoint = startPointInput;
        controlPoint = ControlPoints[0];
        endPoint = ControlPoints[1];
        controlPoint2 = ControlPoints[2];
        endPoint2 = ControlPoints[3];
        returnPoint = ReturnPoints[0];
        returnControlPoint = ReturnPoints[1];
        returnPoint2 = ReturnPoints[2];
        returnControlPoint2 = ReturnPoints[3];

        ChangeDirection(startPoint, controlPoint, endPoint);
    }
    

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
                m_speed = -speed;
                preHitDirection = Vector3.forward * m_speed;
                break;
            case BallType.Right:
                m_speed = -speed;
                preHitDirection = Vector3.forward * m_speed;
                break;
            case BallType.Smash:
                m_speed = -speed * 10.0f;
                preHitDirection = Vector3.forward * m_speed;
                break;
            default:
                break;
        }
        
        Quaternion q = Quaternion.Euler(0f, Random.Range(10.0f, 30.0f), 0f);

        postHitDirection = q * -preHitDirection;
    }

    /// <summary>
    /// Movement()
    /// Ball 오브젝트의 기본 움직임을 정의합니다.
    /// </summary>
    public void SetMovement()
    {
        if (m_BallRb != null)
        {
            Debug.Log("Set Movement");
            if (ballStatus == BallStatus.PreHit)
            {
                m_BallRb.velocity = preHitDirection;
                Debug.Log(m_BallRb.velocity);
            }
            else if (ballStatus == BallStatus.PostHit)
            {
                m_BallRb.velocity = postHitDirection;
            }
        }
    }
    
    /// <summary>
    /// 2차 베지에 곡선을 계산하는 함수
    /// <param name="t">진행 정도 (0~1)</param>
    /// <param name="p0">출발점</param>
    /// <param name="p1">중간 제어점</param>
    /// <param name="p2">도착점</param>
    /// <returns>곡선 상의 위치</returns>
    /// </summary>
    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        return u * u * p0 + 2 * u * t * p1 + t * t * p2;
    }
    /// <summary>
    /// 공 방향을 지정
    /// </summary>
    public void ChangeDirection(Transform s, Transform c, Transform e)
    {
        t = 0;
        m_startPoint = s;
        m_controlPoint = c;
        m_endPoint = e;
    }
    // Start is called before the first frame update
    void Start()
    {
        InitBall();
        m_BallRb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        // t 값을 증가시켜 경로를 따라 이동
        t += Time.deltaTime * -m_speed;
        if (t > 1f)
        {
            t = 1f; // t가 1을 초과하지 않도록 제한
        }

        // 베지에 곡선을 따라 포물선 경로를 계산
        movePos = CalculateQuadraticBezierPoint(t, m_startPoint.position, m_controlPoint.position, m_endPoint.position);
        transform.position = movePos;
    }
    

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Table"))
        {
            Debug.Log("Table Detected");
            t = 0.0f;
            ChangeDirection(endPoint, controlPoint2, endPoint2);
            isHitTable = true;
        }
    }

}
