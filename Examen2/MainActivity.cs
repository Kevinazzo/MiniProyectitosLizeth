using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
namespace Examen2
{
	[Activity(Label = "Examen2", MainLauncher = true)]
	public class MainActivity : Activity
	{
		#region hardcoded DB
		public Dictionary<string, string> db = new Dictionary<string, string>()
		{
			{"Aguascalientes","Aguascalientes" },
			{"Baja california", "Mexicali" },
			{"Baja California Sur", "La Paz" },
			{"Campeche","San Francisco de Campeche" },
			{"Chiapas","Tuxtla Gutierrez" },
			{"Chihuahua","Chihuahua" },
			{"Ciudad de Mexico","Ciudad de Mexico" },
			{"Coahuila","Saltillo" },
			{"Colima","Colima" },
			{"Durango","Victoria de Durango" },
			{"Guanajuato","Guanajuato" },
			{"guerrero","Chilpancingo de los Bravo" },
			{"Hidalgo","Pachuca de Soto" },
			{"Jalisco","Guadalajara" },
			{"Mexico","Toluca de Lerdo" },
			{"Michoacan","Morelia" },
			{"Morelos","Cuernavaca" },
			{"Nayarit","Tepic" },
			{"Nuevo Leon","Monterrey" },
			{"Oaxaca","Oaxaca de Juarez" },
			{"Puebla","Puebla de Zaragoza" },
			{"Queretaro","Santiago de Queretaro" },
			{"Quintana Roo","Chetumal" },
			{"San Luis Potosi","San Luis Potosi" },
			{"Sinaloa","Culiacan Rosales" },
			{"Sonora","Hermosillo" },
			{"Tabasco","Villahermosa" },
			{"Tamaulipas","Ciudad Victoria" },
			{"Tlaxcala","Tlaxcala de Xicohtencatl" },
			{"Veracruz","Xalapa" },
			{"Yucatan","Merida" },
			{"Zacatecas","Zacatecas" }			
		};
		#endregion
		public ListView listview;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);


			listview = FindViewById<ListView>(Resource.Id.estadosListView);
			estadosListAdapter adaptito = new estadosListAdapter(this, db);
			listview.Adapter = adaptito;
		}
	}
}