using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using kc3.d.tz.evolve;

namespace kc3.d.tz.divide {
    public class TimerCount : MonoBehaviour {
        [SerializeField] Image timerFill;
        [SerializeField] Text timerText;
        [SerializeField] RectTransform timerTransform;
        [SerializeField] ScoreManager scoreManager;
        readonly int GAME_TIME = 60;
        readonly Vector3 TIMER_ANIMATION_SCALE = new Vector3(1.3f, 1.3f, 1);

        EvolveValue evolveValue;
        Dictionary<int, float> ScoreToPointConverter = new Dictionary<int, float>() {
            {1000000,1},
            {800000,0.9f},
            {650000,0.8f},
            {500000,0.7f},
            {300000,0.6f},
            {100000,0.5f},
            {50000,0.4f},
            {10000,0.3f},
            {5000,0.2f}
        };

        void Start() {
            timerFill.DOFillAmount(1, GAME_TIME);
            StartCoroutine(TextTimer());

            evolveValue = EvolveValue.instance;
        }
        /// <summary>
        /// 十秒以後数字でのタイムカウントを行うコルーチン
        /// </summary>
        /// <returns></returns>
        public IEnumerator  TextTimer() {
            yield return new WaitForSeconds(50);
            timerText.text = 10.ToString();
            timerTransform.DOScale(TIMER_ANIMATION_SCALE, 0.5f).SetLoops(20);
            for(int i = 9; i > -1; i--) {
                yield return new WaitForSeconds(1);
                timerText.text = i.ToString();
            }
            evolveValue.SetGamePoint(GetGamePoint());
            SceneManager.LoadScene("Test");
        }

        public float GetGamePoint() {
            var score = scoreManager.GetScore();
            foreach(KeyValuePair<int,float> item in ScoreToPointConverter) {
                if(score >= item.Key) {
                    return item.Value;
                }
            }
            return 0.1f;
        }
    }
}