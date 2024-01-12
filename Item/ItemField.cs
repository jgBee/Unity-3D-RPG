using UnityEngine;
using UnityEngine.UI;
using static ItemEnum;

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

	[SerializeField]ITEMINDEX itemIndex;
	WEAPONITEMINDEX weapon;
	EQUIPTMENTINDEX equipt;
	FOODITEMINDEX food;

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
				case ITEMINDEX.Weapon:
					createEffect = Instantiate(InTerrainEffects[0], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				case ITEMINDEX.Equiptment:
					createEffect = Instantiate(InTerrainEffects[1], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				case ITEMINDEX.Food:
					createEffect = Instantiate(InTerrainEffects[2], transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
					createEffect.transform.parent = transform;
					break;
				//case ITEMINDEX.Quest:
				//	break;
				//case ITEMINDEX.Goods:
				//	break;
				//case ITEMINDEX.Read:
				//	break;
				//case ITEMINDEX.Special:
				//	break;
				//case ITEMINDEX.Max:
				//	break;
				//case ITEMINDEX.Min:
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
					case ITEMINDEX.Weapon:
				createImage.GetComponent<ItemUI>().Init(weapon);
						break;
					case ITEMINDEX.Equiptment:
				createImage.GetComponent<ItemUI>().Init(equipt);
						break;
					case ITEMINDEX.Food:
				createImage.GetComponent<ItemUI>().Init(food);
						break;
					//case ITEMINDEX.Quest:
					//	break;
					//case ITEMINDEX.Goods:
					//	break;
					//case ITEMINDEX.Read:
					//	break;
					//case ITEMINDEX.Special:
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
			case ITEMINDEX.Weapon:		bReturn = Inventory.Instance.WeaponItemIn(weapon);break;
			case ITEMINDEX.Equiptment:	bReturn = Inventory.Instance.EquiptItemIn(equipt);break;
			case ITEMINDEX.Food:		bReturn = Inventory.Instance.FoodItemIn(food);	  break;

				//case ITEMINDEX.Quest:
				//	break;
				//case ITEMINDEX.Goods:
				//	break;
				//case ITEMINDEX.Read:
				//	break;
				//case ITEMINDEX.Special:
				//	break;
				//case ITEMINDEX.Max:
				//	break;
				//case ITEMINDEX.Min:
				//	break;
				//default:
				//	break;
		}
		if (bReturn == true) { UIManager.Instance.AddFieldButtonInventoryAddNotify(); Destroy(gameObject); return true; }
		else return false;
	}


	private void ItemSetting()
	{
		int min = (int)ITEMINDEX.Min;
		int max = (int)ITEMINDEX.Max;
		itemIndex = (ITEMINDEX)Random.Range(min,max);

		switch (itemIndex)
		{
			case ITEMINDEX.Weapon:
				weapon = ItemWeapon.GetItemRandomIndex();
				break;
			case ITEMINDEX.Equiptment:
				equipt = ItemEquipment.GetItemRandomIndex();
				break;
			case ITEMINDEX.Food:
				food = ItemFood.GetItemRandomIndex();
				break;
				//case ITEMINDEX.Quest:
				//	break;
				//case ITEMINDEX.Goods:
				//	break;
				//case ITEMINDEX.Read:
				//	break;
				//case ITEMINDEX.Special:
				//	break;
				//case ITEMINDEX.Max:
				//	break;
				//case ITEMINDEX.Min:
				//	break;
				//default:
				//	break;
		}
	}
}