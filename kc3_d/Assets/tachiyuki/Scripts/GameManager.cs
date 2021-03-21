using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using kc3.d.tz.evolve;
using kc3.d.tz.common;
public class GameManager : MonoBehaviour
{
    GameObject Timetext;
    GameObject Scoretext;
    GameObject generator;
    EvolveValue evolveValue;
    [SerializeField] FadeManager fadeManager;
    float time = 60.0f;
    int score;
    bool play = true;

    public void GetGrass()
    {
        score += 10;
    }

    public void GetWolf()
    {
        if (score > 0)
        {
            score -= 5;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        this.Timetext = GameObject.Find("Time");
        this.Scoretext = GameObject.Find("Score");
        this.generator = GameObject.Find("ItemGenerator");
        evolveValue = EvolveValue.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            generator.SetActive(false);
            if(play){
                evolveValue.SetGamePoint(score / 300);
                fadeManager.FadeInAndSceneLoad();
                play = false;
            }
        }
        else
        {
            this.time -= Time.deltaTime;
        }
        this.Timetext.GetComponent<Text>().text = "Time : " + this.time.ToString("F1");
        this.Scoretext.GetComponent<Text>().text = "Score : " + this.score.ToString("F1");
        
    }
}
