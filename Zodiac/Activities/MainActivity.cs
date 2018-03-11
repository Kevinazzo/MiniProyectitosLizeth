using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;

namespace Zodiaco
{
	[Activity(Label = "Zodiaco", MainLauncher = true)]
	public class MainActivity : Activity
	{
		//Declaracion de Widgets de XML
		public DatePicker datep;
		public Button btn_calc;

		//Clase horoscopo para que funciona como objecto activo
		public class horoscopo
		{
			public horoscopo()
			{

			}
			public horoscopo(int _mes1, int _mes2, int _dia1, int _dia2)
			{
				mesInicio = _mes1; mesFinal = _mes2;
				diaInicio = _dia1; diaFinal = _dia2;
			}
			public int mesInicio { get; set; }
			public int mesFinal { get; set; }
			public int diaInicio { get; set; }
			public int diaFinal { get; set; }
		}

		//Base de Datos en-memoria
		public Dictionary<string, horoscopo> db = new Dictionary<string, horoscopo>()
		{
			{"Aries", new horoscopo(3,4,21,20) },
			{"Tauro",new horoscopo(4,5,21,20) },
			{"Geminis",new horoscopo(5,6,21,20) },
			{"Cancer",new horoscopo(6,7,21,22) },
			{"Leo",new horoscopo(7,8,23,22) },
			{"Virgo",new horoscopo(8,9,23,21) },
			{"Libra",new horoscopo(9,10,22,22) },
			{"Escorpio",new horoscopo(10,11,23,22) },
			{"Sagitario",new horoscopo(11,12,23,21) },
			{"Capricornio",new horoscopo(12,1,22,21) },
			{"Acuario",new horoscopo(1,2,22,21) },
			{"Piscis",new horoscopo(2,3,22,21) }
		};

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			datep = (DatePicker)FindViewById(Resource.Id.datePicker);
			btn_calc = (Button)FindViewById(Resource.Id.button);


			//Evento Click Del Boton
			btn_calc.Click += delegate
			{
				//en el day-picker enero es el mes #0, por eso se suma 1
				int currentM = datep.Month + 1;
				int currentD = datep.DayOfMonth;

				//Consulta linq a la base de datos
				try
				{
					var result = db.Single(a =>
					(currentM == a.Value.mesInicio && currentD >= a.Value.diaInicio)
					||
					(currentM == a.Value.mesFinal && currentD <= a.Value.diaFinal)
					).Key;
					Toast.MakeText(this, "Su horoscopo es " + result, ToastLength.Short).Show();
				}
				catch (System.Exception)
				{

					Toast.MakeText(this, "Sin Horoscopo:(", ToastLength.Short).Show();
				}
			};
		}
	}
}