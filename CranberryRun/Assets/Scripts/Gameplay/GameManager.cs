using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Task = System.Threading.Tasks.Task;

namespace Gameplay
{

    public class GameManager : MonoBehaviour
    {

        private bool _isGameOver;

        [Inject] private PlayerCollision _playerCollision;


        public void Awake()
        {
            _playerCollision.OnObstacleHit += OnObstacleHit;
        }

        public void OnDestroy()
        {
            _playerCollision.OnObstacleHit -= OnObstacleHit;
        }

        private void OnObstacleHit()
        {
            if (_isGameOver) return;

            _isGameOver = true;
            RestartWithDelay(4000);
        }

        private async void RestartWithDelay(int delayMilis)
        {
            await Task.Delay(delayMilis);
            Restart();
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void PauseGame()
        {
            Debug.Log("Game was paused");
        }
    }

}