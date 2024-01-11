public class ElementEnum
{
	public enum ELEMENT : byte
	{
		Wind = 0,
		Rock,
		Thunder,
		Grass,
		Water,
		Fire,
		Ice,
	};

	public enum ELEMENTRESULT : int
	{
		Wind_Wind = 00,
		Wind_Rock,
		Wind_Thunder,
		Wind_Grass,
		Wind_Water,
		Wind_Fire,
		Wind_Ice,

		Rock_Wind = 10,
		Rock_Rock,
		Rock_Thunder,
		Rock_Grass,
		Rock_Water,
		Rock_Fire,
		Rock_Ice,

		Thunder_Wind = 20,
		Thunder_Rock,
		Thunder_Thunder,
		Thunder_Grass,
		Thunder_Water,
		Thunder_Fire,
		Thunder_Ice,

		Grass_Wind = 30,
		Grass_Rock,
		Grass_Thunder,
		Grass_Grass,
		Grass_Water,
		Grass_Fire,
		Grass_Ice,

		Water_Wind = 40,
		Water_Rock,
		Water_Thunder,
		Water_Grass,
		Water_Water,
		Water_Fire,
		Water_Ice,

		Fire_Wind = 50,
		Fire_Rock,
		Fire_Thunder,
		Fire_Grass,
		Fire_Water,
		Fire_Fire,
		Fire_Ice,

		Ice_Wind = 60,
		Ice_Rock,
		Ice_Thunder,
		Ice_Grass,
		Ice_Water,
		Ice_Fire,
		Ice_Ice,
	};
}