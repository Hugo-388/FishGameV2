using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FishGameV2;

public class myGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    
    private Menu _menu;
    
    public myGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        
        Window.AllowUserResizing = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

      
        _menu = new Menu();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

      
        _menu.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.F11))
        {
            _graphics.ToggleFullScreen();
        }

        MouseState currentMouseState = Mouse.GetState();
        
        MenuAction action = _menu.Update(gameTime, currentMouseState, GraphicsDevice);
        
        switch (action)
        {
            case MenuAction.Play:
                //TODO Lancer le jeux
                break;
                
            case MenuAction.Exit:
                Exit();
                break;
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        
        _menu.Draw(_spriteBatch, GraphicsDevice);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}