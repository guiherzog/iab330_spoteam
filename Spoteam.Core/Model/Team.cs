namespace Spoteam.Core.Model {
    public class Team {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string nfc { get; set; }

        public Team(int id, string name, string img, string nfc) {
            this.id = id;
            this.name = name;
            this.img = img;
            this.nfc = nfc;
        }
    }
}