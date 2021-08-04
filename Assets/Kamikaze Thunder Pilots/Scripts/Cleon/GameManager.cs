using UnityEngine;

namespace Game.Cleon
{
    public class GameManager : MonoBehaviour
    {
        [Header("CharacterSetting")] 
        public float moveSpeed = 5f;
        [Range(.1f, 1)] public float bulletTimeModify = .5f;
        public bool canMoveHori = false;
        public bool canBulletTime = false;
        
        [Header("CameraSetting")]
        [Range(1,5)] public float cameraDis = 3f;
    }
}