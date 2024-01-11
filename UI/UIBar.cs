using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBar : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI text;

	[SerializeField] private Image backFill;
	[SerializeField] private Image inFill;

	public float reduceSpeed;

	private bool bUpdateFill = false;
	private bool bUpdateVisible = false;
	private float percentage;

	[SerializeField]private float currTime, visibleTime;


	private void Update()
	{
		if (bUpdateFill == false && bUpdateVisible == false) return;


		if (bUpdateFill)
		{
			if (backFill.fillAmount <= inFill.fillAmount)
			{
				bUpdateVisible = true;
			}
			else
				backFill.fillAmount -= reduceSpeed * Time.deltaTime;
		}

		if (bUpdateVisible)
		{
			if (visibleTime >= 0.0f)
			{
				if (currTime >= visibleTime)
				{
					bUpdateFill = false;
					bUpdateVisible = false;
					return;
				}
				else
					currTime += Time.deltaTime;
			}
		}
	}


	public void Init(int _value, int _valueMax,float _recudeSpeed, float _visibleTime)
	{
		currTime = 0;
		visibleTime = _visibleTime;
		reduceSpeed = _recudeSpeed;

		text.text = _value + " / " + _valueMax;
		percentage = (float)_value / (float)_valueMax;

		backFill.fillAmount = percentage;
		inFill.fillAmount = percentage;
		bUpdateFill = false;
		bUpdateVisible = (_visibleTime <0 ) ?false : true;
	}


	public void Increase(int _curr, int _Max, float _percentage)
	{
		currTime = 0;
		text.text = _curr + " / " + _Max;
		percentage = _percentage;
		backFill.fillAmount = percentage;
		inFill.fillAmount = percentage;
		bUpdateFill = false;
		bUpdateVisible = true;
	}

	public void Reduce(int _curr, int _Max, float _percentage)
	{
		currTime = 0;
		text.text = _curr + " / " + _Max;
		percentage = _percentage;
		inFill.fillAmount = percentage;
		bUpdateFill = true;
		bUpdateVisible = false;
	}


	public void Active(bool _activeself)
	{
		gameObject.SetActive(_activeself);
	}

	public bool CheckVisible()
	{
		return (!bUpdateVisible && !bUpdateFill);
	}
}