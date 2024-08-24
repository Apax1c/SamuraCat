using System.Collections.Generic;
using CodeBase.Game;

namespace SamuraCat.Game.Enemy
{
	public interface IEnemyBehaviour
	{
		List<Cat> CatsList { get; set; }

		void UpdateCatsList(List<Cat> newCatsList);
		void ChooseCat();
	}
}