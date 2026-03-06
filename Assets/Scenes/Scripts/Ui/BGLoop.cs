using UnityEngine;
using UnityEngine.UI;

public class BGLoop : MonoBehaviour
{
	private const float MAX_OFFSET = 1f;
	private const string PROPERTY_NAME = "_MainTex";

	Vector2 _offsetSpeed = new Vector2(0.1f,0.1f);
	Material _material;

	private void Start()
	{
		_material = GetComponent<Image>().material;

		InvokeRepeating(nameof(MoveUpdate), 0f, 0.01f);
	}

	private void MoveUpdate()
	{
		if (_material != null)
		{
			var x = Mathf.Repeat(Time.time * _offsetSpeed.x, MAX_OFFSET);
			var y = Mathf.Repeat(Time.time * _offsetSpeed.y, MAX_OFFSET);
			var offset = new Vector2(x, y);
			_material.SetTextureOffset(PROPERTY_NAME, offset);
		}
	}

	private void OnDestroy()
	{
		// オブジェクトが破棄されるタイミングに位置をリセットする
		if (_material != null)
		{
			_material.SetTextureOffset(PROPERTY_NAME, Vector2.zero);
		}
	}
}
