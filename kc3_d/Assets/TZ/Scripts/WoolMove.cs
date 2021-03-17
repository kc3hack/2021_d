using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.divide {
    public class WoolMove : MonoBehaviour {
        [SerializeField] WoolChange[] wools;
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void MoveWoolNext() {
            WoolID beforeID = WoolID.NULL;
            foreach(WoolChange wool in wools) {
                if(beforeID == WoolID.NULL) {
                    beforeID = wool.GetID();
                    wool.SetWool();
                } else {
                    WoolID temp = wool.GetID();
                    wool.ChangeWoolData(beforeID);
                    beforeID = temp;
                }
            }
        }
    }
}