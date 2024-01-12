using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using static ItemEnum;

[System.Serializable]


public class ItemFood : MonoBehaviour
{
	public class FoodData
	{
		public int star;
		public int value;
		public string mainName;
		public FOODITEMINDEX index;
		public FOODTYPE type;

		public int count;
		public int countMax;

		public float foodTimer;
	}
	[SerializeField]private FoodData data;

	[SerializeField]private string mainExplan;
	[SerializeField]private string subExplan;

	public bool bFavorit;

	public Image favoritSprite;
	public Image itemImage;

	public TextMeshProUGUI textCount;

	int slotNumber;
	public int SlotNumber { get { return slotNumber; } set { slotNumber = value; } }

	public Sprite ItemSprite { get { return itemImage.sprite; } }
	public int Star { get { return data.star; } }
	public string NameText { get { return data.mainName; } }
	public string MainExplan { get { return mainExplan; } }
	public string SubExplan { get { return subExplan; } }

	private UnityAction selectAction;



	public void Init(FOODITEMINDEX _index, int _slotNumber, UnityAction _selectAction)
	{
		if (data == null) data = new FoodData();
		data.index = _index;
		slotNumber = _slotNumber;
		selectAction = _selectAction;
		itemImage.sprite = ItemImage.Instance.GetFood(_index);
		switch (_index)
		{
			case FOODITEMINDEX.Star1_BaseMeat:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Base;
				
				data.value = 0;
				data.foodTimer = 0.0f;
				data.mainName = "��� ����";
				mainExplan = "ü���� 10 ȸ���մϴ�.";
				subExplan = "��𿡼� ������ ��� �����̴�";
				break;
			case FOODITEMINDEX.Star1_BaseWater:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Base;
				data.value = 0;
				data.foodTimer = 0.0f;
				data.mainName = "��";
				mainExplan = "������ 10 ȸ���մϴ�.";
				subExplan = "���ݾƿ� �װ�";
				break;
			case FOODITEMINDEX.Star1_H_CookMeat:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Heal;
				data.foodTimer = 0.0f;
				data.value = 30;

				data.mainName = "���� ���";
				mainExplan = "ü���� 30 ȸ���Ѵ�";
				subExplan = "����� ���� ����";
				break;
			case FOODITEMINDEX.Star1_R_CornSoup:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Respawn;
				data.foodTimer = 300.0f;

				data.mainName = "������ ����";
				mainExplan = "���� �÷��̾ ��Ȱ��Ű��, ��Ȱ �� ü���� 10 ȸ���Ѵ�. \n��� �� 300�� ���� ����� �� ����.\n �ݵ�� ���� �÷��̾�Ը� ��밡��";
				subExplan = "�߰ſ� ���� �������� �־� �����ð� ���� ����";
				break;
			case FOODITEMINDEX.Star1_AB_EnergyBar:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffAttack;
				data.foodTimer = 300.0f;
				data.value = 5;

				data.mainName = "������ ��";
				mainExplan = "300�� ���� ���ݷ��� 5 �����Ѵ�.";
				subExplan = "��� ���� ���������? ���ִµ� �ʹ� ����";

				break;
			case FOODITEMINDEX.Star1_SB_CanFood:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffShield;
				data.foodTimer = 300.0f;
				data.value = 5;

				data.mainName = "������";
				mainExplan = "300�� ���� ������ 5 �����Ѵ�.";
				subExplan = "���� ���� �� ���� �ȶ�������?";

				break;
			case FOODITEMINDEX.Star1_LB_S_SportDrink:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffLife;
				data.value = 5;
				data.foodTimer = 0.0f;

				data.mainName = "������ ����";
				mainExplan = "300�� ���� ���¹̳ʰ� 5 �����Ѵ�.";
				subExplan = "�ƾ� ������ ���� ���¹̳ʿ�";

				break;
		}
		textCount.text = data.count.ToString();

	}


	public void ChangeImage(ref Sprite[] _itemImage, FOODITEMINDEX _index)
	{
		switch (_index)
		{
			case FOODITEMINDEX.Star1_BaseMeat:
				itemImage.sprite = _itemImage[0];
				break;
			case FOODITEMINDEX.Star1_BaseWater:
				itemImage.sprite = _itemImage[1];
				break;
			//case FOODITEMINDEX.Star1_H_CookMeat:
			//	break;
			//case FOODITEMINDEX.Star1_R_CornSoup:
			//	break;
			//case FOODITEMINDEX.Star1_AB_EnergyBar:
			//	break;
			//case FOODITEMINDEX.Star1_SB_CanFood:
			//	break;
			//case FOODITEMINDEX.Star1_LB_S_SportDrink:
			//	break;
			//default:
			//	break;
		}
	}

	public FOODITEMINDEX Type { get {return data.index; } }
	public int Count { get { if (data != null) return data.count; else return -1; } 
		set {
			if (data != null) data.count = value;
			if (data.count >= data.countMax) data.count = data.countMax;
			else if (data.count < 0) data.count = 0;
			textCount.text = data.count.ToString(); } 
	}

	public bool CheckItemIn(int _value)
	{
		return (data.count +_value <= data.countMax)? true:false;

	}

	public void Lock()
	{
		//iconLock.gameObject.SetActive(!iconLock.gameObject.activeSelf);
	}

	public void Click()
	{
		//if (iconLock.gameObject.activeSelf == true) return;

		//if (iconNew.gameObject.activeSelf == true)
		//{
		//	iconNew.gameObject.SetActive(false);
		//	return;
		//}
		if (selectAction != null)
			selectAction();
	}


	public static FOODITEMINDEX GetItemIndex(int _value)
	{
		switch (_value)
		{
			case 0: return FOODITEMINDEX.Star1_BaseMeat;
			case 1: return FOODITEMINDEX.Star1_BaseWater;
			default:
				return FOODITEMINDEX.Star1_BaseMeat;
		}
	}

	public static FOODITEMINDEX GetItemRandomIndex()
	{
		int min = 0;
		int max = 2;
		int randValue = UnityEngine.Random.Range(min, max);
		switch (randValue)
		{
			case 0: return FOODITEMINDEX.Star1_BaseMeat;
			case 1: return FOODITEMINDEX.Star1_BaseWater;
			default:
				return FOODITEMINDEX.Star1_BaseMeat;
		}
	}
}