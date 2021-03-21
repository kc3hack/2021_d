using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace kc3.d.tz.alarm {
    public class WakeUpTImeSetting : MonoBehaviour {
        [SerializeField] Button set;
        static int hour, minute;
        static bool isSetHour, isSetMinute;
        InputField myField;
        readonly int MIN = 0;
        readonly int MAX_HOUR = 23;
        readonly int MAX_MINUTE = 59;
        void Start() {
            myField = gameObject.GetComponent<InputField>();
        }
        /// <summary>
        /// 時間インプットフィールドが編集完了したら呼ばれる。入力を時間のタイマー設定として受け取る。ありえない値は修正。
        /// </summary>
        public void SetHour() {
            string hourText = myField.text;
            if(hourText != "") {
                hour = int.Parse(hourText);
                if(hour < MIN) {
                    hour = MIN;
                }else if(hour > MAX_HOUR) {
                    hour = MAX_HOUR;
                }
                myField.text = hour.ToString("00");
                isSetHour = true;
            } else {
                isSetHour = false;
            }
            CheckOnButton();
        }

        /// <summary>
        ///分インプットフィールドが編集完了したら呼ばれる。入力を分のタイマー設定として受け取る。ありえない値は修正。 
        /// </summary>
        public void SetMinute() {
            string minuteText = myField.text;
            if(minuteText != "") {
                minute = int.Parse(minuteText);
                if (minute < MIN) {
                    minute = MIN;
                } else if(minute > MAX_MINUTE) {
                    minute = MAX_MINUTE;
                }
                myField.text = minute.ToString("00");
                isSetMinute = true;
            } else {
                isSetMinute = false;
            }
            CheckOnButton();
        }
        /// <summary>
        /// 両方の設定が入力されたかを判定。もしそうならタイマー設定ボタンが有効化。
        /// </summary>
        public void CheckOnButton() {
            if(isSetMinute && isSetHour) {
                set.interactable = true;
            } else {
                set.interactable = false;
            }
        }

        public int GetHour() {
            return hour;
        }
        public int GetMinute() {
            return minute;
        }
    }
}