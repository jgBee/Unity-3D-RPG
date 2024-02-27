using UnityEngine;

using static ItemEnum;

public class ItemImage : SlngleTonMonobehaviour<ItemImage>
{
	[SerializeField] private Sprite[] weaponItem;
	[SerializeField] private Sprite[] equipItem;
	[SerializeField] private Sprite[] foodItem;
	[SerializeField] private Sprite[] questItem;
	[SerializeField] private Sprite[] goodsItem;
	[SerializeField] private Sprite[] readItem;
	[SerializeField] private Sprite[] specialItem;


	public Sprite GetItemImage(eItemIndex _index, int _subIndex)
	{

		switch (_index)
		{
			case eItemIndex.Weapon:
				if (weaponItem.Length >= _subIndex) return null;
				return weaponItem[_subIndex];
			case eItemIndex.Equipment:
				if (equipItem.Length >= _subIndex) return null;
				return equipItem[_subIndex];
			case eItemIndex.Food:
				if (foodItem.Length >= _subIndex) return null;
				return foodItem[_subIndex];
			case eItemIndex.Quest:
				if (questItem.Length >= _subIndex) return null;
				return questItem[_subIndex];
			case eItemIndex.Goods:
				if (goodsItem.Length >= _subIndex) return null;
				return goodsItem[_subIndex];
			case eItemIndex.Read:
				if (readItem.Length >= _subIndex) return null;
				return readItem[_subIndex];
			case eItemIndex.Special:
				if (specialItem.Length >= _subIndex) return null;
				return specialItem[_subIndex];
				break;
				//case eItemIndex.Max:
				//	break;
				//case eItemIndex.Min:
				//	break;
				//default:
				//	break;
		}
		return null;
	}

	public Sprite GetWeapon(WEAPONeItemIndex _index)
	{
		switch (_index)
		{
			case WEAPONeItemIndex.Star1_1_ItemSword: return weaponItem[0];
			case WEAPONeItemIndex.Star1_2_ItemGreatSword: return weaponItem[1];
			case WEAPONeItemIndex.Star1_3_ItemSpear: return weaponItem[2];
			case WEAPONeItemIndex.Star1_4_ItemBow: return weaponItem[3];
			case WEAPONeItemIndex.Star1_5_ItemCatalyst: return weaponItem[4];


			case WEAPONeItemIndex.Star2_1_ItemSword: return weaponItem[5];
			case WEAPONeItemIndex.Star2_2_ItemGreatSword: return weaponItem[6];
			case WEAPONeItemIndex.Star2_3_ItemSpear: return weaponItem[7];
			case WEAPONeItemIndex.Star2_4_ItemBow: return weaponItem[8];
			case WEAPONeItemIndex.Star2_5_ItemCatalyst: return weaponItem[9];

			case WEAPONeItemIndex.Star3_1_ItemSword: return weaponItem[10];
			case WEAPONeItemIndex.Star3_2_ItemGreatSword: return weaponItem[11];
			case WEAPONeItemIndex.Star3_3_ItemSpear: return weaponItem[12];
			case WEAPONeItemIndex.Star3_4_ItemBow: return weaponItem[13];
			case WEAPONeItemIndex.Star3_5_ItemCatalyst: return weaponItem[14];

			case WEAPONeItemIndex.Star4_1_ItemSword: return weaponItem[15];
			case WEAPONeItemIndex.Star4_2_ItemGreatSword: return weaponItem[16];
			case WEAPONeItemIndex.Star4_3_ItemSpear: return weaponItem[17];
			case WEAPONeItemIndex.Star4_4_ItemBow: return weaponItem[18];
			case WEAPONeItemIndex.Star4_5_ItemCatalyst: return weaponItem[18];

			case WEAPONeItemIndex.Star5_1_ItemSword: return weaponItem[19];
			case WEAPONeItemIndex.Star5_2_ItemGreatSword: return weaponItem[20];
			case WEAPONeItemIndex.Star5_3_ItemSpear: return weaponItem[21];
			case WEAPONeItemIndex.Star5_4_ItemBow: return weaponItem[22];
			case WEAPONeItemIndex.Star5_5_ItemCatalyst: return weaponItem[23];

			default:
				return null;

		}
	}

	public Sprite GetEquip(EQUIPMENTINDEX _index)
	{
		switch (_index)
		{
			case EQUIPMENTINDEX.Star1_Flower: return equipItem[0];
			case EQUIPMENTINDEX.Star1_Feather:return equipItem[1];
			case EQUIPMENTINDEX.Star1_Hourglass: return equipItem[2];
			case EQUIPMENTINDEX.Star1_Glass: return equipItem[3];
			case EQUIPMENTINDEX.Star1_Crown: return equipItem[4];
		}
		return null;
	}

	public Sprite GetFood(FOODeItemIndex _index)
	{
		switch (_index)
		{
			case FOODeItemIndex.Star1_BaseMeat: return foodItem[0];
			case FOODeItemIndex.Star1_BaseWater: return foodItem[1];
			case FOODeItemIndex.Star1_H_CookMeat: return foodItem[2];
			case FOODeItemIndex.Star1_R_CornSoup: return foodItem[3];
			case FOODeItemIndex.Star1_AB_EnergyBar: return foodItem[4];
			case FOODeItemIndex.Star1_SB_CanFood: return foodItem[5];
			case FOODeItemIndex.Star1_LB_S_SportDrink: return foodItem[6];
		}
		return null;
	}

	public Sprite GetQuest(QUESTeItemIndex _index)
	{
		switch (_index)
		{
			case QUESTeItemIndex.Star1_SpearManEqupit: return questItem[0];
			default:
				break;
		}
		return null;
	}

	public Sprite GetGoods(GOODSeItemIndex _index)
	{
		switch (_index)
		{
			case GOODSeItemIndex.GameCrystal: return goodsItem[0];
			case GOODSeItemIndex.CashCrystal: return goodsItem[1];
			case GOODSeItemIndex.Special_Ticket: return goodsItem[2];
			case GOODSeItemIndex.Normal_Ticket: return goodsItem[3];
			case GOODSeItemIndex.Character_Exp_Item_Base: return goodsItem[4];
			case GOODSeItemIndex.Weapon_Exp_Item_Base: return goodsItem[5];
			default:
				break;
		}
		return null;
	}


	public Sprite GetRead(READeItemIndex _index)
	{
		switch (_index)
		{
			case READeItemIndex.Star1_1_OldPage: return readItem[0];

			default:
				break;
		}
		return null;
	}

	public Sprite GetSpecial(SPECIALeItemIndex _index)
	{
		switch (_index)
		{
			case SPECIALeItemIndex.Star5_TutorialClear: return specialItem[0];

			default:
				break;
		}
		return null;

	}
}