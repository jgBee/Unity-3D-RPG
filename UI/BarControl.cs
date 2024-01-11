using UnityEngine;

public class BarControl : MonoBehaviour
{
	[SerializeField] private UIBar hpBar;
	[SerializeField] private UIBar mpBar;

	public bool bUseMP;

	private bool bVisible =false;


	private void Update()
	{
		if(bVisible)
		{
			if (hpBar.CheckVisible() && mpBar.CheckVisible())
				gameObject.SetActive(false);
		}
	}
	public void Init(int _hp,int _hpMax, float _reduceSpeedHp, int _mp, int _mpMax, float _reduceSpeedMp, float _visibleTime = -0.1f)
	{
		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);

		hpBar.Init(_hp,_hpMax, _reduceSpeedHp, _visibleTime);
		mpBar.Init(_mp,_mpMax, _reduceSpeedMp, _visibleTime);

		bVisible = (_visibleTime >= 0) ? true : false;
		bUseMP = true;
		mpBar.Active(true);
	}

	public void Init(int _hp, int _hpMax, float _reduceSpeed, float _visibleTime = -0.1f)
	{
		if (gameObject.activeSelf == false)
			gameObject.SetActive(true);

		bVisible = (_visibleTime > 0) ? true : false;
		hpBar.Init(_hp,_hpMax, _reduceSpeed, _visibleTime);
		bUseMP = false;
		mpBar.Active(false);
	}


	public void IncreaseHP(int _curr, int _Max, float _percentage)
	{
		if (gameObject.activeSelf == false) gameObject.SetActive(true);

		hpBar.Increase(_curr, _Max, _percentage);
	}

	public void ReduceHP(int _curr, int _Max, float _percentage)
	{
		if (gameObject.activeSelf == false) gameObject.SetActive(true);

		hpBar.Reduce(_curr,_Max,_percentage);
	}


	public void IncreaseMP(int _curr, int _Max, float _percentage)
	{
		if (bUseMP == false) return;
		if (gameObject.activeSelf == false) gameObject.SetActive(true);
		mpBar.Active(true);

		mpBar.Increase(_curr, _Max, _percentage);
		
	}

	public void ReduceMP(int _curr, int _Max, float _percentage)
	{
		if (bUseMP == false) return;
		
		if (gameObject.activeSelf == false) gameObject.SetActive(true);
		mpBar.Active(true);

		mpBar.Reduce(_curr, _Max, _percentage);
	}

}