using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace kc3.d.tz.divide {
    public enum WoolID {
        FEMALE,
        MALE,
        NULL
    }
    public class WoolChange : MonoBehaviour {
        SpriteRenderer myRenderer;
        WoolID myID;
        [SerializeField] WoolSpritesObject woolSpritesObject;

        void Start() {
            myRenderer = gameObject.GetComponent<SpriteRenderer>();
            SetWool();
        }
        /// <summary>
        /// 羊のデータ設定　初期化
        /// </summary>
        public void SetWool() {
            int num = Random.Range(0, 2);
            myID = (WoolID)num;
            myRenderer.sprite = woolSpritesObject.GetSprite(myID);
        }
        /// <summary>
        /// 羊のデータ設定　奥からデータ移動時
        /// </summary>
        /// <param name="nextMyID">移動してくるデータ</param>
        public void ChangeWoolData(WoolID nextMyID) {
            myID = nextMyID;
            myRenderer.sprite = woolSpritesObject.GetSprite(myID);
        }

        public WoolID GetID() {
            return myID;
        }
    }
}
