
using System;
using UnityEngine;
/// <summary>
/// ロジックを集約させる
/// </summary>
public class AiLogickIntegration: IDisposable
{

    Transform _aiTransform;
	AiChildBinder _aiChildBinder;
	AiGroupInstance _aiGroupInstance;
	/// <summary>
	/// 初期化
	/// </summary>
	public AiLogickIntegration(Transform _aiTransform)
    {
        this._aiTransform = _aiTransform;
		_aiChildBinder = new AiChildBinder(this._aiTransform);
		_aiGroupInstance = new AiGroupInstance(this._aiTransform);
	}



    public void ChildBinder() => _aiChildBinder.ChildBinder();
	public void ResetParent() => _aiChildBinder.ResetParent();
    public bool IsSeat() => _aiChildBinder.IsSeat();

    public void AiWalk() => _aiGroupInstance.AiWalk();
	public void Dispose()
	{
		_aiChildBinder.Dispose();
	}
}