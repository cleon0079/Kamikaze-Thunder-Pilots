using System;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.Cleon
{
    public class GameManager : MonoBehaviour
    {
        [Header("Character Setting")] 
        public float moveSpeed = 5f;
        public bool canMoveHori = false;
        public bool canMouseRotate = false;
        public bool canBulletTime = false;
        public bool canOpenDoor = false;
        
        [Header("BulletTime Setting")]
        [Range(.1f, 1)] public float bulletTimeModify = .5f;
        [Range(1,10)] public float coolDown = 5f;
        [Range(.5f, 3)] public float bulletTimeLength = 1.5f;
        public float currentCDTime;
        public bool isBulletTime = false;

        [Header("Camera Setting")] 
        [Range(1,5)] public float cameraDis = 3f;

        [Header("Bullet Time Canvas Setting")] 
        public Sprite bulletTimeIcon;
        public string bulletTimeName;
        [TextArea(3, 3)] public string bulletTimeDescription;
        
        [Header("Key Setting")]
        public Sprite keyIcon;
        public string keyName;
        [TextArea(3, 3)] public string keyDescription;

        [Header("Canvas On Object SetUp")] 
        public GameObject canvasOnObject;
        public Text canvasOnObjectText;

        [Header("Canvas Item Display SetUp")] 
        public GameObject canvasItemDisplay;
        public Image canvasItemImage;
        public Text canvasItemName;
        public Text canvasItemDescription;
        public GameObject keyCanvasImage;
        public GameObject bulletTimeCanvasImage;
        public Image bulletTimeCDImage;

        private void Update()
        {
            if(isBulletTime)
            {
                BulletTimeCanvasUpdate();
            }
        }

        public void BulletTimeCanvasUpdate()
        {
            currentCDTime += Time.unscaledDeltaTime;
            bulletTimeCDImage.fillAmount = 1 - currentCDTime / (bulletTimeLength + coolDown);
        }
        
        public void CloseItemDisplay()
        {
            canvasItemDisplay.SetActive(false);
            canvasOnObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}