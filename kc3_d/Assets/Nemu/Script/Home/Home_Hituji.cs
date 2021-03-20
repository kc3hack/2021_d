using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home_Hituji : MonoBehaviour
{
    [SerializeField] Oshaberi oshaberi;
    [SerializeField] GameObject serihu;

    void Start()
    {
        StartCoroutine("Hituji_Active");
    }

    void Update()
    {
        if(Application.isEditor){
            if(Input.GetMouseButtonDown(0)) Talk();
        }
        else if(Input.touchCount > 0) {
            if(Input.GetTouch(0).phase == TouchPhase.Began) Talk();
        }
    }

    IEnumerator Hituji_Active(){
        yield return new WaitForSeconds(1.7f);
        Talk();
    }

    void Talk(){
        int id = Random.Range(0,oshaberi.Count());
        Debug.Log(id);
        serihu.GetComponent<Text>().text = oshaberi.GetTalk(id);
    }

}
