using UnityEngine;

/// <summary>
/// AIのアニメーションを定義するクラス
/// </summary>
public class AiAnimation
{
    Animator _animator;
	int currentAnimID = -1;

	public AiAnimation(Animator _animator)
    {
        this._animator = _animator;
    }


    const float ANIM_FADE_TIME = 0.25f;
    const string ANIM_NAME_IDOL_0 = "IDOL_0";
    const string ANIM_NAME_IDOL_1 = "IDOL_1";
    const string ANIM_NAME_IDOL_2 = "IDOL_2";
    const string ANIM_NAME_SITTING_0 = "SITTING_0";
    const string ANIM_NAME_SITTING_1 = "SITTING_1";
    const string ANIM_NAME_SITTING_2 = "SITTING_2";
    const string ANIM_NAME_SITTING_3 = "SITTING_3";

    public void Idle0AnimPlay() => _animator.CrossFade(ANIM_NAME_IDOL_0, ANIM_FADE_TIME);
    public void Idle1AnimPlay() => _animator.CrossFade(ANIM_NAME_IDOL_1, ANIM_FADE_TIME);
    public void Idle2AnimPlay() => _animator.CrossFade(ANIM_NAME_IDOL_2, ANIM_FADE_TIME);
    public void Sitting0AnimPlay() => _animator.CrossFade(ANIM_NAME_SITTING_0, ANIM_FADE_TIME);
    public void Sitting1AnimPlay() => _animator.CrossFade(ANIM_NAME_SITTING_1, ANIM_FADE_TIME);
    public void Sitting2AnimPlay() => _animator.CrossFade(ANIM_NAME_SITTING_2, ANIM_FADE_TIME);
    public void Sitting3AnimPlay() => _animator.CrossFade(ANIM_NAME_SITTING_3, ANIM_FADE_TIME);

	public void SelectAnimationPlay(int _animID)
    {
        if (_animID == currentAnimID) return;

		switch (_animID)
        {
            case 0:
                Idle0AnimPlay();
				break;
            case 1:
                Idle1AnimPlay();
				break;
            case 2:
                Idle2AnimPlay();
				break;
            case 3:
                Sitting0AnimPlay();
				break;
            case 4:
                Sitting1AnimPlay();
				break;
            case 5:
                Sitting2AnimPlay();
				break;
            case 6:
                Sitting3AnimPlay();
				break;
            default:
                Debug.Log("アニメーションIDが不正です");
                break;
        }

		currentAnimID = _animID;
	}


}