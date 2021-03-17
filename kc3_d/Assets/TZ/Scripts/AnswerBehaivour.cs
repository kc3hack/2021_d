using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace kc3.d.tz.divide {
    public class AnswerBehaivour : MonoBehaviour {
        Transform myTransform;
        SpriteRenderer spriteRenderer;
        readonly Vector3 DISAPPERAR_SCALE= new Vector3(1.5f, 1.5f, 0);
        readonly float DISAPPERAR_TIME = 0.7f;
        readonly Color DISAPPERAR_COLOR = new Color(1, 1, 1, 0.7f);
        void Start() {
            myTransform = gameObject.GetComponent<Transform>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            myTransform.DOScale(DISAPPERAR_SCALE, DISAPPERAR_TIME);
            spriteRenderer.DOColor(DISAPPERAR_COLOR, DISAPPERAR_TIME)
                .OnComplete(DestroyObject);
        }

        public void DestroyObject() {
            Destroy(gameObject);
        }
    }
}
