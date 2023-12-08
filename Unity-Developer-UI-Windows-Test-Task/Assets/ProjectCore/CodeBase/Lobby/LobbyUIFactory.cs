using ProjectCore.CodeBase.Lobby.Infrastructure;
using ProjectCore.CodeBase.Lobby.Main;
using ProjectCore.CodeBase.Lobby.Settings;
using Zenject;

namespace ProjectCore.CodeBase.Lobby
{
    public class LobbyUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyMainAdapter _mainAdapter;
        private readonly LobbySettingsUIFactory _settingsUIFactory;
        private readonly LobbyStaticDataProvider _staticDataProvider;

        public LobbyUIFactory(IInstantiator instantiator, LobbyMainAdapter mainAdapter,
            LobbySettingsUIFactory settingsUIFactory, LobbyStaticDataProvider staticDataProvider)
        {
            _instantiator = instantiator;
            _mainAdapter = mainAdapter;
            _settingsUIFactory = settingsUIFactory;
            _staticDataProvider = staticDataProvider;
        }

        public void Create()
        {
            var mainView = CreateMainView();
            var settingsView = _settingsUIFactory.CreateView(mainView.GetViewsRoot());
            
            _mainAdapter.Initialize(settingsView);
        }

        private LobbyMainView CreateMainView()
        {
            var prefab = _staticDataProvider.GetConfig().MainViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<LobbyMainView>(prefab);

            return item;
        }
    }
}