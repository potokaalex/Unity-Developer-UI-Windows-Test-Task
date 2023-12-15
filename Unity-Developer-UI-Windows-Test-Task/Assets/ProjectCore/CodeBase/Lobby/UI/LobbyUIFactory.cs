using CodeBase.Lobby.Data;
using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Settings;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby.UI
{
    public class LobbyUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyConfigProvider _configProvider;
        private readonly WindowsManager _windowsManager;
        private readonly LobbyController _controller;
        private readonly SettingsController _settingsController;
        private readonly DailyBonusUIFactory _dailyBonusUIFactory;
        private LobbyConfig _config;

        public LobbyUIFactory(IInstantiator instantiator, LobbyConfigProvider configProvider,
            WindowsManager windowsManager, LobbyController controller, SettingsController settingsController,
            DailyBonusUIFactory dailyBonusUIFactory)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _windowsManager = windowsManager;
            _controller = controller;
            _settingsController = settingsController;
            _dailyBonusUIFactory = dailyBonusUIFactory;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public void Create()
        {
            var viewsRoot = CreateRootCanvas().transform;
            var lobbyView = CreateView(viewsRoot, _config.ViewPrefab);

            _controller.Initialize(lobbyView);

            CreateSettings(viewsRoot);
            CreateDailyBonus(viewsRoot);
        }

        private Transform CreateRootCanvas()
        {
            var prefab = _config.CanvasPrefab;
            var instance = _instantiator.InstantiatePrefab(prefab);
            return instance.transform;
        }

        private T CreateView<T>(Transform root, T prefab) where T : MonoBehaviour
        {
            var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab);
            instance.transform.SetParent(root, false);
            return instance;
        }

        private void CreateSettings(Transform viewsRoot)
        {
            var settingsView = CreateView(viewsRoot, _config.Settings.ViewPrefab);
            _windowsManager.RegisterWindow(WindowType.Settings, settingsView);
            _settingsController.Initialize(settingsView);
        }

        private void CreateDailyBonus(Transform viewsRoot)
        {
            _dailyBonusUIFactory.Initialize(_config.DailyBonus);
            _dailyBonusUIFactory.Create(viewsRoot);
        }
    }
}