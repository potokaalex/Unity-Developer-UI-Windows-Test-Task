using UnityEngine;
using Zenject;

namespace ProjectCore.CodeBase.Lobby.Infrastructure
{
    public class LobbyStartup : MonoBehaviour
    {
        private LobbyUIFactory _lobbyUIFactory;

        [Inject]
        public void Construct(LobbyUIFactory lobbyUIFactory) => _lobbyUIFactory = lobbyUIFactory;

        private void Start() => _lobbyUIFactory.Create();
    }
}