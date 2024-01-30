using UnityEngine;
using SimpleJSON;

// �� ��ũ��Ʈ�� �������� ���� ������ ��� ���� �ְ�
// GetReadTable(_index, out Item<T> �Դϴ�)

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

	public void GetWeaponTable(ItemEnum.WEAPONITEMINDEX _index, out ItemWeapon _weapon)
	{

		string findKey = "";
		switch (_index)
		{
			case ItemEnum.WEAPONITEMINDEX.Star1_1_ItemSword:
				findKey = "�콼 ��";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_2_ItemGreatSword:
				findKey = "�콼 ���";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_3_ItemSpear:
				findKey = "�콼 â";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_4_ItemBow:
				findKey = "�콼 Ȱ";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star1_5_ItemCatalyst:
				findKey = "�콼 ����";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_1_ItemSword:
				findKey = "�Ϲ� ��";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_2_ItemGreatSword:
				findKey = "�Ϲ� ���";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_3_ItemSpear:
				findKey = "�Ϲ� â";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_4_ItemBow:
				findKey = "�Ϲ� Ȱ";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star2_5_ItemCatalyst:
				findKey = "�Ϲ� ����";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_1_ItemSword:
				findKey = "���� ��";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_2_ItemGreatSword:
				findKey = "���� ���";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_3_ItemSpear:
				findKey = "���� â";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_4_ItemBow:
				findKey = "���� Ȱ";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star3_5_ItemCatalyst:
				findKey = "���� ����";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_1_ItemSword:
				findKey = "���� ��";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_2_ItemGreatSword:
				findKey = "���� ���";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_3_ItemSpear:
				findKey = "���� Ī";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_4_ItemBow:
				findKey = "���� Ȱ";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star4_5_ItemCatalyst:
				findKey = "���� ����";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_1_ItemSword:
				findKey = "ȭ�� ��";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_2_ItemGreatSword:
				findKey = "�� ���";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_3_ItemSpear:
				findKey = "���� â";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_4_ItemBow:
				findKey = "Ǯ Ȱ";
				break;
			case ItemEnum.WEAPONITEMINDEX.Star5_5_ItemCatalyst:
				findKey = "���� ����";
				break;
			default:
				break;
		}

		_weapon= new ItemWeapon();

		JSONNode targetData = jsonData["Read"][findKey];
		_weapon.Init(_index, targetData["Star"], findKey, 
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
	}

	public void GetFoodTable(ItemEnum.FOODITEMINDEX _index, out ItemFood _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.FOODITEMINDEX.Star1_BaseMeat:
				findKey = "���";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_BaseWater:
				findKey = "��";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_H_CookMeat:
				findKey = "���� ���";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_R_CornSoup:
				findKey = "������ ����";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_AB_EnergyBar:
				findKey = "��������";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_SB_CanFood:
				findKey = "������";
				break;
			case ItemEnum.FOODITEMINDEX.Star1_LB_S_SportDrink:
				findKey = "������ ����";
				break;
			default:
				break;
		}

		_item = new ItemFood();
	}

	public void GetQuestTable(ItemEnum.QUESTITEMINDEX _index, out ItemQuest _item)
	{
		string findKey = "";
		switch (_index)
		{
			case ItemEnum.QUESTITEMINDEX.Star1_SpearManEqupit:
				findKey = "������ ����";
				break;
			case ItemEnum.QUESTITEMINDEX.Star1_CubeEnterTicket:
				findKey = "���Ա�";
				break;
			default:
				break;
		}

		_item = new ItemQuest();
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
			case ItemEnum.GOODSITEMINDEX.Character_LevelUp_Item_Base:
				findKey = "";
				break;
			case ItemEnum.GOODSITEMINDEX.Read_LevelUp_Item_Base:
				findKey = "";
				break;
			default:
				break;
		}

		_item = new ItemGoods();
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
	}
	//Debug.Log(jsonData["Read"]["�콼 â"].ToString());
	//Debug.Log(jsonData["Food"][2]);


	//int rnd = Random.Range(1, jsonData.Count);

	//GameObject character = Instantiate(jsonImage); // ����ž�

	//character.GetComponent<JsonChar>().charname = (jsonData[rnd]["Name"]).ToString();
	//character.transform.name = jsonData[rnd]["Name"].ToString(); // ������Ʈ�� ����

	//character.GetComponent<JsonChar>().charHp = (int)(jsonData[rnd]["HP"]);
	//character.GetComponent<JsonChar>().atk = (int)(jsonData[rnd]["AD"]);
	//character.GetComponent<JsonChar>().faceImage = (jsonData[rnd]["IMAGE"]);

	//Debug.Log(jsonData[rnd]["Name"]);



	// character.transform.SetParent(readyCanvas.transform);

}