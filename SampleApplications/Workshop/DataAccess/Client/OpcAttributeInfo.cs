namespace DataAccessClient
{
    public class OpcAttributeInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }


        public OpcAttributeInfo(string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
