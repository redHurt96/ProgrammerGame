using System.Collections.Generic;
using _Game.Data;
using _Game.UI.Windows;

namespace _Game.Services
{
    public static class WindowsManager
    {
        private static Stack<BaseWindow> _windowsStack => GameData.Instance.WindowsStack;
        
        public static T Show<T>(T window) where T : BaseWindow
        {
            _windowsStack.Push(window);

            if (_windowsStack.Count == 1)
                window.Show();

            return window;
        }

        public static void Hide(BaseWindow window)
        {
            _windowsStack.Pop();
            window.Hide();

            if (_windowsStack.Count > 0)
                _windowsStack.Peek().Show();
        }
    }
}