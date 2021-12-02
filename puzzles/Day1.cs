internal class Day1 : BasePuzzle, IPuzzle
{
    public void Run() {
        StartPuzzleOutput(nameof(Day1));

        Console.WriteLine($" Part 1:");
        Console.WriteLine($"  Floor: {Part1()}");

        Console.WriteLine($" Part 2:");
        Console.WriteLine($"  Position: {Part2()}");
    }

    internal int Part1() {
        var up = InputsListChar.Count(e => e == '(');
        var down = InputsListChar.Count(e => e == ')');

        return up - down;
    }

    internal int Part2() {
        var chars = InputsListChar;

        int floor = 0;
        int position = 0;

        while (floor >= 0)
        {
            if (chars[position] == '(')
                floor += 1;
            else
                floor -= 1;

            position++;
        }

        return position;
    }
}