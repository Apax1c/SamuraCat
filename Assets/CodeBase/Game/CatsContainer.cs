using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cat;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<Cat.Cat> _catsList;
        private List<GameObject> _platformsList;
        
        private const float DistanceBetweenCats = 0.74f;

        public void Construct(List<GameObject> platforms)
        {
            _platformsList = platforms;
        }
        
        private void SortCats()
        {
            ReorderCatsList();

            for (int i = 0; i < _platformsList.Count; i++)
            {
                Vector3 newPosition = GetPositionForCatAndPlatform(i);
                
                Platform platform = SetPlatformOnNewPosition(i, newPosition);

                if (i >= 0 && i < _catsList.Count)
                {
                    Cat.Cat cat = SetCatOnNewPosition(i, newPosition);

                    platform.SetNumber(cat.ID);
                }
                else
                {
                    platform.ClearNumber();
                }
            }
        }

        private void ReorderCatsList() => 
            _catsList = _catsList.OrderBy(b => b.ID).ToList();

        public void RemoveCat(Cat.Cat catToRemove)
        {
            _catsList.Remove(catToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<Cat.Cat> cats)
        {
            _catsList = cats;
            SortCats();
        }

        private static Vector3 GetPositionForCatAndPlatform(int i)
        {
            float xPosition = -3.33f + DistanceBetweenCats * i;
            return new Vector3(xPosition, 0, 0);
        }

        private Platform SetPlatformOnNewPosition(int i, Vector3 newPosition)
        {
            GameObject platformGameObject = _platformsList[i];
            platformGameObject.transform.localPosition = newPosition;
            
            return platformGameObject.GetComponent<Platform>();
        }

        private Cat.Cat SetCatOnNewPosition(int i, Vector3 newPosition)
        {
            Cat.Cat cat = _catsList[i];
            cat.transform.localPosition = newPosition;
            return cat;
        }
    }
}