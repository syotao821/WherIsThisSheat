using DG.Tweening;
using UnityEngine;

public class AiGroupInstance: AiBusStopGaterReceiverListener
{
	Transform _aiTransform;

	public AiGroupInstance(Transform _groupTransform)
	{
		this._aiTransform = _groupTransform;
	}

	public void AiWalk()
	{
		_getBusStopTransform = GetBusStopTransform;
		_busStopTransform = _getBusStopTransform.Invoke();

		// バス停の位置に向かって移動する処理
		_aiTransform.DOPath(
			path: new Vector3[] { GatherPosRundom() }, // Vector3[] に修正
			duration: 3f, //移動時間
			pathType: PathType.CatmullRom)
			.SetLink(_aiTransform.gameObject);
	}

	/// <summary>
	/// バス停の周りにランダムで集まる位置を設定する
	/// </summary>
	/// <returns></returns>
	Vector3 GatherPosRundom()
	{
		Vector3 pos = new Vector3(_busStopTransform.transform.localPosition.x + Random.Range(-3, 3),
			0,
			_busStopTransform.transform.localPosition.z/* + Random.Range(0f, 0)*/);
		return pos;
	}

	public override void Dispose()
	{
		base.Dispose();
	}
}
