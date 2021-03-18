using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kc3.d.tz.divide {
    [CreateAssetMenu(menuName = "WoolSprites")]
    public class WoolSpritesObject : ScriptableObject {
        [SerializeField] Sprite[] sprites;

        public Sprite GetSprite(WoolID getID) {
            return sprites[(int)getID];
        }
    }
}
