using System;
using System.Drawing;

namespace AsteroidsGame
{
    /// <summary>
    /// Объект - движущиеся звезды
    /// </summary>
    class Star : BaseObject
    {
        /// <summary>
        /// Создаем звезду
        /// </summary>
        /// <param name="pos">Расположение звезды</param>
        /// <param name="dir">Направление движения звезды</param>
        /// <param name="size">Размер звезды</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Рисуем в буфер звезду
        /// </summary>
        public override void Draw()
        {
            SplashScreen.buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            SplashScreen.buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y + Size.Height, Pos.X + Size.Width, Pos.Y);
            SplashScreen.buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y + Size.Height / 2, Pos.X + Size.Width, Pos.Y + Size.Height / 2);
            SplashScreen.buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width / 2, Pos.Y, Pos.X + Size.Width / 2, Pos.Y + Size.Height);
        }

        /// <summary>
        /// Движение звезды по экрану
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X < 0) Pos.X = SplashScreen.Width;
            if (Pos.Y < 0) Pos.Y = SplashScreen.Height;
        }   
    }
}
