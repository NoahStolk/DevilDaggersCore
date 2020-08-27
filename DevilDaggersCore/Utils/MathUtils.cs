namespace DevilDaggersCore.Utils
{
	public static class MathUtils
	{
		public static float Lerp(float value1, float value2, float amount)
			=> value1 + (value2 - value1) * amount;
	}
}