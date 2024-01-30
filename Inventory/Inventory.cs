using UnityEngine;
using TMPro;
using UnityEngine.UI;


using static ItemEnum;
using System.Collections.Generic;
using UnityEditor;

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
	[SerializeField]private List<ItemEquipment> itemEquiptList;
	[SerializeField]private List<ItemFood> itemFoodList;
	[SerializeField]private List<ItemQuest> itemQuestList;
	[SerializeField]private List<ItemGoods> itemGoodsList;
	[SerializeField]private List<ItemRead> itemReadList;
	[SerializeField]private List<ItemSpecial> itemSpecialList;

	private void Awake()
	{
		itemWeaponList = new List<ItemWeapon>();
		itemEquiptList = new List<ItemEquipment>();
		itemFoodList = new List<ItemFood>();
		itemQuestList = new List<ItemQuest>();
		itemGoodsList = new List<ItemGoods>();
		itemReadList = new List<ItemRead>();
		itemSpecialList = new List<ItemSpecial>();
	}

	private void Start()
	{
		// 테스트목적
		InitRight();
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

	public void InitRight()
	{
		rightItemList.Init(ref itemWeaponList);
	}

	public bool WeaponItemIn(WEAPONITEMINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemReadList.Count >= itemReadMax) return false;

		// 아이템 생성
		ItemWeapon itemData = null;
		Itemtable.Instance.GetWeaponTable(_index, out itemData);
		itemWeaponList.Add(itemData);

		rightItemList.RefreshWeapon();

		return true;
	}

	public bool EquiptItemIn(EQUIPMENTINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemEquiptList.Count >= itemEquiptmentMax) return false;

		// 아이템 생성
		ItemEquipment itemData = null;
		Itemtable.Instance.GetEquiptTable(_index, out itemData);
		itemEquiptList.Add(itemData);

		rightItemList.RefreshEquip();

		return true;
	}

	public bool FoodItemIn(FOODITEMINDEX _index, int _addValue = 1)
	{
		// 1. 아이템 추가가 가능한지 체크
		foreach (var item in itemFoodList)
		{
			if(true)
			{

			}
		}

		// 2. 슬롯 체크 
		if (itemFoodList.Count >= itemFoodMax) return false;

		// 아이템 생성
		ItemFood itemData = null;
		Itemtable.Instance.GetFoodTable(_index, out itemData);
		itemFoodList.Add(itemData);

		rightItemList.RefreshFood();

		return true;
	}

	public bool QuestItemIn(QUESTITEMINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemQuestList.Count >= itemQuestMax) return false;

		// 아이템 생성
		ItemQuest itemData = null;
		Itemtable.Instance.GetQuestTable(_index, out itemData);
		itemQuestList.Add(itemData);

		rightItemList.RefreshQuest();

		return true;
	}

	public bool GoodsItemIn(GOODSITEMINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemGoodsList.Count >= itemGoodsMax) return false;

		// 아이템 생성
		ItemGoods itemData = null;
		Itemtable.Instance.GetGoodsTable(_index, out itemData);
		itemGoodsList.Add(itemData);

		rightItemList.RefreshGoods();

		return true;
	}

	public bool ReadItemIn(READITEMINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemReadList.Count >= itemReadMax) return false;

		// 아이템 생성
		ItemRead itemData = null;
		Itemtable.Instance.GetReadTable(_index, out itemData);
		itemReadList.Add(itemData);

		rightItemList.RefreshRead();

		return true;
	}

	public bool SpecialItemIn(SPECIALITEMINDEX _index)
	{
		// 1. 슬롯 체크
		if (itemSpecialList.Count >= itemSpecialMax) return false;

		//result = rightItemList.SpecialItemAdd(_index);

		// 아이템 생성
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