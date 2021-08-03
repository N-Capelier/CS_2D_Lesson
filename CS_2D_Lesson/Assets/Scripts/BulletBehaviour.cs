using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Vector2 direction;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float _dir;
        if(direction.x >= 0)
        {
            _dir = 1;
        }
        else
        {
            _dir = -1;
        }

        rb.velocity = new Vector2(_dir * moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}