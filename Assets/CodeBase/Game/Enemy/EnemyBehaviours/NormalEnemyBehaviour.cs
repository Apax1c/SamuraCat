using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cat;

namespace SamuraCat.Game.Enemy
{
	public class NormalEnemyBehaviour : IEnemyBehaviour
    {
        private List<CatData> _catsList;
        public List<CatData> CatsList
        {
            get { return _catsList; }
            set { _catsList = value; }
        }

        public void UpdateCatsList(List<CatData> newCatsList)
        {
            CatsList = newCatsList;
        }

        public void ChooseCat()
        {
            throw new System.NotImplementedException();
        }
    }
}