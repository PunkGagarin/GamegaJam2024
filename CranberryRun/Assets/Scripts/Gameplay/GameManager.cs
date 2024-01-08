﻿using System;
using Gameplay.Characters.Player;
using Gameplay.EndLevel;
using Gameplay.Player;
using UnityEngine;
using Zenject;
using Task = System.Threading.Tasks.Task;

namespace Gameplay
{

    public class GameManager : MonoBehaviour
    {

        public bool IsGameStopped { get; private set; }
        private int _restartTimeMilis;
    
        [Inject] private PlayerCollision _playerCollision;
        [Inject] private PlayerMovement _playerMovement;
        [Inject] private EndTrigger _endTrigger;
        [Inject] private EndLevelManager _endLevelManager;
        [Inject] private SceneLevelManager _sceneLevelManager;
        [Inject] private LoseLevelUI _loseLevelUI;

        [SerializeField]
        private float _restartTime;

        public Action OnGameEnded = delegate {  };

        public void Awake()
        {
            _playerCollision.OnObstacleHit += OnObstacleHit;
            _endTrigger.OnEndTriggerPassed += TryWinLevel;
            _restartTimeMilis = (int)(_restartTime * 1000f);
        }

        public void OnDestroy()
        {
            _playerCollision.OnObstacleHit -= OnObstacleHit;
            _endTrigger.OnEndTriggerPassed -= TryWinLevel;
        }

        private void TryWinLevel()
        {
            if (!CanWin())
            {
                return;
            }

            IsGameStopped = true;
            OnGameEnded.Invoke();
            _sceneLevelManager.SetCurrentSceneAsFinished();
            _playerMovement.StopMovement();
            _endLevelManager.OpenUI();
        }

        private void OnObstacleHit()
        {
            if (IsGameStopped) return;

            IsGameStopped = true;
            OnGameEnded.Invoke();
            _loseLevelUI.TurnOn();
            RestartWithDelay(_restartTimeMilis);
        }

        private async void RestartWithDelay(int delayMilis)
        {
            await Task.Delay(delayMilis);
            Restart();
        }

        private void Restart()
        {
            _sceneLevelManager.RestartCurrentLevel();
        }

        public bool CanWin()
        {
            return !IsGameStopped;
        }

        public void PauseGame()
        {
            Debug.Log("Game was paused");
        }
    }

}