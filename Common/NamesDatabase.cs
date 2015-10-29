namespace Common
{
    using System;

    public class NamesDatabase : RandomDatabase
    {
        public NamesDatabase()
            : base("data.dat")
        {
        }

        protected override string Parse(string line)
        {
            if (line.IndexOf(",", StringComparison.InvariantCulture) == -1)
            {
                return string.Empty;
            }

            return line.Substring(0, line.IndexOf(",", StringComparison.InvariantCulture));
        }
    }
}