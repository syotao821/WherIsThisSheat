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
    /// <summary>
    /// レイがヒットしたときヒットしたtransformを返す
    /// </summary>
    /// <returns></returns>
    public Transform GetHitTransform() => _logicIntegration.GetHitTransform();
    /// <summary>
    /// レイがヒットしたかどうか
    /// </summary>
    /// <returns></returns>
    public bool GetIsRayHit() => _logicIntegration.GetIsRayHit();

    public void StartDrag(Transform objTransform) => _logicIntegration.StartDrag(objTransform);
    public void UpdateDrag() => _logicIntegration.UpdateDrag();
    public void EndDrag() => _logicIntegration.EndDrag();
    public void IsDragging() => _logicIntegration.IsDragging();
    public Transform GetSeatTransform() => _logicIntegration.GetSeatTransform();
    public void AiSeatCheckAll() => _logicIntegration.AiSeatCheckAll();
    public void AiSeatCheck() => _logicIntegration.AiSeatCheck();
    public void Dispose() => _logicIntegration.Dispose();


}