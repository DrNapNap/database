using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    class PlayerBuilder : IBuilder
    {
        private GameObject gameObject;

        public void BuildGameObject()
        {
            gameObject = new GameObject();

            BuildComponents();

        }

        private void BuildComponents()
        {
            Player p = (Player)gameObject.AddComponent(new Player());

         
        }



        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
