using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SimpleFPS
{
    public class StartupSceneController : MonoBehaviour
    {
        public TextMeshProUGUI textBox; // Reference to the text box
        public float fadeDuration = 2.0f; // Duration of the fade-in effect
        public string nextSceneName = "GameScene"; // Name of the next scene to load

        private float fadeTimer = 0.0f;
        private Color initialTextColor;

        private void Start()
        {
            // Initialize the text box
            textBox.color = Color.clear;
            initialTextColor = textBox.color;
        }

        private void Update()
        {
            // Gradually fade in the text box
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Clamp01(fadeTimer / fadeDuration);
            textBox.color = Color.Lerp(initialTextColor, Color.white, alpha);

            // Load the next scene when the fade-in effect is complete
            if (fadeTimer >= fadeDuration)
            {
                LoadNextScene();
            }
        }

        private void LoadNextScene()
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
