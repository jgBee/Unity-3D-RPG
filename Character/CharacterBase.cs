using UnityEngine;

public class CharacterBase : MonoBehaviour
{
	private float walkSpeed, runSpeed,finalSpeed;

	[SerializeField] private GameObject model;

	private int hp, HpMax;
	public float HPPercent { get { return (float)hp / (float)HpMax; } }
	

}