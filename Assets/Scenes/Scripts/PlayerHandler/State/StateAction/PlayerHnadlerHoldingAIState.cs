using UnityEngine.UI;

/// <summary>
/// お客さんを持った瞬間
/// </summary>
public class PlayerHnadlerHoldingAIState : IPlayerHandlerState
{
    PlayerHandlerProvider _probider;
    PlayerHandler _playerHandler;
    public PLAYERHANDLERSTATE State => PLAYERHANDLERSTATE.HOLDINGAI;

    public PlayerHnadlerHoldingAIState(PlayerHandler _playerHandler, PlayerHandlerProvider _probider)
    {
        this._playerHandler = _playerHandler;
        this._probider = _probider;

    }

    /// <summary>
    /// ステートに入ったとき
    /// </summary>
    public void Entry()
    {
		//カーソル切り替え
		_probider.GetPlayerHandlerPresenter().SetSprite(_playerHandler.GetComponent<Image>(), 2);

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
