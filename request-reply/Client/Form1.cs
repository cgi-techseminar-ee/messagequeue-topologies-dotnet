namespace Client
{
    using System;
    using System.Windows.Forms;

    using Common.Messages;

    using MassTransit;

    public partial class Form1 : Form
    {
        private readonly IBusControl bus;

        public Form1(IBusControl bus)
        {
            this.bus = bus;
            this.InitializeComponent();
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var number = int.Parse(this.txtNumber.Text);

                var client = this.bus.CreatePublistRequestClient<FibonacciRequest, FiboracciResponse>(TimeSpan.FromSeconds(3));
                var response = await client.Request(new FibonacciRequest { Number = number });

                this.lblStatus.Text = @"Answer: " + response.Answer;
            }
            catch (Exception ex)
            {
                this.lblStatus.Text = @"Ex: " + ex.Message;
            }
        }
    }
}