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
            if (value != "white" || value != "black" || value != "name")
                throw new ArgumentException($"Error 1: Invalid argument 1 {value}. Argument only accepts values 'black', 'white' or 'name.' Please try again.");

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

    private readonly char[] validCharacters = "ZBMJSDCGzbmjsdcg.#".ToCharArray();

    protected Square[,] board;
    private readonly int ROWS, COLS = 9;
    public Square[,] Board
    {
        get => board;
        set
        {
            board = new Square[ROWS, COLS];
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
                                throw new ArgumentException($"Error 6: The character {line[col]} was found in line {row + 1}" +
                                                            $"and is an invalid character. Please try a new file or edit the existing one.");
                            }

                            board[row, col].SetSquare(line[col]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error 4: The file at path {PathToReadIn} could not be opened. This file may be the wrong type or corrupted, please try a new file.");
                throw;
            }
        }
    }

    public void initBoard()
    {
        foreach (Square square in Board)
        {
            
        }
    }
    
    public void updateBoard()
    {
        
    }
}