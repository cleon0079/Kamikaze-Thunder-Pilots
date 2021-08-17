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
    
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
        }

        // Update is called once per frame
        void Update()
        {
            if(isInSight)
            {
                if(Time.time >= timer + 0.5f)
                {
                    spriteRenderer.color = Color.red;
                    if(Time.time >= timer + 0.5f)
                    {
                        // Gameover message
                        // Reload level
                        Debug.Log("Caught");
                    }
                }
            }
        }
    
        private void OnTriggerEnter2D(Collider2D _collider)
        {
            Debug.Log("trigger");
            if(_collider.gameObject.tag == "Player")
            {
                spriteRenderer.color = Color.yellow;
                isInSight = true;
                timer = Time.time;
            }
        }

    
        private void OnTriggerExit2D(Collider2D _collider)
        {
            Debug.Log("triggerExit");
            if(_collider.gameObject.tag == "Player")
            {
                spriteRenderer.color = originalColor;
                isInSight = false;
            }
        }
    }
}