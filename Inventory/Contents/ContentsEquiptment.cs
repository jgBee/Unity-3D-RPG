using System.Collections.Generic;
using UnityEngine;

public class ContentsEquipment : MonoBehaviour
{
	public GameObject prefabIcon;

	[SerializeField] private List<IconEquip> iconList;
	[SerializeField]private ItemInfo info;

	private void Awake()
	{
		iconList = new List<IconEquip>();
	}

	public void Refresh(ref ItemInfo info)
	{
		List<ItemEquipment> itemList = DataManager.Instance.ItemList.ItemEquipList;
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