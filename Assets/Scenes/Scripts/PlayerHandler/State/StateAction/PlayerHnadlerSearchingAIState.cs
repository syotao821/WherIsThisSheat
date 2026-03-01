/// <summary>
/// お客さんを探しているとき
/// </summary>
public class PlayerHnadlerSearchingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.SEARCHINGAI;

    public PlayerHnadlerSearchingAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
    {
        this._playerHandler = _playerHandler;
        this._probider = _probider;

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
        _probider.GetPlayerHnadlerLogicProvider().HandlerMove();
        _probider.GetPlayerHnadlerLogicProvider().GetHitTransform();

        if (!_probider.GetPlayerHandlerApplicationProvider().GetApplication().GetInputSearchingAi())
        {
            if (_probider.GetPlayerHnadlerLogicProvider().GetIsRayHit())
            {
                UnityEngine.Debug.Log("a");
            }
        }
    }


    /// <summary>
    /// ステート中に何度も回る
    /// </summary>
    public void FixedUpdate()
    {

    }
    public void Exit()
    {
    }
}
