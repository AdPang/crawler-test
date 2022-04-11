namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = Test.GetText();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test.SetText(textBox1.Text);
        }

        private void GetText()
        {
            textBox1.Invoke(() =>
            {
                textBox1.Text = Test.GetText();
            });
        }
        bool isFinish = false;
        private void button3_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            isFinish = false;
            var task = Task.Factory.StartNew(() => 
            {
                while (!isFinish)
                {
                    GetText();
                    Thread.Sleep(500);
                }
            });

            task.GetAwaiter().OnCompleted(() =>
            {
                button3.Enabled = true;
                button4.Enabled = false;
            });
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isFinish = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(3000);
                // 执行的函数
                MessageBox.Show("Test");
            });
            task.GetAwaiter().OnCompleted(() =>
            {
                //线程执行完毕后
                MessageBox.Show("线程完成！");
            });
        }
    }
}