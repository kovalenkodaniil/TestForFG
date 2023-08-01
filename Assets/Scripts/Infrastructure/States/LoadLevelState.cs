namespace Scripts.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string MainScene = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader) 
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(MainScene, EnterGameLoop);
        }

        public void Exit()
        {
        }

        private void EnterGameLoop()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}
