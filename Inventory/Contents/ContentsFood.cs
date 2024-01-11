using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsFood : MonoBehaviour
{
	public GameObject prefabItem;

	public List<ItemFood> foodList;

	private int slotMax;
	[SerializeField] private int createCount = 0;
	[SerializeField] private int selectNumber = -1;
	public ItemInfo info;
	public void Init(int _maxSlot)
	{
		slotMax = _maxSlot;
		if (foodList == null)
			foodList = new List<ItemFood>();

	}

	public bool AddItem(FOODINDEX _index, int _addValue)
	{
		if (foodList == null) return false;

		// �Һ�
		// �Һ�� �������� ������ ī��Ʈ�� ����

		for (int i = 0; i < foodList.Count; i++)
		{
			if (foodList[i].Type == _index)
			{
				if (foodList[i].CheckItemIn(_addValue))
				{
					foodList[i].Count += _addValue;
					return true;
				}
				else
				{
					if (foodList.Count < slotMax) continue;
					else
					{
						// �κ��丮 Ǯ
						return false;
					}
				}
			}
		}

		if (foodList.Count< slotMax)
		{
			ItemFood obj = Instantiate(prefabItem).GetComponent<ItemFood>();
			obj.transform.parent = transform;
			obj.Init(_index, createCount, delegate () { selectNumber = obj.SlotNumber; if (info != null) info.ItemFoodView(ref obj); });
			obj.transform.localScale = new Vector3(1, 1, 1);
			foodList.Add(obj);

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
