using System;
using Task_06.Entity;

namespace Task_06.Controller.Command.impl
{
    class AveragePriceCommand : ICommand
    {
        Warehouse warehouse;
        public AveragePriceCommand(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void Execute()
        {
            Console.WriteLine(warehouse.GetAveragePrice());
        }
    }
}
