using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Scripts.Ui
{
	public class UiTimeController : MonoBehaviour
	{
		float limitTime;//3分なら3
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
			if (isTimeOver) return;

			currentTime -= Time.deltaTime;
			TimeSpan span = new TimeSpan(0, 0, (int)currentTime);
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
	}
}