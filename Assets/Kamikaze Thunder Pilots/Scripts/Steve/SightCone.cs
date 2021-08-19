using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Steveo
{
    /// <summary>
    /// Handles all of the Sight Cone interactions
    /// </summary>
    public class SightCone : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Color originalColor;
        private bool isInSight = false;
        private float timer;
        public bool isCaught = false;
        
        public delegate void GotCaught();
        public static event GotCaught Caught;
    
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.material.color;
            isCaught = false;

        }

        // Update is called once per frame
        void Update()
        {
            if(isInSight && Time.time >= timer + 0.25f)
            {
                spriteRenderer.material.color = Color.red;
                    
                if(Time.time >= timer + 0.3f)
                {
                    if(!isCaught && Caught != null)
                    {
                        isCaught = true;
                        Caught();
                        Debug.Log("Caught");

                    }
                    //todo maybe an event?? then subscribe with the game manager
                    // Play caught sfx
                    // Gameover message
                    // Reload level
                    
                    
                }
                
            }
        }

        
        
    
        private void OnTriggerEnter2D(Collider2D _collider)
        {
            Debug.Log("trigger");
            if(_collider.gameObject.tag == "Player")
            {
                
                spriteRenderer.material.color = Color.yellow;
                isInSight = true;
                timer = Time.time;
            }
        }

    
        private void OnTriggerExit2D(Collider2D _collider)
        {
            Debug.Log("triggerExit");
            if(_collider.gameObject.tag == "Player")
            {
                spriteRenderer.material.color = originalColor;
                //spriteRenderer.color = originalColor;
                isInSight = false;
            }
        }
    }
}