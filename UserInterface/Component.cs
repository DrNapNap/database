using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UserInterface
{
    public abstract class Component
    {
        public bool IsEnabled { get; set; }
        public GameObject GameObject { get; set; }

        public virtual void Awake()
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }



    }
}
