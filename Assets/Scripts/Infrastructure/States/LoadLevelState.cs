using Infrastructure.Services;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public LoadLevelState(GameStateMachine stateMachine, AllServices services, SceneLoader sceneLoader) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
        }

        public void Enter()
        {
            _sceneLoader.Load(MainScene, InitGameWorld);
        }

        private void EnterGameLoop()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            GameFactory factory = _services.GetService<GameFactory>();

            factory.CreateGameWorld();

            EnterGameLoop();
        }
    }
}
