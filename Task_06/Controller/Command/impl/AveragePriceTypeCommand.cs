using System;
using Task_06.Entity;

namespace Task_06.Controller.Command.impl
{
    class AveragePriceTypeCommand : ICommand
    {
        private Warehouse warehouse;
        private string type;
        public AveragePriceTypeCommand(Warehouse warehouse, string type)
        {
            this.warehouse = warehouse;
            this.type = type;
        }

        public void Execute()
        {
            Console.WriteLine(warehouse.GetAveragePrice(type));
        }
    }
}
