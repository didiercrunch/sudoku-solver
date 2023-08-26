namespace SudokuSolver;

using System;

public class EntryPoint{
    public static void Main(string[] args){
        foreach (var x in System.Environment.GetEnvironmentVariables()){
            Console.WriteLine(x);
        }

        // It might be necessary to modify path.
        RawSudokuGrid grid = RawSudokuGrid.LoadFile("../data/sudoku_001.json");
        Console.WriteLine(grid);
    }

}
