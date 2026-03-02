using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
	Image resultPanel;
	Text resultText;

	public void SetStart()
	{
		resultPanel = transform.GetChild(0).GetComponent<Image>();
		resultText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
	}

	public void SetResultPanel(bool _isClear)
	{
		resultPanel.gameObject.SetActive(true);
		if (_isClear)
		{
			resultText.text = "CLEAR!!";
		}
		else
		{
			resultText.text = "GAME OVER...";
		}
	}
}
