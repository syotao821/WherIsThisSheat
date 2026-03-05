using System.Collections.Generic;
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
		charaImage = transform.GetChild(4).GetComponent<Image>();

		InvokeRepeating("AiDataUpdate", 0, 0.1f);
	}

	/// <summary>
	/// インフォメーションの内容をセットする関数
	/// </summary>
	public void SetCharaInformation(string _charaName,List<string> _charaInformation,Sprite _charaIcon)
	{
		charaName.text = _charaName;
		charaInformationStrings.text = "";
		foreach (var information in _charaInformation)
		{
			charaInformationStrings.text += information + "\n";
		}
		charaImage.sprite = _charaIcon;
	}

	public void AiDataUpdate()
	{
		if (UiManager.Instance.IsClear || UiManager.Instance.IsGameOver) return;
		
		_aiData = _getAiData.Invoke();

		//情報がない場合は更新しない
		if (_aiData.Name == null) return;
		SetCharaInformation(_aiData.Name,_aiData.InformationStringList,_aiData.ViewSprite);
	}
}
