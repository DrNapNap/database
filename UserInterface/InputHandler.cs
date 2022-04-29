using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{

    class InputHandler
    {

        private static InputHandler instance;

        private ButtonEvent buttonEvent = new ButtonEvent();


        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        private Dictionary<KeyInfo, ICommand> keybinds = new Dictionary<KeyInfo, ICommand>();

        private InputHandler()
        {
            Player player = (Player)GameWorld.Instance.FindObjectOfType<Player>();
            buttonEvent.Attach(player);
            keybinds.Add(new KeyInfo(Keys.Space), new SCommand());
        }

        public void Execute(Player player)
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach (KeyInfo keyIndi in keybinds.Keys)
            {
                if (keyState.IsKeyDown(keyIndi.Key))
                {
                    keybinds[keyIndi].Execute(player);
                    buttonEvent.Notify(keyIndi.Key, BUTTONSTATE.DOWN);
                    keyIndi.IsDown = true;
                }
                if (!keyState.IsKeyDown(keyIndi.Key) && keyIndi.IsDown == true)
                {
                    buttonEvent.Notify(keyIndi.Key, BUTTONSTATE.UP);
                }
            }
        }

    }
    public class KeyInfo
    {
        public bool IsDown { get; set; }

        public Keys Key { get; set; }

        public KeyInfo(Keys key)
        {
            this.Key = key;
        }
    }

}
