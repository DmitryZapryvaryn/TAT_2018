using System;
using Task_06.Entity;

namespace Task_06.Controller.Command.impl
{
    class CountAllCommand : ICommand
    {
        private Warehouse warehouse;
        public CountAllCommand(Warehouse warehouse)
        {
            this.warehouse = warehouse;
        }

        public void Execute()
        {
            Console.WriteLine(warehouse.GetCount());
        }
    }
}