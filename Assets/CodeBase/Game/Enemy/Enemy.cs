using UnityEngine;

namespace SamuraCat.Game.Enemy
{
	public class Enemy : MonoBehaviour
	{
		private IEnemyBehaviour _behaviour;
		private EnemyDifficulty _enemyDifficulty;

        private void Start()
        {
            SetBehaviour();
        }

        private void SetBehaviour()
        {
            switch (_enemyDifficulty)
            {
                case EnemyDifficulty.Easy:
                    _behaviour = new EasyEnemyBehaviour();
                    break;
                case EnemyDifficulty.Normal:
                    _behaviour = new NormalEnemyBehaviour();
                    break;
                case EnemyDifficulty.Hard:
                    _behaviour = new HardEnemyBehaviour();
                    break;
                default:
                    _enemyDifficulty = EnemyDifficulty.Normal;
                    _behaviour = new NormalEnemyBehaviour();
                    break;
            }
        }

        private void ChooseCat()
        {
            if (_behaviour != null)
            {
                _behaviour.ChooseCat();
            }
        }
    }

	enum EnemyDifficulty
	{
		Easy,
		Normal,
		Hard
	}
}