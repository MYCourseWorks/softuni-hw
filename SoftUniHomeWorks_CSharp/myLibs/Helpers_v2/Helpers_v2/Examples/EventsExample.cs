namespace Helpers_v2.Examples
{
    using System;
    
    class EventsExample
    {
        /// <summary>
        /// The arguments class thats going to be passed to event handlers.
        /// </summary>
        public class MyEventArgs : EventArgs
        {
            private int ticksLeft;

            public MyEventArgs(int ticksLeft)
            {
                this.ticksLeft = ticksLeft;
            }

            public int TicksLeft
            {
                get { return this.ticksLeft; }
            }
        }

        /// <summary>
        /// The user defined event handler.
        /// </summary>
        /// <param name="sender">In which class was the event triggered.</param>
        /// <param name="eventArgs">eventArgs class with the arguments we want to pass.</param>
        public delegate void MyEvenetHandler(object sender, MyEventArgs eventArgs);

        /// <summary>
        /// Test class that has the click event .
        /// All This does is signal that a event happened.
        /// </summary>
        public class Button
        {
            public event MyEvenetHandler Click; // this provides the subscribe an unsubscribe System functionality

            private void OnClick()
            {
                if (Click != null)
                {
                    Click(this, new MyEventArgs(10));
                }
            }

            public void FireClick()
            {
                OnClick();
            }
        }

        /// <summary>
        /// The actual work that needs to be don when a lick happens.
        /// </summary>
        public static void OnClick_DoWork(object sender, MyEventArgs args)
        {
            Console.WriteLine(args.TicksLeft);
        }

        //public static void Main()
        //{
        //    Button button = new Button();

        //    button.FireClick(); // nothing happens.

        //    button.Click += OnClick_DoWork;

        //    button.FireClick(); // now the OcLickDoWork executes and prints 10 to the screen.

        //    button.Click -= OnClick_DoWork;

        //    button.FireClick(); // nothing happens
        //}
    }
}
