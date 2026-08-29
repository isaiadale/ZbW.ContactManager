using System;
using System.Windows.Forms;
using ContactManager.Business.Services;
using ContactManager.UI.WinForms.Base;

namespace ContactManager.UI.WinForms.Forms
{
    /// <summary>
    /// Fragt Benutzername und Passwort ab und prüft sie über den
    /// <see cref="AuthenticationService"/>. Wird modal aus <c>Program.cs</c> geöffnet,
    /// bevor der Kontaktstamm geladen wird - so bleibt <c>contacts.json</c> unangetastet,
    /// solange sich niemand angemeldet hat. Enthält selbst keine Prüflogik, nur
    /// Dialogsteuerung und Fehlermeldungen.
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        // Zugang zur Business-Schicht. Prüft ausschliesslich Anmeldedaten, kennt den
        // Kontaktstamm nicht.
        private readonly AuthenticationService _authentication;

        /// <summary>
        /// Erstellt das Anmeldeformular.
        /// </summary>
        /// <param name="authentication">Der Service, der die eingegebenen Anmeldedaten prüft.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="authentication"/> <c>null</c> ist.</exception>
        public LoginForm(AuthenticationService authentication)
        {
            ArgumentNullException.ThrowIfNull(authentication);

            InitializeComponent();

            _authentication = authentication;

            // Bewusst hier statt im Designer verdrahtet: Der Designer gehört den
            // Kolleg*innen, jede Änderung daran erzeugt unnötige Merge-Konflikte.
            BtnLogin.Click += BtnLogin_Click;
            BtnCancel.Click += BtnCancel_Click;

            // Enter meldet an, Escape bricht ab. Beide Zuweisungen brauchen die fertig
            // erzeugten Controls, stehen deshalb nach InitializeComponent().
            AcceptButton = BtnLogin;
            CancelButton = BtnCancel;

            SetTabOrder();
        }

        /// <summary>
        /// Setzt beim allerersten Start einen Hinweis auf den automatisch angelegten
        /// Standardbenutzer und den Eingabefokus. Bewusst hier statt im Konstruktor:
        /// Zu diesem Zeitpunkt ist das Fenster bereit für den Fokus.
        /// </summary>
        /// <param name="e">Die Ereignisdaten des Load-Ereignisses.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_authentication.DefaultUserCreated)
            {
                LblFirstStartHint.Text =
                    "Erststart: Der Benutzer \"admin\" mit dem Passwort \"admin\" wurde angelegt.";
                LblFirstStartHint.Visible = true;

                TxtbUserName.Text = "admin";
                TxtbPassword.Focus();
            }
            else
            {
                TxtbUserName.Focus();
            }
        }

        // Legt die Reihenfolge fest, in der die Tab-Taste durch die Felder springt.
        // Der Designer kennt TabIndex zwar, die Projektkonvention setzt die Reihenfolge
        // trotzdem im Code, damit sie unabhängig von Designer-Änderungen bleibt.
        private void SetTabOrder()
        {
            Control[] order = { TxtbUserName, TxtbPassword, BtnLogin, BtnCancel };

            for (int i = 0; i < order.Length; i++)
                order[i].TabIndex = i;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            string userName = TxtbUserName.Text.Trim();
            string password = TxtbPassword.Text; // Passwort bewusst nicht trimmen.

            if (userName.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("Bitte Benutzername und Passwort eingeben.", "Ungültige Eingabe",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_authentication.ValidateCredentials(userName, password))
            {
                DialogResult = DialogResult.OK;
                return;
            }

            // Bewusst ohne Angabe, ob der Benutzername unbekannt oder das Passwort falsch
            // war - das entscheidet bereits der Service so und die Oberfläche darf es
            // nicht durch eine genauere Meldung wieder preisgeben.
            MessageBox.Show("Benutzername oder Passwort ist falsch.", "Anmeldung fehlgeschlagen",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            TxtbPassword.Clear();
            TxtbPassword.Focus();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
