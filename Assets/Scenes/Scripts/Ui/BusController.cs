using UnityEngine;

/// <summary>
/// バスのアニメーションを管理する
/// </summary>
public class BusController : MonoBehaviour
{
	public enum BUSANIMATION
	{
		NONE = 0,
		DEFAULT,
		TOUCHAKU,
		OPENDOOR,
		CLOSEDOOR,
		HASSYA,//CLOSEDOORのアニメーションイベント登録済みのため、ドア閉めたら勝手に発車再生
	}

	BUSANIMATION bUSANIMATION = BUSANIMATION.NONE;
	Animator animator;


	public void SetStart()
	{
		animator = GetComponent<Animator>();
	}

	/// <summary>
	/// 指定したEnumのアニメーションを再生(引数整数)
	/// </summary>
	/// <param name="id"></param>
	public void PlayBusAnimation(int _id)
	{
		BUSANIMATION animID = (BUSANIMATION)_id;
		if (animID == BUSANIMATION.NONE)
		{
			Debug.Log("アニメーション未指定");
			return;
		}

		animator.Play(animID.ToString(), 0, 0.0f);
		bUSANIMATION = animID;
	}

	/// <summary>
	/// 指定したEnumのアニメーションを再生(引数列挙型)
	/// </summary>
	/// <param name="id"></param>
	public void PlayBusAnimation(BUSANIMATION _id)
	{
		if (_id == BUSANIMATION.NONE)
		{
			Debug.Log("アニメーション未指定");
			return;
		}

		animator.Play(_id.ToString(), 0, 0.0f);
		bUSANIMATION = _id;
	}

	/// <summary>
	/// 現在のバスのアニメーションの状態を取得する
	/// </summary>
	/// <returns></returns>
	public BUSANIMATION GetBusAnimation()
	{
		return bUSANIMATION;
	}
}
