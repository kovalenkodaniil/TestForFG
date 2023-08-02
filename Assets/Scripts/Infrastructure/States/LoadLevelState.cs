using Infrastructure.Services;
using Logic.Player;
using Logic.UI;
using Logic.Zone;
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
        private AssetProviderService _assetProvider;

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
            _assetProvider = _services.GetService<AssetProviderService>();

            CreatePlayer();
            InitializeZone();

            EnterGameLoop();
        }

        private void CreatePlayer()
        {
            GameObject spawnPosition = GameObject.FindGameObjectWithTag(SpawnPoint);

            GameObject player = _assetProvider.Instantiate(AssetPath.PlayerPath, spawnPosition.transform.position);

            if (player.TryGetComponent<PlayerMove>(out PlayerMove playerMove))
                playerMove.Init(_services.GetService<InputService>());

            if (player.TryGetComponent<PlayerBackpack>(out PlayerBackpack backpack))
                backpack.Init();
        }

        private void InitializeZone()
        {
            DigZone _digZone = GameObject.FindObjectOfType<DigZone>();

            _digZone.Init();

            DropZone _dropZone = GameObject.FindObjectOfType<DropZone>();

            _dropZone.Init();

            CreateUI(_digZone, _dropZone);
        }

        private void CreateUI(DigZone digZone, DropZone dropZone)
        {
            GameObject UI = _assetProvider.Instantiate(AssetPath.UIPath);

            if (UI.TryGetComponent<UIActor>(out UIActor actor))
                actor.Init(digZone, dropZone);
        }
    }
}
