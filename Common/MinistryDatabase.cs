namespace Common
{
    using System.Collections.Generic;

    public class Ministry
    {
        public Ministry(int id, string name, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }
    }

    public class MinistryDatabase
    {
        private readonly List<Ministry> ministries = new List<Ministry>
                                                         {
                                                             new Ministry(1, "Haridus- ja Teadusministeerium", "Munga 18, 50088 Tartu"),
                                                             new Ministry(2, "Justiitsministeerium", "	Tõnismägi 5a, 15191 Tallinn"),
                                                             new Ministry(3, "Kaitseministeerium", "Sakala 1, 15094 Tallinn"),
                                                             new Ministry(4, "Keskkonnaministeerium", "Narva mnt 7a, 15172 Tallinn"),
                                                             new Ministry(5, "Kultuuriministeerium", "Suur-Karja 23, 15076 Tallinn"),
                                                             new Ministry(6, "Majandus- ja Kommunikatsiooniministeerium", "Harju 11, 15072 Tallinn"),
                                                             new Ministry(7, "Põllumajandusministeerium", "Lai 39/41, 15056 Tallinn"),
                                                             new Ministry(8, "Rahandusministeerium", "Suur-Ameerika 1, 15006 Tallinn"),
                                                             new Ministry(9, "Siseministeerium", "Pikk 61, 15065 Tallinn"),
                                                             new Ministry(10, "Sotsiaalministeerium", "Gonsiori 29, 15027 Tallinn"),
                                                             new Ministry(11, "Välisministeerium", "Islandi Väljak 1, 15049 Tallinn"),
                                                         };

        public IEnumerable<Ministry> GetAll()
        {
            return this.ministries;
        }
    }
}