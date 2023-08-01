using Infrastructure.States;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        Game _game;

        private void Awake()
        {
            _game = new();
            _game.StateMachine.Enter<BootstrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
