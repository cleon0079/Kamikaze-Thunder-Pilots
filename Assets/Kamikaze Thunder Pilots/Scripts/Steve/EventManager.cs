using Game.Cleon;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Steveo
{
    
    public class EventManager : MonoBehaviour
    {
        [SerializeField] private GameObject scrollPrefab;
        [SerializeField] private Text scrollText;
        [SerializeField] private AudioSource caughtSFX;
        [SerializeField, TextArea] private string caughtText;
        [SerializeField] private CharacterMovement player;
        
        private void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            SightCone.Caught += Caught;
            if(scrollPrefab != null)
                scrollPrefab.SetActive(false);
           
            Time.timeScale = 1;
        
        }

        public void Caught()
        {
            if(caughtSFX != null)
            {
                caughtSFX.Play();
            }

            Time.timeScale = 0;
            if(scrollPrefab != null)
            {
                scrollPrefab.SetActive(true);
                scrollText.text = caughtText;
                player.enabled = false;
            }
            
        }
        
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}