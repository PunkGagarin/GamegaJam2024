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
            
           _sceneLevelManager.ChangeToNextLevel();
        }

        private void OnMenuButtonPressedHandle()
        {
            _sceneLevelManager.ChangeToMainMenu();
        }
    }

}