using System.ComponentModel;

namespace OLV
{
    public class Parameter
    {
        public enum Something
        {
            Single,
            Double,
            Triple,
            Null
        }

        private Something _Thing;
        [
            Category("User Parameters"),
            Description("Some Enum")
        ]
        public Something Thing
        {
            get => _Thing;
            set
            {
                _Thing = value;
            }
        }

        private bool _Enable;
        [
            Category("User Parameters"),
            Description("Enable Parameter")
        ]
        public bool Enable
        {
            get => _Enable;
            set
            {
                _Enable = value;
                ParameterIcon = _Enable ? "check" : "null";
            }
        }

        private bool _Cycle;
        [
            Category("User Parameters"),
            Description("Enable / Disable Cycling")
        ]
        public bool Cycle
        {
            get => _Cycle;
            set
            {
                _Cycle = value;
                FrequencyString = _Frequency > 0 && _Cycle ? _Frequency.ToString() : "";
                FrequencyIcon = _Frequency > 0 && _Cycle ? "cycle" : "";
            }
        }

        private int _Frequency;
        [
            Category("User Parameters"),
            Description("Frequency of Cycle")
        ]
        public int Frequency
        {
            get => _Frequency;
            set
            {
                _Frequency = value;
                FrequencyString = _Frequency > 0 && _Cycle ? _Frequency.ToString() : "";
                FrequencyIcon = _Frequency > 0 && _Cycle ? "cycle" : "";
            }
        }

        public string ParameterIcon { get; set; }
        public string ParameterName { get; set; }
        public string Description { get; set; }
        public string FrequencyString { get; set; } = "";
        public string FrequencyIcon { get; set; } = "";
        public string ThingIcon 
        {
            get => _Thing.ToString();
        }

        public Parameter(
            string ParameterName,
            string Description = "Sample Description",
            bool Enable = false,
            bool Cycle = false,
            int Frequency = 1,
            Something Thing = Something.Null)
        {
            this.ParameterName = ParameterName;
            this.Description = Description;
            this.Enable = Enable;
            this.Cycle = Cycle;
            this.Frequency = Frequency;
            this.Thing = Thing;
        }
    }
}
