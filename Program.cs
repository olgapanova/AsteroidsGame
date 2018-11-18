using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            //SplashScreen.NewGame();
            //SplashScreen.Records();
            //SplashScreen.Exit();
            //SplashScreen.NameGame();
            //SplashScreen.Writer();
            SplashScreen.Init(form);
            SplashScreen.MainMenu_Activate();
            //Game.Init(form);
            form.Show();
            SplashScreen.Draw();
            //Game.Draw();
            Application.Run(form);
        }
    }
}
