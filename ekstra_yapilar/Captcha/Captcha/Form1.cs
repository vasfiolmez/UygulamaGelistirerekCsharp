namespace Captcha
{
    public partial class captcha : Form
    {
        public captcha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] sembol1 = { "a", "b", "c" ,"d","e","f"};
            string[] sembol2 = { "+","-","/","#","-"};
            string[] sembol3 = { "A", "D", "K", "F", "Ç" };
            int s1, s2,s3,s4,s5;
            Random rand = new Random();
            s1 = rand.Next(0, sembol1.Length);
            s2=rand.Next(0, sembol2.Length);
            s3=rand.Next(0,sembol3.Length);
            s4 = rand.Next(0, 10);
            s5= rand.Next(10, 20);   
            label1.Text = sembol1[s1].ToString()+ sembol2[s2].ToString() + sembol3[s3].ToString() +s4.ToString()+s5.ToString();
            


        }
    }
}