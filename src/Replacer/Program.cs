string fullFilename = Environment.GetCommandLineArgs()[1];
string filename = Path.GetFileNameWithoutExtension(fullFilename);
string extension = Path.GetExtension(fullFilename);
string newFilename = $"{filename}-2{extension}";

if (int.TryParse(Environment.GetCommandLineArgs()[2], out int numberToReplace))
{
    try
    {
        using (var sr = File.OpenText(fullFilename))
        {
            string fullText = sr.ReadToEnd();
            string textToReplace = $";{numberToReplace};";
            string newText = $";{numberToReplace + 1};";

            fullText = fullText.Replace(textToReplace, newText);

            File.WriteAllText(newFilename, fullText);
        }
        Console.WriteLine($"{newFilename} created!");

    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
else
{
    Console.WriteLine("Invalid number");
}