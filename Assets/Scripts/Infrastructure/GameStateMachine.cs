using Infrastructure.Services;
using Infrastructure.States;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
   
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _currentState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services) 
        {
            _states = new Dictionary<Type, IState>() 
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState = _states[typeof(TState)];
            _currentState.Enter();
        }
    }
}
