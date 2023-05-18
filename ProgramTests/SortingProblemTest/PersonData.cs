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
            //Console.WriteLine($"DEBUG: {inputData}");
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



        private static string[] towns =  {  "Stockholm", "Jarfalla", "Falkoping", "Skovde", "Goteborg", "Umea", "Lulea", "Lund", "Boras", "Orebro",
                                            "Asarp", "Trollhattan", "Jonkoping", "Huskvarna", "Vaxsjo", "Savsjo", "Karlskrona", "Karlshamn", "Karlsborg", "Halmstad",
                                            "Uppsala", "Vasteras", "Sodertalje", "Norrkoping", "Linkoping", "Vastervik", "Oskarshamn", "Kalmar", "Visby", "Borgholm",
                                            "Ysta", "Trelleborg", "Malmo", "Helsingborg", "Varnamo", "Falkenberg", "Varberg", "Kungsbacka", "Kungalv", "Alingsas",
                                            "Ulricehamn", "Vargarda", "Vara", "Uddevalla", "Lysekil", "Motala", "Gotene", "Skara", "Lidkoping", "Karlstad",
                                            "Amal", "Karlskoga", "Filipstad", "Nora", "Koping", "Kopparberg", "Ludvika", "Avesta", "Leksand", "Mora",
                                            "Falun", "Storvreta", "Gavle", "Eversberg", "Soderhamn", "Orsa", "Edsbyn", "Bollnas", "Idre", "Sveg",
                                            "Sundsvall", "Timra", "Kramfors", "Ostersund", "Solleftea", "Ornskoldsvik", "Are", "Robertsfors", "Lycksele", "Skelleftea",
                                            "Pitea", "Arvidjaur", "Kalix", "Jokkmokk", "Gallivare", "Pajala", "Kiruna", "Malung", "Rattvik", "Saffle",
                                            "Nykoping", "Mjolby", "Vimmerby", "Vetlanda", "Nassjo", "Molndal", "Havdhem", "Hemse", "Kristinehamn", "Norrtalje"};




    }
}
