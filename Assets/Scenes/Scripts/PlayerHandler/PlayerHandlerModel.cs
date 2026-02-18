using UnityEngine;
/// <summary>
/// ユーザーの隠すべきデータ
/// </summary>
[System.Serializable]
public struct PlayerHandlerModel
{

    Transform _playerHandleTransform;//マウスカーソルのトランスフォーム
    Animator _animator;//マウスカーソルのアニメーション

    public Transform PlayerHandleTransform { get => _playerHandleTransform;　private　 set => _playerHandleTransform = value; }
    public Animator Animator { get => _animator; private set => _animator = value; }
}
