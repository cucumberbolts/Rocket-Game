public enum GameState
{
    Start,
    Playing,
    Dead
}

public class GameStateManager
{
    public static GameState GameState { get; set; } = GameState.Start;

    public static bool IsState(GameState state) { return state == GameState; }
}
