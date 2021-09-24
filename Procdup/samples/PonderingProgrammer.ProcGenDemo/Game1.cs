using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.FeatureObjects;
using PonderingProgrammer.Map2d.ProcGen.Mazes;
using PonderingProgrammer.Map2d.ProcGen.Rooms;

namespace PonderingProgrammer.ProcGenDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IGridMap _map;
        private int _scale = 10;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            _map = new GridMap(40, 30);
            var settings = new BFRandRectSettings
            {
                RectWidthMin = 2,
                RectWidthMax = 6,
                RectHeightMin = 2,
                RectHeightMax = 5,
                MaxRectCount = 40,
                MaxTries = 100,
            };
            var rects = RandomRoomsGenerator.BFRandRectGenerator(_map, settings);
            var maze = RandomizedPrimMazeGenerator.GenerateMaze(_map);
            foreach (var rect in rects)
            {
                _map.AddFeature(new GridRectFeature(FeatureType.Room, rect));
            }
            _map.AddFeature(new GridPolyPointFeature(FeatureType.Passage, maze));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            MapRenderer.DrawMap(_map, _spriteBatch, _scale);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
