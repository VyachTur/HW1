namespace GameSystem.InterfaceListeners
{
    public interface ILateUpdateGameListener : IGameListener
    {
        void OnLateUpdate(float deltaTime);
    }
}