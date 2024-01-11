using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerActionButton : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI text;
	[SerializeField] Image fillImage;

	public void SetText(float _percentage, float _value)
	{
		
		if( fillImage != null) fillImage.fillAmount = _percentage;
		if (text != null)
		{
			if (_value > 0)
			{
				text.text = Mathf.Floor(_value).ToString();
			}
			else text.text = "";
		}
	}
}