using System;
using UnityEngine;
/// <summary>
/// AIに関する総合的なアクセッサー
/// </summary>
public class AiProvider:IDisposable
{
    AiApplicationProvider _applicationProvider;
    AiLogicProvider _aiLogicProvider;
    AiRunTimeData _runtimeData;
    AiEventOrderer _aiEventOrderer;
    AiData _aiData;
    AiSpawnData _aiSpawnData;

	public AiProvider(GameObject _aiObj, AiData _aiData, AiSpawnData _aiSpawnData)
    {
        _applicationProvider = new AiApplicationProvider(_aiObj);
        _aiLogicProvider = new AiLogicProvider(_aiObj.transform);
        _runtimeData=new AiRunTimeData();
        _aiEventOrderer=new AiEventOrderer();
        this._aiData = _aiData;
        this._aiSpawnData = _aiSpawnData;

	}
    
 

    /// <summary>
    /// AIEvent購読の選択
    /// </summary>
    public void UpdateEventOrderer() => _aiEventOrderer.UpdateSelectAi(_applicationProvider.GetApplication().GetAiTransform(),_aiData, _runtimeData);

    /// <summary>
    /// アプリケーションのゲッター
    /// </summary>
    /// <returns></returns>
    public AiApplicationProvider GetApplicationProvider() => _applicationProvider;


    /// <summary>
    /// ロジックのゲッター
    /// </summary>
    /// <returns></returns>
    public AiLogicProvider GetAiLogicProvider() => _aiLogicProvider;


    /// <summary>
    /// 静的データのゲッター
    /// </summary>
    /// <returns></returns>
    public AiData GetAiData() => _aiData;
    public AiSpawnData GetAiSpawnData() => _aiSpawnData;

	/// <summary>
	/// 動的データのゲッター
	/// </summary>
	/// <returns></returns>
	public AiRunTimeData GetRuntimeData() => _runtimeData;


    public void Dispose()
    {
        _aiEventOrderer.Dispose();
    }
}