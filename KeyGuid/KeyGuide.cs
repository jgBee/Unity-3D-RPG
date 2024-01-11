using UnityEngine;
using UnityEngine.UI;


public class KeyGuide : MonoBehaviour
{
	public Sprite[] keySprite;
	[SerializeField] private Image keyImage;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void OnMessage(string _str)
	{
		if (_str == "")
		{
			gameObject.SetActive(false);
			return;
		}

		else
		{
			gameObject.SetActive(true);
			switch (_str)
			{
				case "F":
					keyImage.sprite = keySprite[0];
					break;
				case "G":
					keyImage.sprite = keySprite[1];
					break;
			}
		}
	}

}