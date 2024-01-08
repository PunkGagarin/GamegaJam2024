using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private const string LastCompletedLevel = "LastLevelCompleted";

    [SerializeField]
    private TextMeshProUGUI _currentScoreText;

    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    [SerializeField]
    private TextMeshProUGUI _maxLeveltext;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(LastCompletedLevel))
        {
            var lastLevelIndex = PlayerPrefs.GetInt(LastCompletedLevel);
            SetMaxLevelText(lastLevelIndex + 1);
        }
    }

    public void SetNewScore(float score)
    {
        _currentScoreText.text = score.ToString("0");
    }

    public void SetHighScore(float highScore)
    {
        _highScoreText.text = highScore.ToString("0");
    }

    private void SetMaxLevelText(int maxLevelText)
    {
        _maxLeveltext.text = maxLevelText.ToString();
    }
}