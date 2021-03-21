using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject grass;
    public GameObject wolf;
    float span = 1.0f;
    float delta = 0;
    public float speed  = 5;
    int ratio = 3;
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if (dice <= this.ratio)
            {
                item = Instantiate(wolf) as GameObject;
            }
            else
            {
                item = Instantiate(grass) as GameObject;
            }
            float x = Random.Range(1, 6);
            item.transform.position = new Vector2(x, 6);
            item.GetComponent<PrefabController>().speed = this.speed;
        }
    }
}
