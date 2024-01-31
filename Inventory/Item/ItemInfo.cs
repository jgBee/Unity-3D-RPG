using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static ItemEnum;

using nsItemFood;

public class ItemInfo : MonoBehaviour
{
	public Sprite[] typeSprite;
	[Header("Inspector_Top")]
	[SerializeField] Image type;
	[SerializeField] TextMeshProUGUI starNumber;
	[SerializeField] TextMeshProUGUI itemName;
	[SerializeField] Image itemImage;

	[Header("Inspector_Explan")]
	[SerializeField] TextMeshProUGUI mainExplan;
	[SerializeField] TextMeshProUGUI mainExplanDetail;
	[SerializeField] TextMeshProUGUI subExplan;
	[SerializeField] TextMeshProUGUI subExplanDetail;

	[Header("Inspector_Bottom_BtnText")]
	[SerializeField] TextMeshProUGUI btnUse;
	[SerializeField] TextMeshProUGUI btnClose;

	public void Active(bool _active)
	{
		gameObject.SetActive(_active);
	}

	public void OpenWeapon(ref ItemWeapon _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		itemImage.sprite = _item.ItemSprite;
		starNumber.text = _item.Star.ToString();
		itemName.text = _item.MainName;
		mainExplanDetail.text = _item.MainExplan;
		subExplanDetail.text = _item.SubExplan;
	}

	public void OpenEquip(ref ItemEquipment _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		itemImage.sprite = _item.ItemSprite;
		starNumber.text = _item.Star.ToString();
		itemName.text = _item.MainName;
		mainExplanDetail.text = _item.MainExplan;
		subExplanDetail.text = _item.SubExplan;
	}

	public void OpenFood(ref ItemFood _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;
		itemImage.sprite = _item.ItemSprite;
		starNumber.text = _item.Star.ToString();
		itemName.text = _item.MainName;
		mainExplanDetail.text = _item.MainExplan;
		subExplanDetail.text = _item.SubExplan;
	}

	public void OpenQuest(ref ItemQuest _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		//itemName.text = _item.NameText;
		//mainExplanDetail.text = _item.MainExplan;
		//subExplanDetail.text = _item.SubExplan;
	}

	public void OpenGoods(ref ItemGoods _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;



		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		//itemName.text = _item.NameText;
		//mainExplanDetail.text = _item.MainExplan;
		//subExplanDetail.text = _item.SubExplan;

	}

	public void OpenRead(ref ItemRead _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		//itemName.text = _item.NameText;
		//mainExplanDetail.text = _item.MainExplan;
		//subExplanDetail.text = _item.SubExplan;
	}

	public void OpenSpecial(ref ItemSpecial _item)
	{
		if (gameObject.activeSelf == false)
			Active(true);

		if (_item == null) return;

		//itemImage.sprite = _item.ItemSprite;
		//starNumber.text = _item.Star.ToString();
		//itemName.text = _item.NameText;
		//mainExplanDetail.text = _item.MainExplan;
		//subExplanDetail.text = _item.SubExplan;
	}

	public void Close()
	{
		Active(false);
	}


	public void OK()
	{

	}
}