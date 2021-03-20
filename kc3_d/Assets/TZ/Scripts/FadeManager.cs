using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace kc3.d.tz.common {
    //ここにシーン名を全部完全一致で書く。遷移先シーンはインスペクタからこれを参照したenum変数で設定
    public enum Scenes {
        Home = 0,
        Test = 1,
        DivideGame = 2,
        TouchGame = 3,
    };

    public class FadeManager : MonoBehaviour {

        Image fade;
        readonly int FADE_OUT_ORIGIN = 0;
        readonly int FADE_IN_ORIGIN = 1;
        readonly float FADE_TIME = 1f;
        readonly int WAIT_TIME = 60;
        float variable;
        [SerializeField]
        [Header("フェードイン後、移動する次のシーン名を指定")]
        Scenes moveScene;
        
        void Start() {
            variable = 1.0f / WAIT_TIME;
            fade = gameObject.GetComponent<Image>();
            StartCoroutine(FadeOut());
        }

        /// <summary>
        /// ランダムでミニゲームを選ぶという仕様のため勝手に付け加えています許して
        /// </summary>
        public void SetmoveScene(Scenes changescene){
            moveScene = changescene;
        }

        /// <summary>
        /// 外部から呼ばれてフェードインさせる関数を呼ぶ。デフォルト塗り方向と反対にする設定も
        /// </summary>
        public void FadeInAndSceneLoad() {
            fade.fillOrigin = FADE_IN_ORIGIN;
            fade.fillAmount = 0;
            StartCoroutine(FadeIn());
        }

        /// <summary>
        /// 少しずつフェードするようなコルーチン。
        /// </summary>
        /// <returns></returns>
        IEnumerator FadeOut() {
            fade.fillOrigin = FADE_OUT_ORIGIN;
            fade.fillAmount = 1;
            for(int i = 0; i < 60; i++) {
                yield return new WaitForSeconds(FADE_TIME / WAIT_TIME);
                fade.fillAmount -= variable;
            }
        }

        IEnumerator FadeIn() {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(moveScene.ToString());
            asyncOperation.allowSceneActivation = false;
            for(int i = 0; i < 60; i++) {
                yield return new WaitForSeconds(FADE_TIME / WAIT_TIME);
                fade.fillAmount += variable;
            }
            asyncOperation.allowSceneActivation = true;
        }
    }
}