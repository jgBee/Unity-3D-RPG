using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using static ItemEnum;
using Unity.Burst.CompilerServices;

public class ItemWeapon : MonoBehaviour
{
	public class WeaponData
	{
		private int star;

		private WEAPONINDEX index;

		private int Level;
		private int maxLevel;

		private int dmg;

		private int currBreakThrough;
		private int maxBreakThrough;

		private int exp;
		private int expMax;

		private string mainName;
		private string mainExplan;
		private string subExplan;

		private WEAPON_OPTION subOption;
		private int subOptionValue;
	}
	private WeaponData data;
	public WeaponData Data { get { return data; } set { data = value; } }

	private int star;

	[SerializeField]private WEAPONINDEX index;

	private int Level;
	private int maxLevel;

	private int dmg;

	private int currBreakThrough;
	private int maxBreakThrough;

	private int exp;
	private int expMax;

	private string mainName;
	private string mainExplan;
	private string subExplan;

	private WEAPON_OPTION subOption;
	private int subOptionValue;

	private bool bFavorit;

	int slotNumber;
	public int SlotNumber { get { return slotNumber; } set { slotNumber = value; } }

	[SerializeField] private Image iconImage;
	[SerializeField] private Image iconNew;
	[SerializeField] private Image iconLock;
	[SerializeField] private Image iconChar;
	[SerializeField] private Image iconFavorit;
	[SerializeField] private GameObject FocusObj;
	[SerializeField] private TextMeshProUGUI levelText;

	private UnityAction selectAction;

	public Sprite ItemSprite { get { return iconImage.sprite; } }
	public int Star { get { return star; } }
	public string NameText { get { return mainName; } }
	public string MainExplan { get { return "Lv : " + Level.ToString() + " maxLv : " + maxLevel + "\nBrC : " +currBreakThrough + " BrM : " + maxBreakThrough + "\ndmg : " +dmg + "\nExp " +  exp.ToString() + " ExpMax" + expMax; } }
	public string SubExplan { get { return mainExplan + "\n" + subExplan; } }

	public float ExpPercent { get {
			if (exp >= expMax) return 1.0f;
			else if (0 <= exp) return 0.0f;
			else
				return (exp / (float)expMax);
		}
	}

	public bool Favorit { get { return bFavorit; } set { bFavorit = value; iconFavorit.gameObject.SetActive(bFavorit); } }

	// 생성할 때
	public void Init(WEAPONINDEX _index,int _slotNumber, UnityAction _selectAction)
	{
		index = _index;
		slotNumber = _slotNumber;
		selectAction = _selectAction;
		iconImage.sprite = ItemImage.Instance.GetWeapon(_index);

		switch (_index)
		{
			case WEAPONINDEX.Star1_1_ItemSword:
				BaseDataInit(1);
				mainName = "녹슨 검";
				mainExplan = "정말 기본적인 검입니다.";
				subExplan = "'조금만 쓰다가 버려야겠다.'";
				subOption = WEAPON_OPTION.None;
				subOptionValue = 1;
				break;
			case WEAPONINDEX.Star1_2_ItemGreatSword:
				BaseDataInit(1);
				mainName = "녹슨 대검";
				mainExplan = "정말 기본적인 대검입니다.";
				subExplan = "'조금만 쓰다가 버려야겠다.'";
				subOption = WEAPON_OPTION.None;
				subOptionValue = 1;
				break;
			case WEAPONINDEX.Star1_3_ItemSpear:
				BaseDataInit(1);
				mainName = "녹슨 창";
				mainExplan = "정말 기본적인 창입니다.";
				subExplan = "'조금만 쓰다가 버려야겠다.'";
				subOption = WEAPON_OPTION.None;
				subOptionValue = 1;
				break;
			case WEAPONINDEX.Star1_4_ItemBow:
				BaseDataInit(1);
				mainName = "녹슨 활";
				mainExplan = "정말 기본적인 활입니다.";
				subExplan = "'조금만 쓰다가 버려야겠다.'";
				subOption = WEAPON_OPTION.None;
				subOptionValue = 1;

				break;
			case WEAPONINDEX.Star1_5_ItemCatalyst:
				BaseDataInit(1);
				mainName = "녹슨 법구";
				mainExplan = "정말 기본적인 법구입니다.";
				subExplan = "'조금만 쓰다가 버려야겠다.'";
				subOption = WEAPON_OPTION.None;
				subOptionValue = 1;
				
				break;
			case WEAPONINDEX.Star2_1_ItemSword:
				BaseDataInit(2);
				mainName = "일반 검";
				mainExplan = "기본 데미지가 1 추가됩니다.";
				subExplan = "녹슬려면 조금 시간을 가져야하는 검";
				subOption = WEAPON_OPTION.AddDamage;
				subOptionValue = 10;
				break;
			case WEAPONINDEX.Star2_2_ItemGreatSword:
				BaseDataInit(2);
				mainName = "일반 대검";
				mainExplan = "기본 데미지가 1 추가됩니다.";
				subExplan = "녹슬려면 조금 시간을 가져야하는 대검";
				subOption = WEAPON_OPTION.AddDamage;
				subOptionValue = 10;
				break;
			case WEAPONINDEX.Star2_3_ItemSpear:
				BaseDataInit(2);
				mainName = "일반 창";
				mainExplan = "기본 데미지가 1 추가됩니다.";
				subExplan = "녹슬려면 조금 시간을 가져야하는 창";
				subOption = WEAPON_OPTION.AddDamage;
				subOptionValue = 10;
				break;
			case WEAPONINDEX.Star2_4_ItemBow:
				BaseDataInit(2);
				mainName = "일반 활";
				mainExplan = "기본 데미지가 1 추가됩니다.";
				subExplan = "녹슬려면 조금 시간을 가져야하는 활";
				subOption = WEAPON_OPTION.AddDamage;
				subOptionValue = 10;
				break;
			case WEAPONINDEX.Star2_5_ItemCatalyst:
				BaseDataInit(2);
				mainName = "일반 법구";
				mainExplan = "기본 데미지가 1 추가됩니다.";
				subExplan = "녹슬려면 조금 시간을 가져야하는 법구";
				subOption = WEAPON_OPTION.AddDamage;
				subOptionValue = 10;
				break;
			case WEAPONINDEX.Star3_1_ItemSword:
				BaseDataInit(3);
				mainName = "멋진 검";
				mainExplan = "무기의 공격력이 10 추가로 올라갑니다.";
				subExplan = "생각보다 휘두르기 좋은 검이다.";
				subOption = WEAPON_OPTION.AddWeaponAttackValue;
				subOptionValue = 10 + Level;
				break;
			case WEAPONINDEX.Star3_2_ItemGreatSword:
				BaseDataInit(3);
				mainName = "멋진 대검";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "생각보다 휘두르기 좋은 대검이다.";
				subOption = WEAPON_OPTION.AddWeaponAttackValue;
				subOptionValue = 10 + Level;
				break;
			case WEAPONINDEX.Star3_3_ItemSpear:
				BaseDataInit(3);
				mainName = "멋진 창";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "생각보다 휘두르기 좋은 창이다.";
				subOption = WEAPON_OPTION.AddWeaponAttackValue;
				subOptionValue = 10 + Level;
				break;
			case WEAPONINDEX.Star3_4_ItemBow:
				BaseDataInit(3);
				mainName = "멋진 활";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "생각보다 휘두르기 좋은 활이다.";
				subOption = WEAPON_OPTION.AddWeaponAttackValue;
				subOptionValue = 10 + Level;
				break;
			case WEAPONINDEX.Star3_5_ItemCatalyst:
				BaseDataInit(3);
				mainName = "멋진 법구";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "생각보다 휘두르기 좋은 법구이다.";
				subOption = WEAPON_OPTION.AddWeaponAttackValue;
				subOptionValue = 10 + Level;
				break;
			case WEAPONINDEX.Star4_1_ItemSword:
				BaseDataInit(4);
				mainName = "멋진 검";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "어쩌면 구현못할지도 모르는 검";
				subOption = WEAPON_OPTION.AddWeaponAttackPercent;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star4_2_ItemGreatSword:
				BaseDataInit(4);
				mainName = "멋진 대검";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "어쩌면 구현못할지도 모르는 대검";
				subOption = WEAPON_OPTION.AddWeaponAttackPercent;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star4_3_ItemSpear:
				BaseDataInit(4);
				mainName = "멋진 창";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "어쩌면 구현못할지도 모르는 창";
				subOption = WEAPON_OPTION.AddWeaponAttackPercent;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star4_4_ItemBow:
				BaseDataInit(4);
				mainName = "멋진 활";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "어쩌면 구현못할지도 모르는 활";
				subOption = WEAPON_OPTION.AddWeaponAttackPercent;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star4_5_ItemCatalyst:
				BaseDataInit(4);
				mainName = "멋진 법구";
				mainExplan = "무기의 공격력의 % 추가 공격력을 얻습니다.";
				subExplan = "어쩌면 구현못할지도 모르는 법구";
				subOption = WEAPON_OPTION.AddWeaponAttackPercent;
				subOptionValue = Level;

				break;
			case WEAPONINDEX.Star5_1_ItemSword:
				BaseDataInit(5);
				mainName = "화염 검";
				mainExplan = "화속성 공격이 추가됩니다.";
				subExplan = "불꽃이여 타올라라";
				subOption = WEAPON_OPTION.FireAttack;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star5_2_ItemGreatSword:
				BaseDataInit(5);
				mainName = "물 대검";
				mainExplan = "수속성 공격이 추가됩니다.";
				subExplan = "물렁물렁한 대검 아닙니다.";
				subOption = WEAPON_OPTION.WaterAttack;
				subOptionValue = Level;

				break;
			case WEAPONINDEX.Star5_3_ItemSpear:
				BaseDataInit(5);
				mainName = "번개 창";
				mainExplan = "번개속성 공격이 추가됩니다.";
				subExplan = "전형적인 번개창";
				subOption = WEAPON_OPTION.LightingAttack;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star5_4_ItemBow:
				BaseDataInit(5);
				mainName = "풀 활";
				mainExplan = "풀속성 공격이 추가됩니다.";
				subExplan = "엘프가 사용했을지도 모르는 활";
				subOption = WEAPON_OPTION.GrassAttack;
				subOptionValue = Level;
				break;
			case WEAPONINDEX.Star5_5_ItemCatalyst:
				BaseDataInit(5);
				mainName = "얼음 법구";
				mainExplan = "얼음속성 공격이 추가됩니다.";
				subExplan = "주변이 차가워져서 만지기 어려울지도 모른다";
				subOption = WEAPON_OPTION.IceAttack;
				subOptionValue = Level;
				break;
		}
		levelText.text = "Lv " + Level.ToString();
	}

	private void BaseDataInit(int _n)
	{
		//Favorit = false;

		switch (_n)
		{
			case 1:
				star = 1;
				Level = 1;
				dmg = 10;
				maxLevel = 10;
				exp = 0;
				expMax = 10;
				subOptionValue = 0;
				maxBreakThrough = 1;
				currBreakThrough = 1;
				break;
			case 2:
				star = 2;
				Level = 1;
				dmg = 20;
				maxLevel = 10;
				exp = 0;
				expMax = 10;
				maxBreakThrough = 2;
				currBreakThrough = 1;
				break;
			case 3:
				star = 3;
				Level = 1;
				maxLevel = 10;
				dmg = 30;
				exp = 0;
				expMax = 10;
				maxBreakThrough = 3;
				currBreakThrough = 1;
				break;
			case 4:
				star = 4;
				Level = 1;
				maxLevel = 10;
				dmg = 40;
				exp = 0;
				expMax = 10;
				maxBreakThrough = 4;
				currBreakThrough = 1;
				break;
			case 5:
				star = 5;
				Level = 1;
				maxLevel = 10;
				dmg = 50;
				exp = 0;
				expMax = 10;
				maxBreakThrough = 5;
				currBreakThrough = 1;
				break;
		}
	}


	public void Lock()
	{
		iconLock.gameObject.SetActive(!iconLock.gameObject.activeSelf);
	}

	public void Click()
	{
		//if (iconLock.gameObject.activeSelf == true) return;

		//if (iconNew.gameObject.activeSelf == true)
		//{
		//	iconNew.gameObject.SetActive(false);
		//	return;
		//}
		if( selectAction!= null)
		selectAction();
	}

	public void ExpAdd(int _add)
	{
		int remain = _add;
		int nowExp = 0;
		while (true)
		{
			if (maxLevel >= Level)
			{
				exp = expMax;
				return;
			}
			if( exp + remain >+ expMax)
			{
				remain -= expMax - exp;
				LevelUp();
			}
			else
			{
				exp += remain;
				return;
			}
		}
	}

	private void LevelUp()
	{
		expMax = Level + expMax;
		exp = 0;
	}

	public int BreakThroughUp()
	{
		if (Level < maxLevel) return 1;
		else if (currBreakThrough >= maxBreakThrough) return 2;
		else if( Level == maxLevel)
		{
			currBreakThrough += 1;
			maxLevel = currBreakThrough * 10;
			return 0;
		}
		return -1;
	}

	public void SettingExplan(ref TextMeshProUGUI _mainName, 
		ref Image _itemImage, ref Image _favorit,
		ref TextMeshProUGUI _mainExplan, ref TextMeshProUGUI _subExplan)
	{
		_mainName.text = mainName;
		_mainExplan.text = mainExplan;
		_subExplan.text = subExplan;

		_itemImage.sprite = iconImage.sprite;
		_favorit.sprite = iconFavorit.sprite;
	}


	//public void SettingInfo(ref TextMeshProUGUI _mainName, ref TextMeshProUGUI _level, ref Image _favorit,
	//	ref TextMeshProUGUI _subOption, ref TextMeshPro _subOptionValue,
	//	ref TextMeshProUGUI _exp, ref TextMeshProUGUI _expMax,
	//	ref TextMeshProUGUI _mainExplan, ref TextMeshProUGUI _subExplan,
	//	ref Image _itemImage, out float _expGauge)
	//{
	//	_mainName.text = mainName;
	//	_mainExplan.text = mainExplan;
	//	_subExplan.text = subExplan;
		
	//	_level.text = Level.ToString();
	//	_expMax.text = expMax.ToString();
	//	_exp.text = exp.ToString();

	//	_subOption.text = ((int)subOption).ToString();
	//	_subOptionValue.text = subOptionValue.ToString();
		
	//	_itemImage.sprite = itemImage.sprite;
	//	_favorit.sprite = iconFavorit.sprite;
		
	//	_expGauge = ExpPercent;
	//}

	public static WEAPONINDEX GetItemIndex(int _value)
	{
		WEAPONINDEX index = WEAPONINDEX.Star1_1_ItemSword;
		switch(_value)
		{
			case 0:
				index = WEAPONINDEX.Star1_1_ItemSword;
				break;
			case 1:
				index = WEAPONINDEX.Star1_2_ItemGreatSword;
				break;
		}
		return index;
	}

	public static WEAPONINDEX GetItemRandomIndex()
	{
		int min = 0;
		int max = 2;
		int randValue = UnityEngine.Random.Range(min, max);
		switch (randValue)
		{
			case 0: return WEAPONINDEX.Star1_1_ItemSword;
			case 1: return WEAPONINDEX.Star1_2_ItemGreatSword;
			default:
				return WEAPONINDEX.Star1_1_ItemSword;
		}
	}
}