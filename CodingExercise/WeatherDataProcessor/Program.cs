using FileProcessing;

var fileName = "weather.dat";

var smallestTempSpreadDay = Utilities.GetSmallestDifferenceLabel(fileName, 0, 1, 2);

Console.WriteLine($"Day number with smallest temp spread is day {smallestTempSpreadDay}");