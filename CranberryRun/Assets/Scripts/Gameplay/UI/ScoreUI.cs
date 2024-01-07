using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _currentScoreText;
    
    [SerializeField]
    private TextMeshProUGUI _highScoreText;

    public void SetNewScore(float score)
    {
        _currentScoreText.text = score.ToString("0");
    }

    public void SetHighScore(float highScore)
    {
        _highScoreText.text = highScore.ToString("0");
    }
}
