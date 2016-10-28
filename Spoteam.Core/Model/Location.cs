namespace Spoteam.Core.Model {
    public class Location {
        public int id { get; set; }
        public string name { get; set; }
        public string nfc { get; set; }

        public Location(int id, string name, string nfc) {
            this.id = id;
            this.name = name;
            this.nfc = nfc;
        }
    }
}