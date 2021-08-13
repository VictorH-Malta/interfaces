namespace ExerciseInterfaces.Services
{
    class PayPalService : IOnlinePaymentService
    {
        private double Tax { get; set; } = 0.02;
        private double Fee { get; set; } = 0.01;
        
        public double PaymentFee(double amount)
        {
            return amount + amount * Tax;
        }

        public double Interest(double amount, int months)
        {
            return amount + amount * Fee * months;
        }
    }
}
