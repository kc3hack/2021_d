using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float gravity;
    [SerializeField] float jumpSpeed;
    [SerializeField] GroundingCheck groundingCheck;
    [SerializeField] RunningState runningState;

    Rigidbody2D rb = null;

    float jumpElapsedTime = float.PositiveInfinity;
    Animator anim = null;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("run", runningState.IsRunning());

        if (runningState.CanJump() && groundingCheck.IsGround()) {
            jumpElapsedTime = 0.0f;
        }

        jumpElapsedTime += Time.deltaTime;


        rb.velocity = new Vector2(0, Mathf.Max(jumpSpeed - gravity * jumpElapsedTime, -jumpSpeed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hurdle") {
            runningState.GameOver();
        }
    }

}
