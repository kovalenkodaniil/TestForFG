using Infrastructure.Services;
using System.IO;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string MainScene = "Main";
        private const string SpawnPoint = "SpawnPoint";

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

        public void Exit()
        {
        }

        private void EnterGameLoop()
        {
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            AssetProviderService assetProvider = _services.GetService<AssetProviderService>();

            CreatePlayer(assetProvider);

            EnterGameLoop();
        }

        private void CreatePlayer(AssetProviderService assetProvider)
        {
            GameObject spawnPosition = GameObject.FindGameObjectWithTag(SpawnPoint);

            GameObject player = assetProvider.Instantiate(AssetPath.PlayerPath, spawnPosition.transform.position);

            if (player.TryGetComponent<PlayerMove>(out PlayerMove playerMove))
                playerMove.Init(_services.GetService<InputService>());
        }
    }
}
