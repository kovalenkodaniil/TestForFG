using DG.Tweening;
using Infrastructure.Services;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, AllServices services) 
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            RegisterServices();
            EnterLoadLevel();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState>();
        }

        private void RegisterServices()
        {
            _services.Register<InputService>(new InputService());

            _services.Register<AssetProviderService>(new AssetProviderService());

            _services.Register<GameFactory>(new GameFactory(
                _services.GetService<InputService>(), 
                _services.GetService<AssetProviderService>()));

            DOTween.Init();
        }
    }
}
