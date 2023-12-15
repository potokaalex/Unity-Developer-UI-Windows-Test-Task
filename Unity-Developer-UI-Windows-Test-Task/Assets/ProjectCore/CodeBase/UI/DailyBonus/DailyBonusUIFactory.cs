using CodeBase.Project.Services.WindowsManagerService;
using CodeBase.UI.DailyBonus.View.CountItem;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.DailyBonus
{
    public class DailyBonusUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly WindowsManager _windowsManager;
        private readonly DailyBonusController _controller;
        private DailyBonusConfig _config;

        public DailyBonusUIFactory(IInstantiator instantiator, WindowsManager windowsManager,
            DailyBonusController controller)
        {
            _instantiator = instantiator;
            _windowsManager = windowsManager;
            _controller = controller;
        }

        public void Initialize(DailyBonusConfig config) => _config = config;

        public void Create(Transform viewsRoot)
        {
            var congratsView = CreateView(viewsRoot, _config.DailyBonusCongratsViewPrefab);
            var overviewView = CreateView(viewsRoot, _config.DailyBonusOverviewViewPrefab);

            _windowsManager.RegisterWindow(WindowType.DailyBonusCongrats, congratsView);
            _windowsManager.RegisterWindow(WindowType.DailyBonusOverview, overviewView);

            _controller.Initialize(_config, congratsView, overviewView);
        }

        private T CreateView<T>(Transform root, T prefab) where T : MonoBehaviour
        {
            var instance = _instantiator.InstantiatePrefabForComponent<T>(prefab);
            instance.transform.SetParent(root, false);
            return instance;
        }

        public void CreateCountItems(Transform root)
        {
            foreach (var preset in _config.CountItemsPresets)
                CreateCountItem(root, preset);
        }

        private void CreateCountItem(Transform root, DailyBonusCountItemData preset)
        {
            var prefab = _config.DailyBonusCountItemViewPrefab;
            var item = _instantiator.InstantiatePrefabForComponent<DailyBonusCountItemView>(prefab);

            item.transform.SetParent(root, false);
            item.Initialize(preset);
        }
    }
}