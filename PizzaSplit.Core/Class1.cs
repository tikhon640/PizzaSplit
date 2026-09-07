namespace PizzaSplit.Core
{
    public static class PizzaCalculator
    {
        public static decimal CalculateShare(decimal total, int people, bool addTip)
        {
            if (total <= 0 || total > 10000)
                throw new ArgumentOutOfRangeException(nameof(total), "Сумма должна быть от 0,01 до 10 000 €.");
            if (people < 1 || people > 20)
                throw new ArgumentOutOfRangeException(nameof(people), "Количество человек должно быть от 1 до 20.");
            decimal finalTotal = addTip ? total * 1.10m : total;
            return Math.Round(finalTotal / people, 2, MidpointRounding.AwayFromZero);
        }
    }
}
