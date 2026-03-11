using System;
using UnityEngine;

/// <summary>
/// バスのアニメーションを管理する
/// </summary>
public class BusController : SingletonBehaviour<BusController>,IGameInit
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
	public event Action OnBussDoorOpen;
	public event Action OnBussHassyaAnimeEnd;
	public event Action OnBussTeisyaAnimeStart;
	public event Action OnBussDoorClose;//お客さんの満足度を更新するタイミングでイベント発火
	public int InitOrder => 7;

	void IGameInit.GameInit()
	{
		animator = GetComponent<Animator>();

		//生成したシートとAIのオブジェクトをバスの子に入れる
		BussChildSet bussChildSet = new BussChildSet(this.transform);

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

	public void SetDoorOpenSE()
	{
		UiSound.Instance.Play(UiClips.Instance.audioClip[1]);
	}

	/// <summary>
	/// ドアがオープンした後にイベントで登録する
	/// </summary>
	public void SetDoorOpenInChild()
	{
		OnBussDoorOpen?.Invoke();
	}

	/// <summary>
	/// ドアがクローズした後にイベントで登録する
	/// </summary>
	public void SetDoorClose()
	{
		OnBussDoorClose?.Invoke();
	}

	/// <summary>
	/// バスが発車した後にイベントで登録する
	/// </summary>
	public void SetHassyaResetChild()
	{
		OnBussHassyaAnimeEnd?.Invoke();
	}

	/// <summary>
	/// バスが停車アニメーションを再生を開始したタイミングでイベントで登録する
	/// </summary>
	public void SetTeisyaStart()
	{
		OnBussTeisyaAnimeStart?.Invoke();
	}
}
