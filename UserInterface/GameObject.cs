using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInterface
{
    public class GameObject
    {

        private List<Component> components = new List<Component>();

        public string Tag { get; set; }



        public Component AddComponent(Component component)
        {
            component.GameObject = this;

            components.Add(component);

            return component;
        }

        public Component GetComponent<T>() where T : Component
        {
            return components.Find(x => x.GetType() == typeof(T));
        }

        public void Awake()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Awake();
            }
        }

        public void Start()
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Start();
            }
        }

        public void Update(GameTime gameTime)
        {

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Update(gameTime);
            }

        }

        public bool HasComponent<T>() where T : Component
        {
            Component c = components.Find(x => x.GetType() == typeof(T));

            return c != null;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Draw(spriteBatch);
            }
        }


        public object Clone()
        {
            GameObject go = new GameObject();

            foreach (Component component in components)
            {
                go.AddComponent(component.Clone() as Component);
            }

            return go;
        }





    }
}
