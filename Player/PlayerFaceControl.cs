using UnityEngine;

public class PlayerFaceControl : MonoBehaviour
{
	[Header("Inspector")]
	public MMD4MecanimModel modelControl;

	public bool bTest;


	public int CorrectEye;
	public int CorrectEyeBlow;
	public int CorrectLip;
	public int CorrectOther;

	public int EyeBlowMax;
	public int EyeMax;
	public int LipMax;
	public int Other;


	private float[] FaceWeight;

	private void Start()
	{
		FaceWeight = new float[EyeBlowMax + EyeMax + LipMax + Other];
	}


	private void Update()
	{
		if(bTest)
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				FaceReset();
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				FaceSmile();
			}

			if (Input.GetKeyDown(KeyCode.Q))
			{
				foreach (var item in modelControl.morphList)
				{
					Debug.Log(item.name);
				}
			}
			if (Input.GetKeyDown(KeyCode.W))
				Debug.Log(modelControl.morphList.Length);
		}
	}

	private void PartsUpdate(int _min, int _max)
	{
		for (int i = _min; i < _max; i++)
		{
			modelControl.morphList[i].weight = FaceWeight[i];
		}
	}
	private void PartsReset(int _min, int _max)
	{
		for (int i = _min; i < _max; i++)
		{
			modelControl.morphList[i].weight = FaceWeight[i] = 0;
		}
	}

	public void FaceSmile()
	{
		int eyeblow = 0;
		int eye = 0;
		int mouse = 0;
		switch (CorrectEyeBlow)
		{
			case 1: eyeblow = EyeBlowMax; break;
			case 2: eyeblow = EyeBlowMax; break;
			case 3: break;

		}

		FaceReset();

		FaceWeight[eyeblow] = 1;
		FaceWeight[eye] = 1;
		FaceWeight[mouse] = 1;
		FaceUpdate();
	}

	#region Face 
	private void FaceReset()
	{

		FaceUpdate();
	}

	private void FaceUpdate()
	{
		for (int i = 0; i < FaceWeight.Length; i++)
		{
			modelControl.morphList[i].weight = FaceWeight[i];
		}
	}
	#endregion

	//#region EyeBlow
	//public void EyeBlowReset()
	//{
	//	PartsReset(start, end);
	//}

	//public void SetEyeBlow(FACEENUM _data, int _value)
	//{
	//	FACEENUM min = FACEENUM.BLOW_Earnestness;
	//	FACEENUM max = FACEENUM.BLOW_Front_Right;
	//	if (!(_data >= min && _data <= max)) return;

	//	int target = (int)prevEyeBlow;
	//	FaceWeight[target] = 0;
	//	prevEyeBlow = _data;

	//	target = (int)_data;
	//	FaceWeight[target] = _value;

	//	PartsUpdate((int)min,(int)max);
	//}

	//#endregion

	//#region Eye
	//public void EyeReset()
	//{
	//	int start = (int)FACEENUM.EYE_Blink;
	//	int end = (int)FACEENUM.EYE_Pupil_Star;

	//	PartsReset(start, end);
	//}
	//public void SetEye(FACEENUM _data, int _value)
	//{
	//	FACEENUM min = FACEENUM.EYE_Blink;
	//	FACEENUM max = FACEENUM.EYE_Pupil_Star;
	//	if (!(_data >= min && _data <= max)) return;

	//	int target = (int)prevEye;
	//	FaceWeight[target] = 0;
	//	prevEye = _data;

	//	target = (int)_data;
	//	FaceWeight[target] = _value;

	//	PartsUpdate((int)min, (int)max);
	//}


	//#endregion

	//#region Lip
	//public void LipReset()
	//{
	//	int start = (int)FACEENUM.LIP_A;
	//	int end = (int)FACEENUM.LIP_Open_Down;
	//	PartsReset(start, end);
	//}


	//public void SetLip(FACEENUM _data, int _value)
	//{
	//	FACEENUM min = FACEENUM.LIP_A;
	//	FACEENUM max = FACEENUM.LIP_Open_Down;
	//	if (!(_data >= min && _data <= max)) return;

	//	int target = (int)prevLip;
	//	FaceWeight[target] = 0;
	//	prevLip = _data;

	//	target = (int)_data;
	//	FaceWeight[target] = _value;

	//	PartsUpdate((int)min,(int)max);
	//}

	//#endregion


}