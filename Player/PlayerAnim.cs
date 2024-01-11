using System.Collections;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
	private Animator anim;

	public float[] AtkDelay;

	public float skillDelay;


	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
	}

	public enum ANIINDEX
	{
		Idle = 0,

		Move,
		Atk,
		Skill,
		Hit,
		Dead,
		Max
	};

	public void StartAniForSetInt(ANIINDEX _index)
	{
		anim.SetInteger("PLAYERSTATE", (int)_index);
	}

	public void StartAni_Idle()
	{
		anim.SetBool("Idle", true);
		anim.SetBool("Walk", false);
		anim.SetBool("Run", false);
	}

	public void StartAni_Walk()
	{
		anim.SetBool("Idle", false);
		anim.SetBool("Walk", true);
		anim.SetBool("Run", false);
	}

	public void StartAni_Run()
	{
		anim.SetBool("Idle", false);
		anim.SetBool("Walk", false);
		anim.SetBool("Run", true);
	}


	public void StartAni_Complusion(ANIINDEX _index)
	{
		switch (_index)
		{
			case ANIINDEX.Idle:
				anim.CrossFade("", 0.1f);
				break;
			case ANIINDEX.Move:
				anim.CrossFade("", 0.1f);
				break;
			case ANIINDEX.Atk:
				anim.CrossFade("", 0.1f);
				break;
			case ANIINDEX.Skill:
				anim.CrossFade("", 0.1f);
				break;
			case ANIINDEX.Hit:
				anim.CrossFade("", 0.1f);
				break;
			case ANIINDEX.Dead:
				anim.CrossFade("", 0.1f);
				break;
		}
	}

	public bool IsAnimationAtk()
	{
		int value = anim.GetInteger("PLAYERSTATE");
		if ( value == 2 || value == 3 || value == 4) return true;

		return false;
	}

	public void SetBlendSpeed(float _speed) { anim.SetFloat("Speed", _speed); }
}