public class EnemyEnum
{
	public enum ENEMYCHARINDEX : uint
	{
		None = 00000,

		// 10001 ~ 29999 까지 일반 몹 _Normal_
		Char_N_SpearMan = 10001,


		// 30001 ~ 59999 까지 히든 적 _Hidden_
		Char_H_SpearMan = 30001,

		// 60001 ~ 99999 까지 보스 _Boss_
		Char_B_SpearMan = 60001,

		//test
		// 100000 ~ Event = _Event_ 
		Char_E_SpearMan = 100000,
	};
}