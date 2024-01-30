using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsWeapon : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconWeapon> iconList;
	[SerializeField] private List<ItemWeapon> itemList;

	public ItemInfo info;


	public void Init(ref List<ItemWeapon> itemList)
	{
		this.itemList = itemList;
		if (iconList == null)
			iconList = new List<IconWeapon>();
	}


	public void Refresh()
	{
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
				IconWeapon newicon = Instantiate(prefabIcon, transform).GetComponent<IconWeapon>();
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
