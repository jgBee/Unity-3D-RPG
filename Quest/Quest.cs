using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public enum QUESTSTATE
{
	Wait = 0,
	Start,
	Progressing,
	Complete,
	Reward,
};

public enum QUESTSTARTTYPE
{
	NPCTalk,
	PointInTalk,
};

[CreateAssetMenu(fileName = "New Quest", menuName = "ThisProject/Quest")]
public class Quest : ScriptableObject
{
	public GameObject prefabPont;

	public GameObject prefabChatWindow;

	public GameObject prefabQuestInterface;

	public int QuestNumber;
	[Tooltip("")] public string NPCName;
	public int QuestSequence;

	public QUESTSTATE state = QUESTSTATE.Wait;
	public QUESTSTARTTYPE type = QUESTSTARTTYPE.NPCTalk;

	public string title;
	public Sprite npcImage;

	public Vector3 startTalkPoint;

	[TextArea(2, 16)]
	public string NormalDialog, CompleteDialog;

	public int QuestValueCount;
	public int QuestValueCountMax;

	[Header("Reward")]
	public int rewardJewel;
	public int rewardGold;
	public int rewardExp;

	public List<ItemEnum.WEAPONITEMINDEX> weaponList;
	public List<ItemEnum.EQUIPTMENTINDEX> equiptList;
	public List<ItemEnum.FOODITEMINDEX> foodList;

	public void QuestStart()
	{
		if (QUESTSTARTTYPE.PointInTalk == type)
		{

			if (prefabPont != null)
			{
				GameObject questObj = Instantiate(prefabPont, startTalkPoint, Quaternion.identity);
				questObj.GetComponent<QuestPointAction>().actionValue = QuestNumber;

			}
		}
		state = QUESTSTATE.Progressing;
	}

	public void QuestReward()
	{
		state = QUESTSTATE.Reward;

	}

	public void QuestComplete()
	{
		state = QUESTSTATE.Complete;
	}

	public void QuestAddValue(int _n = 1)
	{
		if (state != QUESTSTATE.Progressing) return;
		QuestValueCount += _n;
		if (QuestValueCount >= QuestValueCountMax)
		{
			QuestManager.Instance.QuestReward(QuestNumber);
			QuestValueCount = QuestValueCountMax;
		}
	}
	public QUESTSTATE GetState()
	{
		return state;
	}

	public string GetTitle()
	{
		return title;
	}

	public string GetNormalText()
	{
		return NormalDialog;
	}


	public string GetClearText()
	{
		return CompleteDialog;
	}


	public string GetCompleteText()
	{
		return CompleteDialog;
	}

	public string GetQuestValue()
	{
		
		return (QuestValueCount + " / " + QuestValueCountMax);
	}

	public void SetRewardImage(ref UnityEngine.UI.Image[] _rewardImage, ref TMPro.TextMeshProUGUI[] _rewardText)
	{
		int weaponCount ,equiptCount ,foodCount ,currCount = 0;

		// 0 쥬얼
		_rewardImage[0].gameObject.SetActive(true);
		_rewardText[0].text = rewardJewel.ToString();

		// 1 경험치
		_rewardImage[1].gameObject.SetActive(true);
		_rewardText[1].text = rewardExp.ToString();

		// 2 골드
		_rewardImage[2].gameObject.SetActive(true);
		_rewardText[2].text = rewardGold.ToString();

		currCount = 3;

		if ( weaponList == null && equiptList == null && foodList == null) return;

		// 3 아이템의 이미지 세팅
		// 3-1 웨폰
		if( weaponList != null)
		{
			foreach (var item in weaponList)
			{
				_rewardImage[currCount].gameObject.SetActive(true);
				_rewardImage[currCount].sprite = ItemImage.Instance.GetWeapon(item);
				_rewardText[currCount].text = "1";
				currCount++;
			}
		}

		// 3-2 방어구
		if (equiptList != null)
		{
			foreach (var item in equiptList)
			{
				_rewardImage[currCount].gameObject.SetActive(true);
				_rewardImage[currCount].sprite = ItemImage.Instance.GetEquipt(item);
				_rewardText[currCount].text = "1";
				currCount++;
			}
		}

		// 3-3 먹을 것들
		if (foodList != null)
		{
			foreach (var item in foodList)
			{
				_rewardImage[currCount].gameObject.SetActive(true);
				_rewardImage[currCount].sprite = ItemImage.Instance.GetFood(item);
				_rewardText[currCount].text = "1";
				currCount++;
			}
		}
	}

	public void RewardGivePlayer(int _questNumber)
	{
		// 플레이어 정보를 싱글톤으로 만든다면 수정해야함

		Inventory.Instance.Jewel += rewardJewel;
//		Inventory.Instance.Gold += rewardGold;
		GameObject.Find("PlayerObject").GetComponent<MainGirlScrpit>().GetExpGold(rewardExp,rewardGold);

		if (weaponList != null)
		{
			foreach (var item in weaponList)
			{
				Inventory.Instance.WeaponItemIn(item);
			}
		}

		// 3-2 방어구
		if (equiptList != null)
		{
			foreach (var item in equiptList)
			{
				Inventory.Instance.EquiptItemIn(item);
			}
		}

		// 3-3 먹을 것들
		if (foodList != null)
		{
			foreach (var item in foodList)
			{
				Inventory.Instance.FoodItemIn(item);
			}
		}

	}
}