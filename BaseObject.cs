using System;
using System.Drawing;

namespace AsteroidsGame
{
    abstract class BaseObject
    {
        protected Point Pos, Dir, point1, point2;
        protected Size Size, sizeobj;
        protected int N;
        
        /// <summary>
        /// Объект на экране - основа
        /// </summary>
        /// <param name="pos">Координаты нашего объекта</param>
        /// <param name="dir">Направление движения нашего объекта по координатной плоскости</param>
        /// <param name="size">Размер нашего объекта</param>
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        protected BaseObject(int N, Point point1, Point point2, Size sizeobj)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.sizeobj = sizeobj;
            this.N = N;
        }

        public abstract void Draw();
        public abstract void Update();
    }
}
