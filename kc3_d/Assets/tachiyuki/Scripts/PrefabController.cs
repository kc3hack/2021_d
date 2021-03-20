using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(rb.velocity.x, -speed);
    }
}
