using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace kc3.d.tz.alarm {
    public class TimerSetButton : MonoBehaviour {

        [SerializeField] Text info,count;
        [SerializeField] WakeUpTImeSetting wakeUpTImeSettingHour,wakeUpTImeSettingMinute;
        [SerializeField] GameObject game;
        static int timerHour, timerMinute;
        bool isSet;
        int isFirstSetUp;//boolの代わり　1ならtrue
        int nowHour, nowMinute;

        private void Start() {
            timerHour = PlayerPrefs.GetInt("HOUR", 0);
            timerMinute = PlayerPrefs.GetInt("MINUTE", 0);
            isFirstSetUp = PlayerPrefs.GetInt("ISFIRST", 0);
            if(isFirstSetUp == 0) {
                NotificationManager.RegisterChannel();
                isFirstSetUp = 1;
                PlayerPrefs.SetInt("ISFIRST", isFirstSetUp);
                PlayerPrefs.Save();
            }
            if(timerHour != 0 && timerMinute != 0) {
                isSet = true;
                wakeUpTImeSettingHour.SetInputFieldText(timerHour);
                wakeUpTImeSettingMinute.SetInputFieldText(timerMinute);
            }
        }

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
        /// <summary>
        /// タイマーセットボタンを押したときのコールバック。タイマー時間を取得＆セット
        /// </summary>
        public void TimerSet() {
            timerHour = wakeUpTImeSettingHour.GetHour();
            timerMinute = wakeUpTImeSettingMinute.GetMinute();
            info.text = timerHour + ":" + timerMinute.ToString("00")+ "にタイマーをセットしたメェ～";
            isSet = true;
            PlayerPrefs.SetInt("HOUR", timerHour);
            PlayerPrefs.SetInt("MINUTE", timerMinute);
            PlayerPrefs.Save();

            NotificationManager.SetNotification(GetRemainTime());
        }
        /// <summary>
        /// 起床設定時刻から三十分後までの間か判定
        /// </summary>
        /// <param name="remainTime">タイマーまでの時間</param>
        /// <returns>もし三十分後までならtrueで、ゲームできる状態に</returns>
        public bool isGameTime(int remainTime) {
            if(remainTime > 1410) {
                return true;
            } else {
                return false;
            }
        }
        /// <summary>
        /// 起床で得られる進化経験値を算出するため、設定時刻から何分遅れでゲームスタート(起床)したか計算する
        /// </summary>
        /// <returns>設定時刻からの差分</returns>
        public int GetWakeUpDiff() {
            var remainTime = GetRemainTime();
            var diff = Math.Abs(remainTime);
            return diff;
        }

        public int GetRemainTime() {
            nowHour = DateTime.Now.Hour;
            nowMinute = DateTime.Now.Minute;
            var remainHour = timerHour - nowHour;
            var remainMinute = timerMinute - nowMinute;
            var remainTime = remainHour * 60 + remainMinute;
            return remainTime;
        }
    }
}