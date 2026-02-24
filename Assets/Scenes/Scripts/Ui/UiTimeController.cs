using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Scripts.Ui
{
	public class UiTimeController : MonoBehaviour
	{
		float limitTime;//3分なら3
		float currentTime;
		Text timeText;

		private void Start()
		{
			timeText = GetComponent<Text>();
		}

		void Update()
		{
			currentTime -= Time.deltaTime;
			TimeSpan span = new TimeSpan(0, 0, (int)currentTime);
			timeText.text = span.ToString(@"mm\:ss");

			if (currentTime <= 0)
			{
				// 0秒になったときの処理
				Debug.Log("タイムオーバー");
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