using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public static class InputManager
    {
        public static void Update()
        {
            var State = Keyboard.GetState();

            if(State.IsKeyDown(Keys.F11)) Renderer.FullScreenToggle();
        }
    }
}
