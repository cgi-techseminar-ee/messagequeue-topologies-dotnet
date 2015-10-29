namespace Client
{
    using System;
    using System.Windows.Forms;
    using Common;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var bus = BusFactory.Create("rr-request", configurator => { });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(bus));

            bus.Stop();
        }
    }
}