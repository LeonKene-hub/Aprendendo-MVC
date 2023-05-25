using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprendendo_MVC.Model
{
    public class Produto
    {
        //propriedade
        public int Codigo { get; set; }
        public string ? Nome { get; set; }
        public float Preco { get; set; }

        //caminho
        private const string PATH = "Database/Produto.csv";

        //criar um construtor
        public Produto()
        {
            //obter o caminho da pasta
            string pasta = PATH.Split("/")[0]; //Database

            //se n tiver, cria uma pasta
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            //se n tiver, cria um arquivo
            if (!File.Exists(PATH))
            {
                File.Create(PATH);
            }
        }

        public List<Produto> Ler()
        {
            //instanciar uma lista de produtos
            List<Produto> produtos = new List<Produto>();

            //array de string que recebe cada linha
            string[] linhas = File.ReadAllLines(PATH);

            foreach (string item in linhas)
            {
                string[] atributos = item.Split(";");
                Produto p = new Produto();

                p.Codigo = int.Parse(atributos[0]);
                p.Nome = atributos[1];
                p.Preco = float.Parse(atributos[2]);

                produtos.Add(p);
            }
            return produtos;
        }

        //metodo para preparar a linha do csv
        public string PrepararLinhasCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //metodo para inserir um produto no arquivo csv
        public void Inserir(Produto p)
        {
            string[] linhas = {PrepararLinhasCSV(p)};
            File.AppendAllLines(PATH, linhas);
        }
    }
}