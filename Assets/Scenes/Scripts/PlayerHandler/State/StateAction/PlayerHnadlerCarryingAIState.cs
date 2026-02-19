/// <summary>
/// お客さんを運んでいるとき
/// </summary>
public class PlayerHnadlerCarryingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.SEARCHINGAI;

    public PlayerHnadlerCarryingAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
    {
        this._playerHandler = _playerHandler;
    }

    /// <summary>
    /// ステートに入ったとき
    /// </summary>
    public void Entry()
    {

    }

    /// <summary>
    /// ステート中に何度も回る
    /// </summary>
    public void Update()
    {


    }


    /// <summary>
    /// ステート中に何度も回る
    /// </summary>
    public void FixedUpdate()
    {

    }

    /// <summary>
    /// ステートを抜けたとき
    /// </summary>
    public void Exit()
    {
    }
}