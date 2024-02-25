using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private readonly string[] _grid;
    private int GridRows { get => _grid.GetLength(0); }
    private int GridColumns { get => _grid[0].Length; }
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
    
    public WordSearch(string grid) => _grid = grid.Split('\n');

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor) =>
        wordsToSearchFor.ToDictionary(word => word, SearchForWord);

    private ((int, int), (int, int))? SearchForWord(string word) 
        => _grid
            .SelectMany((line, y) => line.Select((c, x) => (c, x, y)))
            .Where(point => 
                point.c == word[0])
            .SelectMany(point => _directions.Select(direction => SearchInGrid(word, point.x, point.y, direction)))
            .FirstOrDefault(o => o is not null);
        
    private bool IsInGrid(int x, int y) => (y >= 0 && y < GridRows) && (x >= 0 && x < GridColumns);
    
    private ((int, int), (int, int))? SearchInGrid(string word, int x, int y, (int dx, int dy) direction)
    {
        var coords = word
            .Select((c, i) => 
                (c, cx: x + i * direction.dx, cy: y + i * direction.dy))
            .ToArray();
        
        var valid = coords.All(cord => 
            IsInGrid(cord.cx, cord.cy) && cord.c == _grid[cord.cy][cord.cx]);

        if (!valid)
            return null;

        var end = coords.Last();
        return ((x + 1, y + 1), (end.cx + 1, end.cy + 1));
    }
}
