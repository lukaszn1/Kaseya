using System.Threading.Tasks;

namespace CodeChallenge.Application.Interfaces.Commands
{
    public interface ICommandHandler
    { }

    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task Handle(T command); //todo propagate 
    }
}
