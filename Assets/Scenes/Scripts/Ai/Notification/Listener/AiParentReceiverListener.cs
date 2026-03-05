using System;
using UnityEngine;

public abstract class AiParentReceiverListener : IDisposable
{

	AiParentReceiverMessage _aiParentReceiverMessage;
	protected Func<Transform> _getParentTransform;
	protected Transform _parentTransform;
	bool _disposed;

	public AiParentReceiverListener()
	{
		_aiParentReceiverMessage = new AiParentReceiverMessage();
		AiParentReceiverEventHub._onAiPearentReceiver += SetParentTransform;

		UnityEngine.Debug.Log(1);
	}

	public virtual void Dispose()
	{
		if (_disposed) return;
		AiParentReceiverEventHub._onAiPearentReceiver -= SetParentTransform;
		_disposed = true;
	}


	void SetParentTransform(Transform _parentTransform) => _aiParentReceiverMessage.SetParentTransform(_parentTransform);
	protected Transform GetParentTransform() => _aiParentReceiverMessage.GetParentTransform();
}