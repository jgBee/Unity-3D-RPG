using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


using static ItemEnum;
using nsItemFood;



//
// 02.05 싱글톤 해제 데이터 매니저 클래스로 생성
public class Inventory : SlngleTonMonobehaviour<Inventory>
{
	private int gold = 0;
	public int Gold { get { return gold; } set { gold = value; if (goldText != null) goldText.text = gold.ToString(); } }
	private int jewel = 0;
	public int Jewel { get { return jewel; } set { jewel = value; if (jewelText != null) jewelText.text = jewel.ToString(); } }


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

	private void Awake()
	{
		
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

	public void Refresh(eItemIndex _index)
	{
		switch (_index)
		{
			case eItemIndex.Weapon:
				rightItemList.RefreshWeapon();
				break;
			case eItemIndex.Equipment:
				rightItemList.RefreshEquip();
				break;
			case eItemIndex.Food:
				rightItemList.RefreshFood();
				break;
			case eItemIndex.Quest:
				rightItemList.RefreshQuest();
				break;
			case eItemIndex.Goods:
				rightItemList.RefreshGoods();
				break;
			case eItemIndex.Read:
				rightItemList.RefreshRead();
				break;
			case eItemIndex.Special:
				rightItemList.RefreshSpecial();
				break;
			default:
				break;
		}
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