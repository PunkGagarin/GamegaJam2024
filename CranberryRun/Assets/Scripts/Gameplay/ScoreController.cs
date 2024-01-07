using System;
using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay
{

    public class ScoreController : MonoBehaviour
    {
        private const string HIGHSCORE = "highScore";

        private float _currentScore;

        [Inject] private PlayerCharacter _playerCharacter;
        [Inject] private ScoreUI _scoreUI;
        [Inject] private GameManager _gameManager;

        private void Awake()
        {
            _gameManager.OnGameEnded += SaveCurrentScore;
            LoadHighScore();
        }

        private void OnDestroy()
        {
            _gameManager.OnGameEnded -= SaveCurrentScore;
        }
        
        private void LoadHighScore()
        {
            if (PlayerPrefs.HasKey(HIGHSCORE))
            {
                var oldScore = PlayerPrefs.GetFloat(HIGHSCORE);
                _scoreUI.SetHighScore(oldScore);
            }
        }

        private void SaveCurrentScore()
        {
            if (_currentScore <= 0) return;
            
            float newScore = _currentScore;

            //todo: выводить 1 последний счёт или несколько?
            if (PlayerPrefs.HasKey(HIGHSCORE))
            {
                var oldScore = PlayerPrefs.GetFloat(HIGHSCORE);
                if (oldScore > newScore)
                    return;
            }
            
            PlayerPrefs.SetFloat(HIGHSCORE, newScore);
            SetHighScoreToUi(newScore);
        }

        private void SetHighScoreToUi(float newScore)
        {
            _scoreUI.SetHighScore(newScore);
        }

        private void Update()
        {
            if (!_gameManager.IsGameStopped)
            {
                _currentScore = CalculateCurrentScore();

                _scoreUI.SetNewScore(_currentScore);
            }
        }

        private float CalculateCurrentScore()
        {
            return _playerCharacter.transform.position.z / 10;
        }

    }

}