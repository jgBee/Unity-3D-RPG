using UnityEngine;
using TMPro;

public class UIPlayMode : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI text;
	[SerializeField] private Animator ani;

	string[] str = { "InTown", "InFightZone", "InBossZone" };

	private void Awake()
	{
		gameObject.SetActive(false);
	}

	public void OnMessage(int _index)
	{
		gameObject.SetActive(true);
		ani.Play("PlayMode", 0, 0);
		text.text = str[_index];
	}

	//private void InTown()
	//{
	//	gameObject.SetActive(true);
	//	ani.Play("PlayMode", 0, 0);
	//	text.text = str[0];
	//}

	//private void InFightZone()
	//{
	//	gameObject.SetActive(true);
	//	ani.Play("PlayMode", 0, 0);
	//	text.text = str[1];
	//}

	//private void InBossZone()
	//{
	//	gameObject.SetActive(true);
	//	ani.Play("PlayMode", 0, 0);
	//	text.text = str[2];
	//}
}