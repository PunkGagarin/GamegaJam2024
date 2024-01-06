using System;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Gameplay.EndLevel
{

    public class EndLevelManager : IInitializable, IDisposable, UiController
    {

        [Inject] private WinLeveUI _winLeveUI;
        [Inject] private SceneLevelManager _sceneLevelManager;

        public void Initialize()
        {
            _winLeveUI.NextLevelButton.onClick.AddListener(OnNextLevelPressedHandle);
            _winLeveUI.MenuButton.onClick.AddListener(OnMenuButtonPressedHandle);
        }

        public void Dispose()
        {
            _winLeveUI.NextLevelButton.onClick.RemoveListener(OnNextLevelPressedHandle);
            _winLeveUI.MenuButton.onClick.RemoveListener(OnMenuButtonPressedHandle);
        }

        public void OpenUI()
        {
            _winLeveUI.TurnOn();
        }

        private void OnNextLevelPressedHandle()
        {
            Debug.Log("On next level pressed handle");
           _sceneLevelManager.RestartCurrentLevel();
        }

        private void OnMenuButtonPressedHandle()
        {
            Debug.Log("On OnMenuButtonPressedHandle pressed handle");
            _sceneLevelManager.ChangeToMainMenu();
        }
    }

}