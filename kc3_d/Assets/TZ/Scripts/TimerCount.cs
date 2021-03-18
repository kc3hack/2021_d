using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace kc3.d.tz.divide {
    public class TimerCount : MonoBehaviour {
        [SerializeField] Image timerFill;
        [SerializeField] Text timerText;
        [SerializeField] RectTransform timerTransform;
        readonly int GAME_TIME = 60;
        readonly Vector3 TIMER_ANIMATION_SCALE = new Vector3(1.3f, 1.3f, 1);

        void Start() {
            timerFill.DOFillAmount(1, GAME_TIME);
            StartCoroutine(TextTimer());
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
        }
    }
}