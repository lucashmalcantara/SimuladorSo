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
using System.Windows.Threading;

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
                TamanhoMB = 100,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(visualStudio);
        }

        private void BtnAppChrome_Click(object sender, RoutedEventArgs e)
        {
            var chrome = new ProcessoDto
            {
                Nome = "Google Chrome",
                TamanhoMB = 128,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(chrome);
        }

        private void BtnAppAdobeReader_Click(object sender, RoutedEventArgs e)
        {
            var adobeReader = new ProcessoDto
            {
                Nome = "Adobe Reader",
                TamanhoMB = 50,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(adobeReader);
        }

        private void BtnAppCmd_Click(object sender, RoutedEventArgs e)
        {
            var cmd = new ProcessoDto
            {
                Nome = "Prompt de Comando",
                TamanhoMB = 8,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(cmd);
        }

        private void BtnAppNetflix_Click(object sender, RoutedEventArgs e)
        {
            var netflix = new ProcessoDto
            {
                Nome = "Netflix",
                TamanhoMB = 70,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(netflix);
        }

        private void BtnAppWord_Click(object sender, RoutedEventArgs e)
        {
            var word = new ProcessoDto
            {
                Nome = "Microsoft Word",
                TamanhoMB = 95,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(word);
        }

        private void BtnAppExcel_Click(object sender, RoutedEventArgs e)
        {
            var excel = new ProcessoDto
            {
                Nome = "Microsoft Excel",
                TamanhoMB = 113,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(excel);
        }

        private void BtnAppPowerPoint_Click(object sender, RoutedEventArgs e)
        {
            var powerPoint = new ProcessoDto
            {
                Nome = "Microsoft PowerPoint",
                TamanhoMB = 60,
                DuracaoSurto = 10
            };

            _simuladorPresenter.Carregar(powerPoint);
        }
        #endregion

        public void ExibirProcessosMemoriaPrincipal(List<ProcessoDto> processos)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                lstMemoriaPrincipal.Items.Clear();

                foreach (var processo in processos)
                    lstMemoriaPrincipal.Items.Add(processo.ToString());
            }));
        }

        public void ExibirProcessosMemoriaSecundaria(List<ProcessoDto> processos)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                lstMemoriaSecundaria.Items.Clear();

                foreach (var processo in processos)
                    lstMemoriaSecundaria.Items.Add(processo.ToString());
            }));
        }

        public void ExibirProcessoCpu(ProcessoDto processo)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                txtProcessoCpu.Clear();

                if (processo != null)
                    txtProcessoCpu.Text = processo.ToString();
            }));
        }
    }
}
