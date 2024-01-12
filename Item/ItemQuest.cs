using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using static ItemEnum;


public class ItemQuest : MonoBehaviour
{
	#region Data Part
	///========== Data ==========
	public class QuestItemData
	{

	}

	#endregion

	#region Data Part Function


	#endregion
	///==========================



	///========== Icon ==========

	[SerializeField] private Image iconImage;
	[SerializeField] private Image iconNew;
	[SerializeField] private TextMeshProUGUI iconText;


	int slotNumber;
	public int SlotNumber { get { return slotNumber; } }
	private UnityAction actionSetSlotNumber;

	///==========================


	#region Icon Part Function


	#endregion

	public void Init(SPECIALITEMINDEX _index, int _slotNumber,UnityAction _action)
	{
		slotNumber = _slotNumber;
		actionSetSlotNumber = _action;

		iconImage.sprite = ItemImage.Instance.GetSpecial(_index);
	}


	
}