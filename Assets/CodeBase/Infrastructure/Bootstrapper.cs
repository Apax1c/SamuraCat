using CodeBase.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Start()
        {
            if (SceneManager.GetActiveScene().name != "Initial")
            {
                SceneManager.LoadScene("Initial");
            }
            
            _gameStateMachine.Initialize();
        }
    }
}