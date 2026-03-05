
using System;
using UnityEngine;
/// <summary>
/// ロジックを集約させる
/// </summary>
public class AiLogickIntegration: IDisposable
{

    Transform _aiTransform;
	AiChildBinder _aiChildBinder;

	/// <summary>
	/// 初期化
	/// </summary>
	public AiLogickIntegration(Transform _aiTransform)
    {
        this._aiTransform = _aiTransform;
		_aiChildBinder = new AiChildBinder(this._aiTransform);
	}

	public void ChildBinder() => _aiChildBinder.ChildBinder();
	public void Dispose()
	{
		_aiChildBinder.Dispose();
	}
}