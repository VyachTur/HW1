namespace GameSystem.InterfaceListeners
{
    public interface IFixedUpdateGameListener : IGameListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}