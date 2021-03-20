using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Hituji : MonoBehaviour
{
    [SerializeField] Oshaberi oshaberi;
    [SerializeField] Camera camera_;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Text serihu_;
    [SerializeField] GameObject hukidasi_;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Hituji_Active");
        //StartCoroutine("Hituji_Move");
    }

    void Update()
    {
        if(hukidasi_.activeSelf){
            if(Application.isEditor){
                if(Input.GetMouseButtonDown(0)) Touch();
            }
            else if(Input.touchCount > 0) {
                if(Input.GetTouch(0).phase == TouchPhase.Began) Touch();
            }
        }
    }

    IEnumerator Hituji_Active(){
        yield return new WaitForSeconds(2.5f);
        hukidasi_.SetActive(true);
        Talk();
    }
    
    IEnumerator Hituji_Move(){
        yield return new WaitForSeconds(2.5f);
        rb.velocity += new Vector2(1,1);
    }

    void Talk(){
        int id = Random.Range(0,oshaberi.Count());
        serihu_.text = oshaberi.GetTalk(id);
    }

    void Touch(){
        Debug.Log("Touch!");
        Ray ray;
        if(Application.isEditor) ray = camera_.ScreenPointToRay(Input.mousePosition);
        else ray = camera_.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 50);

        if(hit.collider){
            Talk();
        }

    }

}
