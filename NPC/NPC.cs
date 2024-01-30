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
			case "대기 중": return;
			case "시작": return;
			case "진행 중":
				chatLog.Clear();
				chatLog.Add("맵의 파란색 원 안에 있는 두루마리가 사라지면 \n다시 말을 걸어 줘");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "남행자", "퀘스트를 주는 사람", renderCamera.targetTexture);
				return;
			case "완료":
				break;
			case "완료 대기 중":
				return;
		}

		switch (QuestManager.Instance.GetQuestState(1))
		{
			case "대기 중":
				UIManager.Instance.WaitQuestInfo(1);
				return;
			case "시작": return;
			case "진행 중":
				chatLog.Clear();
				chatLog.Add("경비병 3명을 잡아줬으면 해");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "남행자", "퀘스트를 주는 사람", renderCamera.targetTexture );
				return;
			case "완료":
				chatLog.Clear();
				chatLog.Add("더 이상 너에게 줄 퀘스트가 없어");
				chatLog.Add("오른쪽 [!]가 사라졌으니 위로 올라가 봐");
				chatLog.Add("다음은 마지막 보스존이야");
				UIManager.Instance.OpenUIChatWindow(ref chatLog, "남행자", "퀘스트를 주는 사람", renderCamera.targetTexture);
				return;
			case "완료 대기 중":
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