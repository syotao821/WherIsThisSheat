using System;
using UnityEngine;

public abstract class AiBusStopGaterReceiverListener : IDisposable
{

	AiBusStopGaterReceiverMessage _aiBusStopGaherReceiverMessage;
	protected Func<Transform> _getBusStopTransform;
	protected Transform _busStopTransform;
	bool _disposed;

	public AiBusStopGaterReceiverListener()
	{
		_aiBusStopGaherReceiverMessage = new AiBusStopGaterReceiverMessage();
		AiBusStopGatherReceiverEventHub._onBusStopReceiver += SetBusStopTransform;
	}

	public virtual void Dispose()
	{
		if (_disposed) return;
		AiBusStopGatherReceiverEventHub._onBusStopReceiver -= SetBusStopTransform;
		_disposed = true;
	}


	void SetBusStopTransform(Transform _busStopTransform) => _aiBusStopGaherReceiverMessage.SetBusStopTransform(_busStopTransform);
	protected Transform GetBusStopTransform() => _aiBusStopGaherReceiverMessage.GetBusStopTransform();
}