using UnityEngine;
using UnityEngine.UI;

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

            //カーソル切り替え
			_probider.GetPlayerHandlerPresenter().SetSprite(_playerHandler.GetComponent<Image>(),1);
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

			//カーソル切り替え
			_probider.GetPlayerHandlerPresenter().SetSprite(_playerHandler.GetComponent<Image>(), 0);
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
