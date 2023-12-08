using CodeBase.Project.Services.StateMachineService;
using Zenject;

namespace CodeBase.Project
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}