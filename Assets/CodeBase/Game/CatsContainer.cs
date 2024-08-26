using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cat;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<CatData> _catsList;
        private List<GameObject> _platforms;
        
        private const float DistanceBetweenCats = 0.74f;

        public void Construct(List<GameObject> platforms)
        {
            _platforms = platforms;
        }
        
        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.GetId()).ToList();

            for (int i = 0; i < _catsList.Count; i++)
            {
                CatData catData = _catsList[i];
                float xPosition = -DistanceBetweenCats * (_catsList.Count - 1) / 2 + DistanceBetweenCats * i;
                catData.transform.localPosition = new Vector3(xPosition, 0, 0);

                GameObject platform = _platforms[i];
                platform.transform.localPosition = catData.transform.localPosition;
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