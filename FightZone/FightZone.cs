using UnityEngine;

public class FightZone : MonoBehaviour
{
	public MainGirlScrpit player;
	public UIPlayMode playmode;


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			player.InFightZone(true);
			UIManager.Instance.PlayMode(1);
			SoundManager.Instance.PlayBGM(1);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			player.InFightZone(false);
			UIManager.Instance.PlayMode(0);
			SoundManager.Instance.PlayBGM(0);
		}
	}
}