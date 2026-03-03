using Assets.Scenes.Scripts.Ui;
using UnityEngine;

public class UiManager : MonoBehaviour,IGameInit
{
	public BusUiSlider busUiSlider;
	public UiTimeController timeController;
	public BusController busController;
	public BusHassyaUiButton busHassyaUiButton;
	public ResultManager resultManager;
	public UiCharaInfomation uiCharaInfomation;

	[SerializeField, Header("目標金額")] int clearScoreValue;
	[SerializeField, Header("制限時間")] float timeLimitValue;
	bool isClear = false;
	bool isGameOver = false;

	public int InitOrder => 4;

	void IGameInit.GameInit()
	{
		//UI関係の初期化
		busUiSlider.SetStart();
		timeController.SetStart();
		busController.SetStart();
		busHassyaUiButton.SetStart();
		resultManager.SetStart();
		uiCharaInfomation.SetStart();

		//目標金額に到達すると呼ばれる
		busUiSlider.onScoreOver += () =>
		{
			isClear = true;
			Debug.Log("クリア");
			resultManager.SetResultPanel(true);
		};

		//残り時間が０になると呼ばれる
		timeController.OnTimeOver += () =>
		{
			isGameOver = true;
			Debug.Log("タイムオーバー");
			resultManager.SetResultPanel(false);
		};

		//目標金額を設定
		busUiSlider.SetClearScore(clearScoreValue);

		//残り時間を設定
		timeController.SetTimeLimit(timeLimitValue);
	}

	private void OnDestroy()
	{
		busUiSlider.onScoreOver -= () => { };
		timeController.OnTimeOver -= () => { };
	}
}
