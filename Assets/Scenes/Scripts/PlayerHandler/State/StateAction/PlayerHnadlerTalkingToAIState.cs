#define ALL_SEAT_ANIM

using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// お客さんを離したとき
/// </summary>
public class PlayerHnadlerTalkingToAIState : IPlayerHandlerState
{

    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    Transform _tagetTransform;
    RayEventHub _rayEventHub;

    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.TALKINGTOAI;

    public PlayerHnadlerTalkingToAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
    {
        this._playerHandler = _playerHandler;
        this._probider= _probider;
        _rayEventHub=new RayEventHub();
    }

    /// <summary>
    /// ステートに入ったとき
    /// </summary>
    public void Entry()
    {
        _tagetTransform = _probider.GetPlayerHnadlerLogicProvider().GetHitTransform();
        _rayEventHub.RaiseOnAiRayFire(_tagetTransform);

		//カーソル切り替え
		_probider.GetPlayerHandlerPresenter().SetSprite(_playerHandler.GetComponent<Image>(), 3);

#if ALL_SEAT_ANIM
		_probider.GetPlayerHnadlerLogicProvider().AiSeatCheckAll();
#else
        _probider.GetPlayerHnadlerLogicProvider().AiSeatCheck();

#endif
        _playerHandler.SearchingAi();

    }

    /// <summary>
    /// ステート中に何度も回る
    /// </summary>
    public void Update()
    {
        _probider.GetPlayerHnadlerLogicProvider().HandlerMove();

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