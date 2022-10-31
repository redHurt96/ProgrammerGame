using _Game.Common;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;

namespace _Game.Logic.Systems
{
    public class ShowNewLevelButtonSystem : BaseInitSystem
    {
        private readonly SceneObjects _sceneObjects;

        public ShowNewLevelButtonSystem() =>
            _sceneObjects = Services.Get<SceneObjects>();
        
        public override void Init() => 
            EventsMediator.Instance.LevelChanged += ShowNewLevelButton;

        public override void Dispose() => 
            EventsMediator.Instance.LevelChanged -= ShowNewLevelButton;

        private void ShowNewLevelButton() => 
            _sceneObjects.NewLevelButton.SetActive(true);
    }
}