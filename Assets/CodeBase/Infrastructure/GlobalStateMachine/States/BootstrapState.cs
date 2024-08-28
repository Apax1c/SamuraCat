using CodeBase.StaticData;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.GlobalStateMachine.States
{
    public class BootstrapState : IState
    {
        private ZenjectSceneLoader _sceneLoader;

        public void Enter()
        {
            SceneManager.LoadScene((int)Scenes.MainMenu);
        }

        public void Exit()
        {
            
        }
    }
}