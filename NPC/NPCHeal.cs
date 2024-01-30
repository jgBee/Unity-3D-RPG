using System.Collections.Generic;
using UnityEngine;

public class NPCHeal : MonoBehaviour
{
	[SerializeField] private UIChatWindow chatWindow;

	[SerializeField] NPCCollider finder;

	[SerializeField] private SpriteRenderer icon;

	private Vector3 resetRotate;
	private Quaternion resetRot;
	private Vector3 pos;

	[SerializeField] private Camera renderCamera;
	Texture2D texture;

	List<string> chatLog;

	[SerializeField] private Animator npcAni;


	private void Awake()
	{
		chatLog = new List<string>();
		resetRotate = new Vector3(0, 0, 0);
		resetRot = Quaternion.Euler(resetRotate);

		chatLog.Add("HP�� ��� ȸ�� ���ѵ帱�Կ� \n ���õ� ���� �Ϸ� �Ǽ���");
	}


	private void Update()
	{
		if (finder.target == null)
		{
			if (transform.rotation.Equals(resetRot) == true)
			{
				return;
			}
			else
				transform.rotation = Quaternion.Slerp(transform.rotation, resetRot, 0.85f * Time.deltaTime);
			return;
		}
		else
		{
			pos = finder.target.transform.position;
			pos.y = transform.position.y;

			transform.LookAt(pos);
		}
	}

	public void OpenUIChatWindow()
	{
		if (UIManager.Instance.UIChatWindowGetActive() == true) return;


		if (npcAni.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			SoundManager.Instance.PlayNPCSoundEffect(0);
			npcAni.Play("ThankFul", 0, 0);
		}
		UIManager.Instance.OpenUIChatWindow(ref chatLog, "�뿤", "���̵�", renderCamera.targetTexture);
	}

}