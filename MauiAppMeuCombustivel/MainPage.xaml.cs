
namespace MauiAppMeuCombustivel
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Recupera a marca e o modelo do veículo
                string marca = txt_marca.Text?.Trim() ?? "";
                string modelo = txt_modelo.Text?.Trim() ?? "";

                // Verifica se marca e modelo foram informados
                if (string.IsNullOrWhiteSpace(marca) ||
                    string.IsNullOrWhiteSpace(modelo))
                {
                    await DisplayAlert(
                        "Atenção",
                        "Informe a marca e o modelo do veículo.",
                        "OK");
                    return;
                }

                // Recupera os preços dos combustíveis
                double etanol = Convert.ToDouble(txt_etanol.Text);
                double gasolina = Convert.ToDouble(txt_gasolina.Text);

                // Verifica se os preços são válidos
                if (etanol < 0 || gasolina <= 0)
                {
                    await DisplayAlert(
                        "Atenção",
                        "Informe preços válidos para os combustíveis.",
                        "OK");
                    return;
                }

                // Compara os preços dos combustíveis
                string msg = "";

                if (etanol <= (gasolina * 0.7))
                {
                    msg = $"O etanol está compensando para o seu {marca} {modelo}.";
                }
                else
                {
                    msg = $"A gasolina está compensando para o seu {marca} {modelo}.";
                }

                // Exibe o resultado
                await DisplayAlert("Calculado", msg, "OK");
            }
            catch (Exception)
            {
                await DisplayAlert(
                    "Ops",
                    "Informe valores numéricos válidos para os combustíveis.",
                    "Fechar");
            }
        }
    }
}
