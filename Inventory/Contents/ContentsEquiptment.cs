using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemEnum;

public class ContentsEquipment : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconEquip> iconList;
	[SerializeField] private List<ItemEquipment> itemList;

	public ItemInfo info;


	public void Init(ref List<ItemEquipment> EquiptList)
	{
		itemList = EquiptList;
		if (iconList == null)
			iconList = new List<IconEquip>();
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
				IconEquip newicon = Instantiate(prefabIcon, transform).GetComponent<IconEquip>();
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