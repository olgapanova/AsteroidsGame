using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidsGame
{
    static class SplashScreen
    {
        static BufferedGraphicsContext bgc;
        public static BufferedGraphics buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] objcircles;
        public static BaseObject[] objstars;
        static Button newGame, records, exit;
        static Label nameGame, writer;
        static Image bgimage = Image.FromFile(@"background_cosmos.jpg");
        //private static Bullets _bullet;
        //private static Asteroid[] _asteroids;
        static Form form1;

        static SplashScreen()
        {
        }

        /// <summary>
        /// Инициализируем появление окна главного меню
        /// </summary>
        /// <param name="form">Окно главного меню</param>
        public static void Init(Form form)
        {
            Graphics g;
            bgc = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            buffer = bgc.Allocate(g, new Rectangle(0, 0, Width, Height));
            form1 = form;
            MainMenu_Activate();
            FormGame();
            Load();
            Timer timer = new Timer { Interval = 75 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Нажание на кнопку выход - закрывает игру
        /// </summary>
        static void Exit_Click(object sender, EventArgs e)
        {
            form1.Close();
        }

        /// <summary>
        /// Метод, отвечающий за появление кнопок на экране
        /// </summary>
        public static void MainMenu_Activate()
        {
            form1.Controls.Add(newGame);
            form1.Controls.Add(records);
            form1.Controls.Add(exit);
            form1.Controls.Add(nameGame);
            form1.Controls.Add(writer);
            NameGame();
            Writer();
            Records();
            NewGame();
            Exit();
            FormGame();
            exit.Click += Exit_Click;
        }

        /// <summary>
        /// Кнопка "Новая игра"
        /// </summary>
        public static Button NewGame()
        {
            newGame = new Button
            {
                Size = new Size(200, 50),
                Location = new Point(500, 150),
                Text = "Новая игра",
                Cursor = Cursors.Hand
            };
            return newGame;            
        }

        /// <summary>
        /// Кнопка "Таблица рекордов"
        /// </summary>
        public static Button Records()
        {
            records = new Button
            {
                Size = new Size(200, 50),
                Location = new Point(500, 250),
                Text = "Таблица рекордов",
                Cursor = Cursors.Hand
            };
            return records;
        }

        /// <summary>
        /// Кнопка "Выход"
        /// </summary>
        public static Button Exit()
        {
            exit = new Button
            {
                Size = new Size(200, 50),
                Location = new Point(500, 350),
                Text = "Выход",
                Cursor = Cursors.Hand
            };            
            return exit;
        }

        /// <summary>
        /// Надпись - название игры
        /// </summary>
        public static Label NameGame()
        {
            nameGame = new Label();
            nameGame.Text = "Space \nIntruders";
            nameGame.Location = new Point(125, 225);
            nameGame.TextAlign = ContentAlignment.MiddleCenter;
            nameGame.ForeColor = Color.Crimson;
            nameGame.Font = new Font("Times New Roman", 34, FontStyle.Bold);
            nameGame.Size = new Size(200, 100);
            //nameGame.BackColor = Color.Transparent; //почему-то не работает.            
            return nameGame;
        }

        /// <summary>
        /// Надпись - создатель игры
        /// </summary>
        public static Label Writer()
        {
            writer = new Label();
            writer.Text = "Автор - Ольга Панова";
            writer.Location = new Point(125, 330);
            writer.TextAlign = ContentAlignment.MiddleCenter;
            writer.ForeColor = Color.Crimson;
            writer.Font = new Font("Times New Roman", 12, FontStyle.Italic);
            writer.Size = new Size(200, 25);
            //writer.BackColor = Color.Transparent; //почему-то не работает.            
            return writer;
        }
         
        /// <summary>
        /// Рисуем элементы на экране
        /// </summary>
        public static void Draw()
        {
            buffer.Graphics.DrawImage(bgimage, 0, 0, Width, Height);
            foreach (BaseObject obj in objcircles)
            {
                obj.Draw();
            }
            foreach (BaseObject obj in objstars)
            {
                obj.Draw();
            }

            //foreach (BaseObject obj in _asteroids)
            //{
            //    obj.Draw();
            //}
            buffer.Render();
        }

        /// <summary>
        /// Наполняем экран элементами
        /// </summary>
        public static void Load()
        {
            objcircles = new BaseObject[30];
            objstars = new BaseObject[30];
            //_bullet = new Bullets(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            //_asteroids = new Asteroid[3];
            //var rnd = new Random();
            for (int i = 0; i < objcircles.Length; i++)
            {
                for (int j = 0; j < objstars.Length; j++)
                {
                    objstars[j] = new Star(new Point(600, j * 20), new Point(j + 5, 0), new Size(7, 7));
                }
                objcircles[i] = new Circle(new Point(600, i * 20), new Point(15 - i, 10 - i), new Size(10, 10));
            }
            //for (var i = 0; i < _asteroids.Length; i++)
            //{
            //    int r = rnd.Next(5, 50);
            //    _asteroids[i] = new Asteroid(new Point(700, rnd.Next(0, Height)), new Point(-r / 5, r), new Size(r, r));
            //}
        }

        /// <summary>
        /// Метод, отвечающий за движение объектов
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

        static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Метод, отвечающий за логику нажатия на кнопку "Новая игра", открывает новое окно с классом Game
        /// </summary>
        public static void FormGame()
        {
            Form formGame = new Form {StartPosition = FormStartPosition.CenterScreen, Width = 800, Height = 600};
            void NewGame_Click(object sender, EventArgs e)
            {
                form1.Hide();
                Game.Init(formGame);
                formGame.ShowDialog();
                form1.Close();
                Game.Draw();
            }
            newGame.Click += NewGame_Click;
        }
    }
}