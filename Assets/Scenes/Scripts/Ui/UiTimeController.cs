using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Scripts.Ui
{
	public class UiTimeController : MonoBehaviour
	{
		float limitTime;//3分なら3 30秒なら0.5 など、分単位で設定する
		float currentTime;
		Text timeText;
		Image timerImage;
		bool isTimeOver = false;
		public event Action OnTimeOver;

		public void SetStart()
		{
			timerImage = transform.GetChild(1).GetComponent<Image>();
			timeText = transform.GetChild(2).GetComponent<Text>();
		}

		void Update()
		{
			if (isTimeOver || UiManager.Instance.IsClear) return;

			currentTime -= Time.deltaTime;
			TimeSpan span = new TimeSpan(0, 0, (int)currentTime);//int hours, int minutes, int seconds
			timeText.text = span.ToString(@"mm\:ss");
			timerImage.fillAmount = Mathf.InverseLerp(limitTime * 60,0, currentTime);

			if (currentTime <= 0)
			{
				// 0秒になったときの処理
				isTimeOver = true;
				OnTimeOver?.Invoke();
			}

		}

		public void SetTimeLimit(float _limitTime)
		{
			limitTime = _limitTime;

			//秒に変換
			currentTime = limitTime * 60;
		}

		public float GetTimeLimit()
		{
			return currentTime;
		}

		/// <summary>
		/// クリアタイムを取得する。残り時間を分:秒の形式で返す
		/// </summary>
		/// <returns></returns>
		public string GetClearTime()
		{
			TimeSpan span = new TimeSpan(0, 0, (int)((limitTime * 60) - currentTime));
			return span.ToString(@"mm\:ss");
		}
	}
}