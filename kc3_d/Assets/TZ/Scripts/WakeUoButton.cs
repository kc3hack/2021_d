using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kc3.d.tz.common;
using kc3.d.tz.evolve;

namespace kc3.d.tz.alarm {
    public class WakeUoButton : MonoBehaviour {
        [SerializeField] TimerSetButton timerSetButton;
        EvolveValue evolveValue;
        [SerializeField] FadeManager fadeManager;
        Dictionary<int, float> DiffToPointConverter = new Dictionary<int, float>() {
            {1,1},
            {2,0.9f},
            {3,0.8f},
            {5,0.7f},
            {8,0.6f},
            {10,0.5f},
            {15,0.4f},
            {20,0.3f},
            {25,0.2f},
            {30,0.1f}
        };
        void Start() {
            evolveValue = EvolveValue.instance;
        }

    public void OnClick() {
            var diff = timerSetButton.GetWakeUpDiff();
            foreach(KeyValuePair<int,float> items in DiffToPointConverter) {
                if(diff <= items.Key) {
                    evolveValue.SetAlarmPoint(items.Value);
                    break;
                }
            }
            fadeManager.FadeInAndSceneLoad();
        }
    }
}