using UnityEngine;

/// <summary>
/// AIのアニメーションを定義するクラス
/// </summary>
public class AiAnimation
{
    Animator _animator;


    public AiAnimation(Animator _animator)
    {
        this._animator = _animator;
    }


    const float ANIM_FADE_TIME = 0.25f;
    const string ANIM_NAME_IDEL = "Idel";

    public void IdleAnimPlay() => _animator.CrossFade(ANIM_NAME_IDEL, ANIM_FADE_TIME);
}