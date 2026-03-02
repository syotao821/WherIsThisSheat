using UnityEngine;

/// <summary>
/// お客さんを探しているとき
/// </summary>
public class PlayerHnadlerSearchingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    Transform _tagetTransform;
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
        _tagetTransform= _probider.GetPlayerHnadlerLogicProvider().GetHitTransform();

        if (_probider.GetPlayerHnadlerLogicProvider().GetIsRayHit())
        {
            RayEventHub.RaiseOnRayFire(_tagetTransform);

            if (_probider.GetPlayerHandlerApplicationProvider().GetApplication().GetInputSearchingAi())
            {
               
            }
            else
            {

            }
        }
        else
        {
            RayEventHub.RaiseOnRayFire(null);
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
