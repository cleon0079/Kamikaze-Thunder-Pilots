using UnityEngine;
using System.Collections;

namespace Game.Cleon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        private GameManager gameManager;
        private Rigidbody2D rb;

        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            rb = GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
        
        // Update is called once per frame
        private void Update()
        {
            Move();
            BulletTime();
            if(gameManager.canMouseRotate)
            {
                Look();
            }
        }

        private void BulletTime()
        {
            if(gameManager.canBulletTime)
            {
                if(Input.GetKeyDown(KeyCode.Space) && !gameManager.isBulletTime)
                {
                    gameManager.isBulletTime = true;
                    gameManager.bulletTimeCDImage.fillAmount = 1;
                    gameManager.currentCDTime = 0;
                    Time.timeScale = gameManager.bulletTimeModify;
                    StartCoroutine(BulletTimeCoolDown());
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
        
        private IEnumerator BulletTimeCoolDown()
        {
            yield return new WaitForSecondsRealtime(gameManager.bulletTimeLength);
            Time.timeScale = 1;
            yield return new WaitForSecondsRealtime(gameManager.coolDown);
            gameManager.isBulletTime = false;
        }
    }
}