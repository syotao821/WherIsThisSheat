using System;
using UnityEngine;

/// <summary>
/// AIの基本処理　（井町さんが触る場所）
/// </summary>
public class AiBase:IDisposable
{
    AiProvider _aiProvider;
    IAiState _currentState;
    public AiBase(GameObject thisObj,AiData _aiData)
    {
        _aiProvider = new AiProvider(thisObj, _aiData);
        SetState(CreateStateById(_aiData.Id));
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void Dispose()
    {
        _currentState.Exit();
        _aiProvider.Dispose();
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
            case 0: return new AiNormalStateAction(_aiProvider);
            case 1: return new AiNormalStateAction(_aiProvider);
            default: return new AiNormalStateAction(_aiProvider);
        }
    }

}