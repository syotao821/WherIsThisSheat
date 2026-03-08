using Assets.Scenes.Scripts.Ui;
using UnityEngine;

public class UiManager : SingletonBehaviour<UiManager>,IGameInit
{
	public BusUiSlider busUiSlider;
	public UiTimeController timeController;
	public BusHassyaUiButton busHassyaUiButton;
	public ResultManager resultManager;
	public UiCharaInfomation uiCharaInfomation;

	[SerializeField, Header("目標金額")] int clearScoreValue;
	[SerializeField, Header("制限時間")] float timeLimitValue;

	int currentAiGroup = 0;
	bool isClear = false;
	bool isGameOver = false;
	public int InitOrder => 6;

	public bool IsClear { get => isClear;}
	public bool IsGameOver { get => isGameOver;}
	public int CurrentAiGroup { get => currentAiGroup; set => currentAiGroup = value; }

	void IGameInit.GameInit()
	{
		//UI関係の初期化
		busUiSlider.SetStart();
		timeController.SetStart();
		busHassyaUiButton.SetStart();
		resultManager.SetStart();
		uiCharaInfomation.SetStart();

		//目標金額に到達すると呼ばれる
		busUiSlider.onScoreOver += () =>
		{
			isClear = true;
			resultManager.SetResultPanel(true,timeController.GetClearTime());
		};

		//残り時間が０になると呼ばれる
		timeController.OnTimeOver += () =>
		{
			isGameOver = true;
			resultManager.SetResultPanel(false, busUiSlider.GetBusScore().ToString("C"));
		};

		//目標金額を設定
		busUiSlider.SetClearScore(clearScoreValue);

		//残り時間を設定
		timeController.SetTimeLimit(timeLimitValue);
	}

	/// <summary>
	/// 次のグループのAIを行動させるためにグループIDをインクリメント
	/// </summary>
	public void CountAiGroup()
	{
		currentAiGroup++;
	}


	/// <summary>
	/// 現在のグループIDとAIのグループIDが同じかどうかを確認する関数。
	/// 次のグループのAIを行動させるために使用する。
	/// </summary>
	/// <returns></returns>
	public bool CheckAiGroup(int _myGroupID)
	{
		if (_myGroupID == currentAiGroup) return true;
		
		return false;
	}

	private void OnDestroy()
	{
		busUiSlider.onScoreOver -= () => { };
		timeController.OnTimeOver -= () => { };
	}
}
