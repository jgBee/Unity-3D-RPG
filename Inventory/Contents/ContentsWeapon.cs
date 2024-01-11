using UnityEngine;
using System.Collections.Generic;

using static ItemEnum;

public class ContentsWeapon : MonoBehaviour
{
	public GameObject prefabItemWeapon;

	public List<ItemWeapon> weaponList;

	public ItemInfo info;


	private int slotMax;

	[SerializeField] private int createCount = 0;
	[SerializeField] private int selectNumber = -1;

	public void Init(int _maxSlot)
	{
		slotMax = _maxSlot;
		if (weaponList == null)
			weaponList = new List<ItemWeapon>();

	}

	public bool AddItem(WEAPONINDEX _index)
	{
		if (weaponList == null) return false;

		// 장비는 조건없이 추가
		if (weaponList.Count < slotMax)
		{
			ItemWeapon obj = Instantiate(prefabItemWeapon).GetComponent<ItemWeapon>();
			obj.transform.parent = transform;
			obj.Init(_index, createCount, delegate () { selectNumber = obj.SlotNumber; if (info != null) info.ItemWeaponView(ref obj); });
			createCount++;
			obj.transform.localScale = new Vector3(1, 1, 1);
			weaponList.Add(obj);

			return true;
		}
		else
		{
			return false;
		}
	}

	public void SelectNull()
	{
		selectNumber = -1;
	}
}