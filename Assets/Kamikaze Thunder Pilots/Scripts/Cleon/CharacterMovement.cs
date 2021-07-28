using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Cleon
{
    public class CharacterMovement : MonoBehaviour
    {
        private int moveSpeed = 5;

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.right * (Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed));
            transform.Translate(Vector3.up * (Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed));

            if(Input.GetAxisRaw("Horizontal") == 0)
            {
                Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float angle;

                Vector2 targetDir = mousePoint - transform.position;
                angle = Vector2.Angle(targetDir, Vector3.up);

                if(mousePoint.x > transform.position.x)
                {
                    angle = -angle;
                }

                transform.eulerAngles = new Vector3(0, 0, angle);
            }
        }
    }
}