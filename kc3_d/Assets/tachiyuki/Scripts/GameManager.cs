using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject Timetext;
    GameObject Scoretext;
    GameObject generator;
    float time = 60.0f;
    int score;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 0)
        {
            generator.SetActive(false);
        }
        else
        {
            this.time -= Time.deltaTime;
        }
        this.Timetext.GetComponent<Text>().text = "Time : " + this.time.ToString("F1");
        this.Scoretext.GetComponent<Text>().text = "Score : " + this.score.ToString("F1");
    }
}
