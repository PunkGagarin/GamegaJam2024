using Gameplay.Characters.Player;
using Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Gameplay.Zenject
{

    public class PlayerInstaller : MonoInstaller
    {

        [SerializeField]
        private PlayerCharacter _character;
        
        [SerializeField]
        private PlayerCollision _playerCollision;
        
        [SerializeField]
        private PlayerMovement _playerMovement;

        [SerializeField]
        private CameraFollowing _cameraFollowing;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerCharacter>()
                .FromInstance(_character)
                .AsSingle();

            Container.Bind<CameraFollowing>()
                .FromInstance(_cameraFollowing)
                .WithArguments(_character)
                .NonLazy();
            
            Container.Bind<PlayerMovement>()
                .FromInstance(_playerMovement)
                .WithArguments(_character)
                .NonLazy();
            
            Container.Bind<PlayerCollision>()
                .FromInstance(_playerCollision)
                .WithArguments(_playerMovement)
                .NonLazy();
        }
    }

}