using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChequeWriter.Services;
using ChequeWriter.Validator;

namespace ChequeWriter
{
    public class Program
    {
        static void Main(string[] args)
        {
            INumberConverter converter = new NumberConverter();
            IInputValidator inputValidator = new InputValidator();
            IInputProcessor processor = new InputProcessor(converter, inputValidator);

            Console.WriteLine("Please enter an amount : ");

            var input = Console.ReadLine();
            Console.WriteLine("Your cheque amount is : ");
            Console.WriteLine(processor.ProcessInput(input));

            Console.ReadKey();

        }
    }
}
