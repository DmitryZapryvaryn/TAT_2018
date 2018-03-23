using System;
using Task_06.Entity;

namespace Task_06.Controller.Command.impl
{
    class CountTypeCommand : ICommand
    {
        private Warehouse warehouse;
        public CountTypeCommand(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void Execute()
        {
           Console.WriteLine(warehouse.GetCountTypes());
        }
    }
}