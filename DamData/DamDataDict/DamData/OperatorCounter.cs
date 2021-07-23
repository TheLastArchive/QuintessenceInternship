
namespace DamData
{
    class OperatorCounter
    {
        public static int opCounter { get; set; } = 0;

        public static void IncrementOperatorCounter() => opCounter++;
    }
}
