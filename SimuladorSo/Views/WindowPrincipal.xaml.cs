using SimuladorSo.Dtos;
using SimuladorSo.Presenters;
using SimuladorSo.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimuladorSo.Views
{
    /// <summary>
    /// Interaction logic for WindowPrincipal.xaml
    /// </summary>
    public partial class WindowPrincipal : Window, ISimuladorView
    {
        private SimuladorPresenter _simuladorPresenter;
        public WindowPrincipal()
        {
            InitializeComponent();
            _simuladorPresenter = new SimuladorPresenter(this);
        }

        #region Aplicações
        private void BtnAppVisualStudio_Click(object sender, RoutedEventArgs e)
        {
            var visualStudio = new ProcessoDto
            {
                Nome = "Visual Studio",
                //TamanhoMB = 128
                TamanhoMB = 129
            };

            _simuladorPresenter.Carregar(visualStudio);
        }
        #endregion

        public void ExibirProcessosMemoriaPrincipal(List<ProcessoDto> processos)
        {
            lstMemoriaPrincipal.Items.Clear();

            foreach (var processo in processos)
                lstMemoriaPrincipal.Items.Add(processo.ToString());
        }
    }
}
