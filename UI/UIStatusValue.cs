using UnityEngine;
using TMPro;

public class UIStatusValue : MonoBehaviour
{
	public TextMeshProUGUI tmp;

	public void SetValue(int _value)
	{
		//tmp.text = _value.ToString("C2");
		tmp.text = _value.ToString("N2");
		Debug.Log("asdfjkpljwe");

	}

	public void SetValue(int _value, int _valueMax)
	{
		tmp.text = _value + " / " +_valueMax;
	}
}