using CodeBase.Common.Services.WindowsManagerService;
using CodeBase.Lobby.Data;
using CodeBase.Lobby.UI;
using CodeBase.UI.DailyBonus;
using CodeBase.UI.Levels;
using CodeBase.UI.Settings;
using CodeBase.UI.Shop;
using UnityEngine;
using Zenject;

namespace CodeBase.Lobby
{
    public class LobbyInstaller : MonoInstaller
    {
        [SerializeField] private LobbyConfig _lobbyConfig;
        [SerializeField] private ShopConfig _shopConfig;

        public override void InstallBindings()
        {
            BindFactories();
            BindControllers();
            BindModel();

            Container.Bind<LobbyConfigProvider>().AsSingle().WithArguments(_lobbyConfig, _shopConfig);
            Container.Bind<WindowsManager>().AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesAndSelfTo<LobbyUIFactory>().AsSingle();
            Container.Bind<DailyBonusUIFactory>().AsSingle();
            Container.Bind<ShopUIFactory>().AsSingle();
        }

        private void BindControllers()
        {
            Container.BindInterfacesAndSelfTo<LobbyController>().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsController>().AsSingle();
            Container.Bind<DailyBonusController>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelsController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShopController>().AsSingle();
        }

        private void BindModel()
        {
            Container.Bind(
                    typeof(LobbyModel),
                    typeof(ISettingsModel),
                    typeof(IDailyBonusModel),
                    typeof(ILevelsModel),
                    typeof(IShopModel))
                .To<LobbyModel>()
                .AsSingle();
        }
    }
}