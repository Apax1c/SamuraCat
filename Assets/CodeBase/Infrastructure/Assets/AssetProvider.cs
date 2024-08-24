using UnityEngine;

namespace CodeBase.Infrastructure.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject LoadFromResources(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);

            return gameObject;
        }
    }
}