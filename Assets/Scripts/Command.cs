using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class MoveLeftCommand : ICommand
    {
        private Basket basket;

        public MoveLeftCommand(Basket basket)
        {
            this.basket = basket;
        }

        public void Execute()
        {
            basket.MoveLeft();
        }
    }

    public class MoveRightCommand : ICommand
    {
        private Basket basket;

        public MoveRightCommand(Basket basket)
        {
            this.basket = basket;
        }

        public void Execute()
        {
            basket.MoveRight();
        }
    }

    public static void Execute(ICommand command)
    {
        command.Execute();
    }
}
