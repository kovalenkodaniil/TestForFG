using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Services
{
    public class AssetProviderService : IService
    {
        public GameObject Instantiate(string assetPath)
        {
            GameObject prefab = LoadAsset(assetPath);

            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string assetPath, Vector3 position)
        {
            GameObject prefab = LoadAsset(assetPath);

            return Object.Instantiate(prefab, position, Quaternion.identity);
        }

        private GameObject LoadAsset(string assetPath) =>
            Resources.Load<GameObject>(assetPath);
    }
}
