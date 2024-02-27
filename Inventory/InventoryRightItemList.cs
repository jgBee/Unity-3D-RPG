using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;


public class InventoryRightItemList : MonoBehaviour
{
	[SerializeField] private InventoryTapText tapAll;
	[SerializeField] private InventoryTapImage[] tapImages;

	[SerializeField] private GameObject[] contents;

	private enum eSlotIndex : int {All, Weapon, Equipt, Food, Quest, Goods, Read, Special };

	[Header("Inspector")]
	[SerializeField] private ItemInfo info;
	#region ALL
	public void OnAll()
	{
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[0].SetActive(true);
		tapAll.Select();
	}
	#endregion


	#region Weapon
	public void OnWeapon()
	{
		int weaponValue = (int)eSlotIndex.Weapon;
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[weaponValue - 1].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[weaponValue].SetActive(true);
	}

	public void RefreshWeapon()
	{
		int weaponValue = (int)eSlotIndex.Weapon;
		contents[weaponValue].GetComponent<ContentsWeapon>().Refresh(ref info);
	}

	#endregion


	#region Equiptment
	public void OnEquiptment()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[1].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[2].SetActive(true);
	}


	public void RefreshEquip()
	{
		int value = (int)eSlotIndex.Equipt;
		contents[value].GetComponent<ContentsEquipment>().Refresh(ref info);
	}

	#endregion


	#region Food

	public void OnFood()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[2].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[3].SetActive(true);
	}

	public void RefreshFood()
	{
		int value = (int)eSlotIndex.Food;
		contents[value].GetComponent<ContentsFood>().Refresh(ref info);
	}
	#endregion


	#region QuestItem
	public void OnQuest()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[3].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[4].SetActive(true);
	}

	public void RefreshQuest()
	{
		int value = (int)eSlotIndex.Quest;
		contents[value].GetComponent<ContentsFood>().Refresh(ref info);
	}

	#endregion


	#region Goods

	public void OnGoods()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[4].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[5].SetActive(true);
	}
	public void RefreshGoods()
	{
		int value = (int)eSlotIndex.Goods;
		contents[value].GetComponent<ContentsGoods>().Refresh(ref info);
	}
	#endregion


	#region Read
	public void OnRead()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[5].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[6].SetActive(true);
	}

	public void RefreshRead()
	{
		int value = (int)eSlotIndex.Read;
		contents[value].GetComponent<ContentsRead>().Refresh(ref info);
	}

	#endregion


	#region Special
	public void OnSpecial()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[6].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[7].SetActive(true);
	}
	public void RefreshSpecial()
	{
		int value = (int)eSlotIndex.Special;
		contents[value].GetComponent<ContentsSpecial>().Refresh(ref info);
	}
	#endregion
}