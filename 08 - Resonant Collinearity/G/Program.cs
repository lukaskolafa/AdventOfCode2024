using aoc;

bool test = false;

string[] input = File.ReadAllLines(test ? @"..\..\..\test.txt" : @"..\..\..\input.txt");

var height = input.Length;
var width = input[0].Length;

bool[,] antiNodes = new bool[height, width];

var beacons = new Dictionary<char, IList<Coordinates>>();

for (int h = 0; h < height; h++)
{
    for (int w = 0; w < width; w++)
    {
        char c = input[h][w];
        
        if (c == '.')
        {
            continue;
        }

        if (!beacons.TryGetValue(c, out var beaconsList))
        {
            beaconsList = new List<Coordinates>();
            beacons.Add(c, beaconsList);
        }
        
        beaconsList.Add(new Coordinates(h, w));
    }
}

var result = 0;

foreach (var beacon in beacons)
{
    foreach (var coordinates in beacon.Value)
    {
        foreach (var pairCoordinates in beacon.Value)
        {
            if (coordinates == pairCoordinates)
            {
                continue;
            }

            var dirW = pairCoordinates.W - coordinates.W;
            var dirH = pairCoordinates.H - coordinates.H;
            
            var antiNodeH = coordinates.H;
            var antiNodeW = coordinates.W;
            
            while (true)
            {
                if (antiNodeW >= 0 && antiNodeW < width && antiNodeH >= 0 && antiNodeH < height)
                {
                    if (!antiNodes[antiNodeH, antiNodeW])
                    {
                        antiNodes[antiNodeH, antiNodeW] = true;
                        result++;
                    }

                    antiNodeH += dirH;
                    antiNodeW += dirW;
                }
                else
                {
                    break;
                }
            }
        }
    }
}

Console.WriteLine(result);
