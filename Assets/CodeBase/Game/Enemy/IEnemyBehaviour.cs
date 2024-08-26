using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cat;

namespace SamuraCat.Game.Enemy
{
	public interface IEnemyBehaviour
	{
		List<CatData> CatsList { get; set; }

		void UpdateCatsList(List<CatData> newCatsList);
		void ChooseCat();
	}
}