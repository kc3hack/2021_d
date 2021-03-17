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

        public void SetWool() {
            int num = Random.Range(0, 2);
            myID = (WoolID)num;
            myRenderer.sprite = woolSpritesObject.GetSprite(myID);
        }

        public void ChangeWoolData(WoolID nextMyID) {
            myID = nextMyID;
            myRenderer.sprite = woolSpritesObject.GetSprite(myID);
        }

        public WoolID GetID() {
            return myID;
        }
    }
}
