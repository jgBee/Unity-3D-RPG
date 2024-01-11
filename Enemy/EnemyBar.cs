using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBar : MonoBehaviour
{
	[SerializeField] private Slider slider;
	[SerializeField] private TextMeshProUGUI dmgText;
	[SerializeField] private Image critical;

	private float currTime, maxTime = 2.0f;

	private void Update()
	{
		if (currTime >= maxTime)
		{
			gameObject.SetActive(false);
		}
		else
			currTime += Time.deltaTime;	
	}

	public void OnBar(int _dmg, bool _critial, float _percent)
	{
		currTime = 0.0f;
		gameObject.SetActive(true);
		dmgText.text = _dmg.ToString();
		critical.gameObject.SetActive(_critial);
		slider.value = _percent;
	}
}