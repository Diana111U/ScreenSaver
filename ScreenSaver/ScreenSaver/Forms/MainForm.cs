using ScreenSaver.Classes;

namespace ScreenSaver
{
    public partial class MainForm : Form
    {
        const int SNOWFLAKESCOUNT = 100;
        int activeSnowflakesCount = 0;
        private Snowflake[] Snowflakes;
        int[] Sizes = [32, 64];
        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeSnowflake()
        {
            Random rnd = new Random();
            int x = rnd.Next(ClientSize.Width);
            int y = rnd.Next(ClientSize.Height);
            int size = Sizes[rnd.Next(2)];
            int speed;
            if (size == 32)
            {
                speed = 3;
            }
            else
            {
                speed = 5;
            }

            Snowflakes[activeSnowflakesCount] = new Snowflake(x, y, size, speed);
            activeSnowflakesCount++;
               
        }
       
    }
}
