using Projekt.application;
using System;
using System.Windows.Forms;

namespace Projekt.pages
{
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
            if (e.RowIndex < 0) return;

            try
            {
                var entity = (T)BindingSource.Current;
                if (entity == null) return;

                using (var editForm = CreateEditForm(entity))
                {
                    editForm.ShowDialog();
                }

                LoadData();
            }
            catch (Exception ex)
            {
                ShowError($"Error opening edit form: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
        }

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