using CodeBase.Lobby.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;

        public LobbyMainUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
        }

        public LobbyMainView CreateView()
        {
            var prefab = _staticDataProvider.GetConfig().MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyMainView>(prefab);

            return item;
        }
    }
}