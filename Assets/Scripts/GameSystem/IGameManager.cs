namespace GameSystem
{
    public interface IGameManager
    {
        GameState State { get; }
        void LoadGame();
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void EndGame();
    }
}