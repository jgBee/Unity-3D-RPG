using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconSpecial : MonoBehaviour
{
	int slotNumber;

	[SerializeField] private Image iconImage;
	[SerializeField] private GameObject[] star;
	[SerializeField] private Image iconNew;
	[SerializeField] private Image iconFavorit;
	[SerializeField] private GameObject CheckObject;
	[SerializeField] private TextMeshProUGUI levelText;

	[SerializeField] private ItemInfo info;

	private ItemSpecial select;

	public void Init(int selectNumber, ref ItemInfo info)
	{
		slotNumber = selectNumber;
		this.info = info;
	}

	public void OnClick()
	{
		if (info.gameObject.activeSelf == false)
		{
			info.gameObject.SetActive(true);
			info.OpenSpecial(ref select);
		}
		else
		{
			info.gameObject.SetActive(false);
		}
	}

	public void Refresh(ItemSpecial item)
	{
		iconImage.sprite = item.ItemSprite;
		iconNew.gameObject.SetActive(item.Notify);


		for (int i = 0; i < star.Length; i++)
		{
			if (i < item.Star)
			{
				star[i].gameObject.SetActive(true);
			}
			else
			{
				star[i].gameObject.SetActive(false);
			}
		}
		select = item;
	}
}
