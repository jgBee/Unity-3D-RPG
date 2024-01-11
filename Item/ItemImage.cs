using TMPro;
using UnityEngine;

using static ItemEnum;

public class ItemImage : SingleTon<ItemImage>
{
	[SerializeField] private Sprite[] WeaponItem;
	[SerializeField] private Sprite[] equiptItem;
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
				if (WeaponItem.Length >= _subIndex) return null;
				return WeaponItem[_subIndex];
			case ITEMINDEX.Equiptment:
				if (equiptItem.Length >= _subIndex) return null;
				return equiptItem[_subIndex];
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

	public Sprite GetWeapon(WEAPONINDEX _index)
	{
		switch (_index)
		{
			case WEAPONINDEX.Star1_1_ItemSword: return WeaponItem[0];
			case WEAPONINDEX.Star1_2_ItemGreatSword: return WeaponItem[1];

				//case WEAPONINDEX.Star1_3_ItemSpear:
				//	break;
				//case WEAPONINDEX.Star1_4_ItemBow:
				//	break;
				//case WEAPONINDEX.Star1_5_ItemCatalyst:
				//	break;
				//case WEAPONINDEX.Star2_1_ItemSword:
				//	break;
				//case WEAPONINDEX.Star2_2_ItemGreatSword:
				//	break;
				//case WEAPONINDEX.Star2_3_ItemSpear:
				//	break;
				//case WEAPONINDEX.Star2_4_ItemBow:
				//	break;
				//case WEAPONINDEX.Star2_5_ItemCatalyst:
				//	break;
				//case WEAPONINDEX.Star3_1_ItemSword:
				//	break;
				//case WEAPONINDEX.Star3_2_ItemGreatSword:
				//	break;
				//case WEAPONINDEX.Star3_3_ItemSpear:
				//	break;
				//case WEAPONINDEX.Star3_4_ItemBow:
				//	break;
				//case WEAPONINDEX.Star3_5_ItemCatalyst:
				//	break;
				//case WEAPONINDEX.Star4_1_ItemSword:
				//	break;
				//case WEAPONINDEX.Star4_2_ItemGreatSword:
				//	break;
				//case WEAPONINDEX.Star4_3_ItemSpear:
				//	break;
				//case WEAPONINDEX.Star4_4_ItemBow:
				//	break;
				//case WEAPONINDEX.Star4_5_ItemCatalyst:
				//	break;
				//case WEAPONINDEX.Star5_1_ItemSword:
				//	break;
				//case WEAPONINDEX.Star5_2_ItemGreatSword:
				//	break;
				//case WEAPONINDEX.Star5_3_ItemSpear:
				//	break;
				//case WEAPONINDEX.Star5_4_ItemBow:
				//	break;
				//case WEAPONINDEX.Star5_5_ItemCatalyst:
				//	break;
		}
		return null;
	}

	public Sprite GetEquipt(EQUIPTMENTINDEX _index)
	{
		switch (_index)
		{
			case EQUIPTMENTINDEX.Star1_Flower: return equiptItem[0];
			case EQUIPTMENTINDEX.Star1_Feather:return equiptItem[1];
				//case EQUIPTMENTINDEX.Star1_Hourglass:
				//	break;
				//case EQUIPTMENTINDEX.Star1_Glass:
				//	break;
				//case EQUIPTMENTINDEX.Star1_Crown:
				//	break;
		}
		return null;
	}

	public Sprite GetFood(FOODINDEX _index)
	{
		switch (_index)
		{
			case FOODINDEX.Star1_BaseMeat: return foodItem[0];
			case FOODINDEX.Star1_BaseWater: return foodItem[1];
				//case FOODINDEX.Star1_H_CookMeat:
				//	break;
				//case FOODINDEX.Star1_R_CornSoup:
				//	break;
				//case FOODINDEX.Star1_AB_EnergyBar:
				//	break;
				//case FOODINDEX.Star1_SB_CanFood:
				//	break;
				//case FOODINDEX.Star1_LB_S_SportDrink:
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

	public Sprite GetGoods(GOODSINDEX _index)
	{
		switch (_index)
		{
			case GOODSINDEX.Crystal: 
				return goodsItem[0];
			case GOODSINDEX.Special_Ticket:
				return goodsItem[1];
			case GOODSINDEX.Normal_Ticket:
				return goodsItem[2];
			case GOODSINDEX.Character_LevelUp_Item_Base:
				break;
			case GOODSINDEX.Weapon_LevelUp_Item_Base:
				break;
			default:
				break;
		}
		return null;
	}


	public Sprite GetRead(READINDEX _index)
	{
		switch (_index)
		{
			case READINDEX.Star1_1_OldPage:
				return readItem[0];

			default:
				break;
		}
		return null;
	}

	public Sprite GetSpecial(SPECIALINDEX _index)
	{
		switch (_index)
		{
			case SPECIALINDEX.Star5_TutorialClear: 
				return specialItem[0];

			default:
				break;
		}
		return null;
	}
}