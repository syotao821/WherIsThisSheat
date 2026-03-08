using UnityEngine;

public class AiChildBinder : AiParentReceiverListener
{
	Transform _aiTransform;

	public AiChildBinder(Transform _seatTransform)
	{
		this._aiTransform = _seatTransform;
	}

	public void ChildBinder()
	{
		_getParentTransform = GetParentTransform;
		_parentTransform = _getParentTransform.Invoke();

		_aiTransform.SetParent(_parentTransform, true);
	}

	/// <summary>
	/// 子オブジェクトを解除
	/// </summary>
	public void ResetParent()
	{
		this._aiTransform.transform.parent = null;
	}

	public override void Dispose()
	{
		base.Dispose();
	}

}