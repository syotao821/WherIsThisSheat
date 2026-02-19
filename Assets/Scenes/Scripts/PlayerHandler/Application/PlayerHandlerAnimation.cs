using UnityEngine;
public class PlayerHandlerAnimation
{

    Animator _animator;


    public PlayerHandlerAnimation(Animator _animator)
    {
        this._animator = _animator;
    }
    const float ANIM_FADE_TIME = 0.25f;

    const string ANIM_NAME_NORMAL = "Normal";

    public void NormalAnimPlay() => _animator.CrossFade(ANIM_NAME_NORMAL, ANIM_FADE_TIME);






}