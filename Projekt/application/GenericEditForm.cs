using Projekt.application;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Projekt.pages
{
    public class GenericEditForm<T> : Form where T : class
    {
        protected CrudService<T> Service { get; set; }
        protected BindingSource BindingSource { get; set; }
        protected T CurrentEntity { get; set; }

        public GenericEditForm() { }

        public GenericEditForm(T entity, BindingSource bindingSource)
        {
            CurrentEntity = entity;
            BindingSource = bindingSource;
            Service = new CrudService<T>();

            BindingSource.DataSource = entity;
        }

        protected virtual void OnSaveClick(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                Service.Update(CurrentEntity);
                MessageBox.Show(
                    $"{typeof(T).Name} updated successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (CrudServiceException ex)
            {
                ShowError($"Update Error: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
            catch (Exception ex)
            {
                ShowError($"Unexpected Error: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
        }

        protected virtual void OnDeleteClick(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete this {typeof(T).Name}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                Service.Delete(CurrentEntity);
                MessageBox.Show(
                    $"{typeof(T).Name} deleted successfully",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            catch (CrudServiceException ex)
            {
                ShowError($"Delete Error: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
            catch (Exception ex)
            {
                ShowError($"Unexpected Error: {CrudService<T>.GetFullExceptionMessage(ex)}");
            }
        }

        protected virtual void ValidateForm() { }

        protected void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}