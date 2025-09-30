using ScreenSaver.Classes;

namespace ScreenSaver
{
    public partial class MainForm : Form
    {
        const int SnowflakesCount = 100;
        int activeSnowflakesCount = 0;
        private Image scene = new Bitmap(1, 1);
        private readonly Image pictureBackground = Properties.Resources.switzerkand;
        private readonly Image pictureSnowflake = Properties.Resources.snowflake;
        private readonly Snowflake[] Snowflakes = new Snowflake[SnowflakesCount];

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализация снежинок
        /// </summary>
        private void InitializeSnowflakes()
        {
            var rnd = new Random();
            var Sizes = new[] { 32, 64 };
            for (var i = 0; i < SnowflakesCount; i++)
            {
                var x = rnd.Next(ClientSize.Width);
                var size = Sizes[rnd.Next(2)];
                var y = -size;
                var speed = 6 * size / 64;
                Snowflakes[i] = new Snowflake(x, y, size, speed);
            }

        }

        /// <summary>
        /// Таймер движения снежинок
        /// </summary>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (var i = 0; i < activeSnowflakesCount; i++)
            {
                Snowflakes[i].Y += Snowflakes[i].Speed;
                if (Snowflakes[i].Y > ClientSize.Height)
                {
                    Snowflakes[i].Y = -Snowflakes[i].Size;
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
            timer1.Start();
        }

        /// <summary>
        /// Таймер счёта активных снежинок
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (activeSnowflakesCount < SnowflakesCount)
            {
                activeSnowflakesCount++;
            }
        }
    }
}
