using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kc3.d.tz.common;

public class Home_Game : MonoBehaviour
{

    [SerializeField] GameObject popup_;
    [SerializeField] FadeManager fadeManager;
    Scenes movescenes;
    void Start()
    {
        //popup();
    }

    void popup(){
        popup_.SetActive(true);
    }

    public void ToGame(){
        int game = Random.Range(1,4);
        fadeManager.SetmoveScene((Scenes)game);
        fadeManager.FadeInAndSceneLoad();
    }
}
