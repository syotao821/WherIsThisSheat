using UnityEngine;
using UnityEngine.UI;

public class UiCharaInfomation : MonoBehaviour
{
	Text charaName;
	Text charaInformationStrings;
	Image charaImage;

	public void SetStart()
	{
		charaName = transform.GetChild(1).GetComponent<Text>();
		charaInformationStrings = transform.GetChild(2).GetComponent<Text>();
		charaImage = transform.GetChild(3).GetComponent<Image>();
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
}
