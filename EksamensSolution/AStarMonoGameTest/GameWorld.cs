using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace AStarMonoGameTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private PathFinding pathFinding = new PathFinding();
        /// <summary>
        /// En liste over GameObjects som programmet skal håndtere.
        /// </summary>
        private static List<GameObject> gameObjects = new List<GameObject>();
        /// <summary>
        /// En liste over alle de Nodes som udgør grid, banen.
        /// Skal bruges når vi anvender Astar, så den kan afsøge banen.
        /// </summary>
        public static Node[,] nodes = new Node[10, 10];


        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static float scale = 3f;
        public static float cellSize = 32*scale;

        public static Texture2D tile;
        public static Texture2D start;
        public static Texture2D wall;
        public static Texture2D enemy;
        public static Texture2D pathSprite;
        public static SpriteFont spriteFont;


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 1000;
     
            graphics.ApplyChanges();

            // TODO: Add your initialization logic here

            //Nested for-loop bruger vi for at kunne tegne et grid der er 10x10 felter (fra 0 til 9).
            //Her skal vi bruge vores nodes[,] array.
            //Vi gør det i initialize, så banen er lagt op før alt andet i spillet.
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    //Vi skal definerer variablerne her, så vi kan indsætte den i tmp til sidst.
                    //Det sparer bare nogle linjer kode.
                    NodeType type;
                    bool walkable;

                    //Hvor skal fjenden placeres (Start Node).
                    if (x == 5 && y == 5)
                    {
                        type = NodeType.Enemy;
                        walkable = true;
                    }

                    //Hvor skal målet placeres (End Node).
                    else if (x == 9 && y == 9)
                    {
                        type = NodeType.Goal;
                        walkable = true;
                    }

                    //Hvor skal der være tårne (ikke-walkables)?
                    else if (x == 7 && (y == 4 || y == 5 || y == 6 || y == 7 || y == 9))
                    {
                        type = NodeType.Tower;
                        walkable = false;
                    }

                    //De resterende felter i grid skal være tomme pladser.
                    else 
                    {
                        type = NodeType.Empty;
                        walkable = true;
                    }

                    //Hver plads i grid får sin egen instans af Node.
                    Node tmp = new Node(new Vector2(x * cellSize, y * cellSize), type, walkable);

                    gameObjects.Add(tmp);
                    //Og vi tilføjer denne node til arrayet af nodes, så vi kan undersøge dem,
                    //og holde styr på dem.
                    nodes[x, y] = tmp;
                }
            }
           
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Nu kan vi så loade sprites de Nodes og spritefonts som er defineret.
            tile = Content.Load<Texture2D>("Tile");
            wall = Content.Load<Texture2D>("TileWall");
            start = Content.Load<Texture2D>("TileStart");
            enemy = Content.Load<Texture2D>("TileEnemy");
            pathSprite = Content.Load<Texture2D>("TilePath");
            spriteFont = Content.Load<SpriteFont>("info");

            foreach (GameObject gO in gameObjects)
            {
                gO.LoadContent(Content);
            }

            //Vi definerer en midlertidig Start og Goal Node.
            //Således kan vi tjekke vores gameobjects og fine de nodes, 
            //som er Start og Goal. Derefter kan vi sætte de midlertidige til disse,
            //og indsætte dem i vores FindPath-metode.
            //Vi er nødt til at definere dem først, og så omdefinere dem i foreach,
            //ellers giver det en fejl pga unassigned variable i FindPath.
            Node tmpStart = new Node(new Vector2(5, 5), NodeType.Empty, true);
            Node tmpGoal = new Node(new Vector2(9, 9), NodeType.Empty, true);

            foreach (Node nO in gameObjects)
            {
                if (nO.Type == NodeType.Enemy)
                {
                    tmpStart = nO;
                }
                else if (nO.Type == NodeType.Goal)
                {
                    tmpGoal = nO;
                }
            }

            pathFinding.FindPath(tmpStart, tmpGoal);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Dette sørger bare for at vi kan gå ud af spillet igen.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here

            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            foreach (GameObject gO in gameObjects)
            {    
                gO.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
