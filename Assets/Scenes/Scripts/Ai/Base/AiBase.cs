using System;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// AIの基本処理　（井町さんが触る場所）
/// </summary>
public class AiBase:IDisposable
{
    AiProvider _aiProvider;
    IAiState _currentState;

    Animator _animator;
    AIANIMATION _aiAnimation;
	public enum AIANIMATION
	{
		NONE = 0,

		IDOL_0,
		IDOL_1,
		IDOL_2,

		SITTING_0,
		SITTING_1,
		SITTING_2,
		SITTING_3,
	}


	public AiBase(GameObject thisObj,AiData _aiData)
    {
        _aiProvider = new AiProvider(thisObj, _aiData);
        SetState(CreateStateById(_aiData.Id));

		_animator = thisObj.GetComponent<Animator>();
        thisObj.transform.eulerAngles = new Vector3(306, 180, 357);//カメラのほうを向くように回転
	}

	public void Start()
	{
		//待機アニメーションをランダムで再生
		PlayAiAnimation(UnityEngine.Random.Range(1,4));
	}

    /// <summary>
    /// キャラ生成時にバスの子オブジェクトにする
    /// </summary>
    public void LateStart()
    {
		_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().ChildBinder();
	}

	public void Update()
    {
        _currentState.Update();
    }

    public void Dispose()
    {
        _currentState.Exit();
        _aiProvider.Dispose();
        _aiProvider.GetAiLogicProvider().Dispose();
    }


    public void SetState(IAiState newState)
    {

        if (_currentState != null)
        {
            _currentState.Exit();      // 前のステートを終了
        }
        _currentState = newState;
        _currentState.Entry();     // 新しいステート開始
    }

    // ID に応じたステート生成
    IAiState CreateStateById(int id)
    {
        switch (id)
        {
            case 0:
            case 5:
            case 1: return new AiNormalStateAction(_aiProvider);
            default: return new AiNormalStateAction(_aiProvider);
        }
    }


	/// <summary>
	/// 指定したEnumのアニメーションを再生(引数整数)
	/// </summary>
	/// <param name="id"></param>
	public void PlayAiAnimation(int _id)
	{
		AIANIMATION animID = (AIANIMATION)_id;
		if (animID == AIANIMATION.NONE)
		{
			Debug.Log("アニメーション未指定");
			return;
		}
		Debug.Log(animID);

		_animator.Play(animID.ToString(), 0, 0.0f);
		_aiAnimation = animID;
	}

}