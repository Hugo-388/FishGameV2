using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace FishGameV2;

public enum MenuAction
{
    Play, 
    Exit   
}

public class Menu
{
    private Texture2D _map;
    private Texture2D _btnJouer;
    private Texture2D _btnQuitter;

    private Rectangle _btnJouerRect;
    private Rectangle _btnQuitterRect;
    private MouseState _previousMouseState;

    private Color _jouerColor = Color.White;
    private Color _quitterColor = Color.White;
    
    private MenuAction _menuAction;
    
    public void LoadContent(ContentManager content)
    {
        _map = content.Load<Texture2D>("Carte");
        _btnJouer = content.Load<Texture2D>("btnJouer");
        _btnQuitter = content.Load<Texture2D>("btnQuitter");
        
    }
    
    public MenuAction Update(GameTime gameTime, MouseState currentMouseState, GraphicsDevice graphicsDevice)
    {
        int screenWidth = graphicsDevice.Viewport.Width;
        int screenHeight = graphicsDevice.Viewport.Height;
        
        //Dimmension de chaque bouton
        int jouerWidth = _btnJouer.Width;
        int jouerHeight = _btnJouer.Height;
        int quitterWidth = _btnQuitter.Width;
        int quitterHeight = _btnQuitter.Height;
        
        //Calcule de la position X
        int posJouerX = (screenWidth / 2) - (jouerWidth / 2);
        int posQuitterX = (screenWidth / 2) - (quitterWidth / 2);
        
        //Calcule de la position Y 
        int posYJouer = (screenHeight / 5) - (jouerHeight / 5);
        int posYQuitter = (screenHeight) - (quitterHeight) - 20; 

        // Stocke les rectangles 
        _btnJouerRect = new Rectangle(posJouerX, posYJouer, jouerWidth, jouerHeight);
        _btnQuitterRect = new Rectangle(posQuitterX, posYQuitter, quitterWidth, quitterHeight);
        
        // Couleur des bouton
        _jouerColor = Color.White;
        _quitterColor = Color.White;

        // --- Logique Bouton Jouer ---
        if (_btnJouerRect.Contains(currentMouseState.Position))
        {
            _jouerColor = Color.LightGray;
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                _previousMouseState.LeftButton == ButtonState.Released)
            {
                _menuAction =  MenuAction.Play;
            }
        }
        
        // --- Logique Bouton Quitter ---
        if (_btnQuitterRect.Contains(currentMouseState.Position))
        {
            _quitterColor = Color.LightGray;
            if (currentMouseState.LeftButton == ButtonState.Pressed &&
                _previousMouseState.LeftButton == ButtonState.Released)
            {
                _menuAction =  MenuAction.Exit;
            }
        }
        
        _previousMouseState = currentMouseState;

        return _menuAction;
    }

    public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
    {
        spriteBatch.Draw(_map, graphicsDevice.Viewport.Bounds, Color.White);        
    
        spriteBatch.Draw(_btnJouer, _btnJouerRect, _jouerColor);
        spriteBatch.Draw(_btnQuitter, _btnQuitterRect, _quitterColor);
    }
}