using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactManager.Model;

namespace ContactManager.UI.WinForms.Base
{
    /// <summary>
    /// Verwaltet die Mehrfachauswahl einer Liste über eine ungebundene Checkbox-Spalte.
    /// Kümmert sich darum, dass die Checkboxen sichtbar und mit einem Klick bedienbar sind,
    /// und merkt sich die Auswahl über das Neuladen der Liste hinweg.
    /// </summary>
    /// <remarks>
    /// Bewusst eine eigene Klasse statt Code in beiden Listenformularen: Kunden- und
    /// Mitarbeiterliste brauchen dasselbe Verhalten, und
    /// <see cref="ContactManager.Business.Services.CustomerService"/> und
    /// <see cref="ContactManager.Business.Services.EmployeeService"/> haben kein gemeinsames
    /// Interface, an dem sich das sonst aufhängen liesse. Diese Klasse kommt ohne aus — sie
    /// kennt nur <see cref="Person"/> und die Tabelle.
    /// </remarks>
    public sealed class GridSelection
    {
        private readonly DataGridView _grid;
        private readonly DataGridViewCheckBoxColumn _column;

        // Die Checkbox-Spalte ist ungebunden: Ihre Werte leben nur in den Zellen und sind
        // nach jedem Setzen der DataSource weg. Deshalb wird die Auswahl hier zusätzlich
        // an der Id festgehalten und nach dem Neuladen wiederhergestellt.
        private readonly HashSet<Guid> _selectedIds = new HashSet<Guid>();

        /// <summary>
        /// Richtet die Mehrfachauswahl auf einer Tabelle ein.
        /// </summary>
        /// <param name="grid">Die Tabelle, in der ausgewählt wird.</param>
        /// <param name="column">Die ungebundene Checkbox-Spalte dieser Tabelle.</param>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn ein Parameter <c>null</c> ist.</exception>
        public GridSelection(DataGridView grid, DataGridViewCheckBoxColumn column)
        {
            ArgumentNullException.ThrowIfNull(grid);
            ArgumentNullException.ThrowIfNull(column);

            _grid = grid;
            _column = column;

            // Der entscheidende Punkt: Die Auswahlspalte muss editierbar sein. Steht das
            // ganze Grid auf ReadOnly, zeichnet WinForms Checkbox-Zellen im deaktivierten
            // Stil - auf hellem Hintergrund sind sie dann praktisch unsichtbar, und die
            // Spalte wirkt leer. Die Datenspalten bleiben davon unberührt; die sperrt das
            // Formular einzeln.
            _column.ReadOnly = false;

            // Ohne diesen Handler wirkt ein Klick auf die Checkbox erst, wenn die Zelle den
            // Fokus verliert: Der neue Wert steckt bis dahin im Editier-Puffer und
            // Cells[...].Value liefert noch den alten. CommitEdit schreibt ihn sofort fest.
            _grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
        }

        /// <summary>
        /// Stellt die Häkchen nach einem Neuladen der Tabelle wieder her und sorgt dafür,
        /// dass jede Zelle einen echten Wahrheitswert trägt.
        /// </summary>
        /// <remarks>
        /// Nach jedem Setzen der <c>DataSource</c> aufzurufen. Ohne diesen Aufruf stünden die
        /// Zellen auf <c>null</c> statt auf <c>false</c> — WinForms zeichnet dann keine
        /// Checkbox, sondern eine leere Zelle.
        /// </remarks>
        public void Refresh()
        {
            foreach (DataGridViewRow row in _grid.Rows)
            {
                bool isSelected = row.DataBoundItem is Person person && _selectedIds.Contains(person.Id);

                row.Cells[_column.Index].Value = isSelected;
            }
        }

        /// <summary>
        /// Liefert die aktuell angehakten Einträge des gewünschten Typs.
        /// </summary>
        /// <typeparam name="T">Der erwartete Typ der Zeilenobjekte.</typeparam>
        /// <returns>Die angehakten Einträge in der Reihenfolge der Tabelle.</returns>
        /// <remarks>
        /// Gelesen werden bewusst nur die <b>sichtbaren</b> Zeilen und nicht die gemerkten
        /// Ids: Bei aktiver Suche soll genau das gelöscht werden, was man auch sieht. Sonst
        /// entstünde „drei löschen, eines sehen".
        /// </remarks>
        public IReadOnlyList<T> GetSelected<T>()
            where T : Person
        {
            List<T> selected = new List<T>();

            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.Cells[_column.Index].Value is bool isChecked && isChecked &&
                    row.DataBoundItem is T item)
                {
                    selected.Add(item);
                }
            }

            return selected;
        }

        /// <summary>
        /// Vergisst einen Eintrag, etwa weil er gelöscht wurde.
        /// </summary>
        /// <param name="id">Die Id des zu vergessenden Eintrags.</param>
        public void Forget(Guid id) => _selectedIds.Remove(id);

        /// <remarks>
        /// Schreibt den angeklickten Wert sofort fest, statt bis zum Verlassen der Zelle zu
        /// warten, und zieht die gemerkte Auswahl nach.
        /// <para>
        /// Die Auswahl wird bewusst <b>hier</b> nachgeführt und nicht im naheliegenderen
        /// <c>CellValueChanged</c>: Jenes Ereignis feuert auch bei <b>programmatischen</b>
        /// Änderungen, also bei jedem <see cref="Refresh"/> und möglicherweise beim Binden
        /// der Daten. Es würde die gemerkte Auswahl also mit den Zellen überschreiben, die
        /// es gerade wiederherzustellen gilt — genau verkehrt herum.
        /// <c>IsCurrentCellDirty</c> wird dagegen nur durch eine echte Benutzereingabe
        /// gesetzt.
        /// </para>
        /// </remarks>
        private void Grid_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (!_grid.IsCurrentCellDirty)
            {
                return;
            }

            DataGridViewCell? current = _grid.CurrentCell;

            if (current is null || current.ColumnIndex != _column.Index || current.RowIndex < 0)
            {
                return;
            }

            _grid.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (_grid.Rows[current.RowIndex].DataBoundItem is not Person person)
            {
                return;
            }

            if (current.Value is bool isChecked && isChecked)
            {
                _selectedIds.Add(person.Id);
            }
            else
            {
                _selectedIds.Remove(person.Id);
            }
        }
    }
}
