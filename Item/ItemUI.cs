using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static ItemEnum;

public class ItemUI : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI itemName;

	public void Init(WEAPONINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetWeapon(_index);
		switch (_index)
		{
			case WEAPONINDEX.Star1_1_ItemSword:
				itemName.text = "≥ÏΩº ∞À";
				break;
			case WEAPONINDEX.Star1_2_ItemGreatSword:
				itemName.text = "≥ÏΩº ¥Î∞À";
				break;
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
			default:
				break;
		}
	}

	public void Init(EQUIPTMENTINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetEquipt(_index);
		switch (_index)
		{
			case EQUIPTMENTINDEX.Star1_Flower:
				itemName.text = "≥ÏΩº πÊ∆–";
				break;
			case EQUIPTMENTINDEX.Star1_Feather:
				itemName.text = "πÊ∆–";
				break;
			case EQUIPTMENTINDEX.Star1_Hourglass:
				break;
			case EQUIPTMENTINDEX.Star1_Glass:
				break;
			case EQUIPTMENTINDEX.Star1_Crown:
				break;
			default:
				break;
		}
	}

	public void Init(FOODINDEX _index)
	{
		image.sprite = ItemImage.Instance.GetFood(_index);
		switch (_index)
		{
			case FOODINDEX.Star1_BaseMeat:
				itemName.text = "∞Ì±‚¡∂∞¢";
				break;
			case FOODINDEX.Star1_BaseWater:
				itemName.text = "π∞";
				break;
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
			default:
				break;
		}
	}
}