using System.Collections.Generic;
using _Game.Data;
using _Game.UI.Windows;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.GameServices
{
    public class WindowsChangeService : IService
    {
        private readonly GameData _gameData;

        public WindowsChangeService()
        {
            _gameData = Services.Instance.Single<GameData>();
        }

        private Stack<BaseWindow> _windowsStack => _gameData.WindowsStack;
        
        public T Show<T>(T window) where T : BaseWindow
        {
            _windowsStack.Push(window);

            if (_windowsStack.Count == 1)
                window.Show();

            return window;
        }

        public void Hide(BaseWindow window)
        {
            _windowsStack.Pop();
            window.Hide();

            if (_windowsStack.Count > 0)
                _windowsStack.Peek().Show();
        }
    }
}