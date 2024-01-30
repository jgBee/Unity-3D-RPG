using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static ItemEnum;

public class ItemUI : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI itemName;

	public void Init(WEAPONITEMINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetWeapon(_index);
		switch (_index)
		{
			case WEAPONITEMINDEX.Star1_1_ItemSword:
				itemName.text = "≥ÏΩº ∞À";
				break;
			case WEAPONITEMINDEX.Star1_2_ItemGreatSword:
				itemName.text = "≥ÏΩº ¥Î∞À";
				break;
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
			default:
				break;
		}
	}

	public void Init(EQUIPMENTINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetEquip(_index);
		switch (_index)
		{
			case EQUIPMENTINDEX.Star1_Flower:
				itemName.text = "≥ÏΩº πÊ∆–";
				break;
			case EQUIPMENTINDEX.Star1_Feather:
				itemName.text = "πÊ∆–";
				break;
			case EQUIPMENTINDEX.Star1_Hourglass:
				break;
			case EQUIPMENTINDEX.Star1_Glass:
				break;
			case EQUIPMENTINDEX.Star1_Crown:
				break;
			default:
				break;
		}
	}

	public void Init(FOODITEMINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetFood(_index);
		switch (_index)
		{
			case FOODITEMINDEX.Star1_BaseMeat:
				itemName.text = "∞Ì±‚¡∂∞¢";
				break;
			case FOODITEMINDEX.Star1_BaseWater:
				itemName.text = "π∞";
				break;
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
			default:
				break;
		}
	}
}