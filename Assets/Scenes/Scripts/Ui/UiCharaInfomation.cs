using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// お客さんの情報をUIで表示するクラス
/// AiDataEventReciverListenerを継承しているため、AiDataの内容が更新されると自動でUIも更新される
/// </summary>
public class UiCharaInfomation : AiDataEventReciverListenerMono
{
	Text charaName;
	Text charaInformationStrings;
	Image charaImage;
	AiData _aiData;
	int currentInformationIndex = 0;//現在表示中の情報のインデックス
	//float writeSpeed = 1.3f;//ノベル風に表示する際の一文字あたりの表示時間
	Tween moveTween;

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
		charaImage.sprite = _charaIcon;

		string informationTextAll = "";
		//_charaInformationはリストのため、要素の間は改行する
		foreach (var information in _charaInformation)
		{
			informationTextAll += information + "\n";
		}


		//文字送り実行中の場合は中断してから新しい文字送りを開始する
		if (moveTween != null && moveTween.IsActive())
		{
			moveTween.Kill();
		}
		charaInformationStrings.text = "";

		//ノベル風に一文字ずつ表示する
		moveTween = charaInformationStrings
			.DOText(informationTextAll, _aiData.TextSpeed)
			.SetEase(Ease.Linear)
			.SetLink(gameObject);

		//一気に全ての情報を表示する場合は以下のコードを使用する
		//charaInformationStrings.text = informationTextAll;
	}



	public void AiDataUpdate()
	{
		if (UiManager.Instance.IsClear || UiManager.Instance.IsGameOver) return;
		
		_aiData = _getAiData.Invoke();

		//情報がない場合は更新しない
		if (_aiData.Name == null) return;

		//情報が現在表示中のものと同じ場合は更新しない
		if (currentInformationIndex == _aiData.Id) return;

		//表示する情報を更新する
		currentInformationIndex = _aiData.Id;
		SetCharaInformation(_aiData.Name,_aiData.InformationStringList,_aiData.ViewSprite);
	}
}
