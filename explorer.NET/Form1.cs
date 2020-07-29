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
    /// Klasa reprezentująca główne okno aplikacji.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Konstruktor klasy, inicjalizuje komponenty.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zwraca obiekt paska postępu wyświetlanego w oknie.
        /// </summary>
        /// <returns>Obiekt paska postępu</returns>
        public ToolStripProgressBar getProgressBar()
        {
            return toolStripProgressBar1;
        }

        /// <summary>
        /// Zwraca obiekt przycisku służącego do odświeżania strony.
        /// </summary>
        /// <returns>Obiekt przycisku do odświeżania strony</returns>
        public ToolStripButton getRefreshButton()
        {
            return toolStripButton4;
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Cofnij".
        /// Pozwala wrócić na stronę poprzednio odwiedzoną.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Do przodu".
        /// Pozwala przejść do następnej strony w historii przeglądania.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Stop".
        /// Umożliwia zatrzymanie wykonywania lub ładowania strony.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Odśwież".
        /// Przeładowuje bieżącą stronę wyświetlaną w przeglądarce.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Idź".
        /// Wykonuje przejście do strony wprowadzonej w pasku adresu.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text); 
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Drukuj".
        /// Wyświetla okno pozwalające dostosować ustawienia strony.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPageSetupDialog();
        }

        /// <summary>
        /// Uchwyt zdarzenia zmiany postępu ładowania strony internetowej.
        /// Aktualizuje wartość wyświetlaną przez pasek postępu.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia zmiany postępu</param>
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try // Pobiera wartość Progressbar i konwertuje tą wartość do typu Int
            {
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
                toolStripProgressBar1.Value = Convert.ToInt32(e.MaximumProgress);
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message); - okomentowano ponieważ generuje błedy pop-up
            }

        }

        /// <summary>
        /// Uchwyt zdarzenia zmiany treści adresu strony internetowej.
        /// Po naciśnięciu przycisku Enter przechodzi pod wprowadzony adres internetowy.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // jeżeli klawisz który został wciśniety jest Enter-em wtedy zostaje wykonana instrukcja przejscia pod adres strony internetowej wprowadzonej do textbox
            if (e.KeyCode == Keys.Enter) 
            {
                webBrowser1.Navigate(toolStripTextBox1.Text);
            }
            
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Zapisz".
        /// Wyświetla okno dialogowe zapisywania strony.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowSaveAsDialog();
        }

        /// <summary>
        /// Uchwyt wykonywany po kliknięciu w przycisk "Ulubione".
        /// Otwiera okno aplikacji pozwalające zarządzać zakładkami.
        /// </summary>
        /// <param name="sender">Instancja obiektu wywołującego event</param>
        /// <param name="e">Argumenty zdarzenia</param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Form2 fav = new Form2();

            if (webBrowser1.Url != null)
                fav.toolStripTextBox1.Text = webBrowser1.Url.ToString();

            fav.StartPosition = FormStartPosition.CenterParent;
            fav.Show();
        }

    }
}
