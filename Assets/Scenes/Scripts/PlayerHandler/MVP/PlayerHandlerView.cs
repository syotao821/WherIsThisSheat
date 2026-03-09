using UnityEngine;
/// <summary>
/// ユーザー操作のアウトデータ
/// </summary>
[System.Serializable]
public struct PlayerHandlerView
{
    [Header("マウスカーソルスプライト")]
    [SerializeField] Sprite[] _handSprite;
    [Header("描画するためのキャンバス")]
    [SerializeField] Canvas _canvas;

    /// <summary>
    /// マウスカーソルのスプライト
    /// </summary>
    public Sprite[] HandSprite { get => _handSprite;  set => _handSprite = value; }
    public Canvas Canvas { get => _canvas; set => _canvas = value; }
}
