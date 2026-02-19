using UnityEngine;
using UnityEngine.UI;
public class PlayerHandlerApi
{
    Transform _playerHandleTransform;//マウスカーソルのトランスフォーム
    Animator _animator;//マウスカーソルのアニメーション
    Image _playerHnadlerImage;

    public Transform PlayerHandleTransform { get => _playerHandleTransform; set => _playerHandleTransform = value; }
    public Animator Animator { get => _animator; set => _animator = value; }
    public Image PlayerHandlerImage { get => _playerHnadlerImage; set => _playerHnadlerImage = value; }
}