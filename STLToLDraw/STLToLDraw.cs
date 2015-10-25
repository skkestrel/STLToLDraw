using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace STLToLDraw
{
	public partial class STLToLDraw : Form
	{
		private OpenFileDialog _ofd;

		public STLToLDraw()
		{
			InitializeComponent();
		}

		private void OpenButtonOnClick(object sender, EventArgs e)
		{
			var _ofd = new OpenFileDialog { Filter = "Stereolithography Files|*.stl" };
			if (_ofd.ShowDialog() == DialogResult.OK)
			{
				using (BinaryReader br = new BinaryReader(_ofd.OpenFile()))
				{
					byte[] header = br.ReadBytes(5);

					if (Encoding.ASCII.GetString(header) == "solid")
					{
						_infoLabel.Text = "ASCII STL files not supported.";
						_ofd = null;
						return;
					}
					else
					{
						_infoLabel.Text = "";
					}
				}
			}
			else
			{
				_ofd = null;
			}
		}

		private void ConvertButtonOnClick(object sender, EventArgs e)
		{
			if (_ofd != null)
			{
				using (BinaryReader br = new BinaryReader(_ofd.OpenFile()))
				{
					byte[] header = br.ReadBytes(80);
					uint n = br.ReadUInt32();

					for (int i = 0; i < n; i++)
					{
						// normal
						br.ReadSingle();
						br.ReadSingle();
						br.ReadSingle();

						Vector3 a = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
						Vector3 b = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
						Vector3 c = new Vector3(br.ReadSingle(), br.ReadSingle(), br.ReadSingle());
						Triangle t = new Triangle(a, b, c);
					}
				}
			}
		}

		private struct Vector3
		{
			public double X;
			public double Y;
			public double Z;

			public Vector3(double x, double y, double z)
			{
				X = x;
				Y = y;
				Z = z;
			}

			public double Length
			{
				get { return Math.Sqrt(X * X + Y * Y + Z * Z); }
			}

			public Vector3 Norm
			{
				get { double len = Length; return new Vector3(X / len, Y / len, Z / len); }
			}


			public double Dot(Vector3 other)
			{
				return X * other.X + Y * other.Y + Z * other.Z;
			}

			public Vector3 Cross(Vector3 other)
			{
				return new Vector3(Y * other.Z - Z * other.Y, Z * other.X - X * other.Z, X * other.Y - Y * other.Z);
			}

			public static Vector3 operator -(Vector3 a, Vector3 b)
			{
				return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
			}

			public static Vector3 operator +(Vector3 a, Vector3 b)
			{
				return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
			}
		}

		private struct Triangle
		{
			public Vector3 A;
			public Vector3 B;
			public Vector3 C;

			public Triangle(Vector3 a, Vector3 b, Vector3 c)
			{
				A = a;
				B = b;
				C = c;
			}

			public Vector3 Normal
			{
				get { return (B - A).Cross(C - A).Norm; }
			}
		}
	}
}
