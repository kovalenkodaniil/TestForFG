using Scripts.Infrastructure.States;
using System;
using System.Collections.Generic;

namespace Scripts.Infrastructure
{
   
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMachine(SceneLoader sceneLoader) 
        {
            _states = new Dictionary<Type, IState>() 
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();

            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}
