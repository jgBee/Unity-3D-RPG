using UnityEngine;
using System.Collections.Generic;

public enum QUESTINDEX
{
	Q1_1GoToNpcMan = 0 ,
	Q1_2KillSpearMan,
	Q1_3QuestItem5,
	Q1_4LastBoss,
}

public class QuestManager : SingleTon<QuestManager>
{
	[SerializeField] private Quest[] prefabQuestList;
	public List<Quest> questListData;

	[SerializeField] private QuestBoard questBoard;

	private void Awake()
	{
		questListData = new List<Quest>();
		foreach (Quest item in prefabQuestList)
		{
			questListData.Add(Instantiate(item));
		}
	}



	public void QuestIn(int _questNumber)
	{
		if (questListData.Count < _questNumber) return;

		questBoard.CreateQuest(_questNumber);
		questListData[_questNumber].QuestStart();
	}

	public void QuestReward(int _questNumber)
	{
		if (questListData.Count < _questNumber) return;
		questListData[_questNumber].QuestReward();
	}


	public void QuestClear(int _questNumber)
	{
		if (questListData.Count < _questNumber) return;
		questListData[_questNumber].QuestComplete();
	}

	public string GetQuestState(int _number)
	{
		if (questListData == null) return "";
		if (questListData.Count < _number) return "";

		string text = "";
		switch (questListData[_number].GetState())
		{
			case QUESTSTATE.Wait:
				text = "대기 중";
				break;
			case QUESTSTATE.Start:
				text = "시작";
				break;
			case QUESTSTATE.Progressing:
				text = "진행 중";
				break;
			case QUESTSTATE.Complete:
				text = "완료";
				break;
			case QUESTSTATE.Reward:
				text = "완료 대기 중";
				break;
		}
		return text;
	}


	public string GetQuestTitle(int _number)
	{
		if (questListData == null) return "";
		if (questListData[_number] == null) return "";

		return questListData[_number].GetTitle();
	}

	public string GetQuestDetail(int _number)
	{
		if (questListData == null) return "";
		if (questListData[_number] == null) return "";

		return questListData[_number].GetNormalText();
	}

	public string GetQuestClearText(int _number)
	{
		if (questListData == null) return "";
		if (questListData[_number] == null) return "";

		return questListData[_number].GetClearText();
	}

	public string GetQuestValue(int _number)
	{
		if (questListData == null) return "";
		if (questListData[_number] == null) return "";

		return questListData[_number].GetQuestValue();
	}

	public void AddValue(int _questNumber, int _addCount)
	{
		if (questListData == null) return ;
		if (questListData[_questNumber] == null) return ;

		if(questListData[_questNumber].GetState() == QUESTSTATE.Progressing)
			questListData[_questNumber].QuestAddValue(_addCount);

	}

	public void SetRewardImage(int _questNumber, ref UnityEngine.UI.Image[] _rewardImage, ref TMPro.TextMeshProUGUI[] _text)
	{
		questListData[_questNumber].SetRewardImage(ref _rewardImage, ref _text);
	}


	public void RewardGivePlayer(int _questNumber)
	{
		questListData[_questNumber].RewardGivePlayer(_questNumber);
	}
}