using System.Collections.Generic;
using CodeBase.Game;
using CodeBase.Game.Cat;

namespace SamuraCat.Game.Enemy
{
	public interface IEnemyBehaviour
	{
		List<CatConstructor> CatsList { get; set; }

		void UpdateCatsList(List<CatConstructor> newCatsList);
		void ChooseCat();
	}
}