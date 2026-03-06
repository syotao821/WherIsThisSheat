using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	Image resultPanel;
	Text resultText;

	GameObject[] resultBG = new GameObject[2];//0:クリアBG 1:ゲームオーバーBG


	public void SetStart()
	{
		resultPanel = transform.GetChild(0).GetComponent<Image>();
		resultText = transform.GetChild(0).GetChild(2).GetComponent<Text>();

		resultBG[0] = transform.GetChild(0).GetChild(0).gameObject;
		resultBG[1] = transform.GetChild(0).GetChild(1).gameObject;

		resultPanel.gameObject.SetActive(false);
	}

	public void SetResultPanel(bool _isClear,string _resultText)
	{
		resultPanel.gameObject.SetActive(true);
		if (_isClear)
		{
			resultBG[0].SetActive(true);
			resultBG[1].SetActive(false);
		}
		else
		{
			resultBG[1].SetActive(true);
			resultBG[0].SetActive(false);
		}
		resultText.text = _resultText;
	}
}
