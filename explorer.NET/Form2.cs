using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace explorerNET
{
    /// <summary>
    /// Klasa dostarczająca okno programu, które pozwala zarządzać ulubionymi stronami (zakładkami).
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// Konstruktor klasy, inicjalizuje komponenty.
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Dodaj".
        /// Dodaje wprowadzony adres WWW do zakładek.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem(toolStripTextBox1.Text);
            listView1.Items.Add(toolStripTextBox1.Text);
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Usuń".
        /// Usuwa zaznaczony element z zakładek. W przypadku braku zaznaczenia wyświetlana jest informacja.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            }
            catch
            {
                MessageBox.Show("Wybierz obiekt");
            }
        }

        /// <summary>
        /// Metoda wywoływana przy ładowaniu okna, wczytuje zapisane zakładki.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void Form2_Load(object sender, EventArgs e) 
        {
            System.Xml.XmlDocument loadDoc = new System.Xml.XmlDocument();
            loadDoc.Load(Application.StartupPath + "\\Zakladki.xml");
            foreach (System.Xml.XmlNode favNode in loadDoc.SelectNodes("/Zakladki/Obiekt"))
            {
                listView1.Items.Add(favNode.Attributes["url"].InnerText);
            }
        }

        /// <summary>
        /// Metoda wywoływana przy zamykaniu okna, zapisuje stan zakładek do zewnętrznego pliku.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(Application.StartupPath + "\\Zakladki.xml", null);
            writer.WriteStartElement("Zakladki");
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                writer.WriteStartElement("Obiekt");
                writer.WriteAttributeString("url", listView1.Items[i].Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
