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
        private bool isCaught = false;
        
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
                    }
                }
            }
        }

        
        
    
        private void OnTriggerEnter2D(Collider2D _collider)
        {
            // Handles the player entering the sight cone
            if(_collider.gameObject.tag == "Player")
            {
                spriteRenderer.material.color = Color.yellow;
                isInSight = true;
                timer = Time.time;
            }
        }

    
        private void OnTriggerExit2D(Collider2D _collider)
        {
            // Handles the player exiting the sight cone
            if(_collider.gameObject.tag == "Player")
            {
                spriteRenderer.material.color = originalColor;
                isInSight = false;
            }
        }
    }
}