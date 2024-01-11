using TMPro;
using UnityEngine;

public class UINotifyGame : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI text;

	private float currTime, maxTime;
	private bool bUpdate;

	private void Start()
	{
		gameObject.SetActive(false);
	}
	private void Update()
	{
		if (bUpdate == false) return;

		if( currTime >= maxTime)
		{
			gameObject.SetActive(false);
			bUpdate = false;
		}
		else
		{
			currTime += Time.deltaTime;
		}
	}

	public void OnNotify(float _maxTime, string _str)
	{
		gameObject.SetActive(true);
		bUpdate = true;
		maxTime = _maxTime;
		currTime = 0;
		text.text = _str;
	}
}