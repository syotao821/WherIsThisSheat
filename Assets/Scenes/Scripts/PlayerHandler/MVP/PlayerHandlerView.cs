using UnityEngine;
/// <summary>
/// ユーザー操作のアウトデータ
/// </summary>
[System.Serializable]
public struct PlayerHandlerView
{
    [Header("マウスカーソルスプライト")]
    [SerializeField] Sprite _handSprite;
    
    /// <summary>
    /// マウスカーソルのスプライト
    /// </summary>
    public Sprite HandSprite { get => _handSprite; private set => _handSprite = value; }

}
