using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType
    {
        Right,
        Left,
        Smash
    }
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveToTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Table"))
        {

        }
        else if (other.gameObject.CompareTag("Racket"))
        {
            Destroy(this.gameObject);
        }
    }
}
