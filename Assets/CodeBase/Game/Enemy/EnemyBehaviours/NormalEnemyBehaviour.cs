using System.Collections.Generic;
using CodeBase.Game;

namespace SamuraCat.Game.Enemy
{
	public class NormalEnemyBehaviour : IEnemyBehaviour
    {
        private List<Cat> _catsList;
        public List<Cat> CatsList
        {
            get { return _catsList; }
            set { _catsList = value; }
        }

        public void UpdateCatsList(List<Cat> newCatsList)
        {
            CatsList = newCatsList;
        }

        public void ChooseCat()
        {
            throw new System.NotImplementedException();
        }
    }
}