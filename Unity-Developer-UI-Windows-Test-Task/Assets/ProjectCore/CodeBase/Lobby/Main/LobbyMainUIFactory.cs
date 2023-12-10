using CodeBase.Lobby.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyMainAdapter _adapter;

        public LobbyMainUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyMainAdapter adapter)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _adapter = adapter;
        }

        public LobbyMainView CreateView()
        {
            var prefab = _staticDataProvider.GetConfig().MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyMainView>(prefab);

            return item;
        }
    }
}