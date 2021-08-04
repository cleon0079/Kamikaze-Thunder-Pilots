using UnityEngine;

namespace Game.Cleon
{
    public class CharacterMovement : MonoBehaviour
    {
        private GameManager gameManager;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        
        // Update is called once per frame
        private void Update()
        {
            Move();
            Look();
            BulletTime();
        }

        private void BulletTime()
        {
            if(gameManager.canBulletTime)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Time.timeScale = gameManager.bulletTimeModify;
                }
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    Time.timeScale = 1f;
                }
            }
        }
        
        private void Move()
        {
            if(gameManager.canMoveHori)
            {
                transform.Translate(Vector3.right * (Input.GetAxisRaw("Horizontal") * Time.unscaledDeltaTime * gameManager.moveSpeed));
            }
            transform.Translate(Vector3.up * (Input.GetAxisRaw("Vertical") * Time.unscaledDeltaTime * gameManager.moveSpeed));
        }

        private void Look()
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