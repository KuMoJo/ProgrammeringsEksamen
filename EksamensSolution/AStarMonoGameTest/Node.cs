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
    /// <summary>
    /// Definerer hvilken type denne Node er.
    /// </summary>
    public enum NodeType { Empty, Enemy, Start, Goal, Tower}

    /// <summary>
    /// De Nodes som udgør det grid som Astar skal køre på.
    /// </summary>
    public class Node : GameObject
    {
        public string Coordinates { get; set; }
        /// <summary>
        /// Bestemmer om den her Node er en del af en unit test.
        /// </summary>
        public bool IsTest { get; set; }
        /// <summary>
        /// Kan fjenden paserer denne Node? (Er det et Tower?)
        /// </summary>
        public bool Walkable { get; set; } = true;
        /// <summary>
        /// Hvilken type tilhører Node (Tower, Goal etc).
        /// </summary>
        public NodeType Type { get; private set; }
        /// <summary>
        /// Bruges når man skal retrace sin path til EndNode.
        /// Når man definerer naboer til en CurrentNode,
        /// så bliver CurrentNode til naboernes Parent Node.
        /// </summary>
        public Node Parent { get; set; }
        /// <summary>
        /// Prisen fra den nuværende Node til StartNode.
        /// </summary>
        public int GCost { get; set; }
        /// <summary>
        /// Prisen fra nuværende Node til EndNode (goal).
        /// </summary>
        public int HCost { get; set; }
        /// <summary>
        /// Summen af GCost og HCost.
        /// </summary>
        public int FCost { get => HCost + GCost; }


        /// <summary>
        /// Constructor for Node.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="type"></param>
        /// <param name="walkable"></param>
        public Node(Vector2 position, NodeType type, bool walkable)
        {
            tint = Color.Red;
            Position = position;
            Type = type;
            Walkable = walkable;
            IsTest = false;
        }

        /// <summary>
        /// Constructor til unit testing.
        /// </summary>
        /// <param name="type"></param>
        public Node(NodeType type, bool walkable, string coordinates)
        {
            Type = type;
            Walkable = walkable;
            IsTest = true;
            Coordinates = coordinates;
        }


        public override void LoadContent(ContentManager content)
        {
            //Bestemmer hvilken sprite der skal vises baseret på Nodes type.
            switch (Type)
            {
                case (NodeType.Empty):
                    Sprite = GameWorld.tile;
                    break;

                case (NodeType.Tower):
                    Sprite = GameWorld.wall;
                    break;

                case (NodeType.Enemy):
                    Sprite = GameWorld.enemy;
                    break;

                case (NodeType.Goal):
                    Sprite = GameWorld.start;
                    break;

                default:
                    Sprite = GameWorld.tile;
                    break;
            }     
        }


        /// <summary>
        /// Giver en simplified position, således en position kan beskrives som f.eks. 2,2,
        /// og ikke en masse pixels. Gør det også sværere at skrive positionen forkert.
        /// </summary>
        /// <returns></returns>
        public Vector2 GetCoordinate()
        {
            //Hvis position er (0,0) i pixels, så er man i hjørnet.
            //Deler man med cellsize (32, tror jeg), får man (0,0).
            //Men hvis positionen er (32,0), nummer 2 fra hjørnet, og deler man med cellsize, får man (1,0).
            return position / GameWorld.cellSize;
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            //Det her tegner bare spriten samt de fonts der viser GCost, HCost og FCost.

            spriteBatch.Draw(Sprite, Position, null, Color.Green, 0, new Vector2(0, 0), GameWorld.scale, 
                             SpriteEffects.None, 0.9f);

            spriteBatch.DrawString(GameWorld.spriteFont, $"G: {GCost}", new Vector2((Position.X+5), 
                                  (Position.Y)), Color.DarkRed, 0, Vector2.Zero, 1, SpriteEffects.None, 0.92f);

            spriteBatch.DrawString(GameWorld.spriteFont, $"H: {HCost}", new Vector2((Position.X+5), 
                                  (Position.Y+(Sprite.Height*GameWorld.scale/1.3f))), Color.DarkBlue, 0, 
                                   Vector2.Zero, 1, SpriteEffects.None, 0.92f);

            spriteBatch.DrawString(GameWorld.spriteFont, $"F: {FCost}",
                                   new Vector2((Position.X +Sprite.Width*GameWorld.scale/1.5f), 
                                  (Position.Y + (Sprite.Height * GameWorld.scale / 1.3f))), 
                                   Color.DarkGreen, 0, Vector2.Zero, 1, SpriteEffects.None, 0.92f);
        }
    }
}
