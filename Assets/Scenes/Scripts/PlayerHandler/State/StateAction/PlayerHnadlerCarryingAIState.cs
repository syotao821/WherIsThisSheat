using UnityEngine;

/// <summary>
/// お客さんを運んでいるとき
/// </summary>
public class PlayerHnadlerCarryingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    Transform _tagetTransform;
    RayEventHub _rayEventHub;
    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.CARRYINGAI;

    public PlayerHnadlerCarryingAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
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
        _tagetTransform = _probider.GetPlayerHnadlerLogicProvider().GetHitTransform();
        _probider.GetPlayerHnadlerLogicProvider().StartDrag(_tagetTransform);
        
    }

    /// <summary>
    /// ステート中に何度も回る
    /// </summary>
    public void Update()
    {
        _probider.GetPlayerHnadlerLogicProvider().HandlerMove();
        if (_probider.GetPlayerHandlerApplicationProvider().GetApplication().GetInputCarryingAi())
        {
            _rayEventHub.RaiseOnAiRayFire(_tagetTransform);
            _probider.GetPlayerHnadlerLogicProvider().UpdateDrag();
            _rayEventHub.RaiseOnSeatRayFire(_probider.GetPlayerHnadlerLogicProvider().GetSeatTransform());

        }
        else
        {
            _rayEventHub.RaiseOnAiRayFire(null);
            _rayEventHub.RaiseOnSeatRayFire(null);
            _playerHandler.TalkingtoAi();
        }

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
        _probider.GetPlayerHnadlerLogicProvider().EndDrag();

    }
}