using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private string[] _grid;
    private int _gridRows { get => _grid.GetLength(0); }
    private int _gridColumns { get => _grid[0].Length; }
    private readonly (int x, int y)[] _directions = new[]
    {
        ( 0,-1), // up
        ( 0, 1), // down
        ( 1, 0), // right
        (-1, 0), // left
        ( 1, 1), // top-right
        (-1, 1), // top-left
        ( 1,-1), // bottom-right
        (-1,-1), // bottom-left
    };
    
    public WordSearch(string grid)
    {
        _grid = grid.Split('\n').ToArray();
    }
    
    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var searchResult = wordsToSearchFor.ToDictionary<string, string,((int, int), (int, int))?> (key => key, _ => null);
        
        for (int yCord = 0; yCord < _gridRows; yCord++)
        {
            for (int xCord = 0; xCord < _gridColumns; xCord++)
            {
                foreach (var targetWord in wordsToSearchFor)
                {
                    var endCord = SearchInGrid(targetWord, xCord, yCord);
                    if (endCord != null)
                        searchResult[targetWord] = ((xCord + 1, yCord + 1), (endCord.Value.endX + 1, endCord.Value.endY + 1));
                }
            }
        }

        return searchResult;
    }

    private bool inBounds(int x, int y) => (y >= 0 && y < _grid.Length) && (x >= 0 && x < _grid[y].Length);
    
    private (int endX, int endY)? SearchInGrid(string target, int startX, int startY)
    {
        foreach (var direction in _directions)
        {
            int i = 0, x = startX, y = startY;
            while (i < target.Length && inBounds(x, y))
            {
                if (target[i] != _grid[y][x]) break; 
                if (i == target.Length - 1) return (x, y);
                x += direction.x;
                y += direction.y;
                i++;
            }
        }
        return null;
    }
}
