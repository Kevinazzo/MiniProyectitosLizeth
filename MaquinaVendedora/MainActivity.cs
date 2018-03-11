using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;

namespace MaquinaVendedora
{
	[Activity(Label = "MaquinaVendedora", MainLauncher = true)]
	public class MainActivity : Activity
	{


		#region var
		public static VendingMachine vendingMachine = new VendingMachine();
		public ImageButton[] imgBtnRow1;
		public ImageButton[] imgBtnRow2;
		public ImageButton[] imgBtnRow3;
		ImageButton imgbtn1;
		ImageButton imgbtn2;
		ImageButton imgbtn3;
		ImageButton imgbtn4;
		ImageButton imgbtn5;
		ImageButton imgbtn6;
		ImageButton imgbtn7;
		ImageButton imgbtn8;
		ImageButton imgbtn9;
		#endregion
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			#region variables
			ImageButton imgbtn1 = FindViewById<ImageButton>(Resource.Id.btn_11);
			ImageButton imgbtn2 = FindViewById<ImageButton>(Resource.Id.btn_12);
			ImageButton imgbtn3 = FindViewById<ImageButton>(Resource.Id.btn_13);
			ImageButton imgbtn4 = FindViewById<ImageButton>(Resource.Id.btn_21);
			ImageButton imgbtn5 = FindViewById<ImageButton>(Resource.Id.btn_22);
			ImageButton imgbtn6 = FindViewById<ImageButton>(Resource.Id.btn_23);
			ImageButton imgbtn7 = FindViewById<ImageButton>(Resource.Id.btn_31);
			ImageButton imgbtn8 = FindViewById<ImageButton>(Resource.Id.btn_32);
			ImageButton imgbtn9 = FindViewById<ImageButton>(Resource.Id.btn_33);
			imgBtnRow1 = new ImageButton[] { imgbtn1, imgbtn2, imgbtn3, };
			imgBtnRow2 = new ImageButton[] { imgbtn4, imgbtn5, imgbtn6, };
			imgBtnRow3 = new ImageButton[] { imgbtn7, imgbtn8, imgbtn9 };
			var metrics = Resources.DisplayMetrics;
			var DpWidth = ConvertPixelsToDp(metrics.WidthPixels);
			var DpHeight = ConvertPixelsToDp(metrics.HeightPixels);
			#endregion
			#region tamaño de los imageButton
			//cambia el tamaño de los botones para que se  ajusten a 1/3 de la pantalla
			foreach (var view in imgBtnRow1)
			{
				var vparams = view.LayoutParameters;
				vparams.Width = ConvertDpToPix(DpWidth) / 3;
				vparams.Height = ConvertDpToPix(DpHeight) / 3;
			}
			foreach (var view in imgBtnRow2)
			{
				var vparams = view.LayoutParameters;
				vparams.Width = ConvertDpToPix(DpWidth) / 3;
				vparams.Height = ConvertDpToPix(DpHeight) / 3;
			}
			foreach (var view in imgBtnRow3)
			{
				var vparams = view.LayoutParameters;
				vparams.Width = ConvertDpToPix(DpWidth) / 3;
				vparams.Height = ConvertDpToPix(DpHeight) / 3;
			}
			#endregion

			vendingMachine.initialize();

			#region añadiendo imagenes a los imageButton
			//set images row 1
			for (int i = 0; i < imgBtnRow1.Length; i++)
			{
				imgBtnRow1[i].SetImageResource(vendingMachine[0, i].img);
			}
			//set images row 2
			for (int i = 0; i < imgBtnRow2.Length; i++)
			{
				imgBtnRow2[i].SetImageResource(vendingMachine[1, i].img);
			}
			//set images row 3
			for (int i = 0; i < imgBtnRow1.Length; i++)
			{
				imgBtnRow3[i].SetImageResource(vendingMachine[2, i].img);
			}
			#endregion
		}
		#region tamaño de la pantalla,Conversion de datos
		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}
		private int ConvertDpToPix(float dpValue)
		{
			var pix = ((dpValue) * Resources.DisplayMetrics.Density);
			return (int)pix;
		}
		#endregion
	}
	#region class:VendingMachine
	public class VendingMachine
	{
		private Product[] db =
		{
			new Product("ElBronco",666.6f,Resource.Drawable.bronco),
			new Product ("Rufles Verdes",15f,Resource.Drawable.ruffles),
			new Product ("Tostitos Flaming Hot",15f,Resource.Drawable.tostitos),
			new Product ("Emperador Chocolate",15f,Resource.Drawable.emperadorChocolate),
			new Product ("Emperador Vainilla",13f,Resource.Drawable.emperadorVainilla),
			new Product ("Mazapan",5f,Resource.Drawable.mazapan),
			new Product ("Mix",10f,Resource.Drawable.Mix),
			new Product ("Chicles",7f,Resource.Drawable.chicles),
			new Product ("Doritos",10f,Resource.Drawable.doritos),
			new Product ("Pay",13f,Resource.Drawable.pay),
			new Product ("Paleta",5f,Resource.Drawable.paleta),
			new Product ("Pulparindo",4.5f,Resource.Drawable.pulparindo),
			new Product ("Halls",9f,Resource.Drawable.halls),
			new Product ("cheetos",8f,Resource.Drawable.cheetos),
			new Product ("Crunch",14f,Resource.Drawable.crunch)
		};
		private Product[,] slots = new Product[3, 3];
		public Product this[int x, int y]
		{
			get { return slots[x, y]; }
		}

		//inicializar maquina vendedora
		public void initialize()
		{
			Random rng = new Random();
			int[] rngResult = new int[9];
			//Escoger 9 productos aleatorios de la base de datos
			for (int i = 0; i < rngResult.Length; i++)
			{

			}

			//colocar los resultados en la matriz o en loss espacios de la maquina 
			int count2 = 0;
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					Product toAdd2 = db[rngResult[count2]];
					slots[x,y] = toAdd2;
					count2++;
				}
			}
		}
	}
	#endregion

	#region class:Product
	public class Product
	{
		public Product()
		{

		}
		public Product(string _name, float _desc, int _img)
		{
			name = _name;
			desc = _desc;
			img = _img;
		}
		public string name { get; set; }
		public float desc { get; set; }
		public int img { get; set; }
	}
	#endregion
}