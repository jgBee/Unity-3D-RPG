using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsEquiptment : MonoBehaviour
{
	public GameObject prefabItem;

	public List<ItemEquipment> equiptList;


	private int slotMax;
	
	[SerializeField] private int createCount = 0;
	[SerializeField] private int selectNumber = -1;
	public ItemInfo info;

	public void Init(int _maxSlot)
	{
		slotMax = _maxSlot;
		if (equiptList == null)
			equiptList = new List<ItemEquipment>();

	}

	public bool AddItem(EQUIPTMENTINDEX _index)
	{
		if (equiptList == null) return false;

		// 장비는 조건없이 추가
		if (equiptList.Count < slotMax)
		{
			ItemEquipment obj = Instantiate(prefabItem).GetComponent<ItemEquipment>();
			obj.transform.parent = transform;
			obj.Init(_index, createCount, delegate ()
			{ selectNumber = obj.SlotNumber; if (info != null) info.ItemEquiptView(ref obj); });
			createCount++;
			obj.transform.localScale = new Vector3(1, 1, 1);
			equiptList.Add(obj);

			return true;
		}
		else
		{
			return false;
		}
	}

	private void ItemChange(int _select, int _slotNumber)
	{
		
	}

	public void SelectNull()
	{
		selectNumber = -1;
	}

	public void SetSelectItem(ref ItemEquipment _inData)
	{
		Debug.Log(_inData.NameText + "\t" + _inData.SlotNumber);
		if (selectNumber == -1) return;
		_inData = equiptList[selectNumber];
	}

}