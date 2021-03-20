using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kc3.d.tz.common;

public class TestSceneLoad : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] FadeManager fadeManager;

    public void SceneLoad() {
        fadeManager.FadeInAndSceneLoad();
    }
}
