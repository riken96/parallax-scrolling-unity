using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parallax.ParallaxCameras
{
    public class ParallaxCamera : MonoBehaviour
    {
        public delegate void ParallaxCameraDelegate(float deltaMovement);
        public ParallaxCameraDelegate onCameraTranslate;
        private float oldPosition;
        public float speed = 1.0f;
        void Start()
        {
            oldPosition = transform.position.x;
        }
        void Update()
        {
            if (transform.position.x != oldPosition)
            {
                if (onCameraTranslate != null)
                {
                    float delta = oldPosition - transform.position.x;
                    onCameraTranslate(delta);
                }
                oldPosition = transform.position.x;
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -83f, 72f), Mathf.Clamp(transform.position.y, 4f, 4f), Mathf.Clamp(transform.position.z, -10f, 10f));

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
    }

}
