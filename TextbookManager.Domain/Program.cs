using TextbookManager.Business;
using TextbookManager.Business.UserInterface;

namespace TextbookManager.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var UI=new UInterface(new ReflectionCommandLoader(),new ServiceContainer());
            UI.Run();
        }
    }
}
