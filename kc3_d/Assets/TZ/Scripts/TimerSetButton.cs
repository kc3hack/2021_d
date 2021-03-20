using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace kc3.d.tz.alarm {
    public class TimerSetButton : MonoBehaviour {

        [SerializeField] Text info,count;
        [SerializeField] WakeUpTImeSetting wakeUpTImeSetting;
        [SerializeField] GameObject game;
        int timerHour, timerMinute;
        bool isSet;
        int nowHour, nowMinute;

        private void Update() {
            if (isSet) {
                nowHour = DateTime.Now.Hour;
                nowMinute = DateTime.Now.Minute;
                var remainHour = timerHour - nowHour;
                var remainMinute = timerMinute - nowMinute;

                if(remainMinute < 0) {
                    remainMinute = 60 + remainMinute;
                    remainHour--;
                }

                if(remainHour < 0) {
                    remainHour = 24 + remainHour;
                }

                if(remainHour == 0 && remainMinute == 0) {
                    count.text = "おきてください";
                    game.SetActive(true);
                    Debug.Log("時間です");
                }else if (remainHour == 23) {
                    if (isGameTime(remainHour * 60 + remainMinute)) {
                        count.text = "おきてください";
                        game.SetActive(true);
                    }
                } else {
                    game.SetActive(false);
                    count.text = "あと" + remainHour + "時間" + remainMinute + "分";
                }
            }
        }

        public void TimerSet() {
            timerHour = wakeUpTImeSetting.GetHour();
            timerMinute = wakeUpTImeSetting.GetMinute();
            info.text = timerHour + ":" + timerMinute.ToString("00")+ "にタイマーをセットしたメェ～";
            isSet = true;
        }

        public bool isGameTime(int remainTime) {
            if(remainTime > 1410) {
                return true;
            } else {
                return false;
            }
        }

        public int GetWakeUpDiff() {
            nowHour = DateTime.Now.Hour;
            nowMinute = DateTime.Now.Minute;
            var remainHour = timerHour - nowHour;
            var remainMinute = timerMinute - nowMinute;
            var remainTime = remainHour * 60 + remainMinute;
            var diff = Math.Abs(remainTime);
            return diff;
        }
    }
}