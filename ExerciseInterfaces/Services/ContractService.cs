using ExerciseInterfaces.Entities;

namespace ExerciseInterfaces.Services
{
    class ContractService
    {
        public Contract Contract { get; set; }
        public IOnlinePaymentService _onlinePaymentService;

        public ContractService(Contract contract, IOnlinePaymentService onlinePaymentService)
        {
            Contract = contract;
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double parc = contract.TotalValue / months;
            //De acordo com a quantidade de meses
            for (int i = 1; i <= months; i++)
            {
                
                double installment = _onlinePaymentService.Interest(parc, i);
                
                contract.Installments.Add(new Installment(contract.Date.AddMonths(i), _onlinePaymentService.PaymentFee(installment)));
            }
        }
    }
}
