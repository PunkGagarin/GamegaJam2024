using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Gameplay.Zenject
{

    public class ObstaclesInstaller : MonoInstaller
    {

        [SerializeField]
        private MovingObstaclesController _movingObstaclesController;


        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MovingObstaclesController>()
                .FromInstance(_movingObstaclesController)
                .AsSingle();
        }

    }

}