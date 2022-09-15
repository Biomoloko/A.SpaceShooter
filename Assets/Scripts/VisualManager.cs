using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class VisualManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starsQuantityText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject loosePanel;
    public static VisualManager instance;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI resultScoreText;

    public static UnityEvent OnScoreAccrual = new UnityEvent();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public void Drawator(Image image, float currentHealth, float maxHealth)
    {
        image.fillAmount = currentHealth / maxHealth;
    }
    public void StarsQuantity(int starsCount)
    {
        starsQuantityText.text = $"x {starsCount}";
    }
    public void DrawScore(int score)
    {
        scoreText.text = $"Score : {score}";
    }
    public void DrawLoosePanel(int bestScore, int score)
    {
        resultScoreText.text = $"Your Score : {score}";
        bestScoreText.text = $"Best Score : {bestScore}";
        Time.timeScale = 0;
        loosePanel.SetActive(true);
    }

    public void Retryder()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        GameManager.isGaming = true;
    }
}