using UnityEngine;
using Zenject;

namespace Gameplay.Zenject
{

    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private GameManager _gameManager;

        public override void InstallBindings()
        {
            Container.Bind<GameManager>()
                .FromInstance(_gameManager)
                .AsSingle();
        }
    }

}