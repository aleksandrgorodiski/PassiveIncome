using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TPSShooter
{
    public class Joystick : MonoBehaviour
    {
        [SerializeField]
        private GameObject circle, dot;
        Touch oneTouch;
        //[SerializeField]
        //private RectTransform circleRect, dotRect;
        private Vector2 touchPosition;
        private Vector2 moveDirection;
        public float maxRadius;
        [HideInInspector]
        public bool IsTouched;
        [HideInInspector]
        public float Horizontal, Vertical;
        private float speedKoef = 0.02f;

        void Start()
        {
            circle.SetActive(false);
            dot.SetActive(false);
        }

        void Update()
        {
#if UNITY_EDITOR
            if (Input.GetButton("Fire1"))
            {
                touchPosition = Input.mousePosition;
                if (!IsTouched)
                {
                    IsTouched = true;
                    circle.SetActive(true);
                    dot.SetActive(true);
                    circle.transform.position = touchPosition;
                    dot.transform.position = touchPosition;
                }
                MovePlayer();
            }
            else
            {
                IsTouched = false;
                circle.SetActive(false);
                dot.SetActive(false);
            }
#else
        if (Input.touchCount > 0)
        {
            IsTouched = true;
            oneTouch = Input.GetTouch(0);
            touchPosition = oneTouch.position;
            switch (oneTouch.phase)
            {
                case TouchPhase.Began:
                    circle.SetActive(true);
                    dot.SetActive(true);
                    circle.transform.position = touchPosition;
                    dot.transform.position = touchPosition;
                    break;
                case TouchPhase.Stationary:
                    MovePlayer();
                    break;
                case TouchPhase.Moved:
                    MovePlayer();
                    break;
                case TouchPhase.Ended:
                    circle.SetActive(false);
                    dot.SetActive(false);
                    break;
            }
        }
        else
        {
            IsTouched = false;
        }
#endif
        }
        private void MovePlayer()
        {
            dot.transform.position = touchPosition;
            dot.transform.localPosition = Vector2.ClampMagnitude(dot.transform.localPosition, maxRadius);
            moveDirection = (dot.transform.position - circle.transform.position) * speedKoef;
            Horizontal = moveDirection.x;
            Vertical = moveDirection.y;
        }
    }
}

