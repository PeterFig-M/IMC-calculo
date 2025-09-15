using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace IMC_calculo.ViewModels;

public class IMCViewModel : ObservableObject
{
    private double _altura;
    public double Altura
    {
        get => _altura;
        set => SetProperty(ref _altura, value);
    }

    private double _peso;
    public double Peso
    {
        get => _peso;
        set => SetProperty(ref _peso, value);
    }

    private double _imc;
    public double IMC
    {
        get => _imc;
        private set => SetProperty(ref _imc, value);
    }

    private string _categoria = string.Empty;
    public string Categoria
    {
        get => _categoria;
        private set => SetProperty(ref _categoria, value);
    }

    public ICommand CalcularCommand { get; }

    public IMCViewModel()
    {
        CalcularCommand = new RelayCommand(Calcular);
    }






    private void Calcular()
    {
        if (Altura <= 0 || Peso <= 0)
        {
            IMC = 0;
            Categoria = "Por favor ingresar valores validos";
            return;
        }

        var valor = Peso / Math.Pow(Altura, 2);
        IMC = Math.Round(valor, 2);
        Categoria = Clasificar(IMC);
    }






    private static string Clasificar(double imc)
    {
        if (imc < 18.5) return "Bajo peso";
        if (imc < 25.0) return "Peso saludable";
        if (imc < 30.0) return "Sobrepeso";
        if (imc < 35.0) return "Obesidad clase I";
        if (imc < 40.0) return "Obesidad clase II";
        return "Obesidad clase III, ya pongase a correr :( ";
    }
}
