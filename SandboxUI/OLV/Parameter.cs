using System.ComponentModel;

namespace OLV
{
    public class Parameter
    {
        public enum Alignment
        {
            Single,
            Rotational,
            Null
        }

        private Alignment _AlignmentSelection;
        [
            Category("User Parameters"),
            Description("Single or Rotational"),
            DisplayName("Alignment Selection")
        ]
        public Alignment AlignmentSelection
        {
            get => _AlignmentSelection;
            set
            {
                _AlignmentSelection = value;
            }
        }

        public enum RotationalAlignment
        {
            Horizontal,
            Vertical
        }

        private RotationalAlignment _RotationalAlignmentSelection;
        [
            Category("User Parameters"),
            Description("Vertical or Horizontal"),
            DisplayName("Rotational Selection")
        ]
        public RotationalAlignment RotationalAlignmentSelection
        {
            get => _RotationalAlignmentSelection;
            set
            {
                _RotationalAlignmentSelection = value;
            }
        }

        private bool _Locked;
        [
            Category("User Parameters"),
            Description("Enable Parameter")
        ]
        public bool Locked
        {
            get => _Locked;
            set
            {
                _Locked = value;
                ParameterIcon = _Locked ? "locked" : _Enable ? _AutoEnable ? "doublecheck" : "check" : "null";
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
                ParameterIcon = _Locked ? "locked" : _Enable ? _AutoEnable ? "doublecheck" : "check" : "null";
            }
        }

        private bool _AutoEnable;
        [
            Category("User Parameters"),
            Description("Enable Parameter")
        ]
        public bool AutoEnable
        {
            get => _AutoEnable;
            set
            {
                _AutoEnable = value;
                ParameterIcon = _Locked ? "locked" : _Enable ? _AutoEnable ? "doublecheck" : "check" : "null";
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
        public string AlignmentIcon 
        {
            get
            {
                switch (_AlignmentSelection)
                {
                    case Alignment.Single:
                        return "single";
                    case Alignment.Rotational:
                        return _RotationalAlignmentSelection.ToString();
                    case Alignment.Null:
                        return "null";
                    default:
                        return "null";
                }
            }
        }

        public Parameter(
            string ParameterName,
            string Description = "Sample Description",
            bool Enable = false,
            bool Cycle = false,
            int Frequency = 1,
            Alignment AlignmentSelection = Alignment.Null,
            RotationalAlignment RotationalAlignmentSelection = RotationalAlignment.Horizontal)
        {
            this.ParameterName = ParameterName;
            this.Description = Description;
            this.Enable = Enable;
            this.Cycle = Cycle;
            this.Frequency = Frequency;
            this.AlignmentSelection = AlignmentSelection;
            this.RotationalAlignmentSelection = RotationalAlignmentSelection;
        }
    }
}
