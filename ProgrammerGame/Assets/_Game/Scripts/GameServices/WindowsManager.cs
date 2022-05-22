using RH.Utilities.ServiceLocator;
using System.Collections.Generic;
using _Game.UI.Windows;

namespace _Game.GameServices
{
    public class WindowsManager : IService
    {
        private Queue<BaseWindow> _windowsStack = new Queue<BaseWindow>();

        public BaseWindow TopWindow => _windowsStack.Peek();
        public bool IsAnyWindowShown => _windowsStack.Count > 0;

        public T Show<T>(T window) where T : BaseWindow
        {
            _windowsStack.Enqueue(window);

            if (_windowsStack.Count == 1)
                window.Show(this);

            return window;
        }

        public void Hide(BaseWindow window)
        {
            _windowsStack.Dequeue();
            window.Hide();

            if (_windowsStack.Count > 0)
                _windowsStack.Peek().Show(this);
        }
    }
}