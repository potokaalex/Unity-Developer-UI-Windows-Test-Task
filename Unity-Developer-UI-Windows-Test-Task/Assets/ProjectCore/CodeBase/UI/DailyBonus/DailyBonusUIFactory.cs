using CodeBase.Lobby.DailyBonus;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.Infrastructure.Providers;
using CodeBase.Project.Services.WindowsManagerService;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyStaticDataProvider _staticDataProvider;
        private readonly WindowsManager _windowsManager;
        private LobbyConfig _config;

        public DailyBonusUIFactory(IInstantiator instantiator, LobbyStaticDataProvider staticDataProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize() => _config = _staticDataProvider.GetConfig();

        public DailyBonusCongratsView CreateCongratsView()
        {
            var prefab = _config.DailyBonusCongratsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCongratsView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }

        public DailyBonusOverviewView CreateOverviewView()
        {
            var prefab = _config.DailyBonusOverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusOverviewView>(prefab);

            item.transform.SetParent(_windowsManager.WindowsRoot, false);

            return item;
        }

        public void CreateCountItemView(Transform root, LobbyDailyBonusCountItemPreset preset)
        {
            var prefab = _config.DailyBonusCountItemViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCountItemView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset.DayNumber, preset.TicketsCount);
        }
    }
}