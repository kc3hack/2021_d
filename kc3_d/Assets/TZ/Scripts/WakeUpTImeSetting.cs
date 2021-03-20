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
        void Start() {
            myField = gameObject.GetComponent<InputField>();
        }

        public void SetHour() {
            string hourText = myField.text;
            if(hourText != "") {
                hour = int.Parse(hourText);
                if(hour < 0) {
                    hour = 0;
                }else if(hour > 23) {
                    hour = 23;
                }
                myField.text = hour.ToString();
                isSetHour = true;
            } else {
                isSetHour = false;
            }
            CheckOnButton();
        }

        public void SetMinute() {
            string minuteText = myField.text;
            if(minuteText != "") {
                minute = int.Parse(minuteText);
                if (minute < 0) {
                    minute = 0;
                } else if(minute > 59) {
                    minute = 59;
                }
                myField.text = minute.ToString();
                isSetMinute = true;
            } else {
                isSetMinute = false;
            }
            CheckOnButton();
        }

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