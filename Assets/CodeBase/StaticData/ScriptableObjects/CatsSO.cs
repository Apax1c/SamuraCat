using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.ScriptableObjects
{
	[CreateAssetMenu(fileName = "CatsDataSO", menuName = "Scriptable Objects/CatsDataSO")]
	public class CatsSo : ScriptableObject
	{
		public List<CatsData> Cats;
	}
}