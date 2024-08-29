using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Game.Cats
{
    public abstract class Cat : MonoBehaviour
    {
        public int ID { get; private set; }
        public abstract CatType Type { get; protected set; }

        private CatsContainer _catsContainer;
        private Player _player;

        public void Construct(int id, CatsContainer catsContainer, Player player)
        {
            ID = id;
            _catsContainer = catsContainer;
            _player = player;
        }

        public void ChooseCat()
        {
            _player.ChooseCat(this);
            _catsContainer.RemoveCat(this);
        }
    }
}