using UnityEngine;
using SimpleJSON;

// �� ��ũ��Ʈ�� �������� ���� ������ ��� ���� �ְ�
// GetReadTable(_index, out Item<T> �Դϴ�)
using nsItemFood;
using static UnityEditor.Progress;

public class Itemtable : SlngleTonMonobehaviour<Itemtable>
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

	public void GetWeaponTable(ItemEnum.WEAPONeItemIndex _index, out ItemWeapon _item)
	{

		string findKey = "";
		switch (_index)
		{
			case ItemEnum.WEAPONeItemIndex.Star1_1_ItemSword:
				findKey = "�콼 ��";
				break;
			case ItemEnum.WEAPONeItemIndex.Star1_2_ItemGreatSword:
				findKey = "�콼 ���";
				break;
			case ItemEnum.WEAPONeItemIndex.Star1_3_ItemSpear:
				findKey = "�콼 â";
				break;
			case ItemEnum.WEAPONeItemIndex.Star1_4_ItemBow:
				findKey = "�콼 Ȱ";
				break;
			case ItemEnum.WEAPONeItemIndex.Star1_5_ItemCatalyst:
				findKey = "�콼 ����";
				break;
			case ItemEnum.WEAPONeItemIndex.Star2_1_ItemSword:
				findKey = "�Ϲ� ��";
				break;
			case ItemEnum.WEAPONeItemIndex.Star2_2_ItemGreatSword:
				findKey = "�Ϲ� ���";
				break;
			case ItemEnum.WEAPONeItemIndex.Star2_3_ItemSpear:
				findKey = "�Ϲ� â";
				break;
			case ItemEnum.WEAPONeItemIndex.Star2_4_ItemBow:
				findKey = "�Ϲ� Ȱ";
				break;
			case ItemEnum.WEAPONeItemIndex.Star2_5_ItemCatalyst:
				findKey = "�Ϲ� ����";
				break;
			case ItemEnum.WEAPONeItemIndex.Star3_1_ItemSword:
				findKey = "���� ��";
				break;
			case ItemEnum.WEAPONeItemIndex.Star3_2_ItemGreatSword:
				findKey = "���� ���";
				break;
			case ItemEnum.WEAPONeItemIndex.Star3_3_ItemSpear:
				findKey = "���� â";
				break;
			case ItemEnum.WEAPONeItemIndex.Star3_4_ItemBow:
				findKey = "���� Ȱ";
				break;
			case ItemEnum.WEAPONeItemIndex.Star3_5_ItemCatalyst:
				findKey = "���� ����";
				break;
			case ItemEnum.WEAPONeItemIndex.Star4_1_ItemSword:
				findKey = "���� ��";
				break;
			case ItemEnum.WEAPONeItemIndex.Star4_2_ItemGreatSword:
				findKey = "���� ���";
				break;
			case ItemEnum.WEAPONeItemIndex.Star4_3_ItemSpear:
				findKey = "���� Ī";
				break;
			case ItemEnum.WEAPONeItemIndex.Star4_4_ItemBow:
				findKey = "���� Ȱ";
				break;
			case ItemEnum.WEAPONeItemIndex.Star4_5_ItemCatalyst:
				findKey = "���� ����";
				break;
			case ItemEnum.WEAPONeItemIndex.Star5_1_ItemSword:
				findKey = "ȭ�� ��";
				break;
			case ItemEnum.WEAPONeItemIndex.Star5_2_ItemGreatSword:
				findKey = "�� ���";
				break;
			case ItemEnum.WEAPONeItemIndex.Star5_3_ItemSpear:
				findKey = "���� â";
				break;
			case ItemEnum.WEAPONeItemIndex.Star5_4_ItemBow:
				findKey = "Ǯ Ȱ";
				break;
			case ItemEnum.WEAPONeItemIndex.Star5_5_ItemCatalyst:
				findKey = "���� ����";
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
				findKey = "�⺻ ��";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Feather:
				findKey = "�⺻ ����";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Hourglass:
				findKey = "�⺻ �𷡽ð�";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Glass:
				findKey = "�⺻ ��";
				break;
			case ItemEnum.EQUIPMENTINDEX.Star1_Crown:
				findKey = "�⺻ �հ�";
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

	public void GetFoodTable(ItemEnum.FOODeItemIndex _index, out ItemFood _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.FOODeItemIndex.Star1_BaseMeat:
				findKey = "����";
				break;
			case ItemEnum.FOODeItemIndex.Star1_BaseWater:
				findKey = "��";
				break;
			case ItemEnum.FOODeItemIndex.Star1_H_CookMeat:
				findKey = "���� ����";
				break;
			case ItemEnum.FOODeItemIndex.Star1_R_CornSoup:
				findKey = "������ ����";
				break;
			case ItemEnum.FOODeItemIndex.Star1_AB_EnergyBar:
				findKey = "��������";
				break;
			case ItemEnum.FOODeItemIndex.Star1_SB_CanFood:
				findKey = "������";
				break;
			case ItemEnum.FOODeItemIndex.Star1_LB_S_SportDrink:
				findKey = "������ ����";
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

	public void GetQuestTable(ItemEnum.QUESTeItemIndex _index, out ItemQuest _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.QUESTeItemIndex.Star1_SpearManEqupit:
				findKey = "������ ����";
				break;
			case ItemEnum.QUESTeItemIndex.Star1_CubeEnterTicket:
				findKey = "���Ա�";
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

	public void GetGoodsTable(ItemEnum.GOODSeItemIndex _index, out ItemGoods _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.GOODSeItemIndex.GameCrystal:
				findKey = "";
				break;
			case ItemEnum.GOODSeItemIndex.CashCrystal:
				findKey = "";
				break;
			case ItemEnum.GOODSeItemIndex.Special_Ticket:
				findKey = "";
				break;
			case ItemEnum.GOODSeItemIndex.Normal_Ticket:
				findKey = "";
				break;
			case ItemEnum.GOODSeItemIndex.Character_Exp_Item_Base:
				findKey = "";
				break;
			case ItemEnum.GOODSeItemIndex.Weapon_Exp_Item_Base:
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
	public void GetReadTable(ItemEnum.READeItemIndex _index, out ItemRead _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.READeItemIndex.Star1_1_OldPage:
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
	public void GetSpecialTable(ItemEnum.SPECIALeItemIndex _index, out ItemSpecial _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.SPECIALeItemIndex.Star5_TutorialClear:
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