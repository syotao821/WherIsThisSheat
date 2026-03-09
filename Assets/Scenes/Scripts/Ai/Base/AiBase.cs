using System;
using UnityEngine;

/// <summary>
/// AIの基本処理　（井町さんが触る場所）
/// </summary>
public class AiBase:IDisposable
{
    AiProvider _aiProvider;
    IAiState _currentState;
    Transform _transform;


	public AiBase(GameObject thisObj,AiData _aiData,AiSpawnData _aiSpawnData)
    {
        _aiProvider = new AiProvider(thisObj, _aiData, _aiSpawnData);
        SetState(CreateStateById(_aiData.Id));

		_transform = thisObj.transform;
	}

	public void Start()
	{
	}

	/// <summary>
	/// キャラ生成時にバスの子オブジェクトにする
	/// </summary>
	public void LateStart()
    {
		//別のタイミングでバスの子オブジェクトにするため、ここでは呼ばない
		//_aiProvider.GetAiLogicProvider().GetAiLogickIntegration().ChildBinder();
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
}