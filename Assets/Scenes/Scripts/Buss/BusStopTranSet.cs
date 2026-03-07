using UnityEngine;

/// <summary>
/// バス停にアタッチされたスクリプトでインスタンスを生成して、バス停の位置をイベントハブに送るクラス
/// </summary>
public class BusStopTranSet
{
	Transform _busStopTrans;
	AiBusStopGatherReceiverEventHub _aiBusStopGatherReceiverEventHub;

	/// <summary>
	/// バス停の位置をセットする
	/// </summary>
	/// <param name="_busStopTrans"></param>
	public BusStopTranSet(Transform _busStopTrans)
	{
		this._busStopTrans = _busStopTrans;

		_aiBusStopGatherReceiverEventHub = new AiBusStopGatherReceiverEventHub();
		_aiBusStopGatherReceiverEventHub.AiBusStopGather(this._busStopTrans);
	}
}
