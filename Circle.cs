using System;
using System.Drawing;

namespace AsteroidsGame
{
    /// <summary>
    /// Объект - движущиеся круги
    /// </summary>
    class Circle : BaseObject
    {
        Image img = Image.FromFile(@"rock_type_C0015.png");

        /// <summary>
        /// Конктруктор по умолчанию - круг(камушки)
        /// </summary>
        /// <param name="pos">Координаты нашего объекта</param>
        /// <param name="dir">Направление движения нашего объекта по координатной плоскости</param>
        /// <param name="size">Размер нашего объекта</param>
        public Circle(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Рисуем в буфер круг(камушки)
        /// </summary>
        public override void Draw()
        {
            SplashScreen.buffer.Graphics.DrawImage(img, Pos.X, Pos.Y);
        }

        /// <summary>
        /// Логика движения кругов(камушков)
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X >= SplashScreen.Width) Dir.X = -Dir.X;
            if (Pos.Y >= SplashScreen.Height) Dir.Y = -Dir.Y;
            if (Pos.X <= 0) Dir.X = -Dir.X;
            if (Pos.Y <= 0) Dir.Y = -Dir.Y;
        }       
    }
}
