using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    Vector2 vec;
    GameObject manager;
    GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager");
        generator = GameObject.Find("ItemGenerator");
        vec.x = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        vec.x = Mathf.RoundToInt(vec.x);
        if (vec.x >= 1 && vec.x <= 5)
        {
            transform.position = new Vector2(vec.x, -4.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grass")
        {
            this.manager.GetComponent<GameManager>().GetGrass();
            if (this.generator.GetComponent<ItemGenerator>().speed < 25)
            {
                this.generator.GetComponent<ItemGenerator>().speed += 1;
            }
        }else if (collision.gameObject.tag == "wolf")
        {
            this.manager.GetComponent<GameManager>().GetWolf();
            if (this.generator.GetComponent<ItemGenerator>().speed > 5)
            {
                this.generator.GetComponent<ItemGenerator>().speed -= 1;
            }
        }
        Destroy(collision.gameObject);
    }
}
