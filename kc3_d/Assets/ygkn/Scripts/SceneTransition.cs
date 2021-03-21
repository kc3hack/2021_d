using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kc3.d.tz.evolve;
using kc3.d.tz.common;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] FadeManager fadeManager;
    [SerializeField] RunningState runningState;

    EvolveValue evolveValue;
    bool loading = false;

    void Start (){
        evolveValue = EvolveValue.instance;
    }

    void Update()
    {
        if(runningState.GetState() == RunningState.GameState.End) {

            if(!loading){
                evolveValue.SetGamePoint(runningState.GetScore() / 120.0f);
                fadeManager.FadeInAndSceneLoad();
                loading = true;
            }
            
        }
    }
}
