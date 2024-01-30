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
		//		data.mainName = "��� ����";
		//		mainExplan = "ü���� 10 ȸ���մϴ�.";
		//		subExplan = "��𿡼� ������ ��� �����̴�";
		//		break;
		//	case FOODITEMINDEX.Star1_BaseWater:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Base;
		//		data.value = 0;
		//		data.foodTimer = 0.0f;
		//		data.mainName = "��";
		//		mainExplan = "������ 10 ȸ���մϴ�.";
		//		subExplan = "���ݾƿ� �װ�";
		//		break;
		//	case FOODITEMINDEX.Star1_H_CookMeat:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Heal;
		//		data.foodTimer = 0.0f;
		//		data.value = 30;

		//		data.mainName = "���� ���";
		//		mainExplan = "ü���� 30 ȸ���Ѵ�";
		//		subExplan = "����� ���� ����";
		//		break;
		//	case FOODITEMINDEX.Star1_R_CornSoup:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.Respawn;
		//		data.foodTimer = 300.0f;

		//		data.mainName = "������ ����";
		//		mainExplan = "���� �÷��̾ ��Ȱ��Ű��, ��Ȱ �� ü���� 10 ȸ���Ѵ�. \n��� �� 300�� ���� ����� �� ����.\n �ݵ�� ���� �÷��̾�Ը� ��밡��";
		//		subExplan = "�߰ſ� ���� �������� �־� �����ð� ���� ����";
		//		break;
		//	case FOODITEMINDEX.Star1_AB_EnergyBar:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffAttack;
		//		data.foodTimer = 300.0f;
		//		data.value = 5;

		//		data.mainName = "������ ��";
		//		mainExplan = "300�� ���� ���ݷ��� 5 �����Ѵ�.";
		//		subExplan = "��� ���� ���������? ���ִµ� �ʹ� ����";

		//		break;
		//	case FOODITEMINDEX.Star1_SB_CanFood:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffShield;
		//		data.foodTimer = 300.0f;
		//		data.value = 5;

		//		data.mainName = "������";
		//		mainExplan = "300�� ���� ������ 5 �����Ѵ�.";
		//		subExplan = "���� ���� �� ���� �ȶ�������?";

		//		break;
		//	case FOODITEMINDEX.Star1_LB_S_SportDrink:
		//		data.count = 1;
		//		data.countMax = 5;
		//		data.star = 1;
		//		data.type = FOODTYPE.BuffLife;
		//		data.value = 5;
		//		data.foodTimer = 0.0f;

		//		data.mainName = "������ ����";
		//		mainExplan = "300�� ���� ���¹̳ʰ� 5 �����Ѵ�.";
		//		subExplan = "�ƾ� ������ ���� ���¹̳ʿ�";

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