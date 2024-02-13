using System;
using System.Collections.Generic;
using System.Linq;

var grid = 
    "abc\n" +
    "def\n" +
    "ghj";

WordSearch ws = new WordSearch(grid);
ws.PrintGrid();
var result = ws.Search(["heb", "beh", "abc", "jhg", "db", "aej"]);
foreach (var kvp in result)
{
    Console.WriteLine($"{kvp.Key}: ({kvp.Value!.Value.Item1.Item1}, {kvp.Value!.Value.Item1.Item2}), ({kvp.Value!.Value.Item2.Item1}, {kvp.Value!.Value.Item2.Item2})");
}
Console.WriteLine("end");

public class WordSearch
{
    private char[][] _grid;
    
    public WordSearch(string grid)
    {
        _grid = grid.Split('\n').Select(s => s.ToCharArray()).ToArray();
    }

    
    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var searchResult = new Dictionary<string, ((int, int), (int, int))?>();
        for (int yCord = 0; yCord < _grid.Length; yCord++)
        {
            for (int xCord = 0; xCord < _grid[yCord].Length; xCord++)
            {
                foreach (var targetWord in wordsToSearchFor)
                {
                    var endCord = SearchInGrid(targetWord, xCord, yCord);
                    if (endCord != null)
                        searchResult[targetWord] = ((xCord, yCord), (endCord.Value.endX, endCord.Value.endY));
                }
            }
        }
        return searchResult;
    }

    private bool inBounds(int x, int y) => (y >= 0 && y < _grid.Length) && (x >= 0 && x < _grid[y].Length);
    
    private (int endX, int endY)? SearchInGrid(string target, int startX, int startY)
    {
        // to top
        for (int i = 0, y = startY; i < target.Length && y >= 0; i++, y--)
        {
            if (target[i] != _grid[y][startX]) break;
            if (i == target.Length - 1) return (startX, y);
        }
        // to bottom
        for (int i = 0, y = startY; i < target.Length && y < _grid.Length; i++, y++)
        {
            if (target[i] != _grid[y][startX]) break;
            if (i == target.Length - 1) return (startX, y);
        }
        // to right
        for (int i = 0, x = startX; i < target.Length && x < _grid[startY].Length; i++, x++)
        {
            if (target[i] != _grid[startY][x]) break;
            if (i == target.Length - 1) return (x, startY);
        }
        // to left
        for (int i = 0, x = startX; i < target.Length && x >= 0; i++, x--)
        {
            if (target[i] != _grid[startY][x]) break;
            if (i == target.Length - 1) return (x, startY);
        }
        // to top-right
        for (int i = 0, x = startX, y = startY; i < target.Length && y >= 0 && x < _grid[y].Length; i++, x++, y--)
        {
            if (target[i] != _grid[y][x]) break;
            if (i == target.Length - 1) return (x, y);
        }
        // to top-left
        for (int i = 0, x = startX, y = startY; i < target.Length && y >= 0 && x >= 0; i++, x--, y--)
        {
            if (target[i] != _grid[y][x]) break;
            if (i == target.Length - 1) return (x, y);
        }
        // to bottom-right
        for (int i = 0, x = startX, y = startY; i < target.Length && y < _grid.Length && x < _grid[y].Length; i++, x++, y++)
        {
            if (target[i] != _grid[y][x]) break;
            if (i == target.Length - 1) return (x, y);
        }
        // to bottom-left
        for (int i = 0, x = startX, y = startY; i < target.Length && y < _grid.Length && x >= 0; i++, x--, y++)
        {
            if (target[i] != _grid[y][x]) break;
            if (i == target.Length - 1) return (x, y);
        } 
        return null;
    }
    
    #region debug

    public void PrintGrid()
    {
        for (int outer = 0; outer < _grid.Length; outer++)
        {
            for (int inner = 0; inner < _grid[outer].Length; inner++)
            {
                Console.Write($" {_grid[outer][inner]}({inner},{outer})");
            }

            Console.Write('\n');
        }
    }

    #endregion
}
