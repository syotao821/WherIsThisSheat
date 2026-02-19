
public interface IPlayerHandlerState
{

    // このクラスの状態を取得する
    PLAYERHANDLERSTATE State { get; }

    // 状態開始時に最初に実行される
    void Entry();

    // フレームごとに実行される
    void Update();

    void FixedUpdate();
    // 状態終了時に実行される
    void Exit();
}