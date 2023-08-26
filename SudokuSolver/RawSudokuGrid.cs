using System;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace SudokuSolver;

class SerializedOuterObject
{

    [JsonPropertyName("newboard")]
    public SerializedNewBoard NewBoard { get; set; }

    public SerializedOuterObject()
    {
        this.NewBoard = new SerializedNewBoard();
    }
}

class SerializedNewBoard
{
    [JsonPropertyName("grids")]
    public List<SerializedGrid> Grid { get; set; }

    public SerializedNewBoard()
    {
        this.Grid = new List<SerializedGrid>();
    }
}


class SerializedGrid
{

    [JsonPropertyName("value")]
    public List<List<int>> Value { get; set; }

    public SerializedGrid()
    {
        this.Value = new List<List<int>>();
    }
}

public class RawSudokuGrid
{
    private readonly List<List<int>> grid;

    public List<List<int>> Grid { get { return grid; } }

    public RawSudokuGrid(List<List<int>> grid)
    {
        this.grid = grid;
    }

    public override string ToString()
    {
        string ret = "";
        foreach (List<int> row in grid)
        {
            foreach (var item in row)
            {
                ret += $"{item} ";
            }
            ret += "\n";
        }
        return ret;
    }

    public static RawSudokuGrid LoadFile(string filename)
    {
        using FileStream stream = File.OpenRead(filename);
        SerializedOuterObject ser = JsonSerializer.Deserialize<SerializedOuterObject>(stream)!;
        return new RawSudokuGrid(ser.NewBoard.Grid[0].Value);
    }
}
