    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class GameOverManager : MonoBehaviour
    {
        public static GameOverManager Instance;

        public GameObject gameOverPanel;
        public Text finalScoreText;

        void Awake()
        {
            Instance = this;
        }

        public void ShowGameOver(int finalScore)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = "?i?m: " + finalScore;
            Time.timeScale = 0f; // stop
        }

        public void RestartGame()
        {
            Time.timeScale = 1f; // Khôi ph?c time
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }