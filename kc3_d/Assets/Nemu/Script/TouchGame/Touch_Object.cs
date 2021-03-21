using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LorR{
    Left,
    Right
}

public class Touch_Object : MonoBehaviour
{
    Rigidbody2D rb;
    public float forcex;
    public float forcey;
    LorR direct;
    public Position position;
    bool on = false;

    //デバック用
    /*void Start(){
        Run(Position.Middle);
    }*/

    public void Run(Position pos){
        position = pos;
        rb = GetComponent<Rigidbody2D>();
 
        //加える力
        RandomForce(ref forcex, ref forcey);
        Vector2 force = new Vector2(forcex, forcey);

        //速度に合わせて画像を回転させる
        if(forcex > 0) direct = LorR.Right;
        else if(forcex < 0) direct = LorR.Left;
        else{
            if(Random.value > 0.5f) direct = LorR.Right;
        }

        //Rigidbody2Dに力を加える
        rb.AddForce(force);
        on = true;
    }

    void FixedUpdate()
    {
        SetAngle();
        if(on) DesObj();
    }

    //画像の角度を変更
    void SetAngle(){
        //右向きと左向きで処理を変えます
        if(direct == LorR.Right){
            float rad = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
            float angle = rad * Mathf.Rad2Deg *-1;
            this.transform.rotation = Quaternion.Euler(0f, 180, angle);
        }else{
            float rad = Mathf.Atan2(rb.velocity.y, rb.velocity.x * -1);
            float angle = rad * Mathf.Rad2Deg * -1;
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
       
    }

    //ランダムに加える力を設定する
    void RandomForce(ref float x, ref float y){
        float PowerLim = 0;
        if(position == Position.Forward){
            y = Random.Range(400f,700f);
            PowerLim = Random.Range(y,800f);
        }else if(position == Position.Middle){
            y = Random.Range(300f,600f);
            PowerLim = Random.Range(y,700f);
        }else if(position == Position.Rear){
            y = Random.Range(200f,450f);
            PowerLim = Random.Range(y,600f);
        }

        x = PowerLim - y;
        if(this.transform.position.x > 0){
            x *= -1;
        }
    }

    //自壊する
    void DesObj(){
        if(position == Position.Forward){
            if(this.transform.position.y < -6f) Destroy(this.gameObject);
        }else if(position == Position.Middle) {
            if(this.transform.position.y < -1.8f) Destroy(this.gameObject);
        }else if(position == Position.Rear){
            if(this.transform.position.y < 0.3f) Destroy(this.gameObject);
        }
    }

    public virtual void Touched(){
        StartCoroutine("Touchedanim");
    }

    IEnumerator Touchedanim(){
        rb.velocity = new Vector2(0,10);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
