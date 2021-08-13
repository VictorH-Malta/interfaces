using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace ExerciseInterfaces.Entities
{
    class Contract
    {
        public int Number { get; private set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Installment installment in Installments)
            {
                sb.AppendLine(installment.DueDate.ToString("dd/MM/yyyy") + " - " + installment.Amount.ToString("F2", CultureInfo.InvariantCulture));
            }

            return sb.ToString();
        }

    }
}
