namespace SnakeGame;

public class Snake:Node
{
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
        
        // switch(newDirection){
        //     case Direction.up:
        //         Y = ((Y - 1) + height) % height;
        //         break;
        //     case Direction.down:
        //         Y = (Y + 1) % width;
        //         break;
        //     case Direction.left:
        //         X = ((X - 1) + height) % height;
        //         break;
        //     case Direction.right:
        //         X = (X + 1) % width;
        //         break;
        // }P

         switch(newDirection){
            case Direction.up:
                Y -= 1 ;
                break;
            case Direction.down:
                Y += 1 ;
                break;
            case Direction.left:
                X -= 1 ;
                break;
            case Direction.right:
                X += 1 ;
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