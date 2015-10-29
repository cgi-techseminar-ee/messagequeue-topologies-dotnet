namespace Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public abstract class RandomDatabase
    {
        private readonly List<string> names = new List<string>();
        private readonly Random random = new Random();

        protected RandomDatabase(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        continue;
                    }

                    var name = this.Parse(line);
                    if (string.IsNullOrEmpty(name))
                    {
                        continue;
                    }

                    this.names.Add(name);
                }
            }
        }

        public string GetRandom()
        {
            var index = this.random.Next(0, this.names.Count - 1);

            return this.names[index];
        }

        protected abstract string Parse(string line);
    }
}