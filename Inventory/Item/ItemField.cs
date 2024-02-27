using UnityEngine;
using UnityEngine.UI;
using static ItemEnum;

using nsItemFood;

public class ItemField : MonoBehaviour
{
	[SerializeField] Rigidbody rigidbody;
	[SerializeField] private GameObject prefabImage;


	public GameObject PrefabEffect;

	public GameObject[] InTerrainEffects;

	private GameObject createImage;
	private GameObject createEffect;
	public float x;
	public float z;

	GameObject canvas;

	[SerializeField]eItemIndex itemIndex;
	WEAPONeItemIndex weapon;
	EQUIPMENTINDEX equipt;
	FOODeItemIndex food;

	bool bDestroy = false;


	private void Start()
	{
		rigidbody.useGravity = true;
		rigidbody.isKinematic = false;
		x = Random.Range(-1.0f, 1.0f);
		z = Random.Range(-1.0f, 1.0f);
		Vector3 pos = new Vector3(x, 5, z);
		rigidbody.AddForce(pos , ForceMode.VelocityChange);

		canvas= GameObject.Find("StaticCanvas");
		ItemSetting();

	}



	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Terrain")
		{
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
			Destroy(Instantiate(PrefabEffect, transform.position, Quaternion.Euler(new Vector3(-90, 0, 0))), 1.0f);
			switch (itemIndex)
			{
				case eItemIndex.Weapon:
					createEffect = Instantiate(InTerrainEffects[0], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				case eItemIndex.Equipment:
					createEffect = Instantiate(InTerrainEffects[1], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				case eItemIndex.Food:
					createEffect = Instantiate(InTerrainEffects[2], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				//case eItemIndex.Quest:
				//	break;
				//case eItemIndex.Goods:
				//	break;
				//case eItemIndex.Read:
				//	break;
				//case eItemIndex.Special:
				//	break;
				//case eItemIndex.Max:
				//	break;
				//case eItemIndex.Min:
				//	break;
				//default:
				//	break;
			}
			
		}

		if( other.gameObject.tag == "Player")
		{
			if (createImage != null)
			{
				createImage.gameObject.SetActive(true);
			}
			else
			{
				createImage = Instantiate(prefabImage, Vector3.zero, Quaternion.identity);
				switch (itemIndex)
				{
					case eItemIndex.Weapon:
				createImage.GetComponent<ItemUI>().Init(weapon);
						break;
					case eItemIndex.Equipment:
				createImage.GetComponent<ItemUI>().Init(equipt);
						break;
					case eItemIndex.Food:
				createImage.GetComponent<ItemUI>().Init(food);
						break;
					//case eItemIndex.Quest:
					//	break;
					//case eItemIndex.Goods:
					//	break;
					//case eItemIndex.Read:
					//	break;
					//case eItemIndex.Special:
					//	break;
					default:
						break;
				}
				createImage.gameObject.transform.parent = canvas.transform;
				createImage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (createImage != null) createImage.gameObject.SetActive(false);
	}

	public bool DestroyItem()
	{
		if (bDestroy == true) return true;
		bDestroy = true;

		if (createImage != null) Destroy(createImage);

		bool bReturn = false;
		switch (itemIndex)
		{
			case eItemIndex.Weapon:		bReturn = DataManager.Instance.ItemList.AddWeapon(weapon);break;
			case eItemIndex.Equipment:	bReturn = DataManager.Instance.ItemList.AddEquipt(equipt);break;
			case eItemIndex.Food:		bReturn = DataManager.Instance.ItemList.AddFood(food,1);  break;

				//case eItemIndex.Quest:
				//	break;
				//case eItemIndex.Goods:
				//	break;
				//case eItemIndex.Read:
				//	break;
				//case eItemIndex.Special:
				//	break;
				//case eItemIndex.Max:
				//	break;
				//case eItemIndex.Min:
				//	break;
				//default:
				//	break;
		}
		if (bReturn == true) { UIManager.Instance.AddFieldButtonInventoryAddNotify(); Destroy(gameObject); return true; }
		else return false;
	}


	private void ItemSetting()
	{
		int min = (int)eItemIndex.Min;
		int max = (int)eItemIndex.Max;
		itemIndex = (eItemIndex)Random.Range(min,max);

		switch (itemIndex)
		{
			case eItemIndex.Weapon:
				weapon = ItemWeapon.GetItemRandomIndex();
				break;
			case eItemIndex.Equipment:
				equipt = ItemEquipment.GetItemRandomIndex();
				break;
			case eItemIndex.Food:
				food = ItemFood.GetItemRandomIndex();
				break;
			case eItemIndex.Quest:
				break;
			case eItemIndex.Goods:
				break;
			case eItemIndex.Read:
				break;
			case eItemIndex.Special:
				break;
				//default:
				//	break;
		}
	}
}