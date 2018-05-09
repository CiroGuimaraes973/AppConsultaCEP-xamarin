using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
		}
        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Logica do programa

            //Validaçoes.
            string cep = CEP.Text.Trim();
            if (isValid(cep))
            {
                try{
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: "+cep, "OK");
                    }
                    
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.Message, "OK");
                }
                
            }
        }
        

        public bool isValid(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP invalido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("EROO!!", "CEP invalido!!. O CEP deve conter apenas numeros!!", "OK");
                valido = false;
            }
            return valido;
        }
	}
}
