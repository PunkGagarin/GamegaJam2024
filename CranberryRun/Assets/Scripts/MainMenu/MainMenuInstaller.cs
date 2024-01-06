using UnityEngine;
using Zenject;

namespace MainMenu
{

    public class MainMenuInstaller : MonoInstaller
    {

        [SerializeField]
        private MainMenuManager _mainMenuManager;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLevelManager>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<MainMenuManager>()
                .FromInstance(_mainMenuManager)
                .AsSingle();
        }
    }

}