using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float Speed;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rb.velocity = new Vector2(Speed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Speed *= -1;
            transform.Rotate(0, 180, 0);
        }
    }
}
