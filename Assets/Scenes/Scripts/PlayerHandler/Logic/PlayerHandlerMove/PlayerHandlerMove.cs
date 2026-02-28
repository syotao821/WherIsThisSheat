using UnityEngine;
/// <summary>
/// マウスの動きに対してUiを動かすクラス
/// </summary>
public class PlayerHandlerMove
{
    readonly RectTransform _playerHandlerRectTransfom;
    readonly Canvas _playerHandlerCanvas;

    Vector2 _screenPos;
    Vector2 _uiPos;
    Camera _uiCamera = null;

    public PlayerHandlerMove( RectTransform _playerHandlerRectTransfom,Canvas _playerHandlerCanvas)
    {
        this._playerHandlerRectTransfom = _playerHandlerRectTransfom;
        this._playerHandlerCanvas = _playerHandlerCanvas;
    }

  
    public void HandlerMove()
    {
        // 親が RectTransform でない場合は処理しない（UI階層前提）
        if (_playerHandlerRectTransfom.parent is not RectTransform parentRect)return;

        // --- マウスのスクリーン座標を取得 ---
        _screenPos = Input.mousePosition;

        // --- UI変換に使用するカメラを決定 ---
        _uiCamera = null;
        if (_playerHandlerCanvas.renderMode != RenderMode.ScreenSpaceOverlay)
            _uiCamera = _playerHandlerCanvas.worldCamera;

        // --- スクリーン座標 → UIローカル座標に変換 ---
        // parentRect 基準の anchoredPosition 用座標を取得
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect,_screenPos, _uiCamera, out _uiPos);

        // --- UI位置を更新 ---
        // マウス位置にUIを追従させる
        _playerHandlerRectTransfom.anchoredPosition = _uiPos;
    }


}