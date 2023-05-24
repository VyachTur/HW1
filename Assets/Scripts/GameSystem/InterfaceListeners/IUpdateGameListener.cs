namespace GameSystem.InterfaceListeners
{
    public interface IUpdateGameListener : IGameListener
    {
        void OnUpdate(float deltaTime);
    }
}
