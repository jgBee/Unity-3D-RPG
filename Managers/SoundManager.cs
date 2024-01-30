using UnityEngine;
using UnityEngine.UI;

public class SoundManager : SingleTon<SoundManager>
{
	[SerializeField] private AudioSource audioBGM;
	[SerializeField] private AudioSource audioSEPlayer;
	[SerializeField] private AudioSource audioSEEnemy;
	[SerializeField] private AudioSource audioSENPC;
	[SerializeField] private AudioSource audioSEButton;

	[SerializeField] private Slider sliderBGM;
	[SerializeField] private Slider sliderSE;


	[SerializeField] private AudioClip[] BGMList;
	[SerializeField] private AudioClip[] SEEnemyList;
	[SerializeField] private AudioClip[] SEPlayerList;
	[SerializeField] private AudioClip[] SEButtonList;
	[SerializeField] private AudioClip[] SENPCList;
	[SerializeField] private AudioClip[] SELevelUp;
	[SerializeField] private AudioClip[] SEBoss;

	[SerializeField] private AudioClip[] SEPortal;

	private void Update()
	{
		if (UIManager.Instance.bUIOn)
		{
			audioBGM.volume = sliderBGM.value;
			audioSEPlayer.volume = sliderSE.value;
			audioSEEnemy.volume = sliderSE.value;
			audioSENPC.volume = sliderSE.value;
			audioSEButton.volume = sliderSE.value;
		}
	}

	public void Init(float _BGMVolume, float _SEVolume)
	{
		audioBGM.volume = _BGMVolume;
		audioSEPlayer.volume = _SEVolume;
		audioSEEnemy.volume = _SEVolume;
		audioSENPC.volume = _SEVolume;
		audioSEButton.volume = _SEVolume;
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

		audioSEPlayer.clip = SEPlayerList[_num];
		audioSEPlayer.Play();
	}

	public void PlayEnemySoundEffect(int _num)
	{
		if (_num < 0 || _num >= SEPlayerList.Length) return;

		audioSEEnemy.clip = SEEnemyList[_num];
		audioSEEnemy.Play();


	}

	public void PlayButtonSoundEffect(int _num)
	{
		if (_num < 0 || _num >= SEButtonList.Length) return;

		audioSEButton.clip = SEButtonList[_num];
		audioSEButton.Play();
	}

	public void PlayNPCSoundEffect(int _num)
	{
		if (_num < 0 || _num >= SENPCList.Length) return;

		audioSENPC.clip = SENPCList[_num];
		audioSENPC.Play();

	}

	public void PlayLevelUpSoundEffect()
	{
		audioSEPlayer.clip = SELevelUp[0];
		audioSEPlayer.Play();

	}

	public void PlayBossSoundEffect(int _num)
	{
		audioSEEnemy.clip = SEBoss[_num];
		audioSEEnemy.Play();
	}
	
	public void PlayPortalSoundEffect()
	{
		audioSEPlayer.clip = SEPortal[0];
		audioSEPlayer.Play();
	}


}