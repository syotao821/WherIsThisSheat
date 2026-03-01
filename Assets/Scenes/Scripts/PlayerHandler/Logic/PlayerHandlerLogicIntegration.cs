using UnityEngine;


public class PlayerHandlerLogicIntegration
{

    readonly PlayerHandlerApplicationIntegration _playerHandlerApplicationIntegration;
    readonly PlayerHandlerPresenter _playerHandlerPresenter;

    readonly Transform _playerHandlerTransfom;
    readonly RectTransform _playerHandlerRectTransform;
    readonly Canvas _playerHandlerCanvas;

    readonly PlayerHandlerMove _playerHandlerMove;
    readonly MouseRayCheckerPhysics _mouseRayChecker;

    public PlayerHandlerLogicIntegration(PlayerHandlerApplicationIntegration _playerHandlerApplicationIntegration, PlayerHandlerPresenter _playerHandlerPresenter)
    {
        this._playerHandlerApplicationIntegration = _playerHandlerApplicationIntegration;
        this._playerHandlerPresenter = _playerHandlerPresenter;


        _playerHandlerTransfom = this._playerHandlerApplicationIntegration.GetTransForm();
        _playerHandlerRectTransform = this._playerHandlerApplicationIntegration.GetRectTransForm();
        _playerHandlerCanvas=this._playerHandlerPresenter.GetCanvas();


        _playerHandlerMove = new PlayerHandlerMove(_playerHandlerRectTransform, _playerHandlerCanvas);
        _mouseRayChecker = new MouseRayCheckerPhysics();
    }


    public void PlayerHandlerMove()=> _playerHandlerMove.HandlerMove();
    public Transform GetHitTransform()=> _mouseRayChecker.GetHitTransform();
    public bool GetIsRayHit()=> _mouseRayChecker.GetIsRayHit();
}