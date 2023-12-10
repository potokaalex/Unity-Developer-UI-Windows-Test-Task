using System.Collections.Generic;
using CodeBase.Lobby.Data;
using CodeBase.Utilities.UI;

namespace CodeBase.Project.Services.WindowsManagerService
{
    public class WindowsManager
    {
        private readonly Dictionary<WindowType, IWindow> _registeredWindows = new();
        private IWindow _currentWindow;

        public void RegisterWindow(WindowType type, IWindow window) => _registeredWindows.Add(type, window);

        public void ToggleCurrentWindow(WindowType type)
        {
            var window = _registeredWindows[type];

            CloseCurrentWindow();

            if (_currentWindow != window)
                OpenWindow(window);
        }

        public void CloseCurrentWindow()
        {
            _currentWindow?.Close();
            _currentWindow = null;
        }

        private void OpenWindow(IWindow window)
        {
            _currentWindow = window;
            _currentWindow.Open();
        }
    }
}