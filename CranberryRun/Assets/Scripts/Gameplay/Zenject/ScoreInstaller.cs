using UnityEngine;
using Zenject;

namespace Gameplay.Zenject
{

    public class ScoreInstaller : MonoInstaller
    {
        [SerializeField]
        private ScoreUI _scoreUI;

        [SerializeField]
        private ScoreController _scoreController;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ScoreUI>()
                .FromInstance(_scoreUI)
                .AsSingle();
            
            Container.BindInterfacesAndSelfTo<ScoreController>()
                .FromInstance(_scoreController)
                .AsSingle();
        }
    }

}