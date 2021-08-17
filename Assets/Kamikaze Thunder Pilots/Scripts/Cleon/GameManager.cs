using UnityEngine;
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
        public bool isBulletTime = false;

        [Header("Camera Setting")] 
        [Range(1,5)] public float cameraDis = 3f;

        [Header("Item Setting")] 
        public Image bulletTimeIcon;
        [TextArea(3, 3)] public string bulletTimeDescription;
        public Image keyIcon;
        [TextArea(3, 3)] public string keyDescription;
    }
}