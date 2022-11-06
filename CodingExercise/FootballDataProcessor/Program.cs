using FileProcessing;

var fileName = "football.dat";

var smallestGoalsDifferenceTeam = Utilities.GetSmallestDifferenceLabel(fileName, 1, 6, 8);

Console.WriteLine($"Team with smallest difference between goals for and against is {smallestGoalsDifferenceTeam}");