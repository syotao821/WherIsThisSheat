using System.Collections;
using UnityEngine;

namespace Assets.Scenes.Scripts.Ui
{
	public class UiManager : MonoBehaviour
	{
		public BusUiSlider busUiSlider;
		public UiTimeController timeController;


		private void Start()
		{
			//目標金額を設定
			busUiSlider.SetClearScore(30000);

			//残り時間を設定
			timeController.SetTimeLimit(1);
		}
	}
}