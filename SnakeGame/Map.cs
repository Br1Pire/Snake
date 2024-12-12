namespace SnakeGame;

public class Map
{
    public int Height {get;}
    public int Width {get;}
    Snake snake; 
    Dictionary<(int,int),Node> elements;
    public bool obstacleHit{get;}
    public bool foodHit{get;}
    Node? objetive{get; set;}

    

    public Map(int height, int width, Snake snake, Dictionary<(int,int),Node> elements){
        Height = height;
        Width = width;
        this.snake = snake;
        this.elements = elements;
    }

    public void CheckColition(){
        var aux = (snake.X,snake.Y);
        
        if(elements.TryGetValue(aux, out var node))
        {
            objetive = node;
            return;
        }

        objetive = null;
    }

    public void FixSnakePosition(){
        if(snake.X == Width) snake.X = 0;
        if(snake.Y == Height) snake.Y = 0;
        if(snake.X < 0) snake.X = Width-1;
        if(snake.Y < 0) snake.Y = Height-1;
    }

}