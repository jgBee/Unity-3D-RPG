using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemFood
{
	[SerializeField]private FOODITEMINDEX index;
	private int star;

	private Sprite itemSprite;

	private int level;
	private int maxLevel;

	private int mainValue;
	private int subValue;

	private int currBreakThrough;
	private int maxBreakThrough;

	private int exp;
	private int expMax;

	private string mainName;
	private string mainExplan;
	private string subExplan;

	private int subOptionValue;

	private bool bFavorit;
	private bool bNew;
	private bool bLock;


	// Get

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public int Level => level;
	public int MaxLevel => maxLevel;

	public int MainValue => mainValue;

	public int CurrBreakThrough => currBreakThrough;
	public int MaxBreakThrough => maxBreakThrough;

	public int Exp => exp;
	public int ExpMax => expMax;
	public float ExpPer => (float)exp / (float)expMax;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;

	public bool Favorit { get; set; }
	public bool Lock { get; set; }
	public bool New { get; set; }



	public void Init(FOODITEMINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _mainValue, string _subOptionType, int _subOptionValue, int _maxBreakThrough)
	{
		itemSprite = ItemImage.Instance.GetFood(_index);
		index = _index;

		bFavorit = false;
		bNew = false;
		bLock = false;
		level = 1;
		maxLevel = 10;

		star = _star;

		mainValue = _mainValue;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		currBreakThrough = 1;
		maxBreakThrough = _maxBreakThrough;
		//switch (_index)
		//{
		//	case FOODITEMINDEX.Star1_BaseMeat:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Base;
				
		//		data.value = 0;
		//		data.foodTimer = 0.0f;
		//		data.mainName = "고기 조각";
		//		mainExplan = "체력을 10 회복합니다.";
		//		subExplan = "어디에서 떨어진 고기 조각이다";
		//		break;
		//	case FOODITEMINDEX.Star1_BaseWater:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Base;
		//		data.value = 0;
		//		data.foodTimer = 0.0f;
		//		data.mainName = "물";
		//		mainExplan = "마력을 10 회복합니다.";
		//		subExplan = "있잖아요 그거";
		//		break;
		//	case FOODITEMINDEX.Star1_H_CookMeat:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Heal;
		//		data.foodTimer = 0.0f;
		//		data.value = 30;

		//		data.mainName = "익힌 고기";
		//		mainExplan = "체력을 30 회복한다";
		//		subExplan = "충분히 익힌 고기다";
		//		break;
		//	case FOODITEMINDEX.Star1_R_CornSoup:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Respawn;
		//		data.foodTimer = 300.0f;

		//		data.mainName = "옥수수 스프";
		//		mainExplan = "죽은 플레이어를 부활시키며, 부활 후 체력을 10 회복한다. \n사용 후 300초 동안 사용할 수 없다.\n 반드시 죽은 플레이어에게만 사용가능";
		//		subExplan = "뜨거운 물에 옥수수를 넣어 오랜시간 끓인 스프";
		//		break;
		//	case FOODITEMINDEX.Star1_AB_EnergyBar:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffAttack;
		//		data.foodTimer = 300.0f;
		//		data.value = 5;

		//		data.mainName = "에너지 바";
		//		mainExplan = "300초 동안 공격력이 5 증가한다.";
		//		subExplan = "어디서 누가 만들었을까? 맛있는데 너무 적다";

		//		break;
		//	case FOODITEMINDEX.Star1_SB_CanFood:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffShield;
		//		data.foodTimer = 300.0f;
		//		data.value = 5;

		//		data.mainName = "통조림";
		//		mainExplan = "300초 동안 방어력이 5 증가한다.";
		//		subExplan = "열고 있을 때 누가 안때리겠지?";

		//		break;
		//	case FOODITEMINDEX.Star1_LB_S_SportDrink:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffLife;
		//		data.value = 5;
		//		data.foodTimer = 0.0f;

		//		data.mainName = "스포츠 음료";
		//		mainExplan = "300초 동안 스태미너가 5 증가한다.";
		//		subExplan = "아아 스며든다 나의 스태미너에";

		//		break;
		//}
		//textCount.text = data.count.ToString();

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