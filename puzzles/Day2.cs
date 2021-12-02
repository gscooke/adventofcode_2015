internal class Day2 : BasePuzzle, IPuzzle
{
    public void Run() {
        StartPuzzleOutput(nameof(Day2));

        Console.WriteLine($" Part 1:");
        Console.WriteLine($"  Wrapping Paper Required: {Part1()}");

        Console.WriteLine($" Part 2:");
        Console.WriteLine($"  Feet of Ribbon Required: {Part2()}");
    }

    internal int Part1() {
        return InputsList.Select(e => new Parcel(e))
                         .Sum(e => e.Area);
    }

    internal int Part2() {
        return InputsList.Select(e => new Parcel(e))
                         .Sum(e => e.Ribbon);
    }
}

internal class Parcel {
    public Parcel(string dimensions) {
        var measurements = dimensions.Split('x').Select(int.Parse).ToArray();
        Length = measurements[0];
        Width = measurements[1];
        Height = measurements[2];

        Areas = new() {
            CalculateArea(Length, Width),
            CalculateArea(Width, Height),
            CalculateArea(Height, Length)
        };
    }
    public int Length { get; init; }
    public int Height { get; init; }
    public int Width { get; init; }
    private List<int> Areas { get; init; }
    private int CalculateArea(int dimension1, int dimension2) {
        return dimension1 * dimension2;
    }
    private int SmallestArea {
        get {
            return Areas.Min();
        }
    }
    public int Area { 
        get {
            return Areas.Sum(e => 2 * e)
                 + SmallestArea;
        }
    }

    public int Ribbon {
        get {
            List<int> Sides = new() {
                Length,
                Width,
                Height
            };

            var shortSides = Sides.OrderByDescending(e => e).Skip(1);

            return shortSides.Sum() * 2
                 + Bow;
        }
    }

    private int Bow {
        get {
            return Length * Width * Height;
        }
    }
}
