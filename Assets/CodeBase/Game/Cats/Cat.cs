using SamuraCat.Constants;
using UnityEngine;

namespace CodeBase.Game.Cats
{
    public abstract class Cat : MonoBehaviour
    {
        public int ID { get; protected set; }
        public abstract CatType Type { get; protected set; }

        public void Construct(int id)
        {
            ID = id;
        }
    }
}