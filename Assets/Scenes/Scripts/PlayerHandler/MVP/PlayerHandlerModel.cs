using UnityEngine;
/// <summary>
/// ユーザーの隠すべきデータ
/// </summary>
public struct PlayerHandlerModel
{

    Transform _playerHandleTransform;//マウスカーソルのトランスフォーム
    Animator _animator;//マウスカーソルのアニメーション

    public Transform PlayerHandleTransform { get => _playerHandleTransform;　set => _playerHandleTransform = value; }
    public Animator Animator { get => _animator;  set => _animator = value; }
}
