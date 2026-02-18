using UnityEngine;
/// <summary>
/// ユーザー操作のアウトデータ
/// </summary>
[System.Serializable]
public struct PlayerHandlerView
{
    [Header("マウスカーソルスプライト")]
    [SerializeField] SpriteRenderer _handSprite;
    
    /// <summary>
    /// マウスカーソルのスプライト
    /// </summary>
    public SpriteRenderer HandSprite { get => _handSprite; private set => _handSprite = value; }

}
