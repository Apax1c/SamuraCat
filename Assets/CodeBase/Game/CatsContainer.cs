using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cat;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<CatData> _catsList;
        private const float DistanceBetweenCats = 0.74f;

        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.GetId()).ToList();

            for (int i = 0; i < _catsList.Count; i++)
            {
                CatData catData = _catsList[i];
                float xPosition = -DistanceBetweenCats * (_catsList.Count - 1) / 2 + DistanceBetweenCats * i;
                catData.transform.localPosition = new Vector3(xPosition, 0, 0);
            }
        }

        public void RemoveCat(CatData catDataToRemove)
        {
            _catsList.Remove(catDataToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<CatData> cats)
        {
            _catsList = cats;
            SortCats();
        }
    }
}