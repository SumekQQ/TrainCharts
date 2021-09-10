namespace TrainChart
{
    public class Station
    {
        public int Meters { get; set; }

        public string Name { get; set; }

        public bool IsStation { get; set; }

        public bool IsUsed { get; set; }

        public string Blockade { get; set; }

        public Station(int meters, string name)
        {
            Meters = meters;
            Name = name;            
        }

        public Station(int meters, string name, int isStation, string blockade)
        {
            Meters = meters;
            Name = name;
            IsStation = isStation > 0;
            Blockade = blockade;
        }
    }
}
