using System;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidsGame
{
    /// <summary>
    /// Поле игры
    /// </summary>
    static class Game
    {
        static BufferedGraphicsContext bgc;
        public static BufferedGraphics buffer;   
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject [] objcircles;
        public static BaseObject [] objstars;
        private static Bullets _bullet;
        private static Asteroid[] _asteroids;
        static Image img = Image.FromFile(@"background_game.jpg");
        
        static Game()
        {
        }

        /// <summary>
        /// Инициализируем появление окна игры
        /// </summary>
        /// <param name="form">Окно игры</param>
        public static void Init(Form formGame)
        {
            Graphics graphic;
            bgc = BufferedGraphicsManager.Current;
            graphic = formGame.CreateGraphics();
            Width = formGame.ClientSize.Width;
            Height = formGame.ClientSize.Height;
            buffer = bgc.Allocate(graphic, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 75 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Рисуем элементы на экране
        /// </summary>
        public static void Draw()
        {
            //buffer.Graphics.Clear(Color.Black);
            buffer.Graphics.DrawImage(img, 0, 0, Game.Width, Game.Height);
            foreach (BaseObject obj in objcircles)
            {
                obj.Draw();
            }
            foreach (BaseObject obj in objstars)
            {
                obj.Draw();
            }
            foreach (BaseObject obj in _asteroids)
            {
                obj.Draw();
            }
            buffer.Render();
        }

        /// <summary>
        /// Теперь элементы двигаются
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in objcircles)
            {
                obj.Update();
            }
            foreach (BaseObject obj in objstars)
            {
                obj.Update();
            }
        }

        /// <summary>
        /// Наполняем элементами экран
        /// </summary>
        public static void Load()
        {
            objcircles = new BaseObject[30];
            objstars = new BaseObject[30];
            _asteroids = new Asteroid[3];
            _bullet = new Bullets(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            var rnd = new Random();
            for (int i=0; i < objcircles.Length; i++)
            {
                for (int j = 0; j < objstars.Length; j++)
                {
                    objstars[i] = new Star(new Point(600, i * 20), new Point(i + 5, 0), new Size(7, 7));
                }
                objcircles[i] = new Circle(new Point(600, i * 20), new Point(15 - i, 10 - i), new Size(10, 10));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(700, rnd.Next(0, Height)), new Point(-r / 5, r), new Size(r, r));
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }


    }
}
