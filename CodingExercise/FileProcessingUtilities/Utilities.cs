using System.Text.RegularExpressions;

namespace FileProcessing
{
    public static class Utilities
    {
        public static string GetSmallestDifferenceLabel(string fileName, int labelIndex, int upperIndex, int lowerIndex)
        {
            var fileData = GetFileData(fileName);

            var parsedData = GetParsedData(fileData, labelIndex, upperIndex, lowerIndex);

            return parsedData.OrderBy(f => f.Difference).First().Label;
        }

        private static string[] GetFileData(string fileName)
        {
            var fileFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(fileFolder, fileName);

            return File.ReadAllLines(filePath);
        }

        private static List<ParsedData> GetParsedData(string[] fileData, int labelIndex, int upperIndex, int lowerIndex)
        {
            var parsedData = new List<ParsedData>();

            for (int i = 1; i < fileData.Length; i++)
            {
                var values = Regex.Split(fileData[i].Trim(), @"\s+");

                if (values.Length > Math.Max(upperIndex, lowerIndex))
                {
                    var data = new ParsedData
                    {
                        Label = values[labelIndex],
                        Upper = ParseInt(values[upperIndex]),
                        Lower = ParseInt(values[lowerIndex]),
                    };

                    data.Difference = Math.Abs(data.Upper - data.Lower);

                    parsedData.Add(data);
                }
            }

            return parsedData;
        }

        private static int ParseInt(string value)
        {
            return int.Parse(Regex.Replace(value, @"\D", string.Empty));
        }
    }
}