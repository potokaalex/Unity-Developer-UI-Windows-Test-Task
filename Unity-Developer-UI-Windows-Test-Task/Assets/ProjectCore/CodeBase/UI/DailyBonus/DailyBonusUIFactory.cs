using CodeBase.Lobby;
using CodeBase.Lobby.Data;
using CodeBase.Project.Services.WindowsManagerService;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusUIFactory : IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly LobbyConfigProvider _configProvider;
        private readonly WindowsManager _windowsManager;
        private LobbyConfig _config;

        public DailyBonusUIFactory(IInstantiator instantiator, LobbyConfigProvider configProvider,
            WindowsManager windowsManager)
        {
            _instantiator = instantiator;
            _configProvider = configProvider;
            _windowsManager = windowsManager;
        }

        public void Initialize() => _config = _configProvider.GetConfig();

        public DailyBonusCongratsView CreateCongratsView()
        {
            var prefab = _config.DailyBonusCongratsViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCongratsView>(prefab);

            item.transform.SetParent(null, false);

            return item;
        }

        public DailyBonusOverviewView CreateOverviewView()
        {
            var prefab = _config.DailyBonusOverviewViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusOverviewView>(prefab);

            item.transform.SetParent(null, false);

            return item;
        }

        public void CreateCountItemView(Transform root, DailyBonusCountItemPreset preset)
        {
            var prefab = _config.DailyBonusCountItemViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCountItemView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset.DayNumber, preset.TicketsCount);
        }
    }
}