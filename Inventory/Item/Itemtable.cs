using UnityEngine;
using SimpleJSON;

// 이 스크립트는 아이템의 대한 정보를 모두 갖고 있고
// GetReadTable(_index, out Item<T> 입니다)
using nsItemFood;
using static UnityEditor.Progress;

public class Itemtable : SingleTon<Itemtable>
{
	public TextAsset txtFile;
	[SerializeField] JSONNode jsonData;

	private void Start()
	{
		GetJSONData();
	}

	public void GetJSONData()
	{
		string json = txtFile.text;
		jsonData = JSON.Parse(json);
	}

	public void GetWeaponTable(ItemEnum.WEAPONITEMINDEX _index, out ItemWeapon _item)
	{

		string findKey = "";
		switch (_index)
		{
			case ItemEnum.WEAPONITEMINDEX.Star1_1_ItemSword:
				findKey = "녹슨 검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_2_ItemGreatSword:
				findKey = "녹슨 대검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_3_ItemSpear:
				findKey = "녹슨 창";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_4_ItemBow:
				findKey = "녹슨 활";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_5_ItemCatalyst:
				findKey = "녹슨 법구";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_1_ItemSword:
				findKey = "일반 검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_2_ItemGreatSword:
				findKey = "일반 대검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_3_ItemSpear:
				findKey = "일반 창";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_4_ItemBow:
				findKey = "일반 활";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_5_ItemCatalyst:
				findKey = "일반 법구";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_1_ItemSword:
				findKey = "좋은 검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_2_ItemGreatSword:
				findKey = "좋은 대검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_3_ItemSpear:
				findKey = "좋은 창";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_4_ItemBow:
				findKey = "좋은 활";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_5_ItemCatalyst:
				findKey = "좋은 법구";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_1_ItemSword:
				findKey = "멋진 검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_2_ItemGreatSword:
				findKey = "멋진 대검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_3_ItemSpear:
				findKey = "멋진 칭";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_4_ItemBow:
				findKey = "멋진 활";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_5_ItemCatalyst:
				findKey = "멋진 법구";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_1_ItemSword:
				findKey = "화염 검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_2_ItemGreatSword:
				findKey = "물 대검";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_3_ItemSpear:
				findKey = "번개 창";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_4_ItemBow:
				findKey = "풀 활";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_5_ItemCatalyst:
				findKey = "얼음 법구";
				break;
			default:
				break;
		}

		_item = new ItemWeapon();

		JSONNode targetData = jsonData["Weapon"][findKey];
		_item.Init(_index, targetData["Star"], findKey, 
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["Attack"].AsInt, targetData["SubType"], 
			targetData["SubOption"].AsInt, targetData["MaxBreakThrough"].AsInt);
	}



	public void GetEquiptTable(ItemEnum.EQUIPMENTINDEX _index, out ItemEquipment _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.EQUIPMENTINDEX.Star1_Flower:
				findKey = "기본 꽃";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Feather:
				findKey = "기본 깃털";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Hourglass:
				findKey = "기본 모래시계";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Glass:
				findKey = "기본 잔";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Crown:
				findKey = "기본 왕관";
				break;
			default:
				break;
		}
		_item = new ItemEquipment();

		JSONNode targetData = jsonData["Equipment"][findKey];
		_item.Init(_index, targetData["Star"], findKey, targetData["MainOption"], targetData["MainValue"].AsInt,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MaxBreakThrough"].AsInt, targetData["SetName"]);
	}

	public void GetFoodTable(ItemEnum.FOODITEMINDEX _index, out ItemFood _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.FOODITEMINDEX.Star1_BaseMeat:
				findKey = "고기";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_BaseWater:
				findKey = "물";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_H_CookMeat:
				findKey = "익힌 고기";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_R_CornSoup:
				findKey = "옥수수 스프";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_AB_EnergyBar:
				findKey = "에너지바";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_SB_CanFood:
				findKey = "통조림";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_LB_S_SportDrink:
				findKey = "스포츠 음료";
				break;
			default:
				break;
		}

		_item = new ItemFood();
		JSONNode targetData = jsonData["Food"][findKey];
		_item.Init(_index, targetData["Star"], findKey,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MainValue"].AsInt, targetData["SubValue"].AsInt,
			targetData["Type"], targetData["MaxCount"].AsInt);

	}

	public void GetQuestTable(ItemEnum.QUESTITEMINDEX _index, out ItemQuest _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.QUESTITEMINDEX.Star1_SpearManEqupit:
				findKey = "병사의 갑옷";
				break;
			case ItemEnum.QUESTITEMINDEX.Star1_CubeEnterTicket:
				findKey = "진입권";
				break;
			default:
				break;
		}

		_item = new ItemQuest();
		JSONNode targetData = jsonData["Quest"][findKey];
		_item.Init(_index, targetData["Star"], findKey,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MaxCount"].AsInt);
	}

	public void GetGoodsTable(ItemEnum.GOODSITEMINDEX _index, out ItemGoods _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.GOODSITEMINDEX.GameCrystal:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.CashCrystal:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.Special_Ticket:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.Normal_Ticket:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.Character_Exp_Item_Base:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.Weapon_Exp_Item_Base:
				findKey = "";
				break;
			default:
				break;
		}

		_item = new ItemGoods();
		JSONNode targetData = jsonData["Goods"][findKey];
		_item.Init(_index, targetData["Star"], findKey,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MaxCount"].AsInt);
	}
	public void GetReadTable(ItemEnum.READITEMINDEX _index, out ItemRead _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.READITEMINDEX.Star1_1_OldPage:
				break;
			default:
				break;
		}

		_item = new ItemRead();
		JSONNode targetData = jsonData["Read"][findKey];
		_item.Init(_index, targetData["Star"], findKey,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MaxCount"].AsInt);
	}
	public void GetSpecialTable(ItemEnum.SPECIALITEMINDEX _index, out ItemSpecial _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.SPECIALITEMINDEX.Star5_TutorialClear:
				break;
			default:
				break;
		}

		_item = new ItemSpecial();
		JSONNode targetData = jsonData["Special"][findKey];
		_item.Init(_index, targetData["Star"], findKey,
			targetData["MainExplan"], targetData["SubExplan"],
			targetData["MaxCount"].AsInt);
	}
	
}