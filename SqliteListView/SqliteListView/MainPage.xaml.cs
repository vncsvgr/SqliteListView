using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SqliteListView
{
    public partial class MainPage : ContentPage
    {
        Aluno a = new Aluno();

        public MainPage()
        {
            InitializeComponent();

            lstAlunos.ItemsSource = a.Listar("");
        }

        void Limpar()
        {
            txtId.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtCurso.Text = String.Empty;
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                DisplayAlert("Atenção", "Por favor insira um nome", "OK");
                return;
            }

            a = new Aluno
            {
                Nome = txtNome.Text,
                Curso = txtCurso.Text
            };

            a.Adicionar(a);
            lstAlunos.ItemsSource = a.Listar("");
            Limpar();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                DisplayAlert("Atenção", "Por favor insira um ID", "OK");
                return;
            }

            a = new Aluno
            {
                Id = int.Parse(txtId.Text),
                Nome = txtNome.Text,
                Curso = txtCurso.Text
            };

            a.Atualizar(a);
            lstAlunos.ItemsSource = a.Listar("");
            Limpar();
        }

        private void btnExcluir_Clicked(object sender, EventArgs e)
        {

        }

        private void sbAluno_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstAlunos.ItemsSource = a.Listar(sbAluno.Text);
        }

        private void lstAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            a = e.SelectedItem as Aluno;

            txtId.Text = a.Id.ToString();
            txtNome.Text = a.Nome;
            txtCurso.Text = a.Curso;
        }

        private void btnFinalizar_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
