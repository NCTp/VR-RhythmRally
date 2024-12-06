using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    Right,
    Left,
    Smash
}
public class Ball : MonoBehaviour
{

    public BallType ballType;
    public float upPower = 1.0f;
    private Rigidbody m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Table"))
        {
            Vector3 normal = other.contacts[0].normal;
            Vector3 currentVelocity = m_rb.velocity;
            Vector3 reflectedVelocity = Vector3.Reflect(currentVelocity, normal);
            m_rb.velocity = reflectedVelocity + Vector3.down * -upPower;
            Debug.Log(m_rb.velocity);
            Debug.Log("Table Hit!");
        }
        else if (other.gameObject.CompareTag("Racket"))
        {
            Debug.Log("Racket Hit!");
        }
    }
}
