using UnityEngine;

public class AiBusStopGatherReceiverEventHub
{

	public delegate void OnBusStopReceiver(Transform _busStopTransform);
	public static event OnBusStopReceiver _onBusStopReceiver;
	public void AiBusStopGather(Transform _busStopTransform)
	{
		_onBusStopReceiver.Invoke(_busStopTransform);
	}
}