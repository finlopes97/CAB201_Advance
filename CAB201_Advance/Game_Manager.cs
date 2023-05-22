using System.Diagnostics;
using System.Drawing;

namespace CAB201_Advance;

using System;
using System.IO;
using System.Linq;

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
            {
                _side = "Wario"; // Bot name
            }
            _side = value;
        }
    }

    private string _pathToReadIn;

    public string PathToReadIn
    {
        get => _pathToReadIn;
        set
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
    
    /// <summary>
    /// Defined below is an array of valid characters that can be used to compare against lines read from the input file
    /// to determine the validity of each character in the line. This is to ensure that no unknown characters are entered into
    /// the board matrix. Some static variables are also used to control the size of the board to ensure the correct size. Finally,
    /// create the board with the default parameters.
    ///
    /// Then read in a file line by line, and each line by character. If the symbol at the specific matrix location is
    /// deemed appropriate, declare a new square object at the coordinates and and subsequently update the square
    /// with the appropriate information so that it can be used to define the correct piece later on.
    /// </summary>
    private readonly char[] validCharacters = "ZBMJSDCGzbmjsdcg.#".ToCharArray();
    private static int ROWS = 9;
    private static int COLS = 9;
    private Square[,] board = new Square[ROWS, COLS];

    public void SetupBoard()
    {
        try
        {
            using (StreamReader reader = new StreamReader(PathToReadIn))
            {
                for (int row = 0; row < ROWS; row++)
                {
                    string line = reader.ReadLine();
                    if (line == null || line.Length != COLS)
                    {
                        throw new ArgumentException($"Error 5: Line {row + 1} of the file at filepath {PathToReadIn} " +
                                                    $"is either null or contains the incorrect number of columns. Please try a " +
                                                    $"new file or edit the existing one.");
                    }

                    for (int col = 0; col < COLS; col++)
                    {
                        if (!validCharacters.Contains(line[col]))
                        {
                            throw new ArgumentException(
                                $"Error 6: The character {line[col]} was found in line {row + 1}" +
                                $"and is an invalid character. Please try a new file or edit the existing one.");
                        }
                        char symbol = line[col];
                        board[row, col] = new Square();
                        board[row, col].UpdateSquareInfo(symbol, col, row);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(
                $"Error 4: The file at path {PathToReadIn} could not be opened. This file may be the wrong type or corrupted, please try a new file.");
            throw;
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
}