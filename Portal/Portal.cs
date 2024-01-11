using UnityEngine;

public class Portal : MonoBehaviour
{
	public Transform target;

	public GameObject[] effects;

	public Transform moveTR;
	
	[SerializeField]private byte state;


	private float Distance => Vector3.Distance(transform.position, target.position) ;
	private bool InPlayerRange => (Distance >= 0.0f) && (Distance <= 10.0f);
	private bool InPlayer => (Distance >= 0.0f) && (Distance <= 1.0f);


	private void Start()
	{
		if(target == null)
		{
			Debug.LogError("포탈의 체크할 대상이 없습니다.");
			Destroy(gameObject);
			return;
		}
	}

	private void Update()
	{
		switch (state)
		{
			case 0:
				if (InPlayerRange) { state = 1; }

				break;
			case 1:
				foreach (GameObject item in effects)
					item.SetActive(true);

				state = 2;
				break;
			case 2:
				if (InPlayerRange == false) state = 3;

				if( InPlayer == true)
				{
					foreach (GameObject item in effects)
						item.SetActive(false);

					target.transform.position = moveTR.position;
					Camera.main.transform.position = moveTR.position;

					state = 0;
				}

				break;
			case 3:
				foreach (GameObject item in effects)
					item.SetActive(false);

				state = 0;
				break;
		}
	}
}