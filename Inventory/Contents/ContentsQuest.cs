using System.Collections.Generic;
using UnityEngine;

public class ContentsQuest : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconQuest> iconList;

	public ItemInfo info;
	private void Awake()
	{
		iconList = new List<IconQuest>();
	}

	public void Refresh(ref ItemInfo info)
	{
		List<ItemQuest> itemList = Inventory.Instance.ItemQuestList;

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
				IconQuest newicon = Instantiate(prefabIcon, transform).GetComponent<IconQuest>();
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
