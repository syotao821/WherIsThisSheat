using UnityEngine;

public class AiParentReceiverEventHub
{

	public delegate void OnAiPearentReceiver(Transform _parentTransform);
	public static event OnAiPearentReceiver _onAiPearentReceiver;
	public void RaiseOnAiParent(Transform _parentTransform)
	{
		_onAiPearentReceiver.Invoke(_parentTransform);
	}
}