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
        [Header("Scroll Elements")]
        [SerializeField] private GameObject scrollPrefab;
        [SerializeField] private Text scrollText;
        [SerializeField] private Text continueText;
        [SerializeField] private Text tryAgainText;
        [SerializeField, TextArea] private string caughtText;
        [SerializeField, TextArea] private string startText;
        
        [Header("Sound Effects")]
        [SerializeField] private AudioSource caughtSFX;
        
        [Header("Player Character")]
        [SerializeField] private CharacterMovement player;

        private static bool isRestart = false; 
        
        
        // Start is called before the first frame update
        void Start()
        {
            SightCone.Caught += Caught;

            if(!isRestart)
            {
               ShowScroll(startText);
               tryAgainText.enabled = false;
            }

            isRestart = true;
            Time.timeScale = 1;

        }

        private void ShowScroll(string _text)
        {
            if(scrollPrefab != null)
                scrollPrefab.SetActive(true);
            scrollText.text = _text;
            Time.timeScale = 0;
            if(player != null)
                player.enabled = false;
        }

        public void Play()
        {
            player.enabled = true;
            Time.timeScale = 1;
            scrollPrefab.SetActive(false);

        }

        /// <summary>
        /// Gets called when caught by the watchers sight cones.
        /// </summary>
        public void Caught()
        {
            if(caughtSFX != null)
            {
                // Play the caught sfx
                caughtSFX.Play();
            }

            ShowScroll(caughtText);
            if(continueText != null && tryAgainText != null)
            {
                continueText.enabled = false;
                tryAgainText.enabled = true;
            }
                
                
        }

    }
}