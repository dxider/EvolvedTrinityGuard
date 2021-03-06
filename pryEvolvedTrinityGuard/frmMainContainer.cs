﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryEvolvedTrinityGuard.Classes;
using System.Json;
using System.IO;
using MySql.Data.MySqlClient;

namespace pryEvolvedTrinityGuard
{
    public partial class frmMainContainer : Form
    {
        private int childFormNumber = 0;
        private frmSandbox Sandbox;
        private frmSandbox SandboxAuth;
        Connection con = new Connection();

        List<Item> elementos = new List<Item>();
        List<Equipo> equipamento = new List<Equipo>();
        List<Montura> monturas = new List<Montura>();
        List<Creatura> creaturas = new List<Creatura>();
        List<Spell> conjuros = new List<Spell>();
        List<Skill> skills = new List<Skill>();
        List<Logro> logros = new List<Logro>();
        List<Currency> monedas = new List<Currency>();
        Info inf = new Info();
        GameInfo ginf = new GameInfo();
        List<Reputacion> reputaciones = new List<Reputacion>();

        public frmMainContainer()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sandbox = new frmSandbox();
            Sandbox.MdiParent = this;
            Sandbox.console = "worldserver.exe";
            Sandbox.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration Configuracion = new frmConfiguration();
            Configuracion.MdiParent = this;
            Configuracion.Show();
        }

        private void setMotDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            frmInputBox frmInputText = new frmInputBox();
            if(frmInputText.ShowDialog()== System.Windows.Forms.DialogResult.OK && Sandbox!=null)
            {
                message = frmInputText.txtValor.Text;
                Sandbox.SendCommand(message);
            }
        }

        private void authSandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SandboxAuth = new frmSandbox();
            SandboxAuth.MdiParent = this;
            SandboxAuth.console = "authserver.exe";
            SandboxAuth.Show();
        }

        private void frmMainContainer_Load(object sender, EventArgs e)
        {

        }

        private void fswMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            string texto = File.ReadAllText(e.FullPath);
            texto = texto.Trim();
            int inicio = texto.IndexOf("\"");
            int fin = texto.IndexOf("\n");
            string valores;
            valores = texto;
            int charguid;
            valores = valores.Replace("\\\"", "\"");

            JsonObject jso = JsonObject.Parse(valores);
            JsonObject items;
            // Parsing the items

            JsonElement js = jso.GetElementByKey("items");
            if(js.Value.ToString()!="[]")
            { 
                items = (JsonObject)js.Value;
                elementos.Clear();
                foreach (JsonElement j in items)
                {
                    Item it = new Item();
                    JsonObject propiedades = (JsonObject)j.Value;
                    it.ID = int.Parse(propiedades.GetElementByKey("I").Value.ToString());
                    it.Slot = int.Parse(propiedades.GetElementByKey("S").Value.ToString());
                    it.Bolsa = int.Parse(propiedades.GetElementByKey("B").Value.ToString());
                    it.Gema1 = int.Parse(propiedades.GetElementByKey("G1").Value.ToString());
                    it.Gema2 = int.Parse(propiedades.GetElementByKey("G2").Value.ToString());
                    it.Gema3 = int.Parse(propiedades.GetElementByKey("G3").Value.ToString());
                    it.Cantidad = int.Parse(propiedades.GetElementByKey("C").Value.ToString());
                    elementos.Add(it);
                }
            }

            // Parsing Equipment
            JsonElement jse = jso.GetElementByKey("equipo");
            if(jse.Value.ToString()!="[]")
            {
                items = (JsonObject)jse.Value;
                equipamento.Clear();
                foreach (JsonElement j in items)
                {
                    Equipo it = new Equipo();
                    JsonObject propiedades = (JsonObject)j.Value;
                    it.ID = int.Parse(propiedades.GetElementByKey("I").Value.ToString());
                    it.Gema1 = int.Parse(propiedades.GetElementByKey("G1").Value.ToString());
                    it.Gema2 = int.Parse(propiedades.GetElementByKey("G2").Value.ToString());
                    it.Gema3 = int.Parse(propiedades.GetElementByKey("G3").Value.ToString());
                    it.Cantidad = int.Parse(propiedades.GetElementByKey("C").Value.ToString());
                    if (it.Cantidad == 0)
                        it.Cantidad++;
                    it.Name = GetGearName(it.ID);
                    equipamento.Add(it);
                    //monturas
                }
            }
            

            // Parsing Equipment
            jse = jso.GetElementByKey("monturas");
            if (jse.Value.ToString() != "[]")
            { 
                items = (JsonObject)jse.Value;
                monturas.Clear();
                foreach (JsonElement j in items)
                {
                    Montura it = new Montura();
                    it.ID = int.Parse(j.Value.ToString());
                    monturas.Add(it);
                    //monturas
                }
            }

            JsonElement obc = jso.GetElementByKey("creaturas");
            if (obc.Value.ToString() != "[]")
            {
                items= (JsonObject)obc.Value;
                creaturas.Clear();
                foreach (JsonElement j in items)
                {
                    Creatura it = new Creatura();
                    it.ID = int.Parse(j.Value.ToString());
                    creaturas.Add(it);
                }
            }
            jse = jso.GetElementByKey("spells");
            if (jse.Value.ToString() != "[]")
            { 
                items = (JsonObject)jse.Value;
                conjuros.Clear();
                foreach (JsonElement j in items)
                {
                    Spell it = new Spell();
                    JsonObject propiedades = (JsonObject)j.Value;
                    it.Book = int.Parse(propiedades.GetElementByKey("ID").Value.ToString());
                    it.SpellId = int.Parse(propiedades.GetElementByKey("S").Value.ToString());
                    conjuros.Add(it);
                }
            }

            JsonElement ob = jso.GetElementByKey("skills");
            if (ob.Value.ToString() != "[]")
            { 
                JsonArray ja = (JsonArray)ob.Value;
                skills.Clear();
                for (int k = 0; k < ja.Count; k++)
                {
                    Skill it = new Skill();
                    JsonObject propiedades = (JsonObject)ja[k];
                    it.MaxRank = int.Parse(propiedades.GetElementByKey("M").Value.ToString());
                    it.Rank = int.Parse(propiedades.GetElementByKey("C").Value.ToString());
                    it.Name = propiedades.GetElementByKey("N").Value.ToString();
                    skills.Add(it);
                }
            }

            JsonElement achi = jso.GetElementByKey("achiev");
            if (achi.Value.ToString() != "[]")
            { 
                JsonArray ja2 = (JsonArray)achi.Value;
                logros.Clear();
                for (int k = 0; k < ja2.Count; k++)
                {
                    Logro it = new Logro();
                    JsonObject propiedades = (JsonObject)ja2[k];
                    it.Id = int.Parse(propiedades.GetElementByKey("I").Value.ToString());
                    it.Posix = int.Parse(propiedades.GetElementByKey("D").Value.ToString());
                    logros.Add(it);
                }
            }

            JsonElement glyphs = jso.GetElementByKey("glyphs");
            string[] glypslist = glyphs.ToString().Substring(glyphs.ToString().IndexOf(':') + 1).Trim().Replace("[", "").Replace("]", "").Split(',');
            

            JsonElement curr = jso.GetElementByKey("currency");
            if (curr.Value.ToString() != "[]")
            { 
                JsonArray ja3 = (JsonArray)curr.Value;
                monedas.Clear();
                for (int l = 0; l < ja3.Count; l++)
                {
                    Currency it = new Currency();
                    JsonObject propiedades = (JsonObject)ja3[l];
                    it.Id = int.Parse(propiedades.GetElementByKey("I").Value.ToString());
                    it.Cantidad = int.Parse(propiedades.GetElementByKey("C").Value.ToString());
                    monedas.Add(it);
                }
            }
            jse = jso.GetElementByKey("uinf");
            items = (JsonObject)jse.Value;

            inf.Arena = int.Parse(items.GetElementByKey("arenapoints").Value.ToString());
            inf.Nombre = items.GetElementByKey("name").Value.ToString();
            charguid= GetCharGuid(inf.Nombre);
            inf.Clase = items.GetElementByKey("class").Value.ToString();
            inf.Nivel = int.Parse(items.GetElementByKey("level").Value.ToString());
            inf.Raza = items.GetElementByKey("race").Value.ToString();
            inf.Sexo = int.Parse(items.GetElementByKey("gender").Value.ToString());
            inf.Kills = int.Parse(items.GetElementByKey("kills").Value.ToString());
            inf.Honor = int.Parse(items.GetElementByKey("honor").Value.ToString());
            inf.Money = int.Parse(items.GetElementByKey("money").Value.ToString());
            inf.Specs = int.Parse(items.GetElementByKey("specs").Value.ToString());

            jse = jso.GetElementByKey("ginf");
            items = (JsonObject)jse.Value;
            ginf.Idioma = items.GetElementByKey("locale").Value.ToString();
            ginf.Realmlist = items.GetElementByKey("realmlist").Value.ToString();
            ginf.Build = items.GetElementByKey("clientbuild").Value.ToString();
            ginf.Realm = items.GetElementByKey("realm").Value.ToString();
            //inf.

            JsonElement repu = jso.GetElementByKey("rep");
            JsonArray ja4 = (JsonArray)repu.Value;
            reputaciones.Clear();
            for (int m = 0; m < ja4.Count; m++)
            {
                Reputacion it = new Reputacion();
                JsonObject propiedades = (JsonObject)ja4[m];
                it.Faccion = int.Parse(propiedades.GetElementByKey("F").Value.ToString());
                it.Valor = int.Parse(propiedades.GetElementByKey("V").Value.ToString());
                it.Nombre = propiedades.GetElementByKey("N").Value.ToString();
                reputaciones.Add(it);
            }
            
            txtLog.Text += Environment.NewLine + "Iniciando el proceso de migración de [" + inf.Nombre + "](" + charguid.ToString() + ").";
            txtLog.Text += Environment.NewLine + "Expulsando al jugador " + inf.Nombre + " en caso de estar Online por el proceso de migración.";
            Sandbox.SendCommand("kick " + inf.Nombre);
            
            txtLog.Text += Environment.NewLine + "Restaurando items a [" + inf.Nombre + "].";
            string command = "send items " + inf.Nombre + " \"Migracion de personaje\" \"Se envia este correo como parte de los item que se restauraran a su cuenta por el proceso de migracion\" ";
            string cadenaitems=string.Empty;
            List<string> cadenas = new List<string>();
            int contador = 0;
            foreach( Item item in elementos )
            {
                if(cadenaitems.Length==0)
                    cadenaitems = item.ID + ":" + item.Cantidad;
                else
                    cadenaitems += " " + item.ID + ":" + item.Cantidad;
                contador++;
                if(contador%12==0)
                {
                    cadenas.Add(cadenaitems);
                    cadenaitems=string.Empty;
                }
            }
            cadenas.Add(cadenaitems);
            foreach (string cadena in cadenas)
            {
                Sandbox.SendCommand(command + cadena);
                txtLog.Text += Environment.NewLine + "Enviando los items : " + cadena;
                System.Threading.Thread.Sleep(500);
            }

            ////////////////////////////

            txtLog.Text += Environment.NewLine + "Restaurando gear a [" + inf.Nombre + "].";
            command = "send items " + inf.Nombre + " \"Migracion de personaje\" \"Se envia este correo como parte del gear que se restaurará a su cuenta por el proceso de migracion\" ";
            cadenaitems = string.Empty;
            cadenas = new List<string>();
            List<string> nombres = new List<string>();
            string cadenanombres = string.Empty;
            contador = 0;
            foreach (Equipo gear in equipamento)
            {
                if (cadenaitems.Length == 0)
                {
                    if(!gear.Name.ToLower().Contains("quiver"))
                    { 
                        cadenaitems = gear.ID + ":" + gear.Cantidad;
                        cadenanombres = gear.Name;
                        contador++;
                    }
                }
                    
                else
                {
                    if(!gear.Name.ToLower().Contains("quiver"))
                    {
                        cadenaitems += " " + gear.ID + ":" + gear.Cantidad;
                        cadenanombres += ", " + gear.Name;
                        contador++;
                    }
                }
                    
                
                if (contador % 12 == 0)
                {
                    cadenas.Add(cadenaitems);
                    nombres.Add(cadenanombres);
                    cadenanombres = string.Empty;
                    cadenaitems = string.Empty;
                }
            }
            cadenas.Add(cadenaitems);
            nombres.Add(cadenanombres);
            int ncontador = 0;
            foreach (string cadena in cadenas)
            {
                Sandbox.SendCommand(command + cadena);
                txtLog.Text += Environment.NewLine + "Enviando el gear : " + nombres[ncontador];
                ncontador++;
                System.Threading.Thread.Sleep(25);
            }

            ////////////////////////////
            txtLog.Text += Environment.NewLine + "Estableciendo el nivel de " + inf.Nombre + " en " + inf.Nivel + " de acuerdo al proceso de migración.";
            Sandbox.SendCommand("character level " + inf.Nombre + " " + inf.Nivel);

            txtLog.Text += Environment.NewLine + "Enviando oro a [" + inf.Nombre + "] = " + inf.Money.ToString() + "C.";
            SendGold(inf.Money, inf.Nombre);

            System.Threading.Thread.Sleep(500);
            txtLog.Text += Environment.NewLine + "Enviando monturas a [" + inf.Nombre + "] de acuerdo al proceso de migración.";
            List<String> mountlist= GetMounts(monturas);
            command = "send items " + inf.Nombre + " \"Migracion de personaje\" \"Se envia este correo como parte de la restauracion de las monturas.\" ";
            string sublist = string.Empty;
            for (int i = 0; i < mountlist.Count;i++ )
            {
                if(i==0)
                {
                    sublist = mountlist[i] + ":1";
                }
                else
                {
                    if(i%12!=0)
                    {
                        sublist += " " + mountlist[i] + ":1";
                    }
                    else
                    {
                        Sandbox.SendCommand(command + sublist);
                        sublist = mountlist[i] + ":1";
                    }
                }
                if(i==mountlist.Count -1)
                    Sandbox.SendCommand(command + sublist);
            }
            /////////////////////
            System.Threading.Thread.Sleep(250);
            txtLog.Text += Environment.NewLine + "Enviando mascotas a [" + inf.Nombre + "] de acuerdo al proceso de migración.";
            List<String> critterlist = GetCritters(creaturas);
            command = "send items " + inf.Nombre + " \"Migracion de personaje\" \"Se envia este correo como parte de la restauracion de las monturas.\" ";
            sublist = string.Empty;
            for (int i = 0; i < critterlist.Count; i++)
            {
                if (i == 0)
                {
                    sublist = critterlist[i] + ":1";
                }
                else
                {
                    if (i % 12 != 0)
                    {
                        sublist += " " + critterlist[i] + ":1";
                    }
                    else
                    {
                        Sandbox.SendCommand(command + sublist);
                        sublist = critterlist[i] + ":1";
                    }
                }
                if (i == critterlist.Count - 1)
                    Sandbox.SendCommand(command + sublist);
            }

            ///////////////////////
            if(SendArenaHonor(inf.Nombre, inf.Honor, inf.Arena))
                txtLog.Text += Environment.NewLine + "Puntos de Arena=" + inf.Arena.ToString() + "  y Honor=" + inf.Honor.ToString() + " de " + inf.Nombre + " restaurados de acuerdo al proceso de migración.";
            else
                txtLog.Text += Environment.NewLine + "No se pudieron restaurar los puntos de arena y honor para el jugador " + inf.Nombre + "Arena=" + inf.Arena.ToString() + " Honor=" + inf.Honor.ToString() + ".";
            

            foreach(Logro achiv in logros)
            {
                Logro acvtmp = new Logro();
                acvtmp.Id = achiv.Id;
                acvtmp.Posix = achiv.Posix;
                FillAchievement(ref acvtmp);
                if (!HasAchievement(charguid, acvtmp.Id) && !acvtmp.Name.StartsWith("Realm First!"))
                {
                    SaveAchievement(charguid, acvtmp);
                    txtLog.Text += Environment.NewLine + "Se restauró el logro " + acvtmp.Name + " para el jugador " + inf.Nombre + ".";
                }
                else
                    txtLog.Text += Environment.NewLine + "No fue posible restaurar el logro " + acvtmp.Name + " para el jugador " + inf.Nombre + ".";
            }

            //////////////////////////////
            command = "send items " + inf.Nombre + " \"Migracion de personaje\" \"Se envia este correo como parte de los tokens que se restauraran a su cuenta por el proceso de migracion\" ";
            cadenaitems = string.Empty;
            cadenas = new List<string>();
            contador = 0;
            foreach (Currency curre in monedas)
            {
                if (cadenaitems.Length == 0 && curre.Cantidad!=0)
                {
                    cadenaitems = curre.Id + ":" + curre.Cantidad;
                    contador++;
                }
                else
                {
                    if (curre.Cantidad != 0)
                    { 
                        cadenaitems += " " + curre.Id + ":" + curre.Cantidad;
                        contador++;
                    }
                }
                if (contador % 12 == 0 && contador!=0)
                {
                    cadenas.Add(cadenaitems);
                    cadenaitems = string.Empty;
                }
            }
            cadenas.Add(cadenaitems);
            foreach (string cadena in cadenas)
            {
                Sandbox.SendCommand(command + cadena);
                txtLog.Text += Environment.NewLine + "Enviando las monedas: " + cadena;
                System.Threading.Thread.Sleep(500);
            }

            ///////////////////
            for (int gidx = 0; gidx < glypslist.Length; gidx++)
            {
                int glyphid = GetGlyphId(glypslist[gidx]);
                SaveGlyph(gidx, glyphid, charguid);
            }
            
        }

        private void SaveAchievement(int charguid, Logro acv)
        {
            if (con.charconn.State == ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO character_achievement VALUES (" + charguid + "," + acv.Id + "," + acv.Posix +")", con.charconn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
        }

        private bool HasAchievement(int charguid, int idacv)
        {
            bool ret =false;
            if(con.charconn.State== ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM character_achievement WHERE achievement=" + idacv + " AND guid=" + charguid, con.charconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    if(dr[0].ToString()!="0")
                    {
                        ret = true;
                    }
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
            }
            return ret;
        }

        private void FillAchievement(ref Logro acvtmp)
        {
            if(con.evolvedconn.State== ConnectionState.Open)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM achievements WHERE id=" + acvtmp.Id, con.evolvedconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    acvtmp.Name = dr[1].ToString();
                    acvtmp.Description = dr[2].ToString();
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
            }
        }

        private void SaveGlyph(int gidx, int glyphid, int charguid)
        {
            if(con.charconn.State== ConnectionState.Open)
            {
                MySqlCommand cmd= null;
                switch(gidx)
                {
                    case 0:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph1=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                    case 1:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph4=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                    case 2:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph6=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                    case 3:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph2=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                    case 4:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph3=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                    case 5:
                        cmd = new MySqlCommand("UPDATE character_glyphs set glyph5=" + glyphid.ToString() + " WHERE guid=" + charguid.ToString(), con.charconn);
                        break;
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                 
            }
        }

        private int GetGlyphId(string glyph)
        {
            int ret = 0;
            if(con.evolvedconn.State== ConnectionState.Open)
            {
                MySqlCommand com = new MySqlCommand("SELECT id FROM evolvedtrinityguard.glyphproperties where spellid=+" + glyph, con.evolvedconn);
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                    ret = int.Parse(dr[0].ToString());
                dr.Close();
                dr.Dispose();
                com.Dispose();
            }
            return ret;
        }

        private string GetGearName(int id)
        {
            string ret = string.Empty;
            if(con.worldconn.State== ConnectionState.Open)
            {
                MySqlCommand com = new MySqlCommand("SELECT name FROM world.item_template where entry=" + id, con.worldconn);
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                    ret = dr[0].ToString();
                dr.Close();
                dr.Dispose();
                com.Dispose();
            }
            return ret;
        }

        private int GetCharGuid(string name)
        {
            int ret = 0;
            if(con.charconn.State == ConnectionState.Open)
            {
                MySqlCommand com = new MySqlCommand("SELECT guid FROM characters where name='" + name + "'", con.charconn);
                MySqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                    ret = int.Parse(dr[0].ToString());
                dr.Close();
                dr.Dispose();
                com.Dispose();
            }
            return ret;
        }

        private List<String> GetMounts(List<Montura> monturas)
        {
            List<String> ret = new List<string>();
            if (con.worldconn.State == ConnectionState.Open)
            {
                foreach(Montura m in monturas)
                {
                    MySqlCommand com = new MySqlCommand("SELECT entry FROM item_template where spellid_2=" + m.ID + " order by entry desc LIMIT 1", con.worldconn);
                    MySqlDataReader dr = com.ExecuteReader();
                    if(dr.Read())
                    {
                        ret.Add(dr[0].ToString());
                    }
                    dr.Close();
                    dr.Dispose();
                    com.Dispose();
                }
                
            }
            return ret;
        }

        private List<String> GetCritters(List<Creatura> creaturas)
        {
            List<String> ret = new List<string>();
            if (con.worldconn.State == ConnectionState.Open)
            {
                foreach (Creatura c in creaturas)
                {
                    MySqlCommand com = new MySqlCommand("SELECT entry FROM item_template where spellid_2=" + c.ID + " order by entry desc LIMIT 1", con.worldconn);
                    MySqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        ret.Add(dr[0].ToString());
                    }
                    dr.Close();
                    dr.Dispose();
                    com.Dispose();
                }

            }
            return ret;
        }

        private bool SendArenaHonor(string nombre, int honor, int arena)
        {
            bool ret = true;
            try
            {
                MySqlCommand com = new MySqlCommand("UPDATE characters.characters SET arenaPoints=arenaPoints+" + arena.ToString() + ", totalHonorPoints=totalHonorPoints+" + honor.ToString() + " WHERE name='" + nombre + "'", con.charconn);
            com.ExecuteNonQuery();
                }
            catch(Exception ex)
            {
                ret = false;

            }
            return ret;
        }

        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        private void SendGold(long cantidad, string para)
        {

            var mail = new Mail(con.charconn);
            string exp = DateTimeToUnixTimestamp(DateTime.Now.AddDays(30)).ToString().Split(',')[0];
            string del = DateTimeToUnixTimestamp(DateTime.Now).ToString().Split(',')[0];
            mail.Delivery = del;
            mail.Expire = exp;
            mail.COD = false;


            List<int> guids = new List<int>();
            mail.Type = 0;
            mail.Sender = -1;
            int stationary = 0;
            int ssender = -1;
            Int64 money = 0;
            int hasitems = 0;
            int type = 0;

            MySqlCommand cmd0 = new MySqlCommand("SELECT `guid` FROM `characters` WHERE `name`='Parinzak' LIMIT 1;", con.charconn);
            MySqlDataReader reader0 = cmd0.ExecuteReader();
            while (reader0.Read()) mail.Sender = reader0.GetInt32("guid");
            reader0.Close();


            
            MySqlCommand cmd = new MySqlCommand("SELECT `guid` FROM `characters` WHERE `name`='" + para + "' LIMIT 1;", con.charconn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) mail.Receivers.Add(reader.GetInt32("guid"));
            reader.Close();

            //Default
            mail.Style = 41;
            //Blizzard
            mail.Style = 61;
            //Auction House
            mail.Style = 62;
            //Valentine's Day
            mail.Style = 64;
            //The Orphanage
            mail.Style = 65;
            //Magic Scroll
            mail.Style = 1;

            mail.Cash = cantidad;
            hasitems = 0;

            mail.Body = "Oro regresado por la migracion";
            mail.Subject = "Migracion de personaje";

            DialogResult dr;
            while (true)
            {

                //Exception ex = con.ExecuteMail(txtSubject.Text.Replace("'", "`"), stationary, txtBody.Text.Replace("'", "`"), guids, ssender, money.ToString(), hasitems, type, false, del.ToString(), exp.ToString());
                MySqlException ex = mail.Send();
                if (ex != null)
                {
                    txtLog.Text += Environment.NewLine + "Error al enviar el correo con la restauración del oro de " + inf.Nombre +" por " + inf.Money + "C.";
                    break;
                }
                else
                {
                    txtLog.Text += Environment.NewLine + "Correo con restauración de oro enviado exitosamente a " + inf.Nombre + " con " + inf.Money + "C.";
                    break;
                }


            }
            this.Cursor = Cursors.Default;
        }

        private void fswInput_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(500);
            string text = File.ReadAllText(e.FullPath).Trim();
            text = text.Substring(text.IndexOf("\"")+1);
            text = text.Substring(0, text.IndexOf("\n")-2).Trim();
            File.WriteAllText(e.FullPath, text);
            System.Diagnostics.Process.Start("C:\\Users\\Ing.Isaac\\Documents\\decoder\\WoWReanMigrador_53A09\\decode.bat");
            System.Threading.Thread.Sleep(500);
            //System.Diagnostics.Process.Start("C:\\Program Files (x86)\\Lua\\5.1\\lua.exe", "C:\\Users\\Ing.Isaac\\Documents\\decoder\\WoWReanMigrador_53A09\\decode.luac");

            //// Prepare the process to run
            //System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            //// Enter in the command line arguments, everything you would enter after the executable name itself
            //start.Arguments = "C:\\Users\\Ing.Isaac\\Documents\\decoder\\WoWReanMigrador_53A09\\decode.luac"; 
            //// Enter the executable to run, including the complete path
            //start.FileName = "C:\\Program Files (x86)\\Lua\\5.1\\lua.exe";
            //// Do you want to show a console window?
            //start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            //start.CreateNoWindow = false;
            //int exitCode;


            //// Run the external process & wait for it to finish
            //using (System.Diagnostics.Process proc = System.Diagnostics.Process.Start(start))
            //{
            //     proc.WaitForExit();

            //     // Retrieve the app's exit code
            //     exitCode = proc.ExitCode;
            //}
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }

        private void fswInput_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void fswMonitor_Changed(object sender, FileSystemEventArgs e)
        {

        }

    }
}
