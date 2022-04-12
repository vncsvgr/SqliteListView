using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace SqliteListView
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }

        SQLiteConnection db;

        public Aluno()
        {
            db = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "escola.db"));
            db.CreateTable<Aluno>();
        }

        public void Adicionar(Aluno a)
        {
            db.Insert(a);
        }

        public void Atualizar(Aluno a)
        {
            db.Update(a);
        }

        public void Excluir(Aluno a)
        {
            db.Delete(a);
        }

        public List<Aluno> Listar(string nome)
        {
            return db.Table<Aluno>().Where(i => i.Nome.ToUpper().Contains(nome.ToUpper())).ToList();
        }
    }
}