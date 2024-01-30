using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	private Vector3 resetRotate;
	private Quaternion resetRot;
	private Vector3 pos;


	[SerializeField] private int[] questNumber;

	public GameObject dontForwardWall;

	[SerializeField] private SpriteRenderer icon;

	[SerializeField]NPCCollider finder;
	[SerializeField] private Camera renderCamera;

	[SerializeField] private Animator npcAni;

	List<string> chatLog;

	private void Awake()
	{
		chatLog = new List<string>();
		resetRotate = new Vector3(0, 180, 0);
		resetRot = Quaternion.Euler(resetRotate);
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
				transform.rotation = Quaternion.Slerp(transform.rotation,resetRot, 0.85f *Time.deltaTime);
			return;
		}
		else
		{
			pos = finder.target.transform.position;
			pos.y = transform.position.y;

			transform.LookAt(pos);
		}
	}

	public void OpenQuestInfo()
	{
		if (UIManager.Instance.UIChatWindowGetActive() == true) return;
		if(npcAni.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			npcAni.Play("Talk", 0, 0);
		}
		switch (QuestManager.Instance.GetQuestState(0))
		{
			case "��� ��": return;
			case "����": return;
			case "���� ��":
				chatLog.Clear();
				chatLog.Add("���� �Ķ��� �� �ȿ� �ִ� �η縶���� ������� \n�ٽ� ���� �ɾ� ��");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "������", "����Ʈ�� �ִ� ���", renderCamera.targetTexture);
				return;
			case "�Ϸ�":
				break;
			case "�Ϸ� ��� ��":
				return;
		}

		switch (QuestManager.Instance.GetQuestState(1))
		{
			case "��� ��":
				UIManager.Instance.WaitQuestInfo(1);
				return;
			case "����": return;
			case "���� ��":
				chatLog.Clear();
				chatLog.Add("��� 3���� ��������� ��");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "������", "����Ʈ�� �ִ� ���", renderCamera.targetTexture );
				return;
			case "�Ϸ�":
				chatLog.Clear();
				chatLog.Add("�� �̻� �ʿ��� �� ����Ʈ�� ����");
				chatLog.Add("������ [!]�� ��������� ���� �ö� ��");
				chatLog.Add("������ ������ �������̾�");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "������", "����Ʈ�� �ִ� ���", renderCamera.targetTexture);
				return;
			case "�Ϸ� ��� ��":
				UIManager.Instance.RewardQuestInfo(1, delegate () { 
				if (dontForwardWall) Destroy(dontForwardWall);
				QuestManager.Instance.QuestIn(2);

				if (icon != null) 
					Destroy(icon);
				});

				return;
		}
	}

}