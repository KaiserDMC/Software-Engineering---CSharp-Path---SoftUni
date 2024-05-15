namespace SummatorApp
{
    public class Summator
    {
        public int Sum(int[] arr)
        {
            int sum = arr[0];
            for (int i = 1; i < arr.Length; i++) sum += arr[i];
            return sum;
        }
    }
}