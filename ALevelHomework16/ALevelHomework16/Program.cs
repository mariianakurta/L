using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum StateEnum
{
    Ok,
    Cancel
}

public class MessageBox
{
    public event Action<StateEnum> WindowClosed;

    public async Task Open()
    {
        Console.WriteLine("Window is opened");

        await Task.Delay(3000);

        Console.WriteLine("Window was closed by the user");

        StateEnum state = GetRandomState();
        OnWindowClosed(state);
    }

    private StateEnum GetRandomState()
    {
        var random = new Random();
        return (StateEnum)random.Next(0, 2);
    }

    protected virtual void OnWindowClosed(StateEnum state)
    {
        WindowClosed?.Invoke(state);
    }
}

internal sealed class Program
{
    public static async Task Main(string[] args)
    {
        MessageBox messageBox = new MessageBox();
        messageBox.WindowClosed += (state) =>
        {
            Console.WriteLine($"State: {state}");
            HandleWindowClosedResult(state);
        };
        await messageBox.Open();
    }

    private static void HandleWindowClosedResult(StateEnum state)
    {
        switch (state)
        {
            case StateEnum.Ok:
                Console.WriteLine("Operation was confirmed");
                break;
            case StateEnum.Cancel:
                Console.WriteLine("Operation was rejected");
                break;
            default:
                break;
        }
    }
}
