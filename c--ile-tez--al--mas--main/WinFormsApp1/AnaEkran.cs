namespace WinFormsApp1
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AGrubu yeniForm = new AGrubu(); // Yeni pencereyi olu�tur
            yeniForm.Show(); // Yeni pencereyi a�
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ErgonomikTezgahAnalizi frmrula = new ErgonomikTezgahAnalizi(); // Yeni pencereyi olu�tur
            frmrula.Show(); // Yeni pencereyi a�
            this.Hide();
        }
    }
}
