using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using static ItemEnum;

public class EquiptLineData {
	public EQUIPTMENTOPTION optionIndex;
	public float value;
	public EQUIPTMENTSET set;
}


public class ItemEquipment : MonoBehaviour
{
	public int star;

	private EQUIPTMENTINDEX index;
	EquiptLineData mainOption;


	public int Level;
	public int maxLevel;
	private int exp;
	private int expMax;
	public float ExpPercent => exp / (float)expMax;

	public string itemName;
	public string mainOptionName;
	public string mainOptionExplan;
	public string subExplan;

	public bool bFavorit;

	public UnityEngine.UI.Image itemImage;
	public UnityEngine.UI.Image favoriteImage;

	public TextMeshProUGUI textLevel;

	private UnityAction selectAction;

	int slotNumber;
	public int SlotNumber { get { return slotNumber; } set { slotNumber = value; } }

	public Sprite ItemSprite { get { return itemImage.sprite; } }
	public int Star { get { return star; } }
	public string NameText { get { return itemName; } }
	public string MainExplan { get { return GetMainOptionString(); } }
	public string SubExplan { get { return subExplan; } }
	

	public void Init(EQUIPTMENTINDEX _index, int _slotNumber, UnityAction _selectAction)
	{
		if (mainOption == null) mainOption = new EquiptLineData();
		index = _index;
		slotNumber = _slotNumber;
		if (_selectAction != null) selectAction = _selectAction;
		itemImage.sprite = ItemImage.Instance.GetEquipt(_index);
		BaseDataInit(1);

		switch (_index)
		{
			case EQUIPTMENTINDEX.Star1_Flower:
				itemName = "나무 방패";
				mainOption.optionIndex = EQUIPTMENTOPTION.HPValue;
				mainOption.value = 1;
				mainOption.set = EQUIPTMENTSET.None;
				break;
			case EQUIPTMENTINDEX.Star1_Feather:
				itemName = "일반 방패";
				mainOption.optionIndex = EQUIPTMENTOPTION.AttackValue;
				mainOption.value = 1;
				mainOption.set = EQUIPTMENTSET.None;

				break;
			case EQUIPTMENTINDEX.Star1_Hourglass:
				switch (UnityEngine.Random.Range(0,3))
				{
					case 0:
						mainOption.optionIndex = EQUIPTMENTOPTION.AttackValue;
						break;
					case 1:
						mainOption.optionIndex = EQUIPTMENTOPTION.HPValue;
						break;
					case 2:
						mainOption.optionIndex = EQUIPTMENTOPTION.ShieldValue;
						break;
				}
				mainOption.value = 1;
				mainOption.set = EQUIPTMENTSET.None;

				break;
			case EQUIPTMENTINDEX.Star1_Glass:
				mainOption.optionIndex = EQUIPTMENTOPTION.AttackValue;
				mainOption.value = 1;
				mainOption.set = EQUIPTMENTSET.None;

				break;
			case EQUIPTMENTINDEX.Star1_Crown:
				mainOption.optionIndex = EQUIPTMENTOPTION.AttackValue;
				mainOption.value = 1;
				mainOption.set = EQUIPTMENTSET.None;

				break;
		}
		textLevel.text = "Lv " + Level.ToString();

	}

	private void BaseDataInit(int _n)
	{
		bFavorit = false;

		switch (_n)
		{
			case 1:
				star = 1;
				Level = 1;
				maxLevel = 10;
				exp = 0;
				expMax = 10;
				break;
		}
	}


	private string GetMainOptionString()
	{
		switch (mainOption.optionIndex)
		{
			case EQUIPTMENTOPTION.AttackValue:
				return "공격력 추가 : " + mainOption.value;
			case EQUIPTMENTOPTION.AttackPercent:
				return "공격력 추가 : " + mainOption.value + "%";
			case EQUIPTMENTOPTION.HPValue:
				return "체력 추가 : " + mainOption.value + "%";
			case EQUIPTMENTOPTION.HPPercent:
				return "체력 추가 : " + mainOption.value + "%";
			case EQUIPTMENTOPTION.ShieldValue:
				return "방어력 추가 : " + mainOption.value + "%";
			case EQUIPTMENTOPTION.ShieldPercent:
				return "방어력 추가 : " + mainOption.value + "%";
		}
		return "";
	}

	public void Lock()
	{
		//iconLock.gameObject.SetActive(!iconLock.gameObject.activeSelf);
	}

	public void Click()
	{
		//if (iconLock.gameObject.activeSelf == true) return;

		//if (iconNew.gameObject.activeSelf == true)
		//{
		//	iconNew.gameObject.SetActive(false);
		//	return;
		//}
		if (selectAction != null)
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
			if (exp + remain > +expMax)
			{
				remain -= expMax - exp;
				//LevelUp();
			}
			else
			{
				exp += remain;
				return;
			}
		}
	}


	public static EQUIPTMENTINDEX GetItemIndex(int _value)
	{
		EQUIPTMENTINDEX index = EQUIPTMENTINDEX.Star1_Flower;
		switch (_value)
		{
			case 0:
				index = EQUIPTMENTINDEX.Star1_Flower;
				break;
			case 1:
				index = EQUIPTMENTINDEX.Star1_Feather;
				break;
		}
		return index;
	}

	public static EQUIPTMENTINDEX GetItemRandomIndex()
	{
		int min = 0;
		int max = 2;
		int randValue = UnityEngine.Random.Range(min, max);
		switch (randValue)
		{
			case 0: return EQUIPTMENTINDEX.Star1_Flower;
			case 1: return EQUIPTMENTINDEX.Star1_Feather;
			default:
				return EQUIPTMENTINDEX.Star1_Flower;
		}
	}
}
