using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsFood : MonoBehaviour
{
	public GameObject prefabItem;

	public List<ItemFood> itemList;

	private int slotMax;
	[SerializeField] private int createCount = 0;
	[SerializeField] private int selectNumber = -1;
	public ItemInfo info;
	public void Init(int _maxSlot)
	{
		slotMax = _maxSlot;
		if (itemList == null)
			itemList = new List<ItemFood>();

	}

	public bool AddItem(FOODITEMINDEX _index, int _addValue)
	{
		if (itemList == null) return false;

		// 소비
		// 소비는 아이템이 있으면 카운트만 증가

		for (int i = 0; i < itemList.Count; i++)
		{
			if (itemList[i].Type == _index)
			{
				if (itemList[i].CheckItemIn(_addValue))
				{
					itemList[i].Count += _addValue;
					return true;
				}
				else
				{
					if (itemList.Count < slotMax) continue;
					else
					{
						// 인벤토리 풀
						return false;
					}
				}
			}
		}

		if (itemList.Count< slotMax)
		{
			ItemFood obj = Instantiate(prefabItem).GetComponent<ItemFood>();
			obj.transform.parent = transform;
			obj.Init(_index, createCount, delegate () { selectNumber = obj.SlotNumber; if (info != null) info.ItemFoodView(ref obj); });
			obj.transform.localScale = new Vector3(1, 1, 1);
			itemList.Add(obj);

			return true;
		}
		else
		{
			return false;
		}
	}

	public bool UseItem()
	{



		return false;
	}
}
