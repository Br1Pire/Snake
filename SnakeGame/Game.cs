namespace SnakeGame;

public class Game
{
    Map map;

}

public enum Direction{
    up = 1,
    left = 2,
    down = 3,
    right = 4
}

public class Map{
    int hight;
    int width;
    Snake snake; 
    Dictionary<(int,int),Node> Elements;

}

public class Node
{
    public int X {get; protected set;}
    public int Y {get; protected set;}

    public Node(int x, int y){
        X = x;
        Y = y;
    }
}

public class Snake: Node{
    Direction newDirection;
    Direction oldDirection;
    Snake? parent;
    Snake? son;
    bool expand = false;

    public Snake(int x, int y, Direction direction,Snake? parent, Snake? son = null): base(x, y){
        newDirection = direction;
        oldDirection = direction;
        this.parent = parent;
        this.son = son;
    }

    public void Move(int height, int width){
        
        int x = 0;                      //
        int y = 0;                      //
        if(son == null && expand){      // intentar refactorizar 
            x = this.X;                 //     mas adelante
            y = this.Y;                 //
        }                               //
        
        switch(newDirection){
            case Direction.up:
                Y = ((Y - 1) + height) % height;
                break;
            case Direction.down:
                Y = (Y + 1) % width;
                break;
            case Direction.left:
                X = ((X - 1) + height) % height;
                break;
            case Direction.right:
                X = (X + 1) % width;
                break;
        }
        oldDirection = newDirection;
        // if(parent == null){
        //     if(son != null) son.Move();
        //     else return;
        // }
        // else
        // {
        //     newDirection = parent.oldDirection;
        //     if(son != null) son.Move();
        //     else return;
        // }

        if(parent != null) newDirection = parent.oldDirection;
        if(son != null) son.Move(height, width);
        //else
        if(son == null && expand){                                //
            son = new Snake(x, y, oldDirection, this);            //  intentar refactorizar 
            expand = false;                                       //      mas adelante
        }                                                         //
        return;
    }

    public void Expand(){
        expand = true;
        return;
        
    }


}

public class Obstacle:Node{

    public Obstacle(int x, int y): base(x, y){
    }

}

public class Food:Node{

    public Food(int x, int y): base(x, y){
    }

}
