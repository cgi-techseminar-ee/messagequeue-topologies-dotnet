namespace Common
{
    using System;

    public class CitiesDatabase : RandomDatabase
    {
        public CitiesDatabase()
            : base("cities.txt")
        {
        }

        protected override string Parse(string line)
        {
            if (line.IndexOf("\t", StringComparison.InvariantCulture) == -1)
            {
                return string.Empty;
            }

            var a = line.Split('\t');

            return a[1];
        }
    }
}