using UnityEngine;

using static ItemEnum;

public class ItemImage : SingleTon<ItemImage>
{
	[SerializeField] private Sprite[] weaponItem;
	[SerializeField] private Sprite[] equipItem;
	[SerializeField] private Sprite[] foodItem;
	[SerializeField] private Sprite[] questItem;
	[SerializeField] private Sprite[] goodsItem;
	[SerializeField] private Sprite[] readItem;
	[SerializeField] private Sprite[] specialItem;


	public Sprite GetItemImage(ITEMINDEX _index, int _subIndex)
	{

		switch (_index)
		{
			case ITEMINDEX.Weapon:
				if (weaponItem.Length >= _subIndex) return null;
				return weaponItem[_subIndex];
			case ITEMINDEX.Equipment:
				if (equipItem.Length >= _subIndex) return null;
				return equipItem[_subIndex];
			case ITEMINDEX.Food:
				if (foodItem.Length >= _subIndex) return null;
				return foodItem[_subIndex];
			case ITEMINDEX.Quest:
				if (questItem.Length >= _subIndex) return null;
				return questItem[_subIndex];
			case ITEMINDEX.Goods:
				if (goodsItem.Length >= _subIndex) return null;
				return goodsItem[_subIndex];
			case ITEMINDEX.Read:
				if (readItem.Length >= _subIndex) return null;
				return readItem[_subIndex];
			case ITEMINDEX.Special:
				if (specialItem.Length >= _subIndex) return null;
				return specialItem[_subIndex];
				break;
				//case ITEMINDEX.Max:
				//	break;
				//case ITEMINDEX.Min:
				//	break;
				//default:
				//	break;
		}
		return null;
	}

	public Sprite GetWeapon(WEAPONITEMINDEX _index)
	{
		switch (_index)
		{
			case WEAPONITEMINDEX.Star1_1_ItemSword: return weaponItem[0];
			case WEAPONITEMINDEX.Star1_2_ItemGreatSword: return weaponItem[1];
			case WEAPONITEMINDEX.Star1_3_ItemSpear: return weaponItem[2];
			case WEAPONITEMINDEX.Star1_4_ItemBow: return weaponItem[3];
			case WEAPONITEMINDEX.Star1_5_ItemCatalyst: return weaponItem[4];


			case WEAPONITEMINDEX.Star2_1_ItemSword: return weaponItem[5];
			case WEAPONITEMINDEX.Star2_2_ItemGreatSword: return weaponItem[6];
			case WEAPONITEMINDEX.Star2_3_ItemSpear: return weaponItem[7];
			case WEAPONITEMINDEX.Star2_4_ItemBow: return weaponItem[8];
			case WEAPONITEMINDEX.Star2_5_ItemCatalyst: return weaponItem[9];

			case WEAPONITEMINDEX.Star3_1_ItemSword: return weaponItem[10];
			case WEAPONITEMINDEX.Star3_2_ItemGreatSword: return weaponItem[11];
			case WEAPONITEMINDEX.Star3_3_ItemSpear: return weaponItem[12];
			case WEAPONITEMINDEX.Star3_4_ItemBow: return weaponItem[13];
			case WEAPONITEMINDEX.Star3_5_ItemCatalyst: return weaponItem[14];

			case WEAPONITEMINDEX.Star4_1_ItemSword: return weaponItem[15];
			case WEAPONITEMINDEX.Star4_2_ItemGreatSword: return weaponItem[16];
			case WEAPONITEMINDEX.Star4_3_ItemSpear: return weaponItem[17];
			case WEAPONITEMINDEX.Star4_4_ItemBow: return weaponItem[18];
			case WEAPONITEMINDEX.Star4_5_ItemCatalyst: return weaponItem[18];

			case WEAPONITEMINDEX.Star5_1_ItemSword: return weaponItem[19];
			case WEAPONITEMINDEX.Star5_2_ItemGreatSword: return weaponItem[20];
			case WEAPONITEMINDEX.Star5_3_ItemSpear: return weaponItem[21];
			case WEAPONITEMINDEX.Star5_4_ItemBow: return weaponItem[22];
			case WEAPONITEMINDEX.Star5_5_ItemCatalyst: return weaponItem[23];

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

	public Sprite GetFood(FOODITEMINDEX _index)
	{
		switch (_index)
		{
			case FOODITEMINDEX.Star1_BaseMeat: return foodItem[0];
			case FOODITEMINDEX.Star1_BaseWater: return foodItem[1];
			case FOODITEMINDEX.Star1_H_CookMeat: return foodItem[2];
			case FOODITEMINDEX.Star1_R_CornSoup: return foodItem[3];
			case FOODITEMINDEX.Star1_AB_EnergyBar: return foodItem[4];
			case FOODITEMINDEX.Star1_SB_CanFood: return foodItem[5];
			case FOODITEMINDEX.Star1_LB_S_SportDrink: return foodItem[6];
		}
		return null;
	}

	public Sprite GetQuest(QUESTITEMINDEX _index)
	{
		switch (_index)
		{
			case QUESTITEMINDEX.Star1_SpearManEqupit: return questItem[0];
			default:
				break;
		}
		return null;
	}

	public Sprite GetGoods(GOODSITEMINDEX _index)
	{
		switch (_index)
		{
			case GOODSITEMINDEX.GameCrystal: return goodsItem[0];
			case GOODSITEMINDEX.CashCrystal: return goodsItem[1];
			case GOODSITEMINDEX.Special_Ticket: return goodsItem[2];
			case GOODSITEMINDEX.Normal_Ticket: return goodsItem[3];
			case GOODSITEMINDEX.Character_Exp_Item_Base: return goodsItem[4];
			case GOODSITEMINDEX.Weapon_Exp_Item_Base: return goodsItem[5];
			default:
				break;
		}
		return null;
	}


	public Sprite GetRead(READITEMINDEX _index)
	{
		switch (_index)
		{
			case READITEMINDEX.Star1_1_OldPage: return readItem[0];

			default:
				break;
		}
		return null;
	}

	public Sprite GetSpecial(SPECIALITEMINDEX _index)
	{
		switch (_index)
		{
			case SPECIALITEMINDEX.Star5_TutorialClear: return specialItem[0];

			default:
				break;
		}
		return null;

	}
}