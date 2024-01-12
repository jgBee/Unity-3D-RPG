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
				data.mainName = "고기 조각";
				mainExplan = "체력을 10 회복합니다.";
				subExplan = "어디에서 떨어진 고기 조각이다";
				break;
			case FOODITEMINDEX.Star1_BaseWater:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Base;
				data.value = 0;
				data.foodTimer = 0.0f;
				data.mainName = "물";
				mainExplan = "마력을 10 회복합니다.";
				subExplan = "있잖아요 그거";
				break;
			case FOODITEMINDEX.Star1_H_CookMeat:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Heal;
				data.foodTimer = 0.0f;
				data.value = 30;

				data.mainName = "익힌 고기";
				mainExplan = "체력을 30 회복한다";
				subExplan = "충분히 익힌 고기다";
				break;
			case FOODITEMINDEX.Star1_R_CornSoup:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.Respawn;
				data.foodTimer = 300.0f;

				data.mainName = "옥수수 스프";
				mainExplan = "죽은 플레이어를 부활시키며, 부활 후 체력을 10 회복한다. \n사용 후 300초 동안 사용할 수 없다.\n 반드시 죽은 플레이어에게만 사용가능";
				subExplan = "뜨거운 물에 옥수수를 넣어 오랜시간 끓인 스프";
				break;
			case FOODITEMINDEX.Star1_AB_EnergyBar:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffAttack;
				data.foodTimer = 300.0f;
				data.value = 5;

				data.mainName = "에너지 바";
				mainExplan = "300초 동안 공격력이 5 증가한다.";
				subExplan = "어디서 누가 만들었을까? 맛있는데 너무 적다";

				break;
			case FOODITEMINDEX.Star1_SB_CanFood:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffShield;
				data.foodTimer = 300.0f;
				data.value = 5;

				data.mainName = "통조림";
				mainExplan = "300초 동안 방어력이 5 증가한다.";
				subExplan = "열고 있을 때 누가 안때리겠지?";

				break;
			case FOODITEMINDEX.Star1_LB_S_SportDrink:
				data.count = 1;
				data.countMax = 5;
				data.star = 1;
				data.type = FOODTYPE.BuffLife;
				data.value = 5;
				data.foodTimer = 0.0f;

				data.mainName = "스포츠 음료";
				mainExplan = "300초 동안 스태미너가 5 증가한다.";
				subExplan = "아아 스며든다 나의 스태미너에";

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