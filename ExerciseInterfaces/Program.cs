using System;
using System.Collections.Generic;
using System.Globalization;
using ExerciseInterfaces.Entities;
using ExerciseInterfaces.Services;

namespace ExerciseInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter contract data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Date (dd/MM/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Contract value: ");
                double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Enter the number of installments: ");
                int months = int.Parse(Console.ReadLine());

                
                Contract contract = new Contract(number, date, contractValue);

                ContractService contractService = new ContractService(contract, new PayPalService());
                contractService.ProcessContract(contract, months);

                Console.WriteLine("Installments: ");
                Console.WriteLine(contractService.Contract.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
