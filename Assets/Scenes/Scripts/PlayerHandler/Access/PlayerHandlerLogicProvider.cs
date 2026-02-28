using UnityEngine;

public class PlayerHandlerLogicProvider
{
    PlayerHandlerLogicIntegration _logicIntegration;
    public PlayerHandlerLogicProvider(PlayerHandlerApplicationIntegration _playerHandlerTransform,PlayerHandlerPresenter _playerHandlerPresenter)
    {
        _logicIntegration=new PlayerHandlerLogicIntegration(_playerHandlerTransform, _playerHandlerPresenter);
    }

    /// <summary>
    /// マウスカーソル移動
    /// </summary>
    public void HandlerMove()=> _logicIntegration.PlayerHandlerMove();
}