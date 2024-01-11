using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : SingleTon<SoundManager>
{
	[SerializeField] private AudioSource audioBGM;
	[SerializeField] private AudioSource audioSE;

	[SerializeField] private Slider sliderBGM;
	[SerializeField] private Slider sliderSE;


	[SerializeField] private AudioClip[] BGMList;
	[SerializeField] private AudioClip[] SEEnemyList;
	[SerializeField] private AudioClip[] SEPlayerList;
	[SerializeField] private AudioClip[] SEButtonList;
	[SerializeField] private AudioClip[] SENPCList;
	[SerializeField] private AudioClip[] SELevelUp;


	private void Update()
	{
		if (UIManager.Instance.bUIOn)
		{
			audioSE.volume = sliderSE.value;
			audioBGM.volume = sliderBGM.value;

		}
	}

	public void Init(float _BGMVolume, float _SEVolume)
	{
		audioBGM.volume = _BGMVolume;
		audioSE.volume = _SEVolume;
	}

	public void PlayBGM(int _num)
	{
		if (_num < 0 || _num >= BGMList.Length) return;
		audioBGM.loop = true;
		audioBGM.clip = BGMList[_num];
		audioBGM.Play();
	}

	public void PlayPlayerSoundEffect(int _num)
	{
		if (_num < 0 || _num >= SEPlayerList.Length) return;

		audioSE.clip = SEPlayerList[_num];
		audioSE.Play();
	}

	public void PlayEnemySoundEffect(int _num)
	{
		if (_num < 0 || _num >= SEPlayerList.Length) return;

		audioSE.clip = SEEnemyList[_num];
		audioSE.Play();


	}

	public void PlayButtonSoundEffect(int _num)
	{
		if (_num < 0 || _num >= SEButtonList.Length) return;

		audioSE.clip = SEButtonList[_num];
		audioSE.Play();

	}
	public void PlayNPCSoundEffect(int _num)
	{
		if (_num < 0 || _num >= SENPCList.Length) return;

		audioSE.clip = SENPCList[_num];
		audioSE.Play();

	}

	public void PlayLevelUpSoundEffect()
	{
		audioSE.clip = SELevelUp[0];
		audioSE.Play();

	}

}