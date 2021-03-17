using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.divide {
    public class AnswerApper : MonoBehaviour {
        [SerializeField] Transform[] ansPos;
        [SerializeField] GameObject circle, cross;
        public void AppeearAns(WoolID selected,bool istrue) {
            if (istrue) {
                Instantiate(circle, ansPos[(int)selected]);
            } else {
                Instantiate(cross, ansPos[(int)selected]);
            }
        }
    }
}
