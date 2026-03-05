using UnityEngine;
using UnityEngine.UI;

public class UiCharaInfomation : AiDataEventReciverListener
{
	Text charaName;
	Text charaInformationStrings;
	Image charaImage;
	AiData _aiData;

	public void SetStart()
	{
		charaName = transform.GetChild(1).GetComponent<Text>();
		charaInformationStrings = transform.GetChild(2).GetComponent<Text>();
		charaImage = transform.GetChild(3).GetComponent<Image>();

		InvokeRepeating("AiDataUpdate", 0, 0.1f);
	}

	/// <summary>
	/// インフォメーションの内容をセットする関数
	/// </summary>
	public void SetCharaInformation(string _charaName,string _charaInformation,Image _charaIcon)
	{
		charaName.text = _charaName;
		charaInformationStrings.text = _charaInformation;
		charaImage.sprite = _charaIcon.sprite;
	}

	void AiDataUpdate()
	{
		_aiData = _getAiData.Invoke();
		Debug.Log(_aiData.Name);
	}
}
