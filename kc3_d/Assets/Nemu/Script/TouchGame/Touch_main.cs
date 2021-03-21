using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using kc3.d.tz.evolve;
using kc3.d.tz.common;

public enum Position{
    Middle = 0,
    Forward = 1,
    Rear = -1
}

enum Touch_Type{
    Hituji,
    Wolf
}

public class Touch_main : MonoBehaviour
{
    [SerializeField] Camera camera_;
    [SerializeField] GameObject button_;
    [SerializeField] GameObject text_;
    [SerializeField] Text timer_;
    [SerializeField] Text point_;
    [SerializeField] Text combo_;
    [SerializeField] FadeManager fadeManager;

    GameObject hituji;
    GameObject wolf;

    EvolveValue evolveValue;
    
    bool play = false;
    public float time = 120.00f;

    public double point = 0;
    int combo = 0;

    const int MAX_POINT = 25000;

    void Start()
    {   
        evolveValue = EvolveValue.instance;
        //変更する可能性あり
        hituji = (GameObject)Resources.Load ("Hituji");
        wolf = (GameObject)Resources.Load ("Wolf");
    }

    void Update(){
        if(play) Timer();
        if(Application.isEditor){
            if(Input.GetMouseButtonDown(0)) Touch();
        }
        else if(Input.touchCount > 0) {
            if(Input.GetTouch(0).phase == TouchPhase.Began) Touch();
        }
    }

    public void OnClick(){
        button_.SetActive(false);
        play = true;
        StartCoroutine("Pop");
    }

    //時間を測ります
    void Timer(){
        time -= Time.deltaTime;
        if(time < 0){
            text_.SetActive(true);
            play = false;
        }
        timer_.text = $"{(int)time/60}:{((int)time%60).ToString("D2")}";
    }

    //タッチ判定
    void Touch(){
        Debug.Log("Touch!");
        Ray ray;
        if(Application.isEditor) ray = camera_.ScreenPointToRay(Input.mousePosition);
        else ray = camera_.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, 50);

        if(hit.collider){
            if(hit.collider.gameObject.name == "Hituji(Clone)") Point(Touch_Type.Hituji);
            else if(hit.collider.gameObject.name == "Wolf(Clone)") Point(Touch_Type.Wolf);
            hit.collider.gameObject.GetComponent<Touch_Object>().Touched();
        }

    }

    //ポイントを加算する
    void Point(Touch_Type type){
        if(type == Touch_Type.Hituji){
            point += 100 * ( 1 + combo * 0.1 );
            combo++;
        }
        else if(type == Touch_Type.Wolf){
            point -= 200;
            combo = 0;
        }
        Debug.Log(combo);
        if(point < 0) point = 0;
        point_.text = $"{point.ToString("F0")}";

        if(combo == 0)combo_.gameObject.SetActive(false);
        else if(combo == 1)combo_.gameObject.SetActive(true);
        combo_.text = $"{combo}Combo!";
    }

    //何かを生成
    IEnumerator Pop(){
        while(play){
            Touch_Type type;
            if(Random.Range(0f,1f) < 0.2f){
                type = Touch_Type.Wolf;
            }else{
                type = Touch_Type.Hituji;
            }

            Position position;
            if(Random.Range(0f,1f) >= 0.5f) position = Position.Middle;
            else if(Random.Range(0f,1f) >= 0.2f) position = Position.Rear;
            else position = Position.Forward;
            Set(position, type);
            yield return new WaitForSeconds(Random.Range(0.25f + time / 240, 0.5f + time / 120));
        }
        yield return new WaitForSeconds(1);
        Finish();
    }

    //座標を設定
    void Set(Position position,Touch_Type type){
        GameObject obj = null;

        if(type == Touch_Type.Hituji) obj = hituji;
        else if(type == Touch_Type.Wolf) obj = wolf;

        float posx = Random.Range(-2.5f,2.5f);
        //前方後方中央によって生成場所変更
        if(position == Position.Forward){
            GameObject hoge = Instantiate (obj, new Vector3(posx,-5f,1f), Quaternion.identity);
            hoge.GetComponent<Touch_Object>().Run(position);
        }
        else if(position == Position.Middle){
            GameObject hoge = Instantiate (obj, new Vector3(posx,-1.8f,11f), Quaternion.identity);
            hoge.transform.localScale = new Vector3(0.75f,0.75f,0.75f);
            hoge.GetComponent<Touch_Object>().Run(position);
        }
        else if(position == Position.Rear){
            GameObject hoge = Instantiate (obj, new Vector3(posx,0.3f,21f), Quaternion.identity);
            hoge.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            hoge.GetComponent<Touch_Object>().Run(position);
        } 
    }

    //終了時
    void Finish(){
        float score = ((float)point+1) / (MAX_POINT+1);
        if(score > 1) score = 1;
        evolveValue.SetGamePoint(score);
        fadeManager.FadeInAndSceneLoad();
    }

}