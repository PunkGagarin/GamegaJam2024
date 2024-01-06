using Zenject;

namespace Gameplay.Zenject
{

    public class SystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneLevelManager>()
                .AsSingle();
        }
    }

}