using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Game.Steveo
{
    /// <summary>
    /// Handles all Menu and Audio functions
    /// </summary>
    public class Menu : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] private AudioMixer audioMixer;
    
        [Header("Volume Sliders")]
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;

    
        // Start is called before the first frame update
        void Start()
        {
            LoadPlayerPrefs();
        }
    
    
        /// <summary>
        /// Loads all the saved values for settings from playerprefs.
        /// </summary>
        public void LoadPlayerPrefs()
        {
            if(PlayerPrefs.HasKey("MasterVolume"))
            {
                float volume = PlayerPrefs.GetFloat("MasterVolume");
                masterVolumeSlider.value = volume;
                VolumeSlider(volume);
            }

            if(PlayerPrefs.HasKey("SFXVolume"))
            {
                float sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
                sfxVolumeSlider.value = sfxVolume;
                SFXSlider(sfxVolume);
            }
        }
    
    #region Volume Sliders
        /// <summary>
        /// Function for the Master Volume slider. Saves value to PlayerPrefs.
        /// </summary>
        /// <param name="_volume">Float passed in from the slider</param>
        public void VolumeSlider(float _volume)
        {
            PlayerPrefs.SetFloat("MasterVolume", _volume);
            _volume = VolumeRemap(_volume);
            audioMixer.SetFloat("masterVolume", _volume);
        }

        /// <summary>
        /// Function for the SFX Volume slider. Saves value to PlayerPrefs.
        /// </summary>
        /// <param name="_volume">Float passed in from the slider</param>
        public void SFXSlider(float _volume)
        {
            PlayerPrefs.SetFloat("SFXVolume", _volume);
            _volume = VolumeRemap(_volume);
            audioMixer.SetFloat("sfxVolume", _volume);
        }

        /// <summary>
        /// Remaps the passed in float from the slider(value 0-1) and outputs to audio scale
        /// </summary>
        /// <param name="value">Passed in slider value</param>
        /// <returns>Remapped float value to pass into the audio mixer</returns>
        public float VolumeRemap(float value)
        {
            return -40 + (value - 0) * (20 - -40) / (1 - 0);
        }
    #endregion


        /// <summary>
        /// Loads the scene of the passed in name
        /// </summary>
        /// <param name="_sceneName">Name of the scene to load</param>
        public void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        /// <summary>
        /// Quits from both the Play Mode in the Unity Editor and the Built Application.
        /// </summary>
        public void ExitGame()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
    Application.Quit();
        #endif
        }
    
    }
}