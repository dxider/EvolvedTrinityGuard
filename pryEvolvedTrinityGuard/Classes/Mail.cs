using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
namespace pryEvolvedTrinityGuard.Classes
{
    class Mail
    {
        public string Subject { get; set; }
        public int Style { get; set; }
        public string Body { get; set; }
        public string Delivery { get; set; }
        public string Expire { get; set; }
        public int MyProperty { get; set; }
        public List<int> Receivers { get; set; }
        public int Sender { get; set; }
        public bool COD { get; set; }
        public long Cash { get; set; }
        public int Type { get; set; }
        public MySqlConnection CharConn { get; set; }

        public Mail(MySqlConnection con)
        {
            CharConn = con;
            Receivers = new List<int>();
        }

        public MySqlException Send()
        {
            string oldbody = Body;
            try
            {
                string ID = GetNewID().ToString();
                string codcash = "0";
                if (COD) { codcash = Cash.ToString(); Cash = 0; }
                Body = oldbody;
                Body = "Oro regresado por la migracion";
                string query = String.Format("INSERT INTO `mail` (`id`, `messageType`, `stationery`, `mailTemplateId`, `sender`, `receiver`, `subject`, `body`, `has_items`, `expire_time`, `deliver_time`, `money`, `cod`) VALUES ({0}, {1}, {2}, 0, {3}, {4}, '{5}', '{6}', {7}, {8}, {9}, {10}, {11});",
                    ID,
                    Type.ToString(),
                    Style.ToString(),
                    Sender.ToString(),
                    Receivers[0],
                    Subject.Replace("'", "´"),
                    Body.Replace("'", "´"),
                    "0",
                    Expire,
                    Delivery,
                    Cash.ToString(),
                    codcash
                    );
                var cmd = new MySqlCommand(query, CharConn);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader;

                // ITEMS:
                int guid = 0;
                var guids = new List<int>();
                cmd = new MySqlCommand("SELECT `guid` FROM `item_instance`", CharConn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int nguid = reader.GetInt32("guid");
                    if (nguid > guid) guid = nguid;
                }
                reader.Close();
                guid += 2;
            }
            catch (MySqlException ex)
            {
                return ex;
            }
            return null;
        }

        private int GetNewID()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT `id` FROM `mail`;", CharConn);
            MySqlDataReader reader = cmd.ExecuteReader();
            int hid = 0;
            while (reader.Read())
            {
                int nid = reader.GetInt32("id");
                if (nid > hid) hid = nid;
            }
            reader.Close();
            return hid + 1;
        }
    }

}
