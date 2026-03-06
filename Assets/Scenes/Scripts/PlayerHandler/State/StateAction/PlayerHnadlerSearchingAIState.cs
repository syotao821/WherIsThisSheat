using UnityEngine;

/// <summary>
/// お客さんを探しているとき
/// </summary>
public class PlayerHnadlerSearchingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    Transform _tagetTransform;
    RayEventHub _rayEventHub;

    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.SEARCHINGAI;

    public PlayerHnadlerSearchingAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
    {
        this._playerHandler = _playerHandler;
        this._probider = _probider;
        _rayEventHub=new RayEventHub();
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
        _tagetTransform= _probider.GetPlayerHnadlerLogicProvider().GetHitTransform();

        if (_probider.GetPlayerHnadlerLogicProvider().GetIsRayHit())
        {
            _rayEventHub.RaiseOnAiRayFire(_tagetTransform);

            if (_probider.GetPlayerHandlerApplicationProvider().GetApplication().GetInputSearchingAi())
            {
               
            }
            else
            {
                _playerHandler.CarryingAi();
            }
        }
        else
        {
            _rayEventHub.RaiseOnAiRayFire(null);
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
