using System.Collections.Generic;
using UnityEngine;

public class ContentsRead : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconRead> iconList;

	private void Awake()
	{
		iconList = new List<IconRead>();
	}

	public void Refresh(ref ItemInfo info)
	{
		List<ItemRead> itemList = Inventory.Instance.ItemReadList;

		int firstFor, secondFor = 0;

		if (itemList.Count < iconList.Count)
		{
			firstFor = itemList.Count;
			secondFor = iconList.Count;
			for (int i = 0; i < firstFor; i++)
			{
				iconList[i].Refresh(itemList[i]);
			}

			// 아이템 제거
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

			// 아이템 생성
			for (int i = firstFor; i < secondFor; i++)
			{
				IconRead newicon = Instantiate(prefabIcon, transform).GetComponent<IconRead>();
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
