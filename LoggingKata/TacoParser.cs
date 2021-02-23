namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("Array length is less than 3");
                return null; 
            }

            double latitude = double.Parse(cells[0]);
            
            double longitude = double.Parse(cells[1]);
            
            var name = cells[2];

            var taco = new TacoBell();
            var point = new Point();
            
            point.Latitude = latitude;
            point.Longitude = longitude;

            taco.Name = name;
            taco.Location = point;

            return taco;
        }
    }
}