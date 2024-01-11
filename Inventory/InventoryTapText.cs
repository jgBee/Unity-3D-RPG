using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryTapText : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI tmp;
	[SerializeField] private Image Focus;

	[SerializeField] private Color selectColor;
	[SerializeField] private Color unSelectColor;

	public void Select()
	{
		Focus.gameObject.SetActive(true);
		tmp.color = selectColor;
	}

	public void UnSelect()
	{
		Focus.gameObject.SetActive(false);
		tmp.color = unSelectColor;
	}
}