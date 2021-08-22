using UnityEngine;

namespace Game.Cleon
{
    public class CameraFollow : MonoBehaviour
    {
        private GameManager gameManager;
        private GameObject player;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            player = FindObjectOfType<CharacterMovement>().gameObject;
        }

        private void Update()
        {
            Follow();
        }

        /// <summary>
        /// Let the camera move with the player's movement and can rotate around the player
        /// </summary>
        private void Follow()
        {
            // Get the mouse world position 
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Get the distance from mouse to player
            float dis = Vector3.Distance(mousePoint, player.transform.position);
            // If the distance is less then the numble we set the use the mouse position as the camera position
            if(dis < gameManager.cameraDis)
            {
                transform.position = new Vector3(mousePoint.x,mousePoint.y,transform.position.z);
            }
            // If the distance is lager then the numble we set then get the dir from mouse and player and use the number we set as the dis for the camera 
            else
            {
                Vector2 targetDir = (mousePoint - player.transform.position).normalized * gameManager.cameraDis;
                Vector3 target = new  Vector3(targetDir.x, targetDir.y, transform.position.z);
                transform.position = target + player.transform.position;
            }
        }
    }
}