using UnityEngine;
using UnityEngine.UI;
public class PlayerHandlerApi
{
    RectTransform _playerHandlerRectTransform;
    Transform _playerHandleTransform;//マウスカーソルのトランスフォーム
    Animator _playerHandlerAnimator;//マウスカーソルのアニメーション
    Image _playerHnadlerImage;
    public RectTransform PlayerHandlerRectTransform { get => _playerHandlerRectTransform; set => _playerHandlerRectTransform = value; }
    public Transform PlayerHandlerTransform { get => _playerHandleTransform; set => _playerHandleTransform = value; }
    public Animator PlayerHandlerAnimator { get => _playerHandlerAnimator; set => _playerHandlerAnimator = value; }
    public Image PlayerHandlerImage { get => _playerHnadlerImage; set => _playerHnadlerImage = value; }
}