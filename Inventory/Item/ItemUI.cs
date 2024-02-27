using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static ItemEnum;

public class ItemUI : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private TextMeshProUGUI itemName;

	public void Init(WEAPONeItemIndex _index)
	{
		image.sprite = ItemImage.Instance.GetWeapon(_index);
		switch (_index)
		{
			case WEAPONeItemIndex.Star1_1_ItemSword:
				itemName.text = "≥ÏΩº ∞À";
				break;
			case WEAPONeItemIndex.Star1_2_ItemGreatSword:
				itemName.text = "≥ÏΩº ¥Î∞À";
				break;
			//case WEAPONeItemIndex.Star1_3_ItemSpear:
			//	break;
			//case WEAPONeItemIndex.Star1_4_ItemBow:
			//	break;
			//case WEAPONeItemIndex.Star1_5_ItemCatalyst:
			//	break;
			//case WEAPONeItemIndex.Star2_1_ItemSword:
			//	break;
			//case WEAPONeItemIndex.Star2_2_ItemGreatSword:
			//	break;
			//case WEAPONeItemIndex.Star2_3_ItemSpear:
			//	break;
			//case WEAPONeItemIndex.Star2_4_ItemBow:
			//	break;
			//case WEAPONeItemIndex.Star2_5_ItemCatalyst:
			//	break;
			//case WEAPONeItemIndex.Star3_1_ItemSword:
			//	break;
			//case WEAPONeItemIndex.Star3_2_ItemGreatSword:
			//	break;
			//case WEAPONeItemIndex.Star3_3_ItemSpear:
			//	break;
			//case WEAPONeItemIndex.Star3_4_ItemBow:
			//	break;
			//case WEAPONeItemIndex.Star3_5_ItemCatalyst:
			//	break;
			//case WEAPONeItemIndex.Star4_1_ItemSword:
			//	break;
			//case WEAPONeItemIndex.Star4_2_ItemGreatSword:
			//	break;
			//case WEAPONeItemIndex.Star4_3_ItemSpear:
			//	break;
			//case WEAPONeItemIndex.Star4_4_ItemBow:
			//	break;
			//case WEAPONeItemIndex.Star4_5_ItemCatalyst:
			//	break;
			//case WEAPONeItemIndex.Star5_1_ItemSword:
			//	break;
			//case WEAPONeItemIndex.Star5_2_ItemGreatSword:
			//	break;
			//case WEAPONeItemIndex.Star5_3_ItemSpear:
			//	break;
			//case WEAPONeItemIndex.Star5_4_ItemBow:
			//	break;
			//case WEAPONeItemIndex.Star5_5_ItemCatalyst:
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

	public void Init(FOODeItemIndex _index)
	{
		image.sprite = ItemImage.Instance.GetFood(_index);
		switch (_index)
		{
			case FOODeItemIndex.Star1_BaseMeat:
				itemName.text = "∞Ì±‚¡∂∞¢";
				break;
			case FOODeItemIndex.Star1_BaseWater:
				itemName.text = "π∞";
				break;
			//case FOODeItemIndex.Star1_H_CookMeat:
			//	break;
			//case FOODeItemIndex.Star1_R_CornSoup:
			//	break;
			//case FOODeItemIndex.Star1_AB_EnergyBar:
			//	break;
			//case FOODeItemIndex.Star1_SB_CanFood:
			//	break;
			//case FOODeItemIndex.Star1_LB_S_SportDrink:
			//	break;
			default:
				break;
		}
	}
}