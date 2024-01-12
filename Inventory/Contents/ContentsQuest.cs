using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsQuest : MonoBehaviour
{
	public GameObject prefabItem;

	public List<ItemQuest> itemList;


	private int slotMax;

	[SerializeField] private int createCount = 0;
	[SerializeField] private int selectNumber = -1;
	public ItemInfo info;

	public void Init(int _maxSlot)
	{
		slotMax = _maxSlot;
		if (itemList == null)
			itemList = new List<ItemQuest>();

	}

	public bool AddItem(SPECIALITEMINDEX _index)
	{
		if (itemList == null) return false;

		// 장비는 조건없이 추가
		if (itemList.Count < slotMax)
		{
			ItemQuest obj = Instantiate(prefabItem).GetComponent<ItemQuest>();
			obj.transform.parent = transform;
			obj.Init(_index, createCount, delegate ()
			{ selectNumber = obj.SlotNumber; if (info != null) info.ItemQuestView(ref obj); });
			createCount++;
			obj.transform.localScale = new Vector3(1, 1, 1);
			itemList.Add(obj);

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

	public void SetSelectItem(ref ItemQuest _inData)
	{
		//Debug.Log(_inData.NameText + "\t" + _inData.SlotNumber);
		//if (selectNumber == -1) return;
		//_inData = itemList[selectNumber];
	}

}
