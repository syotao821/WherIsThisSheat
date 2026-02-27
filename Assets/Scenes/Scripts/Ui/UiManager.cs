using UnityEngine;

namespace Assets.Scenes.Scripts.Ui
{
	public class UiManager : MonoBehaviour
	{
		public BusUiSlider busUiSlider;
		public UiTimeController timeController;
		public BusController busController;
		[SerializeField,Header("目標金額")]int clearScoreValue;
		[SerializeField,Header("制限時間")]float timeLimitValue;
		bool isClear = false;
		bool isGameOver = false;

		private void Start()
		{
			//UI関係の初期化
			busUiSlider.SetStart();
			timeController.SetStart();
			busController.SetStart();

			//目標金額に到達すると呼ばれる
			busUiSlider.onScoreOver += () =>
			{
				isClear = true;
				Debug.Log("クリア");
			};

			//残り時間が０になると呼ばれる
			timeController.OnTimeOver += () =>
			{
				isGameOver = true;
				Debug.Log("タイムオーバー");
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
}