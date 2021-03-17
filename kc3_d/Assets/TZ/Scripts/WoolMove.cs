using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.divide {
    public class WoolMove : MonoBehaviour {
        [SerializeField] WoolChange[] wools;

        /// <summary>
        /// 羊を奥のやつから手前のやつに動かす(データだけ)　最奥は移動後のデータを作成する
        /// </summary>
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