using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tack_Toe
{
    [Serializable]
    public class Database
    {
        private readonly List<Player> Players= new List<Player>();

        private static readonly string FILE = "database.bin";

        public Player GetPlayerByNameOrCreate(string name)
        {
            Player? playerOpt = Players.Find(player => player.Name == name);
            Player player;
            if (playerOpt == null)
            {
                player = new(name);
                Players.Add(player);
            }
            else
            {
                player = playerOpt;
            }
            return player;

        }

        public static void Serialize(Database database, bool append = false)
        {
            using (Stream stream = File.Open(FILE, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, database);
            }
        }

        public static Database Deserialize()
        {
            Stream? stream = null;
                try
                {
                    stream = File.Open(FILE, FileMode.Open);
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    return (Database)binaryFormatter.Deserialize(stream);
                }
                catch (Exception e)
                {
                if (stream != null)
                    stream.Close();
                    Debug.WriteLine(e);
                    return new();
                }
        }

    }
}
