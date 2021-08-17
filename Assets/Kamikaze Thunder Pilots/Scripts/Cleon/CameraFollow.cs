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

        private void Follow()
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float dis = Vector3.Distance(mousePoint, player.transform.position);
            if(dis < gameManager.cameraDis)
            {
                transform.position = new Vector3(mousePoint.x,mousePoint.y,transform.position.z);
            }
            else
            {
                Vector2 targetDir = (mousePoint - player.transform.position).normalized * gameManager.cameraDis;
                Vector3 target = new  Vector3(targetDir.x, targetDir.y, transform.position.z);
                transform.position = target + player.transform.position;
            }
        }
    }
}