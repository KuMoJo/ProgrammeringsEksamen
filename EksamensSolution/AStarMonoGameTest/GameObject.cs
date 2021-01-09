using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarMonoGameTest
{
    public abstract class GameObject
    {
        protected Color tint = Color.White;

        private Texture2D sprite;

        protected Vector2 position;

        public Vector2 Position { get => position; set => position = value; }
        public  Color Tint { get => tint; set => tint = value; }
        public Texture2D Sprite { get => sprite; set => sprite = value; }

        public abstract void LoadContent(ContentManager content);

        //public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, null, Color.White, 0, new Vector2(0, 0), GameWorld.scale, SpriteEffects.None, 1);
        }
    }
}
