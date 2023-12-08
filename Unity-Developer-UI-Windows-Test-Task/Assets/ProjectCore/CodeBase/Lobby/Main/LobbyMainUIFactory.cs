using CodeBase.Lobby.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Lobby.Main
{
    public class LobbyMainUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyAudioManagerProvider _audioManagerProvider;
        private readonly LobbyMainAdapter _adapter;

        public LobbyMainUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            LobbyAudioManagerProvider audioManagerProvider, LobbyMainAdapter adapter)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _audioManagerProvider = audioManagerProvider;
            _adapter = adapter;
        }

        public LobbyMainView CreateView()
        {
            var audio = _audioManagerProvider.GetManager();
            var prefab = _staticDataProvider.GetConfig().MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyMainView>(prefab);

            item.Initialize(_adapter, audio);

            return item;
        }
    }
}