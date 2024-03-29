using UnityEngine;
using System.Collections;

namespace Game.Cleon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        private GameManager gameManager;
        private Rigidbody2D rb;
        private Animator anim;
        
        //For use with animator
        private float xPos;
        private float yPos;

        // Set up the rigidbody for the player
        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
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
            AnimationInput();
            Move();
            BulletTime();
            // We are not using the mouse rotate anymore
            if(gameManager.canMouseRotate)
            {
                Look();
            }
        }

        /// <summary>
        /// Allow players to slow down the time just like the protagonist of The Matrix
        /// </summary>
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
        
        /// <summary>
        /// Move the player
        /// </summary>
        private void Move()
        {
            if(!gameManager.canvasItemDisplay.activeSelf)
            {
                transform.Translate(Vector3.right * (Input.GetAxisRaw("Horizontal") * Time.unscaledDeltaTime * gameManager.moveSpeed));
                anim.SetBool("isMoving", true);
                transform.Translate(Vector3.up * (Input.GetAxisRaw("Vertical") * Time.unscaledDeltaTime * gameManager.moveSpeed));
            }
        }

        /// <summary>
        /// Setting the animator
        /// </summary>
        private void AnimationInput()
        {
            // Setting the animator - Steveo
            if(Input.GetAxisRaw("Horizontal") > 0.1f)
                xPos = 1;
            else if(Input.GetAxisRaw("Horizontal") < -0.1f)
                xPos = -1;
            else if(Input.GetAxisRaw("Horizontal") == 0)
            {
                xPos = 0;
                anim.SetBool("isMoving", false);
            }
            
            if(Input.GetAxisRaw("Vertical") > 0.1f)
                yPos = 1;
            else if(Input.GetAxisRaw("Vertical") < -0.1f)
                yPos = -1;
            else if(Input.GetAxisRaw("Vertical") == 0)
            {
                yPos = 0;
                anim.SetBool("isMoving", false);
            }
            anim.SetFloat("xPos",xPos);
            anim.SetFloat("yPos",yPos);
        }

        /// <summary>
        /// Let the player turn in the direction of the mouse
        /// </summary>
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
        
        /// <summary>
        /// Calculate the cooldown of bullet time
        /// </summary>
        private IEnumerator BulletTimeCoolDown()
        {
            yield return new WaitForSecondsRealtime(gameManager.bulletTimeLength);
            Time.timeScale = 1;
            yield return new WaitForSecondsRealtime(gameManager.coolDown);
            gameManager.isBulletTime = false;
        }
    }
}