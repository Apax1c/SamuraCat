using UnityEngine;

namespace CodeBase.Infrastructure.Assets
{
    public interface IAssetProvider
    {
        GameObject LoadFromResources(string path);
        T LoadFromResources<T>(string path);
    }
}