using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画面上部のUIをためたお金でスライダーを変化させる
/// </summary>
public class BusUiSlider : MonoBehaviour
{
    int clearScore;
    float currentScore;
    Slider scoreSlider;
    Text scoreText;
	bool isScoreOver = false;//目標金額越えたかどうか
	public event Action onScoreOver;

	public void SetStart()
	{
		scoreSlider = GetComponent<Slider>();
		scoreText = transform.GetChild(4).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
		currentScore = 0;
		scoreSlider.value = 0;
		UpDateBusSlider(0);

		//sliderが動くたびに実行される
		scoreSlider.onValueChanged.AddListener(UpDateBusSlider);
	}

	/// <summary>
	/// 目標金額を外部から設定する
	/// </summary>
	/// <param name="_clearScore"></param>
	public void SetClearScore(int _clearScore)
    {
		clearScore = _clearScore;
		isScoreOver = false;
	}

	/// <summary>
	/// 金額を加算
	/// </summary>
	/// <param name="_addvValue"></param>
	public void SetBusSlider(int _addvValue)
    {
		currentScore = (int)scoreSlider.value + _addvValue;
	}

	/// <summary>
	/// スライダーの01でスコアも同期してテキストの金額が変わる
	/// 0：０円　1：目標金額
	/// </summary>
    public void UpDateBusSlider(float _value)
    {
		if (isScoreOver) return;

		//スコア更新
		currentScore = Mathf.Lerp(0, clearScore, scoreSlider.value);
		scoreText.text = currentScore.ToString("C");//円表示にしてくれる

		//スライダー更新
		scoreSlider.value = Mathf.InverseLerp(0, clearScore, currentScore);

		CheckBusSilider();
	}

	/// <summary>
	/// 現在のスライダー移動量を取得（0～1）
	/// </summary>
	/// <returns></returns>
	public float GetBusSlider()
    {
        return scoreSlider.value;
	}

	/// <summary>
	/// 現在の金額を取得
	/// </summary>
	/// <returns></returns>
	public int GetBusScore()
	{
		return (int)currentScore;
	}

	/// <summary>
	/// 目標金額に到達したらTrue
	/// </summary>
	/// <returns></returns>
	public bool CheckBusSilider()
    {
		if (currentScore >= clearScore)
        {
            //上限まで行ったらそれ以上増やさない
			currentScore = clearScore;
			isScoreOver = true;
			onScoreOver?.Invoke();
			return true;
        }

        return false;
    }
}
