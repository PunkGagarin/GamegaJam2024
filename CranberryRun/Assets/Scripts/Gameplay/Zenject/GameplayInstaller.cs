using Gameplay.EndLevel;
using UnityEngine;
using Zenject;

namespace Gameplay.Zenject
{

    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private GameManager _gameManager;

        [SerializeField]
        private EndTrigger _endTrigger;

        [SerializeField]
        private IvanFollower _ivanFollower;

        [SerializeField]
        private WinLeveUI _winLeveUI;
        
        [SerializeField]
        private LoseLevelUI _loseLevelUI;

        public override void InstallBindings()
        {
            Container.Bind<GameManager>()
                .FromInstance(_gameManager)
                .AsSingle();

            Container.Bind<EndTrigger>()
                .FromInstance(_endTrigger)
                .AsSingle();

            Container.Bind<IvanFollower>()
                .FromInstance(_ivanFollower)
                .AsSingle();

            Container.Bind<WinLeveUI>()
                .FromInstance(_winLeveUI)
                .AsSingle();
            
            Container.Bind<LoseLevelUI>()
                .FromInstance(_loseLevelUI)
                .AsSingle();

            Container.BindInterfacesAndSelfTo<EndLevelManager>()
                .AsSingle();
        }
    }

}