using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    Animator anim;
    [SerializeField] RunningState runningState;
    [SerializeField] float speed;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.speed = 0.0f;
    }

    void Update()
    {
        anim.speed = runningState.GetState() == RunningState.GameState.Running ? speed : 0;
    }
}
