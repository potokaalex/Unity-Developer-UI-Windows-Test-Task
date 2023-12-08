using CodeBase.Lobby.Infrastructure.States;
using CodeBase.Project.Services.StateMachineService;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.Infrastructure
{
    public class LobbyStartup : MonoBehaviour
    {
        private StateMachine _stateMachine;

        [Inject]
        public void Construct(StateMachine stateMachine) => _stateMachine = stateMachine;

        private void Start() => _stateMachine.SwitchTo<LobbyStartState>();
    }
}