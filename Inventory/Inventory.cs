using UnityEngine;
using TMPro;
using UnityEngine.UI;


using static ItemEnum;

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
	[SerializeField]private TextMeshProUGUI level;
	[SerializeField]private TextMeshProUGUI expPercent;
	[SerializeField]private Slider expGauge;
	[SerializeField]private Slider hpGauge;
	[SerializeField]private Slider attackGauge;
	[SerializeField]private Slider defenceGauge;
	[SerializeField] private ItemInfo itemInfo;

	[Header("Right")]
	[SerializeField] InventoryRightItemList rightItemList;

	[Header("Top")]
	//[SerializeField]TextMeshProUGUI stemina;
	[SerializeField]TextMeshProUGUI jewelText;
	[SerializeField]TextMeshProUGUI goldText;


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
		rightItemList.Init(itemWeaponMax,itemEquiptmentMax,itemFoodMax);
	}

	public bool WeaponItemIn(WEAPONITEMINDEX _index)
	{
		return rightItemList.WeaponItemAdd(_index);
	}

	public bool EquiptItemIn(EQUIPTMENTINDEX _index)
	{
		return rightItemList.EquiptItemAdd(_index);
	}

	public bool FoodItemIn(FOODITEMINDEX _index, int _addValue = 1)
	{
		return rightItemList.FoodItemAdd(_index, _addValue);
	}

	public void QuestItemIn(QUESTINDEX _index)
	{

	}

	public void GoodsItemIn(GOODSITEMINDEX _index)
	{

	}

	public void ReadItemIn(READITEMINDEX _index)
	{

	}

	public void SpecialItemIn(SPECIALITEMINDEX _index)
	{

	}

	public void SelectNull()
	{
		rightItemList.SelectNull();
		itemInfo.Active(false);
	}

	public void NotifyCountAdd()
	{

	}

	public void NotifyReset()
	{

	}

	#region Test
	public void TestWeapon1()
	{
		WEAPONITEMINDEX randIndex = WEAPONITEMINDEX.Star1_1_ItemSword;
		rightItemList.WeaponItemAdd(randIndex);
	}
	public void TestWeapon2()
	{
		WEAPONITEMINDEX randIndex = WEAPONITEMINDEX.Star1_2_ItemGreatSword;
		rightItemList.WeaponItemAdd(randIndex);
	}

	public void TestEquip1()
	{
		EQUIPTMENTINDEX randIndex = EQUIPTMENTINDEX.Star1_Flower;
		rightItemList.EquiptItemAdd(randIndex);
	}

	public void TestEquip2()
	{
		EQUIPTMENTINDEX randIndex = EQUIPTMENTINDEX.Star1_Feather;
		rightItemList.EquiptItemAdd(randIndex);
	}

	public void TestFood1()
	{
		FOODITEMINDEX randIndex = FOODITEMINDEX.Star1_BaseMeat;
		rightItemList.FoodItemAdd(randIndex,1);
	}


	public void TestFood2()
	{
		FOODITEMINDEX randIndex = FOODITEMINDEX.Star1_BaseWater;
		rightItemList.FoodItemAdd(randIndex,1);
	}
	#endregion
}