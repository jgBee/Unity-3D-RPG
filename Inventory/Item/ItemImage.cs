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
			//case ITEMINDEX.Quest:
			//	break;
			//case ITEMINDEX.Goods:
			//	break;
			//case ITEMINDEX.Read:
			//	break;
			//case ITEMINDEX.Special:
			//	break;
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

				//case WEAPONITEMINDEX.Star1_3_ItemSpear:
				//	break;
				//case WEAPONITEMINDEX.Star1_4_ItemBow:
				//	break;
				//case WEAPONITEMINDEX.Star1_5_ItemCatalyst:
				//	break;
				//case WEAPONITEMINDEX.Star2_1_ItemSword:
				//	break;
				//case WEAPONITEMINDEX.Star2_2_ItemGreatSword:
				//	break;
				//case WEAPONITEMINDEX.Star2_3_ItemSpear:
				//	break;
				//case WEAPONITEMINDEX.Star2_4_ItemBow:
				//	break;
				//case WEAPONITEMINDEX.Star2_5_ItemCatalyst:
				//	break;
				//case WEAPONITEMINDEX.Star3_1_ItemSword:
				//	break;
				//case WEAPONITEMINDEX.Star3_2_ItemGreatSword:
				//	break;
				//case WEAPONITEMINDEX.Star3_3_ItemSpear:
				//	break;
				//case WEAPONITEMINDEX.Star3_4_ItemBow:
				//	break;
				//case WEAPONITEMINDEX.Star3_5_ItemCatalyst:
				//	break;
				//case WEAPONITEMINDEX.Star4_1_ItemSword:
				//	break;
				//case WEAPONITEMINDEX.Star4_2_ItemGreatSword:
				//	break;
				//case WEAPONITEMINDEX.Star4_3_ItemSpear:
				//	break;
				//case WEAPONITEMINDEX.Star4_4_ItemBow:
				//	break;
				//case WEAPONITEMINDEX.Star4_5_ItemCatalyst:
				//	break;
				//case WEAPONITEMINDEX.Star5_1_ItemSword:
				//	break;
				//case WEAPONITEMINDEX.Star5_2_ItemGreatSword:
				//	break;
				//case WEAPONITEMINDEX.Star5_3_ItemSpear:
				//	break;
				//case WEAPONITEMINDEX.Star5_4_ItemBow:
				//	break;
				//case WEAPONITEMINDEX.Star5_5_ItemCatalyst:
				//	break;
		}
		return null;
	}

	public Sprite GetEquip(EQUIPMENTINDEX _index)
	{
		switch (_index)
		{
			case EQUIPMENTINDEX.Star1_Flower: return equipItem[0];
			case EQUIPMENTINDEX.Star1_Feather:return equipItem[1];
				//case EQUIPMENTINDEX.Star1_Hourglass:
				//	break;
				//case EQUIPMENTINDEX.Star1_Glass:
				//	break;
				//case EQUIPMENTINDEX.Star1_Crown:
				//	break;
		}
		return null;
	}

	public Sprite GetFood(FOODITEMINDEX _index)
	{
		switch (_index)
		{
			case FOODITEMINDEX.Star1_BaseMeat: return foodItem[0];
			case FOODITEMINDEX.Star1_BaseWater: return foodItem[1];
				//case FOODITEMINDEX.Star1_H_CookMeat:
				//	break;
				//case FOODITEMINDEX.Star1_R_CornSoup:
				//	break;
				//case FOODITEMINDEX.Star1_AB_EnergyBar:
				//	break;
				//case FOODITEMINDEX.Star1_SB_CanFood:
				//	break;
				//case FOODITEMINDEX.Star1_LB_S_SportDrink:
				//	break;
				//default:
				//	break;
		}
		return null;
	}

	public Sprite GetQuest(QUESTITEMINDEX _index)
	{
		switch (_index)
		{
			case QUESTITEMINDEX.Star1_SpearManEqupit:
				return questItem[0];
			default:
				break;
		}
		return null;
	}

	public Sprite GetGoods(GOODSITEMINDEX _index)
	{
		switch (_index)
		{
			case GOODSITEMINDEX.GameCrystal:
				return goodsItem[0];
			case GOODSITEMINDEX.CashCrystal:
				return goodsItem[1];
			case GOODSITEMINDEX.Special_Ticket:
				return goodsItem[2];
			case GOODSITEMINDEX.Normal_Ticket:
				return goodsItem[3];
			case GOODSITEMINDEX.Character_LevelUp_Item_Base:
				break;
			case GOODSITEMINDEX.Read_LevelUp_Item_Base:
				break;
			default:
				break;
		}
		return null;
	}


	public Sprite GetRead(READITEMINDEX _index)
	{
		switch (_index)
		{
			case READITEMINDEX.Star1_1_OldPage:
				return readItem[0];

			default:
				break;
		}
		return null;
	}

	public Sprite GetSpecial(SPECIALITEMINDEX _index)
	{
		switch (_index)
		{
			case SPECIALITEMINDEX.Star5_TutorialClear: 
				return specialItem[0];

			default:
				break;
		}
		return null;

	}
}