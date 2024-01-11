using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
	[SerializeField] Slider slider;
	[SerializeField] TextMeshProUGUI hpText;

	public void Active(bool _flag)
	{
		gameObject.SetActive(_flag);
	}

	public void OnBar(float _hpPer, int _hp, int _hpmax)
	{
		slider.value = _hpPer;
	}
}
