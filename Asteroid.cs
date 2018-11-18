using System;
using System.Drawing;

namespace AsteroidsGame
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }

        /// <summary>
        /// Конструктор по умолчанию - астероиды
        /// </summary>
        /// <param name="pos">Координаты нашего объекта</param>
        /// <param name="dir">Направление движения нашего объекта</param>
        /// <param name="size">Размер нашего объекта</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        /// <summary>
        /// Отрисовываем наш объект
        /// </summary>
        public override void Draw()
        {
            SplashScreen.buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Логика движения нашего объекта
        /// </summary>
        public override void Update()
        {            
        }

    }
}
