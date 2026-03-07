using UnityEngine;

public class AiBusStopGaterReceiverMessage
{

	Transform _busStopTransform;


	public void SetBusStopTransform(Transform _busStopTransform) => this._busStopTransform = _busStopTransform;

	public Transform GetBusStopTransform() => _busStopTransform;
}