using System;

namespace _Game.GameServices
{
    public interface IAdTypeProvider : IDisposable
    {
        bool IsReady { get; }
        void Load();
        void Show();
    }
}