using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public class Player : Component, IGameListner
    {



        private float speed;

 

        private Dictionary<Keys, BUTTONSTATE> movementKeys = new Dictionary<Keys, BUTTONSTATE>();


        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;





        }

        public override void Awake()
        {
            speed = 100;
        }

        public override void Start()
        {
    


        }



        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);

        }

        public void Notify(GameEvent gameEvent)
        {

            if (gameEvent is ButtonEvent)
            {
                ButtonEvent be = (gameEvent as ButtonEvent);

                movementKeys[be.Key] = be.State;


            }


        }
    }
}
