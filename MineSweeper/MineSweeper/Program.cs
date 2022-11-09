using System;
using System.Collections.Generic;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playing = true;
            NewCell cell00 = new NewCell();
            NewCell cell01 = new NewCell();
            NewCell cell10 = new NewCell();
            NewCell cell11 = new NewCell();
            //Let's connect the cells
            cell00.connectTo(cell01,Direction.E);
            cell00.connectTo(cell11, Direction.SE);
            cell00.connectTo(cell10, Direction.S);
            cell01.connectTo(cell01, Direction.SW);
            cell01.connectTo(cell11, Direction.S);
            cell10.connectTo(cell11, Direction.E);

            /**
            cell00.AddNeighbor(Direction.E, cell01);
            cell00.AddNeighbor(Direction.SE, cell11);
            cell00.AddNeighbor(Direction.S, cell10);
            cell01.AddNeighbor(Direction.W, cell00);
            cell01.AddNeighbor(Direction.SW, cell10);
            cell01.AddNeighbor(Direction.S, cell11);
            cell11.AddNeighbor(Direction.NW, cell00);

            cell11.AddNeighbor(Direction.N, cell01);
            cell11.AddNeighbor(Direction.W, cell10);
            cell10.AddNeighbor(Direction.N, cell00);
            cell10.AddNeighbor(Direction.NE, cell01);
            cell10.AddNeighbor(Direction.E, cell11);
    */
            //place a mine
            cell11.Mine = new Mine();
            cell00.updateMineCount();
            NewMineSweeper ms = new NewMineSweeper(cell00);
            while(playing)
            {
                Console.WriteLine("Please, enter your choice");
                Console.WriteLine("1. Uncover cell");
                Console.WriteLine("2. Mark cell");
                Console.WriteLine("3. Quit");
                Console.WriteLine(ms);
                string inputLine = Console.ReadLine();
                int choice = Convert.ToInt32(inputLine);
                int inputRow, inputColumn;
                bool steppedOnMine = false;
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Please, enter the column number:");
                        inputLine = Console.ReadLine();
                        inputColumn = Convert.ToInt32(inputLine);
                        Console.WriteLine("Please, enter the row number:");
                        inputLine = Console.ReadLine();
                        inputRow = Convert.ToInt32(inputLine);
                        steppedOnMine = ms.uncover(inputColumn, inputRow);
                        break;
                    case 2:
                        Console.WriteLine("Please, enter the column number:");
                        inputLine = Console.ReadLine();
                        inputColumn = Convert.ToInt32(inputLine);
                        Console.WriteLine("Please, enter the row number:");
                        inputLine = Console.ReadLine();
                        inputRow = Convert.ToInt32(inputLine);
                        ms.mark(inputColumn, inputRow);
                        break;
                    case 3:
                        Console.WriteLine("Thank you for playing");
                        playing = false;
                        break;
                    default:
                        break;
                }
                if(steppedOnMine)
                {
                    Console.WriteLine("You stepped on a mine. Sorry, game over. You are a loser.");
                    playing = false;
                }
            }
        }
    }

    enum MineState { Armed, Exploded }
    enum Direction { NW, N, NE, E, SE, S, SW, W}

    static class Extensions
    {
        public static Direction Opposite(this Direction direction)
        {
            Direction returnValue = Direction.E;
            switch(direction)
            {
                case Direction.NW:
                    returnValue = Direction.SE;
                    break;
                case Direction.N:
                    returnValue = Direction.S;
                    break;
                case Direction.NE:
                    returnValue = Direction.SW;
                    break;
                case Direction.E:
                    returnValue = Direction.W;
                    break;
                case Direction.SE:
                    returnValue = Direction.NW;
                    break;
                case Direction.S:
                    returnValue = Direction.N;
                    break;
                case Direction.SW:
                    returnValue = Direction.NE;
                    break;
                case Direction.W:
                    returnValue = Direction.E;
                    break;

            }
            return returnValue;
        }
    }

    class Mine
    {
        public MineState State { get; set; }

        public Mine()
        {
            State = MineState.Armed;
        }
    }

    enum CellState { Covered, Marked, Uncovered }
    class Cell
    {
        public int MineCount { get; set; }
        public CellState State { get; private set; }
        public Mine Mine { get; set; }

        public Cell()
        {
            reset();
            //MineCount = 0;
            //State = CellState.Covered;
            //Mine = null;
        }

        public void mark()
        {
            switch(State)
            {
                case CellState.Covered:
                    State = CellState.Marked;
                    break;
                case CellState.Marked:
                    State = CellState.Covered;
                    break;
                case CellState.Uncovered:
                    break;
            }
        }

        public bool uncover()
        {
            bool returnValue = false;
            switch(State)
            {
                case CellState.Covered:
                    State = CellState.Uncovered;
                    returnValue = Mine != null;
                    break;
                case CellState.Marked:
                    break;
                case CellState.Uncovered:
                    break;
            }
            return returnValue;
        }

        public void reset()
        {
            MineCount = 0;
            State = CellState.Covered;
            Mine = null;
        }

        override
        public string ToString()
        {
            string output = "";
            switch(State)
            {
                case CellState.Covered:
                    output = "_";
                    break;
                case CellState.Marked:
                    output = "!";
                    break;
                case CellState.Uncovered:
                    if(Mine != null)
                    {
                        output = "M";
                    }
                    else
                    {
                        if(MineCount > 0)
                        {
                            output = "" + MineCount;
                        }
                        else
                        {
                            output = " ";
                        }
                    }
                    break;
            }
            return output;
        }
    }

    class MineSweeper
    {
        public int NumberOfMines { get; set; }
        private Cell[,] grid;
        private Queue<Mine> minesQueue;

        public MineSweeper() : this(10, 10, 10)
        {

        }

        // Designated Constructor
        public MineSweeper(int numberOfMines, int width, int height)
        {
            NumberOfMines = numberOfMines;
            grid = new Cell[width, height];
            for(int row = 0; row < height; row++)
            {
                for(int column = 0; column < width; column++)
                {
                    grid[column, row] = new Cell();
                }
            }
            minesQueue = new Queue<Mine>();
            for(int i = 0; i < NumberOfMines; i++)
            {
                minesQueue.Enqueue(new Mine());
            }

            reset();

            // Update MineCount
        }

        public void reset()
        {
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                for (int column = 0; column < grid.GetLength(0); column++)
                {
                    if(grid[column, row].Mine != null)
                    {
                        minesQueue.Enqueue(grid[column, row].Mine);
                    }
                    grid[column, row].reset();
                }
            }

            // Randomly place the mines
            //int minesNotPlaced = NumberOfMines;
            Random random = new Random();
            while (minesQueue.Count > 0)
            {
                int row = random.Next(0, grid.GetLength(1));
                int col = random.Next(0, grid.GetLength(0));
                if (grid[col, row].Mine == null)
                {
                    grid[col, row].Mine = minesQueue.Dequeue();// new Mine();
                    //minesNotPlaced--;
                    //Console.WriteLine("About to update count for " + col + ", " + row + " = " + grid[col, row]);
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            try
                            {
                                //Console.WriteLine("" + c + ", " + r);
                                grid[c, r].MineCount++;
                            }
                            catch (IndexOutOfRangeException)
                            {

                            }
                        }
                    }
                }
            }

        }

        public bool uncover(int col, int row)
        {
            bool result = false;
            bool outOfRange = false;
            try
            {
                result = grid[col, row].uncover();
            }
            catch (IndexOutOfRangeException)
            {
                outOfRange = true;
            }
            if (!outOfRange && grid[col, row].MineCount == 0)
            {
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        try
                        {
                            if (grid[c, r].State == CellState.Covered)
                            {
                                uncover(c, r);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {

                        }
                    }
                }
            }

            return result;
        }

        public void mark(int col, int row)
        {
            try
            {
                grid[col, row].mark();
            }
            catch(IndexOutOfRangeException)
            {

            }

        }

        override
        public string ToString()
        {
            string output = "";
            for (int row = 0; row < grid.GetLength(1); row++)
            {
                for (int column = 0; column < grid.GetLength(0); column++)
                {
                    output += "|" + grid[column, row];
                }
                output += "|\n";
            }
            return output;
        }
    }

    class NewCell
    {
        public int MineCount { get; set; }
        public CellState State { get; private set; }
        public Mine Mine { get; set; }
        private Dictionary<Direction, NewCell>neighbors;
        public NewCell()
        {
            neighbors = new Dictionary<Direction, NewCell>();
            reset();
        }
        public void AddNeighbor(Direction direction, NewCell neighbor)
        {
            neighbors[direction] = neighbor;
        }
        public bool uncover()
        {
            bool returnValue = false;
            switch (State)
            {
                case CellState.Covered:
                    State = CellState.Uncovered;
                    returnValue = Mine != null;
                    if(!returnValue)
                    {
                        if(MineCount == 0)
                        {
                            foreach(NewCell Cell in neighbors.Values)
                            {
                                Cell.uncover();
                            }
                        }
                    }
                    break;
                case CellState.Marked:
                    break;
                case CellState.Uncovered:
                    break;
            }
            return returnValue;
        }

        public bool uncover(int col, int row)
        {
            NewCell cell = findCell(col, row);
            if(cell != null)
            {
                return cell.uncover();
            }
            else
            {
                return false;
            }
            if(col == 0 && row == 0)
            {
                return uncover();
            }
            else
            {
                if(col != 0)
                {
                    //continue East
                    //eastNeigbor.uncover(col - 1, row);
                    NewCell eastNeighbor;
                    if(neighbors.TryGetValue(Direction.E, out eastNeighbor))
                    {
                        return eastNeighbor.uncover(col - 1, row);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    //continue South
                    //southNeighbor.uncover(col, row - 1);
                    NewCell southNeighbor;
                    if(neighbors.TryGetValue(Direction.S, out southNeighbor))
                    {
                        return southNeighbor.uncover(col, row - 1);
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }
        public void mark()
        {
            switch (State)
            {
                case CellState.Covered:
                    State = CellState.Marked;
                    break;
                case CellState.Marked:
                    State = CellState.Covered;
                    break;
                case CellState.Uncovered:
                    break;
            }
        }

        public void mark(int col, int row)
        {
            NewCell cell = findCell(col, row);
            if(cell != null)
            {
                cell.mark();
            }
        }

        private NewCell findCell(int col, int row)
        {
            if (col == 0 && row == 0)
            {
                return this;
            }
            else
            {
                if (col != 0)
                {
                    //continue East
                    //eastNeigbor.uncover(col - 1, row);
                    NewCell eastNeighbor;
                    if (neighbors.TryGetValue(Direction.E, out eastNeighbor))
                    {
                        return eastNeighbor.findCell(col - 1, row);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    //continue South
                    //southNeighbor.uncover(col, row - 1);
                    NewCell southNeighbor;
                    if (neighbors.TryGetValue(Direction.S, out southNeighbor))
                    {
                        return southNeighbor.findCell(col, row - 1);
                    }
                    else
                    {
                        return null;
                    }
                }

            }
        }

        public int countMines(Direction direction)
        {
            switch(direction)
            {
                case Direction.E:
                    NewCell eastNeighbor;
                    if(neighbors.TryGetValue(direction, out eastNeighbor))
                    {
                        return Mine == null ? 0 : 1 + eastNeighbor.countMines(direction);
                    }
                    else
                    {
                        NewCell southNeighbor;
                        if (neighbors.TryGetValue(Direction.S, out southNeighbor))
                        {
                            return Mine == null ? 0 : 1 + southNeighbor.countMines(Direction.W);
                        }  
                        else
                        {
                            return Mine == null ? 0 : 1;
                        }
                    }
                    //break;
                case Direction.W:
                    NewCell westNeighbor;
                    if (neighbors.TryGetValue(direction, out westNeighbor))
                    {
                        return Mine == null ? 0 : 1 + westNeighbor.countMines(direction);
                    }
                    else
                    {
                        NewCell southNeighbor;
                        if (neighbors.TryGetValue(Direction.S, out southNeighbor))
                        {
                            return Mine == null ? 0 : 1 + southNeighbor.countMines(Direction.E);
                        }
                        else
                        {
                            return Mine == null ? 0 : 1;
                        }
                    }
                    //break;
                default:
                    return 0;
                    break;
            }
        }

        public void updateMineCount()
        {
            switch(State)
            {
                case CellState.Covered:
                    break;
                case CellState.Uncovered:
                    State = CellState.Covered;
                    foreach (NewCell cell in neighbors.Values)
                    {
                        if (cell.Mine != null)
                        {
                            MineCount++;
                        }
                        cell.updateMineCount();
                    }
                    break;
                case CellState.Marked:
                    break;

            }
   
        }

  

        public void reset()
        {
            MineCount = 0;
            State = CellState.Uncovered;
            Mine = null;
        }
        override
     public string ToString()
        {
            string output = "";
            switch (State)
            {
                case CellState.Covered:
                    output = "_";
                    break;
                case CellState.Marked:
                    output = "!";
                    break;
                case CellState.Uncovered:
                    if (Mine != null)
                    {
                        output = "M";
                    }
                    else
                    {
                        if (MineCount > 0)
                        {
                            output = "" + MineCount;
                        }
                        else
                        {
                            output = " ";
                        }
                    }
                    break;
            }
            return output;
        }

        public string print()
        {
            string output = this.printEast();
            NewCell southNeighbor;
            if(neighbors.TryGetValue(Direction.S, out southNeighbor))
            {
                output += "\n" + southNeighbor.print();
            }
            return output;
        }

        public string printEast()
        {
            NewCell eastNeighbor;
            if(neighbors.TryGetValue(Direction.E, out eastNeighbor))
            {
                return "|" + ToString() + eastNeighbor.printEast();
            }
            else
            {
                return "|" + ToString() + "|";
            }
        }

        public void connectTo(NewCell toCell, Direction direction)
        {
            //this.AddNeighbor(direction, toCell);
            //toCell.AddNeighbor(direction.Opposite(), this);
            NewCell.connectCells(this, toCell, direction);
        }

        public static void connectCells(NewCell fromCell, NewCell toCell, Direction direction)
        {
            fromCell.AddNeighbor(direction, toCell);
            toCell.AddNeighbor(direction.Opposite(), fromCell);
        }


    }


    
    class NewMineSweeper
    {
        private NewCell entry;


        public NewMineSweeper(NewCell entrance)
        {
            entry = entrance;
        }

        public bool uncover(int col, int row)
        {
            return entry.uncover(col, row);
        }

        public void mark(int col, int row)
        {
            entry.mark(col, row);
        }

        override
        public string ToString()
        {
            return entry.print();
        }

    }

}
