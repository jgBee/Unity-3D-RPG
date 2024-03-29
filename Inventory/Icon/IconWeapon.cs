using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IconWeapon : MonoBehaviour
{
	int slotNumber;

	[SerializeField] private Image iconImage;
	[SerializeField] private GameObject[] star;
	[SerializeField] private Image iconNew;
	[SerializeField] private Image iconLock;
	//[SerializeField] private Image iconChar;
	[SerializeField] private Image iconFavorit;
	[SerializeField] private GameObject CheckObject;
	[SerializeField] private TextMeshProUGUI levelText;

	private UnityAction selectAction;

	[SerializeField] private ItemInfo info;

	private ItemWeapon select;

	public void Init(int selectNumber, ref ItemInfo info)
	{
		slotNumber = selectNumber;
		this.info = info;
		iconLock.enabled = false;
		iconNew.enabled = true;
		iconFavorit.enabled = false;
		CheckObject.SetActive(false);
		levelText.text = "Lv.1";
		foreach (GameObject item in star)
		{
			item.SetActive(false);
		}

	}

	public void OnClick()
	{
		if( info.gameObject.activeSelf == false)
		{
			info.gameObject.SetActive(true);
			info.OpenWeapon(ref select);
		}
		else
		{
			info.gameObject.SetActive(false);
		}

	}

	public void Refresh(ItemWeapon item)
	{
		iconImage.sprite = item.ItemSprite;
		iconNew.gameObject.SetActive(item.New);
		iconLock.gameObject.SetActive(item.Lock);
		iconFavorit.gameObject.SetActive(item.Favorit);

		levelText.text = item.Level.ToString();


		for (int i = 0; i < star.Length; i++)
		{
			if (i <item.Star )
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