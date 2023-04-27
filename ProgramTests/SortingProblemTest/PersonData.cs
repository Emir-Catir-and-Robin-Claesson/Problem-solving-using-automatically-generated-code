using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SortingProblemTest
{
    public record PersonData
    {
        private static Random rnd = new Random();

        public string Name { get; set; } = string.Empty;
        public string HomeTown { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public PersonData()
        {
            Name = names[rnd.Next(0, names.Length)];
            HomeTown = towns[rnd.Next(0, towns.Length)];
            Age = rnd.Next(20, 75);
            Height = rnd.Next(150, 200);
            Weight = rnd.Next(50, 100);
        }

        public PersonData(string inputData)
        {
            var data = inputData.TrimEnd().Split(' ');

            Name = data[0];
            HomeTown = data[4];
            Age = int.Parse(data[1]);
            Height = int.Parse(data[3]);
            Weight = int.Parse(data[2]);
        }


        public override string ToString()
        {
            return $"{Name} {Age} {Weight} {Height} {HomeTown}";
        }

        private static string[] names = {   "Alice", "Maja", "Verra", "Alma", "Selma", "Lilly", "Ella", "Astrid", "Wilma",
                                            "Noah", "William", "Liam", "Hugo", "Lucas", "Adam", "Oliver", "Matteo", "Frans", "Elias",
                                            "Ellie", "Love", "Malte", "Ines", "Harry", "Ebba", "Otto", "Elsa", "Robin", "Emir",
                                            "Signe", "Iris", "Leah", "Saga", "Max", "Walter", "Filip", "Erik", "Viktor", "Albin",
                                            "Julia", "Emma", "Sandra", "Hanna", "Elin", "Linnea", "Amanda", "Ida", "Matlida", "Sara",
                                            "Felicia", "Emilia", "Klara", "Josefine", "Alva", "Rebecca", "Oscar", "Alexander", "Ahmed", "Alfred",
                                            "Arvid", "Carl", "Niklas", "Joakim", "Gabriel", "Patrik", "Adrian", "Kim", "Vincent", "Kalle",
                                            "Clara", "Tove", "Frida", "Lovisa", "Lisa", "Fanny", "Cornelia", "Madelene", "Caroline", "Tilda",
                                            "Charlie", "Ludvig", "Emil", "Theo", "Edvin", "Anton", "Gustav", "Sixten", "Benjamin", "Loke",
                                            "Molly", "Nellie", "Moa", "Liv", "Stella", "Nova", "Freja", "Alicia", "Lova", "Elvira", "Bengt"};



        private static string[] towns =  {  "Stockholm", "Järfälla", "Falköping", "Skövde", "Göteborg", "Umeå", "Luleå", "Lund", "Borås", "Örebro",
                                            "Åsarp", "Trollhättan", "Jönköping", "Huskvarna", "Växsjö", "Sävsjö", "Karlskrona", "Karlshamn", "Karlsborg", "Halmstad",
                                            "Uppsala", "Västerås", "Södertälje", "Norrköping", "Linköping", "Västervik", "Oskarshamn", "Kalmar", "Visby", "Borgholm",
                                            "Ysta", "Trelleborg", "Malmö", "Helsingborg", "Värnamo", "Falkenberg", "Varberg", "Kungsbacka", "Kungälv", "Alingsås",
                                            "Ulricehamn", "Vårgårda", "Vara", "Uddevalla", "Lysekil", "Motala", "Götene", "Skara", "Lidköping", "Karlstad",
                                            "Åmål", "Karlskoga", "Filipstad", "Nora", "Köping", "Kopparberg", "Ludvika", "Avesta", "Leksand", "Mora",
                                            "Falun", "Storvreta", "Gävle", "Eversberg", "Söderhamn", "Orsa", "Edsbyn", "Bollnäs", "Idre", "Sveg",
                                            "Sundsvall", "Timrå", "Kramfors", "Östersund", "Sollefteå", "Örnsköldsvik", "Åre", "Robertsfors", "Lycksele", "Skellefteå",
                                            "Piteå", "Arvidjaur", "Kalix", "Jokkmokk", "Gällivare", "Pajala", "Kiruna", "Malung", "Rättvik", "Säffle", 
                                            "Nyköping", "Mjölby", "Vimmerby", "Vetlanda", "Nässjö", "Mölndal", "Havdhem", "Hemse", "Kristinehamn", "Norrtälje"};

       


    }
}
