namespace CAB201_Advance;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

public class Game_Manager
{
    private string _side;
    public string Side
    {
        get => _side;
        set
        {
            if (!(new[] { "black", "white", "name" }.Contains(value))) 
                throw new ArgumentException($"Error 1: Invalid argument 1 {value}. Argument only accepts values 'black', 'white' or 'name.' Please try again.");
            if (value == "name")
                _side = "Wario"; // Bot name, sue me Nintendo
            else
                _side = value;
        }
    }
    private readonly string _pathToReadIn;
    private string PathToReadIn
    {
        get => _pathToReadIn;
        init
        {
            if (!File.Exists(value))
                throw new ArgumentException($"Error 2: Invalid argument 2 {value}. The provided filepath does not exist. Please try again with a valid filepath.");

            _pathToReadIn = value;
        }
    }
    private string _pathToWriteOut;
    public string PathToWriteOut
    {
        get => _pathToWriteOut;
        set
        {
            if (!File.Exists(value))
                throw new ArgumentException($"Error 3: Invalid argument 3 {value}. The provided filepath does not exist. Please try again with a valid filepath.");

            _pathToWriteOut = value;
        }
    }
    public Game_Manager(string _side, string _pathToReadIn, string _pathToWriteOut)
    {
        Side = _side;
        PathToReadIn = _pathToReadIn;
        PathToWriteOut = _pathToWriteOut;
    }

    private readonly char[] validCharacters = "ZBMJSDCGzbmjsdcg.#".ToCharArray();
    
    private const int ROWS = 9;
    private const int COLS = 9;
    
    private Square[,] board = new Square[ROWS, COLS];
    private Dictionary<string, int[,]> moves = new ();

    public void SetupBoard()
    {
        try
        {
            using StreamReader reader = new (PathToReadIn);
            
            for (int row = 0; row < ROWS; row++)
            {
                string line = reader.ReadLine();
                if (line is not { Length: COLS })
                {
                    throw new ArgumentException($"Error 5: Line {row + 1} of the file at filepath {PathToReadIn} " +
                                                $"is either null or contains the incorrect number of columns. Please try a " +
                                                $"new file or edit the existing one.");
                }

                ProcessRow(line, row);
            }
        }
        catch
        {
            Console.Error.WriteLine(
                $"Error 4: The file at path {PathToReadIn} could not be opened. This file may be the wrong type or corrupted, please try a new file.");
            throw;
        }
    }

    private void ProcessRow(string line, int row)
    {
        for (int col = 0; col < COLS; col++)
        {
            if (!validCharacters.Contains(line[col]))
            {
                throw new ArgumentException(
                    $"Error 6: The character {line[col]} was found in line {row + 1}" +
                    $"and is an invalid character. Please try a new file or edit the existing one.");
            }

            char symbol = line[col];
            board[row, col] = new Square(symbol, new[] { row, col });

            if (symbol is '.' or '#') continue;

            IPiece piece = board[row, col].ThisPiece;
            string key = $"{piece.GetSide()}_{piece.GetType().Name}_{row}{col}";
            int[,] moveRange = piece.GetMoves();

            moves.TryAdd(key, moveRange);
        }
    }

    public void Play()
    {
        // To do, delegate this to the appropriate sub classes
        // This is just a test to see if the moves are being generated correctly
        foreach (KeyValuePair<string, int[,]> kvp in moves)
        {
            string key = kvp.Key;
            int[,] moveRange = kvp.Value;
            
            string[] splitKey = key.Split('_');
            string side = splitKey[0];
            string pieceType = splitKey[1];
            int row = int.Parse(splitKey[2].Substring(0, 1));
            int col = int.Parse(splitKey[2].Substring(1, 1));
    
            for (int i = 0; i < moveRange.GetLength(0); i++)
            {
                int moveRow = row + moveRange[i, 0];
                int moveCol = col + moveRange[i, 1];

                if (!Debug_IsValidMove(moveRow, moveCol)) continue;
                Square destination = board[moveRow, moveCol];
    
                if (destination.ThisPiece != null && destination.ThisPiece.GetSide() != side)
                {
                    Console.WriteLine($"The {side} {pieceType} at {row}, {col} can move " +
                                      $"to take the {destination.ThisPiece.GetSide()} {destination.ThisPiece.GetType().Name} at {moveRow}, {moveCol}.");
                    
                }
            }
        }
    }
    
    public void DebugBoard()
    {
        for (int row = 0; row < ROWS; row++)
        {
            for (int col = 0; col < COLS; col++)
            {
                Console.Write(board[row, col].Symbol);
            }
            Console.WriteLine();
        }
    }
        
    private bool Debug_IsValidMove(int row, int col)
    {
        return row >= 0 && row < ROWS && col >= 0 && col < COLS;
    }
}
    
    // Old method below, used multi-threading. Functional but realised I could
    // merge code into the board setup method and avoid re-reading the board
    
    // private static object lockObj = new object();
    // private ConcurrentDictionary<string, int[,]> moves = new ConcurrentDictionary<string, int[,]>();
    
    // public void Play()
    // {
    //     Task[] tasks = new Task[ROWS];
    //     for (int row = 0; row < ROWS; row++)
    //     {
    //         int currentRow = row;
    //
    //         tasks[row] = Task.Run(() =>
    //         {
    //             ProcessRow(currentRow);
    //         });
    //
    //     }
    //     Task.WaitAll(tasks);
    //
    //     
    //     // To do, delegate this to the appropriate sub classes
    //     // This is just a test to see if the moves are being generated correctly
    //     foreach (var kvp in moves)
    //     {
    //         string key = kvp.Key;
    //         int[,] moveRange = kvp.Value;
    //         
    //         string[] splitKey = key.Split('_');
    //         string side = splitKey[0];
    //         string pieceType = splitKey[1];
    //         int row = int.Parse(splitKey[2].Substring(0, 1));
    //         int col = int.Parse(splitKey[2].Substring(1, 1));
    //
    //         for (int i = 0; i < moveRange.GetLength(0); i++)
    //         {
    //             int moveRow = row + moveRange[i, 0];
    //             int moveCol = col + moveRange[i, 1];
    //             
    //             if (Debug_IsValidMove(moveRow, moveCol))
    //             {
    //                 Square destination = board[moveRow, moveCol];
    //
    //                 if (destination.IsOccupied && destination.ThisPiece.GetSide() != side)
    //                 {
    //                     Console.WriteLine($"The {side} {pieceType} at {row}, {col} can move " +
    //                                       $"to take the {destination.ThisPiece.GetSide()} {destination.ThisPiece.GetType().Name} at {moveRow}, {moveCol}.");
    //                 }
    //             }
    //         }
    //     }
    //     
    //     Console.WriteLine("All tasks completed.");
    // }
    //
    // private void ProcessRow(int row)
    // {
    //     for (int col = 0; col < COLS; col++)
    //     {
    //         char sym = board[row, col].Symbol;
    //         if (sym != '.' && sym != '#')
    //         {
    //             IPiece piece = board[row, col].ThisPiece;
    //             string key = $"{piece.GetSide()}_{piece.GetType().Name}_{row}{col}";
    //             int[,] moveRange = piece.GetMoves();
    //
    //             lock (lockObj)
    //             {
    //                 // Console.WriteLine($"Adding {key} to dictionary.");
    //                 moves.TryAdd(key, moveRange);
    //             }
    //         }
    //     }
    // }
