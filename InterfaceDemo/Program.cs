// See https://aka.ms/new-console-template for more information

namespace interfaceDemo
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<IKeyboardController> controllers = new List<IKeyboardController>();
            
            Keyboard keyboard = new Keyboard();
            GameController gameController = new GameController();
            BatteryPoweredGameController batteryController = new BatteryPoweredGameController();
            BatteryPoweredKeyBoard batteryPoweredKeyBoard = new BatteryPoweredKeyBoard();
            
            controllers.Add(keyboard);
            controllers.Add(gameController);
            controllers.Add(batteryController);

            foreach (IKeyboardController controller in controllers)
            {
                controller.Connect();
                controllers.Add(controller);
            }

            List<IBatteryPowered> batteryPowereds = new List<IBatteryPowered>();
            
            batteryPowereds.Add(batteryController);
            batteryPowereds.Add(batteryPoweredKeyBoard);

            Console.ReadLine();
        }
    }

    public interface IKeyboardController
    {
        void Connect();

        void CurrentKeyPressed();
    }

    public interface IBatteryPowered
    {
        int BatteryLevel { get; set; }
    }
    
    public class Keyboard : IKeyboardController
    {
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void CurrentKeyPressed()
        {
            throw new NotImplementedException();
        }
        
        public string ConnectionType { get; set; }
    }

    public class BatteryPoweredKeyBoard : Keyboard, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }
    
    public class GameController : IKeyboardController, IDisposable
    {
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void CurrentKeyPressed()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class BatteryPoweredGameController : GameController, IBatteryPowered
    {
        private int _batteryLevel;
        private int BatteryPercentage { get; set; }

        public void BatteryLevel()
        {
            Console.WriteLine(BatteryPercentage);
        }

        int IBatteryPowered.BatteryLevel
        {
            get => _batteryLevel;
            set => _batteryLevel = value;
        }
    }
}