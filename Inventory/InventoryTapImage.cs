using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryTapImage : MonoBehaviour
{
	[SerializeField] private Image iconNormal;
	[SerializeField] private Image iconFocus;

	[SerializeField] private Image focus;
	[SerializeField] private Image nofify;

	public void Select()
	{
		iconNormal.gameObject.SetActive(false);
		iconFocus.gameObject.SetActive(true);

		focus.gameObject.SetActive(true);
		nofify.gameObject.SetActive(false);
	}

	public void UnSelect()
	{
		iconNormal.gameObject.SetActive(true);
		iconFocus.gameObject.SetActive(false);

		focus.gameObject.SetActive(false);
		nofify.gameObject.SetActive(false);
	}

	public void NewItem()
	{
		//iconNormal.gameObject.SetActive(false);
		//iconFocus.gameObject.SetActive(false);

		//focus.gameObject.SetActive(false);
		nofify.gameObject.SetActive(true);
	}
}