using ClockPatienceExigy.Services;
using System;

namespace ClockPatienceExigy
{
    class Program
    {
        static void Main(string[] args)
        {
            new ClockSolitaireService().PlayGame();
        }
    }
}
