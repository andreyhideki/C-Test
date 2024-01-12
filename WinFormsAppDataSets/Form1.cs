using System.Data;
using System.Windows.Forms;

namespace WinFormsAppDataSets
{
    public partial class Form1 : Form
    {
        private DataSet masterDataSet;

        public Form1()
        {
            InitializeComponent();
            InitializeDataSet();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarNoDataSet("01", "ChaveUrD1");
        }

        private void InitializeDataSet()
        {
            masterDataSet = new DataSet();

            // Criar DataTable para SEGMENTO D UR AGENDA
            DataTable segmentoDurAgendaTable = new DataTable("SegmentoDurAgenda");
            segmentoDurAgendaTable.Columns.Add("TipoRegistro", typeof(string));
            segmentoDurAgendaTable.Columns.Add("EstabelecimentoSubmissor", typeof(string));
            segmentoDurAgendaTable.Columns.Add("CPFCNPJTitulo", typeof(string));
            segmentoDurAgendaTable.Columns.Add("CPFCNPJRecebedor", typeof(string));
            segmentoDurAgendaTable.Columns.Add("Bandeira", typeof(string));
            segmentoDurAgendaTable.Columns.Add("StatusPagamento", typeof(string));
            segmentoDurAgendaTable.Columns.Add("ValorBruto", typeof(decimal));
            segmentoDurAgendaTable.Columns.Add("ValorLiquido", typeof(decimal));
            segmentoDurAgendaTable.Columns.Add("TipoLancamento", typeof(string));
            segmentoDurAgendaTable.Columns.Add("ChaveUr", typeof(string));

            // Adicionar DataTable ao DataSet
            masterDataSet.Tables.Add(segmentoDurAgendaTable);

            // Criar DataTable para SEGMENTO E UR ANALITICA
            DataTable segmentoEurAnaliticaTable = new DataTable("SegmentoEurAnalitica");
            segmentoEurAnaliticaTable.Columns.Add("TipoRegistro", typeof(string));
            segmentoEurAnaliticaTable.Columns.Add("EstabelecimentoSubmissor", typeof(string));
            segmentoEurAnaliticaTable.Columns.Add("BandeiraLiquidacao", typeof(string));
            segmentoEurAnaliticaTable.Columns.Add("Parcela", typeof(int));
            segmentoEurAnaliticaTable.Columns.Add("CodigoAutorizacao", typeof(string));
            segmentoEurAnaliticaTable.Columns.Add("TipoLancamento", typeof(string));
            segmentoEurAnaliticaTable.Columns.Add("ChaveUr", typeof(string));

            // Adicionar DataTable ao DataSet
            masterDataSet.Tables.Add(segmentoEurAnaliticaTable);

            // Estabelecer relação entre as tabelas usando as colunas TipoLancamento e ChaveUr
            DataRelation relation = new DataRelation("MasterDetailRelation",
                segmentoDurAgendaTable.Columns["ChaveUr"],
                segmentoEurAnaliticaTable.Columns["ChaveUr"]);
            masterDataSet.Relations.Add(relation);
        }

        private void LoadData()
        {
            // Adicionar dados de exemplo ao SEGMENTO D UR AGENDA
            DataTable segmentoDurAgendaTable = masterDataSet.Tables["SegmentoDurAgenda"];
            for (int i = 1; i <= 10; i++)
            {
                segmentoDurAgendaTable.Rows.Add(
                    "TipoRegistroD" + i,
                    "EstabelecimentoD" + i,
                    "CPFCNPJTituloD" + i,
                    "CPFCNPJRecebedorD" + i,
                    "BandeiraD" + i,
                    "StatusPagamentoD" + i,
                    i * 100.0m,
                    i * 90.0m,
                    "01",
                    "ChaveUrD" + i
                );
            }

            // Adicionar dados de exemplo ao SEGMENTO E UR ANALITICA
            DataTable segmentoEurAnaliticaTable = masterDataSet.Tables["SegmentoEurAnalitica"];
            for (int i = 1; i <= 10; i++)
            {
                segmentoEurAnaliticaTable.Rows.Add(
                    "TipoRegistroE" + i,
                    "EstabelecimentoE" + i,
                    "BandeiraLiquidacaoE" + i,
                    i,
                    "CodigoAutorizacaoE" + i,
                    "01",
                    "ChaveUrD" + i
                );
            }

            // Vincular o DataSet ao DataGridView
            dataGridView1.DataSource = masterDataSet.Tables["SegmentoDurAgenda"];
            dataGridView2.DataSource = masterDataSet.Tables["SegmentoEurAnalitica"];

        }

        private void BuscarNoDataSet(string tipoLancamento, string chaveUr)
        {
            // Verificar se o DataSet contém as tabelas necessárias
            if (masterDataSet.Tables.Contains("SegmentoDurAgenda") && masterDataSet.Tables.Contains("SegmentoEurAnalitica"))
            {
                // Buscar na tabela SegmentoDurAgenda
                DataTable segmentoDurAgendaTable = masterDataSet.Tables["SegmentoDurAgenda"];
                DataRow[] resultDurAgenda = segmentoDurAgendaTable.Select($"TipoLancamento = '{tipoLancamento}' AND ChaveUr = '{chaveUr}'");

                // Buscar na tabela SegmentoEurAnalitica
                DataTable segmentoEurAnaliticaTable = masterDataSet.Tables["SegmentoEurAnalitica"];
                DataRow[] resultEurAnalitica = segmentoEurAnaliticaTable.Select($"TipoLancamento = '{tipoLancamento}' AND ChaveUr = '{chaveUr}'");

                // Exibir resultados (pode ser adaptado conforme necessário)
                Console.WriteLine("Resultados de SegmentoDurAgenda:");
                foreach (DataRow row in resultDurAgenda)
                {
                    Console.WriteLine($"TipoLancamento: {row["TipoLancamento"]}, ChaveUr: {row["ChaveUr"]}");
                }

                Console.WriteLine("Resultados de SegmentoEurAnalitica:");
                foreach (DataRow row in resultEurAnalitica)
                {
                    Console.WriteLine($"TipoLancamento: {row["TipoLancamento"]}, ChaveUr: {row["ChaveUr"]}");
                }
            }
            else
            {
                Console.WriteLine("As tabelas necessárias não estão presentes no DataSet.");
            }
        }
    }
}
