using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.evolve {
    public class EvolveValue {

        private static EvolveValue thisInstance;
        Values values;

        public class Values {
            public float alarmPoint = 0.5f;
            public float gamePoint = 0.5f;
        }

        private EvolveValue() {
            values = new Values();
        }

        public static EvolveValue instance {
            get {
                if (thisInstance == null) {
                    thisInstance = new EvolveValue();
                }
                return thisInstance;
            }
        }
        /// <summary>
        /// アラーム止めた後、起きれた度合いを引数に呼び出して、起きれた度合いを保存するメソッド　0-1で
        /// </summary>
        /// <param name="point"></param>
        public void SetAlarmPoint(float point) {
            values.alarmPoint = point;
        }
        /// <summary>
        /// ゲーム終了後、スコアを引数に呼び出して、保存するメソッド　0-1で
        /// </summary>
        /// <param name="point"></param>
        public void SetGamePoint(float point) {
            values.gamePoint = point;
        }

        /// <summary>
        /// 二種の進化用値から進化の指標となる値を計算する。式は仮。代入以前に呼び出しても動くけどバグなのでそうならないようになんとかする
        /// </summary>
        /// <returns></returns>
        public float GetEvolveNum() {
            return values.alarmPoint * 3 + values.gamePoint * 7;
        }
    }
}