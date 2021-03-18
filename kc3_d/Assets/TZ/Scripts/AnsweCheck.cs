using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.divide{
    public class AnsweCheck : MonoBehaviour {
        [SerializeField] WoolChange foremost;
        [SerializeField] AnswerApper answerApper;
        [SerializeField] WoolMove woolMove;
        [SerializeField] ScoreManager scoreManager;
        public void OnClickFemaleButton() {
            if(foremost.GetID() == WoolID.FEMALE) {
                answerApper.AppeearAns(WoolID.FEMALE, true);
                scoreManager.Answerd(true);
            } else {
                answerApper.AppeearAns(WoolID.FEMALE, false);
                scoreManager.Answerd(false);
            }
            woolMove.MoveWoolNext();
        }

        public void OnClickMaleButton() {
            if (foremost.GetID() == WoolID.MALE) {
                answerApper.AppeearAns(WoolID.MALE, true);
                scoreManager.Answerd(true);
            } else {
                answerApper.AppeearAns(WoolID.MALE, false);
                scoreManager.Answerd(false);
            }
            woolMove.MoveWoolNext();
        }
    }
}