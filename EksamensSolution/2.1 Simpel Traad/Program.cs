using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2._1_Simpel_Traad
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldHandler hwHandler = new HelloWorldHandler();

            Delegate dele;
            dele = hwHandler.HelloWorld();


            Thread helloWorldThread = new Thread()
        }
    }
}
