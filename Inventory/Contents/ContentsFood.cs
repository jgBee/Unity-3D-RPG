using System.Collections.Generic;
using UnityEngine;

using nsItemFood;

public class ContentsFood : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconFood> iconList;

	public ItemInfo info;

	private void Awake()
	{
		iconList = new List<IconFood>();
	}
	public void Refresh(ref ItemInfo info)
	{
		List<ItemFood> itemList = Inventory.Instance.ItemFoodList;

		int firstFor, secondFor = 0;

		if (itemList.Count < iconList.Count)
		{
			firstFor = itemList.Count;
			secondFor = iconList.Count;
			for (int i = 0; i < firstFor; i++)
			{
				iconList[i].Refresh(itemList[i]);
			}

			// ������ ����
			for (int i = firstFor; i < secondFor; i++)
			{
				Destroy(iconList[i].gameObject);
				iconList.RemoveAt(i);
			}
		}
		else if (itemList.Count > iconList.Count)
		{
			firstFor = iconList.Count;
			secondFor = itemList.Count;
			for (int i = 0; i < firstFor; i++)
			{
				iconList[i].Refresh(itemList[i]);
			}

			// ������ ����
			for (int i = firstFor; i < secondFor; i++)
			{
				IconFood newicon = Instantiate(prefabIcon, transform).GetComponent<IconFood>();
				newicon.transform.parent = transform;
				newicon.Init(i, ref info);
				newicon.Refresh(itemList[i]);
				iconList.Add(newicon);
			}
		}
		else //if(itemList.Count == iconList.Count)
		{
			firstFor = secondFor = iconList.Count;
			for (int i = 0; i < firstFor; i++)
			{
				iconList[i].Refresh(itemList[i]);
			}
		}
	}
}
