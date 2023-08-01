namespace Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; }

        public Game()
        {
            StateMachine = new GameStateMachine(new SceneLoader());
        }
    }
}