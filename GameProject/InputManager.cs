using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public static class InputManager
    {
        static bool FullScreen = false;

        static void FullScreenToggle()
        {
            FullScreen = !FullScreen;
            Globals.Graphics.IsFullScreen = !FullScreen;
            Globals.Graphics.ApplyChanges();
        }

        public static void Update()
        {
            var State = Keyboard.GetState();

            if(State.IsKeyDown(Keys.F11)) FullScreenToggle();
        }
    }
}
