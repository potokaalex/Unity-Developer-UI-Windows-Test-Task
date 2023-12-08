using CodeBase.Lobby.Infrastructure.Providers;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly LobbyAudioManagerProvider _audioManagerProvider;

        public LobbyFactory(IInstantiator instantiator,LobbyStaticDataProvider staticDataProvider,LobbyAudioManagerProvider audioManagerProvider)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _audioManagerProvider = audioManagerProvider;
        }
        
        public LobbyAudioManager CreateAudioManager()
        {
            var prefab = _staticDataProvider.GetConfig().AudioManagerPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyAudioManager>(prefab);

            _audioManagerProvider.Initialize(item);
            
            return item;
        }
    }
}