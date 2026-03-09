using System;
using UnityEngine;

public class SeatBase:IDisposable
{
    SeatProvider _seatProvider;
	int myGrouID = -1;

	public SeatBase(GameObject _thisObj,SeatData _thisSeatData,SeatSpawnData _thisSeatSpawnData)
    {
        _seatProvider =new SeatProvider(_thisObj, _thisSeatData, _thisSeatSpawnData);
        _thisObj.transform.eulerAngles = new Vector3(0, 90, 0);//バス正面を向くように回転
    }
    public void Start()
    {

		//自身のグループIDを取得しておく
		myGrouID = _seatProvider.GetSeatSpawnData().GroupId;

		//バスが動いた瞬間のタイミングでイベント発火
		//バスの子オブジェクトにセット
		BusController.Instance.OnBussTeisyaStartSet += () =>
		{
			if (UiManager.Instance.CheckAiGroup(myGrouID))
			{
				_seatProvider.GetSeatLogickProvider().GetSeatLogickIntegration().ChildBinder();
			}
		};

		//バスの発車して見えなくなったタイミングでイベント発火
		//バスの子オブジェクトにセット
		BusController.Instance.OnBussResetChildSet += () =>
		{
			_seatProvider.GetSeatLogickProvider().GetSeatLogickIntegration().ResetParent();
		};


	}
	public void Update()
    {
        _seatProvider.EventOderUpdate();
    }

    public void Dispose()
    {
        _seatProvider.Dispose();

		if(BusController.Instance != null)
		BusController.Instance.OnBussResetChildSet -= () => { };
		BusController.Instance.OnBussTeisyaStartSet -= () => { };
	}
}