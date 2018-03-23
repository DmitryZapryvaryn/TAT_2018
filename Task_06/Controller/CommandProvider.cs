using Task_06.Controller.Command;

namespace Task_06.Controller
{
    public class CommandProvider
    {
        ICommand command;

        public CommandProvider() {}

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }
    }
}
