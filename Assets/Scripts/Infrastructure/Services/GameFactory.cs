using Logic.Player;
using Logic.UI;
using Logic.Zone;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameFactory : IService
    {
        private const string SpawnPoint = "SpawnPoint";

        private readonly InputService _inputsServices;
        private AssetProviderService _assetProvider;

        public GameFactory(InputService input, AssetProviderService assetProvider)
        {
            _assetProvider = assetProvider;
            _inputsServices = input;
        }

        public void CreateGameWorld()
        {
            CreatePlayer();
            InitializeZone();
        }

        private void CreatePlayer()
        {
            GameObject spawnPosition = GameObject.FindGameObjectWithTag(SpawnPoint);

            GameObject player = _assetProvider.Instantiate(AssetPath.PlayerPath, spawnPosition.transform.position);

            PlayerMove move = player.GetComponentInChildren<PlayerMove>();

            if (move != null)
                move.Init(_inputsServices);

            PlayerBackpack backpack = player.GetComponentInChildren<PlayerBackpack>();

            if (backpack != null)
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

            if (UI.TryGetComponent<ButtonController>(out ButtonController actor))
                actor.Init(digZone.Delay, dropZone.Delay);

            DropCounter counter = UI.GetComponentInChildren<DropCounter>();

            if (counter != null)
                counter.Init(dropZone);
        }
    }
}
