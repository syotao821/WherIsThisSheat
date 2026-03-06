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

	public override void Dispose()
	{
		base.Dispose();
	}

}