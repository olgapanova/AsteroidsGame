using System;
using System.Drawing;

namespace AsteroidsGame
{
    class Bullets : BaseObject
    {
        /// <summary>
        /// Конструктор по умолчания - пуля
        /// </summary>
        /// <param name="pos">Координаты нашего объекта</param>
        /// <param name="dir">Направление движения нашего объекта по координатной плоскости</param>
        /// <param name="size">Размер нашего объекта</param>
        public Bullets(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        /// <summary>
        /// Отрисовываем наш объект
        /// </summary>
        public override void Draw()
        {
            SplashScreen.buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        /// <summary>
        /// Логика движения нашего объекта
        /// </summary>
        public override void Update()
        {
            Pos.X += 3;
        }
    }
}
