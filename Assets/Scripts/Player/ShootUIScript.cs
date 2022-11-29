using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootUIScript : MonoBehaviour {
    [SerializeField] private RectTransform BarRectTransform;
    [SerializeField] private ShootBall playerShootBall;
    private float posStart;
    private float scaleStart;

    private void Start() {

        posStart = BarRectTransform.anchoredPosition.y;
        scaleStart = BarRectTransform.localScale.y;
    }

    private void Update() {
        BarRectTransform.sizeDelta = new Vector2(BarRectTransform.sizeDelta.x, 4f*(playerShootBall.charge));
        BarRectTransform.anchoredPosition = new Vector2(BarRectTransform.anchoredPosition.x, 50 + 2f * (playerShootBall.charge));

    }
}
