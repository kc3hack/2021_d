using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace kc3.d.tz.divide {
    public class ScoreManager : MonoBehaviour {

        [SerializeField] Text magnification, score;
        int scoreNum, magNum;
        readonly int BASE_SCORE = 100;
        readonly int BASE_MAG = 1;
        Color HIGH = new Color(0.88f, 0.047f,0.047f,1);
        Color LOW = new Color(0, 0, 0, 1);
        private void Start() {
            magNum = BASE_MAG;
        }
        /// <summary>
        /// 羊選択ボタンが押されたとき、正解不正解がわたされる。スコアや倍率の表示
        /// </summary>
        /// <param name="istrue"></param>
        public void Answerd(bool istrue) {
            int beforeScore = scoreNum;
            if (istrue) {
                scoreNum += BASE_SCORE * magNum;
                if (magNum < 100) {
                    magNum++;
                }
            } else {
                scoreNum -= BASE_SCORE;
                magNum = 1;
            }
            magnification.text = "x" + magNum.ToString();
            CheckMagColor();
            DOTween.To(() => beforeScore, (n) => beforeScore = n, scoreNum, 0.5f)
                .OnUpdate(() => score.text = beforeScore.ToString());
        }
        /// <summary>
        /// 倍率が高いとき色を赤くしてアピールする
        /// </summary>
        public void CheckMagColor() {
            if(magNum >= 30) {
                magnification.color = HIGH;
            } else {
                magnification.color = LOW;
            }
        }
        public int GetScore() {
            return scoreNum;
        }
    }
}
