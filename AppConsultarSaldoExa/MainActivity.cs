using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Android.Views;
using System.Data;


namespace AppConsultarSaldoExa
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var txtNumero = FindViewById<TextView>(Resource.Id.txtnumeroconsultar);
            var txtNumeroRes = FindViewById<TextView>(Resource.Id.txtnumerores);
            var SaldoRes = FindViewById<TextView>(Resource.Id.txtsaldores);
            var btnConsultar = FindViewById<Button>(Resource.Id.btnconsultarsaldo);
            var WS = new Servicio_Web.ServicioConect();

            btnConsultar.Click += delegate
            {
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    var WS = new Servicio_Web.ServicioConect();
                    Conjunto = WS.VerificarSaldo(txtNumero.Text);

                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    txtNumeroRes.Text = "El número de Télefono: " + Renglon["NumTelefono"].ToString();
                    SaldoRes.Text = "Cuenta con: $" + Renglon["Saldo"].ToString() + " de saldo";
                   
                }
                catch (System.Exception)
                {

                }
            };


        }
        
    }
}