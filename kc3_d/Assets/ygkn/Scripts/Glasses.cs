using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour
{
    [SerializeField] RunningState runningState;
    float speed;
    Transform t;

    void Start()
    {
        t = gameObject.GetComponent<Transform>();

        // make sure -1.5 <= y <= 1.5
        float positionY = t.position.y;

        float d = (positionY - 1.5f) / -3;

        speed = -1 * (8 + 4 * d);
    }

    void Update()
    {
        if (runningState.GetState() != RunningState.GameState.Running) {
            return;
        }

        float x = t.position.x + speed * Time.deltaTime;

        t.position = new Vector3(x < -8 ? 2 : x, t.position.y, t.position.z);
    }
}
