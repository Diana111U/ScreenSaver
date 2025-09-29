using ScreenSaver.Classes;

namespace ScreenSaver
{
    public partial class MainForm : Form
    {
        const int SNOWFLAKESCOUNT = 100;
        int activeSnowflakesCount = 0;
        private Image scene = new Bitmap(1, 1);
        private readonly Image pictureBackground = Properties.Resources.switzerkand;
        private readonly Image pictureSnowflake = Properties.Resources.snowflake;
        private readonly Snowflake[] Snowflakes = new Snowflake[SNOWFLAKESCOUNT];

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализация снежинок
        /// </summary>
        private void InitializeSnowflakes()
        {
            Random rnd = new Random();
            int[] Sizes = [32, 64];
            int y, speed;
            for (var i = 0; i < SNOWFLAKESCOUNT; i++)
            {
                int x = rnd.Next(ClientSize.Width);
                int size = Sizes[rnd.Next(2)];
                if (size == 32)
                {
                    y = -32;
                    speed = 3;
                }
                else
                {
                    y = -64;
                    speed = 6;
                }
                Snowflakes[i] = new Snowflake(x, y, size, speed);
            }

        }

        /// <summary>
        /// Таймер
        /// </summary>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (activeSnowflakesCount < SNOWFLAKESCOUNT)
            {
                activeSnowflakesCount++;
            }

            for (var i = 0; i < activeSnowflakesCount; i++)
            {
                Snowflakes[i].Y += Snowflakes[i].Speed;
                if (Snowflakes[i].Y > ClientSize.Height)
                {
                    if (Snowflakes[i].Size == 32)
                    {
                        Snowflakes[i].Y = -32;
                    }
                    else
                    {
                        Snowflakes[i].Y = -64;
                    }
                }
            }
            MainForm_Paint(this, new PaintEventArgs(CreateGraphics(), ClientRectangle));

        }

        /// <summary>
        /// Отрисовка формы
        /// </summary>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            var bg = Graphics.FromImage(scene);
            bg.DrawImage(pictureBackground, 0, 0, Width, Height);
            for (int i = 0; i < activeSnowflakesCount; i++)
            {
                bg.DrawImage(pictureSnowflake, Snowflakes[i].X, Snowflakes[i].Y, Snowflakes[i].Size, Snowflakes[i].Size);
            }
            e.Graphics.DrawImage(scene, new Point(0, 0));
        }

        /// <summary>
        /// Закрытие формы при нажатии на клавишу
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            scene = new Bitmap(ClientSize.Width, ClientSize.Height);
            InitializeSnowflakes();
            timer.Start();
        }
    }
}
