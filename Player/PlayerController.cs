using UnityEngine;

using static PlayerEnum;
using static ElementEnum;


public class PlayerController : MonoBehaviour
{
	private PlayerModelGroup playerModel;
	private PlayerBaseData playerdata;

	public Vector3 startPos;

	private PLAYERCHARINDEX Index { get { return playerdata.Index; } set { playerdata.Index = value; } }

	public bool bTestWall = true;


	private Vector3 moveDir;

	public bool isCameraMove = false;

	public float walkSpeed = 5;
	public float runSpeed = 10;
	public float finalSpeed = 0;

	private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;

	private Vector3 moveLeftUp;
	private Vector3 moveLeftDown;
	private Vector3 moveRightUp;
	private Vector3 moveRightDown;

	public PlayerMove playerMove;

	#region Awake_Start_Init_Reset

	private void Awake()
	{
		finalSpeed = walkSpeed;
		moveLeftUp = new Vector3(-0.7f, 0, 0.7f);
		moveLeftDown = new Vector3(-0.7f, 0, -0.7f);
		moveRightUp = new Vector3(0.7f, 0, 0.7f);
		moveRightDown = new Vector3(0.7f, 0, -0.7f);

		playerdata = GetComponent<PlayerBaseData>();
		playerModel = GetComponentInChildren<PlayerModelGroup>();
		playerMove = GetComponent<PlayerMove>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			finalSpeed  = runSpeed;
		}
		else
		{
			finalSpeed = walkSpeed;
		}

		if( Input.GetKeyDown(KeyCode.Alpha1))
		{
			ChangeCharacter(PLAYERCHARINDEX.Char_5_0_1_MainGirl);
		}

		if (Input.GetKey(KeyCode.W)) { isUp = true; } else isUp = false;
		if (Input.GetKey(KeyCode.S)) { isDown = true; } else isDown = false;
		if (Input.GetKey(KeyCode.A)) { isLeft = true; } else isLeft = false;
		if (Input.GetKey(KeyCode.D)) { isRight = true; } else isRight = false;

		if (!isUp && !isDown && !isLeft && !isRight)
		{
			moveDir = Vector3.zero;
			playerMove.SetSpeed(0);
			playerModel.SetMove(0);
			return;
		}

		if (isLeft && isUp == false && isDown == false && isRight == false)
		{
			moveDir = -Camera.main.transform.right;
		}
		if (isRight && isUp == false && isDown == false && isLeft == false)
		{
			moveDir = Camera.main.transform.right;
		}
		if (isUp && isDown == false && isLeft == false && isRight == false)
		{
			moveDir = Camera.main.transform.forward;
		}
		if (isDown && isUp == false && isLeft == false && isRight == false)
		{
			moveDir = -Camera.main.transform.forward;
		}

		if (isLeft && isUp)
		{
			moveDir = Camera.main.transform.rotation * moveLeftUp;
		}
		else if (isLeft && isDown)
		{
			moveDir = Camera.main.transform.rotation * moveLeftDown;
		}

		if (isRight && isUp)
		{
			moveDir = Camera.main.transform.rotation * moveRightUp;
		}
		else if (isRight && isDown)
		{
			moveDir = Camera.main.transform.rotation * moveRightDown;
		}

		moveDir.y = 0;



		playerMove.SetSpeed(finalSpeed);
		playerModel.SetMove(finalSpeed);
		playerMove.Move(ref moveDir);

		//if (moveDir != Vector3.zero)
		//{
		//	if (bTestWall)
		//	{
		//		Ray ray = new Ray(transform.position, moveDir);

		//		RaycastHit hitData;

		//		if (Physics.Raycast(ray, out hitData, 0.5f) == true)
		//		{
		//			if (hitData.collider.transform.tag == "Wall") return;
		//		}
		//	}
		//	moveDir.y = 0;

		//	transform.rotation = Quaternion.LookRotation(moveDir);
		//	//회전한 후 전진방향으로 이동
		//	transform.Translate(Vector3.forward * Time.deltaTime * finalSpeed);
		//}
	}

	#endregion

	#region Global

	public void ChangeCharacter(PLAYERCHARINDEX _index)
	{
		playerdata.ChangeData(_index, 1);
		playerModel.OnModel(_index);
	}

	#endregion

	#region Face

	#endregion

	#region Animation



	#endregion

	#region Data
	


	#endregion

	#region DataPart


	#endregion
}