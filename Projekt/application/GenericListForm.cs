using Projekt.application;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Projekt.pages
{
    /// <summary>
    /// Generic base class for all entity list/browse forms
    /// Eliminates repetition across RoleForm, UserForm, GameForm, etc.
    /// 
    /// NOTE: This is NOT a partial class (no designer file).
    /// Derived classes should be partial and have InitializeComponent in their designer.
    /// </summary>
    public class GenericListForm<T> : Form where T : class
    {
        protected CrudService<T> Service { get; set; }
        public BindingSource BindingSource { get; set; }

        public GenericListForm()
        {
            Service = new CrudService<T>();
            BindingSource = new BindingSource();
        }

        protected virtual void LoadData()
        {
            try
            {
                Service.Load(BindingSource);
            }
            catch (CrudServiceException ex)
            {
                ShowError($"Load Error: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
        }

        protected virtual void OnCellClick(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Header click

            try
            {
                var entity = (T)BindingSource.Current;
                if (entity == null) return;

                // Create and show the edit form (derived class must implement this)
                using (var editForm = CreateEditForm(entity))
                {
                    editForm.ShowDialog();
                }

                // Reload data after edit/delete
                LoadData();
            }
            catch (Exception ex)
            {
                ShowError($"Error opening edit form: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
        }

        /// <summary>
        /// Derived classes must implement this to return the appropriate edit form
        /// </summary>
        protected virtual Form CreateEditForm(T entity)
        {
            throw new NotImplementedException(
                $"Derived class must implement CreateEditForm for {typeof(T).Name}");
        }

        protected void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void RefreshData()
        {
            LoadData();
        }
    }
}