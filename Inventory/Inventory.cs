using UnityEngine;
using TMPro;
using UnityEngine.UI;


using static ItemEnum;
using nsItemFood;

using System.Collections.Generic;

public class Inventory : SingleTon<Inventory>
{
	private int gold = 0;
	public int Gold { get { return gold; } set { gold = value; if (goldText != null) goldText.text = gold.ToString(); } }
	private int jewel = 0;
	public int Jewel { get { return jewel; } set { jewel = value; if (jewelText != null) jewelText.text = jewel.ToString(); } }


	public int itemWeaponMax;
	public int itemFoodMax;
	public int itemEquiptmentMax;
	public int itemQuestMax;
	public int itemGoodsMax;
	public int itemReadMax;
	public int itemSpecialMax;


	[SerializeField] private GameObject backObject;

	[Header("Left")]
	[SerializeField] private RawImage charImage;
	[SerializeField] private TextMeshProUGUI name;
	[SerializeField] private TextMeshProUGUI level;
	[SerializeField] private TextMeshProUGUI expPercent;
	[SerializeField] private Slider expGauge;
	[SerializeField] private Slider hpGauge;
	[SerializeField] private Slider attackGauge;
	[SerializeField] private Slider defenceGauge;
	[SerializeField] private ItemInfo itemInfo;

	[Header("Right")]
	[SerializeField] InventoryRightItemList rightItemList;

	[Header("Top")]
	//[SerializeField]TextMeshProUGUI stemina;
	[SerializeField]TextMeshProUGUI jewelText;
	[SerializeField]TextMeshProUGUI goldText;

	[Header("ItemData")]
	[SerializeField]private List<ItemWeapon> itemWeaponList;
	[SerializeField]private List<ItemEquipment> itemEquipList;
	[SerializeField]private List<ItemFood> itemFoodList;
	[SerializeField]private List<ItemQuest> itemQuestList;
	[SerializeField]private List<ItemGoods> itemGoodsList;
	[SerializeField]private List<ItemRead> itemReadList;
	[SerializeField]private List<ItemSpecial> itemSpecialList;

	// GetItemList
	public List<ItemWeapon> ItemWeaponList { get { return itemWeaponList; } }
	public List<ItemEquipment> ItemEquipList { get { return itemEquipList; } }
	public List<ItemFood> ItemFoodList { get { return itemFoodList; } }
	public List<ItemQuest> ItemQuestList { get { return itemQuestList; } }
	public List<ItemGoods> ItemGoodsList { get { return itemGoodsList; } }
	public List<ItemRead> ItemReadList { get { return itemReadList; } }
	public List<ItemSpecial> ItemSpecialList { get { return itemSpecialList; } }

	private void Awake()
	{
		itemWeaponList = new List<ItemWeapon>();
		itemEquipList = new List<ItemEquipment>();
		itemFoodList = new List<ItemFood>();
		itemQuestList = new List<ItemQuest>();
		itemGoodsList = new List<ItemGoods>();
		itemReadList = new List<ItemRead>();
		itemSpecialList = new List<ItemSpecial>();
	}


	public void Active(bool _active)
	{
		backObject.SetActive(_active);
	}

	public void InitLeft(string _name,Texture _texture, int _level, float _expPerValue, float _hpPerValue, float _attackValue, float _defenceValue)
	{
		name.text = _name;
		charImage.texture = _texture;
		level.text = _level.ToString();
		expPercent.text = System.String.Format("{0:0.00}", _expPerValue);
		hpGauge.value = _hpPerValue;
		attackGauge.value = _attackValue;
		defenceGauge.value = _defenceValue;
	}


	public bool WeaponItemIn(WEAPONITEMINDEX _index)
	{
		// 1. ���� üũ
		if (itemReadList.Count >= itemReadMax) return false;

		// ������ ����
		ItemWeapon itemData = null;
		Itemtable.Instance.GetWeaponTable(_index, out itemData);
		itemWeaponList.Add(itemData);

		rightItemList.RefreshWeapon();

		return true;
	}

	public bool EquiptItemIn(EQUIPMENTINDEX _index)
	{
		// 1. ���� üũ
		if (itemEquipList.Count >= itemEquiptmentMax) return false;

		// ������ ����
		ItemEquipment itemData = null;
		Itemtable.Instance.GetEquiptTable(_index, out itemData);
		itemEquipList.Add(itemData);

		rightItemList.RefreshEquip();

		return true;
	}

	public bool FoodItemIn(FOODITEMINDEX _index, int _addValue = 1)
	{
		// 1. ������ �߰��� �������� üũ
		foreach (ItemFood item in itemFoodList)
		{
			if(item.Index == _index && item.InItem(_addValue))
			{
				item.CurrCount += _addValue;
				return true;
			}
			// �ϳ� �� ������ �𸣴� ���⼭ ��� �����ؾ��ϴµ� Ư�� ������ �� �� ����
			// Dictionary<index, >�� ����̿�������?
		}

		// 2. ���� üũ 
		if (itemFoodList.Count >= itemFoodMax) return false;

		// ������ ����
		ItemFood itemData = null;
		Itemtable.Instance.GetFoodTable(_index, out itemData);
		itemFoodList.Add(itemData);

		rightItemList.RefreshFood();

		return true;
	}

	public bool QuestItemIn(QUESTITEMINDEX _index)
	{
		// 1. ���� üũ
		if (itemQuestList.Count >= itemQuestMax) return false;

		// ������ ����
		ItemQuest itemData = null;
		Itemtable.Instance.GetQuestTable(_index, out itemData);
		itemQuestList.Add(itemData);

		rightItemList.RefreshQuest();

		return true;
	}

	public bool GoodsItemIn(GOODSITEMINDEX _index)
	{
		// 1. ���� üũ
		if (itemGoodsList.Count >= itemGoodsMax) return false;

		// ������ ����
		ItemGoods itemData = null;
		Itemtable.Instance.GetGoodsTable(_index, out itemData);
		itemGoodsList.Add(itemData);

		rightItemList.RefreshGoods();

		return true;
	}

	public bool ReadItemIn(READITEMINDEX _index)
	{
		// 1. ���� üũ
		if (itemReadList.Count >= itemReadMax) return false;

		// ������ ����
		ItemRead itemData = null;
		Itemtable.Instance.GetReadTable(_index, out itemData);
		itemReadList.Add(itemData);

		rightItemList.RefreshRead();

		return true;
	}

	public bool SpecialItemIn(SPECIALITEMINDEX _index)
	{
		// 1. ���� üũ
		if (itemSpecialList.Count >= itemSpecialMax) return false;

		//result = rightItemList.SpecialItemAdd(_index);

		// ������ ����
		ItemSpecial itemData = null;
		Itemtable.Instance.GetSpecialTable(_index, out itemData);
		itemSpecialList.Add(itemData);

		rightItemList.RefreshSpecial();

		return true;
	}

	public void SelectNull()
	{
		itemInfo.Active(false);
	}

	public void NotifyCountAdd()
	{

	}

	public void NotifyReset()
	{

	}

}