using UnityEngine;
using static ItemEnum;


public class InventoryRightItemList : MonoBehaviour
{
	[SerializeField] private InventoryTapText tapAll;
	[SerializeField] private InventoryTapImage[] tapImages;

	[SerializeField] private GameObject[] contents;


	public void SelectNull()
	{
		contents[1].GetComponent<ContentsWeapon>().SelectNull();
		contents[2].GetComponent<ContentsEquiptment>().SelectNull();

	}

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

	public void Init(int _maxWeapon,int _maxEquipt,int _maxFood)
	{
		contents[1].GetComponent<ContentsWeapon>().Init(_maxWeapon);
		contents[2].GetComponent<ContentsEquiptment>().Init(_maxEquipt);
		contents[3].GetComponent<ContentsFood>().Init(_maxFood);


	}

	public void OnWeapon()
	{
		tapAll.UnSelect();
		foreach (InventoryTapImage item in tapImages)
		{
			item.UnSelect();
		}
		tapImages[0].Select();

		foreach (GameObject item in contents)
		{
			item.SetActive(false);
		}
		contents[1].SetActive(true);
	}
	public bool WeaponItemAdd(WEAPONITEMINDEX _index)
	{
		return contents[1].GetComponent<ContentsWeapon>().AddItem(_index);
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


	public bool EquiptItemAdd(EQUIPTMENTINDEX _index)
	{
		return contents[2].GetComponent<ContentsEquiptment>().AddItem(_index);
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

	public bool FoodItemAdd(FOODITEMINDEX _index, int _addValue)
	{
		return contents[3].GetComponent<ContentsFood>().AddItem(_index, _addValue);
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
	#endregion
}